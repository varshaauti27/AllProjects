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
    public partial class frmLoanTransaction : Form
    {
        InsertClass ic = new InsertClass();
        ViewClass vc = new ViewClass();
        DeleteClass dc = new DeleteClass();
        EditClass ec = new EditClass();
        decimal chekemi = 0.0M;

        public frmLoanTransaction()
        {
            InitializeComponent();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbChq_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbChq.Checked == true)
            {
                chqNo.Visible = true;
                txtChequeNo.Visible = true;
            }
            else
            {
                chqNo.Visible = false;
                txtChequeNo.Visible = false;
            }
        }
        public bool validateOnAdd()
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            ds = vc.GetStudentsDetails(long.Parse(txtAccountNO.Text));
            ds1 = vc.GetHomeVehicaleDetails(long.Parse(txtAccountNO.Text));

            if (!(ds.Tables[0].Rows.Count > 0) && !(ds1.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("No such loan found");
            }
            if (txtAccountNO.Text == "")
            {
                MessageBox.Show("Please enter the account number");
                txtAccountNO.Focus();
                return false;
            }
            if (cboLoanType.Text == "")
            {
                MessageBox.Show("Please select the loan type");
                cboLoanType.Focus();
                return false;

            }
            if (txtBalance.Text == "")
            {
                MessageBox.Show("Please enter the Balance");
                txtBalance.Focus();
                return false;

            }
            if (txtEMI.Text == "")
            {
                MessageBox.Show("Please enter the emi ");
                txtEMI.Focus();
                return false;

            }
            if (txtIntRate.Text == "")
            {
                MessageBox.Show("Please enter the Interest Rate");
                txtIntRate.Focus();
                return false;

            }
            if (rdbChq.Checked == true)
            {
                if (txtChequeNo.Text == "")
                {
                    MessageBox.Show("Please Enter the Cheque NO");
                    txtChequeNo.Focus();
                    return false;

                }
            }
            return true;
        }
        public bool validateonDelete()
        {
            if (txtTransNo.Text == "")
            {
                MessageBox.Show("Please enter the Transaction number");
                txtTransNo.Focus();
                return false;

            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtEMI.Text) >= chekemi)
            {
                string transWay = "";
                string transNo = "";
                decimal balance = 0.0M, intRate = 0.0M, emi = 0.0M, amt = 0.0M;


                balance = decimal.Parse(txtBalance.Text);
                emi = decimal.Parse(txtEMI.Text);
                intRate = decimal.Parse(txtIntRate.Text);
                balance = balance - emi;
                amt = (balance * (decimal)(intRate / 100)) / (decimal)12;
                balance = balance + amt;

                if (rbdSelf.Checked == true)
                {
                    transWay = "self";
                }
                if (rdbAccount.Checked == true)
                {
                    transWay = "Ac" + txtAccountNO.Text;
                }
                if (rdbChq.Checked == true)
                {
                    transWay = "Chq" + txtChequeNo.Text;
                }

                if (validateOnAdd())
                {
                    DataSet ds = new DataSet();

                    if (rdbAccount.Checked == true)
                    {
                        string i1;
                        //DataSet ds = new DataSet();

                        ds = vc.GetTransaction(long.Parse(txtAccountNO.Text));
                        //decimal withdraw = 0.0M;
                        decimal balance1 = 0.0M;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string type;

                            balance1 = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                            balance1 = balance1 - decimal.Parse(txtEMI.Text);

                            if (balance1 >= 0)
                            {
                                type = "loan";
                                ic.addWithdrawalTransaction(long.Parse(txtAccountNO.Text), balance1, type, decimal.Parse(txtEMI.Text), out i1);

                                ic.addLoanTransaction(long.Parse(txtAccountNO.Text), balance, transWay, decimal.Parse(txtEMI.Text), decimal.Parse(txtIntRate.Text), cboLoanType.Text, out transNo);
                                MessageBox.Show("Transaction is accepted");
                            }
                            else
                            {
                                MessageBox.Show("Account Balance is less than 0 can not do transaction");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No account found");
                        }
                    }
                    else
                    {
                        ic.addLoanTransaction(long.Parse(txtAccountNO.Text), balance, transWay, decimal.Parse(txtEMI.Text), decimal.Parse(txtIntRate.Text), cboLoanType.Text, out transNo);
                        MessageBox.Show("Transaction is accepted");
                    }
                }
            }
            else
            {
                MessageBox.Show("Can not enter the less amount than predefine emi");
                txtEMI.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateonDelete())
            {
                dc.deleteLoanTransction(long.Parse(txtTransNo.Text));
                MessageBox.Show("Transaction is Deleted!!!!!!!");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (validateonDelete())
            {
                ds = vc.GetLoanTransaction1(long.Parse(txtTransNo.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cboLoanType.Text = ds.Tables[0].Rows[0]["Loantype"].ToString();
                    txtBalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                    txtEMI.Text = ds.Tables[0].Rows[0]["EMI"].ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["InterestRate"].ToString();
                    txtAccountNO.Text = ds.Tables[0].Rows[0]["AccNo"].ToString();

                }
                else
                {
                    MessageBox.Show("No transaction is found");
                }

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtAccountNO.Text = "";
            txtBalance.Text = "";
            txtChequeNo.Text = "";
            txtEMI.Text = "";
            txtIntRate.Text = "";
            txtTransNo.Text = "";
        }
        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtBalance.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
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
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txtIntRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtIntRate.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void txtTransNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtAccountNO_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAccountNO_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (txtAccountNO.Text != "" && cboLoanType.SelectedItem.ToString() != "")
            {
                ds = vc.GetLoanTransaction2(long.Parse(txtAccountNO.Text), (cboLoanType.SelectedItem).ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if ((cboLoanType.SelectedItem).ToString() == "Home Loan" || (cboLoanType.SelectedItem).ToString() == "Vehical Loan")
                    {
                        ds1 = vc.GetHomeVehicaleDetails(long.Parse(txtAccountNO.Text));
                    }
                    if ((cboLoanType.SelectedItem).ToString() == "Student Loan")
                    {
                        ds1 = vc.GetStudentsDetails(long.Parse(txtAccountNO.Text));
                    }
                    //txtTransaction.Text = ds.Tables[0].Rows[0]["TransactionNo"].ToString(); ;
                    chekemi = decimal.Parse(ds1.Tables[0].Rows[0]["EMI"].ToString());
                    txtBalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                    txtEMI.Text = chekemi.ToString();
                    txtIntRate.Text = ds.Tables[0].Rows[0]["InterestRate"].ToString();
                    //txtLoanType.Text = ds.Tables[0].Rows[0]["Loantype"].ToString();
                }
                else
                {
                    MessageBox.Show("No Account Found");
                }
            }
            else
            {
                MessageBox.Show("Plese Enter the Account Number and select the Loan type");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chekemi <= decimal.Parse(txtEMI.Text))
            {
                string transWay = "";
                // string transNo = "";
                decimal balance = 0.0M, intRate = 0.0M, emi = 0.0M, amt = 0.0M;


                balance = decimal.Parse(txtBalance.Text);
                emi = decimal.Parse(txtEMI.Text);
                intRate = decimal.Parse(txtIntRate.Text);
                balance = balance - emi;
                amt = (balance * (decimal)(intRate / 100)) / (decimal)12;
                balance = balance + amt;

                if (rbdSelf.Checked == true)
                {
                    transWay = "self";
                }
                if (rdbAccount.Checked == true)
                {
                    transWay = "Ac" + txtAccountNO.Text;
                }
                if (rdbChq.Checked == true)
                {
                    transWay = "Chq" + txtChequeNo.Text;
                }

                if (validateOnAdd() && validateonDelete())
                {
                    ec.updateLoanTransaction(long.Parse(txtAccountNO.Text), decimal.Parse(txtBalance.Text), transWay, decimal.Parse(txtEMI.Text), decimal.Parse(txtIntRate.Text), (cboLoanType.SelectedItem).ToString(), long.Parse(txtTransNo.Text));
                    MessageBox.Show("Loan Transaction Is Updated");
                }
            }
            else
            {
                MessageBox.Show("Can not enter the less amount than predefine emi");
                txtEMI.Focus();
            }
        }
    }
}
