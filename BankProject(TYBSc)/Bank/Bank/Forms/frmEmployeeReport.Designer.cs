namespace Bank.Forms
{
    partial class frmEmployeeReport
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
            this.bankDataSet11 = new Bank.Forms.BankDataSet1();
            this.employeeTableAdapter1 = new Bank.Forms.BankDataSet1TableAdapters.EmployeeTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new Bank.Forms.CrystalReport1();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // bankDataSet11
            // 
            this.bankDataSet11.DataSetName = "BankDataSet1";
            this.bankDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeTableAdapter1
            // 
            this.employeeTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1280, 662);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmEmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 662);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmEmployeeReport";
            this.Text = "Employee Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalReport1 CrystalReport11;
        private BankDataSet1 bankDataSet11;
        private Bank.Forms.BankDataSet1TableAdapters.EmployeeTableAdapter employeeTableAdapter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}