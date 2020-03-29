namespace Bank.Forms
{
    partial class frmDepositeWithdrawal
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbChq = new System.Windows.Forms.RadioButton();
            this.rdbSelf = new System.Windows.Forms.RadioButton();
            this.rdbTransfer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDwWithdrawal = new System.Windows.Forms.RadioButton();
            this.rdbDwDeposite = new System.Windows.Forms.RadioButton();
            this.txtToAcNo = new System.Windows.Forms.TextBox();
            this.txtDwChqNo = new System.Windows.Forms.TextBox();
            this.txtDwAmount = new System.Windows.Forms.TextBox();
            this.txtDwBal = new System.Windows.Forms.TextBox();
            this.txtDwAcNo = new System.Windows.Forms.TextBox();
            this.txtTransaction = new System.Windows.Forms.TextBox();
            this.lblToAccNo = new System.Windows.Forms.Label();
            this.lblChqNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bankDataSet21 = new Bank.Forms.BankDataSet2();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.transactionTableTableAdapter = new Bank.Forms.BankDataSet2TableAdapters.TransactionTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.left_right;
            this.pictureBox1.Location = new System.Drawing.Point(55, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 46);
            this.pictureBox1.TabIndex = 93;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(481, 417);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 39);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(365, 417);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 39);
            this.btnDelete.TabIndex = 91;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(249, 417);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 39);
            this.btnUpdate.TabIndex = 90;
            this.btnUpdate.Text = "EDIT";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(133, 417);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 39);
            this.btnAdd.TabIndex = 89;
            this.btnAdd.Text = "SAVE";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(17, 417);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(94, 39);
            this.btnAddNew.TabIndex = 88;
            this.btnAddNew.Text = "CLEAR";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(355, 1);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 87;
            this.dateTimePicker2.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(334, 46);
            this.label7.TabIndex = 86;
            this.label7.Text = "DEPOSITE / WITHDRAWAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(278, 86);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 26);
            this.btnView.TabIndex = 74;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbChq);
            this.groupBox2.Controls.Add(this.rdbSelf);
            this.groupBox2.Controls.Add(this.rdbTransfer);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(300, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 63);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction Way";
            // 
            // rdbChq
            // 
            this.rdbChq.AutoSize = true;
            this.rdbChq.Location = new System.Drawing.Point(82, 30);
            this.rdbChq.Name = "rdbChq";
            this.rdbChq.Size = new System.Drawing.Size(78, 23);
            this.rdbChq.TabIndex = 8;
            this.rdbChq.TabStop = true;
            this.rdbChq.Text = "Cheque";
            this.rdbChq.UseVisualStyleBackColor = true;
            this.rdbChq.CheckedChanged += new System.EventHandler(this.rdbChq_CheckedChanged);
            // 
            // rdbSelf
            // 
            this.rdbSelf.AutoSize = true;
            this.rdbSelf.Location = new System.Drawing.Point(9, 30);
            this.rdbSelf.Name = "rdbSelf";
            this.rdbSelf.Size = new System.Drawing.Size(53, 23);
            this.rdbSelf.TabIndex = 7;
            this.rdbSelf.TabStop = true;
            this.rdbSelf.Text = "Self";
            this.rdbSelf.UseVisualStyleBackColor = true;
            // 
            // rdbTransfer
            // 
            this.rdbTransfer.AutoSize = true;
            this.rdbTransfer.Location = new System.Drawing.Point(166, 30);
            this.rdbTransfer.Name = "rdbTransfer";
            this.rdbTransfer.Size = new System.Drawing.Size(84, 23);
            this.rdbTransfer.TabIndex = 10;
            this.rdbTransfer.TabStop = true;
            this.rdbTransfer.Text = "Transfer";
            this.rdbTransfer.UseVisualStyleBackColor = true;
            this.rdbTransfer.CheckedChanged += new System.EventHandler(this.rdbTransfer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDwWithdrawal);
            this.groupBox1.Controls.Add(this.rdbDwDeposite);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(300, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 65);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction";
            // 
            // rdbDwWithdrawal
            // 
            this.rdbDwWithdrawal.AutoSize = true;
            this.rdbDwWithdrawal.Location = new System.Drawing.Point(127, 28);
            this.rdbDwWithdrawal.Name = "rdbDwWithdrawal";
            this.rdbDwWithdrawal.Size = new System.Drawing.Size(107, 23);
            this.rdbDwWithdrawal.TabIndex = 6;
            this.rdbDwWithdrawal.TabStop = true;
            this.rdbDwWithdrawal.Text = "WithDrawal";
            this.rdbDwWithdrawal.UseVisualStyleBackColor = true;
            // 
            // rdbDwDeposite
            // 
            this.rdbDwDeposite.AutoSize = true;
            this.rdbDwDeposite.Location = new System.Drawing.Point(26, 28);
            this.rdbDwDeposite.Name = "rdbDwDeposite";
            this.rdbDwDeposite.Size = new System.Drawing.Size(87, 23);
            this.rdbDwDeposite.TabIndex = 5;
            this.rdbDwDeposite.TabStop = true;
            this.rdbDwDeposite.Text = "Deposite";
            this.rdbDwDeposite.UseVisualStyleBackColor = true;
            // 
            // txtToAcNo
            // 
            this.txtToAcNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToAcNo.Location = new System.Drawing.Point(117, 332);
            this.txtToAcNo.Name = "txtToAcNo";
            this.txtToAcNo.Size = new System.Drawing.Size(141, 26);
            this.txtToAcNo.TabIndex = 83;
            this.txtToAcNo.Visible = false;
            this.txtToAcNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToAcNo_KeyPress);
            // 
            // txtDwChqNo
            // 
            this.txtDwChqNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwChqNo.Location = new System.Drawing.Point(117, 275);
            this.txtDwChqNo.Name = "txtDwChqNo";
            this.txtDwChqNo.Size = new System.Drawing.Size(141, 26);
            this.txtDwChqNo.TabIndex = 82;
            this.txtDwChqNo.Visible = false;
            this.txtDwChqNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDwChqNo_KeyPress);
            // 
            // txtDwAmount
            // 
            this.txtDwAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwAmount.Location = new System.Drawing.Point(117, 210);
            this.txtDwAmount.Name = "txtDwAmount";
            this.txtDwAmount.Size = new System.Drawing.Size(141, 26);
            this.txtDwAmount.TabIndex = 79;
            this.txtDwAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDwAmount_KeyPress);
            // 
            // txtDwBal
            // 
            this.txtDwBal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwBal.Location = new System.Drawing.Point(117, 151);
            this.txtDwBal.Name = "txtDwBal";
            this.txtDwBal.Size = new System.Drawing.Size(141, 26);
            this.txtDwBal.TabIndex = 76;
            this.txtDwBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDwBal_KeyPress);
            // 
            // txtDwAcNo
            // 
            this.txtDwAcNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwAcNo.Location = new System.Drawing.Point(117, 89);
            this.txtDwAcNo.Name = "txtDwAcNo";
            this.txtDwAcNo.Size = new System.Drawing.Size(141, 26);
            this.txtDwAcNo.TabIndex = 72;
            this.txtDwAcNo.Leave += new System.EventHandler(this.txtDwAcNo_Leave);
            // 
            // txtTransaction
            // 
            this.txtTransaction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransaction.Location = new System.Drawing.Point(415, 129);
            this.txtTransaction.Name = "txtTransaction";
            this.txtTransaction.Size = new System.Drawing.Size(141, 26);
            this.txtTransaction.TabIndex = 71;
            this.txtTransaction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaction_KeyPress);
            // 
            // lblToAccNo
            // 
            this.lblToAccNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToAccNo.Location = new System.Drawing.Point(-4, 332);
            this.lblToAccNo.Name = "lblToAccNo";
            this.lblToAccNo.Size = new System.Drawing.Size(125, 23);
            this.lblToAccNo.TabIndex = 81;
            this.lblToAccNo.Text = "To Account No:";
            this.lblToAccNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToAccNo.Visible = false;
            // 
            // lblChqNo
            // 
            this.lblChqNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChqNo.Location = new System.Drawing.Point(17, 278);
            this.lblChqNo.Name = "lblChqNo";
            this.lblChqNo.Size = new System.Drawing.Size(94, 23);
            this.lblChqNo.TabIndex = 80;
            this.lblChqNo.Text = "Cheque No:";
            this.lblChqNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChqNo.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 78;
            this.label4.Text = "Amount:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "Balance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 75;
            this.label2.Text = "Account No:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 73;
            this.label1.Text = "Transaction:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bankDataSet21
            // 
            this.bankDataSet21.DataSetName = "BankDataSet2";
            this.bankDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "TransactionTable";
            this.bindingSource1.DataSource = this.bankDataSet21;
            // 
            // transactionTableTableAdapter
            // 
            this.transactionTableTableAdapter.ClearBeforeFill = true;
            // 
            // frmDepositeWithdrawal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 470);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtToAcNo);
            this.Controls.Add(this.txtDwChqNo);
            this.Controls.Add(this.txtDwAmount);
            this.Controls.Add(this.txtDwBal);
            this.Controls.Add(this.txtDwAcNo);
            this.Controls.Add(this.txtTransaction);
            this.Controls.Add(this.lblToAccNo);
            this.Controls.Add(this.lblChqNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDepositeWithdrawal";
            this.Text = "Deposite/Withdrawal";
            this.Load += new System.EventHandler(this.frmDepositeWithdrawal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbChq;
        private System.Windows.Forms.RadioButton rdbSelf;
        private System.Windows.Forms.RadioButton rdbTransfer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDwWithdrawal;
        private System.Windows.Forms.RadioButton rdbDwDeposite;
        private System.Windows.Forms.TextBox txtToAcNo;
        private System.Windows.Forms.TextBox txtDwChqNo;
        private System.Windows.Forms.TextBox txtDwAmount;
        private System.Windows.Forms.TextBox txtDwBal;
        private System.Windows.Forms.TextBox txtDwAcNo;
        private System.Windows.Forms.TextBox txtTransaction;
        private System.Windows.Forms.Label lblToAccNo;
        private System.Windows.Forms.Label lblChqNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BankDataSet2 bankDataSet21;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Bank.Forms.BankDataSet2TableAdapters.TransactionTableTableAdapter transactionTableTableAdapter;
    }
}