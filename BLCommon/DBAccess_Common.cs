using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using DAL;
namespace BLCommon
{
   public  class DBAccess_Common
    {
       public DataSet GetCountry()
       {
           string[] strDataTableName = { "country" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("invt_get_country", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       public DataSet GetProviderDetailsByCountry(Property_Common objBilling)
       {
           string[] strDataTableName = { "provider" };
           MySqlParameter[] parameters = new MySqlParameter[]
            { 
                  new MySqlParameter("lcountry_id",objBilling.CountryId)
         
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("inventory_provider_select_by_countryid", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       public DataSet GetPaymentType()
       {
           string[] strDataTableName = { "paymenttype" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sale_report_Payment_Type", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }

       public DataSet GetBranch()
       {
           string[] strDataTableName = { "branch" };
           MySqlParameter[] parameters = new MySqlParameter[]
            {
              
            };
           using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("sp_branch_select_ddl", CommandType.StoredProcedure, strDataTableName, parameters))
           {
               return ds;
           }
       }
    }
}
