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
    public partial class frmVerification : Form
    {
        ViewClass vc = new ViewClass();
        public frmVerification()
        {
            InitializeComponent();
        }

        private void frmVerification_Load(object sender, EventArgs e)
        {
            new InsertClass();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
             int i ;
            DataSet ds = new DataSet();
            if (txtAccNo.Text != "")
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
                        picHSign.Image = Image.FromFile(sHSign);
                        picHSign.Invalidate();


                        byte[] Bholderphoto = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                        string SHphoto = Convert.ToString(DateTime.Now.ToFileTime());
                        //string SG1photo = "d://abc.text";
                        FileStream fHPhoto = new FileStream(SHphoto, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        fHPhoto.Write(Bholderphoto, 0, Bholderphoto.Length);
                        fHPhoto.Flush();
                        fHPhoto.Close();
                        picHPhoto.Image = Image.FromFile(SHphoto);
                        picHPhoto.Invalidate();

                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.ToString());
                    }
                    i = int.Parse(ds.Tables[0].Rows[0]["JointHolder"].ToString());


                    if (ds.Tables[0].Rows[0]["Minor"].ToString() == "Yes")
                    {

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
                                picJ1Sign.Image = Image.FromFile(sMSign);
                                picJ1Sign.Invalidate();
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

                    if (i > 0)
                    {
                        //groupJointHolder1.Visible = true;
                        ds = vc.GetJointHolder(long.Parse(txtAccNo.Text));
                        if (i == 1)
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
                                picJ1Photo.Image = Image.FromFile(SJ1photo);
                                picJ1Sign.Invalidate();
                            }
                            catch (IOException io)
                            {
                                MessageBox.Show(io.ToString());
                            }

                        }
                        if (i == 2)
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
                                picJ1Photo.Image = Image.FromFile(SJ1photo);
                                picJ1Photo.Invalidate();



                                byte[] BJ2Sign = (byte[])ds.Tables[0].Rows[0]["signPath"];
                                string sJ2Sign = Convert.ToString(DateTime.Now.ToFileTime());
                                FileStream fJ2Sign = new FileStream(sJ2Sign, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                fJ2Sign.Write(BJ2Sign, 0, BJ2Sign.Length);
                                fJ2Sign.Flush();
                                fJ2Sign.Close();
                                picj2Sign.Image = Image.FromFile(sJ2Sign);
                                picj2Sign.Invalidate();


                                byte[] BJ2photo = (byte[])ds.Tables[0].Rows[0]["PhotoPath"];
                                string SJ2photo = Convert.ToString(DateTime.Now.ToFileTime());
                                //string SG1photo = "d://abc.text";
                                FileStream fJ2Photo = new FileStream(SJ2photo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                fJ2Photo.Write(BJ2photo, 0, BJ2photo.Length);
                                fJ2Photo.Flush();
                                fJ2Photo.Close();
                                picj2Photo.Image = Image.FromFile(SJ2photo);
                                picj2Photo.Invalidate();
                                //lblBalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                            }
                            catch (IOException io)
                            {
                                MessageBox.Show(io.ToString());
                            }
                        }
                    }
                    ds = vc.GetTransaction(long.Parse(txtAccNo.Text));
                    lblBalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                }
                else
                {
                    MessageBox.Show("No Account Number Found");
                }                
            }   
        }
        
        public bool validateOncheck()
        {
            if (txtAccNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtAccNo.Focus();
                return false;
            }
            return true;
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
    }
}

