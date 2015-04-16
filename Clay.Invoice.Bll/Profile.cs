using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class Profile
    {
        #region Private Variables

        private int _UserID = 0;
        private string _Password = string.Empty;

        #endregion



        #region Public Properties

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion

        public DataSet CheckOldPassword()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _UserID, ParameterDirection.Input);
                objSpParameters.Add("cpassword", DbType.String, _Password, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_password_check",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet ChangePassword()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _UserID, ParameterDirection.Input);
                objSpParameters.Add("cpassword", DbType.String, _Password, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_password_change",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
    }
}
