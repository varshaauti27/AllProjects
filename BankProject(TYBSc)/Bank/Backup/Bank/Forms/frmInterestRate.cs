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
    public partial class frmInterestRate : Form
    {
        InsertClass ic = new InsertClass();
        ViewClass vc = new ViewClass();
        EditClass ec = new EditClass();

        public frmInterestRate()
        {
            InitializeComponent();
        }

        public bool validateOnAdd()
        {
            if (txtHome.Text == "")
            {
                MessageBox.Show("Please Enter The Home Rate");
                txtHome.Focus();
                return false;
            }
            if (txtStudent.Text == "")
            {
                MessageBox.Show("Please Enter The Student Rate");
                txtStudent.Focus();
                return false;
            }
            if (txtVehicale.Text == "")
            {
                MessageBox.Show("Please Enter The Vehicale Rate");
                txtVehicale.Focus();
                return false;
            }
            if (txt45.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 45 Days");
                txt45.Focus();
                return false;
            }
            if (txt90.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 90 Days");
                txt90.Focus();
                return false;
            }
            if (txt180.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 180 Days");
                txt180.Focus();
                return false;
            }
            if (txt540.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 540 Days");
                txt540.Focus();
                return false;
            }
            if (txt1800.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 1800 Days");
                txt1800.Focus();
                return false;
            }
            if (txt1801up.Text == "")
            {
                MessageBox.Show("Please Enter The fixed deposite Rate for 1801 Up");
                txt1801up.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_New_Click(object sender, EventArgs e)
        {
            txt180.Text = "";
            txt1800.Text = "";
            txt1801up.Text = "";
            txt45.Text = "";
            txt540.Text = "";
            txt90.Text = "";
            txtHome.Text = "";
            txtStudent.Text = "";
            txtVehicale.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateOnAdd())
            {
                ic.addInterestRate(decimal.Parse(txtHome.Text), decimal.Parse(txtVehicale.Text), decimal.Parse(txtStudent.Text), decimal.Parse(txt45.Text), decimal.Parse(txt90.Text), decimal.Parse(txt180.Text),
                    decimal.Parse(txt540.Text), decimal.Parse(txt1800.Text), decimal.Parse(txt1801up.Text), dateIntCreate.Value);
                MessageBox.Show("Interest Rate Is Added");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            ds = vc.GetIntRate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHome.Text = ds.Tables[0].Rows[0]["Home"].ToString();
                txtStudent.Text = ds.Tables[0].Rows[0]["Student"].ToString();
                txtVehicale.Text = ds.Tables[0].Rows[0]["Vehical"].ToString();
                txt45.Text = ds.Tables[0].Rows[0]["Fix45"].ToString();
                txt90.Text = ds.Tables[0].Rows[0]["Fix90"].ToString();
                txt180.Text = ds.Tables[0].Rows[0]["Fix180"].ToString();
                txt540.Text = ds.Tables[0].Rows[0]["Fix540"].ToString();
                txt1800.Text = ds.Tables[0].Rows[0]["Fix1800"].ToString();
                txt1801up.Text = ds.Tables[0].Rows[0]["Fix1801"].ToString();

            }
            else
            {
                MessageBox.Show("No Such Employee ID is Found");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateOnAdd())
            {
                ec.updateInterestRate(decimal.Parse(txtHome.Text), decimal.Parse(txtVehicale.Text), decimal.Parse(txtStudent.Text), decimal.Parse(txt45.Text), decimal.Parse(txt90.Text), decimal.Parse(txt180.Text),
                         decimal.Parse(txt540.Text), decimal.Parse(txt1800.Text), decimal.Parse(txt1801up.Text));
                MessageBox.Show("Interest Rate is Updated");
            }
        }
        private void txtHome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtHome.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void txtVehicale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtVehicale.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void txtStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtStudent.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void txt45_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt45.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }


        private void txt90_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt90.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txt180_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt180.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txt540_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt540.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txt1800_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt1800.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txt1801up_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txt1801up.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //frmInterestRate IR = new frmInterestRate();
           // IR.Close();
            this.Close();
        }



       
    }
}
