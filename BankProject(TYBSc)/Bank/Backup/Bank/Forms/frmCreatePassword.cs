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
    public partial class frmCreatePassword : Form
    {
        SqlConnection con = new SqlConnection();
        InsertClass ic = new InsertClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();
        public frmCreatePassword()
        {
            InitializeComponent();
        }

        private void frmCreatePassword_Load(object sender, EventArgs e)
        {
            string username;
            Login fm = new Login();
            fm.getLoginText(out username);
            txtUserName.Text = username;
            if (username == "Master")
            {
                txtUserName.ReadOnly = false;
                btnCreatePassword.Visible = true;
            }
            else
                txtUserName.ReadOnly = true;
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
                }
            }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (validateOnAdd())
            {

                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    ec.updateLogin(txtUserName.Text, txtPassword.Text);
                    MessageBox.Show("You have create Password Successfuly");
                    frmMDIMain  fm = new frmMDIMain ();
                    fm.Show();
                }

                else
                {
                    MessageBox.Show("please conform the password!!!!!");
                    txtPassword.Clear();
                    txtConfirmPassword.Text = "";
                    txtPassword.Focus();
                }
            }
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
