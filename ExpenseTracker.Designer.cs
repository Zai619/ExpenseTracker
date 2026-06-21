namespace ExpenseTracker
{
    partial class ExpenseTracker
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend22 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWallet = new System.Windows.Forms.ComboBox();
            this.rdoIncome = new System.Windows.Forms.RadioButton();
            this.rdoExpense = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.rdoAdd = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chartExpense = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbFilterWallet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Location = new System.Drawing.Point(455, 119);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 27;
            this.dgvAccount.Size = new System.Drawing.Size(712, 150);
            this.dgvAccount.TabIndex = 0;
            this.dgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbWallet);
            this.groupBox1.Controls.Add(this.rdoIncome);
            this.groupBox1.Controls.Add(this.rdoExpense);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(1193, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 385);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帳目資料";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "錢包";
            // 
            // cmbWallet
            // 
            this.cmbWallet.FormattingEnabled = true;
            this.cmbWallet.Location = new System.Drawing.Point(91, 158);
            this.cmbWallet.Name = "cmbWallet";
            this.cmbWallet.Size = new System.Drawing.Size(200, 33);
            this.cmbWallet.TabIndex = 10;
            // 
            // rdoIncome
            // 
            this.rdoIncome.AutoSize = true;
            this.rdoIncome.Location = new System.Drawing.Point(184, 339);
            this.rdoIncome.Name = "rdoIncome";
            this.rdoIncome.Size = new System.Drawing.Size(73, 29);
            this.rdoIncome.TabIndex = 8;
            this.rdoIncome.Text = "收入";
            this.rdoIncome.UseVisualStyleBackColor = true;
            // 
            // rdoExpense
            // 
            this.rdoExpense.AutoSize = true;
            this.rdoExpense.Checked = true;
            this.rdoExpense.Location = new System.Drawing.Point(71, 339);
            this.rdoExpense.Name = "rdoExpense";
            this.rdoExpense.Size = new System.Drawing.Size(73, 29);
            this.rdoExpense.TabIndex = 7;
            this.rdoExpense.TabStop = true;
            this.rdoExpense.Text = "支出";
            this.rdoExpense.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "備註";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "金額";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "類別";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(91, 280);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(200, 34);
            this.txtMemo.TabIndex = 3;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(91, 218);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 34);
            this.txtAmount.TabIndex = 2;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "食",
            "衣",
            "住",
            "行",
            "育",
            "樂",
            "其他"});
            this.cmbCategory.Location = new System.Drawing.Point(91, 100);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 33);
            this.cmbCategory.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(91, 34);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 34);
            this.dtpDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDelete);
            this.groupBox2.Controls.Add(this.rdoUpdate);
            this.groupBox2.Controls.Add(this.rdoAdd);
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(455, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作功能";
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(6, 71);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(113, 29);
            this.rdoDelete.TabIndex = 2;
            this.rdoDelete.Text = "刪除資料";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.Click += new System.EventHandler(this.rdoDelete_Click);
            // 
            // rdoUpdate
            // 
            this.rdoUpdate.AutoSize = true;
            this.rdoUpdate.Location = new System.Drawing.Point(6, 46);
            this.rdoUpdate.Name = "rdoUpdate";
            this.rdoUpdate.Size = new System.Drawing.Size(113, 29);
            this.rdoUpdate.TabIndex = 1;
            this.rdoUpdate.Text = "修改資料";
            this.rdoUpdate.UseVisualStyleBackColor = true;
            this.rdoUpdate.Click += new System.EventHandler(this.rdoUpdate_Click);
            // 
            // rdoAdd
            // 
            this.rdoAdd.AutoSize = true;
            this.rdoAdd.Checked = true;
            this.rdoAdd.Location = new System.Drawing.Point(3, 21);
            this.rdoAdd.Name = "rdoAdd";
            this.rdoAdd.Size = new System.Drawing.Size(113, 29);
            this.rdoAdd.TabIndex = 0;
            this.rdoAdd.TabStop = true;
            this.rdoAdd.Text = "新增資料";
            this.rdoAdd.UseVisualStyleBackColor = true;
            this.rdoAdd.Click += new System.EventHandler(this.rdoAdd_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRun.Location = new System.Drawing.Point(600, 68);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(99, 40);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "執行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(455, 88);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(144, 25);
            this.dtpStart.TabIndex = 5;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(643, 88);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(138, 25);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Items.AddRange(new object[] {
            "全部",
            "食",
            "衣",
            "住",
            "行",
            "育",
            "樂",
            "其他"});
            this.cmbFilterCategory.Location = new System.Drawing.Point(1071, 88);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(96, 23);
            this.cmbFilterCategory.TabIndex = 7;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotal.Location = new System.Drawing.Point(450, 279);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 25);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "總餘額";
            // 
            // chartExpense
            // 
            chartArea22.Name = "ChartArea1";
            this.chartExpense.ChartAreas.Add(chartArea22);
            legend22.Name = "Legend1";
            this.chartExpense.Legends.Add(legend22);
            this.chartExpense.Location = new System.Drawing.Point(24, 36);
            this.chartExpense.Name = "chartExpense";
            series22.ChartArea = "ChartArea1";
            series22.Legend = "Legend1";
            series22.Name = "Series1";
            this.chartExpense.Series.Add(series22);
            this.chartExpense.Size = new System.Drawing.Size(384, 385);
            this.chartExpense.TabIndex = 9;
            this.chartExpense.Text = "chart1";
            // 
            // cmbFilterWallet
            // 
            this.cmbFilterWallet.FormattingEnabled = true;
            this.cmbFilterWallet.Location = new System.Drawing.Point(857, 88);
            this.cmbFilterWallet.Name = "cmbFilterWallet";
            this.cmbFilterWallet.Size = new System.Drawing.Size(121, 23);
            this.cmbFilterWallet.TabIndex = 11;
            this.cmbFilterWallet.SelectedIndexChanged += new System.EventHandler(this.cmbFilterWallet_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(450, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "篩選條件";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(787, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "錢包";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(1007, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "類別";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(607, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "~";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "日期";
            // 
            // ExpenseTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1682, 466);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbFilterWallet);
            this.Controls.Add(this.chartExpense);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAccount);
            this.MinimumSize = new System.Drawing.Size(1700, 513);
            this.Name = "ExpenseTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個人記帳系統";
            this.Load += new System.EventHandler(this.ExpenseTracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoAdd;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.RadioButton rdoUpdate;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.RadioButton rdoIncome;
        private System.Windows.Forms.RadioButton rdoExpense;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpense;
        private System.Windows.Forms.ComboBox cmbWallet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFilterWallet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

