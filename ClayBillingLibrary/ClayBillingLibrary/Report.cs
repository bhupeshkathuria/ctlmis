using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DalClayBilling;
namespace Clay.Invoice.Bll
{
   public class Report
    {

        public DataSet GetReportByMonthsale1(int month1, int year1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetMonth1 = new DataSet();
                dsDataSetMonth1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lmonth1", DbType.Int32, month1, ParameterDirection.Input);
                objSpParameters.Add("lyear1", DbType.Int32, year1, ParameterDirection.Input);

                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_month_Sale1", dsDataSetMonth1, strDataTableName, objSpParameters);

                if (dsDataSetMonth1 != null)
                    return dsDataSetMonth1;

                return null;
            }
        }
        public DataSet GetReportByMonthsale2(int month2, int year2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetMonth2 = new DataSet();
                dsDataSetMonth2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lmonth2", DbType.Int32, month2, ParameterDirection.Input);
                objSpParameters.Add("lyear2", DbType.Int32, year2, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_month_Sale2", dsDataSetMonth2, strDataTableName, objSpParameters);

                if (dsDataSetMonth2 != null)
                    return dsDataSetMonth2;

                return null;
            }
        }


        public DataSet GetReportByquartersale1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetquarter1 = new DataSet();

                dsDataSetquarter1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport" };

                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_quarter", dsDataSetquarter1, strDataTableName, objSpParameters);

                if (dsDataSetquarter1 != null)
                {
                    return dsDataSetquarter1;
                }

