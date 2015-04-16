using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data;
namespace Clay.RAD
{
  public  class Billingsale
    {
      public DataSet GetBillingDashBoard(string _month, string _year, string type)
      {
          using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
          {
              DataSet dsDataSet = new DataSet();
              dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
              string[] strDataTableName = { "country","Billing" };
              SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
              objSpParameters.Add("_month", DbType.String, _month, ParameterDirection.Input);
              objSpParameters.Add("_year", DbType.String, _year, ParameterDirection.Input);
              objSpParameters.Add("_type", DbType.String, type, ParameterDirection.Input);
              objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_countrywisedashboard", dsDataSet, strDataTableName, objSpParameters);
              //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
              if (dsDataSet != null)
                  return dsDataSet;
              return null;
          }
      }

      public DataSet GetSaleDetails(string _month, string _year, string country)
      {
          using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
          {
              DataSet dsDataSet = new DataSet();
              dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
              string[] strDataTableName = { "sale" };
              SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
              objSpParameters.Add("_month", DbType.String, _month, ParameterDirection.Input);
              objSpParameters.Add("_year", DbType.String, _year, ParameterDirection.Input);
              objSpParameters.Add("_country", DbType.String, country, ParameterDirection.Input);
              objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "get_sales_details_by_country", dsDataSet, strDataTableName, objSpParameters);
              //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
              if (dsDataSet != null)
                  return dsDataSet;
              return null;
          }
      }

      public DataSet GetCallType(int _month, int _year, int country)
      {
          using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
          {
              DataSet dsDataSet = new DataSet();
              dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
              string[] strDataTableName = { "calltype" };
              SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
              objSpParameters.Add("lmonth", DbType.Int32, _month, ParameterDirection.Input);
              objSpParameters.Add("lyear", DbType.Int32, _year, ParameterDirection.Input);
              objSpParameters.Add("lcountryid", DbType.Int32, country, ParameterDirection.Input);
              objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_calltype", dsDataSet, strDataTableName, objSpParameters);
              //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
              if (dsDataSet != null)
                  return dsDataSet;
              return null;
          }
      }
    }
}
