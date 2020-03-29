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
    public partial class frmEmployeeDetails : Form
    {
        InsertClass ic = new InsertClass();
        DeleteClass dc = new DeleteClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();

        byte[] BEphoto = new byte[100];
        byte[] BESign = new byte[100];

        string EmpPhoto = "", EmpSign = "";

        public frmEmployeeDetails()
        {
            InitializeComponent();
        }

      
        private void cmdPhotoUpload_Click(object sender, EventArgs e)
        {
            if (txtPhoto.Text != "")
            {
                FileStream file = new FileStream(EmpPhoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();

                BEphoto = rawdata;
                MessageBox.Show("Image is uploaded");
                imgPhoto.LoadAsync(txtPhoto.Text);
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Eid = "";
            if (validateAtAdd())
            {
                ic.addEmployee(txtName.Text, txtAddress.Text, cboSex.Text, DateTime.Parse(dateBirthDate.Text), long.Parse(txtPhoneNo.Text), cboJob.Text,
                    decimal.Parse(txtSal.Text), BEphoto, BESign, decimal.Parse(txtBasicSal.Text), decimal.Parse(txtPF.Text), out Eid);
                txtEId.Text = Eid;
                MessageBox.Show("New Employee is Added  " + Eid);
                MessageBox.Show("Please create new employee login and password");
                frmCreateLogin   CL = new frmCreateLogin ();
                CL.Show();
            }
       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (validateOnDelete())
            {
                dc.deletEmployee(long.Parse(txtEId.Text));
                MessageBox.Show("Employee is deleted");
            }
        }

        private void txtBasicSal_TextChanged(object sender, EventArgs e)
        {
            double basSal = 1, pf = 1, TotalSal = 1;
            string txtBasSal = txtBasicSal.Text;
            if (txtBasSal != "")
            {
                basSal = long.Parse(txtBasicSal.Text);

                pf = basSal * 0.05;

                txtPF.Text = pf.ToString();
                TotalSal = basSal + pf;
                txtSal.Text = TotalSal.ToString();
            }
            else
            {
                MessageBox.Show("Plese Enter the Basic sal");
                txtBasicSal.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateAtAdd() && validateOnDelete())
            {
                ec.updateEmployee(long.Parse(txtEId.Text), txtName.Text, txtAddress.Text, (cboSex.SelectedItem).ToString(), Convert.ToDateTime(dateBirthDate.Text), long.Parse(txtPhoneNo.Text), (cboJob.SelectedItem).ToString(), decimal.Parse(txtSal.Text), BEphoto, BESign, long.Parse(txtBasicSal.Text), long.Parse(txtPF.Text));
                MessageBox.Show("Updated Successfully   " + txtEId.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                EmpPhoto = openDlg.FileName;
                txtPhoto.Text = EmpPhoto;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                EmpSign = openDlg.FileName;
                txtSign.Text = EmpSign;
            }
        }
        public bool validateAtAdd()
        {
            int i;
            i = dateBirthDate.Value.Date.CompareTo(DateTime.Now.Date);
            if (i == 0 || i == 1)
            {
                MessageBox.Show("Please select the Valid Birth Date");
                dateBirthDate.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter the Name");
                txtName.Focus();
                return false;
            }
            if (txtPhoneNo.Text.Length > 10 || txtPhoneNo.Text.Length < 8)
            {
                MessageBox.Show("Invalid Phone number");
                txtPhoneNo.Text = "";
                txtPhoneNo.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Enter the Address");
                txtAddress.Focus();
                return false;
            }
            if (txtPhoneNo.Text == "")
            {
                MessageBox.Show("Please Enter the Phone Number");
                txtPhoneNo.Focus();
                return false;
            }
            if (cboJob.Text == "")
            {
                MessageBox.Show("Please Select the Job");
                cboJob.Focus();
                return false;
            }
            if (cboSex.Text == "")
            {
                MessageBox.Show("Please select the Sex");
                cboSex.Focus();
                return false;
            }
            if (txtBasicSal.Text == "")
            {
                MessageBox.Show("Please Enter the Basic Sal");
                txtBasicSal.Focus();
                return false;
            }
            if (txtPF.Text == "")
            {
                MessageBox.Show("Please Enter the PF");
                txtPF.Focus();
                return false;
            }
            if (txtSal.Text == "")
            {
                MessageBox.Show("Please Enter the Total Sal");
                txtSal.Focus();
                return false;
            }
            if (txtPhoto.Text == "")
            {
                MessageBox.Show("Please Enter the Photo Path");
                txtPhoto.Focus();
                return false;
            }
            if (txtSign.Text == "")
            {
                MessageBox.Show("Please Enter the Sign Path");
                txtSign.Focus();
                return false;
            }
            return true;
        }

        public bool validateOnDelete()
        {
            if (txtEId.Text == "")
            {
                txtEId.Focus();
                MessageBox.Show("Please Enter the Eid");
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();


            if (validateOnDelete())
            {
                ds = vc.GetEmplyeeDetails(long.Parse(txtEId.Text));
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0]["Ename"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Eadd"].ToString();
                        cboSex.SelectedItem  = ds.Tables[0].Rows[0]["ESex"].ToString();

                        dateBirthDate.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                        txtPhoneNo.Text = ds.Tables[0].Rows[0]["PhoneNO"].ToString();
                        cboJob.SelectedItem  = ds.Tables[0].Rows[0]["EJob"].ToString();

                        txtSal.Text = ds.Tables[0].Rows[0]["TotalSal"].ToString();
                        //txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                        //txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                        txtBasicSal.Text = ds.Tables[0].Rows[0]["BasicSal"].ToString();
                        txtPF.Text = ds.Tables[0].Rows[0]["PF"].ToString();


                        byte[] empphoto = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];

                        string sempphoto = Convert.ToString(DateTime.Now.ToFileTime());
                        FileStream fempPhoto = new FileStream(sempphoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fempPhoto.Write(empphoto, 0, empphoto.Length);
                        fempPhoto.Flush();
                        fempPhoto.Close();
                        imgPhoto.Image = Image.FromFile(sempphoto);
                        imgPhoto.Invalidate();

                        byte[] empSign = (byte[])ds.Tables[0].Rows[0]["SignPath"];
                        string sempSign = Convert.ToString(DateTime.Now.ToFileTime());
                        FileStream fempSign = new FileStream(sempSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fempSign.Write(empSign, 0, empSign.Length);
                        fempSign.Flush();
                        fempSign.Close();
                        picSign.Image = Image.FromFile(sempSign);
                        picSign.Invalidate();

                        txtName.Text = ds.Tables[0].Rows[0]["Ename"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Eadd"].ToString();
                        cboSex.SelectedText  = ds.Tables[0].Rows[0]["ESex"].ToString();
                        dateBirthDate.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                        txtPhoneNo.Text = ds.Tables[0].Rows[0]["PhoneNO"].ToString();
                        cboJob.SelectedText = (ds.Tables[0].Rows[0]["EJob"].ToString());
                        txtSal.Text = ds.Tables[0].Rows[0]["TotalSal"].ToString();
                        //txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                        //txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                        txtBasicSal.Text = ds.Tables[0].Rows[0]["BasicSal"].ToString();
                        txtPF.Text = ds.Tables[0].Rows[0]["PF"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No Such Employee ID is Found");
                    }
                }
                catch (IOException io)
                {
                    MessageBox.Show(io.ToString());
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtBasicSal.Text = "";

            txtEId.Text = "";
            txtName.Text = "";
            txtPF.Text = "";
            txtPhoneNo.Text = "";
            txtPhoto.Text = "";
            imgPhoto.Image = null;
            picSign.Image = null;
            txtSal.Text = "";
            txtSign.Text = "";
            cboJob.Text = "";
            cboSex.Text = "";
        }

        private void btnSignUpload_Click(object sender, EventArgs e)
        {
            if (txtSign.Text != "")
            {
                FileStream file = new FileStream(EmpSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();

                BESign = rawdata;
                MessageBox.Show("Image is uploaded");
                picSign.LoadAsync(txtSign.Text);
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }
        private void txtBasicSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtBasicSal.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txtEId_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtPF.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtSal.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtPhoneNo_Leave(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text.Length > 10 || txtPhoneNo.Text.Length < 8)
            {
                MessageBox.Show("Invalid Phone Number");
                txtPhoneNo.Text = "";
                //txtPhoneNo.Focus();
            }
        }

        

    }
}
