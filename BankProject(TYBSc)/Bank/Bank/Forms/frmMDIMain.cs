using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;



namespace Bank.Forms
{
    public partial class frmMDIMain : Form
    {
        //private int childFormNumber = 0;

        public frmMDIMain()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Log = new Login();
            Log.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInterestRate IR = new frmInterestRate();
            IR.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails Emp = new frmEmployeeDetails();
            Emp.Show();

        }

        private void depositeWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepositeWithdrawal DepWith = new frmDepositeWithdrawal();
            DepWith.Show();

        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanTransaction LT = new frmLoanTransaction();
            LT.Show();

        }

       

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFixedDeposite FD = new frmFixedDeposite();
            FD.Show();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHomeLoan HL = new frmHomeLoan();
            HL.Show();
        }

        private void Loan_transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewLoanTransaction ViewLT = new frmViewLoanTransaction();
            ViewLT.Show();
        }

        private void lockerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLockerDetails LD = new frmLockerDetails();
            LD.Show();
        }

        private void verificationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVerification Verify = new frmVerification();
            Verify.Show();

        }

        private void passbookPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPassbookPrinting pp = new frmPassbookPrinting();
            pp.Show();
        }

        private void checkbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChequeBook CB = new frmChequeBook();
            CB.Show();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fDCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFDCalculator FDC = new frmFDCalculator();
            FDC.Show();


        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalender CL = new frmCalender();
            CL.Show();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start("notepad.exe");



            }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vehicalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVehicalLoan VL = new frmVehicalLoan();
            VL.Show();
        }

       

        private void lockerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpenLocker OL = new frmOpenLocker();
            OL.Show();

        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpenAccount OA = new frmOpenAccount();
            //OA.MdiParent = this;

            OA.Show();
        }

        private void createPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreatePassword CP = new frmCreatePassword();
            //CP.MdiParent  =this ;

            CP.Show ();

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudentLoan SL = new frmStudentLoan();
            SL.Show();
        }

        private void lockApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLock LA = new frmLock();
            LA.Show();
            this.Hide();
        }

        private void unlockApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnlock UA = new frmUnlock();
            UA.Show();
            this.Hide();
        }

        public  void LockedApp()
        {
            lockApplicationToolStripMenuItem.Enabled = false;
            lockerToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = false;
            administratorToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            loanToolStripMenuItem.Enabled = false;
            loanToolStripMenuItem1.Enabled = false;

            reportToolStripMenuItem.Enabled = false;
        }

        public  void UnLockedApp()
        {
            lockApplicationToolStripMenuItem.Enabled = true ;
            lockerToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Enabled = true;
            administratorToolStripMenuItem.Enabled = true;
            transactionToolStripMenuItem.Enabled = true;
            loanToolStripMenuItem.Enabled = true;
            reportToolStripMenuItem.Enabled = true;
            loanToolStripMenuItem1.Enabled = true;

        }

        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            String userName;
            DateTime LT;
            Login LG=new Login ();
            LG.getLoginText(out userName);
            LoginNamepanel.Text = userName;
            LG.getLoginTime(out LT);
            LoginTimePanel.Text = LT.ToString ();


        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmCustomerReport CR = new frmCustomerReport();
            CR.Show();

        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeReport ER = new frmEmployeeReport();
            ER.Show();


        }

        private void depositReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDepositReport DR = new frmDepositReport();
            //DR.Show();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWithdraw Fw = new frmWithdraw();
            Fw.Show();
        }

        private void fDReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFDReport FR = new frmFDReport();
            FR.Show();
        }

       

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactionReport TR = new frmTransactionReport();
            TR.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout AU = new frmAbout();
            AU .Show ();
            
        }

       
        private void homeVehicaleLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoanReport lr = new frmLoanReport();
            lr.Show();

        }

        private void studentLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentLoanReport SL = new frmStudentLoanReport();
            SL.Show();
        }           

        }
    }
