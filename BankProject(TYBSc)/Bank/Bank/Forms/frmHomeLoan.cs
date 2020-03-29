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
    public partial class frmHomeLoan : Form
    {

        InsertClass ic = new InsertClass();
        EditClass ec = new EditClass();
        DeleteClass dc = new DeleteClass();
        ViewClass vc = new ViewClass();

        string GPhoto = "", GSign = "";

        byte[] BGphoto = new byte[100];
        byte[] BGSign = new byte[100];

        int flags;
        int flagp;

        decimal emi = 0.0M;
        long NoOfInstalment;

        public frmHomeLoan()
        {
            InitializeComponent();
        }

      
        
        private void frmHomeLoan_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = vc.GetIntRate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtIntRate.Text = ds.Tables[0].Rows[0]["Home"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string appno;
            string tarncNo;
            if (ValidateOnAdd())
            {

                ic.addHomeVehicalLoan(long.Parse(txtAccNo.Text), txtTargte.Text, decimal.Parse(txtSavingAmt.Text), decimal.Parse(txtProvidentAmt.Text),
                    decimal.Parse(txtImmovableAmt.Text), long.Parse(txtLicNo.Text), decimal.Parse(txtLicAmt.Text),
                    DateTime.Parse(dateMatuDate.Text), DateTime.Parse(dateAppDate.Text), decimal.Parse(txtLoanAmt.Text), decimal.Parse(txtIntRate.Text), decimal.Parse(txtEmi.Text), lblLoanType.Text, decimal.Parse(txtSalary.Text), long.Parse(txtNoOfInstalment.Text), out appno);
                txtAppNo.Text = appno;

                ic.addGurantor(long.Parse(txtAccNo.Text), txtGName.Text, DateTime.Parse(dateGBirth.Text), txtGres.Text, txtGOff.Text, long.Parse(txtGPhno.Text), txtGOccup.Text, BGphoto, BGSign, long.Parse(appno));

                ic.addLoanTransaction(long.Parse(txtAccNo.Text), decimal.Parse(txtLoanAmt.Text), "Bank", decimal.Parse(txtEmi.Text), decimal.Parse(txtIntRate.Text), lblLoanType.Text, out tarncNo);

                MessageBox.Show("Home Loan is Added");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateOnDelete() && ValidateOnAdd())
            {
                ec.updateHomeVehicale(long.Parse(txtAccNo.Text), txtTargte.Text, decimal.Parse(txtSavingAmt.Text), decimal.Parse(txtProvidentAmt.Text),
                    decimal.Parse(txtImmovableAmt.Text), long.Parse(txtLicNo.Text), decimal.Parse(txtLicAmt.Text),
                    DateTime.Parse(dateMatuDate.Text), DateTime.Parse(dateAppDate.Text), decimal.Parse(txtLoanAmt.Text), decimal.Parse(txtIntRate.Text), decimal.Parse(txtEmi.Text), lblLoanType.Text, decimal.Parse(txtSalary.Text), long.Parse(txtNoOfInstalment.Text), long.Parse(txtAppNo.Text));


                ec.updateGuarantor(long.Parse(txtAppNo.Text), txtGName.Text, DateTime.Parse(dateGBirth.Text), txtGres.Text, txtGOff.Text, long.Parse(txtGPhno.Text), txtGOccup.Text, BGphoto, BGSign, long.Parse(txtAppNo.Text));

                MessageBox.Show("Home Table is Updated!!!!!!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            if (validateOnDelete())
            {
                ds = vc.GetLoanTransaction(long.Parse(txtAccNo.Text), lblLoanType.Text);
                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    dc.deletGuarantor(long.Parse(txtAccNo.Text));
                    dc.deletHomeVehicale(long.Parse(txtAccNo.Text), lblLoanType.Text);
                    MessageBox.Show("Deleted All information");
                }
                else
                {
                    MessageBox.Show("Can not delete because of transaction is presented \n in the loan transaction table");
                }
            }
                
        }
        public bool ValidateOnAdd()
        {
            int i;
            i = dateGBirth.Value.Date.CompareTo(DateTime.Now.Date);
            if (flagp == 0)
            {
                MessageBox.Show("Please upload photo");
                return false;
            }
            if (flags == 0)
            {
                MessageBox.Show("Please upload sign");
                return false;
            }

            DataSet ds = new DataSet();
            ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));
            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Account is not found");
                return false;
            }

            if (i == 0)
            {
                MessageBox.Show("Please select the Valid Birth Date");
                dateGBirth.Focus();
                return false;
            }
            if (txtPhno.Text.Length > 10 || txtPhno.Text.Length < 8)
            {
                MessageBox.Show("Invalid Phone number");
                txtPhno.Text = "";
                txtPhno.Focus();
                return false;
            }
            if (txtGPhno.Text.Length < 8 || txtGPhno.Text.Length > 10)
            {
                MessageBox.Show("Invalid Phone number");
                txtGPhno.Text = "";
                txtGPhno.Focus();
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
                MessageBox.Show("Please Enter the Target Address");
                txtTargte.Focus();
                return false;
            }
            if (txtGName.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Name");
                txtGName.Focus();
                return false;
            }
            if (txtGres.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Resident Address");
                txtGres.Focus();
                return false;
            }
            if (txtGOff.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Office Address");
                txtGOff.Focus();
                return false;
            }
            if (txtGPhno.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Phone Number");
                txtGPhno.Focus();
                return false;
            }
            if (txtGOccup.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Occupation");
                txtGOccup.Focus();
                return false;
            }
            if (txtGSign.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Sign");
                txtGSign.Focus();
                return false;
            }
            if (txtGPhoto.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Photo");
                txtGPhno.Focus();
                return false;
            }

            if (txtLoanAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Loan Amount");
                txtLoanAmt.Focus();
                return false;
            }
            if (txtIntRate.Text == "")
            {
                MessageBox.Show("Please Enter the Intrest Rate ");
                txtIntRate.Focus();
                return false;
            }
            if (txtEmi.Text == "")
            {
                MessageBox.Show("Please Enter the EMI");
                txtEmi.Focus();
                return false;
            }
            if (txtSalary.Text == "")
            {
                MessageBox.Show("Please enter the salary");
                txtSalary.Focus();
                return false;
            }
            if (txtNoOfInstalment.Text == "")
            {
                MessageBox.Show("Please enter the Instalment");
                txtNoOfInstalment.Focus();
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
                MessageBox.Show("Please Enter the Provident Amount");
                txtProvidentAmt.Focus();
                return false;
            }
            if (txtImmovableAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Immovable Property Value");
                txtImmovableAmt.Focus();
                return false;
            }
            if (txtLicNo.Text == "")
            {
                MessageBox.Show("Please enter the lic number if no then enter 0");
                txtAccNo.Focus();
                return false;
            }
            if (txtLicAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Lic Amount");
                txtLicAmt.Focus();
                return false;
            }
            i = dateMatuDate.Value.Date.CompareTo(DateTime.Now.Date);
            if (i <= 0)
            {
                MessageBox.Show("Lic is matuare alredy can not consider");
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
                    //    txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                    //   txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
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
            if (txtAccNo.Text != "")
            {
                ds = vc.GetHomeVehicaleDetails(long.Parse(txtAccNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAppNo.Text = ds.Tables[0].Rows[0]["AppNo"].ToString();
                    txtLoanAmt.Text = ds.Tables[0].Rows[0]["LoanAmt"].ToString();
                    txtEmi.Text = ds.Tables[0].Rows[0]["EMI"].ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["IntRate"].ToString();
                    txtTargte.Text = ds.Tables[0].Rows[0]["TargetPropertyAddress"].ToString();
                    dateAppDate.Text = ds.Tables[0].Rows[0]["AppDate"].ToString();
                    txtSavingAmt.Text = ds.Tables[0].Rows[0]["SavingAmt"].ToString();
                    txtProvidentAmt.Text = ds.Tables[0].Rows[0]["ProvidentAmt"].ToString();
                    txtImmovableAmt.Text = ds.Tables[0].Rows[0]["immovableAmt"].ToString();
                    txtLicNo.Text = ds.Tables[0].Rows[0]["LIC_No"].ToString();
                    txtLicAmt.Text = ds.Tables[0].Rows[0]["LICAmt"].ToString();
                    dateMatuDate.Text = ds.Tables[0].Rows[0]["LICMaturityDate"].ToString();
                    txtSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
                    txtNoOfInstalment.Text = ds.Tables[0].Rows[0]["No_Of_Installment"].ToString();
                }

                ds = vc.GetAccontMasterDetails(long.Parse(txtAppNo.Text));

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
                    //   txtSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                    //  txtPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
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
                            txtGName.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                            txtGres.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                            txtGOff.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                            dateGBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                            txtGPhno.Text = ds.Tables[0].Rows[0]["Phone_NO"].ToString();
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
                            picPhoto.Image = Image.FromFile(SG1photo);
                            picPhoto.Invalidate();


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

                ds = vc.GetHomeVehicaleDetails(long.Parse(txtAppNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtLoanAmt.Text = ds.Tables[0].Rows[0]["LoanAmt"].ToString();
                    txtEmi.Text = ds.Tables[0].Rows[0]["EMI"].ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["IntRate"].ToString();
                    txtTargte.Text = ds.Tables[0].Rows[0]["TargetPropertyAddress"].ToString();
                    dateAppDate.Text = ds.Tables[0].Rows[0]["AppDate"].ToString();
                    txtSavingAmt.Text = ds.Tables[0].Rows[0]["SavingAmt"].ToString();
                    txtProvidentAmt.Text = ds.Tables[0].Rows[0]["ProvidentAmt"].ToString();
                    txtImmovableAmt.Text = ds.Tables[0].Rows[0]["immovableAmt"].ToString();
                    txtLicNo.Text = ds.Tables[0].Rows[0]["LIC_No"].ToString();
                    txtLicAmt.Text = ds.Tables[0].Rows[0]["LICAmt"].ToString();
                    dateMatuDate.Text = ds.Tables[0].Rows[0]["LICMaturityDate"].ToString();
                }

            }
            else
            {
                MessageBox.Show("Please Enter the Account Number");
            }
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                GSign = openDlg.FileName;
                txtGSign.Text = GSign;
            }
        }

        private void btnPhotoBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                GPhoto = openDlg.FileName;
                txtGPhoto.Text = GPhoto;
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
                picPhoto.LoadAsync(txtGPhoto.Text);
                flagp = 1;
            }
            else
            {
                MessageBox.Show("click brows");
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
        private void txtEmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtEmi.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
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
                MessageBox.Show("Please enter valid integer.");
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
                MessageBox.Show("Please enter valid integer.");
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
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void txtLicNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtLicAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtLicAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }



        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            txtAppNo.Text = "";
            txtEducatiom.Text = "";
            txtEmi.Text = "";
            //txtGId.Text = "";
            txtGName.Text = "";
            txtGOccup.Text = "";
            txtGOff.Text = "";
            txtGPhno.Text = "";
            txtGPhoto.Text = "";
            txtGres.Text = "";
            txtGSign.Text = "";
            txtImmovableAmt.Text = "";
            txtIntRate.Text = "";
            txtLicAmt.Text = "";
            txtLicNo.Text = "";
            txtLoanAmt.Text = "";
            txtName.Text = "";
            txtNationality.Text = "";
            txtOccup.Text = "";
            txtOff.Text = "";
            txtPanNo.Text = "";
            txtPhno.Text = "";
            // txtPhoto.Text = "";
            txtProvidentAmt.Text = "";
            txtRefNo.Text = "";
            txtResident.Text = "";
            txtSavingAmt.Text = "";
            //txtSign.Text = "";
            txtTargte.Text = "";
            txtTaxNo.Text = "";
            cmbAccType.Text = "";
            cmbSex.Text = "";
            picPhoto.Image = null;
            picSign.Image = null;


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

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtAppNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTaxNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPanNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPhno_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGPhno_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtGId_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPhno_Leave(object sender, EventArgs e)
        {
            if (txtPhno.Text.Length < 8 || txtPhno.Text.Length > 10)
            {
                MessageBox.Show("Invalid Phone number");
                txtPhno.Text = "";
            }
        }
        private void txtGPhno_Leave(object sender, EventArgs e)
        {
            if (txtGPhno.Text.Length < 8 || txtGPhno.Text.Length > 10)
            {
                MessageBox.Show("Invalid Phone number");
                txtGPhno.Text = "";
            }
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            emi = decimal.Parse(txtSalary.Text) * (decimal)0.6;
            NoOfInstalment = (long)(decimal.Parse(txtLoanAmt.Text) / (decimal)emi);
            txtEmi.Text = emi.ToString();
            txtNoOfInstalment.Text = NoOfInstalment.ToString();
        }


       
    }
}
