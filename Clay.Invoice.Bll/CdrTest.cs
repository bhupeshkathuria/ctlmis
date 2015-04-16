using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class CdrTest
    {
        #region Private Variables

        private int _cdrtestId = 0;
        private int _countryId = 0;
        private int _providerId = 0;
        private int _cdrguideId = 0;
        private string _cfilename = string.Empty;
        private string _cip = string.Empty;
        private string _md5 = string.Empty;
        private int _rows = 0;
        private int _userid = 0;
        private string _ipaddress = string.Empty;
        private DateTime _dt;
        //Start by Mithilesh


        private int _cdrchargeid = 0;
        private int _Year = 0;
        private int _Month = 0;

        //End By Mithilesh

        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public string IPaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        public int CdrTestID
        {
            get { return _cdrtestId; }
            set { _cdrtestId = value; }
        }

        public int CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        public int ProviderId
        {
            get { return _providerId; }
            set { _providerId = value; }
        }

        public int CdrGuideId
        {
            get { return _cdrguideId; }
            set { _cdrguideId = value; }
        }

        public string CFileName
        {
            get { return _cfilename; }
            set { _cfilename = value; }
        }

        public string Ip
        {
            get { return _cip; }
            set { _cip = value; }
        }

        public string MD5
        {
            get { return _md5; }
            set { _md5 = value; }
        }

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }


        // Start Mithilesh



        public DateTime Selectdate
        {
            get { return _dt; }
            set { _dt = value; }
        }

        public int CdrChargeID
        {
            get { return _cdrchargeid; }
            set { _cdrchargeid = value; }
        }

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }



        // End Mithilesh
        #endregion

        #region Public Methods

        public int CdrTestInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideId, ParameterDirection.Input);
                objSpParameters.Add("ccdrfilename", DbType.String, _cfilename, ParameterDirection.Input);
                objSpParameters.Add("cip", DbType.String, _cip, ParameterDirection.Input);
                objSpParameters.Add("ccdrmd5", DbType.String, _md5, ParameterDirection.Input);
                objSpParameters.Add("lrows", DbType.Int32, _rows, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipaddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_cdrtest_insert", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public DataSet GetCdrTestByCdrMD5()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ccdrmd5", DbType.String, _md5, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrtest_select_bymd5", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SetCdrTestStatus()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.String, _cdrtestId, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipaddress, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrtest_update_status", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrDetailsForRollback()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objSpParameters.Add("cfilename", DbType.String, _cfilename, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdr_details_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SetCdrProcessStatus()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.String, _cdrtestId, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipaddress, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrtest_update_process_status", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int RollbackUnProcessData()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrtestid", DbType.Int32, _cdrtestId, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipaddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_rollback_unprocess_data", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }
        public int RollbackProcessData()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrtestid", DbType.Int32, _cdrtestId, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipaddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_rollback_process_data", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public DataSet SelectCdrTestByID()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.String, _cdrtestId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrtest_select_byid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet CountCDRTestByMD5()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ccdrmd5", DbType.String, _md5, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrtest_count_bymd5", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetTodayImportedCdrs(DateTime dt)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ddatetime", DbType.DateTime, dt, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_imported_cdr", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetTodayProcessedCdrs(DateTime dt)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ddatetime", DbType.DateTime, dt, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_processed_cdr", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SelectCdrDetailsByCdrTestID()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.Int32, _cdrtestId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrdetails_select_by_cdrtestid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet SelectCdrDetailsByCdrTestIDProcessOnly()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.Int32, _cdrtestId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrdetails_select_by_cdrtestid_process_only", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }




        //Start by Mithilesh
        public DataSet GetUnbilledInvoice()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "rollbackunbilledmain" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("seldate", DbType.DateTime, _dt, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_Unbilled_cdr", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }



        public DataSet SelectunbilledInvByID(Int32 _id)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("rbuid", DbType.String, _id, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sp_Select_UnbilledInv", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetInvDetails()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("seldate", DbType.DateTime, _dt, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_inv", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }






        //////////////////////////////------------------*************----------------------//////////////////////



        public DataSet GetRecentImportedCdrs()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_recent_imported_cdr", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }






        public DataSet GetRecentProcessedCdrs()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_seelct_recent_processed_cdr", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetUnbilledInvoicebycntidyrmnth()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "rollbackunbilledmain" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sp_select_Unbilled_invoicebycntidyrmnth", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetInvDetailsbycntidyrmnth()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_invbycntidyrmnth", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }



        public DataSet GetTodayImportedCdrsbycntidyrmnth()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_imported_cdrbycntidyrmnth", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }



        public DataSet GetTodayProcessedCdrsbycntidyrmnth()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrtest" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lCountryID", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lYear", DbType.Int32, _Year, ParameterDirection.Input);
                objSpParameters.Add("lMonth", DbType.Int32, _Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_today_processed_cdrbycntidyrmnth", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        //////////////////////////////------------------*************----------------------//////////////////////





        //End Mithilesh
        #endregion
    }
}
