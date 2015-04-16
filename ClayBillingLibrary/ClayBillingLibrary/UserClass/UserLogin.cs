using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DalClayBilling;
using System.Data;
namespace ClayBillingLibrary.UserClass
{
    public  class UserLogin
    {
        private string _uesrName;

        public string UesrName
        {
          get { return _uesrName; }
          set { _uesrName = value; }
        }
        private string _userPassword;

        public string UserPassword
        {
          get { return _userPassword; }
          set { _userPassword = value; }
        }
        private string _ipAddress;

        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        private string _sessionid;

        public string Sessionid
        {
            get { return _sessionid; }
            set { _sessionid = value; }
        }

        private int _otpCode;

        public int OtpCode
        {
            get { return _otpCode; }
            set { _otpCode = value; }
        }

        private int _senton;

        //1-SMS,2-Email
        public int Senton
        {
            get { return _senton; }
            set { _senton = value; }
        }
        List<Module> _modules = new List<Module>();

        public List<Module> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }

        List<Menu> _menus = new List<Menu>();

        public List<Menu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        public DataSet checkUserAuthentication()
        {
            CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "userlogin" };
            objSpParameter.Add("username", DbType.String, UesrName, ParameterDirection.Input);
            objSpParameter.Add("upassword", DbType.String, UserPassword, ParameterDirection.Input);
            objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "user_logindetails", ds, TableName, objSpParameter);

            return ds;
        }

        public int CheckPassword(int userId, string oldpassword)
        {
            CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "userlogin" };
            objSpParameter.Add("luserid", DbType.Int32, userId, ParameterDirection.Input);
            objSpParameter.Add("cpassword", DbType.String, oldpassword, ParameterDirection.Input);
            objSpParameter.Add("rcode", DbType.Boolean, 0, ParameterDirection.Output);
            objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "Checkuserpassword", objSpParameter);
            object objVal = objSpParameter.GetOutputParamValue("rcode");
            int rval = Convert.ToInt32(objVal);
            return rval;   
        }

        public int ChangePassword(int userId, string newpassword)
        {
            CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "userlogin" };
            objSpParameter.Add("luserid", DbType.Int32, userId, ParameterDirection.Input);
            objSpParameter.Add("cpassword", DbType.String, newpassword, ParameterDirection.Input);
            objSpParameter.Add("rcode", DbType.Boolean, 0, ParameterDirection.Output);
            objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "Changeuserpassword", objSpParameter);
            object objVal = objSpParameter.GetOutputParamValue("rcode");
            int rval = Convert.ToInt32(objVal);
            return rval;
        }

        //public DataSet LoginvalidOrInvalid()
        //{
        //    CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection");
        //    SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
        //    DataSet ds = new DataSet();
        //    string[] TableName = { "userlogin", "module", "menu" };
        //    objSpParameter.Add("username", DbType.String, UesrName, ParameterDirection.Input);
        //    objSpParameter.Add("upassword", DbType.String, UserPassword, ParameterDirection.Input);
        //    //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Checkuservalidorinvalid", ds, TableName, objSpParameter);
        //    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Checkuservalidorinvalid_withmenu", ds, TableName, objSpParameter);
        //    foreach (DataRow dr in ds.Tables["module"].Rows)
        //    {
        //        this.Modules.Add(new Module { ModuleId = Convert.ToInt32(dr["moduleid"]), ModuleName = dr["description"].ToString() });
        //    }

        //    ////fetch & fill menu
        //    foreach (DataRow dr in ds.Tables["menu"].Rows)
        //    {

        //        this.Menus.Add(new Menu { MenuId = Convert.ToInt32(dr["menuid"]), MenuText = dr["menutext"].ToString(), ParentId = Convert.ToInt32(dr["parentid"]), ModuleId = Convert.ToInt32(dr["moduleid"]), Url = Convert.ToString(dr["url"]) });
        //    }
        //    return ds;
        //}

        public DataSet LoginvalidOrInvalid()
        {
            CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "userlogin" };
            objSpParameter.Add("username", DbType.String, UesrName, ParameterDirection.Input);
            objSpParameter.Add("upassword", DbType.String, UserPassword, ParameterDirection.Input);
            objSpParameter.Add("_sessionid", DbType.String, _sessionid, ParameterDirection.Input);
            objSpParameter.Add("_ipaddress", DbType.String, _ipAddress, ParameterDirection.Input);
            objSpParameter.Add("_otpcode", DbType.Int32, _otpCode, ParameterDirection.Input);
            objSpParameter.Add("_senton", DbType.Int32, _senton, ParameterDirection.Input);

            objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Checkuservalidorinvalid_otp", ds, TableName, objSpParameter);// Checkuservalidorinvalid
            return ds;
        }

        public int Update_OTP_Code_Sent(int LogID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
                objSpParameter.Add("_logid", DbType.Int32, LogID, ParameterDirection.Input);

                return objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "claymis_otp_update", objSpParameter);
            }
        }

        public int ValidateOTP(int LogID, int OTPCode)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
                objSpParameter.Add("_logid", DbType.Int32, LogID, ParameterDirection.Input);
                objSpParameter.Add("_otpcode", DbType.Int32, OTPCode, ParameterDirection.Input);
                objSpParameter.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                return objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "claymis_otp_validate", objSpParameter);
            }
        }

        public int LogOut(int LogID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameter = new SpParameters(RdbmsType.MySql);
                objSpParameter.Add("_logid", DbType.Int32, LogID, ParameterDirection.Input);

                return objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "claymis_logout", objSpParameter);
            }
        }
    }
}
