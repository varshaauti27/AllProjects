namespace Bank.Forms
{
    partial class frmCustomerReport
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
            this.bankDataSet21 = new Bank.Forms.BankDataSet2();
            this.accountMasterTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.AccountMasterTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CustReport1 = new Bank.Forms.CustReport();
            this.transactionTableTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.TransactionTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).BeginInit();
            this.SuspendLayout();
            // 
            // bankDataSet21
            // 
            this.bankDataSet21.DataSetName = "BankDataSet2";
            this.bankDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountMasterTableAdapter1
            // 
            this.accountMasterTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CustReport1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1084, 778);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // transactionTableTableAdapter1
            // 
            this.transactionTableTableAdapter1.ClearBeforeFill = true;
            // 
            // frmCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 778);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmCustomerReport";
            this.Text = "Customer Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BankDataSet2 bankDataSet21;
        private Bank.Forms.BankDataSet2TableAdapters.AccountMasterTableAdapter accountMasterTableAdapter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CustReport CustReport1;
        private Bank.Forms.BankDataSet2TableAdapters.TransactionTableTableAdapter transactionTableTableAdapter1;
    }
}