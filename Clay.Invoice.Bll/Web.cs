using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;
namespace Clay.Invoice.Bll
{
    public class Web
    {
        public DataSet GetSalesOrderFilter(int branchId, int accountmanagerId, string customerName, int rafno)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lbranchid", DbType.Int32, branchId, ParameterDirection.Input);
                objSpParameters.Add("laccountmanagerid", DbType.Int32, accountmanagerId, ParameterDirection.Input);
                objSpParameters.Add("ccustomername", DbType.String, customerName, ParameterDirection.Input);
                objSpParameters.Add("rafno", DbType.Int32, rafno, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_salesorder_search",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

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

        public DataSet SalesReportByManager(int ManagerId, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lmanagerid", DbType.Int32, ManagerId, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_bymanager", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SalesReportByBranch(int BranchID, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lbranchid", DbType.Int32, BranchID, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_branch", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet SalesReportByDepartment(int DepartmentID, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ldepartmentid", DbType.Int32, DepartmentID, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_department", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetSalesReportDashboard(int branchId, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data", "customer", "sales", "sales1", "sales2", "sales3", "sales4", "sales5" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lbranchid", DbType.Int32, branchId, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_branch_and_status",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetSalesReportDashboardTooltip(int BranchID, int lissendtoinventory, int lissendtooperation, string Year, string Month, string orderstatus)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lissendtoinventory", DbType.Int32, lissendtoinventory, ParameterDirection.Input);
                objSpParameters.Add("lissendtooperation", DbType.Int32, lissendtooperation, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("corderstatus", DbType.String, orderstatus, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, BranchID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_on_dashboard_tooltip",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet GetRafCancelReason(int lorderid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lorderid", DbType.Int32, lorderid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_rafcancelreason",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SalesReportByManagerChart(int lmanagerid, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lmanagerid", DbType.Int32, lmanagerid, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_manager", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet SalesReportByManagerChartConsolidate(int lmanagerid, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lmanagerid", DbType.Int32, lmanagerid, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_managerconsolidated", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet sp_web_report_sales_by_departmentconsolidated(int DepartmentID, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ldepartmentid", DbType.Int32, DepartmentID, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_departmentconsolidated", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet sp_web_report_sales_by_branchconsolidated(int branchId, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lbranchid", DbType.Int32, branchId, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_branchconsolidated", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet GetTimeDifferenceReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_timedifference",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetMaxDeliveryDate(int orderId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lorderId", DbType.Int32, orderId, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_deliverydate_fromsalesordersetails",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet GetDateDifference(DateTime startdate, DateTime enddate, string starttime, string endtime)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("startdate", DbType.DateTime, startdate, ParameterDirection.Input);
                objSpParameters.Add("enddate", DbType.Date, enddate, ParameterDirection.Input);
                objSpParameters.Add("starttime", DbType.String, starttime, ParameterDirection.Input);
                objSpParameters.Add("endtime", DbType.String, endtime, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_date_difference",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        /// <summary>
        /// added by deepak rohilla on 12-july-2010 fro selected the rejected order
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="orderstatus"></param>
        /// <returns></returns>
        public DataSet GetSalesReportDashboardRejected(int BranchID, string Year, string Month, string orderstatus)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("corderstatus", DbType.String, orderstatus, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, BranchID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_on_dashboard_ttoltip_rejected",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        /// <summary>
        /// method created by deepak rohilla to select the count of inventory and operation on dashboard
        /// </summary>
        /// <param name="lissendtoinventory"></param>
        /// <param name="lissendtooperation"></param>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="orderstatus"></param>
        /// <returns></returns>
        public DataSet GetSalesReportDashboardTooltipInventoryAndOperation(int lissendtoinventory, int lissendtooperation, string Year, string Month, string orderstatus)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lissendtoinventory", DbType.Int32, lissendtoinventory, ParameterDirection.Input);
                objSpParameters.Add("lissendtooperation", DbType.Int32, lissendtooperation, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("corderstatus", DbType.String, orderstatus, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_on_dashboard_tooltip_test",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// added by deepak rohilla on 12-07-2010 
        /// </summary>
        /// <param name="enddate"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataSet GetDateDifferenceCurrent(DateTime enddate, string endtime)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("enddate", DbType.Date, enddate, ParameterDirection.Input);

                objSpParameters.Add("endtime", DbType.String, endtime, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_date_difference_currentdate",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// added by deepak rohilla on 12-07-2010 
        /// </summary>
        /// <param name="enddate"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataSet GetRafCancelReport(DateTime fromdate, DateTime todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("fromdate", DbType.Date, fromdate, ParameterDirection.Input);

                objSpParameters.Add("todate", DbType.Date, todate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_Raf_Cancellation",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetRafRejectedReport(DateTime fromdate, DateTime todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("fromdate", DbType.Date, fromdate, ParameterDirection.Input);

                objSpParameters.Add("todate", DbType.Date, todate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_Raf_Rejected",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet SalesReportByChartAnnualy(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_Annualy", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// method creted by deepak rohilla on 05-aug-2010 for get the dashboard summary report
        /// </summary>
        /// <param name="BranchID"></param>
        /// <param name="lissendtoinventory"></param>
        /// <param name="lissendtooperation"></param>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="orderstatus"></param>
        /// <returns></returns>
        public DataSet GetDashboardsummaryreport(int lissendtoinventory, int lissendtooperation, string Year, string Month, string orderstatus)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lissendtoinventory", DbType.Int32, lissendtoinventory, ParameterDirection.Input);
                objSpParameters.Add("lissendtooperation", DbType.Int32, lissendtooperation, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("corderstatus", DbType.String, orderstatus, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_get_dashboard_summary_report",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet Getsummaryreport(string searchcriteria)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("searchcriteria", DbType.String, searchcriteria, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_summaryreport",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int insertwebmail(string email)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("cemailid", DbType.String, email, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_insert_email", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }


        /// <summary>
        /// check whetehr email existing or not
        /// </summary>
        /// <param name="searchcriteria"></param>
        /// <returns></returns>
        public DataSet checkwebemail(string email)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cemailid", DbType.String, email, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_check_email",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// created by deepak rohilla for get the pending inventory on 10-aug-2010
        /// </summary>
        /// <param name="searchcriteria"></param>
        /// <returns></returns>
        public DataSet Getpendinginventorybybranchname(string branchname)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cbranchname", DbType.String, branchname, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_pending_inventory_bybranchname",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// created by deepak rohilla for get the pending inventory on 10-aug-2010
        /// </summary>
        /// <param name="searchcriteria"></param>
        /// <returns></returns>
        public DataSet Getpendingoperationbybranchname(string branchname)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cbranchname", DbType.String, branchname, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_pending_operation_bybranchname",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        ///  to select the report by deliverydate
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet SalesReportByChartAnnualyByDeliveryDate(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_sales_by_Annualy_ByDeliveryDate", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }



        /// <summary>
        /// method created by deepak rohilla on 08-10-2010 for select the pending sale report
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet SalesPendingdetailReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_pending_salesdetails", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// method created by deepak rohilla on 08-10-2010 for select the pending sale report
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet CustomerPendingdetailReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_pending_customerdetails", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetEnquiryReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cfromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("ctodate", DbType.String, todate, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_enquiry_report_web",
                                                                dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }


        public DataSet GetOnlineCampaignCode()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcustomerid", DbType.Int32, 0, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_customeradvertisement_select",
                                                                dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetEnquiryVisiterDetails(DateTime visiterDatetime, int partnerid, int visitor)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder", "data" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("dvisiteddatetime", DbType.DateTime, visiterDatetime, ParameterDirection.Input);
                objSpParameters.Add("lpartnerid", DbType.Int32, partnerid, ParameterDirection.Input);
                objSpParameters.Add("bvisitor", DbType.Int32, visitor, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_enquiry_visiters_detail_select_by_date",dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }


      

        public DataSet MisReportBycountry(Int32 Month, Int32 Year)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("mnth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("yr", DbType.String, Year, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_report_country_yearmonthwise", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }


        public DataSet MisReportBycountry(DateTime frdate, DateTime todate, Int32 invid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing", "country", "invoice" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate", DbType.DateTime, frdate, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.DateTime, todate, ParameterDirection.Input);
                objSpParameters.Add("invoicetypid", DbType.Int32, invid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_misreport_nav", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }



        public DataSet MisReportBycountryGraph(DateTime frdate, DateTime todate, Int32 invid, int _countryID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing", "country", "invoice" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fromdate", DbType.DateTime, frdate, ParameterDirection.Input);
                objSpParameters.Add("todate", DbType.DateTime, todate, ParameterDirection.Input);
                objSpParameters.Add("invoicetypid", DbType.Int32, invid, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_misreport_nav_graph", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }
        public DataSet MisReportCountryBranch(string from, string to)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing", "country", "invoice" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fryr", DbType.String, from, ParameterDirection.Input);
                objSpParameters.Add("toyr", DbType.String, to, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_citywisemisreport_new2", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet MisReportCountryBranchGraph(string from, string to, int _branchID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Invoicing", "country", "invoice" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fryr", DbType.String, from, ParameterDirection.Input);
                objSpParameters.Add("toyr", DbType.String, to, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, _branchID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_citywisemisreport_new_graph", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataTable GetBilledUnbilledCDRFromPTByInvoiceID(int _orderID, int _invoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "PT" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoiceid", DbType.Int32, _invoiceID, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, _orderID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "web_get_billed_unbilled_cdr_invoiceid", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet.Tables[0];
                return null;
            }
        }

        public DataTable GetBilledUnbilledCDRFromPTByInvoiceIDRebel(int _orderID, int _invoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "PT" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoiceid", DbType.Int32, _invoiceID, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, _orderID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "web_get_billed_unbilled_cdr_invoiceid_rebel", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet.Tables[0];
                return null;
            }
        }

    }

}
