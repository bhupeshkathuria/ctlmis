using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;
namespace Clay.Invoice.Bll
{
    public class GprsField
    {

        #region Private Variables
        private int _cdrgprsfielddetailsid = 0;
        private int _cdrguideId = 0;
        private int _datafieldid = 0;
        private int _gprsfieldid = 0;
        private int _isdurationanddatafildsame = 0;
        private string _ValueField = string.Empty;
        #endregion

        #region Public Properties

        public string ValueField
        {
            get { return _ValueField; }
            set { _ValueField = value; }
        }

        public int CdrGprsFieldDetailid
        {
            get { return _cdrgprsfielddetailsid; }
            set { _cdrgprsfielddetailsid = value; }
        }

        public int CdrGuideId
        {
            get { return _cdrguideId; }
            set { _cdrguideId = value; }
        }

        public int DataFieldID
        {
            get { return _datafieldid; }
            set { _datafieldid = value; }
        }

        public int GprsFieldID
        {
            get { return _gprsfieldid; }
            set { _gprsfieldid = value; }
        }

        public int DurationField
        {
            get { return _isdurationanddatafildsame; }
            set { _isdurationanddatafildsame = value; }
        }

        #endregion

        public DataSet GetGPRSField()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "zone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrgprsfieldid", DbType.Int32, _cdrgprsfielddetailsid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_gprs_field_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetGPRSFieldDetail()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "zone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrgprsfieldid", DbType.Int32, _cdrgprsfielddetailsid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_gprsfielddetail_by_gprsfieldid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int NewGPRSField()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideId, ParameterDirection.Input);
                objSpParameters.Add("ldatafieldid", DbType.Int32, _datafieldid, ParameterDirection.Input);
                objSpParameters.Add("lgprsfieldid", DbType.Int32, _gprsfieldid, ParameterDirection.Input);
                objSpParameters.Add("lisdurationanddatafildsame", DbType.Int32, _isdurationanddatafildsame, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_gprs_field", objSpParameters);
                return value;
            }
        }

        public int NewGPRSFieldDetails()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrgprsfieldid", DbType.Int32, _cdrgprsfielddetailsid, ParameterDirection.Input);
                objSpParameters.Add("cvalue", DbType.String, _ValueField, ParameterDirection.Input);
               
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_gprsfield_details", objSpParameters);
                return value;
            }
        }
    }
}
