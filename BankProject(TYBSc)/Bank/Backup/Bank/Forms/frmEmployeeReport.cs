using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank.Forms
{
    public partial class frmEmployeeReport : Form
    {
        public frmEmployeeReport()
        {
            InitializeComponent();
        }

        private void frmEmployeeReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=PRAVIN\\SQLEXPRESS;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();

            CrystalReport11 = new CrystalReport1();

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);

            cmd = new SqlCommand("Select * from Employee", con);

            cmd.CommandType = CommandType.Text; ;
            Da.SelectCommand = cmd;
            Da.Fill(Ds, "Employee");
            CrystalReport11.SetDataSource(Ds);
            crystalReportViewer1.ReportSource = CrystalReport11;

        }      
    }
}
