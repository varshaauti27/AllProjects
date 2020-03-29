using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank.Forms
{
    public partial class frmStudentLoanReport : Form
    {
        public frmStudentLoanReport()
        {
            InitializeComponent();
        }

        private void frmStudentLoanReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            StudentLoanReport1 = new StudentLoanReport();
            
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);
            cmd = new SqlCommand("Select * from StudentLoan; Select * from LoanTransaction where Loantype='Student Loan'", con);

            cmd.CommandType = CommandType.Text; ;
            Da.SelectCommand = cmd;
            Da.Fill(Ds);
            Ds.Tables[0].TableName = "StudentLoan";
            Ds.Tables[1].TableName = "LoanTransaction";

            StudentLoanReport1.SetDataSource(Ds);

            crystalReportViewer1.ReportSource = StudentLoanReport1;
        }
    }
}
