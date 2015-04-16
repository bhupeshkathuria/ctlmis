using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Sale.Bll
{
   public class CreditDetail
    {
       public DataSet Get_Daily_Credit_Report_Branch(string fromdate, string todate)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName ={ "branch","cheque","cash","cc","bank","online","None" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cfromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("ctodate", DbType.String, todate, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getcredit_dailyreport_bybranch", dsDataSet, strDataTableName, objSpParameters);
              // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getcredit_dailyreport_bybranch_2", dsDataSet, strDataTableName, objSpParameters);
               
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Daily_Credit_Report_Branch_new(string fromdate, string todate,int branchID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "branch"};
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cfromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("ctodate", DbType.String, todate, ParameterDirection.Input);
               objSpParameters.Add("lbranchid", DbType.Int32, branchID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getcredit_dailyreport_bybranch_new", dsDataSet, strDataTableName, objSpParameters);
               // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getcredit_dailyreport_bybranch_2", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Daily_Credit_Report_Customer(string fromdate, string todate)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName ={ "branch" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cfromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("ctodate", DbType.String, todate, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_get_daily_report_by_customer", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Monthly_Report(string fromdate, string todate)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName ={ "branch","report" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cfromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("ctodate", DbType.String, todate, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_monthly_repot", dsDataSet, strDataTableName, objSpParameters);
             //  objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_monthly_repot_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetMonthlyOutstanding(string cur_month, string cur_year, string prev_month, string yest_date)
       {
           CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt");
           SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
           DataSet DS = new DataSet();
           string[] TableName = { "emp","outstanding" };
           objSpParameters.Add("cur_month", DbType.String, cur_month, ParameterDirection.Input);
           objSpParameters.Add("cur_year", DbType.String, cur_year, ParameterDirection.Input);
           objSpParameters.Add("last_month", DbType.String, prev_month, ParameterDirection.Input);
           objSpParameters.Add("yestr_date", DbType.String, yest_date, ParameterDirection.Input);
           objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getmonthly_outstanding", DS, TableName, objSpParameters);
           // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getmonthly_outstanding_old", DS, TableName, objSpParameters);
           return DS;
       }

       public DataSet GetMonthly_report_by_branch(string _fromdate, string _todate)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName ={ "branch", "report" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cfromdate", DbType.String, _fromdate, ParameterDirection.Input);
               objSpParameters.Add("ctodate", DbType.String, _todate, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getmonthly_report_by_branch", dsDataSet, strDataTableName, objSpParameters);
               //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getmonthly_report_by_branch_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }

       public DataSet GetCollection_rpt_Monthly(string _month, string _year, string type)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "month"};
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_month", DbType.String, _month, ParameterDirection.Input);
               objSpParameters.Add("_year", DbType.String, _year, ParameterDirection.Input);
               objSpParameters.Add("_type", DbType.String, type, ParameterDirection.Input);
                 objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month", dsDataSet, strDataTableName, objSpParameters);  
               //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }

       public DataSet GetCollection_rpt_Monthly_New(string fromdate, string todate,string type)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "month" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_fromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("_todate", DbType.String, todate, ParameterDirection.Input);
               objSpParameters.Add("_type", DbType.String, type, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
               //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rpt_collection_month_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }


       public DataSet Getdaywise_rpt(string _month, string _year, string branchid,string paymentmode)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "day" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_month", DbType.String, _month, ParameterDirection.Input);
               objSpParameters.Add("_year", DbType.String, _year, ParameterDirection.Input);
               objSpParameters.Add("_paymode", DbType.String, paymentmode, ParameterDirection.Input);
               objSpParameters.Add("branchid", DbType.String, branchid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getdaywise_report", dsDataSet, strDataTableName, objSpParameters);
              // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getdaywise_report_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }
       public DataSet Getdsr_rpt(string _month, string _year, int branchid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "new","old","totalnew","totalold","followupnew","followupold","totalfolNew","totalfolOld" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_month", DbType.String, _month, ParameterDirection.Input);
               objSpParameters.Add("_year", DbType.String, _year, ParameterDirection.Input);

               objSpParameters.Add("_branchid", DbType.String, branchid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rptc_get_dsr_report_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
               /* rptc_get_dsr_report*/
           }
       }
       public DataSet Gettransaction_detail(string _fromdate, string _todate, int branchid, string paymentmode)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "transaction" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_fromdate", DbType.String, _fromdate, ParameterDirection.Input);
               objSpParameters.Add("_todate", DbType.String, _todate, ParameterDirection.Input);
               objSpParameters.Add("_mode", DbType.String, paymentmode, ParameterDirection.Input);
               objSpParameters.Add("_branchid", DbType.Int32, branchid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_get_detailtransaction", dsDataSet, strDataTableName, objSpParameters); 
               //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_get_detailtransaction_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }

       public DataSet GetARPUReport(string cmonth, string cyear, int reptype,string _field)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Billing", "table2" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cyear", DbType.String, cyear, ParameterDirection.Input);
               objSpParameters.Add("cmonth", DbType.String, cmonth, ParameterDirection.Input);
               objSpParameters.Add("lreptype", DbType.Int32, reptype, ParameterDirection.Input);
               objSpParameters.Add("_field", DbType.String, _field, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rptl_sp_arpu_report", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetARPUReportNew(string cmonth, string cyear, int reptype, string _field)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Billing", "table2" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cyear", DbType.String, cyear, ParameterDirection.Input);
               objSpParameters.Add("cmonth", DbType.String, cmonth, ParameterDirection.Input);
               objSpParameters.Add("lreptype", DbType.Int32, reptype, ParameterDirection.Input);
               objSpParameters.Add("_field", DbType.String, _field, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_ARPU_Report_New_25nov", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetARPUDetailReport(string cmonth, string cyear, int reptype, string _field)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Billing", "table2" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("cyear", DbType.String, cyear, ParameterDirection.Input);
               objSpParameters.Add("cmonth", DbType.String, cmonth, ParameterDirection.Input);
               objSpParameters.Add("lreptype", DbType.Int32, reptype, ParameterDirection.Input);
               objSpParameters.Add("_field", DbType.String, _field, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_ARPU_Detail_Report", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetARPUReport_compare(string fromsaleyear, string fromsalemonth, string fromsalemonth2, string fromsaleyear2,
                                           string frombillyear, string frombillmonth, string frombillmonth2, string frombillyear2,
                                            string tosaleyear, string tosalemonth, string tosalemonth2, string tosaleyear2,
                                           string tobillyear, string tobillmonth, string tobillmonth2, string tobillyear2,
                                           string reptype, string _field)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "table1", "table2", "table3", "table4" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("fromsaleyear", DbType.String, fromsaleyear, ParameterDirection.Input);
               objSpParameters.Add("fromsalemonth", DbType.String, fromsalemonth, ParameterDirection.Input);
               objSpParameters.Add("fromsalemonth2", DbType.String, fromsalemonth2, ParameterDirection.Input);
               objSpParameters.Add("fromsaleyear2", DbType.String, fromsaleyear2, ParameterDirection.Input);

               objSpParameters.Add("frombillyear", DbType.String, frombillyear, ParameterDirection.Input);
               objSpParameters.Add("frombillmonth", DbType.String, frombillmonth, ParameterDirection.Input);
               objSpParameters.Add("frombillmonth2", DbType.String, frombillmonth2, ParameterDirection.Input);
               objSpParameters.Add("frombillyear2", DbType.String, frombillyear2, ParameterDirection.Input);

               objSpParameters.Add("tosaleyear", DbType.String, tosaleyear, ParameterDirection.Input);
               objSpParameters.Add("tosalemonth", DbType.String, tosalemonth, ParameterDirection.Input);
               objSpParameters.Add("tosalemonth2", DbType.String, tosalemonth2, ParameterDirection.Input);
               objSpParameters.Add("tosaleyear2", DbType.String, tosaleyear2, ParameterDirection.Input);

               objSpParameters.Add("tobillyear", DbType.String, tobillyear, ParameterDirection.Input);
               objSpParameters.Add("tobillmonth", DbType.String, tobillmonth, ParameterDirection.Input);
               objSpParameters.Add("tobillmonth2", DbType.String, tobillmonth2, ParameterDirection.Input);
               objSpParameters.Add("tobillyear2", DbType.String, tobillyear2, ParameterDirection.Input);


               objSpParameters.Add("lreptype", DbType.Int32, reptype, ParameterDirection.Input);
               objSpParameters.Add("_field", DbType.String, _field, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rptl_arpu_new", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Outstanding_Agging(int branchid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

               if (branchid == 0)
               {
                   string[] strDataTableName = { "branch", "outstanding1", "outstanding2", "outstanding3", "outstanding4" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging", dsDataSet, strDataTableName, objSpParameters);
               }
               else
               {
                   string[] strDataTableName = { "customerwise"};
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging", dsDataSet, strDataTableName, objSpParameters);
               }
               

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet Get_Outstanding_Agging_New(int branchid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

               if (branchid == 0)
               {
                   string[] strDataTableName = { "branch", "outstanding1", "outstanding2", "outstanding3", "outstanding4", "outstanding5", "outstanding6", "outstanding7", "outstanding8" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_new", dsDataSet, strDataTableName, objSpParameters);
               }
               else
               {
                   string[] strDataTableName = { "customerwise" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_new", dsDataSet, strDataTableName, objSpParameters);
               }


               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet Get_Outstanding_Agging_WthoutBranch()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

               
                   string[] strDataTableName = { "outstanding1" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_withoutbranch", dsDataSet, strDataTableName, objSpParameters);
               

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Outstanding_Agging_WthoutBranch_new()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;


               string[] strDataTableName = { "outstanding1" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_withoutbranch_new", dsDataSet, strDataTableName, objSpParameters);


               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Agging_customer_Detail(int branchid,int customerid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;               
                 string[] strDataTableName = { "customerDetail" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objSpParameters.Add("lcustomerid", DbType.Int32, customerid, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_customerwise", dsDataSet, strDataTableName, objSpParameters);
              


               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Agging_customer_Details_new(int branchid, int customerid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "customerDetail" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
               objSpParameters.Add("lcustomerid", DbType.Int32, customerid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_agging_customerwise_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_Collection_Agging_New(int branchid, int month, int year)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

               if (branchid == 0)
               {
                   //  string[] strDataTableName = { "branch", "outstanding1" };
                   string[] strDataTableName = { "outstanding1" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                   objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new1", dsDataSet, strDataTableName, objSpParameters);
                   // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new", dsDataSet, strDataTableName, objSpParameters);
               }
               else
               {
                   string[] strDataTableName = { "customerwise" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                   objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new1", dsDataSet, strDataTableName, objSpParameters);
                   // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new", dsDataSet, strDataTableName, objSpParameters);
               }

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet Get_Collection_Agging(int branchid,int month,int year)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

               if (branchid == 0)
               {
                 //  string[] strDataTableName = { "branch", "outstanding1" };
                   string[] strDataTableName = {"outstanding1" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                   objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3", dsDataSet, strDataTableName, objSpParameters);
                  // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new", dsDataSet, strDataTableName, objSpParameters);
               }
               else
               {
                   string[] strDataTableName = { "customerwise" };
                   SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                   objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                   objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                   objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3", dsDataSet, strDataTableName, objSpParameters);
                  // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_3_new", dsDataSet, strDataTableName, objSpParameters);
               }


               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet Get_collection_Agging_customer_Detail(int branchid, int customerid,int month,int year)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "customerDetail" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
               objSpParameters.Add("lcustomerid", DbType.Int32, customerid, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_customerwise", dsDataSet, strDataTableName, objSpParameters);
              // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_collection_agging_customerwise_new", dsDataSet, strDataTableName, objSpParameters);


               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetEmployeeByEmployeeId(int employeeID, int departmentId, int branchId, string employeeName)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "employee" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lemployeeid", DbType.Int32, employeeID, ParameterDirection.Input);
               objSpParameters.Add("ldepartmentid", DbType.Int32, departmentId, ParameterDirection.Input);
               objSpParameters.Add("lbranchid", DbType.Int32, branchId, ParameterDirection.Input);
               objSpParameters.Add("cemployeename", DbType.String, employeeName, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_employee_select_filter",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetCcTargetVsAchivementReport(string employeeId, int year, int frommonth, int tomonth)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ClayReceipt"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "TarVsAch" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lemployeeid", DbType.String, employeeId, ParameterDirection.Input);
               objSpParameters.Add("cyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("cfrommonth", DbType.Int32, frommonth, ParameterDirection.Input);
               objSpParameters.Add("ctomonth", DbType.Int32, tomonth, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_targetvsachievement_Cc", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetBillingAmountByMonthYear(int currentMonth, int currentYear, int PrvMonth, int PrvYear)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "BillCurrentMonth","BillPrvMonth" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lcurrentmonth", DbType.Int32, currentMonth, ParameterDirection.Input);
               objSpParameters.Add("lcurrentyear", DbType.Int32, currentYear, ParameterDirection.Input);
               objSpParameters.Add("lprvmonth", DbType.Int32, PrvMonth, ParameterDirection.Input);
               objSpParameters.Add("lprvyear", DbType.Int32, PrvYear, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "billing_amount_get", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptSalesBillingBranchAccountManagerWisewithsort(int yearFrom, int yearTo, int _strSaleBranch, int accmgrid, int salecategoryid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Branch", "salecategory", "sale", "Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strBranch", DbType.Int32, _strSaleBranch, ParameterDirection.Input);
               objSpParameters.Add("lemployemgrid", DbType.Int32, accmgrid, ParameterDirection.Input);
               objSpParameters.Add("lsalecategoryid", DbType.Int32, salecategoryid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_sale_billing_branch_accountmanager_wise_optnew", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetManagerByCategory(int SalesCategoryId)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "employee" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lsalecategoryid", DbType.Int32, SalesCategoryId, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_employee_select_sales_cre_new",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }



    }
}
