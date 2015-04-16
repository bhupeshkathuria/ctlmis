using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using BL;
using DAL;
namespace BL
{
  public  class DBAccess_UserDetails
    {
        public DataSet GetUsersDetails(Property_UserDetails objUsers)
        {
            string[] strDataTableName = { "Users" };
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("login", objUsers.PUsersName),
                new MySqlParameter("pass", objUsers.PUsersPwd)
            };
            using (DataSet ds = DBConnection.ExecuteSelectCommandDataSet("usp_getCustomerLogin", CommandType.StoredProcedure, strDataTableName, parameters))
            {
                return ds;
            }
        }
        public int Change_Password(Property_UserDetails objUsers)
        {
            MySqlCommand cmd = new MySqlCommand();
            int result = 0;
            MySqlParameter OutParameter = new MySqlParameter();
            OutParameter.ParameterName = "rcode";
            OutParameter.Value = "0";
            OutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(OutParameter);
            MySqlParameter[] parameters = new MySqlParameter[]
            {                
                new MySqlParameter("CustomerId", objUsers.PUserId),
                new MySqlParameter("OldPassword", objUsers.PUsersPwd),
                      new MySqlParameter("Cpassword", objUsers.PUsersNewPwd),
                OutParameter
            };
            result = DBConnection.ExecuteNonQuery("usp_change_password", CommandType.StoredProcedure, parameters);
            return result;
        }



    }
}
