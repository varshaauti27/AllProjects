namespace Bank.Forms
{
    partial class frmLoanReport
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
            this.homeStudentLoanTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.HomeStudentLoanTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.LoanReport1 = new Bank.Forms.LoanReport();
            this.loanTransactionTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.LoanTransactionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).BeginInit();
            this.SuspendLayout();
            // 
            // bankDataSet21
            // 
            this.bankDataSet21.DataSetName = "BankDataSet2";
            this.bankDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // homeStudentLoanTableAdapter1
            // 
            this.homeStudentLoanTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(1, 2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1280, 680);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            //this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // loanTransactionTableAdapter1
            // 
            this.loanTransactionTableAdapter1.ClearBeforeFill = true;
            // 
            // frmLoanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmLoanReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Loan Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoanReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private LoanReport LoanReport1;
        private BankDataSet2 bankDataSet21;
        private Bank.Forms.BankDataSet2TableAdapters.HomeStudentLoanTableAdapter homeStudentLoanTableAdapter1;
        private Bank.Forms.BankDataSet2TableAdapters.LoanTransactionTableAdapter loanTransactionTableAdapter1;
    }
}