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
    public partial class frmChequeBook : Form
    {

        InsertClass ic = new InsertClass();
        ViewClass vc = new ViewClass();
        EditClass ec = new EditClass();
        DeleteClass dc = new DeleteClass();
        int i = 0;

        public frmChequeBook()
        {
            InitializeComponent();
        }

       

        private void frmChequeBook_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateOnDelet())
            {
                dc.deletCheqBook(long.Parse(txtAccNo.Text));
                MessageBox.Show("Deleted Request");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidationOnAdd())
            {
                ic.addChqBook(int.Parse(txtAccNo.Text), txtName.Text,
                             int.Parse((cboQty.SelectedItem).ToString()), long.Parse(txtFrom.Text),
                               long.Parse(txtTo.Text));
                MessageBox.Show("Your request is Accepted");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidationOnAdd() && validateOnDelet())
            {
                ec.updateChequeBook(int.Parse(txtAccNo.Text), txtName.Text,
                             int.Parse((cboQty.SelectedItem).ToString()), long.Parse(txtFrom.Text),
                               long.Parse(txtTo.Text));
                MessageBox.Show("Update ChequBook Request of  Account number" + txtAccNo.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool ValidationOnAdd()
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
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter the Name");
                txtName.Focus();
                return false;
            }
            if (cboQty.Text == "")
            {
                MessageBox.Show("Please Enter the Quantity");
                cboQty.Focus();
                return false;
            }
            if (txtFrom.Text == "")
            {
                MessageBox.Show("Please Enter the Number Form");
                txtFrom.Focus();
                return false;
            }
            if (txtTo.Text == "")
            {
                MessageBox.Show("Please Enter the Number To");
                txtTo.Focus();
                return false;
            }
            return true;
        }

        public bool validateOnDelet()
        {
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAccNo.Focus();
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (validateOnDelet())
            {
                ds = vc.GetChequeBook(long.Parse(txtAccNo.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    cboQty.SelectedItem = ds.Tables[0].Rows[0]["Quantity"].ToString();
                    txtFrom.Text = ds.Tables[0].Rows[0]["Chq_No_From"].ToString();
                    txtTo.Text = ds.Tables[0].Rows[0]["Chq_No_To"].ToString();
                    
                }
                else
                {
                    txtTo.Text = "";
                    txtFrom.Text = "";
                    txtName.Text = "";
                    cboQty.Text = "";
                    MessageBox.Show("This account does not hav cheak book facility");

                }
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
                MessageBox.Show("Please enter valid integer");
            }
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 46 || (e.KeyChar == 8))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer");
            }
        }


        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 46 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer");
            }
        }

        private void txtAccNo_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (txtAccNo.Text != "")
            {
                ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));

                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show("This is not valid Account number");
                }
                else
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

                }

            }
            else
            {
                MessageBox.Show("Please enter account number.");
            }
        }
        private void txtFrom_Leave(object sender, EventArgs e)
        {
            i = int.Parse(txtFrom.Text) + int.Parse(cboQty.SelectedItem.ToString());
            txtTo.Text = i.ToString();
        }

        private void cboQty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAccNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            txtFrom.Text = "";
            txtName.Text = "";
            txtTo.Text = "";
        }
    }
}
