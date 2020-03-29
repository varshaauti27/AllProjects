namespace Bank.Forms
{
    partial class frmLoanTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoanTransaction));
            this.txtAccountNO = new System.Windows.Forms.TextBox();
            this.cboLoanType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtEMI = new System.Windows.Forms.TextBox();
            this.txtIntRate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbChq = new System.Windows.Forms.RadioButton();
            this.rbdSelf = new System.Windows.Forms.RadioButton();
            this.rdbAccount = new System.Windows.Forms.RadioButton();
            this.chqNo = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccountNO
            // 
            this.txtAccountNO.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNO.Location = new System.Drawing.Point(183, 157);
            this.txtAccountNO.Name = "txtAccountNO";
            this.txtAccountNO.Size = new System.Drawing.Size(121, 26);
            this.txtAccountNO.TabIndex = 3;
            this.txtAccountNO.Leave += new System.EventHandler(this.txtAccountNO_Leave);
            this.txtAccountNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNO_KeyPress);
            // 
            // cboLoanType
            // 
            this.cboLoanType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoanType.FormattingEnabled = true;
            this.cboLoanType.Items.AddRange(new object[] {
            "Home Loan",
            "Student Loan",
            "Vehical Loan"});
            this.cboLoanType.Location = new System.Drawing.Point(183, 118);
            this.cboLoanType.Name = "cboLoanType";
            this.cboLoanType.Size = new System.Drawing.Size(121, 27);
            this.cboLoanType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 61;
            this.label1.Text = "Account No: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(213, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 46);
            this.label7.TabIndex = 65;
            this.label7.Text = "LOAN TRANSACTION";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 62;
            this.label2.Text = "Loan Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 66;
            this.label3.Text = "Transaction No: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "Balance: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "EMI: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 69;
            this.label6.Text = "Interest Rate: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransNo
            // 
            this.txtTransNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransNo.Location = new System.Drawing.Point(183, 77);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(121, 26);
            this.txtTransNo.TabIndex = 1;
            this.txtTransNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransNo_KeyPress);
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(183, 196);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(121, 26);
            this.txtBalance.TabIndex = 4;
           
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // txtEMI
            // 
            this.txtEMI.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMI.Location = new System.Drawing.Point(183, 239);
            this.txtEMI.Name = "txtEMI";
            this.txtEMI.Size = new System.Drawing.Size(121, 26);
            this.txtEMI.TabIndex = 5;
            this.txtEMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEMI_KeyPress);
            // 
            // txtIntRate
            // 
            this.txtIntRate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntRate.Location = new System.Drawing.Point(183, 284);
            this.txtIntRate.Name = "txtIntRate";
            this.txtIntRate.Size = new System.Drawing.Size(121, 26);
            this.txtIntRate.TabIndex = 6;
           
            this.txtIntRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntRate_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbChq);
            this.groupBox2.Controls.Add(this.rbdSelf);
            this.groupBox2.Controls.Add(this.rdbAccount);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(74, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 63);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction Way";
            // 
            // rdbChq
            // 
            this.rdbChq.AutoSize = true;
            this.rdbChq.Location = new System.Drawing.Point(6, 30);
            this.rdbChq.Name = "rdbChq";
            this.rdbChq.Size = new System.Drawing.Size(78, 23);
            this.rdbChq.TabIndex = 7;
            this.rdbChq.TabStop = true;
            this.rdbChq.Text = "Cheque";
            this.rdbChq.UseVisualStyleBackColor = true;
            this.rdbChq.CheckedChanged += new System.EventHandler(this.rdbChq_CheckedChanged);
            // 
            // rbdSelf
            // 
            this.rbdSelf.AutoSize = true;
            this.rbdSelf.Location = new System.Drawing.Point(90, 30);
            this.rbdSelf.Name = "rbdSelf";
            this.rbdSelf.Size = new System.Drawing.Size(53, 23);
            this.rbdSelf.TabIndex = 9;
            this.rbdSelf.TabStop = true;
            this.rbdSelf.Text = "Self";
            this.rbdSelf.UseVisualStyleBackColor = true;
            // 
            // rdbAccount
            // 
            this.rdbAccount.AutoSize = true;
            this.rdbAccount.Location = new System.Drawing.Point(155, 30);
            this.rdbAccount.Name = "rdbAccount";
            this.rdbAccount.Size = new System.Drawing.Size(81, 23);
            this.rdbAccount.TabIndex = 10;
            this.rdbAccount.TabStop = true;
            this.rdbAccount.Text = "Account";
            this.rdbAccount.UseVisualStyleBackColor = true;
            // 
            // chqNo
            // 
            this.chqNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chqNo.Location = new System.Drawing.Point(77, 401);
            this.chqNo.Name = "chqNo";
            this.chqNo.Size = new System.Drawing.Size(100, 23);
            this.chqNo.TabIndex = 75;
            this.chqNo.Text = "Cheque No: ";
            this.chqNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chqNo.Visible = false;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(183, 401);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(127, 26);
            this.txtChequeNo.TabIndex = 8;
            this.txtChequeNo.Visible = false;
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(364, 77);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 36);
            this.btnView.TabIndex = 80;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(508, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(392, 447);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 35);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(276, 447);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 35);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "EDIT";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(160, 447);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "SAVE";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(37, 447);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(96, 35);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "CLEAR";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.loan_icon;
            this.pictureBox1.Location = new System.Drawing.Point(160, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // frmLoanTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 494);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtChequeNo);
            this.Controls.Add(this.chqNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtIntRate);
            this.Controls.Add(this.txtEMI);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtTransNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAccountNO);
            this.Controls.Add(this.cboLoanType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoanTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Transaction";
           
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccountNO;
        private System.Windows.Forms.ComboBox cboLoanType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransNo;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtEMI;
        private System.Windows.Forms.TextBox txtIntRate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbChq;
        private System.Windows.Forms.RadioButton rbdSelf;
        private System.Windows.Forms.RadioButton rdbAccount;
        private System.Windows.Forms.Label chqNo;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}