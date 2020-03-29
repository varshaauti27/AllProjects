using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank.Forms
{
    public partial class frmLockerDetails : Form
    {
        public frmLockerDetails()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewClass vc = new ViewClass();
            DataSet ds = new DataSet();
            ds = vc.getlocker1(long.Parse(txtAccountNo.Text));
            dataGridLocker.DataSource = ds;
            dataGridLocker.DataMember = "LockerDetails1";
        }



      
    }
}
