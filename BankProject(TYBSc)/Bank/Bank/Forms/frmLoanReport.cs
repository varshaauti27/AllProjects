using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank.Forms
{
    public partial class frmLoanReport : Form
    {
        public frmLoanReport()
        {
            InitializeComponent();
        }

        private void frmLoanReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();

            LoanReport1 = new LoanReport();


            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);
            cmd = new SqlCommand("Select * from LoanTransaction ;Select * from HomeStudentLoan where LoanType='Home Loan'", con);

            cmd.CommandType = CommandType.Text; ;
            Da.SelectCommand = cmd;
            Da.Fill(Ds);
            Ds.Tables[0].TableName = "LoanTransaction";
            Ds.Tables[1].TableName = "HomeStudentLoan";

            LoanReport1.SetDataSource(Ds);

            crystalReportViewer1.ReportSource = LoanReport1;

        }

       
      
    }
}
