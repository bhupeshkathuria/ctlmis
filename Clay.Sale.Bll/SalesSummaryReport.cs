using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using dal;

namespace Clay.Sale.Bll
{
    public class SalesSummaryReport
    {
        #region Public Methods

        public DataSet GetSummaryReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Branch", "RAF", "Zone", "MIX", "BB" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreport_new1", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetMonthlyReport(string dtFrom, string dtTo)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("dtfrom", DbType.String, dtFrom, ParameterDirection.Input);
                objSpParameters.Add("dtto", DbType.String, dtTo, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_MISSalesReport_Monthly", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetShortFallReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesShortFallReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_shortfallreport_sales", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetBBAndDataCardReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesReportBB" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreport_bbdatacard", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetReportAccountManagerWise(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesReportAccountManagerWise" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreportdata_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetSummaryReportDateWise(string fromdate, string todate, string SearchBy)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Zone", "product", "ZoneVsProduct" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cfromdate", DbType.DateTime, fromdate, ParameterDirection.Input);
                objSpParameters.Add("ctodate", DbType.DateTime, todate, ParameterDirection.Input);
                objSpParameters.Add("csearchby", DbType.String, SearchBy, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreportDatewise_new", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetReportAccountManagerWise(string Year, string Month, string searchby)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesReportAccountManagerWise" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreportdata_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        //public DataSet GetSummaryReport1(string Year, string Month, string datefrom, string dateto, string searchby)
        //{
        //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
        //    {
        //        DataSet dsDataSet = new DataSet();
        //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //        string[] strDataTableName = { "Branch", "RAF", "Zone", "MIX", "BB", "DailySale", "LastYearSale" };
        //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
        //        objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
        //        objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
        //        objSpParameters.Add("cdatefrom", DbType.DateTime, datefrom, ParameterDirection.Input);
        //        objSpParameters.Add("cdateto", DbType.DateTime, dateto, ParameterDirection.Input);
        //        objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
        //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreport_new_test", dsDataSet, strDataTableName, objSpParameters);
        //        /*OLD SP sproc_salesreport_new*/
        //        if (dsDataSet != null)
        //            return dsDataSet;

        //        return null;
        //    }
        //}
        public DataSet GetSummaryReport1(string Year, string Month, string datefrom, string dateto, string searchby, int salebranch)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Branch", "RAF", "Zone", "MIX", "BB", "DailySale", "LastYearSale", "LeadSale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("cdatefrom", DbType.DateTime, datefrom, ParameterDirection.Input);
                objSpParameters.Add("cdateto", DbType.DateTime, dateto, ParameterDirection.Input);
                objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
                objSpParameters.Add("lsalebranch", DbType.Int32, salebranch, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreport_new_test121", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;

                /* sproc_salesreport_new_test12 sproc_salesreport_new_test121 sproc_salesreport_new_test121copy*/
            }
        }


        //============================================================================By Tarun=================
        public DataSet GetApprovalRequest(int empcode, int reqtype, string reqstatus)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Requisition" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, empcode, ParameterDirection.Input);
                objSpParameters.Add("ctypeid", DbType.String, reqstatus, ParameterDirection.Input);
                objSpParameters.Add("lrequisitiontypeid", DbType.Int32, reqtype, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_approvaltype_select_web", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null; //sp_approval_type_web_select
            }
        }

        public DataSet GetRequistionDetails(string reqno)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "POMaster", "PODetails", "RequisitionDetails", "POFiles" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("creqno", DbType.String, reqno, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_requisition_details_select_web", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet CheckApproverOrNot(int employeeid, int requisitiontypeid, int departmentid, int branchid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "approvalprocesstype" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lemployeeid", DbType.Int32, employeeid, ParameterDirection.Input);
                objSpParameters.Add("lrequisitiontypeid", DbType.Int32, requisitiontypeid, ParameterDirection.Input);
                objSpParameters.Add("ldepartmentid", DbType.Int32, departmentid, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_check_approver_or_not_01",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public object GetUserRankFromRequisitionHierarchy(int RequisitiontypeId, int approverId, int branchId, int departmentId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrequisitiontypeid", DbType.Int32, RequisitiontypeId, ParameterDirection.Input);
                objSpParameters.Add("lapproverid", DbType.Int32, approverId, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, branchId, ParameterDirection.Input);
                objSpParameters.Add("ldepartmentid", DbType.Int32, departmentId, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                object value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_approval_get_user_rank", objSpParameters);
                return value;

            }
        }

