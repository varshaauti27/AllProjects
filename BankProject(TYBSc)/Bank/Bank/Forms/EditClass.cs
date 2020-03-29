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
    class EditClass
    {
        public const string constring = "Data Source=VARSHAAUTI4B26;Initial Catalog=BanK_DB;Integrated Security=True";
        readonly SqlConnection con;

        public EditClass()
        {
            con = new SqlConnection(constring);
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public void updateLogin(string username, string pass)
        {
            //Create_Password cp = new Create_Password();
            string sp_name = "prosUpdatePassword";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@userID", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = username;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@userPass", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = pass;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();


        }

        public void updateLocker(long locker, long accNo, DateTime OpenDate, long deposite, string active)
        {
            string sp_name = "prosUpdateLocker";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@locker", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = locker;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OpeningDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = OpenDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Deposite_Amt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = deposite;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Active", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = active;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void updateInterestRate(decimal home, decimal vehicale, decimal student, decimal fix45, decimal fix90, decimal fix180, decimal fix540, decimal fix1800, decimal fix1801)
        {
            string sp_name = "prosUpdateIntRate";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Home", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = home;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Vehicale", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = vehicale;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Student", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = student;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix45", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix45;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix90", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix90;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix180", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix180;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix540", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix540;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix1800", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix1800;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Fix1801", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = fix1801;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }

        public void updateDepositeTransaction(long AccNo, decimal balance, string transWay, decimal deposite, long tran_no)
        {
            string sp_name = "prosEditDeposite";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = AccNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@balance", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = balance;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@transWay", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transWay;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@deposite", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = deposite;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Trans_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = tran_no;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();


        }

        public void updateWithdrawalTransaction(long AccNo, decimal balance, string transWay, decimal withdraw, long tran_no)
        {
            string sp_name = "prosEditWithdrawal";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@accNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = AccNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@balance", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = balance;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@transWay", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transWay;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@withdrawal", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = withdraw;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Trans_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = tran_no;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

        }

        public void updateAccount(long RefNo, string Name, DateTime opendate,
            DateTime birthdate, string accType, string resAdd, string OffAdd,
            long incomeTax, long panNO, long JId1,
            string Minor, long Phno, string Nationality, string Occup,
            string Education, string sex, byte[] photo, byte[] sign, long AccNo)
        {
            string sp_name = "prosUpdateAccountMaster";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Ref_NO", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = RefNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = AccNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Name;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Opening_Date", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = opendate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BirthDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = birthdate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Acc_Type", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Res_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = resAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Off_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = OffAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IncomeTax_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = incomeTax;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Pan_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = panNO;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@JointHolder", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = JId1;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@Minor", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Minor;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Phone_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Phno;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Nationality", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Nationality;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Occupation", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Occup;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Education", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Education;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Sex", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = sex;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = photo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SignPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = sign;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();


        }

        public void updateMinor(DateTime birthdate, string name, string ResAdd,
            string offAdd, string occup, string relation, byte[] signpath, long accNo)
        {

            string sp_name = "prosUpdateMinor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@birthdate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = birthdate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = name;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@ResAdd", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = ResAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@OffAdd", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = offAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Occup", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = occup;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@relation", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = relation;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@signPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = signpath;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }

        public void updateJointHolder(string JName, DateTime birthdate, long phNo, string Nationality,
           string resAdd, string offAdd, byte[] photoPath, byte[] signpath, string JointHolder, long accNo)
        {
            string sp_name = "prosUpdateJointHolder";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@JName", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = JName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Birthdate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = birthdate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Phone_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = phNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@Nationality", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Nationality;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Res_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = resAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Off_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = offAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = photoPath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SignPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = signpath;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@JoinType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = JointHolder;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }



        public void updateEmployee(long Eid, string Ename, string eadd, string esex, DateTime birthDate, long phno, string ejob, decimal esal, byte[] photo, byte[] sign, long basicSal, long PF)
        {
            string sp_name = "prosUpdateEmployee";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@EId", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Eid;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EName", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Ename;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EAdd", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = eadd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ESex", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = esex;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EJob", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = ejob;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ESal", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = esal;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@BasicSal", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = basicSal;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PF", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = PF;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EBirthDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = birthDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EPhNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = phno;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = photo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@signPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = sign;
            cmd.Parameters.Add(param);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (DataException err)
            {
                MessageBox.Show("Exception occur as   " + err);
            }
        }

        public void updateFixedDeposite(long FDID, long AccNo, decimal amt, decimal intRate, DateTime dateFrom, DateTime dateTo, decimal duration, decimal amtAfter)
        {
            string sp_name = "prosUpdateFixedDeposite";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@FD_Id", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = FDID;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = AccNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Amt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = amt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Interest_Rate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = intRate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Date_From", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = dateFrom;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Date_To", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = dateTo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@duration", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = duration;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@amtAfterDue", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = amtAfter;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();

        }
        public void updateLoanTransaction(long accNo, decimal balance, string transactionWay, decimal emi, decimal intRate, string loanType, long transactionNo)
        {
            string sp_name = "prosUpdateLoanTransaction";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@AccNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Balance", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = balance;
            cmd.Parameters.Add(param);

            param = new SqlParameter("TransactionWay", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transactionWay;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EMI", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = emi;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@intRate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = intRate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LoanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@transaction_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = transactionNo;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();
        }

        public void updateChequeBook(int Acc_no, String Name, int Qty, long noFrom, long noTO)
        {
            string sp_name = "prosUpdateChqueBook";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_Id", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Acc_no;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Name;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Quantity", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = Qty;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Chq_No_From", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = noFrom;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Chq_No_To", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = noTO;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }



        public void updateGuarantor(long accNo, string gname, DateTime gbirthdate, string resAdd, string offAdd,
            long phno, string occup, byte[] photo, byte[] sign, long appNo)
        {
            string sp_name = "prosUpdateGuarantor";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@App_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@GName", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = gname;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Birthdate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = gbirthdate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Res_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = resAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Off_Add", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = offAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Phone_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = phno;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Occupation", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = occup;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@PhotoPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = photo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@SignPath", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = sign;
            cmd.Parameters.Add(param);


            cmd.ExecuteNonQuery();
        }

        public void updateHomeVehicale(long accNo, string TargetAddress, decimal saving, decimal providentAmt, decimal immovableAmt, long LicNo, decimal LicAmt, DateTime LicMatuDate, DateTime appdate,
            decimal LoanAmt, decimal IntRate, decimal emi, string loanType, decimal salary, long NoOfInstalment, long appNo)
        {
            string sp_name = "prosUpdateHomeVehicale";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TargetPro", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = TargetAddress;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Saving", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = saving;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@ProvidentAmt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = providentAmt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@immovable", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = immovableAmt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LIC_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = LicNo;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LICAmt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = LicAmt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LICMatuDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = LicMatuDate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@AppDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appdate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LoanAmt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = LoanAmt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@IntRate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = IntRate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@EMI", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = emi;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@LoanType", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanType;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@salary", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = salary;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NoOfInstallment", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = NoOfInstalment;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@app_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appNo;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }






        public void updateStudent(long accNo, string passExam, DateTime passYear, decimal passMark, string division, string otherSchol,
            string praposedCourse, decimal duration, string collegeName, string collegeAdd, decimal loanAmt, decimal rate, decimal emi, decimal totalFess, DateTime appDate, decimal salary, long NoOfInstalment, long appNO)
        {
            string sp_name = "prosUpdateStudent";
            SqlCommand cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@Acc_No", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = accNo;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@passedExam", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = passExam;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@passedYear", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = passYear;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@passedMarks", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = passMark;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@division", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = division;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@otherScholar", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = otherSchol;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@praposedCourse", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = praposedCourse;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@duration", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = duration;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@collegeName", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = collegeName;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@collegeAdd", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = collegeAdd;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@loanAmt", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = loanAmt;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Rate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = rate;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@emi", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = emi;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@TotalFess", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = totalFess;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@salary", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = salary;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@NoOfInstallment", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = NoOfInstalment;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@appDate", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appDate;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@appNo", DbType.String);
            param.Direction = ParameterDirection.Input;
            param.Value = appNO;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();

        }
    }
}
