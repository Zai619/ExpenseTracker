using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

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
            // ✨ 啟動安全的美化設定 (只改顏色不改整體大小，保證不跑版)
            ApplySafeModernStyle();

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

                // 程式啟動時同步分類與錢包
                SyncDropdowns();
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

        // ✨ 專屬美化函式：只針對元件上色，絕對不影響排版位置
        private void ApplySafeModernStyle()
        {
            // 表單背景改為清爽的淡色 (不改 Font，避免 AutoScale 跑版)
            this.BackColor = Color.FromArgb(245, 247, 250);

            // 表格美化
            dgvAccount.BackgroundColor = Color.White;
            dgvAccount.BorderStyle = BorderStyle.None;
            dgvAccount.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAccount.EnableHeadersVisualStyles = false;
            dgvAccount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 表格標題列 (深藍底白字)
            dgvAccount.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvAccount.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccount.ColumnHeadersDefaultCellStyle.Font = new Font("微軟正黑體", 10F, FontStyle.Bold);
            dgvAccount.ColumnHeadersHeight = 35;

            // 表格資料列 (隔行換色)
            dgvAccount.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvAccount.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvAccount.RowTemplate.Height = 30;

            // 按鈕美化
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.BackColor = Color.FromArgb(46, 204, 113);
            btnRun.ForeColor = Color.White;
            btnRun.FlatAppearance.BorderSize = 0;
            btnRun.Font = new Font("微軟正黑體", 11F, FontStyle.Bold);
            btnRun.Cursor = Cursors.Hand;

            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.BackColor = Color.FromArgb(52, 73, 94);
            btnShow.ForeColor = Color.White;
            btnShow.FlatAppearance.BorderSize = 0;
            btnShow.Cursor = Cursors.Hand;
        }

        private void SyncDropdowns()
        {
            List<string> cats = new List<string> { "食", "衣", "住", "行", "育", "樂", "其他" };
            List<string> wallets = new List<string> { "現金" };

            try
            {
                SqlCommand cmdCat = new SqlCommand("SELECT DISTINCT 分類 FROM accountBook WHERE 分類 IS NOT NULL", sqlDb);
                SqlDataReader drCat = cmdCat.ExecuteReader();
                while (drCat.Read())
                {
                    string c = drCat[0].ToString().Trim();
                    if (!cats.Contains(c) && !string.IsNullOrEmpty(c)) cats.Add(c);
                }
                drCat.Close();

                SqlCommand cmdWallet = new SqlCommand("SELECT DISTINCT 錢包 FROM accountBook WHERE 錢包 IS NOT NULL", sqlDb);
                SqlDataReader drWallet = cmdWallet.ExecuteReader();
                while (drWallet.Read())
                {
                    string w = drWallet[0].ToString().Trim();
                    if (!wallets.Contains(w) && !string.IsNullOrEmpty(w)) wallets.Add(w);
                }
                drWallet.Close();

                string currentCat = cmbCategory.Text;
                string currentFilterCat = cmbFilterCategory.Text;
                string currentWallet = cmbWallet.Text;
                string currentFilterWallet = cmbFilterWallet.Text;

                cmbCategory.Items.Clear();
                cmbFilterCategory.Items.Clear();
                cmbFilterCategory.Items.Add("全部");

                cmbWallet.Items.Clear();
                cmbFilterWallet.Items.Clear();
                cmbFilterWallet.Items.Add("全部");

                foreach (string c in cats) { cmbCategory.Items.Add(c); cmbFilterCategory.Items.Add(c); }
                foreach (string w in wallets) { cmbWallet.Items.Add(w); cmbFilterWallet.Items.Add(w); }

                cmbCategory.Text = currentCat;
                cmbFilterCategory.Text = cmbFilterCategory.Items.Contains(currentFilterCat) ? currentFilterCat : "全部";
                cmbWallet.Text = string.IsNullOrEmpty(currentWallet) ? "現金" : currentWallet;
                cmbFilterWallet.Text = cmbFilterWallet.Items.Contains(currentFilterWallet) ? currentFilterWallet : "全部";
            }
            catch { }
        }

        private void AutoFilter()
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;
            string cat = cmbFilterCategory.Text;
            string wallet = cmbFilterWallet.Text;

            if (start > end) return;
            ShowData(start, end, cat, wallet);
        }

        private void ShowData(DateTime startDate, DateTime endDate, string category, string wallet)
        {
            dgvAccount.Rows.Clear();
            dgvAccount.Columns.Clear();

            dgvAccount.Columns.Add("Id", "序號");
            dgvAccount.Columns.Add("日期", "日期");

            DataGridViewComboBoxColumn cmbWalletCol = new DataGridViewComboBoxColumn();
            cmbWalletCol.Name = "錢包";
            cmbWalletCol.HeaderText = "錢包";
            cmbWalletCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            foreach (var item in cmbWallet.Items) cmbWalletCol.Items.Add(item);
            dgvAccount.Columns.Add(cmbWalletCol);

            DataGridViewComboBoxColumn cmbCatCol = new DataGridViewComboBoxColumn();
            cmbCatCol.Name = "分類";
            cmbCatCol.HeaderText = "分類";
            cmbCatCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            foreach (var item in cmbCategory.Items) cmbCatCol.Items.Add(item);
            dgvAccount.Columns.Add(cmbCatCol);

            dgvAccount.Columns.Add("金額", "金額");
            dgvAccount.Columns.Add("備註", "備註");

            // 調整欄位寬度與對齊
            dgvAccount.Columns["Id"].Width = 45;
            dgvAccount.Columns["日期"].Width = 85;
            dgvAccount.Columns["錢包"].Width = 80;
            dgvAccount.Columns["分類"].Width = 80;
            dgvAccount.Columns["金額"].Width = 80;
            dgvAccount.Columns["金額"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // ✨ 讓「備註」欄位像彈簧一樣，自動填滿右邊剩下的所有空白
            dgvAccount.Columns["備註"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;    
            int totalAmount = 0, totalIncome = 0, totalExpense = 0;
            Dictionary<string, int> expenseChartData = new Dictionary<string, int>();

            try
            {
                string sqlStr = "SELECT * FROM accountBook WHERE 日期 BETWEEN @start AND @end";

                if (category != "全部" && !string.IsNullOrEmpty(category))
                    sqlStr += " AND 分類 = @category";

                if (wallet != "全部" && !string.IsNullOrEmpty(wallet))
                    sqlStr += " AND 錢包 = @wallet";

                sqlStr += " ORDER BY 日期 DESC";

                SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlDb);
                sqlCmd.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"));
                sqlCmd.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"));

                if (category != "全部" && !string.IsNullOrEmpty(category))
                    sqlCmd.Parameters.AddWithValue("@category", category);

                if (wallet != "全部" && !string.IsNullOrEmpty(wallet))
                    sqlCmd.Parameters.AddWithValue("@wallet", wallet);

                SqlDataReader sqlDr = sqlCmd.ExecuteReader();
                while (sqlDr.Read() != false)
                {
                    int amt = Convert.ToInt32(sqlDr["金額"]);
                    string catName = sqlDr["分類"].ToString().Trim();
                    string rowWallet = sqlDr["錢包"] != DBNull.Value ? sqlDr["錢包"].ToString().Trim() : "現金";

                    totalAmount += amt;
                    if (amt > 0)
                    {
                        totalIncome += amt;
                    }
                    else
                    {
                        int absAmt = Math.Abs(amt);
                        totalExpense += absAmt;

                        if (expenseChartData.ContainsKey(catName))
                            expenseChartData[catName] += absAmt;
                        else
                            expenseChartData.Add(catName, absAmt);
                    }

                    dgvAccount.Rows.Add(
                        sqlDr["Id"].ToString(),
                        Convert.ToDateTime(sqlDr["日期"]).ToShortDateString(),
                        rowWallet,
                        catName,
                        amt.ToString("N0"), // 千分位符號
                        sqlDr["備註"].ToString()
                    );
                }
                sqlDr.Close();

                // 更新總計區塊顏色
                lblTotal.Text = $"總收入：{totalIncome:N0} 元   |   總支出：{totalExpense:N0} 元   |   總結餘：{totalAmount:N0} 元";
                lblTotal.ForeColor = totalAmount < 0 ? Color.FromArgb(231, 76, 60) : Color.FromArgb(39, 174, 96);
                lblTotal.Font = new Font("微軟正黑體", 11F, FontStyle.Bold);

                // ----------------------------------------------------
                // ✨ 重繪精美連動圓餅圖 (Pie Chart)
                // ----------------------------------------------------
                chartExpense.Series.Clear();
                chartExpense.Titles.Clear();
                chartExpense.Legends.Clear();

                chartExpense.BackColor = Color.White;
                chartExpense.Titles.Add("各類別支出比例分析");
                chartExpense.Titles[0].Font = new Font("微軟正黑體", 10F, FontStyle.Bold);

                if (expenseChartData.Count > 0)
                {
                    Legend legend = new Legend("MainLegend");
                    legend.Docking = Docking.Bottom;
                    legend.Font = new Font("微軟正黑體", 9F);
                    chartExpense.Legends.Add(legend);

                    Series series = new Series("ExpenseSeries");
                    series.ChartType = SeriesChartType.Pie;
                    series.IsValueShownAsLabel = true;
                    series.Font = new Font("Consolas", 9F, FontStyle.Bold);

                    // ✨ 修正了之前的錯誤，使用 LabelForeColor 設定圓餅圖上方文字的顏色
                    series.LabelForeColor = Color.White;

                    chartExpense.Palette = ChartColorPalette.Pastel;

                    foreach (var kvp in expenseChartData)
                    {
                        int idx = series.Points.AddXY(kvp.Key, kvp.Value);
                        series.Points[idx].Label = $"{kvp.Value:N0}元";
                        series.Points[idx].LegendText = kvp.Key;
                    }

                    chartExpense.Series.Add(series);
                }
                else
                {
                    chartExpense.Titles.Add("\n(目前區間無支出數據)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("篩選失敗：" + ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e) { AutoFilter(); }

        private void rdoAdd_Click(object sender, EventArgs e)
        {
            func = 1;
            dtpDate.Enabled = true; cmbWallet.Enabled = true; cmbCategory.Enabled = true; txtAmount.Enabled = true; txtMemo.Enabled = true;
        }

        private void rdoUpdate_Click(object sender, EventArgs e)
        {
            func = 2;
            dtpDate.Enabled = true; cmbWallet.Enabled = true; cmbCategory.Enabled = true; txtAmount.Enabled = true; txtMemo.Enabled = true;
        }

        private void rdoDelete_Click(object sender, EventArgs e)
        {
            func = 3;
            dtpDate.Enabled = false; cmbWallet.Enabled = false; cmbCategory.Enabled = false; txtAmount.Enabled = false; txtMemo.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbWallet.Text))
            {
                MessageBox.Show("請選擇或輸入錢包！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("請選擇或輸入類別！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("請輸入金額！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int inputAmount = 0;
            if ((func == 1 || func == 2))
            {
                string cleanAmountText = txtAmount.Text.Replace(",", "");
                if (!int.TryParse(cleanAmountText, out inputAmount))
                {
                    MessageBox.Show("請輸入正確的數字金額！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (rdoExpense.Checked) inputAmount = -Math.Abs(inputAmount);
                else inputAmount = Math.Abs(inputAmount);
            }

            string sqlStr = "";
            switch (func)
            {
                case 1:
                    sqlStr = $"INSERT INTO accountBook (日期, 錢包, 分類, 金額, 備註) VALUES ('{dtpDate.Value:yyyy-MM-dd}', N'{cmbWallet.Text}', N'{cmbCategory.Text}', {inputAmount}, N'{txtMemo.Text}')";
                    break;
                case 2:
                    if (dgvAccount.CurrentRow == null || dgvAccount.CurrentRow.IsNewRow || dgvAccount.CurrentRow.Cells["Id"].Value == null) return;
                    string updateId = dgvAccount.CurrentRow.Cells["Id"].Value.ToString();
                    sqlStr = $"UPDATE accountBook SET 日期='{dtpDate.Value:yyyy-MM-dd}', 錢包=N'{cmbWallet.Text}', 分類=N'{cmbCategory.Text}', 金額={inputAmount}, 備註=N'{txtMemo.Text}' WHERE Id = {updateId}";
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

                SyncDropdowns();
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

                if (row.Cells["日期"].Value != null) dtpDate.Value = Convert.ToDateTime(row.Cells["日期"].Value);

                cmbWallet.Text = row.Cells["錢包"].Value?.ToString().Trim() ?? "現金";
                cmbCategory.Text = row.Cells["分類"].Value?.ToString().Trim() ?? "";

                if (row.Cells["金額"].Value != null)
                {
                    string rawAmt = row.Cells["金額"].Value.ToString().Replace(",", "");
                    int amt = Convert.ToInt32(rawAmt);
                    if (amt < 0) { rdoExpense.Checked = true; txtAmount.Text = Math.Abs(amt).ToString(); }
                    else { rdoIncome.Checked = true; txtAmount.Text = amt.ToString(); }
                }

                txtMemo.Text = row.Cells["備註"].Value?.ToString() ?? "";
            }
        }

        private void dgvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 2 || e.ColumnIndex == 3) && sqlDb != null && sqlDb.State == ConnectionState.Open)
            {
                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != null && row.Cells["錢包"].Value != null && row.Cells["分類"].Value != null)
                {
                    string recordId = row.Cells["Id"].Value.ToString();
                    string newWallet = row.Cells["錢包"].Value.ToString();
                    string newCategory = row.Cells["分類"].Value.ToString();

                    try
                    {
                        string updateSql = $"UPDATE accountBook SET 錢包 = N'{newWallet}', 分類 = N'{newCategory}' WHERE Id = {recordId}";
                        SqlCommand cmd = new SqlCommand(updateSql, sqlDb);
                        cmd.ExecuteNonQuery();

                        SyncDropdowns();
                        AutoFilter();
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
        private void cmbFilterWallet_SelectedIndexChanged(object sender, EventArgs e) { AutoFilter(); }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}