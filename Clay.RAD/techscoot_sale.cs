using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data;
namespace Clay.RAD
{
   public class techscoot_sale
    {
       public DataSet GetDailySale(DateTime from, DateTime To,string _flag)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("techscoot"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Techscoot" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("_fromdate", DbType.DateTime, from, ParameterDirection.Input);
               objSpParameters.Add("_todate", DbType.DateTime, To, ParameterDirection.Input);
               objSpParameters.Add("_flagstatus", DbType.String, _flag, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_getcarddetail_rpt",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       //public DataSet GetDailyTotalSale(DateTime from, DateTime To)
       //{
       //    using (CommandExecutor objCommandExecutor = new CommandExecutor("techscoot"))
       //    {
       //        DataSet dsDataSet = new DataSet();
       //        string[] strDataTableName = { "Techscoot","Bingsale" };
       //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

       //        objSpParameters.Add("_fromdate", DbType.DateTime, from, ParameterDirection.Input);
       //        objSpParameters.Add("_todate", DbType.DateTime, To, ParameterDirection.Input);
       //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_selectTotalSale_new",
       //                                                        dsDataSet, strDataTableName, objSpParameters);

       //        if (dsDataSet != null)
       //            return dsDataSet;

       //        return null;
       //    }
       //}
       public DataSet GetDailyTotalSale(DateTime from, DateTime To)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("techscoot"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Techscoot" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("_fromdate", DbType.DateTime, from, ParameterDirection.Input);
               objSpParameters.Add("_todate", DbType.DateTime, To, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_selectTotalSale",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetDailyTotalSaleMap()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("techscoot"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Techscoot" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               //objSpParameters.Add("_fromdate", DbType.DateTime, from, ParameterDirection.Input);
               //objSpParameters.Add("_todate", DbType.DateTime, To, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salemapwise",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
    }
}
