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
    public partial class frmFDReport : Form
    {
        public frmFDReport()
        {
            InitializeComponent();
        }

        private void frmFDReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=PRAVIN\\SQLEXPRESS;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            FDReport1 = new FDReport();

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);
            cmd = new SqlCommand("Select * from FixedDeposite ;Select * from AccountMaster", con);

            cmd.CommandType = CommandType.Text;
            Da.SelectCommand = cmd;

            Da.Fill(Ds);
            Ds.Tables[0].TableName = "FixedDeposite";
            Ds.Tables[1].TableName = "AccountMaster";

            //Da.Fill(Ds, " 'FixedDeposite' , 'AccountMaster' ");
            FDReport1.SetDataSource(Ds);
           
            crystalReportViewer1.ReportSource = FDReport1;
        }
    }
}
