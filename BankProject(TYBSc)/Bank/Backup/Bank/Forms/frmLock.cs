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
    public partial class frmLock : Form
    {

        ViewClass vc = new ViewClass();
        public frmLock()
        {
            InitializeComponent();
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this .Hide ();
            frmMDIMain MM=new frmMDIMain ();
            MM.Show();
        }

        private void frmLock_Load(object sender, EventArgs e)
        {
            string UserName;
            Login fm = new Login();
            fm.getLoginText(out UserName);
            txtUser.Text = UserName;
        }

        private void btnOK_Click(object sender, EventArgs e)
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
                    this.Hide();

                    frmMDIMain fm = new frmMDIMain();
                    fm.LockedApp();

                    fm.Show();
                    //timer1.Enabled = true;
                    //progressBar1.Visible = true;
                }
                else
                    MessageBox.Show("Wrong Password");
            }  
          
            }

        }           
          

       

       
    }

