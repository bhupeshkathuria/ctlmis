using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using BL;
using DAL;

namespace BusinessLayer
{
   public class DbAccess_Billing
    {
       public DataSet GetBillingReports(Property_Billing objBilling)
       {
           string[] strDataTableName = { "Billing" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
                new MySqlParameter("contryid",objBilling.CountryId)
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_Billing_contracts", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       public DataSet GetBillingReportsDetails(Property_Billing objBilling)
       {
           string[] strDataTableName = { "Billing" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("lInvoicingid",objBilling.InvoicingId)
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_Billing_contracts_Details", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }


       public DataSet GetSaleReports(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
                  
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_SaleTotalContract_Countrywise", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       public DataSet GetSaleReportsDetails(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
                  new MySqlParameter("contryid",objBilling.CountryId)
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_salereportDetails", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       //public DataSet GetRevenueReportsDetails(Property_Billing objBilling)
       //{
       //    string[] strDataTableName = { "revenue" };
       //    MySqlParameter[] parameters = new MySqlParameter[]
       //     {
       //         new MySqlParameter("years", objBilling.Years),
       //         new MySqlParameter("lproviderid", objBilling.ProviderId),
       //           new MySqlParameter("lcountryid",objBilling.CountryId)
         
       //     };
       //    using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_revenuereport_Details", CommandType.StoredProcedure, strDataTableName, parameters))
       //    {
       //        return ds;
       //    }
       //}
       //public DataSet GetRevenueReportsBranchwiseDetails(Property_Billing objBilling)
       //{
       //    string[] strDataTableName = { "revenue" };
       //    MySqlParameter[] parameters = new MySqlParameter[]
       //     {
       //         new MySqlParameter("years", objBilling.Years),
       //            new MySqlParameter("months", objBilling.Months),
       //         new MySqlParameter("lproviderid", objBilling.ProviderId),
       //           new MySqlParameter("lcountryid",objBilling.CountryId)
         
       //     };
       //    using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_revenuereport_BranchwiseDetails", CommandType.StoredProcedure, strDataTableName, parameters))
       //    {
       //        return ds;
       //    }
       //}

    

       public DataSet GetRevenueReportsDetails(Property_Billing objBilling)
       {
           string[] strDataTableName = { "revenue" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("years", objBilling.Years),
                new MySqlParameter("lproviderid", objBilling.ProviderId),
                  new MySqlParameter("lcountryid",objBilling.CountryId),
          new MySqlParameter("months",objBilling.MonthsMultiple),
           new MySqlParameter("lpaymenttypeid",objBilling.PaymentTypeId),
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_revenuereport_Details", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetRevenueReportsBranchwiseDetails(Property_Billing objBilling)
       {
           string[] strDataTableName = { "revenue" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("years", objBilling.Years),
                   new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("lproviderid", objBilling.ProviderId),
                  new MySqlParameter("lcountryid",objBilling.CountryId),
                   new MySqlParameter("llanguageid",objBilling.LanguageId),
                    new MySqlParameter("lpaymenttypeid",objBilling.PaymentTypeId)
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_revenuereport_BranchwiseDetails", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       //Sales DashBoard
       public DataSet GetSaleDashboardBranchwise(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.MonthsMultiple),
                new MySqlParameter("years", objBilling.Years),
                  
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_branchwise", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardBranchwiseDetails(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.MonthsMultiple),
                new MySqlParameter("years", objBilling.Years),
                 new MySqlParameter("planguageid", objBilling.LanguageId),
                  
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_salebashboard_branchwiseDetails", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardBranchwisenew(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.MonthsMultiple),
                new MySqlParameter("years", objBilling.Years),
                  
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_branchwisenew", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardBranchwiseDetailsnew(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_branchwisedetailsnew", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardCountrywiseDetailsnew(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_countrywisedetailsnew", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardBranchwiseDetailsnewlast(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
                 new MySqlParameter("planguageid", objBilling.LanguageId),
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_branchwisedetailsnewlast", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardCountrywiseDetailsnewlast(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.Months),
                new MySqlParameter("years", objBilling.Years),
                 new MySqlParameter("pcountryid", objBilling.CountryId),
                   new MySqlParameter("pproviderid", objBilling.ProviderId),
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saledashboard_countrywisedetailsnewlast", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
       public DataSet GetSaleDashboardCountrywisenew(Property_Billing objBilling)
       {
           string[] strDataTableName = { "sale" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("months", objBilling.MonthsMultiple),
                new MySqlParameter("years", objBilling.Years),
                  
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_saleDashboard_coountrywisenew", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

    }
}
