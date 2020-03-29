namespace Bank.Forms
{
    partial class frmFDReport
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
            this.fixedDepositeTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.FixedDepositeTableAdapter();
            this.accountMasterTableAdapter1 = new Bank.Forms.BankDataSet2TableAdapters.AccountMasterTableAdapter();
            this.fixedDepositeTableAdapter2 = new Bank.Forms.BankDataSet2TableAdapters.FixedDepositeTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.FDReport1 = new Bank.Forms.FDReport();
            this.SuspendLayout();
            // 
            // fixedDepositeTableAdapter1
            // 
            this.fixedDepositeTableAdapter1.ClearBeforeFill = true;
            // 
            // accountMasterTableAdapter1
            // 
            this.accountMasterTableAdapter1.ClearBeforeFill = true;
            // 
            // fixedDepositeTableAdapter2
            // 
            this.fixedDepositeTableAdapter2.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-2, 1);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.FDReport1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1280, 680);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // frmFDReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 664);
            this.Controls.Add(this.crystalReportViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmFDReport";
            this.Text = "Fixed Deposite Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFDReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private FDReport FDReport1;
        private Bank.Forms.BankDataSet2TableAdapters.FixedDepositeTableAdapter fixedDepositeTableAdapter1;
        private Bank.Forms.BankDataSet2TableAdapters.AccountMasterTableAdapter accountMasterTableAdapter1;
        private Bank.Forms.BankDataSet2TableAdapters.FixedDepositeTableAdapter fixedDepositeTableAdapter2;

    }
}