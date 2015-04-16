using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace dal
{
    public enum RdbmsType
    {
        OleDB = 0,
        SqlServer,
        Oracle,
        MySql
    }

    /// <summary>
    /// Summary description for ConnectivityFactory.
    /// </summary>
    public abstract class ConnectivityFactory
    {
        /// <summary>
        /// This Method is used to return an IDbConnection 
        /// for the given Connection Type
        /// </summary>
        /// <param name="EnumConnectionType">Enum represents the RDBMS Type</param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(RdbmsType enumConnectionType)
        {
            try
            {
                switch (enumConnectionType)
                {
                    case RdbmsType.OleDB:
                        return new OleDbConnection();
                    case RdbmsType.SqlServer:
                        return new SqlConnection();
                    case RdbmsType.Oracle:
                        return new OracleConnection();
                    case RdbmsType.MySql:
                        return new MySqlConnection();
                    default:
                        throw new InvalidExpressionException(string.Format("Unable to determine connection type for '{0}'.", enumConnectionType.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbConnection for the given Command Type
        /// </summary>
        /// <param name="cmdIDbCommand">Command for which the connection is needed</param>			</param>
        /// <param name="strConnectionString">Connection String</param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(IDbCommand cmdIDbCommand, String strConnectionString)
        {
            try
            {

                cmdIDbCommand.CommandTimeout = 600;

                if (cmdIDbCommand is OleDbCommand)
                {
                    return new OleDbConnection(strConnectionString);
                }
                else if (cmdIDbCommand is SqlCommand)
                {
                    return new SqlConnection(strConnectionString);
                }

                else if (cmdIDbCommand is OracleCommand)
                {
                    return new OracleConnection(strConnectionString);
                }
                else if (cmdIDbCommand is MySqlCommand)
                {

                    return new MySqlConnection(strConnectionString);
                }


                else
                {
                    throw new InvalidExpressionException("Unsupported connection type.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbConnection for the given connection Type and Connection String
        /// </summary>
        /// <param name="EnumConnectionType">Represents type of connection</param>
        /// <param name="strConnectionString">ConnectionString</param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(RdbmsType enumConnectionType, String strConnectionString)
        {
            try
            {

                switch (enumConnectionType)
                {
                    case RdbmsType.OleDB:
                        return new OleDbConnection(strConnectionString);
                    case RdbmsType.SqlServer:
                        return new SqlConnection(strConnectionString);
                    case RdbmsType.Oracle:
                        return new OracleConnection(strConnectionString);
                    case RdbmsType.MySql:

                        return new MySqlConnection(strConnectionString);
                    default:
                        throw new InvalidExpressionException(string.Format("Unable to determine connection type for '{0}'.", enumConnectionType.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbCommand for the given Connection Type
        /// </summary>
        /// <param name="connectionName">Enum represents the RDBMS Type</param>
        /// <returns></returns>
        public static IDbCommand GetDbCommand(RdbmsType enumConnectionType)
        {
            try
            {
                switch (enumConnectionType)
                {
                    case RdbmsType.OleDB:
                        return new OleDbCommand();
                    case RdbmsType.SqlServer:
                        return new SqlCommand();
                    case RdbmsType.Oracle:
                        return new OracleCommand();
                    case RdbmsType.MySql:
                        return new MySqlCommand();
                    default:
                        throw new InvalidExpressionException(string.Format("Unable to determine connection type for '{0}'.", enumConnectionType.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbCommand for the given Connection Type
        /// </summary>
        /// <param name="cnnIDbConnection">IDbConnection of the given type</param>
        /// <returns></returns>
        public static IDbCommand GetDbCommand(IDbConnection cnnIDbConnection)
        {
            try
            {
                if (cnnIDbConnection is OleDbConnection)
                {
                    return new OleDbCommand();
                }
                else if (cnnIDbConnection is SqlConnection)
                {
                    return new SqlCommand();
                }
                else if (cnnIDbConnection is OracleConnection)
                {
                    return new OracleCommand();
                }
                else if (cnnIDbConnection is MySqlConnection)
                {
                    return new MySqlCommand();
                }

                else
                {
                    throw new InvalidExpressionException("Unsupported connection type.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  This Method is used to return an IDbDataAdapter for the given Connection Type
        /// </summary>
        /// <param name="cmdIDbCommand">IDbCommand of the given type</param>
        /// <returns></returns>
        public static IDbDataAdapter GetDbAdapter(IDbCommand cmdIDbCommand)
        {
            try
            {
                cmdIDbCommand.CommandTimeout = 600;
                if (cmdIDbCommand is OleDbCommand)
                {
                    return new OleDbDataAdapter();
                }
                if (cmdIDbCommand is SqlCommand)
                {
                    return new SqlDataAdapter();
                }
                if (cmdIDbCommand is OracleCommand)
                {
                    return new OracleDataAdapter();
                }
                if (cmdIDbCommand is MySqlCommand)
                {
                    return new MySqlDataAdapter();
                }

                else
                {
                    throw new InvalidExpressionException("Unsupported connection type.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbDataParameter for the given Command Type
        /// </summary>
        /// <param name="cmdIDbCommand">IDbCommand of the given type</param>
        /// <returns></returns>
        public static IDbDataParameter GetDbParam(IDbCommand cmdIDbCommand)
        {
            try
            {
                cmdIDbCommand.CommandTimeout = 600;
                if (cmdIDbCommand is OleDbCommand)
                {
                    return new OleDbParameter();
                }
                if (cmdIDbCommand is SqlCommand)
                {
                    return new SqlParameter();
                }
                if (cmdIDbCommand is OracleCommand)
                {
                    return new OracleParameter();
                }
                if (cmdIDbCommand is MySqlCommand)
                {
                    return new MySqlParameter();
                }
                else
                {
                    throw new InvalidExpressionException("Unsupported connection type.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to return an IDbDataAdapter for the given Connection Type
        /// </summary>
        /// <param name="cmdIDbCommand">IDbCommand of the given type</param>
        /// <returns></returns>
        public static IDbDataParameter GetDbParam(RdbmsType enumConnectionType)
        {
            try
            {
                switch (enumConnectionType)
                {
                    case RdbmsType.OleDB:
                        return new OleDbParameter();
                    case RdbmsType.SqlServer:
                        return new SqlParameter();
                    case RdbmsType.Oracle:
                        return new OracleParameter();
                    case RdbmsType.MySql:
                        return new MySqlParameter();
                    default:
                        throw new InvalidExpressionException(string.Format("Unable to determine connection type for '{0}'.", enumConnectionType.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
