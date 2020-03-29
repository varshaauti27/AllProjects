using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank.Forms
{
    public partial class frmViewLoanTransaction : Form
    {
        public frmViewLoanTransaction()
        {
            InitializeComponent();
        }

        private void frmViewLoanTransaction_Load(object sender, EventArgs e)
        {
            /*string cstr;
        cstr = "Data Source=PRAVIN\\SQLEXPRESS;Initial Catalog=BanK_DB;Integrated Security=True";			
            SqlConnection con1 = new SqlConnection(cstr);			
            con1.Open();			
            SqlCommand com1 = new SqlCommand();			
            com1.Connection = con1;			
            
            com1.CommandType = CommandType.Text;

            com1.CommandText = "select * from LoanTransaction"; 		
            DataSet ds1 = new DataSet();			
            SqlDataAdapter adp1 = new SqlDataAdapter(com1);			
            adp1.Fill(ds1,"LoanTransaction");			
            dataGridView1.DataMember = "LoanTransaction";			
            con1.Close();
            */
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewClass vc = new ViewClass();
            DataSet ds = new DataSet();
            ds = vc.GetLoanTransactionView(long.Parse(txtAccountNo.Text));
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "LoanTransaction";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountNo.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.DataMember = null;
        }

       



        
    }
}
