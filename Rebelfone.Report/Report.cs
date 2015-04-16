using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using dal;

namespace Rebelfone.Report
{
    public class Report
    {

        /// <summary>
        /// Get Monthly Sale Report For Sim
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>

        public DataSet GetSimMonthReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SIM_Sale"};
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_date", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_SimSaleDayWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetPrepaidMonthReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SIM_Sale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_date", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_PrepaidSimSaleDayWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetMIfiMonthReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SIM_Sale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_date", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_MifiSimSaleDayWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetOverviewReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SIM_Sale" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_date", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_Overview", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetRevenueMonthReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Revenue_Month" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@fromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@enddate", DbType.String, todate, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Revenue1", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetRevenueCompareReport(string fromdate, string todate,string month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Revenue_Compare" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@fromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@enddate", DbType.String, todate, ParameterDirection.Input);
                objSpParameters.Add("@month", DbType.Int32, month, ParameterDirection.Input);
                

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Revenue2", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetRevenueCompareReport2(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Revenue_Compare2" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@fromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@enddate", DbType.String, todate, ParameterDirection.Input);
               


                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Revenue3", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCountrySaleCompareReport(string fromdate, string todate, int month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "CountrySale_Compare" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@fromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@enddate", DbType.String, todate, ParameterDirection.Input);
                objSpParameters.Add("@month", DbType.Int32, month, ParameterDirection.Input);


                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Sale_Country2", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCountrySaleCompareYearReport(string fromdate, string todate)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "CountrySale_Compare" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@fromdate", DbType.String, fromdate, ParameterDirection.Input);
                objSpParameters.Add("@enddate", DbType.String, todate, ParameterDirection.Input);
              


                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Sale_Country3", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }



        public DataSet GetSimYearReport(string StartYear, string EndYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "MonthWise", "VisitorsYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_year", DbType.String, StartYear, ParameterDirection.Input);
                objSpParameters.Add("@end_year", DbType.String, EndYear, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_SimSaleYearWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetPrepaidSimYearReport(string StartYear, string EndYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "MonthWise", "VisitorsYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_year", DbType.String, StartYear, ParameterDirection.Input);
                objSpParameters.Add("@end_year", DbType.String, EndYear, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_PrepaidSimSaleYearWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetMifiYearReport(string StartYear, string EndYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "MonthWise", "VisitorsYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_year", DbType.String, StartYear, ParameterDirection.Input);
                objSpParameters.Add("@end_year", DbType.String, EndYear, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_MifiSimSaleYearWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetOverviewYearReport(string StartYear, string EndYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "MonthWise", "VisitorsYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);
                objSpParameters.Add("@start_year", DbType.String, StartYear, ParameterDirection.Input);
                objSpParameters.Add("@end_year", DbType.String, EndYear, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_RPT_OverviewYearWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Get Sim Sale Comparission 
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>

        public DataSet GetSimYearComparissionReport(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SIM_SaleYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);


                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_SimSaleYearWise", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// Get Revenue Report By Year Wise
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetRevenueReportByYear(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Revenue_SaleYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@start_date", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_Revenue_Report", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// Get Report Country Wise by Passing Year and Month
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetSimByCountry(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "SimByCountry" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@start_date", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_RPT_SIM_Country", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Get Airtime  Sold
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetAirtime(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Airtime" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@start_date", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_GetAirtime", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Get Databundle Sold
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetDatabundle(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Databundle" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@start_date", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_RPT_Databundle", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Get Phone Sold
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetPhone(string Year, string Month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "Phone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@start_date", DbType.String, Year, ParameterDirection.Input);
                objSpParameters.Add("@end_date", DbType.String, Month, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_GetPhone3", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Insert Google Data
        /// </summary>
        /// <param name="monthid"></param>
        /// <param name="yearname"></param>
        /// <param name="mycount"></param>
        /// <returns></returns>
        public object AddGoolge_Visitors_Adcost(Int32 monthid, Int32 yearname, decimal mycount)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@monthid", DbType.Int64, monthid, ParameterDirection.Input);

                objSpParameters.Add("@yearname", DbType.String, yearname, ParameterDirection.Input);

                objSpParameters.Add("@mycount", DbType.Decimal, mycount, ParameterDirection.Input);



                object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sproc_google_adcost", objSpParameters);
                return value;
            }
        }
        /// <summary>
        /// Get Google Visitors
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public DataSet GetGoogleVisitors(int FromYear, int ToYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "yearwisesale", "VisitorsYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@fromyear", DbType.Int32, FromYear, ParameterDirection.Input);
                objSpParameters.Add("@toyear", DbType.Int32, ToYear, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_googleVisitors_Select", dsDataSet, strDataTableName, objSpParameters);


                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        /// <summary>
        /// Get Google AdCost
        /// </summary>
        /// <param name="FromYear"></param>
        /// <param name="ToYear"></param>
        /// <returns></returns>
        public DataSet GetGoogleAdCost(int FromYear, int ToYear)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("Rebelconn"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName = { "yearwisesale", "AdcostYear" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.SqlServer);

                objSpParameters.Add("@fromyear", DbType.Int32, FromYear, ParameterDirection.Input);
                objSpParameters.Add("@toyear", DbType.Int32, ToYear, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sproc_googleAdcost_Select", dsDataSet, strDataTableName, objSpParameters);


                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
    }
}
