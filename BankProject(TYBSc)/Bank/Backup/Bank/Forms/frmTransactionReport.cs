﻿using System;
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
    public partial class frmTransactionReport : Form
    {
        public frmTransactionReport()
        {
            InitializeComponent();
        }

        private void frmTransactionReport_Load(object sender, EventArgs e)
        {
            const string constring = "Data Source=PRAVIN\\SQLEXPRESS;Initial Catalog=BanK_DB;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            TransactionReport1 = new TransactionReport();
            
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter Da = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            con = new SqlConnection(constring);
            cmd = new SqlCommand("Select * from TransactionTable", con);

            cmd.CommandType = CommandType.Text; ;
            Da.SelectCommand = cmd;
            Da.Fill(Ds, "TransactionTable");
          
            TransactionReport1.SetDataSource(Ds);
            crystalReportViewer1.ReportSource =TransactionReport1 ;
        }
    }
}
