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
    public partial class frmCreateLogin : Form
    {
        ViewClass vc = new ViewClass();
        InsertClass ic = new InsertClass();
        public frmCreateLogin()
        {
            InitializeComponent();
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            int flag;
            if (validateOnAdd())
            {
                vc.seeLogin(txtUserName.Text, out flag);
                if (flag == 1)
                {
                    MessageBox.Show("This user Name is alredy exist please select other User Name");
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    ic.addLogin(txtUserName.Text, txtPassword.Text);
                    MessageBox.Show("Login is created ");
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        public bool validateOnAdd()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter the User Name");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter the Password");
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please enter the Conform password field");
                txtConfirmPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
