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
    public partial class frmCustomerReport : Form
    {
        public frmCustomerReport()
        {
            InitializeComponent();
        }

        private void frmCustomerReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            CustReport1 = new CustReport();

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);
            cmd = new SqlCommand("Select * from AccountMaster ; Select * from TransactionTable", con);

            cmd.CommandType = CommandType.Text;
            Da.SelectCommand = cmd;
            Da.Fill(Ds);
            Ds.Tables[0].TableName = "AccountMaster";
            Ds.Tables[1].TableName = "TransactionTable";

            CustReport1.SetDataSource(Ds);
            crystalReportViewer1.ReportSource = CustReport1;
       
            //crystalReportViewer1.ReportSource = CrystalReport11;
        }

        
              
    }
}
