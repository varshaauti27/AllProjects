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
    public partial class frmOpenAccount : Form
    {
        InsertClass ic = new InsertClass();
        EditClass ec = new EditClass();
        DeleteClass dc = new DeleteClass();
        ViewClass vc = new ViewClass();
        int flagHS = 0, flagHP = 0, flagPS = 0, flagJ1S = 0, flagJ1p = 0, flagJ2s = 0, flagj2p = 0;
        //int bufsiz = 100; 


        byte[] Bholderphoto = new byte[100];
        byte[] BJ1Photo = new byte[100];
        byte[] BJ2Photo = new byte[100];
        byte[] BholderSign = new byte[100];
        byte[] BJ1Sign = new byte[100];
        byte[] BJ2Sign = new byte[100];
        byte[] BparentSign = new byte[100];

        string holderPhoto, J1Photo, J2Photo, holderSign, J1Sign, J2Sign, parentSign;
        //  Image curImage;
        public frmOpenAccount()
        {
            InitializeComponent();
        }

        private void frmOpenAccount_Load(object sender, EventArgs e)
        {
            new InsertClass();
        }

        private void cboJNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboJNo.SelectedItem).ToString() == "1")
            {
                groupJointHolder1.Visible = true;
                picJ1.Visible = true;
                picJ1Sign.Visible = true;
                txtPicJ1.Visible = true;
                txtpicJ1Sign.Visible = true;
                btnUploadJ1Sign.Visible = true;
                btnUploadJ1Pic.Visible = true;
                btnPicJ1.Visible = true;
                btnJ1Sign.Visible = true;
            }
            else if ((cboJNo.SelectedItem).ToString() == "2")
            {
                groupJointHolder2.Visible = true;
                groupJointHolder1.Visible = true;
                picJ1.Visible = true;
                picJ2.Visible = true;
                picJ1Sign.Visible = true;
                picJ2Sign.Visible = true;
                txtPicJ1.Visible = true;
                txtPicJ2.Visible = true;
                txtpicJ1Sign.Visible = true;
                txtPicJ2Sign.Visible = true;
                btnUploadJ1Sign.Visible = true;
                btnUploadJ2Pic.Visible = true;
                btnPicJ1.Visible = true;
                btnPicJ2.Visible = true;
                btnJ2Sign.Visible = true;
                btnUploadJ2Sign.Visible = true;
                btnUploadJ1Pic.Visible = true;
                btnJ1Sign.Visible = true;

            }
            else
            {
                groupJointHolder2.Visible = false;
                groupJointHolder1.Visible = false;
                picJ1.Visible = false;
                picJ2.Visible = false;
                picJ1Sign.Visible = false;
                btnJ1Sign.Visible = false;
                btnJ2Sign.Visible = false;
                btnUploadJ1Pic.Visible = false;
                picJ2Sign.Visible = false;
                txtPicJ1.Visible = false;
                txtPicJ2.Visible = false;
                txtpicJ1Sign.Visible = false;
                txtPicJ2Sign.Visible = false;
                btnUploadJ1Sign.Visible = false;
                btnUploadJ2Pic.Visible = false;
                btnPicJ1.Visible = false;
                btnPicJ2.Visible = false;
                btnUploadJ2Sign.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string AccNo;
            string tn;
            if (ValidateOnAdd())
            {
                ic.addAccount(long.Parse(txtRefNo.Text), txtName.Text, Convert.ToDateTime(dateOpening.Text), Convert.ToDateTime(dateBirth.Text),
                    (cboAccType.SelectedItem).ToString(), txtResident.Text, txtOff.Text, long.Parse(txtIncometaxNo.Text), long.Parse(txtPANNo.Text),
                    int.Parse((cboJNo.SelectedItem).ToString()), (cboMinor.SelectedItem).ToString(), long.Parse(txtPhNo.Text), txtNationality.Text, txtOccupation.Text, txtQulification.Text,
                    (cboSex.SelectedItem).ToString(), Bholderphoto, BholderSign, out AccNo);
                txtAccNo.Text = AccNo;

                ic.addDepositeTransaction(long.Parse(txtAccNo.Text), decimal.Parse(txtInitialAmount.Text), "self", decimal.Parse(txtInitialAmount.Text), out tn);

                if ((cboMinor.SelectedItem).ToString() == "Yes")
                {

                    ic.addMinor(Convert.ToDateTime(dateMinorBirth.Text), txtParentName.Text, txtParentResidenceAdd.Text, txtParentOfficeAdd.Text, txtParentOccupation.Text,
                        txtRelation.Text, BparentSign);
                }
                if ((cboJNo.SelectedItem).ToString() == "1")
                {
                    ic.addJointHolder(txtJ1Name.Text, Convert.ToDateTime(dateJ1Birth.Text), long.Parse(txtJ1PhNo.Text),
                        txtJ1Nationality.Text, txtJ1ResAdd.Text, txtJ1OffAddress.Text,
                        BJ1Photo, BJ1Sign, groupJointHolder1.Text);
                }
                if ((cboJNo.SelectedItem).ToString() == "2")
                {
                    ic.addJointHolder(txtJ1Name.Text, Convert.ToDateTime(dateJ1Birth.Text), long.Parse(txtJ1PhNo.Text),
                     txtJ1Nationality.Text, txtJ1ResAdd.Text, txtJ1OffAddress.Text,
                     BJ1Photo, BJ1Sign, groupJointHolder1.Text);


                    ic.addJointHolder(txtJ2Name.Text, Convert.ToDateTime(dateJ2Birth.Text), long.Parse(txtJ2PhNo.Text),
                        txtJ2Nationality.Text, txtJ2ResAdd.Text, txtJ2OffAdd.Text, BJ2Photo, BJ2Sign, groupJointHolder2.Text);
                }
                MessageBox.Show("Create Acc as no " + "  " + AccNo);
            }
        }

        private void cboMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboMinor.SelectedItem).ToString() == "Yes")
            {
                groupMinor.Visible = true;
                picParentSign.Visible = true;
                txtPicParentSign.Visible = true;
                btnParentSign.Visible = true;
                btnUploadParentSign.Visible = true;
            }
            else
            {
                groupMinor.Visible = false;
                picParentSign.Visible = false;
                txtPicParentSign.Visible = false;
                btnParentSign.Visible = false;
                btnUploadParentSign.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            if (ValidateOnDelete())
            {
                if (validateOnChild())
                {
                    dc.deletMinor(long.Parse(txtAccNo.Text));
                    dc.deleteJointHolder(long.Parse(txtAccNo.Text));
                    dc.deletTransaction(long.Parse(txtAccNo.Text));
                    dc.deletAccount(long.Parse(txtAccNo.Text));
                    MessageBox.Show("Account Has Been Deleted");
                }
            }
        }

        public bool validateOnChild()
        {
            DataSet ds = new DataSet();
            ds = vc.GetChequeBook(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n chequebook tabel cantain information about this \n so please first delete that information");
                return false;
            }

            ds = vc.GetFixedDeposite1(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n Fixede deposite tabel cantain information about this \n so please first delete that information");
                return false;
            }

            ds = vc.getlocker1(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n locker tabel cantain information about this \n so please first delete that information");
                return false;
            }

            ds = vc.GetHomeVehicaleDetails(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n Home loan or vehicale loan tabel cantain information about this \n so please first delete that information");
                return false;
            }

            ds = vc.GetStudentsDetails(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n student loan tabel cantain information about this \n so please first delete that information");
                return false;
            }

            ds = vc.GetTransaction(long.Parse(txtAccNo.Text));
            if ((ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("Can not directly delete because \n transaction tabel cantain information about this \n so please first delete that information");
                return false;
            }
            return true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool ValidateOnAdd()
        {
            int i;
            i = dateBirth.Value.Date.CompareTo(DateTime.Now.Date);
            if (i == 0 || i == 1)
            {
                MessageBox.Show("Please select Valid Birth Date");
                dateBirth.Focus();
                return false;
            }
            if (txtPhNo.Text.Length < 8 || txtPhNo.Text.Length > 10)
            {
                MessageBox.Show("Invalid phone number");
                txtPhNo.Text = "";
                txtPhNo.Focus();
                return false;
            }

            DateTime dt = new DateTime(int.Parse((DateTime.Now.Date.Year).ToString()), int.Parse((DateTime.Now.Date.Month).ToString()), int.Parse((DateTime.Now.Date.Day).ToString()));
            i = DateTime.Now.Year - dateBirth.Value.Year;
            if (i < 18)
            {
                if (cboMinor.SelectedItem.ToString() == "No")
                {
                    MessageBox.Show("Client is minor please select the minor case Yes");
                    cboMinor.Focus();
                    return false;
                }
            }


            if (flagHP == 0)
            {
                MessageBox.Show("Please upload the Holder photo");
                return false;
            }
            if (flagHS == 0)
            {
                MessageBox.Show("Please upload the Holder sign");
                return false;
            }
            if (txtInitialAmount.Text == "")
            {
                MessageBox.Show("Please enter initial amount");
                txtInitialAmount.Focus();
                return false;

            }
            if (txtRefNo.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Referecne Number");
                txtRefNo.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Name");
                txtName.Focus();
                return false;
            }
            if (cboSex.Text == "")
            {
                MessageBox.Show("Please Enter the Holder");
                cboSex.Focus();
                return false;
            }
            if (txtResident.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Residence Address");
                txtResident.Focus();
                return false;
            }
            if (txtOff.Text == "")
            {
                MessageBox.Show("Please Enter Customer Office Address");
                txtOff.Focus();
                return false;
            }
            if (txtPhNo.Text == "")
            {
                MessageBox.Show("Please Enter the Customer Phone Number");
                txtPhNo.Focus();
                return false;
            }
            if (txtQulification.Text == "")
            {
                MessageBox.Show("Please Enter the Customer Qulification");
                txtQulification.Focus();
                return false;
            }
            if (txtOccupation.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Occupation");
                txtOccupation.Focus();
                return false;
            }
            if (txtPANNo.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Pan no if no then enter the 0");
                txtPANNo.Focus();
                return false;
            }
            if (txtIncometaxNo.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Income Tax Number if no then enter 0");
                txtIncometaxNo.Focus();
                return false;
            }
            if (cboJNo.Text == "")
            {
                MessageBox.Show("Please select the Joint Holder Number");
                cboJNo.Focus();
                return false;
            }
            if (cboMinor.Text == "")
            {
                MessageBox.Show("Please selct The Minor Case");
                cboMinor.Focus();
                return false;
            }
            if (txtPicHolder.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Photo");
                txtPicHolder.Focus();
                return false;
            }
            if (txtPicHoldSign.Text == "")
            {
                MessageBox.Show("Please Enter the Holder Sign");
                txtPicHoldSign.Focus();
                return false;
            }
            if ((cboMinor.SelectedItem).ToString() == "Yes")
            {
                i = dateMinorBirth.Value.Date.CompareTo(DateTime.Now.Date);
                if (i == 0 || i == 1)
                {
                    MessageBox.Show("Please select the Valid Birth Date");
                    dateMinorBirth.Focus();
                    return false;
                }

                dt = new DateTime(int.Parse((DateTime.Now.Date.Year).ToString()), int.Parse((DateTime.Now.Date.Month).ToString()), int.Parse((DateTime.Now.Date.Day).ToString()));
                i = DateTime.Now.Year - dateMinorBirth.Value.Year;
                if (i < 18)
                {

                    MessageBox.Show("parent is minor so minor not become parent");
                    dateMinorBirth.Focus();
                    return false;

                }

                if (flagPS == 0)
                {
                    MessageBox.Show("Please upload the parent sign");
                    return false;
                }

                if (txtParentName.Text == "")
                {
                    MessageBox.Show("Please Enter the Parent Name");
                    txtParentName.Focus();
                    return false;
                }
                if (txtParentOfficeAdd.Text == "")
                {
                    MessageBox.Show("Please Enter the Parent Office Address");
                    txtParentOfficeAdd.Focus();
                    return false;
                }
                if (txtParentResidenceAdd.Text == "")
                {
                    MessageBox.Show("Please Enter the Parent Resident Address");
                    txtParentResidenceAdd.Focus();
                    return false;
                }
                if (txtParentOccupation.Text == "")
                {
                    MessageBox.Show("Please Enter the Parent Occupation");
                    txtParentOccupation.Focus();
                    return false;
                }
                if (txtRelation.Text == "")
                {
                    MessageBox.Show("Please Enter the Relation with Parent ");
                    txtRelation.Focus();
                    return false;
                }
                if (txtPicParentSign.Text == "")
                {
                    MessageBox.Show("Please Enter the Parent Sign ");
                    txtPicParentSign.Focus();
                    return false;
                }
            }
            if ((cboJNo.SelectedItem).ToString() != "0")
            {
                if ((cboJNo.SelectedItem).ToString() == "1")
                {
                    i = dateJ1Birth.Value.Date.CompareTo(DateTime.Now.Date);
                    if (i == 0 || i == 1)
                    {
                        MessageBox.Show("Please select Valid Birth date");
                        dateJ1Birth.Focus();
                        return false;
                    }

                    if (flagJ1p == 0)
                    {
                        MessageBox.Show("Please upload the joint holder1 photo");
                        return false;
                    }
                    if (flagJ1S == 0)
                    {
                        MessageBox.Show("Please upload the joint holder1 Sign");
                        return false;
                    }


                    if (txtJ1Name.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Name ");
                        txtJ1Name.Focus();
                        return false;
                    }
                    if (txtJ1OffAddress.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Office Address");
                        txtJ1OffAddress.Focus();
                        return false;
                    }
                    if (txtJ1ResAdd.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Residence Address");
                        txtJ1ResAdd.Focus();
                        return false;
                    }
                    if (txtJ1PhNo.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Phone Number");
                        txtJ1PhNo.Focus();
                        return false;
                    }

                    if (txtJ1PhNo.Text.Length > 10 || txtJ1PhNo.Text.Length < 8)
                    {
                        MessageBox.Show("Invalid Phone number");
                        txtJ1PhNo.Text = "";
                        txtJ1PhNo.Focus();
                        return false;
                    }

                    if (txtJ1Nationality.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Nationality");
                        txtJ1Nationality.Focus();
                        return false;
                    }
                    if (txtPicJ1.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Photo");
                        txtPicJ1.Focus();
                        return false;
                    }
                    if (txtpicJ1Sign.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Sign");
                        txtpicJ1Sign.Focus();
                        return false;
                    }
                }

                if ((cboJNo.SelectedItem).ToString() == "2")
                {
                    i = dateJ1Birth.Value.Date.CompareTo(DateTime.Now.Date);
                    if (i == 0 || i == 1)
                    {
                        MessageBox.Show("Please select the valid Birth date of Joint Holder 1");
                        dateJ2Birth.Focus();
                        return false;
                    }

                    if (txtJ1PhNo.Text.Length > 10 || txtJ1PhNo.Text.Length < 8)
                    {
                        MessageBox.Show("Invalid Phone number");
                        txtJ1PhNo.Text = "";
                        txtJ1PhNo.Focus();
                        return false;
                    }
                    if (txtJ2PhNo.Text.Length > 10 || txtJ2PhNo.Text.Length < 8)
                    {
                        MessageBox.Show("Invalid Phone number");
                        txtJ2PhNo.Text = "";
                        txtJ2PhNo.Focus();
                        return false;
                    }

                    if (flagJ1p == 0)
                    {
                        MessageBox.Show("Please upload the joint holder1 photo");
                        return false;
                    }
                    if (flagJ1S == 0)
                    {
                        MessageBox.Show("Please upload the joint holder1 Sign");
                        return false;
                    }

                    if (flagj2p == 0)
                    {
                        MessageBox.Show("Please upload the joint holder2 photo");
                        return false;
                    }
                    if (flagJ2s == 0)
                    {
                        MessageBox.Show("Please upload the joint holder sign");
                        return false;
                    }

                    if (txtJ1Name.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Name ");
                        txtJ1Name.Focus();
                        return false;
                    }
                    if (txtJ1OffAddress.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Office Address");
                        txtJ1OffAddress.Focus();
                        return false;
                    }
                    if (txtJ1ResAdd.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Residence Address");
                        txtJ1ResAdd.Focus();
                        return false;
                    }
                    if (txtJ1PhNo.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Phone Number");
                        txtJ1PhNo.Focus();
                        return false;
                    }
                    if (txtJ1Nationality.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Nationality");
                        txtJ1Nationality.Focus();
                        return false;
                    }
                    if (txtPicJ1.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Photo");
                        txtPicJ1.Focus();
                        return false;
                    }
                    if (txtpicJ1Sign.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 1 Sign");
                        txtpicJ1Sign.Focus();
                        return false;
                    }
                    i = dateJ2Birth.Value.Date.CompareTo(DateTime.Now.Date);
                    if (i == 0 || i == 1)
                    {
                        MessageBox.Show("Please select the valid Birth date of Joint Holder 2");
                        dateJ2Birth.Focus();
                        return false;
                    }

                    if (txtJ2Name.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Name ");
                        txtJ2Name.Focus();
                        return false;
                    }
                    if (txtJ2OffAdd.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Office Address");
                        txtJ2OffAdd.Focus();
                        return false;
                    }
                    if (txtJ2ResAdd.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Residence Address");
                        txtJ2ResAdd.Focus();
                        return false;
                    }
                    if (txtJ2PhNo.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Phone Number");
                        txtJ2PhNo.Focus();
                        return false;
                    }
                    if (txtJ2Nationality.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Nationality");
                        txtJ2Nationality.Focus();
                        return false;
                    }
                    if (txtPicJ2.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Photo");
                        txtPicJ2.Focus();
                        return false;
                    }
                    if (txtPicJ2Sign.Text == "")
                    {
                        MessageBox.Show("Please Enter the Joint Holder 2 Sign");
                        txtPicJ2Sign.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        public bool ValidateOnDelete()
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
            if (txtAccNo.Text != "")
            {
                try
                {
                    ds = vc.GetAccontMasterDetails(long.Parse(txtAccNo.Text));
                    //ds = vc.GetMinorDetails(long.Parse(txtAccNo.Text));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            byte[] BholderSign = (byte[])ds.Tables[0].Rows[0]["SignPath"];
                            string sHSign = Convert.ToString(DateTime.Now.ToFileTime());
                            FileStream fHSign = new FileStream(sHSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            fHSign.Write(BholderSign, 0, BholderSign.Length);
                            fHSign.Flush();
                            fHSign.Close();
                            picHoldSign.Image = Image.FromFile(sHSign);
                            picHoldSign.Invalidate();


                            byte[] Bholderphoto = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                            string SHphoto = Convert.ToString(DateTime.Now.ToFileTime());
                            //string SG1photo = "d://abc.text";
                            FileStream fHPhoto = new FileStream(SHphoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            fHPhoto.Write(Bholderphoto, 0, Bholderphoto.Length);
                            fHPhoto.Flush();
                            fHPhoto.Close();
                            picHolder.Image = Image.FromFile(SHphoto);
                            picHolder.Invalidate();

                            txtAccNo.Text = ds.Tables[0].Rows[0]["Acc_NO"].ToString();
                            txtRefNo.Text = ds.Tables[0].Rows[0]["Reference_No"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                            txtResident.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                            txtOff.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                            txtPhNo.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                            txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                            txtQulification.Text = ds.Tables[0].Rows[0]["Education"].ToString();
                            
                            cboAccType.SelectedText = ds.Tables[0].Rows[0]["Acc_Type"].ToString();
                            dateBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();

                            cboJNo.SelectedItem = ds.Tables[0].Rows[0]["JointHolder"].ToString();
                            cboMinor.SelectedItem = ds.Tables[0].Rows[0]["Minor"].ToString();

                            cboSex.SelectedText = ds.Tables[0].Rows[0]["Sex"].ToString();
                            txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                            txtPANNo.Text = ds.Tables[0].Rows[0]["Pan_No"].ToString();
                            txtIncometaxNo.Text = ds.Tables[0].Rows[0]["IncomeTax_No"].ToString(); ;
                            //txtHolderSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                            //txtHolderPhoto.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                            dateOpening.Text = ds.Tables[0].Rows[0]["Opening_Date"].ToString();

                        }
                        catch (IOException io)
                        {
                            MessageBox.Show(io.ToString());
                        }
                        if (cboMinor.Text == "Yes")
                        {
                            groupMinor.Visible = true;
                            ds = vc.GetMinorDetails(long.Parse(txtAccNo.Text));
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                try
                                {
                                    byte[] BMSign = (byte[])ds.Tables[0].Rows[0]["SignPath"];
                                    string sMSign = Convert.ToString(DateTime.Now.ToFileTime());
                                    FileStream fMSign = new FileStream(sMSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fMSign.Write(BMSign, 0, BMSign.Length);
                                    fMSign.Flush();
                                    fMSign.Close();
                                    picParentSign.Image = Image.FromFile(sMSign);
                                    picParentSign.Invalidate();


                                    txtParentName.Text = ds.Tables[0].Rows[0]["NameOfParent"].ToString();
                                    txtParentResidenceAdd.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                                    txtParentOfficeAdd.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                                    dateMinorBirth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString(); ;
                                    txtParentOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                                    txtRelation.Text = ds.Tables[0].Rows[0]["Relation"].ToString();
                                    //txtParentSign.Text = ds.Tables[0].Rows[0]["SignPath"].ToString();
                                }
                                catch (IOException io)
                                {
                                    MessageBox.Show(io.ToString());
                                }
                            }
                            else
                            {
                                MessageBox.Show("No Account Number Found");
                            }
                        }

                        if (int.Parse(cboJNo.Text) > 0)
                        {
                            //groupJointHolder1.Visible = true;
                            ds = vc.GetJointHolder(long.Parse(txtAccNo.Text));
                            if (cboJNo.Text == "1")
                            {
                                try
                                {
                                    byte[] BJ1Sign = (byte[])ds.Tables[0].Rows[0]["signPath"];
                                    string sJ1Sign = Convert.ToString(DateTime.Now.ToFileTime());
                                    FileStream fJ1Sign = new FileStream(sJ1Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ1Sign.Write(BJ1Sign, 0, BJ1Sign.Length);
                                    fJ1Sign.Flush();
                                    fJ1Sign.Close();
                                    picJ1Sign.Image = Image.FromFile(sJ1Sign);
                                    picJ1Sign.Invalidate();


                                    byte[] BJ1photo = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                                    string SJ1photo = Convert.ToString(DateTime.Now.ToFileTime());
                                    //string SG1photo = "d://abc.text";
                                    FileStream fJ1Photo = new FileStream(SJ1photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ1Photo.Write(BJ1photo, 0, BJ1photo.Length);
                                    fJ1Photo.Flush();
                                    fJ1Photo.Close();
                                    picJ1.Image = Image.FromFile(SJ1photo);
                                    picJ1.Invalidate();

                                    txtJ1Name.Text = ds.Tables[0].Rows[0]["JName"].ToString();
                                    txtJ1ResAdd.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                                    txtJ1OffAddress.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                                    txtJ1PhNo.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                                    txtJ1Nationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                                    dateJ1Birth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                                    //txtJ1Photo.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                                    //txtJ1Sign.Text = ds.Tables[0].Rows[0]["signPath"].ToString();
                                }
                                catch (IOException io)
                                {
                                    MessageBox.Show(io.ToString());
                                }
                            }
                            if (cboJNo.Text == "2")
                            {
                                try
                                {
                                    byte[] BJ1Sign = (byte[])ds.Tables[0].Rows[0]["signPath"];
                                    string sJ1Sign = Convert.ToString(DateTime.Now.ToFileTime());
                                    FileStream fJ1Sign = new FileStream(sJ1Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ1Sign.Write(BJ1Sign, 0, BJ1Sign.Length);
                                    fJ1Sign.Flush();
                                    fJ1Sign.Close();
                                    picJ1Sign.Image = Image.FromFile(sJ1Sign);
                                    picJ1Sign.Invalidate();


                                    byte[] BJ1photo = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                                    string SJ1photo = Convert.ToString(DateTime.Now.ToFileTime());
                                    FileStream fJ1Photo = new FileStream(SJ1photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ1Photo.Write(BJ1photo, 0, BJ1photo.Length);
                                    fJ1Photo.Flush();
                                    fJ1Photo.Close();
                                    picJ1.Image = Image.FromFile(SJ1photo);
                                    picJ1.Invalidate();

                                    txtJ1Name.Text = ds.Tables[0].Rows[0]["JName"].ToString();
                                    txtJ1ResAdd.Text = ds.Tables[0].Rows[0]["Res_Add"].ToString();
                                    txtJ1OffAddress.Text = ds.Tables[0].Rows[0]["Off_Add"].ToString();
                                    txtJ1PhNo.Text = ds.Tables[0].Rows[0]["Phone_No"].ToString();
                                    txtJ1Nationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();
                                    dateJ1Birth.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                                    //txtJ1Photo.Text = ds.Tables[0].Rows[0]["PhotoPath"].ToString();
                                    //txtJ1Sign.Text = ds.Tables[0].Rows[0]["signPath"].ToString();


                                    byte[] BJ2Sign = (byte[])ds.Tables[0].Rows[0]["signPath"];
                                    string sJ2Sign = Convert.ToString(DateTime.Now.ToFileTime());
                                    FileStream fJ2Sign = new FileStream(sJ2Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ2Sign.Write(BJ2Sign, 0, BJ2Sign.Length);
                                    fJ2Sign.Flush();
                                    fJ2Sign.Close();
                                    picJ2Sign.Image = Image.FromFile(sJ2Sign);
                                    picJ2Sign.Invalidate();


                                    byte[] BJ2photo = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                                    string SJ2photo = Convert.ToString(DateTime.Now.ToFileTime());
                                    //string SG1photo = "d://abc.text";
                                    FileStream fJ2Photo = new FileStream(SJ2photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    fJ2Photo.Write(BJ2photo, 0, BJ2photo.Length);
                                    fJ2Photo.Flush();
                                    fJ2Photo.Close();
                                    picJ2.Image = Image.FromFile(SJ2photo);
                                    picJ2.Invalidate();

                                    txtJ2Name.Text = ds.Tables[0].Rows[1]["JName"].ToString();
                                    txtJ2ResAdd.Text = ds.Tables[0].Rows[1]["Res_Add"].ToString();
                                    txtJ2OffAdd.Text = ds.Tables[0].Rows[1]["Off_Add"].ToString();
                                    txtJ2PhNo.Text = ds.Tables[0].Rows[1]["Phone_No"].ToString();
                                    txtJ2Nationality.Text = ds.Tables[0].Rows[1]["Nationality"].ToString();
                                    dateJ2Birth.Text = ds.Tables[0].Rows[1]["BirthDate"].ToString();
                                    //txtJ2Photo.Text = ds.Tables[0].Rows[1]["PhotoPath"].ToString();
                                    //txtJ2Sign.Text = ds.Tables[0].Rows[1]["signPath"].ToString();
                                }
                                catch (IOException io)
                                {
                                    MessageBox.Show(io.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Account Number Found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

            else
            {
                MessageBox.Show("Please Enter the Account Number");
            }
        }

        private void btnJ2Sign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                J2Sign = openDlg.FileName;
                txtPicJ2Sign.Text = J2Sign;
            }
        }

        private void btnPicHolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                holderPhoto = openDlg.FileName;
                txtPicHolder.Text = holderPhoto;
            }
        }

        private void btnPicJ1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                J1Photo = openDlg.FileName;
                txtPicJ1.Text = J1Photo;
            }
        }

        private void btnPicJ2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                J2Photo = openDlg.FileName;
                txtPicJ2.Text = J2Photo;
            }
        }

        private void btnHolderSign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                holderSign = openDlg.FileName;
                txtPicHoldSign.Text = holderSign;
            }
        }

        private void btnJ1Sign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                J1Sign = openDlg.FileName;
                txtpicJ1Sign.Text = J1Sign;
            }
        }

        private void btnParentSign_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                parentSign = openDlg.FileName;
                txtPicParentSign.Text = parentSign;
            }
        }

        private void btnUploadHolderPic_Click(object sender, EventArgs e)
        {
            if (txtPicHolder.Text != "")
            {
                FileStream file = new FileStream(holderPhoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();

                Bholderphoto = rawdata;
                MessageBox.Show("Image is uploaded");
                picHolder.LoadAsync(txtPicHolder.Text);
                flagHP = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (ValidateOnDelete() && ValidateOnAdd())
            {
                ec.updateAccount(long.Parse(txtRefNo.Text), txtName.Text, Convert.ToDateTime(dateOpening.Text), Convert.ToDateTime(dateBirth.Text),
                    (cboAccType.SelectedItem).ToString(), txtResident.Text, txtOff.Text, long.Parse(txtIncometaxNo.Text), long.Parse(txtPANNo.Text),
                    int.Parse((cboJNo.SelectedItem).ToString()), (cboMinor.SelectedItem).ToString(), long.Parse(txtPhNo.Text), txtNationality.Text, txtOccupation.Text, txtQulification.Text,
                    (cboSex.SelectedItem).ToString(), Bholderphoto, BholderSign, long.Parse(txtAccNo.Text));

                if ((cboMinor.SelectedItem).ToString() == "Yes")
                {

                    ec.updateMinor(Convert.ToDateTime(dateMinorBirth.Text), txtParentName.Text, txtParentResidenceAdd.Text, txtParentOfficeAdd.Text, txtParentOccupation.Text,
                        txtRelation.Text, BparentSign, long.Parse(txtAccNo.Text));
                }
                if ((cboJNo.SelectedItem).ToString() == "1")
                {
                    ec.updateJointHolder(txtJ1Name.Text, Convert.ToDateTime(dateJ1Birth.Text), long.Parse(txtJ1PhNo.Text),
                        txtJ1Nationality.Text, txtJ1ResAdd.Text, txtJ1OffAddress.Text,
                        BJ1Photo, BJ1Sign, groupJointHolder1.Text, long.Parse(txtAccNo.Text));
                }
                if ((cboJNo.SelectedItem).ToString() == "2")
                {
                    ec.updateJointHolder(txtJ1Name.Text, Convert.ToDateTime(dateJ1Birth.Text), long.Parse(txtJ1PhNo.Text),
                     txtJ1Nationality.Text, txtJ1ResAdd.Text, txtJ1OffAddress.Text,
                     BJ1Photo, BJ1Sign, groupJointHolder1.Text, long.Parse(txtAccNo.Text));


                    ec.updateJointHolder(txtJ2Name.Text, Convert.ToDateTime(dateJ2Birth.Text), long.Parse(txtJ2PhNo.Text),
                        txtJ2Nationality.Text, txtJ2ResAdd.Text, txtJ2OffAdd.Text, BJ2Photo, BJ2Sign, groupJointHolder2.Text, long.Parse(txtAccNo.Text));
                }

                MessageBox.Show("Update Account With mention Field");
            }
        }

        private void btnUploadJ1Pic_Click(object sender, EventArgs e)
        {
            if (txtPicJ1.Text != "")
            {
                FileStream file = new FileStream(J1Photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BJ1Photo = rawdata;

                MessageBox.Show("Image is uploaded");
                picJ1.LoadAsync(txtPicJ1.Text);
                flagJ1p = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUploadJ2Pic_Click(object sender, EventArgs e)
        {
            if (txtPicJ2.Text != "")
            {
                FileStream file = new FileStream(J2Photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BJ2Photo = rawdata;

                MessageBox.Show("Image is uploaded");
                picJ2.LoadAsync(txtPicJ2.Text);
                flagj2p = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUploadHolderSign_Click(object sender, EventArgs e)
        {
            if (txtPicHoldSign.Text != "")
            {
                FileStream file = new FileStream(holderSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BholderSign = rawdata;

                MessageBox.Show("Image is uploaded");
                picHoldSign.LoadAsync(txtPicHoldSign.Text);
                flagHS = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUploadJ1Sign_Click(object sender, EventArgs e)
        {
            if (txtpicJ1Sign.Text != "")
            {
                FileStream file = new FileStream(J1Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BJ1Sign = rawdata;

                MessageBox.Show("Image is uploaded");
                picJ1Sign.LoadAsync(txtpicJ1Sign.Text);
                flagJ1S = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUploadJ2Sign_Click(object sender, EventArgs e)
        {
            if (txtPicJ2Sign.Text != "")
            {
                FileStream file = new FileStream(J2Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BJ2Sign = rawdata;

                MessageBox.Show("Image is uploaded");
                picJ2Sign.LoadAsync(txtPicJ2Sign.Text);
                flagJ2s = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }

        private void btnUploadParentSign_Click(object sender, EventArgs e)
        {
            if (txtPicParentSign.Text != "")
            {
                FileStream file = new FileStream(parentSign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] rawdata = new byte[file.Length];
                file.Read(rawdata, 0, System.Convert.ToInt32(file.Length));
                file.Close();
                BparentSign = rawdata;

                MessageBox.Show("Image is uploaded");
                picParentSign.LoadAsync(txtPicParentSign.Text);
                flagPS = 1;
            }
            else
            {
                MessageBox.Show("click brows");
            }
        }
        private void txtInitialAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtInitialAmount.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
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
        private void txtIncometaxNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtJ1PhNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtJ2PhNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPhNo_Leave(object sender, EventArgs e)
        {
            if (txtPhNo.Text.Length < 8 || txtPhNo.Text.Length > 10)
            {
                MessageBox.Show("invalid phone number");
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            txtIncometaxNo.Text = "";
            txtInitialAmount.Text = "";
            txtJ1Name.Text = "";
            txtJ1Nationality.Text = "";
            txtJ1OffAddress.Text = "";
            txtJ1PhNo.Text = "";
            txtJ1ResAdd.Text = "";
            txtJ2Name.Text = "";
            txtJ2Nationality.Text = "";
            txtJ2OffAdd.Text = "";
            txtJ2PhNo.Text = "";
            txtJ2ResAdd.Text = "";
            txtName.Text = "";
            txtNationality.Text = "";
            txtOccupation.Text = "";
            txtOff.Text = "";
            txtPANNo.Text = "";
            txtParentName.Text = "";
            txtParentOccupation.Text = "";
            txtParentOfficeAdd.Text = "";
            txtParentResidenceAdd.Text = "";
            txtPhNo.Text = "";
            txtPicHolder.Text = "";
            txtPicHoldSign.Text = "";
            txtPicJ1.Text = "";
            txtpicJ1Sign.Text = "";
            txtPicJ2.Text = "";
            txtPicJ2Sign.Text = "";
            txtPicParentSign.Text = "";
            txtQulification.Text = "";
            txtRefNo.Text = "";
            txtRelation.Text = "";
            txtResident.Text = "";
            cboAccType.Text = "";
            cboJNo.Text = "0";
            cboMinor.Text = "No";
            cboSex.Text = "";
            picHolder.Image = null;
            picHoldSign.Image = null;
            picJ1.Image = null;
            picJ1Sign.Image = null;
            picJ2.Image = null;
            picJ2Sign.Image = null;
            picParentSign.Image = null;
            txtPicJ1.Text = "";
            txtPicJ2.Text = "";
            txtpicJ1Sign.Text = "";
            txtPicJ2Sign.Text = "";
            txtPicParentSign.Text = "";
        }

       
      

    }
}
