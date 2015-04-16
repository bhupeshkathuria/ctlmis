using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DalClayBilling;

/// <summary>
/// Summary description for RebelDataAccess
/// </summary>
public static class RebelDataAccess
{
    public static DataTable GetRebelBilling(string fromDate, string toDate)
    {
        using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
        {
            DataSet dsDataSetMonth1 = new DataSet();
            dsDataSetMonth1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            string[] strDataTableName = { "ByMonthReport" };
            SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
            objSpParameters.Add("_fromdate", DbType.String, fromDate, ParameterDirection.Input);
            objSpParameters.Add("_Todate", DbType.String, toDate, ParameterDirection.Input);

            objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_rebel_billing", dsDataSetMonth1, strDataTableName, objSpParameters);

            if (dsDataSetMonth1 != null && dsDataSetMonth1.Tables.Count > 0)
                return dsDataSetMonth1.Tables[0];

            return null;
        }
    }
}