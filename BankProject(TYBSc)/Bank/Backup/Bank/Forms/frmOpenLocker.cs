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
    public partial class frmOpenLocker : Form
    {

        SqlConnection con = new SqlConnection();
        InsertClass ic = new InsertClass();
        DeleteClass dc = new DeleteClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();

        public frmOpenLocker()
        {
            InitializeComponent();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            long locker;
            if (ValidateOnAdd())
            {
                ic.addLocker(int.Parse(txtAccNo.Text), Convert.ToDateTime(dateOpen.Text),
                             decimal.Parse(txtDeposite.Text), (cboActive.SelectedItem).ToString(), out locker);

                txtLockerNo.Text = locker.ToString();
                MessageBox.Show("You have open Locker   " + locker + "   Successfuly");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateOnDelete())
            {
                dc.deletLocker(long.Parse(txtLockerNo.Text));
                MessageBox.Show("Locker is deleted");
            }
        }
        public bool ValidateOnAdd()
        {
            DataSet ds = new DataSet();
            ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));
            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Account number is not found");
                return false;
            }
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAccNo.Focus();
                return false;
            }
            if (txtDeposite.Text == "")
            {
                MessageBox.Show("Please Enter the Deposite");
                txtDeposite.Focus();
                return false;
            }
            if (cboActive.Text == "")
            {
                MessageBox.Show("Please select the Activity Status");
                cboActive.Focus();
                return false;
            }
            return true;
        }

        public bool ValidateOnDelete()
        {
            if (txtLockerNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtLockerNo.Focus();
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            if (ValidateOnDelete())
            {
                ds = vc.GetLockerDetails(long.Parse(txtLockerNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_No"].ToString();
                    dateOpen.Text = ds.Tables[0].Rows[0]["OpeningDate"].ToString();
                    txtDeposite.Text = ds.Tables[0].Rows[0]["Deposit_amt"].ToString();

                    //cboActive.DisplayMember = ds.Tables[0].Rows[0]["Active"].ToString();
                    //cboActive.SelectedText = ds.Tables[0].Rows[0]["Active"].ToString();
                    
                    cboActive.SelectedText = ds.Tables[0].Rows[0]["Active"].ToString();

                    txtLockerNo.Text = ds.Tables[0].Rows[0]["LockerNo"].ToString();

                }
                else
                {
                    MessageBox.Show("No Locker Found");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateOnAdd() && ValidateOnDelete())
            {
                ec.updateLocker(long.Parse(txtLockerNo.Text), long.Parse(txtAccNo.Text), DateTime.Parse(dateOpen.Text), long.Parse(txtDeposite.Text), cboActive.SelectedItem.ToString());
                MessageBox.Show("Locker is Updated !!!!");
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            txtDeposite.Text = "";
            txtLockerNo.Text = "";
            cboActive.Text   = " ";

          
        }
        private void txtAccNo_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (txtAccNo.Text != "")
            {
                ds = vc.GetTransaction(long.Parse(txtAccNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Account Number is Found");
                }
                else
                {
                    txtAccNo.Focus();
                    MessageBox.Show("No Account Found Please create Account");
                }
            }
            else
            {
                MessageBox.Show("Plese Enter the Account Number");
            }
        }

        private void txtLockerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 46 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid number");
            }
        }
        private void txtAccNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 46 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid number");
            }
        }
        private void txtDeposite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtDeposite.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }

        private void cboActive_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void frmOpenLocker_Load(object sender, EventArgs e)
        {
            //cboActive.SelectedIndex = 1;
        }

    }
}
