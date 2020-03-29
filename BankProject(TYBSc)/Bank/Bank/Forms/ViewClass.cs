using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Bank.Forms
{
    class ViewClass
    {

        public const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
        SqlConnection con = new SqlConnection();

        public ViewClass()
        {
            con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public DataSet GetLoanTransaction1(long TransactionNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLoanTransaction1";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@transactionNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = TransactionNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "loanTransaction1");

            return ds;

        }

        public DataSet GetFixedDeposite1(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewFixedDeposite1";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "fixedDeposite1");

            return ds;

        }

        public DataSet GetLockerNo()
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLockerNo";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "lockerNo");

            return ds;

        }

        public DataSet getlocker1(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLocker1";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "LockerDetails1");

            return ds;
        }

        public DataSet GetIntRate()
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewIntRate";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "IntRateValue");

            return ds;

        }

        public DataSet GetIMG(long imgId)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewImg";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@imgID", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = imgId;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "imgTab");

            return ds;

        }

        public DataSet GetJointHolder(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewJointHolder";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "JointDetails");

            return ds;

        }

        public void seeLogin(string userName, out int flag)
        {
            string sp_name = "prosSeeLogin";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@userName", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = userName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@flag", SqlDbType.BigInt, 100);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();
            flag = int.Parse(param.Value.ToString());
        }

        public DataSet CheckLogin(string user)
        {
            DataSet ds = new DataSet();

            //Create_Password cp = new Create_Password();
            string sp_name = "prosViewUser";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@username", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = user;
            cmd.Parameters.Add(param);



            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "password");

            return ds;
        }

        public DataSet GetTransaction(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo ", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);



            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "Transaction");

            return ds;
        }

        public DataSet GetPassbook(long accNo, long transNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewPassBook";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo ", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@transNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "PassBook");

            return ds;
        }

        public DataSet GetLoanTransaction(long accNo, string loanType)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLoanTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo ", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@loanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "LoanTransaction");

            return ds;
        }

        public DataSet GetLoanTransaction2(long accNo, string loanType)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLoanTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo ", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@loanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "LoanTransaction2");

            return ds;
        }

        public DataSet GetEmplyeeDetails(long eid)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewEmployee";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Eid", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = eid;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "EmpDetails");

            return ds;

        }

        public DataSet GetFixedDepositeDetails(long fid)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewFixedDeposite";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FID", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fid;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "FDDetails");

            return ds;

        }

        public DataSet GetChequeBook(long AccNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewChequeBook";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = AccNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "ChqDetails");

            return ds;

        }

        public DataSet GetLockerDetails(long lockerNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLocker";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@locker", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = lockerNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "LockerDetails");

            return ds;

        }

        public DataSet GetAccontMasterDetails(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewAccountMaster";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "AccountHolderDetails");

            return ds;

        }

        public DataSet GetMinorDetails(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewMinor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "MinorDetails");

            return ds;

        }

        public DataSet GetGuarantorDetails(long appNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewGurentor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AppNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "GuarantorDetails");

            return ds;

        }

        public DataSet GetHomeVehicaleDetails(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewHomeVehicale";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "HomeVehicalDetails");

            return ds;

        }

        public DataSet GetStudentsDetails(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewStudent";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "StudentDetails");

            return ds;

        }

        public DataSet GetLoanTransactionView(long accNo)
        {
            DataSet ds = new DataSet();
            string sp_name = "prosViewLoanTransaction3";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo ", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            /*param = new SqlParameter("@loanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);*/

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "LoanTransaction");

            return ds;
        }
      
    }
}
