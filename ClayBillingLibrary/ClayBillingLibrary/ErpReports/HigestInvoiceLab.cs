using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DalClayBilling;
using System.Data;
namespace ClayBillingLibrary.ErpReports
{
    public class HigestInvoiceLab
    {
        public DataSet GetHigestInvoiceDetails(int CountryId, int Year, int Month, int CallTypeId, int limitvalue)
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "InvoiceDetails" };
            ObjSpParameter.Add("lcountryId", DbType.Int32, CountryId, ParameterDirection.Input);
            ObjSpParameter.Add("lyearid", DbType.Int32, Year, ParameterDirection.Input);
            ObjSpParameter.Add("lmonthid", DbType.Int32, Month, ParameterDirection.Input);
            ObjSpParameter.Add("lcalltypeid", DbType.Int32, CallTypeId, ParameterDirection.Input);
            ObjSpParameter.Add("setlimitvalue", DbType.Int32, limitvalue, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_erp_get_higest_invoice_details", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetCountry()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "Country"};
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_erp_get_country", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetCallType(int CountryId)
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = {"CallType" };
            ObjSpParameter.Add("lcountryId", DbType.Int32, CountryId, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_erp_get_calltype_based_countryid", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetCRDPricingDetails(int CountryId, int Year, int Month)
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "InvoiceDetails" };
            ObjSpParameter.Add("lcountryId", DbType.Int32, CountryId, ParameterDirection.Input);
            ObjSpParameter.Add("lyearid", DbType.Int32, Year, ParameterDirection.Input);
            ObjSpParameter.Add("lmonthid", DbType.Int32, Month, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_erp_get_cdrpricing_details", ds, TableName, ObjSpParameter);
            return ds;
        }
    }
}
