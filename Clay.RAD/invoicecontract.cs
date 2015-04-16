using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data;
namespace Clay.RAD
{
    public class invoicecontract
    {
        public int InvoiceContractInsert_update(int countryid, int providerid, int userid, string ipaddress, DateTime startdate, DateTime enddate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, providerid, ParameterDirection.Input);

                objSpParameters.Add("luserid", DbType.Int32, userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, ipaddress, ParameterDirection.Input);
                objSpParameters.Add("dstartdate", DbType.Date, startdate, ParameterDirection.Input);
                objSpParameters.Add("denddate", DbType.Date, enddate, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int retValue = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "invrev_insert_invcontract_new", objSpParameters);
                return retValue;

            }
        }

        public int InvoicecontractDetailInsert_update(int contractid, int calltypeid, double cost, int userid, string ipaddress, int _unitid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcontractid", DbType.Int32, contractid, ParameterDirection.Input);
                objSpParameters.Add("lcalltypeid", DbType.Int32, calltypeid, ParameterDirection.Input);
                objSpParameters.Add("docost", DbType.Double, cost, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, userid, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, ipaddress, ParameterDirection.Input);
                objSpParameters.Add("lunitid", DbType.Int32, _unitid, ParameterDirection.Input);

                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int retValue = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "invrev_insert_invcontractdetail", objSpParameters);
                return retValue;

            }
        }
        public DataSet CDRContractrpt(int countryid, int providerid, string startdate, string enddate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "calltype" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("_countryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("_providerid", DbType.Int32, providerid, ParameterDirection.Input);
                objSpParameters.Add("fromdate", DbType.String, startdate, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.String, enddate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_CDRReport_Contract2", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet CDRContractrptRetail(int countryid, int providerid, string startdate, string enddate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "calltype" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("_countryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("_providerid", DbType.Int32, providerid, ParameterDirection.Input);
                objSpParameters.Add("fromdate", DbType.String, startdate, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.String, enddate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_CDRReport_Contract_retail", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet CDRContractrptWhs(int countryid, int providerid, string startdate, string enddate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "calltype" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("_countryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("_providerid", DbType.Int32, providerid, ParameterDirection.Input);
                objSpParameters.Add("fromdate", DbType.String, startdate, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.String, enddate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_CDRReport_Contract_whs", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet GetcontractCDRsubreport(int calltypeid, string billingMonthfrom, string billingMonthto, int countryid, int providerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "Head" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("calltype", DbType.Int32, calltypeid, ParameterDirection.Input);
                objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
                objSpParameters.Add("_countryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("_providerid", DbType.Int32, providerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_CDRReport_Contract_subrpt",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

    }
}
