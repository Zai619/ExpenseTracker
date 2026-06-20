using System;
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

                // 核心防呆：當資料庫撈出的分類不在選單清單中時，默默吸收錯誤不閃退
                dgvAccount.DataError += (s, ev) => { ev.ThrowException = false; };

                dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpEnd.Value = DateTime.Now;
                // 連線成功，預先載入一次資料
                if (cmbFilterCategory.Items.Count > 0)
                {
                    cmbFilterCategory.SelectedIndex = 0;
                }

                // 3. 程式啟動時，直接執行連動篩選！
                AutoFilter();
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("提醒：本專案使用 LocalDB 服務，若未安裝可能無法正常讀寫資料庫。\n錯誤訊息：" + ex.Message,
                                "系統連線提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRun.Enabled = false;
                btnShow.Enabled = false;
            }
        }

        private void ShowData()
        {
            dgvAccount.Rows.Clear();
            dgvAccount.Columns.Clear();

            dgvAccount.Columns.Add("Id", "序號");
            dgvAccount.Columns.Add("日期", "日期");

            // 建立下拉選單欄位
            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.Name = "分類";
            cmbCol.HeaderText = "分類";
            cmbCol.Items.Add("食");
            cmbCol.Items.Add("衣");
            cmbCol.Items.Add("住");
            cmbCol.Items.Add("行");
            cmbCol.Items.Add("育");
            cmbCol.Items.Add("樂");
            cmbCol.Items.Add("其他");
            cmbCol.Items.Add("午餐"); // 補上測試資料的分類，避免顯示空白
            dgvAccount.Columns.Add(cmbCol);

            dgvAccount.Columns.Add("金額", "金額");
            dgvAccount.Columns.Add("備註", "備註");

            dgvAccount.Columns["Id"].Width = 60;
            dgvAccount.Columns["金額"].Width = 80;

            try
            {
                string sqlStr = "SELECT * FROM accountBook ORDER BY 日期 DESC";
                SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlDb);
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    dgvAccount.Rows.Add(
                        sqlDr["Id"].ToString(),
                        Convert.ToDateTime(sqlDr["日期"]).ToShortDateString(),
                        sqlDr["分類"].ToString().Trim(),
                        sqlDr["金額"].ToString(),
                        sqlDr["備註"].ToString()
                    );
                }
                sqlDr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取資料庫失敗：" + ex.Message);
            }
        }
        private void ShowData(DateTime startDate, DateTime endDate, string category)
        {
            // 1. 清空表格
            dgvAccount.Rows.Clear();
            dgvAccount.Columns.Clear();

            // 2. 建立標題欄位
            dgvAccount.Columns.Add("Id", "序號");
            dgvAccount.Columns.Add("日期", "日期");
            dgvAccount.Columns.Add("分類", "分類");
            dgvAccount.Columns.Add("金額", "金額");
            dgvAccount.Columns.Add("備註", "備註");
            dgvAccount.Columns["Id"].Width = 60;
            dgvAccount.Columns["金額"].Width = 80;

            try
            {
                // 3. 利用 WHERE 組合多條件篩選 SQL 指令 (對應投影片 WHERE 查詢條件概念)
                // 基本條件：篩選在 startDate 與 endDate 之間的日期
                string sqlStr = "SELECT * FROM accountBook WHERE 日期 BETWEEN @start AND @end";

                // 如果類別不是選擇「全部」，就再用 AND 串接類別條件
                if (category != "全部" && !string.IsNullOrEmpty(category))
                {
                    sqlStr += " AND 分類 = @category";
                }

                // 最後加上最新日期排序
                sqlStr += " ORDER BY 日期 DESC";

                // 4. 使用參數化查詢（防範 SQL 注入，也避免日期字串格式出錯）
                SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlDb);
                sqlCmd.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"));
                sqlCmd.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"));

                if (category != "全部" && !string.IsNullOrEmpty(category))
                {
                    sqlCmd.Parameters.AddWithValue("@category", category);
                }

                // 5. 執行並透過 Reader 讀取資料填入表格 (對應投影片 Reader 邏輯)
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();
                while (sqlDr.Read() != false)
                {
                    dgvAccount.Rows.Add(
                        sqlDr["Id"].ToString(),
                        Convert.ToDateTime(sqlDr["日期"]).ToShortDateString(),
                        sqlDr["分類"].ToString().Trim(),
                        sqlDr["金額"].ToString(),
                        sqlDr["備註"].ToString()
                    );
                }
                sqlDr.Close(); // 務必關閉 Reader
            }
            catch (Exception ex)
            {
                MessageBox.Show("篩選失敗：" + ex.Message);
            }
        }
        private void AutoFilter()
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;
            string cat = cmbFilterCategory.Text;

            // 如果開始日期大於結束日期，就不動作（防呆）
            if (start > end) return;

            // 自動執行我們在上一步寫好的篩選 ShowData
            ShowData(start, end, cat);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowData();
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
            if ((func == 1 || func == 2) && string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("請輸入金額！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlStr = "";

            switch (func)
            {
                case 1:
                    sqlStr = $"INSERT INTO accountBook (日期, 分類, 金額, 備註) VALUES ('{dtpDate.Value:yyyy-MM-dd}', N'{cmbCategory.Text}', {txtAmount.Text}, N'{txtMemo.Text}')";
                    break;

                case 2:
                    if (dgvAccount.CurrentRow == null || dgvAccount.CurrentRow.IsNewRow || dgvAccount.CurrentRow.Cells["Id"].Value == null) return;
                    string updateId = dgvAccount.CurrentRow.Cells["Id"].Value.ToString();
                    sqlStr = $"UPDATE accountBook SET 日期='{dtpDate.Value:yyyy-MM-dd}', 分類=N'{cmbCategory.Text}', 金額={txtAmount.Text}, 備註=N'{txtMemo.Text}' WHERE Id = {updateId}";
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
                ShowData();
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
                txtAmount.Text = row.Cells["金額"].Value?.ToString() ?? "";
                txtMemo.Text = row.Cells["備註"].Value?.ToString() ?? "";
            }
        }

        // 表格內選單變更時自動同步寫入資料庫
        private void dgvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 確保改到的是「分類」欄位 (index = 2) 且連線存在
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("同步資料庫失敗：" + ex.Message);
                    }
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            AutoFilter();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            AutoFilter();
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoFilter();

        }
    }
}