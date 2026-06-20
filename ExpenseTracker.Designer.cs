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
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.btnShow = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Location = new System.Drawing.Point(33, 102);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 27;
            this.dgvAccount.Size = new System.Drawing.Size(519, 150);
            this.dgvAccount.TabIndex = 0;
            this.dgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(569, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 367);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帳目資料";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "備註";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "金額";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "類別";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(103, 237);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(100, 34);
            this.txtMemo.TabIndex = 3;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(103, 178);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 34);
            this.txtAmount.TabIndex = 2;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "食",
            "衣",
            "住",
            "行",
            "育",
            "樂",
            "其他"});
            this.cmbCategory.Location = new System.Drawing.Point(149, 97);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 33);
            this.cmbCategory.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(3, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 34);
            this.dtpDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDelete);
            this.groupBox2.Controls.Add(this.rdoUpdate);
            this.groupBox2.Controls.Add(this.rdoAdd);
            this.groupBox2.Location = new System.Drawing.Point(113, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作功能";
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(6, 71);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(88, 19);
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
            this.rdoUpdate.Size = new System.Drawing.Size(88, 19);
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
            this.rdoAdd.Size = new System.Drawing.Size(88, 19);
            this.rdoAdd.TabIndex = 0;
            this.rdoAdd.TabStop = true;
            this.rdoAdd.Text = "新增資料";
            this.rdoAdd.UseVisualStyleBackColor = true;
            this.rdoAdd.Click += new System.EventHandler(this.rdoAdd_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(355, 325);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "顯示帳目";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(355, 384);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "執行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(57, 62);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 25);
            this.dtpStart.TabIndex = 5;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(284, 72);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 25);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // cmbFilterCategory
            // 
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
            this.cmbFilterCategory.Location = new System.Drawing.Point(456, 23);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(96, 23);
            this.cmbFilterCategory.TabIndex = 7;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // ExpenseTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 450);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAccount);
            this.Name = "ExpenseTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個人記帳系統";
            this.Load += new System.EventHandler(this.ExpenseTracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
    }
}

