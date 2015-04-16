using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DalClayBilling;
using System.Data;
namespace ClayBillingLibrary.Report
{
    public class DashBoard
    {
        string _fromdate;

        public string Fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }
        string _todate;

        public string Todate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        int _invoiceTypeId;

        public int InvoiceTypeId
        {
            get { return _invoiceTypeId; }
            set { _invoiceTypeId = value; }
        }

        private string _countryName;

        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        private string _fromYear;

        public string FromYear
        {
            get { return _fromYear; }
            set { _fromYear = value; }
        }
        private string _toYear;

        public string ToYear
        {
            get { return _toYear; }
            set { _toYear = value; }
        }

        private string _branchName;

        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        private string _monthName;

        public string MonthName
        {
            get { return _monthName; }
            set { _monthName = value; }
        }

        private int _monthID;

        public int MonthID
        {
            get { return _monthID; }
            set { _monthID = value; }
        }

        private int _monthValue;

        public int PMonthValue
        {
            get { return _monthValue; }
            set { _monthValue = value; }
        }

        private int customerType;

        public int PCustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }


        public DataSet GetBillingDetailsBasedOnFinancialYear()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "CountryDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, MonthID, ParameterDirection.Input);
            ObjSpParameter.Add("customerType", DbType.Int32, PCustomerType, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_countrybilling_yearwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetYearBillingDetailsBasedOnCountry()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "CountryDetails", "lastyearbilling" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getCountryName", DbType.String, CountryName, ParameterDirection.Input);
            ObjSpParameter.Add("customerType", DbType.Int32, PCustomerType, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_countrybilling_monthwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetBranchBillingDetailsBasedOnFinancialYear()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "BranchDetails"};
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, PMonthValue, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branchbilling_yearwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetMonthlyBillingDetailsBasedOnBranch()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "branchDetails","LastYearData" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getbranchName", DbType.String, BranchName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branchbilling_monthwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetSalesOrderDetailsBasedOnFinancialYear()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "SalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, MonthID, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_salesorder_yearwise", ds, TableName, ObjSpParameter);
            return ds;
        }

      

        public DataSet DisplayMonthWiseCountrySalesOrderReport()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "CountryDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getCountryName", DbType.String, CountryName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_salesorder_monthwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetBranchSalesOrderDetailsBasedOnFinancialYear()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "SalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, MonthID, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branch_salesorder_yearwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetMonthlySalesOrderDetailsBasedOnBranch()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "branchDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getbranchName", DbType.String, BranchName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branch_salesorder_monthwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetAllBranchBillingMonthWise()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "SalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_Allbranch_billing_monthwise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetAllBranchBillingDayWiseBasedOnMonth()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "branchDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getMonthID", DbType.String, MonthID, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_Allbranch_billing_daywise", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetSalesOfCountryBasedOnYearAndMonthly()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "SalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.String, MonthID, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_get_sales_basison_year_and_month", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetBranchWiseSalesDetailsOfCountry()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "CountryDetails","AllBranch" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("getCountryName", DbType.String, CountryName, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.String, MonthID, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_get_branch_sales_of_country", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetBranchBillingDetailsBasedMonthAndCountry()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "BranchDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, PMonthValue, ParameterDirection.Input);
            ObjSpParameter.Add("ccountry_name", DbType.String, CountryName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branchbilling_basedon_month_and_country", ds, TableName, ObjSpParameter);
            return ds;
        }

        public DataSet GetCountrySalesOrder_BasedOn_Month_branch()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "SalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, MonthID, ParameterDirection.Input);
            ObjSpParameter.Add("cbranchName", DbType.String, BranchName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_salesorder_branch_and_month", ds, TableName, ObjSpParameter);
            return ds;
        }
        public DataSet GetBranchSalesOrderDetailsBasedOnCountryAndMonth()
        {
            CommandExecutor ObjCommandExecutor = new CommandExecutor("dbconnection");
            SpParameters ObjSpParameter = new SpParameters(RdbmsType.MySql);
            DataSet ds = new DataSet();
            string[] TableName = { "BranchSalesOrderDetails" };
            ObjSpParameter.Add("fromdate", DbType.String, Fromdate, ParameterDirection.Input);
            ObjSpParameter.Add("todate", DbType.String, Todate, ParameterDirection.Input);
            ObjSpParameter.Add("monthvalue", DbType.Int32, MonthID, ParameterDirection.Input);
            ObjSpParameter.Add("ccountry_name", DbType.String, CountryName, ParameterDirection.Input);
            ObjCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "report_display_branch_salesorder_basedon_country_and_month", ds, TableName, ObjSpParameter);
            return ds;
        }
    }
}
