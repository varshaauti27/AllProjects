using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Bank.Forms
{
    public partial class Login : Form
    {

       ViewClass vc = new ViewClass();
       static string UserName = "admin";
       

        public Login()
        {
            InitializeComponent();
        }
        
        /*private void btnLog_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string user = "";
            string pass = "";
            int datediff = 0;

            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                ds = vc.CheckLogin(txtUser.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    user = ds.Tables[0].Rows[0]["UserId"].ToString().TrimEnd();
                    pass = ds.Tables[0].Rows[0]["UserPassword"].ToString().TrimEnd();
                    datediff = int.Parse(ds.Tables[0].Rows[0]["datedif"].ToString());
                }
                else
                {
                    MessageBox.Show("No such User Found");
                }
            }
            else
            {
                MessageBox.Show("Please enter the user name and password");
            }
            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                if (txtUser.Text == user && txtPassword.Text == pass)
                {
                    UserName  = txtUser.Text;
                    if (datediff > 30)
                    {
                        MessageBox.Show("login exp");
                        frmCreatePassword  cp = new frmCreatePassword ();
                        cp.Show();
                    }
                    else
                    {
                        //frmMdiMain fm = new frmMdiMain();
                        //fm.Show();
                        timer1.Enabled = true;
                        progressBar1.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Rong");
                }

            }
            else
            {
                MessageBox.Show("Please Enter the Field");
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();

            }

        }*/
        public void getLoginText(out string user)
        {
            user = UserName;
        }
        public void getLoginTime(out DateTime LTime)
        {

            LTime =DateTime.Now ;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int p=0;
            //p = p + 20;

            if (progressBar1.Value == 100)
            {
                frmMDIMain fm = new frmMDIMain();
                fm.Show();
                this.Hide();
                timer1.Enabled = false;
            }
            else
            {
                progressBar1.Value += 1;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmMDIMain fm = new frmMDIMain();
            fm.Show();
            this.Hide();
        }

              

        
        
        


    }
}