                return null;
            }
        }
        public DataSet GetReportByquartersale2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetquarter2 = new DataSet();

                dsDataSetquarter2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName1 = { "ByMonthReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_quarter2", dsDataSetquarter2, strDataTableName1, objSpParameters);

                if (dsDataSetquarter2 != null)
                {
                    return dsDataSetquarter2;
                }

                return null;
            }
        }

        public DataSet GetReportBySemiyearsale1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetSemi1 = new DataSet();
                dsDataSetSemi1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "BySemiReport" };

                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_semiyear1", dsDataSetSemi1, strDataTableName, objSpParameters);

                if (dsDataSetSemi1 != null)
                {
                    return dsDataSetSemi1;
                }

                return null;
            }
        }
        public DataSet GetReportBySemiyearsale2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetSemi2 = new DataSet();

                dsDataSetSemi2.Locale = System.Globalization.CultureInfo.InvariantCulture;

                string[] strDataTableName1 = { "BySemiReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_semiyear2", dsDataSetSemi2, strDataTableName1, objSpParameters);

                if (dsDataSetSemi2 != null)
                {
                    return dsDataSetSemi2;
                }

                return null;
            }
        }

        public DataSet GetReportByyearsale1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetyear1 = new DataSet();

                dsDataSetyear1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByYearReport" };

                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_year1", dsDataSetyear1, strDataTableName, objSpParameters);

                if (dsDataSetyear1 != null)
                {
                    return dsDataSetyear1;
                }

                return null;
            }
        }
        public DataSet GetReportByyearsale2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetyear2 = new DataSet();
                dsDataSetyear2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByYearReport" };
                string[] strDataTableName1 = { "ByYearReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_year2", dsDataSetyear2, strDataTableName1, objSpParameters);

                if (dsDataSetyear2 != null)
                {
                    return dsDataSetyear2;
                }

                return null;
            }
        }


        //Billing Methods
        public DataSet GetReportByMonthBilling1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetMonthBilling1 = new DataSet();
                dsDataSetMonthBilling1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_month_billing1", dsDataSetMonthBilling1, strDataTableName, objSpParameters);

                if (dsDataSetMonthBilling1 != null)

                    return dsDataSetMonthBilling1;

                return null;
            }
        }
        public DataSet GetReportByMonthBilling2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetMonthBilling2 = new DataSet();
                dsDataSetMonthBilling2.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport2" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_month_billing2", dsDataSetMonthBilling2, strDataTableName, objSpParameters);

                if (dsDataSetMonthBilling2 != null)

                    return dsDataSetMonthBilling2;

                return null;
            }
        }

        public DataSet GetReportByquarterBilling1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetquarterbilng1 = new DataSet();
                dsDataSetquarterbilng1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByMonthReport" };

                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_quarter_billing", dsDataSetquarterbilng1, strDataTableName, objSpParameters);



                if (dsDataSetquarterbilng1 != null)
                    return dsDataSetquarterbilng1;
                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]), 2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 = Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);

            }

            return null;
        }
        public DataSet GetReportByquarterBilling2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {

                DataSet dsdatasetquarterbilng2 = new DataSet();
                dsdatasetquarterbilng2.Locale = System.Globalization.CultureInfo.InvariantCulture;

                string[] strDataTableName1 = { "ByMonthReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_quarter_billing2", dsdatasetquarterbilng2, strDataTableName1, objSpParameters);

                if (dsdatasetquarterbilng2 != null)
                    return dsdatasetquarterbilng2;
                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]), 2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 = Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);

            }

            return null;
        }


        public DataSet GetReportBySemiyearBilling1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetSemibill1 = new DataSet();

                dsDataSetSemibill1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "BySemiReport" };

                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_semiyear_billing1", dsDataSetSemibill1, strDataTableName, objSpParameters);

                if (dsDataSetSemibill1 != null)
                    return dsDataSetSemibill1;

                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]), 2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 = Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);



                return null;
            }
        }
        public DataSet GetReportBySemiyearBilling2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetSemibill2 = new DataSet();

                dsDataSetSemibill2.Locale = System.Globalization.CultureInfo.InvariantCulture;

                string[] strDataTableName1 = { "BySemiReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_semiyear_billing2", dsDataSetSemibill2, strDataTableName1, objSpParameters);

                if (dsDataSetSemibill2 != null)
                    return dsDataSetSemibill2;

                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]), 2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 = Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);



                return null;
            }
        }

        public DataSet GetReportByyearBilling1(string fromdate1, string todate1, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetYearbill1 = new DataSet();
                dsDataSetYearbill1.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ByYearReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("fromdate1", DbType.String, fromdate1, ParameterDirection.Input);
                objSpParameters.Add("todate1", DbType.String, todate1, ParameterDirection.Input);
                objSpParameters.Add("lempid", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_year_billing1", dsDataSetYearbill1, strDataTableName, objSpParameters);

                if (dsDataSetYearbill1 != null)
                    return dsDataSetYearbill1;

                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]),2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 =Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);



                return null;
            }
        }


        public DataSet GetReportByyearBilling2(string fromdate2, string todate2, int managerid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSetyearbill2 = new DataSet();
                dsDataSetyearbill2.Locale = System.Globalization.CultureInfo.InvariantCulture;

                string[] strDataTableName1 = { "ByYearReport1" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate2", DbType.String, fromdate2, ParameterDirection.Input);
                objSpParameters.Add("todate2", DbType.String, todate2, ParameterDirection.Input);
                objSpParameters.Add("lempid2", DbType.Int32, managerid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sp_report_by_year_billing2", dsDataSetyearbill2, strDataTableName1, objSpParameters);

                if (dsDataSetyearbill2 != null)
                    return dsDataSetyearbill2;

                //decimal totalsale2 = Math.Round(Convert.ToDecimal(dsdataset2.Tables[0].Rows[i]["Totalsale2"]),2);
                //dsDataSet.Tables[0].Rows[i]["Totalsale2"] = totalsale2;
                //DateTime dt1 =Convert.ToDateTime(dsdataset2.Tables[0].Rows[i]["orddate2"]);
                //dsDataSet.Tables[0].Rows[i]["orddate2"] = dt1.ToString("MMMM-yyyy");

                // dsDataSet.Merge(dsdataset2);



                return null;
            }
        }

       public DataSet GetEmployeeSalesAndCre()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName ={ "employee" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_employee_select_sales_cre",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetManagerlevelreport(int branchId, int accountmanagerId, int year, int month)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName ={ "salesorder" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lbracnchid", DbType.Int32, branchId, ParameterDirection.Input);
               objSpParameters.Add("lmanagerid", DbType.Int32, accountmanagerId, ParameterDirection.Input);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_invoice_report_manager",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetDownBusinessReport(string cfirstfromdate, string cfirsttodate, string csecondfromdate, string csecondtodate, int top)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salesorder", "ss" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("firstfromdate", DbType.String, cfirstfromdate, ParameterDirection.Input);
               objSpParameters.Add("firsttodate", DbType.String, cfirsttodate, ParameterDirection.Input);
               objSpParameters.Add("secondfromdate", DbType.String, csecondfromdate, ParameterDirection.Input);
               objSpParameters.Add("secondtodate", DbType.String, csecondtodate, ParameterDirection.Input);
               objSpParameters.Add("ltop", DbType.Int32, top, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_down_business",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTop10HighestCorporate(int year, int month, int lSale, int top)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lissale", DbType.Int16, lSale, ParameterDirection.Input);
               objSpParameters.Add("ltop", DbType.Int32, top, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top_10_corporate_sale_bill",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTotalAmtByCustomerID(int year, int month, int customerID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcustomerid", DbType.Int32, customerID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top100_totalbillingamout_bycustomerid",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetTotalSAleByCustomerID(int year, int month, int customerID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcustomerid", DbType.Int32, customerID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top100_totalsalecount_bycustomerid",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetTotalCountInvoiceNotGenerate(int year, int month, int countryIDD)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salesorder", "ss" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcountryid", DbType.Int32, countryIDD, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_invoice_report_not_gen",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataTable GetCountRafByCriteria(int year, int month, string criteria)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salesorder", "ss" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("ccriteria", DbType.String, criteria, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_invoice_report_not_gen_display_diff_wise",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet.Tables[0];

               return null;
           }
       }


       public DataTable GetTotalCountLess500(int year, int month, int countryid, string HighLow, double amountinr)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "invoicing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
               objSpParameters.Add("chighlow", DbType.String, HighLow, ParameterDirection.Input);
               objSpParameters.Add("lamountinr", DbType.Double, amountinr, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_invoice_high_low_value_total_count", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet.Tables[0];

               return null;
           }
       }

       public DataTable GetTotalInvoiceLess500DiffWise(string _criteria, int year, int month, int countryid, string HighLow, double amountinr)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "invoicing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("ccriteria", DbType.String, _criteria, ParameterDirection.Input);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
               objSpParameters.Add("chighlow", DbType.String, HighLow, ParameterDirection.Input);
               objSpParameters.Add("lamountinr", DbType.Double, amountinr, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_invoice_high_low_value_diff_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet.Tables[0];

               return null;
           }
       }
       public DataTable GetCountRafByCriteria2(int year, int month, string criteria, string rentals, string RentalFree)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salesorder", "ss" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("ccriteria", DbType.String, criteria, ParameterDirection.Input);
               objSpParameters.Add("rentals", DbType.String, rentals, ParameterDirection.Input);
               objSpParameters.Add("rentalsFree", DbType.String, RentalFree, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_invoice_report_not_gen_display_diff_wise2",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet.Tables[0];

               return null;
           }
       }




       public DataSet rpt_Daily_Billing_wise(short _withServiceTax, int _year, int _month, int _toyear, int _tomonth, int _day, int custTypeID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "invoicing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lwithservicetax", DbType.Int16, _withServiceTax, ParameterDirection.Input);
               objSpParameters.Add("lyear", DbType.Int32, _year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, _month, ParameterDirection.Input);
               objSpParameters.Add("ltoyear", DbType.Int32, _toyear, ParameterDirection.Input);
               objSpParameters.Add("ltomonth", DbType.Int32, _tomonth, ParameterDirection.Input);
               objSpParameters.Add("lday", DbType.Int32, _day, ParameterDirection.Input);
               objSpParameters.Add("lcustomertypeid", DbType.Int32, custTypeID, ParameterDirection.Input);
              // objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_daily_billing_wise_arpu", dsDataSet, strDataTableName, objSpParameters);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_daily_billing_wise_arpu_with_ST_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
               /*report_daily_billing_wise_arpu_with_ST*/
           }
       }

       public DataSet rpt_Daily_Billing_wise_By_day(short _withServiceTax, int _year, int _month, int _toyear, int _tomonth, int _day, int custTypeID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "invoicing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lwithservicetax", DbType.Int16, _withServiceTax, ParameterDirection.Input);
               objSpParameters.Add("lyear", DbType.Int32, _year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, _month, ParameterDirection.Input);
               objSpParameters.Add("ltoyear", DbType.Int32, _toyear, ParameterDirection.Input);
               objSpParameters.Add("ltomonth", DbType.Int32, _tomonth, ParameterDirection.Input);
               objSpParameters.Add("lday", DbType.Int32, _day, ParameterDirection.Input);
               objSpParameters.Add("lcustomertypeid", DbType.Int32, custTypeID, ParameterDirection.Input);
               //objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_daily_billing_wise_by_day_arpu", dsDataSet, strDataTableName, objSpParameters);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_daily_billing_wise_by_day_arpu_with_ST_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;

               /* report_daily_billing_wise_by_day_arpu_with_ST */
           }
       }

       public DataSet rptSalesBillingYearWise(int yearFrom, int yearTo)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "invoicing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_year_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptSalesBillingYearWiseZone(int yearFrom, int yearTo)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "sale","Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_year_wise_new2", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet rptSalesBillingMonthWise(int yearFrom, int yearTo)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "sale", "Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_month_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet rptSalesBillingBranchWise(int yearFrom, int yearTo, string _strZone)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "sale", "Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strZone", DbType.String, _strZone, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_branch_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet rptSalesBillingBranchWiseWithAllBranch(int yearFrom, int yearTo, string _strZone)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "sale", "Billing", "Branch" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strZone", DbType.String, _strZone, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_branch_wise_with_branch", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTopHighestCorporateByCustomerID(int year, int month, string _strCustomerID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("strCustomerID", DbType.String, _strCustomerID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top_10_corporate_sale_bill_customerid",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTotalSAleByCustomerIDNew(int year, int month, int customerID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "countrywise", "branchwise" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("lcustomerid", DbType.Int32, customerID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top100_totalsalecount_bycustomeridnew",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTop10HighestCorporateFAC(int year, int month, int top)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("ltop", DbType.Int32, top, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top_10_corporate_sale_bill_fac",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetTopHighestCorporateByCustomerIDFAC(int year, int month, string _strLedgerID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecont", "billingamt" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
               objSpParameters.Add("strLedgerID", DbType.String, _strLedgerID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_top_10_corporate_sale_bill_ledgerid_fac",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       //public DataSet rptGetCDRRowData(int _year, int _month, int _groupProviderID, string _strCallTypeName)
       //{
       //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
       //    {
       //        DataSet dsDataSet = new DataSet();
       //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
       //        string[] strDataTableName = { "Branch" };
       //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
       //        objSpParameters.Add("lyear", DbType.Int32, _year, ParameterDirection.Input);
       //        objSpParameters.Add("lmonth", DbType.Int32, _month, ParameterDirection.Input);
       //        objSpParameters.Add("lgroupproviderid", DbType.Int32, _groupProviderID, ParameterDirection.Input);
       //        objSpParameters.Add("strCallTypeName", DbType.String, _strCallTypeName, ParameterDirection.Input);
       //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_get_data_by_row_calldate", dsDataSet, strDataTableName, objSpParameters);

       //        if (dsDataSet != null)
       //            return dsDataSet;

       //        return null;
       //    }
       //}
       //public DataSet rptGroupProviderGetAll()
       //{
       //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
       //    {
       //        DataSet dsDataSet = new DataSet();
       //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
       //        string[] strDataTableName = { "groupProvider" };
       //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
       //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_group_provider_name_get_all", dsDataSet, strDataTableName, objSpParameters);
       //        if (dsDataSet != null)
       //            return dsDataSet;
       //        return null;
       //    }
       //}
       //public DataSet rptCallTypeByGroupProvider(int _groupProviderID)
       //{
       //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
       //    {
       //        DataSet dsDataSet = new DataSet();
       //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
       //        string[] strDataTableName = { "groupProviderCalType" };
       //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
       //        objSpParameters.Add("lgroupproviderid", DbType.Int32, _groupProviderID, ParameterDirection.Input);
       //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_calltype_get_by_providerid", dsDataSet, strDataTableName, objSpParameters);
       //        if (dsDataSet != null)
       //            return dsDataSet;
       //        return null;
       //    }
       //}
       public DataSet getSaleCountBillingHeadCount(int yearFrom, int monthTo, string _strSaleCategory)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "salecategory", "sale", "billing", "headcount" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, monthTo, ParameterDirection.Input);
               objSpParameters.Add("strSaleCategory", DbType.String, _strSaleCategory, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_count_sale_category_wise",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptSalesBillingBranchAccountManagerWise(int yearFrom, int yearTo, string _strBranch)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "sale", "Billing", "Branch" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strBranch", DbType.String, _strBranch, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_branch_accountmanager_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptSalesCategoryBranchAccountManagerWise(int yearFrom, int yearTo, string _strSaleCategory)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Branch", "salecategory", "sale", "Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strSaleCategory", DbType.String, _strSaleCategory, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_sale_category_branch_accountmanager_wise_opt", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptGetCDRRowData(int _year, int _month, int _groupProviderID, string _strCallTypeName)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Branch" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, _year, ParameterDirection.Input);
               objSpParameters.Add("lmonth", DbType.Int32, _month, ParameterDirection.Input);
               objSpParameters.Add("lgroupproviderid", DbType.Int32, _groupProviderID, ParameterDirection.Input);
               objSpParameters.Add("strCallTypeName", DbType.String, _strCallTypeName, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_get_data_by_row_calldate", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet rptGroupProviderGetAll()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "groupProvider" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_group_provider_name_get_all", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }

       public DataSet rptCallTypeByGroupProvider(int _groupProviderID)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "groupProviderCalType" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lgroupproviderid", DbType.Int32, _groupProviderID, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_calltype_get_by_providerid", dsDataSet, strDataTableName, objSpParameters);
               if (dsDataSet != null)
                   return dsDataSet;
               return null;
           }
       }

       public DataSet rptSalesBillingBranchAccountManagerWiseNew(int yearFrom, int yearTo, string _strSaleBranch)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "Branch", "salecategory", "sale", "Billing" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, yearFrom, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, yearTo, ParameterDirection.Input);
               objSpParameters.Add("strBranch", DbType.String, _strSaleBranch, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_sale_billing_branch_accountmanager_wise_opt", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet rptSalesBillingBranchAccountManagerWisewithsort(int yearFrom, int yearTo, int _strSaleBranch,int accmgrid,int salecategoryid)
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
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_sale_billing_sale_billing_branch_accountmanager_wise_opt_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetDistinctEmpYearwiseNew(int FromYear, int ToYear)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "EmpYearWise", "EmpYearZoneWise", "ActiveEmpCount" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("iFromYear", DbType.Int32, FromYear, ParameterDirection.Input);
               objSpParameters.Add("iToYear", DbType.Int32, ToYear, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_distinct_emp_year_wise_new2", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet SaleBillingReportBranchWise(int year)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "BranchWise" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_year_wise_sale_billing_branch_wise_new", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet SaleBillingReportCountryWise(int year)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "CountryWiseRow", "CountryWiseUsa", "CountryWiseUk" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_year_wise_sale_billing_country_wise", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }


       public DataSet SaleBillingReportBranchWiseCompare(int year, int compareYear)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "CompareYear" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lComapreYear", DbType.Int32, compareYear, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_year_wise_sale_billing_branch_wise_compare", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet SaleBillingReportCountryWiseComapre(int year, int compareYear)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
           {
               DataSet dsDataSet = new DataSet();
               dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
               string[] strDataTableName = { "CountryWiseRow", "CountryWiseUsa", "CountryWiseUk" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("lComapreYear", DbType.Int32, compareYear, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "rpt_year_wise_sale_billing_country_wise_compare", dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
    }
}
