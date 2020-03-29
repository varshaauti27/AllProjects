using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bank.Forms
{
    public partial class frmVehicalLoan : Form
    {

        InsertClass ic = new InsertClass();
        DeleteClass dc = new DeleteClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();

        int flagp = 0;
        int flags = 0;

        string GPhoto = "", GSign = "";

        byte[] BGphoto = new byte[100];
        byte[] BGSign = new byte[100];

        decimal NoOfInstalment = 0.0M, emi = 0.0M;
        public frmVehicalLoan()
        {
            InitializeComponent();
        }

        private void frmVehicalLoan_Load(object sender, EventArgs e)
        {
            new InsertClass();
            DataSet ds = new DataSet();


            ds = vc.GetIntRate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtIntRate.Text = ds.Tables[0].Rows[0]["Vehical"].ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string appNo;
            string tcNo;
            if (validateOnAdd())
            {

                ic.addHomeVehicalLoan(long.Parse(txtAccNo.Text), "number", decimal.Parse(txtSavingAmt.Text), decimal.Parse(txtProvidentAmt.Text),
                    decimal.Parse(txtImmovableAmt.Text), long.Parse(txtLICNo.Text), decimal.Parse(txtLICAmt.Text), DateTime.Parse(dateMaturity.Text), DateTime.Parse(dateAppDate.Text),
                    long.Parse(txtLoanAmt.Text), decimal.Parse(txtIntRate.Text), decimal.Parse(txtEMI.Text), lblLoantype.Text, decimal.Parse(txtSalary.Text), long.Parse(txtInstalment.Text), out appNo);
                txtAppNo.Text = appNo;


                ic.addGurantor(long.Parse(txtAccNo.Text), txtGName.Text, DateTime.Parse(DateGBirth.Text), txtGRes.Text, txtGOff.Text,
                    long.Parse(txtGPhNo.Text), txtGOccup.Text, BGphoto, BGSign, long.Parse(txtAppNo.Text));

                ic.addLoanTransaction(long.Parse(txtAccNo.Text), decimal.Parse(txtLoanAmt.Text), "Bank", decimal.Parse(txtEMI.Text), decimal.Parse(txtIntRate.Text), lblLoantype.Text, out tcNo);


                MessageBox.Show("Vehical IS Updated!!!!!!!");
            }
               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (validateOnDelete())
            {
                ds = vc.GetLoanTransaction(long.Parse(txtAccNo.Text), lblLoantype.Text);
                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    dc.deletGuarantor(long.Parse(txtAccNo.Text));
                    dc.deletHomeVehicale(long.Parse(txtAccNo.Text), lblLoantype.Text);
                    MessageBox.Show("Sucessfuly Deleted Vehical");
                }
                else
                {
                    MessageBox.Show("Can not delete data because loan is pending");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (validateOnAdd() && validateOnDelete())
            {
                ec.updateHomeVehicale(long.Parse(txtAccNo.Text), "number", decimal.Parse(txtSavingAmt.Text), decimal.Parse(txtProvidentAmt.Text),
                    decimal.Parse(txtImmovableAmt.Text), long.Parse(txtLICNo.Text), long.Parse(txtLICAmt.Text), DateTime.Parse(dateMaturity.Text), DateTime.Parse(dateAppDate.Text),
                    long.Parse(txtLoanAmt.Text), decimal.Parse(txtIntRate.Text), decimal.Parse(txtEMI.Text), lblLoantype.Text, decimal.Parse(txtSalary.Text), long.Parse(txtInstalment.Text), long.Parse(txtAppNo.Text));

                ec.updateGuarantor(long.Parse(txtAccNo.Text), txtGName.Text, DateTime.Parse(DateGBirth.Text), txtGRes.Text, txtGOff.Text,
                    long.Parse(txtGPhNo.Text), txtGOccup.Text, BGphoto, BGSign, long.Parse(txtAppNo.Text));

                MessageBox.Show("Updated Vehical !!!!!!!!");
            }
        }
        public bool validateOnAdd()
        {
            int i;
            DataSet ds = new DataSet();
            ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));
            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Account number is not found");
                return false;
            }
            if (flags == 0)
            {
                MessageBox.Show("Please upload sign");
                btnSign.Focus();
                return false;
            }
            if (flagp == 0)
            {
                MessageBox.Show("Please upload photo");
                btnPhoto.Focus();
                return false;
            }
            if (txtPhno.Text.Length < 8 || txtPhno.Text.Length > 10)
            {
                MessageBox.Show("Please enter the valid phone number");
                txtPhno.Text = "";
                txtPhno.Focus();
                return false;
            }
            if (txtGPhNo.Text.Length < 8 || txtGPhNo.Text.Length > 10)
            {
                MessageBox.Show("Please enter the valid phone number");
                txtGPhNo.Text = "";
                txtGPhNo.Focus();
                return false;
            }
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAccNo.Focus();
                return false;
            }
            if (txtTargte.Text == "")
            {
                MessageBox.Show("Please Enter the Traget");
                txtTargte.Focus();
                return false;
            }

            if (txtGName.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Name");
                txtGName.Focus();
                return false;
            }
            i = DateGBirth.Value.Date.CompareTo(DateTime.Now.Date);
            if (i == 0)
            {
                MessageBox.Show("Please Enter the Gurentor Birth Date");
                DateGBirth.Focus();
                return false;
            }
            if (txtGRes.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Resident Address");
                txtGRes.Focus();
                return false;
            }
            if (txtGOff.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Office Address");
                txtGOff.Focus();
                return false;
            }
            if (txtGPhNo.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Phone Number");
                txtGPhNo.Focus();
                return false;
            }
            if (txtGOccup.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Occupation");
                txtGOccup.Focus();
                return false;
            }
            if (txtGPhoto.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Photo");
                txtGPhoto.Focus();
                return false;
            }
            if (txtGSign.Text == "")
            {
                MessageBox.Show("Please Enter the Gurantor Sign");
                txtGSign.Focus();
                return false;
            }
            if (txtLICAmt.Text == "")
            {
                MessageBox.Show("Please Enter the LIC Amount");
                txtLICAmt.Focus();
                return false;
            }

            if (txtEMI.Text == "")
            {
                MessageBox.Show("Please Enter the EMI");
                txtEMI.Focus();
                return false;
            }
            if (txtSalary.Text == "")
            {
                MessageBox.Show("Please enter the Salary");
                txtSalary.Focus();
                return false;
            }
            if (txtInstalment.Text == "")
            {
                MessageBox.Show("Please enter the no of Instalment");
                txtInstalment.Focus();
                return false;
            }
            if (txtIntRate.Text == "")
            {
                MessageBox.Show("Please Enter the Intrest Rate ");
                txtIntRate.Focus();
                return false;
            }
            if (txtSavingAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Saving Amount");
                txtSavingAmt.Focus();
                return false;
            }
            if (txtProvidentAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Provident Fund Amt if No the Type 0");
                txtProvidentAmt.Focus();
                return false;
            }
            if (txtLICNo.Text == "")
            {
                MessageBox.Show("Please enter the lic no if no then enter the 0");
                txtLICNo.Focus();
                return false;
            }
            if (txtLICAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Lic Amout if No Then Type 0");
                txtLICAmt.Focus();
                return false;
            }

            if (txtImmovableAmt.Text == "")
            {
                MessageBox.Show("Please Enter the  Amout if No Then Type 0");
                txtImmovableAmt.Focus();
                return false;
            }
            if (txtLoanAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Loan Amt");
                txtLoanAmt.Focus();
                return false;
            }
            if (txtGSign.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Sign");
                txtGSign.Focus();
                return false;
            }
            return true;
        }

        public bool validateOnDelete()
        {
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAppNo.Focus();
                return false;
            }
            return true;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (txtAccNo.Text != "")
            {
                ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_NO"].ToString();
                    txtRefNo.Text = ds.Tables[0].Rows[0]["Reference_No"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtResident.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                    txtOff.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                    txtPhno.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                    txtOccup.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                    txtEducatiom.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                    cmbAccType.Text = ds.Tables[0].Rows[0]["Acc_Type"].ToString();
                    dateBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                    cmbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
                    txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    txtPanNo.Text = ds.Tables[0].Rows[0]["Pan_No"].ToString();
                    txtTaxNo.Text = ds.Tables[0].Rows[0]["IncomeTax_No"].ToString(); ;
                    //txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                    //txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                }
                else
                {
                    MessageBox.Show("No Account Number Found");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Account Number");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            if (txtAccNo.Text != "")
            {
                ds = vc.GetHomeVehicaleDetails(long.Parse(txtAccNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                 //   txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_NO"].ToString();
                    txtAppNo.Text = ds.Tables[0].Rows[0]["AppNo"].ToString();
                    txtLoanAmt.Text = ds.Tables[0].Rows[0]["LoanAmt"].ToString();
                    txtEMI.Text = ds.Tables[0].Rows[0]["EMI"].ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["IntRate"].ToString();
                    txtTargte.Text = ds.Tables[0].Rows[0]["TargetPropertyAddress"].ToString();
                    dateAppDate.Text = ds.Tables[0].Rows[0]["AppDate"].ToString();
                    txtSavingAmt.Text = ds.Tables[0].Rows[0]["SavingAmt"].ToString();
                    txtProvidentAmt.Text = ds.Tables[0].Rows[0]["ProvidentAmt"].ToString();
                    txtImmovableAmt.Text = ds.Tables[0].Rows[0]["immovableAmt"].ToString();
                    txtLICNo.Text = ds.Tables[0].Rows[0]["LIC_No"].ToString();
                    txtLICAmt.Text = ds.Tables[0].Rows[0]["LICAmt"].ToString();
                    dateMaturity.Text = ds.Tables[0].Rows[0]["LICMaturityDate"].ToString();
                    txtSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
                    txtInstalment.Text = ds.Tables[0].Rows[0]["No_Of_Installment"].ToString();
                }

                ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        try
                        {


                            txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_NO"].ToString();
                            txtRefNo.Text = ds.Tables[0].Rows[0]["Reference_No"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                            txtResident.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                            txtOff.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                            txtPhno.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                            txtOccup.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                            txtEducatiom.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                            cmbAccType.Text = ds.Tables[0].Rows[0]["Acc_Type"].ToString();
                            dateBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                            cmbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
                            txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                            txtPanNo.Text = ds.Tables[0].Rows[0]["Pan_No"].ToString();
                            txtTaxNo.Text = ds.Tables[0].Rows[0]["IncomeTax_No"].ToString(); ;
                            //txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                            //txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();


                        }
                        catch (IOException io)
                        {
                            MessageBox.Show(io.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No Account Number Found");
                }

                ds = vc.GetGuarantorDetails(long.Parse(txtAppNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        try
                        {
                            txtGID.Text = ds.Tables[0].Rows[0]["GID"].ToString();
                            txtGName.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                            txtGRes.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                            txtGOff.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                            DateGBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                            txtGPhNo.Text = ds.Tables[0].Rows[0]["Phone_NO"].ToString();
                            txtGOccup.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                            //txtGSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                            //txtGPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();



                            byte[] GSign = (byte[])ds.Tables[0].Rows[0]["SignPath"];
                            string sGSign = Convert.ToString(DateTime.Now.ToFileTime());
                            FileStream fGSign = new FileStream(sGSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            fGSign.Write(GSign, 0, GSign.Length);
                            fGSign.Flush();
                            fGSign.Close();
                            picSign.Image = Image.FromFile(sGSign);
                            picSign.Invalidate();


                            byte[] Gphoto = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                            string SG1photo = Convert.ToString(DateTime.Now.ToFileTime());
                            //string SG1photo = "d://abc.text";
                            FileStream fGPhoto = new FileStream(SG1photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            fGPhoto.Write(Gphoto, 0, Gphoto.Length);
                            fGPhoto.Flush();
                            fGPhoto.Close();
                            imgPhoto.Image = Image.FromFile(SG1photo);
                            imgPhoto.Invalidate();
                        }
                        catch (IOException io)
                        {
                            MessageBox.Show(io.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Account Number");
            }
        }

        private void btnBrowsSign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                GSign = openDlg.FileName;
                txtGSign.Text = GSign;
            }
        }

        private void btnBrowsPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                GPhoto = openDlg.FileName;
                txtGPhoto.Text = GPhoto;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (txtGSign.Text != "")
            {
                FileStream file = new FileStream(GSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();

                BGSign = rawdata;
                MessageBox.Show("Image is uploaded");
                picSign.LoadAsync(txtGSign.Text);
                flags = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {

            if (txtGPhoto.Text != "")
            {
                FileStream file = new FileStream(GPhoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();

                BGphoto = rawdata;
                MessageBox.Show("Image is uploaded");
                imgPhoto.LoadAsync(txtGPhoto.Text);
                flagp = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            txtAppNo.Text = "";
            txtEducatiom.Text = "";
            txtEMI.Text = "";
            txtGID.Text = "";
            txtGName.Text = "";
            txtGOccup.Text = "";
            txtGOff.Text = "";
            txtGPhNo.Text = "";
            txtGPhoto.Text = "";
            txtGRes.Text = "";
            txtGSign.Text = "";
            txtImmovableAmt.Text = "";
            //txtIntRate.Text = "";
            txtLICAmt.Text = "";
            txtLICNo.Text = "";
            txtLoanAmt.Text = "";
            txtName.Text = "";
            txtNationality.Text = "";
            txtOccup.Text = "";
            txtOff.Text = "";
            txtPanNo.Text = "";
            txtPhno.Text = "";
            txtProvidentAmt.Text = "";
            txtRefNo.Text = "";
            txtResident.Text = "";
            txtSavingAmt.Text = "";
            txtTargte.Text = "";
            txtTaxNo.Text = "";
            cmbAccType.Text = "";
            cmbSex.Text = "";
           
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
        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtAppNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTaxNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPanNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPhno_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGID_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGPhNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLoanAmt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtLoanAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtEMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtEMI.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtSavingAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtSavingAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtProvidentAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtProvidentAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtImmovableAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtImmovableAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtLICAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtLICAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }
        private void txtLICNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            emi = decimal.Parse(txtSalary.Text) * (decimal)0.6;
            NoOfInstalment = (long)(decimal.Parse(txtLoanAmt.Text) / (decimal)emi);
            txtEMI.Text = emi.ToString();
            txtInstalment.Text = NoOfInstalment.ToString();
        }

       

      

        
    }
}
