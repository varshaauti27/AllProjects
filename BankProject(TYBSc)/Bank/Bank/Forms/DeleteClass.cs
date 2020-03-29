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
    class DeleteClass
    {
         public const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
        SqlConnection con = new SqlConnection();

        public DeleteClass()
        {
            con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public void deletMinor(long accNo)
        {
            string sp_name = "prosDeleteMinor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deleteLoanTransction(long transactioNo)
        {
            string sp_name = "prosDeleteLoanTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TransactionNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transactioNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletTransaction(long TransactionNo)
        {
            string sp_name = "prosDeleteTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@TransactionNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = TransactionNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deleteJointHolder(long accNo)
        {
            string sp_name = "prosDeleteJointHolder";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletAccount(long accNo)
        {
            string sp_name = "prosDeletAccount";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletCheqBook(long accNo)
        {
            string sp_name = "prosDeletChequeBook";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletEmployee(long accNo)
        {
            string sp_name = "prosDeleteEmployee";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Eid", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletLocker(long locker)
        {
            string sp_name = "prosDeleteLocker";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@locker", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = locker;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deleteFixedDeposite(long Fid)
        {
            string sp_name = "prosDeletFixedDeposite";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FID", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Fid;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletGuarantor(long accNo)
        {
            string sp_name = "prosDeletGurantor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNO", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void deletHomeVehicale(long accNo,string loanType)
        {
            string sp_name = "prosDeletHomeVehical";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LoanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
        }

        public void deleteStudent(long appNO)
        {
            string sp_name = "prosDeleteStudent";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AppNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appNO;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
    }
    }
