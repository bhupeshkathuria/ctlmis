using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dal;

namespace Clay.Invoice.Bll
{
    public  class RAFFilter2
    {
        #region User Defined Method

        public DataSet GetSalesOrderFilterOnBilling(string mobileNo, string orderId, string dtFrom, string dtTo)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);                
                objSpParameters.Add("cmobileno", DbType.String, mobileNo, ParameterDirection.Input);
                objSpParameters.Add("corderid", DbType.String, orderId, ParameterDirection.Input);
                objSpParameters.Add("dtfrom", DbType.String, dtFrom, ParameterDirection.Input);
                objSpParameters.Add("dtto", DbType.String, dtTo, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesorder_select_billing",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetSalesOrderFilterOnBillingWithItems(int InventoryId, string SearchFor)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "salesorder" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ctype", DbType.String, SearchFor, ParameterDirection.Input);
                objSpParameters.Add("linventoryid", DbType.Int32, InventoryId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_salesorder_filteritemonbilling",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        #endregion
    }
}
