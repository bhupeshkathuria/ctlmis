using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dal;

namespace Clay.Invoice.Bll
{
    public class Query
    {
        
            #region Private Variables

            private int _countryId = 0;
            private int _providerId = 0;
            private string _cdruserquery = string.Empty;
            private string _cdrdbquery = string.Empty;
            private string _createdip = string.Empty;
            private int _calltypeid = 0;
            private string _query = string.Empty;
            private Boolean _applychargetozeroduration = false;
            private string _tableToUpdate = string.Empty;
            private int _sequence = 0;
            private int _checkcalltypezero = 0;

            #endregion



            #region Public Properties

            public int CheckCallTypeZero
            {
                get { return _checkcalltypezero; }
                set { _checkcalltypezero = value; }
            }

            public int Sequence
            {
                get { return _sequence; }
                set { _sequence = value; }
            }

            public string TableToUpdate
            {
                get { return _tableToUpdate; }
                set { _tableToUpdate = value; }
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

            public string CdrUserQuery
            {
                get { return _cdruserquery; }
                set { _cdruserquery = value; }
            }

            public string CdrDbQuery
            {
                get { return _cdrdbquery; }
                set { _cdrdbquery = value; }
            }

            public int CallTypeId
            {
                get { return _calltypeid; }
                set { _calltypeid = value; }
            }

            public string CreatedIp
            {
                get { return _createdip; }
                set { _createdip = value; }
            }

            public string CQuery
            {
                get { return _query; }
                set { _query = value; }
            }

            public Boolean ApplyChargeToZeroDuration
            {
                get { return _applychargetozeroduration; }
                set { _applychargetozeroduration = value; }
            }

            #endregion



            #region Public Methods

            public object RunInsertQuery()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                    objSpParameters.Add("cquery", DbType.String, _query, ParameterDirection.Input);
                    object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_query", objSpParameters);
                    return value;
                }
            }

            public object RunMultipleInsertQuery()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                    //objSpParameters.Add("cquery", DbType.String, _query, ParameterDirection.Input);
                    object value = objCommandExecutor.ExecuteDBQuery1(CommandType.Text, _query, objSpParameters);
                    return value;
                }
            }

            public DataSet RunSelectQuery()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {

                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "query" };
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("cquery", DbType.String, _query, ParameterDirection.Input);
                    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_query", dsDataSet, strDataTableName, objSpParameters);
                    if (dsDataSet != null)
                        return dsDataSet;

                    return null;
                }
            }

            public DataSet RunSelectQueryDB(string DBName)
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor(DBName))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "query" };
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("cquery", DbType.String, _query, ParameterDirection.Input);
                    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_query", dsDataSet, strDataTableName, objSpParameters);
                    if (dsDataSet != null)
                        return dsDataSet;
                    return null;
                }
            }

            public DataSet RunSelectQueryDBDirect(string DBName, string myQuery)
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor(DBName))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "query" };
                    objCommandExecutor.ExecuteDataSet(CommandType.Text, myQuery, dsDataSet, strDataTableName);
                    if (dsDataSet != null)
                        return dsDataSet;
                    return null;
                }
            }

            public DataSet RunSelectQueryDBDirect(string DBName, string myQuery, string[] tables)
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor(DBName))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName = tables;
                    objCommandExecutor.ExecuteDataSet(CommandType.Text, myQuery, dsDataSet, strDataTableName);
                    if (dsDataSet != null)
                        return dsDataSet;
                    return null;
                }
            }

            public object RunSelectQueryDBDirect2(string DBName, string myQuery)
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor(DBName))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "query" };
                    //objCommandExecutor.ExecuteDataSet(CommandType.Text, myQuery, dsDataSet, strDataTableName);
                    //if (dsDataSet != null)
                    //    return dsDataSet;
                    //return null;
                    object value = objCommandExecutor.ExecuteDBQuery1(CommandType.Text, myQuery, null);
                    return value;
                }
            }
            /// <summary>
            /// method for save the query created by deepak rohilla on 15-07-2010
            /// </summary>
            /// <returns></returns>
            public object CdrGuideQueryInsert()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                    objSpParameters.Add("lprovider_id", DbType.Int32, _providerId, ParameterDirection.Input);
                    objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                    objSpParameters.Add("ccdruserquery", DbType.String, _cdruserquery, ParameterDirection.Input);
                    objSpParameters.Add("ccdrdbquery", DbType.String, _cdrdbquery, ParameterDirection.Input);
                    objSpParameters.Add("lcalltypeid", DbType.Int32, _calltypeid, ParameterDirection.Input);
                    objSpParameters.Add("ccreatedip", DbType.String, _createdip, ParameterDirection.Input);
                    objSpParameters.Add("ctabletoupdate", DbType.String, _tableToUpdate, ParameterDirection.Input);
                    objSpParameters.Add("lsequence", DbType.Int32, _sequence, ParameterDirection.Input);
                    objSpParameters.Add("lcheckcalltypezero", DbType.Int32, _checkcalltypezero, ParameterDirection.Input);
                    objSpParameters.Add("capplychargetozeroduration", DbType.Boolean, _applychargetozeroduration, ParameterDirection.Input);
                    object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_cdrguidequery_insert2", objSpParameters);
                    return value;
                }
            }

            public DataSet GetCdrQuery()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "provider" };
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrquery_select", dsDataSet, strDataTableName, objSpParameters);

                    if (dsDataSet != null)
                        return dsDataSet;

                    return null;
                }
            }

            public DataSet GetCdrQueryByCountryIDAndProviderID()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "provider" };
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                    objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrquery_select_by_countryid_providerid", dsDataSet, strDataTableName, objSpParameters);

                    if (dsDataSet != null)
                        return dsDataSet;

                    return null;
                }
            }

            /// <summary>
            /// created by deepak rohilla for delete the query
            /// </summary>
            /// <returns></returns>
            public object CdrGuideQueryDelete()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                    objSpParameters.Add("lprovider_id", DbType.Int32, _providerId, ParameterDirection.Input);
                    objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                    objSpParameters.Add("ccdruserquery", DbType.String, _cdruserquery, ParameterDirection.Input);
                    objSpParameters.Add("ccdrdbquery", DbType.String, _cdrdbquery, ParameterDirection.Input);
                    objSpParameters.Add("lcalltypeid", DbType.Int32, _calltypeid, ParameterDirection.Input);
                    objSpParameters.Add("ccreatedip", DbType.String, _createdip, ParameterDirection.Input);
                    object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_cdrguidequerydelete_insert", objSpParameters);
                    return value;
                }
            }
            /// <summary>
            /// function created by deepak rohilla on 04-aug-2010 for select the deleted cdr query
            /// </summary>
            /// <returns></returns>
            public DataSet GetCdrQueryDelete()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    DataSet dsDataSet = new DataSet();
                    dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    string[] strDataTableName ={ "provider" };
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                    objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_deletecdrquery_select", dsDataSet, strDataTableName, objSpParameters);

                    if (dsDataSet != null)
                        return dsDataSet;

                    return null;
                }
            }

            /// <summary>
            /// function created by Navneet on 08-09-2010 to run a direct insert query
            /// </summary>
            /// <returns>
            /// last insert id
            /// </returns>
            public int RunInsertQuerySingle()
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                    objSpParameters.Add("cquery", DbType.AnsiString, _query, ParameterDirection.Input);
                    objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                    int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_query_insert", objSpParameters);
                    return value;
                }
            }

            #endregion
        }
    }

