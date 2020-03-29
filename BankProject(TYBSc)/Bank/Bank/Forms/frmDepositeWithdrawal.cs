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
    public partial class frmDepositeWithdrawal : Form
    {
        InsertClass ic = new InsertClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();
        DeleteClass dc = new DeleteClass();
        string trans;

        public frmDepositeWithdrawal()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (validateOnDelete())
            {
                ds = vc.GetTransaction(long.Parse(txtDwAcNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTransaction.Text = ds.Tables[0].Rows[0]["TransactionNo"].ToString();
                    txtDwBal.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                    if (ds.Tables[0].Rows[0]["Deposit"].ToString() != null)
                    {
                        txtDwAmount.Text = ds.Tables[0].Rows[0]["Deposit"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Withdrawl"].ToString() != null)
                    {
                        txtDwAmount.Text = ds.Tables[0].Rows[0]["Withdrawl"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No Account Found");
                }

            }
        }

        private void frmDepositeWithdrawal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet21.TransactionTable' table. You can move, or remove it, as needed.
            //this.transactionTableTableAdapter.Fill(this.bankDataSet21.TransactionTable);
            this.transactionTableTableAdapter.Fill(this.bankDataSet21.TransactionTable);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtDwAcNo.Text = "";
            txtDwAmount.Text = "";
            txtDwBal.Text = "";
            txtDwChqNo.Text = "";
            txtToAcNo.Text = "";
            txtTransaction.Text = "";
        }

        private void txtDwAcNo_Leave(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (txtDwAcNo.Text != "")
            {
                ds = vc.GetTransaction(long.Parse(txtDwAcNo.Text));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txtTransaction.Text = ds.Tables[0].Rows[0]["TransactionNo"].ToString(); ;
                    txtDwBal.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                }
                else
                {
                    MessageBox.Show("No Account Found");
                }
            }
            else
            {
                MessageBox.Show("Plese Enter the Account Number");
            }
        }

        private void rdbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTransfer.Checked == true)
            {
                lblToAccNo.Visible = true;
                txtToAcNo.Visible = true;
            }
            else
            {
                lblToAccNo.Visible = false;
                txtToAcNo.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal balance = 0M;
            string transaN = "";
            string tway = "";
            if (rdbSelf.Checked == true)
            {
                tway = "self";
            }
            if (rdbChq.Checked == true)
            {
                tway = "chq" + txtDwChqNo.Text;
            }
            if (rdbTransfer.Checked == true)
            {
                tway = "Acc" + txtToAcNo.Text;
            }
            if (validateOnAdd())
            {
                if (rdbDwDeposite.Checked == true)
                {
                    balance = decimal.Parse(txtDwBal.Text) + decimal.Parse(txtDwAmount.Text);
                    ic.addDepositeTransaction(long.Parse(txtDwAcNo.Text), balance, tway, decimal.Parse(txtDwAmount.Text), out transaN);
                    if (rdbTransfer.Checked == true)
                    {
                        string i1;
                        DataSet ds = new DataSet();

                        ds = vc.GetTransaction(long.Parse(txtToAcNo.Text));
                        // decimal withdraw=0.0M;
                        //decimal balance1=0.0M;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string type;

                            balance = long.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                            balance = balance - decimal.Parse(txtDwAmount.Text);
                            type = "Acc" + txtDwAcNo.Text;
                            ic.addWithdrawalTransaction(long.Parse(txtToAcNo.Text), balance, type, decimal.Parse(txtDwAmount.Text), out i1);
                        }
                        else
                        {
                            MessageBox.Show("No account found");
                        }
                    }
                    MessageBox.Show("Transaction is Added");
                }

                if (rdbDwWithdrawal.Checked == true)
                {
                    if ((decimal.Parse(txtDwBal.Text) - decimal.Parse(txtDwAmount.Text)) >= 0)
                    {
                        balance = decimal.Parse(txtDwBal.Text) - decimal.Parse(txtDwAmount.Text);
                        ic.addWithdrawalTransaction(long.Parse(txtDwAcNo.Text), balance, tway, decimal.Parse(txtDwAmount.Text), out transaN);
                        MessageBox.Show("Transaction is Added");

                        string i1;
                        DataSet ds = new DataSet();

                        if (rdbTransfer.Checked == true)
                        {
                            ds = vc.GetTransaction(long.Parse(txtToAcNo.Text));
                            //    decimal withdraw = 0.0M;
                            //    decimal balance1 = 0.0M;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string type;

                                balance = long.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                                balance = balance + decimal.Parse(txtDwAmount.Text);
                                type = "Acc" + txtDwAcNo.Text;
                                ic.addDepositeTransaction(long.Parse(txtToAcNo.Text), balance, type, decimal.Parse(txtDwAmount.Text), out i1);
                            }
                            else
                            {
                                MessageBox.Show("No account found");
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Balance is less can not withdraw");
                    }
                }
                txtTransaction.Text = transaN;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (validateOnAdd() && validateOnDelete())
            {
                string tway = "";
                if (rdbSelf.Checked == true)
                {
                    tway = "self";
                }
                if (rdbChq.Checked == true)
                {
                    tway = "chq" + txtDwChqNo.Text;
                }
                if (rdbTransfer.Checked == true)
                {
                    tway = "Acc" + txtToAcNo.Text;
                }
                if (rdbDwDeposite.Checked == true)
                    ec.updateDepositeTransaction(long.Parse(txtDwAcNo.Text), decimal.Parse(txtDwBal.Text), tway, decimal.Parse(txtDwAmount.Text), long.Parse(txtTransaction.Text));
                else
                    ec.updateWithdrawalTransaction(long.Parse(txtDwAcNo.Text), decimal.Parse(txtDwBal.Text), tway, decimal.Parse(txtDwAmount.Text), long.Parse(txtTransaction.Text));
                MessageBox.Show("Transactiom is Edited");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateOnDelete())
            {
                dc.deletTransaction(long.Parse(txtTransaction.Text));
                MessageBox.Show("Transaction Is Deleted");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validateOnAdd()
        {
            DataSet ds = new DataSet();
            ds = vc.GetAccontMasterDetails(long.Parse(txtDwAcNo.Text));

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("No such account number is found");
                return false;
            }
            if (txtDwAcNo.Text == "")
            {
                MessageBox.Show("Please Enter the Account Number");
                txtDwAcNo.Focus();
                return false;
            }
            if (txtDwAmount.Text == "")
            {
                MessageBox.Show("Please Enter the Ammount");
                txtDwAmount.Focus();
                return false;
            }
            if (rdbDwDeposite.Checked == false && rdbDwWithdrawal.Checked == false)
            {
                MessageBox.Show("Please Select the Transaction ");
                rdbDwDeposite.Focus();
                return false;
            }
            if (rdbChq.Checked == true)
            {
                if (txtDwChqNo.Text == "")
                {
                    MessageBox.Show("Please Enter the Cheque No");
                    txtDwChqNo.Focus();
                    return false;
                }
            }
            if (rdbTransfer.Checked == true)
            {
                if (txtToAcNo.Text == "")
                {
                    MessageBox.Show("Please Enter the Account Number Where want to transfer");
                    txtToAcNo.Focus();
                    return false;
                }
            }
            return true;
        }
        public bool validateOnDelete()
        {
            if (txtTransaction.Text == "")
            {
                MessageBox.Show("Please enter the tranasction number");
                return false;
                //txtTransaction.Focus();
            }
            return true;
        }
        private void txtDwBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtDwBal.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }

        private void txtDwAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtDwAmount.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount.");
            }

        }

        private void txtDwChqNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtDwChqNo.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }

        private void txtToAcNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtToAcNo.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }

        }

        private void txtTransaction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 46 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid Amount");
            }
        }

        private void rdbChq_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbChq.Checked == true)
            {

                lblChqNo.Visible = true;
                txtDwChqNo.Visible = true;
                trans = "ch" + txtDwChqNo.Text;
            }
            else
            {

                lblChqNo.Visible = false;
                txtDwChqNo.Visible = false;
            }
        }

    }
}
