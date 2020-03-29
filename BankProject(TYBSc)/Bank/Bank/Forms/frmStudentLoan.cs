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
    public partial class frmStudentLoan : Form
    {
        InsertClass ic = new InsertClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();
        DeleteClass dc = new DeleteClass();

        int flagp = 0;
        int flags = 0;

        string GPhoto = "", GSign = "";

        byte[] BGphoto = new byte[100];
        byte[] BGSign = new byte[100];

        decimal NoOfInstalmet = 0.0M, emi = 0.0M;

        public frmStudentLoan()
        {
            InitializeComponent();
        }

        private void frmStudentLoan_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = vc.GetIntRate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtIntRate.Text = ds.Tables[0].Rows[0]["Student"].ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string appNo, transNo;
            if (validateOnAdd())
            {
                ic.addStudent(long.Parse(txtAccNo.Text), txtExamPassed.Text, DateTime.Parse(datePassedYear.Text), decimal.Parse(txtMarks.Text),
                    txtDivision.Text, txtScholarShip.Text, txtNameCourse.Text, decimal.Parse(txtDuration.Text), txtCollege.Text, txtCollegeAdd.Text, decimal.Parse(txtLoanAmt.Text),
                    decimal.Parse(txtIntRate.Text), decimal.Parse(txtEMI.Text), decimal.Parse(txtTotalFees.Text), DateTime.Parse(txtApppdate.Text), decimal.Parse(txtSalary.Text), long.Parse(txtInstalment.Text), out appNo);
                txtAppNo.Text = appNo;

                ic.addGurantor(long.Parse(txtAccNo.Text), txtGName.Text, DateTime.Parse(dateGBirth.Text), txtGResidentAdd.Text, txtGOffAdd.Text, long.Parse(txtGPhNo.Text), txtGOccupation.Text, BGphoto, BGSign, long.Parse(appNo));
                MessageBox.Show("Student is Add imto the Table");
                ic.addLoanTransaction(long.Parse(txtAccNo.Text), decimal.Parse(txtLoanAmt.Text), "Bank", decimal.Parse(txtEMI.Text), decimal.Parse(txtIntRate.Text), lblLoanType.Text, out transNo);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (validateOnDelete())
            {
                ds = vc.GetLoanTransaction(long.Parse(txtAccNo.Text), "Student Loan");
                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    dc.deletGuarantor(long.Parse(txtAccNo.Text));
                    dc.deleteStudent(long.Parse(txtAccNo.Text));
                    MessageBox.Show("Delete Application ");
                }
                else
                {
                    MessageBox.Show("Can not delete data because loan is pending");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateOnAdd() && validateOnDelete())
            {
                ec.updateStudent(long.Parse(txtAccNo.Text), txtExamPassed.Text, DateTime.Parse(datePassedYear.Text), decimal.Parse(txtMarks.Text),
                    txtDivision.Text, txtScholarShip.Text, txtNameCourse.Text, decimal.Parse(txtDuration.Text), txtCollege.Text, txtCollegeAdd.Text, decimal.Parse(txtLoanAmt.Text),
                    decimal.Parse(txtIntRate.Text), decimal.Parse(txtEMI.Text), decimal.Parse(txtTotalFees.Text), DateTime.Parse(txtApppdate.Text), decimal.Parse(txtSalary.Text), long.Parse(txtInstalment.Text), long.Parse(txtAppNo.Text));

                ec.updateGuarantor(long.Parse(txtAccNo.Text), txtGName.Text, DateTime.Parse(dateGBirth.Text), txtGResidentAdd.Text, txtGOffAdd.Text, long.Parse(txtGPhNo.Text), txtGOccupation.Text, BGphoto, BGSign, long.Parse(txtAppNo.Text));

                MessageBox.Show("Updated Student Information");
            }
        }

        private void txtValidate_Click(object sender, EventArgs e)
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
                    txtResAddress.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                    txtOffAddress.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                    txtPhNo.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                    txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                    txtEducation.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                    cboAccountType.Text = ds.Tables[0].Rows[0]["Acc_Type"].ToString();
                    dateBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                    cmbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
                    txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                    txtPANNo.Text = ds.Tables[0].Rows[0]["Pan_No"].ToString();
                    txtIncomeTax.Text = ds.Tables[0].Rows[0]["IncomeTax_No"].ToString(); ;
                    //txtHolderSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                    //txtHolderPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
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
                ds = vc.GetStudentsDetails(long.Parse(txtAccNo.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAppNo.Text = ds.Tables[0].Rows[0]["AppNo"].ToString();
                    txtExamPassed.Text = ds.Tables[0].Rows[0]["passedExam"].ToString();
                    datePassedExam.Text = ds.Tables[0].Rows[0]["passedyear"].ToString();
                    txtMarks.Text = ds.Tables[0].Rows[0]["passedmarks"].ToString();
                    txtDivision.Text = ds.Tables[0].Rows[0]["division"].ToString();
                    txtScholarShip.Text = ds.Tables[0].Rows[0]["OtherScholarship"].ToString();
                    txtNameCourse.Text = ds.Tables[0].Rows[0]["ProposedCourse"].ToString();
                    txtDuration.Text = ds.Tables[0].Rows[0]["duration"].ToString();
                    txtCollege.Text = ds.Tables[0].Rows[0]["collegeName"].ToString();
                    txtCollegeAdd.Text = ds.Tables[0].Rows[0]["collegeAddress"].ToString();
                    txtTotalFees.Text = ds.Tables[0].Rows[0]["TotalFees"].ToString();
                    txtLoanAmt.Text = ds.Tables[0].Rows[0]["loanAmt"].ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["intRate"].ToString();
                    txtEMI.Text = ds.Tables[0].Rows[0]["EMI"].ToString();
                    txtSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString();
                    txtInstalment.Text = ds.Tables[0].Rows[0]["No_Of_Installment"].ToString();
                  

                }
                else
                {
                    MessageBox.Show("No Application Number Found");
                }
                if (txtAppNo.Text != "")
                {
                    ds = vc.GetGuarantorDetails(long.Parse(txtAppNo.Text));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            try
                            {
                                txtGName.Text = ds.Tables[0].Rows[0]["GName"].ToString();
                                txtGResidentAdd.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                                txtGOffAdd.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                                dateGBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                                txtGPhNo.Text = ds.Tables[0].Rows[0]["Phone_NO"].ToString();
                                txtGOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
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

                    ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_NO"].ToString();
                        txtRefNo.Text = ds.Tables[0].Rows[0]["Reference_No"].ToString();
                        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        txtResAddress.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                        txtOffAddress.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                        txtPhNo.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                        txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                        txtEducation.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                        cboAccountType.Text = ds.Tables[0].Rows[0]["Acc_Type"].ToString();
                        dateBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                        cmbSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
                        txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                        txtPANNo.Text = ds.Tables[0].Rows[0]["Pan_No"].ToString();
                        txtIncomeTax.Text = ds.Tables[0].Rows[0]["IncomeTax_No"].ToString(); ;
                        //txtHolderSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                        //txtHolderPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                        cboJoint.SelectedItem = ds.Tables[0].Rows[0]["JointHolder"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Account Number Found");
                    }

                }
                else
                {
                    MessageBox.Show("Account No" +" " +txtAccNo .Text +" " +"does not have Student Loan");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Account Number");
            }
        }

        public bool validateOnAdd()
        {
            //DateTime d = new DateTime();
            int i;
            i = datePassedYear.Value.Date.CompareTo(DateTime.Now.Date);

            if (flagp == 0)
            {
                MessageBox.Show("Please upload the photo");
                btnPhoto.Focus();
                return false;
            }
            if (flags == 0)
            {
                MessageBox.Show("Please upload the sign");
                btnSign.Focus();
                return false;
            }

            DataSet ds = new DataSet();
            ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Account Number is not found");
                return false;
            }
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter Account Number");
                txtAccNo.Focus();
                return false;
            }
            if (txtPhNo.Text.Length > 10 || txtPhNo.Text.Length < 8)
            {
                MessageBox.Show("Please enter the valid phone number");
                txtPhNo.Text = "";
                txtPhNo.Focus();
                return false;
            }
            if (txtGPhNo.Text.Length < 8 || txtGPhNo.Text.Length > 10)
            {
                MessageBox.Show("Please enter the valid phone number");
                txtGPhNo.Text = "";
                txtGPhNo.Focus();
                return false;
            }
            if (i == 0)
            {
                MessageBox.Show("Please select the proper Passing Year");
                datePassedYear.Focus();
                return false;
            }
            if (txtMarks.Text == "")
            {
                MessageBox.Show("Please Enter the Marks");
                txtMarks.Focus();
                return false;
            }
            if (txtDivision.Text == "")
            {
                MessageBox.Show("Please Enter the Division");
                txtDivision.Focus();
                return false;
            }
            if (txtScholarShip.Text == "")
            {
                MessageBox.Show("Please Enter the Scholar Ship Details");
                txtScholarShip.Focus();
                return false;
            }
            if (txtNameCourse.Text == "")
            {
                MessageBox.Show("Please Enter the Name of Course");
                txtNameCourse.Focus();
                return false;
            }
            if (txtCollege.Text == "")
            {
                MessageBox.Show("Please Enter the College Name");
                txtCollege.Focus();
                return false;
            }
            if (txtDuration.Text == "")
            {
                MessageBox.Show("Please Enter the Duration");
                txtDuration.Focus();
                return false;
            }

            if (txtCollegeAdd.Text == "")
            {
                MessageBox.Show("Please Enter the College Address");
                txtCollegeAdd.Focus();
                return false;
            }
            if (txtTotalFees.Text == "")
            {
                MessageBox.Show("Please Enter the Total Fees");
                txtTotalFees.Focus();
                return false;
            }
            if (txtLoanAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Loan Amount");
                txtLoanAmt.Focus();
                return false;
            }
            if (txtSalary.Text == "")
            {
                MessageBox.Show("Please enter the salary after the education");
                txtSalary.Focus();
                return false;
            }
            if (txtInstalment.Text == "")
            {
                MessageBox.Show("Please enter the No of Instalment");
                txtInstalment.Focus();
                return false;
            }
            if (txtEMI.Text == "")
            {
                MessageBox.Show("Please Enter the EMI");
                txtEMI.Focus();
                return false;
            }
            if (txtIntRate.Text == "")
            {
                MessageBox.Show("Please Enter the Interest Rate");
                txtIntRate.Focus();
                return false;
            }
            if (txtGName.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Name");
                txtGName.Focus();
                return false;
            }
            if (txtGResidentAdd.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Residence Address");
                txtGResidentAdd.Focus();
                return false;
            }
            if (txtGOffAdd.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor office Address");
                txtGOffAdd.Focus();
                return false;
            }
            if (txtGOccupation.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Occupation");
                txtGOccupation.Focus();
                return false;
            }
            if (txtGPhNo.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Phone Number");
                txtGPhNo.Focus();
                return false;
            }
            if (txtGPhoto.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Photo");
                txtGPhoto.Focus();
                return false;
            }
            if (txtGSign.Text == "")
            {
                MessageBox.Show("Please Enter the Gurentor Sign");
                txtGSign.Focus();
                return false;
            }
            i = dateGBirth.Value.Date.CompareTo(DateTime.Now);
            if (i == 0)
            {
                MessageBox.Show("Please Enter the Valide Date of Birth Of Gurentor");
                dateGBirth.Focus();
                return false;
            }
            return true;
        }
        public bool validateOnDelete()
        {
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAccNo.Focus();
                return false;
            }
            return true;
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
                picPhoto.LoadAsync(txtGPhoto.Text);
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
            //txtClose.Text = "";
            txtCollege.Text = "";
            txtCollegeAdd.Text = "";
            txtDivision.Text = "";
            txtDuration.Text = "";
            txtEducation.Text = "";
            txtEMI.Text = "";
            txtExamPassed.Text = "";
            txtGName.Text = "";
            txtGOccupation.Text = "";
            txtGOffAdd.Text = "";
            txtGPhNo.Text = "";
            txtGPhoto.Text = "";
            txtGResidentAdd.Text = "";
            txtGSign.Text = "";
            // txtHolderPhoto.Text = "";
            //txtHolderSign.Text = "";
            txtIncomeTax.Text = "";
            txtIntRate.Text = "";
            txtLoanAmt.Text = "";
            txtMarks.Text = "";
            txtName.Text = "";
            txtNameCourse.Text = "";
            txtNationality.Text = "";
            txtOccupation.Text = "";
            txtOffAddress.Text = "";
            txtPANNo.Text = "";
            txtPhNo.Text = "";
            txtRefNo.Text = "";
            txtResAddress.Text = "";
            txtScholarShip.Text = "";
            txtTotalFees.Text = "";
            //txtValidate.Text = "";
            cboAccountType.Text = "";
            cboJoint.Text = "0";
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

        private void txtIncomeTax_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPANNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPhNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTotalFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtTotalFees.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
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

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            emi = decimal.Parse(txtSalary.Text) * (decimal)0.6;
            NoOfInstalmet = (long)(decimal.Parse(txtLoanAmt.Text) / (decimal)emi);
            txtEMI.Text = emi.ToString();
            txtInstalment.Text = NoOfInstalmet.ToString();
        }

       
       
       

       
    }
}