        public DataSet GetEmployeeByUser(string employeeId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "employee" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cemployeeid", DbType.String, employeeId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_employee_byuserid",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetHierarchyUserMailId(int HierarchyRank, int RequisitiontypeId, int BranchId, int DepartmentId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {

                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "HierarchyUserMailId" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lhierarchyrank", DbType.Int32, HierarchyRank, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, BranchId, ParameterDirection.Input);
                objSpParameters.Add("ldepartmentid", DbType.Int32, DepartmentId, ParameterDirection.Input);
                objSpParameters.Add("lrequisitiontypeid", DbType.Int32, RequisitiontypeId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_approval_get_employee_emailid",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetEmployee()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "Employee" };
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_employee_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetBranch()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "Branch" };
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_branch_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCountry()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "Country" };
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_country_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetARPU(string Year, string Month, int employeeid, int countryid, int branchid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "ARPU", "TotalBilling" };
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("laccountmanagerid", DbType.Int32, employeeid, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_ARPU_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetTotalBilling(string Year, string Month, int employeeid, int countryid, int branchid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "TotalBilling" };
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("laccountmanagerid", DbType.Int32, employeeid, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_get_totalbilling", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        //===================================================

        public DataSet GetLastThreeMonthsPO(int SupplierId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {

                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "LastThreeMonthsPO" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lsupplierid", DbType.Int32, SupplierId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_get_lastthreemonthinvoice_supplierid",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetPurchaseOrder(int SupplierId, string MonthName, string YearName)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "purchaseorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lsupplierid", DbType.Int32, SupplierId, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, MonthName, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, YearName, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getpo_supplierid_month", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetPurchaseOrderLine(int PoId, int ItemId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "purchaseorderline" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpoid", DbType.Int32, PoId, ParameterDirection.Input);
                objSpParameters.Add("litemid", DbType.Int32, ItemId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_purchaseorderline_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetRequisitionComment(int requisitionid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName = { "requisitioncomment" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrequisitionid", DbType.Int32, requisitionid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_requisitioncomment_select",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetHomeDashboard()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Product", "Receivable", "Billing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                //objSpParameters.Add("creqno", DbType.String, reqno, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_home_dashboard", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetARPUReport(string cmonth, string cyear, int reptype, string compmonth, string compyear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Billing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, cyear, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, cmonth, ParameterDirection.Input);
                objSpParameters.Add("lreptype", DbType.Int32, reptype, ParameterDirection.Input);
                objSpParameters.Add("cyearcomp", DbType.String, compyear, ParameterDirection.Input);
                objSpParameters.Add("cmonthcomp", DbType.String, compmonth, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_ARPU_Report", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int Insertemailinfo(string rptname, int evryday, string weekday, string time, string email)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrptname", DbType.String, rptname, ParameterDirection.Input);
                objSpParameters.Add("leveryday", DbType.Int32, evryday, ParameterDirection.Input);
                objSpParameters.Add("lweekday", DbType.String, weekday, ParameterDirection.Input);
                objSpParameters.Add("ltime", DbType.String, time, ParameterDirection.Input);
                objSpParameters.Add("lemail", DbType.String, email, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_insert_alertemail", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public DataSet ERPUsageReport(int UserId, string dtFrom, string dtTo)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "ERPUsageReport" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, UserId, ParameterDirection.Input);
                objSpParameters.Add("dtfrom", DbType.String, dtFrom, ParameterDirection.Input);
                objSpParameters.Add("dtto", DbType.String, dtTo, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_erpusage_report", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetSaleCategory(int SaleCategoryId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "SaleCategory" };
                objSpParameters.Add("lsalecategoryid", DbType.Int32, SaleCategoryId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salecategory_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetAccountManagerSaleCategory(int SaleCategoryId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                string[] strDataTableName = { "SaleCategory" };
                objSpParameters.Add("lsalecategoryid", DbType.Int32, SaleCategoryId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_employee_select_salecategory", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetTargetVsAchivementReport(string employeeId, string year, string frommonth, string tomonth)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "TarVsAch" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lemployeeid", DbType.String, employeeId, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, year, ParameterDirection.Input);
                objSpParameters.Add("cfrommonth", DbType.String, frommonth, ParameterDirection.Input);
                objSpParameters.Add("ctomonth", DbType.String, tomonth, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_targetvsachievement_03", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetReportAccountManagerWise(string Year, string Month, string searchby, string _employee)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SalesReportAccountManagerWise" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
                objSpParameters.Add("lemployeeid", DbType.String, _employee, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreportdata_select_new", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetReportTravelInsurance(string Year, string frommonth, string tomonth)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Travel" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cfrommonth", DbType.String, frommonth, ParameterDirection.Input);
                objSpParameters.Add("ctomonth", DbType.String, tomonth, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_travelinsurance_report_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCurrentDaySaleCount(string searchby)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SaleCount", "lastyearsale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_getcurrentdaysalecount_new", dsDataSet, strDataTableName, objSpParameters);

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

        public DataSet GetSalesorderStatusReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "branchStatus" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_SalesorderStatusreport_sales", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        //........................salesorderbranchmanaserwise
        public DataSet GetSalesorderStatusReportBranchmangerwise(int branchid, string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "BranchmangerwiseStatus" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lbranchid", DbType.Int32, branchid, ParameterDirection.Input);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_SalesorderStatusBranchManagerwise_sales", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        //public DataSet GetsalesYearly(string text)
        //{
        //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
        //    {
        //        DataSet dsDataSet = new DataSet();
        //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //        string[] strDataTableName = { "month", "T2011", "T2011D", "T2012", "T2012D", "T2013", "T2013D" };
        //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
        //        objSpParameters.Add("ctextsearch", DbType.String, text, ParameterDirection.Input);
        //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesreportyearwise_select_new4", dsDataSet, strDataTableName, objSpParameters);
        //        if (dsDataSet != null)
        //            return dsDataSet;
        //        return null;
        //    }
        //}
        //public DataSet GetsalesYearly(string text)
        //{
        //    using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
        //    {
        //        DataSet dsDataSet = new DataSet();
        //        dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //        string[] strDataTableName = { "yearly"};
        //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
        //        objSpParameters.Add("ctextsearch", DbType.String, text, ParameterDirection.Input);
        //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesreportyearwise_select_new4", dsDataSet, strDataTableName, objSpParameters);
        //        if (dsDataSet != null)
        //            return dsDataSet;
        //        return null;

        //        /* sp_salesreportyearwise_select_new5 */
        //    }
        //}

        public DataSet GetsalesYearly(string text)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "yearly", "T2011", "T2011D", "T2012", "T2012D", "T2013", "T2013D" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ctextsearch", DbType.String, text, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesreportyearwise_select_new7", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;

                /* sp_salesreportyearwise_select_new5 */
            }
        }

        public DataSet GetsalesTillCurrentDay(string text)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Daily" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ctextsearch", DbType.String, text, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesreportyearwise_select_new6", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;

                /* sp_salesreportyearwise_select_new5 */
            }
        }
        public DataSet GetLeadSourceReport(string Year, string Month, int searchby)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "LeadSale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cyear", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("cmonth", DbType.String, Month, ParameterDirection.Input);
                objSpParameters.Add("csearchby", DbType.String, searchby, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_salesreport_LeadSource", dsDataSet, strDataTableName, objSpParameters);
               
                /*OLD sproc_salesreport_new4*/
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }

        #endregion
        }

        public DataSet GetLeadSourceReport_Groupwise(DateTime fromdate,DateTime todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "LeadSale", "allleadpartner", "affilaited","leadcount" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("_fromdate", DbType.DateTime, fromdate, ParameterDirection.Input);
                objSpParameters.Add("_todate", DbType.DateTime, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_leadsource_bak30june_new", dsDataSet, strDataTableName, objSpParameters);
                /*OLD sproc_salesreport_new4  sp_select_leadsource_bak30june*/
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }

       
        }
        public DataSet GetLeadReportLevel2(DateTime fromdate, DateTime todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "LeadSource", "LeadSale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cfromdate", DbType.DateTime, fromdate, ParameterDirection.Input);
                objSpParameters.Add("ctodate", DbType.DateTime, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_leadreport_level1_new", dsDataSet, strDataTableName, objSpParameters);
                /*OLD sproc_salesreport_new4 sproc_leadreport_level1 */
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }


        }
        public DataSet GetLeadDetails(string _Month, string _LeadSource, string _fromYear, string _toYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "LeadSource" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cmonthname", DbType.String, _Month, ParameterDirection.Input);
                objSpParameters.Add("cleadsource", DbType.String, _LeadSource, ParameterDirection.Input);
                objSpParameters.Add("cfromyear", DbType.String, _fromYear, ParameterDirection.Input);
                objSpParameters.Add("ctoyear", DbType.String, _toYear, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_leadreport_level2", dsDataSet, strDataTableName, objSpParameters);
                /*OLD sproc_salesreport_new4*/
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }


        }

        public DataSet GetCSTLeadReport(DateTime fromdate, DateTime todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "CSTLeadSale"};
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("_fromdate", DbType.DateTime, fromdate, ParameterDirection.Input);
                objSpParameters.Add("_todate", DbType.DateTime, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_cstlead_report", dsDataSet, strDataTableName, objSpParameters);
                /*OLD sproc_salesreport_new4  sp_select_leadsource_bak30june*/
                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetManagerByCategory(int SalesCategoryId)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
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

        public DataSet rptSalesBillingBranchAccountManagerWisewithsort(int yearFrom, int yearTo, int _strSaleBranch, int accmgrid, int salecategoryid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
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
    }
}
