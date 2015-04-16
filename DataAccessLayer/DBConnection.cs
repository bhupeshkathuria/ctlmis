using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
namespace DAL
{
    public class DBConnection
    {
        public static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
           
            DataTable table = null;
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return table;
        }

        public static DataSet ExecuteSelectCommandDataSet(string CommandName, CommandType cmdType, string[] TableName, MySqlParameter[] param)
        {
            DataSet table = null;

            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);
                    cmd.CommandTimeout = 600;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            table = new DataSet();

                            da.Fill(table);

                            int intIndex = 0;

                            for (intIndex = 0; intIndex < table.Tables.Count; intIndex++)
                            {
                                table.Tables[intIndex].TableName = TableName[intIndex];
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return table;
        }

        public static DataSet ExecuteSelectCommandDataSet(string CommandName, CommandType cmdType, string[] TableName)
        {
            DataSet Dstables = null;

            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            Dstables = new DataSet();

                            da.Fill(Dstables);

                            int intIndex = 0;

                            for (intIndex = 0; intIndex < Dstables.Tables.Count; intIndex++)
                            {
                                Dstables.Tables[intIndex].TableName = TableName[intIndex];
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return Dstables;
        }

        // This function will be used to execute R(CRUD) operation of parameterized commands
        public static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, MySqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return table;
        }

        public static int ExecuteNonQuery(string CommandName, CommandType cmdType)
        {
            int result = 0;
            MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString());
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("Duplicate record found.");
                }
                else
                    throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        public static int ExecuteNonQuery(string CommandName, CommandType cmdType, MySqlParameter[] pars)
        {
            System.Collections.Hashtable Outpars;
            return ExecuteNonQuery(CommandName, cmdType, pars, out Outpars);
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        public static int ExecuteNonQuery(string CommandName, CommandType cmdType, MySqlParameter[] pars, out Hashtable Outpars)
        {
            int i = 0;
            int result = 0;
            Outpars = new System.Collections.Hashtable();
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["piccellconnection"].ToString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = cmd.ExecuteNonQuery();

                        foreach (MySqlParameter parameter in cmd.Parameters)
                        {
                            if (parameter.ParameterName == "rcode")
                            {
                                i = Convert.ToInt32(parameter.Value);
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return i;
        }


    }
}
