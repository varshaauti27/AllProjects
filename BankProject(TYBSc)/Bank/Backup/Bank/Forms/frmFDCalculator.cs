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
    public partial class frmFDCalculator : Form
    {
        InsertClass ic = new InsertClass();
        DeleteClass dc = new DeleteClass();
        EditClass ec = new EditClass();
        ViewClass vc = new ViewClass();

        decimal rate45 = 0.0M, rate90 = 0.0M, rate180 = 0.0M, rate540 = 0.0M, rate1800 = 0.0M, rate1801 = 0.0M;

        public frmFDCalculator()
        {
            InitializeComponent();
        }

        public bool validateOnAdd()
        {
            DataSet ds = new DataSet();
            //ds = vc.GetFixedDeposite1(long.Parse(txtAccNo.Text));

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                MessageBox.Show("No such account number is found");
                return false;
            }

           
            if (txtAmt.Text == "")
            {
                MessageBox.Show("Please Enter the Amount");
                txtAmt.Focus();
                return false;
            }
            if (txtDuration.Text == "")
            {
                MessageBox.Show("Please Enter the Duration");
                txtDuration.Focus();
                return false;
            }
            if (txtRate.Text == "")
            {
                MessageBox.Show("Please Enter the Rate");
                txtRate.Focus();
                return false;
            }
            if (txtAfterDue.Text == "")
            {
                MessageBox.Show("Plese Enter Anount after Due Date");
                txtAfterDue.Focus();
                return false;
            }
            return true;
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            string txtDurationTime;
            long duration;
            decimal rate;
            decimal amtAfter;
            duration = long.Parse(txtDuration.Text);
            txtDurationTime = txtDuration.Text;

            if (txtDurationTime != "")
            {
                DateTime dt = new DateTime(int.Parse((DateTime.Now.Date.Year).ToString()), int.Parse((DateTime.Now.Date.Month).ToString()), int.Parse((DateTime.Now.Date.Day).ToString()));
                dateTo.Value = dt.AddDays(double.Parse(txtDuration.Text));
            }
            else
            {
                MessageBox.Show("Plese Enter the Duration");
                txtDuration.Focus();
            }

            if (duration >= 1801)
                rate = rate1801;
            else if (duration >= 541 && duration <= 1800)
                rate = rate1800;
            else if (duration >= 181 && duration <= 540)
                rate = rate540;
            else if (duration >= 91 && duration <= 180)
                rate = rate180;
            else if (duration >= 46 && duration <= 90)
                rate = rate90;
            else if (duration >= 15 && duration <= 45)
                rate = rate45;
            else
                rate = 0.0M;
            txtRate.Text = rate.ToString();
            amtAfter = decimal.Parse(txtAmt.Text) + (decimal.Parse(txtAmt.Text) * rate);
            txtAfterDue.Text = amtAfter.ToString();
        }
        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }

        }


        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 46 && (txtAmt.Text.Contains(".") == false)) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter valid integer.");
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtAccNo.Text = "";
            txtAfterDue.Text = "";
            txtAmt.Text = "";
            //txtDuration.Text = "";

            //txtFixedId.Text = "";
            txtRate.Text = "";
        }

        private void frmFDCalculator_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = vc.GetIntRate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                rate45 = decimal.Parse(ds.Tables[0].Rows[0]["Fix45"].ToString());
                rate90 = decimal.Parse(ds.Tables[0].Rows[0]["Fix90"].ToString());
                rate180 = decimal.Parse(ds.Tables[0].Rows[0]["Fix180"].ToString());
                rate540 = decimal.Parse(ds.Tables[0].Rows[0]["Fix540"].ToString());
                rate1800 = decimal.Parse(ds.Tables[0].Rows[0]["Fix1800"].ToString());
                rate1801 = decimal.Parse(ds.Tables[0].Rows[0]["Fix1801"].ToString());

            }
            else
            {
                MessageBox.Show("No Rate Found");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
