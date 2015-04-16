using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dal;
namespace Clay.Invoice.Bll
{
    public class CdrGuideHistory
    {
        #region Private Variables

        private string _ccdrguidequery = string.Empty;
        private string _cip = string.Empty;
        private int _cdrguideid = 0;

        #endregion



        #region Public Properties

        public int CdrGuideId
        {
            get { return _cdrguideid; }
            set { _cdrguideid = value; }
        }
        public string CdrGuideQuery
        {
            get { return _ccdrguidequery; }
            set { _ccdrguidequery = value; }
        }

        public string Ip
        {
            get { return _cip; }
            set { _cip = value; }
        }

        #endregion



        #region Public Methods

        public object NewCdrGuideHistoryRow()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("ccdrguidequery", DbType.String, _ccdrguidequery, ParameterDirection.Input);
                objSpParameters.Add("cip", DbType.String, _cip, ParameterDirection.Input);
                objSpParameters.Add("lcdrguideid", DbType.String, _cdrguideid, ParameterDirection.Input);
                object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_cdrguidehistory_insert", objSpParameters);
                return value;
            }
        }

        public DataSet GetCdrGuideHistoryByCdrGuideId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidehistory" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidehistory_select_bycdrguideid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        #endregion
    }
}
