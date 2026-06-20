using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class ExpenseTracker : Form
    {
        SqlConnection sqlDb = null;
        string cntStr = @"Data Source=(localDB)\MSSQLLocalDB;" +
                        @"AttachDBFilename=|DataDirectory|\account.mdf;";
        int func = 1;

        public ExpenseTracker()
        {
            InitializeComponent();
        }

        private void ExpenseTracker_Load(object sender, EventArgs e)
        {
            try
            {
                sqlDb = new SqlConnection(cntStr);
                sqlDb.Open();
                dgvAccount.RowHeadersVisible = false;
                dgvAccount.AllowUserToAddRows = false;
                dgvAccount.DataError += (s, ev) => { ev.ThrowException = false; };

                // 預設日期區間：這個月 1 號 ~ 今天
                dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpEnd.Value = DateTime.Now;

                // 程式啟動時，先同步一次資料庫裡所有的類別
                SyncCategories();

                // 執行首次連動篩選
                AutoFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("提醒：本專案使用 LocalDB 服務...\n錯誤訊息：" + ex.Message,
                                "系統連線提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRun.Enabled = false;
                btnShow.Enabled = false;
            }
        }

        // ✨ 新增核心功能：從資料庫撈取所有歷史分類，動態更新所有的下拉選單
        private void SyncCategories()
        {
            List<string> cats = new List<string> { "食", "衣", "住", "行", "育", "樂", "其他" }; // 預設底線類別
            try
            {
                // 從資料庫撈出所有不重複的分類
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT 分類 FROM accountBook", sqlDb);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string c = dr[0].ToString().Trim();
                    if (!cats.Contains(c) && !string.IsNullOrEmpty(c)) cats.Add(c);
                }
                dr.Close();

                // 備份使用者目前選取的文字 (避免更新選單時畫面被洗掉)
                string currentCat = cmbCategory.Text;
                string currentFilter = cmbFilterCategory.Text;

                cmbCategory.Items.Clear();
                cmbFilterCategory.Items.Clear();

                cmbFilterCategory.Items.Add("全部"); // 篩選專用

                foreach (string c in cats)
                {
                    cmbCategory.Items.Add(c);
                    cmbFilterCategory.Items.Add(c);
                }

                // 恢復選取狀態
                cmbCategory.Text = currentCat;
                if (cmbFilterCategory.Items.Contains(currentFilter)) cmbFilterCategory.Text = currentFilter;
                else cmbFilterCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private void AutoFilter()
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;
            string cat = cmbFilterCategory.Text;

            if (start > end) return;
            ShowData(start, end, cat);
        }

        private void ShowData(DateTime startDate, DateTime endDate, string category)
        {
            dgvAccount.Rows.Clear();
            dgvAccount.Columns.Clear();

            dgvAccount.Columns.Add("Id", "序號");
            dgvAccount.Columns.Add("日期", "日期");

            // 表格內的下拉選單：直接讀取剛才 SyncCategories 同步好的項目
            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.Name = "分類";
            cmbCol.HeaderText = "分類";
            foreach (var item in cmbCategory.Items)
            {
                cmbCol.Items.Add(item);
            }
            dgvAccount.Columns.Add(cmbCol);

            dgvAccount.Columns.Add("金額", "金額");
            dgvAccount.Columns.Add("備註", "備註");

            dgvAccount.Columns["Id"].Width = 60;
            dgvAccount.Columns["金額"].Width = 80;

            int totalAmount = 0; // 用來計算總金額

            try
            {
                string sqlStr = "SELECT * FROM accountBook WHERE 日期 BETWEEN @start AND @end";

                if (category != "全部" && !string.IsNullOrEmpty(category))
                {
                    sqlStr += " AND 分類 = @category";
                }

                sqlStr += " ORDER BY 日期 DESC";

                SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlDb);
                sqlCmd.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"));
                sqlCmd.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"));

                if (category != "全部" && !string.IsNullOrEmpty(category))
                {
                    sqlCmd.Parameters.AddWithValue("@category", category);
                }

                SqlDataReader sqlDr = sqlCmd.ExecuteReader();
                while (sqlDr.Read() != false)
                {
                    int amt = Convert.ToInt32(sqlDr["金額"]);
                    totalAmount += amt; // 累加總金額

                    dgvAccount.Rows.Add(
                        sqlDr["Id"].ToString(),
                        Convert.ToDateTime(sqlDr["日期"]).ToShortDateString(),
                        sqlDr["分類"].ToString().Trim(),
                        amt.ToString(),
                        sqlDr["備註"].ToString()
                    );
                }
                sqlDr.Close();

                // ✨ 更新總計標籤
                lblTotal.Text = $"總計金額：{totalAmount} 元";
                lblTotal.ForeColor = totalAmount < 0 ? Color.Red : Color.Green; // 負數顯示紅色，正數顯示綠色
            }
            catch (Exception ex)
            {
                MessageBox.Show("篩選失敗：" + ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            AutoFilter();
        }

        private void rdoAdd_Click(object sender, EventArgs e)
        {
            func = 1;
            dtpDate.Enabled = true;
            cmbCategory.Enabled = true;
            txtAmount.Enabled = true;
            txtMemo.Enabled = true;
        }

        private void rdoUpdate_Click(object sender, EventArgs e)
        {
            func = 2;
            dtpDate.Enabled = true;
            cmbCategory.Enabled = true;
            txtAmount.Enabled = true;
            txtMemo.Enabled = true;
        }

        private void rdoDelete_Click(object sender, EventArgs e)
        {
            func = 3;
            dtpDate.Enabled = false;
            cmbCategory.Enabled = false;
            txtAmount.Enabled = false;
            txtMemo.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("請選擇類別！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 中斷函式，不執行後續的 SQL
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("請輸入金額！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 中斷函式
            }

            int inputAmount = 0;

            if ((func == 1 || func == 2))
            {
                if (!int.TryParse(txtAmount.Text, out inputAmount))
                {
                    MessageBox.Show("請輸入正確的數字金額！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✨ 判斷收支：如果選「支出」，將金額轉為負數；如果選「收入」，轉為正數
                if (rdoExpense.Checked)
                    inputAmount = -Math.Abs(inputAmount);
                else
                    inputAmount = Math.Abs(inputAmount);
            }

            string sqlStr = "";

            switch (func)
            {
                case 1:
                    sqlStr = $"INSERT INTO accountBook (日期, 分類, 金額, 備註) VALUES ('{dtpDate.Value:yyyy-MM-dd}', N'{cmbCategory.Text}', {inputAmount}, N'{txtMemo.Text}')";
                    break;

                case 2:
                    if (dgvAccount.CurrentRow == null || dgvAccount.CurrentRow.IsNewRow || dgvAccount.CurrentRow.Cells["Id"].Value == null) return;
                    string updateId = dgvAccount.CurrentRow.Cells["Id"].Value.ToString();
                    sqlStr = $"UPDATE accountBook SET 日期='{dtpDate.Value:yyyy-MM-dd}', 分類=N'{cmbCategory.Text}', 金額={inputAmount}, 備註=N'{txtMemo.Text}' WHERE Id = {updateId}";
                    break;

                case 3:
                    if (dgvAccount.CurrentRow == null || dgvAccount.CurrentRow.IsNewRow || dgvAccount.CurrentRow.Cells["Id"].Value == null) return;
                    string deleteId = dgvAccount.CurrentRow.Cells["Id"].Value.ToString();
                    sqlStr = $"DELETE FROM accountBook WHERE Id = {deleteId}";
                    break;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(sqlStr, sqlDb);
                cmd.ExecuteNonQuery();

                string msg = func == 1 ? "資料已新增" : (func == 2 ? "資料已更新" : "資料已刪除");
                MessageBox.Show(msg, "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                txtMemo.Clear();

                // ✨ 每次資料庫有變動後，重新同步所有類別，並刷新畫面！
                SyncCategories();
                AutoFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("執行失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvAccount.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];

                if (row.Cells["日期"].Value != null)
                    dtpDate.Value = Convert.ToDateTime(row.Cells["日期"].Value);

                cmbCategory.Text = row.Cells["分類"].Value?.ToString().Trim() ?? "";

                // 讀取金額時轉回正數顯示在輸入框，並自動切換收入/支出 RadioButton
                if (row.Cells["金額"].Value != null)
                {
                    int amt = Convert.ToInt32(row.Cells["金額"].Value);
                    if (amt < 0)
                    {
                        rdoExpense.Checked = true;
                        txtAmount.Text = Math.Abs(amt).ToString(); // 介面輸入框保持正數
                    }
                    else
                    {
                        rdoIncome.Checked = true;
                        txtAmount.Text = amt.ToString();
                    }
                }

                txtMemo.Text = row.Cells["備註"].Value?.ToString() ?? "";
            }
        }

        private void dgvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && sqlDb != null && sqlDb.State == ConnectionState.Open)
            {
                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != null && row.Cells["分類"].Value != null)
                {
                    string recordId = row.Cells["Id"].Value.ToString();
                    string newCategory = row.Cells["分類"].Value.ToString();

                    try
                    {
                        string updateSql = $"UPDATE accountBook SET 分類 = N'{newCategory}' WHERE Id = {recordId}";
                        SqlCommand cmd = new SqlCommand(updateSql, sqlDb);
                        cmd.ExecuteNonQuery();

                        // 表格內改完類別，也順便重新同步一次
                        SyncCategories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("同步資料庫失敗：" + ex.Message);
                    }
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e) { AutoFilter(); }
        private void dtpEnd_ValueChanged(object sender, EventArgs e) { AutoFilter(); }
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e) { AutoFilter(); }
    }
}