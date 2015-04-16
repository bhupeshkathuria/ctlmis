using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace DalClayBilling
{
    /// <summary>
    /// SqlHelper class provides methods for executing database commands.
    /// SpParameters class is used as the transportation objects for passing parameters to the SqlHelper class.
    /// This class in turn builds the SqlParameters collection based on the values passed. 	
    /// </summary>
    public class CommandExecutor : IDisposable
    {

        #region Private Member Variables

        //This connection object is used for connecting to database. 
        //Connection will be opened only when needed and will be closed after the operation is performed.
        private IDbConnection dbConnection = null;

        //The static variable holding the connectionstring. Assigned based on parameter passed in the constructor
        //private string strConnectionString = null;
        private string strConnectionString = null;
        //Transaction object, Used to carry out database Transactions
        private IDbTransaction dbTransaction = null;

        //Enum to Identify the RdbmsType OleDB = 0, SqlServer=1, Oracle=2, MySql=3.
        private RdbmsType enumRdbmsType;

        #endregion Private Member Variables

        #region constructors and Set ConnectionString

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CommandExecutor()
        {
        }

        /// <summary>
        /// Constructor which accepts ApplicationID as parameter 
        /// This is a constructor method, which reads the connection string from the DbConnection.xml file
        /// for the ApplicationID passed. This constructor assigns the connection string to the strConnectionString member variable.
        /// </summary>
        /// <param name="strConnectionID">strConnection ID</param>
        public CommandExecutor(string strConnectionID)
        {
            if (strConnectionString == null)
            {
                //Taking the Config Path from WCSConfig class
                //string strConfigPath = Environment.GetEnvironmentVariable("ConfigPath");
                DataSet dsDBConnection = new DataSet();
                enumRdbmsType = (RdbmsType)3;
                Boolean test = true;
                if (test == true)
                {
                    if (strConnectionID == "dbconnection")
                    {
                       // strConnectionString = @"database=clayfac;data source=localhost;user id=root;password=clay";
                        strConnectionString = @"server=192.168.11.8;user id=billing;Password=cldfrthgfd24;database=ERPInvoicing;default command timeout=600;pooling=true";
                    }
                    
                     else if(strConnectionID == "ERPInvoicing")
                    {
                        strConnectionString = @"server=192.168.11.8;user id=clayerp;Password=cldfrthgfd24;database=clayerp;default command timeout=3600;";
                    }
                }
            }
        }

        /// <summary>
        /// This method assigns the ConnectionString parameter value to the member variable strConnectionString.
        /// This method is provided to connect to any database from the business layer by, 
        /// passing the connection string.
        /// </summary>
        /// <param name="strConnectionString">The Connection String parameter</param> 
        public void SetConnectionString(string strConnectionString1)
        {
            strConnectionString = strConnectionString1;
        }

        #endregion constructors and Set ConnectionString

        #region private utility methods
        /// <summary>
        /// This method is used to attach list of SqlParameters to an SqlCommand.
        /// This method will assign a value of DbNull to any parameter with a direction of 
        /// InputOutput and a value of null.This method is called from PrepareCommand.
        /// </summary>
        /// <param name="scCommand">The command to which the parameters will be added</param>
        /// <param name="htCommandParameters">a HashTable of SqlParameters to be added to command</param>
        private void AttachParameters(IDbCommand dbCommand,
                                    Hashtable htCommandParameters)
        {
            foreach (object oValue in htCommandParameters.Values)
            {
                IDbDataParameter dbParam = (IDbDataParameter)oValue;
                if ((dbParam.Direction == ParameterDirection.InputOutput) && (dbParam.Value == null))
                {
                    dbParam.Value = DBNull.Value;
                }
                dbCommand.Parameters.Add(dbParam);
            }
        }

        /// <summary>
        /// This method calls the open method and assigns a connection, transaction (if any), 
        /// command type and parameters to the provided command. 
        /// This method calls the GetParamArray method to get the HashTable of SqlParameters. 
        /// This method calls the AttachParameters method for attaching the parameters to the command
        /// </summary>
        /// <param name="scCommand">the SqlCommand to be prepared</param>
        /// <param name="ctCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <param name="prsCommandParameters">The parameters object which contains the HashTable of SqlParameters, to be associated with the command or 'null' if no parameters are required</param>
        private void PrepareCommand(IDbCommand dbCommand,
            CommandType ctCommandType,
            string strCommandText,
            SpParameters prsCommandParameters)
        {

            //Call the open method to open the connection
            Open();

            //associate the connection with the command
            dbCommand.Connection = dbConnection;

            //set the command text (stored procedure name or SQL statement)
            dbCommand.CommandText = strCommandText;

            //if we were provided a transaction, assign it.
            if (dbTransaction != null)
            {
                dbCommand.Transaction = dbTransaction;
            }

            //set the command type
            dbCommand.CommandType = ctCommandType;

            //attach the command parameters if they are provided
            if (prsCommandParameters != null)
            {
                AttachParameters(dbCommand, prsCommandParameters.GetParamArray());
            }

            return;

        }
        #endregion private utility methods

        #region ExecuteDBQuery
        /// <summary>
        /// Executes an SqlCommand (that returns no resultset and takes no parameters) against 
        /// the database specified in the connection string. 
        /// This method does nothing but calling the ExecuteNonQuery method providing null for the set of SqlParameters as follows 
        /// ExecuteDBQuery(commandType, commandText, (spParameters)null);
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public int ExecuteDBQuery(CommandType ctpCommandType,
                                    string strCommandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDBQuery(ctpCommandType, strCommandText, (SpParameters)null);
        }

        /// <summary>
        /// Executes an SqlCommand (that returns no resultset and takes no parameters) against the 
        /// database specified in the connection string. This method calls the PrepareCommand method, 
        /// then executing the command.
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <param name="prsCommandParameters">the object, which contains the HashTable of SqlParameters</param>
        /// <returns>an int, representing the number of rows affected by the command</returns>
        public int ExecuteDBQuery(CommandType ctpCommandType,
            string strCommandText,
            SpParameters prsCommandParameters)
        {
            //create a command and prepare it for execution
            IDbCommand dbCommand = ConnectivityFactory.GetDbCommand(enumRdbmsType);
            PrepareCommand(dbCommand, ctpCommandType, strCommandText, prsCommandParameters);

            //finally, execute the command.
            int intRetval = dbCommand.ExecuteNonQuery();           
            //int outParamVal = Convert.ToInt32(prsCommandParameters.GetOutputParamValue("rcode").ToString());

            // detach the SqlParameters from the command object, so they can be used again.
            dbCommand.Parameters.Clear();
            Close();
            return intRetval;
        }

        public int ExecuteDBQuery1(CommandType ctpCommandType,
           string strCommandText,
           SpParameters prsCommandParameters)
        {
            //create a command and prepare it for execution
            IDbCommand dbCommand = ConnectivityFactory.GetDbCommand(enumRdbmsType);
            PrepareCommand(dbCommand, ctpCommandType, strCommandText, prsCommandParameters);

            //finally, execute the command.
            int intRetval = dbCommand.ExecuteNonQuery();
            if (prsCommandParameters.GetParamArray().ContainsKey("rcode"))
                intRetval = Convert.ToInt32(prsCommandParameters.GetOutputParamValue("rcode").ToString());
            // detach the SqlParameters from the command object, so they can be used again.
            dbCommand.Parameters.Clear();
            Close();
            return intRetval;
        }
        #endregion ExecuteDBQuery

        #region ExecuteDataSet

        /// <summary>
        /// Executes an SqlCommand that fills the result into a dataset’s data tables in the order
        /// in which it comes in the array. It does nothing but calling the ExecuteDataSet providing null
        /// for the object, SpParameters
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <param name="dsDataSet">the dataSet to be filled</param>
        /// <param name="strDataTableName">an array of DataTable names in the proper order</param>
        public void ExecuteDataSet(CommandType ctpCommandType,
            string strCommandText,
            DataSet dsDataSet,
            string[] strDataTableName)
        {
            //Calling ExecuteDataSet with null SpParameters
            ExecuteDataSet(ctpCommandType, strCommandText, dsDataSet, strDataTableName, (SpParameters)null);
        }

        /// <summary>
        /// Execute an SqlCommand (that Fills a dataset) against the database specified in the 
        /// connection string using the provided parameters. 
        /// This method in turn calls PrepareCommand method and then creates an adapter and fills the dataset’s datatable(s).
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <param name="dsDataSet">the dataSet to be filled</param>
        /// <param name="strDataTableName">an array of DataTable names in the proper order</param>
        /// <param name="prsCommandParameters">the object, which contains the HashTable of SqlParameters</param>
        public void ExecuteDataSet(CommandType ctpCommandType,
            string strCommandText,
            DataSet dsDataSet,
            string[] strDataTableName,
            SpParameters prsCommandParameters)
        {
            //create a command and prepare it for execution
            IDbCommand dbCommand = ConnectivityFactory.GetDbCommand(enumRdbmsType);

            PrepareCommand(dbCommand, ctpCommandType, strCommandText, prsCommandParameters);

            //create the DataAdapter & DataSet
            IDbDataAdapter dbAdapter = ConnectivityFactory.GetDbAdapter(dbCommand);
            dbAdapter.SelectCommand = dbCommand;
            //fill the DataSet using default values for DataTable names, etc.
            dbAdapter.Fill(dsDataSet);
            int intIndex = 0;
            for (intIndex = 0; intIndex < dsDataSet.Tables.Count; intIndex++)
            {
                dsDataSet.Tables[intIndex].TableName = strDataTableName[intIndex];
            }

            // detach the SqlParameters from the command object, so they can be used again.			
            dbCommand.Parameters.Clear();
            Close();
        }
        #endregion ExecuteDataSet

        #region ExecuteScalar
        /// <summary>
        /// Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the database 
        /// specified in the connection string.
        /// It does nothing but calling the ExecuteScalar providing null for the SpParameters
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(CommandType ctpCommandType,
            string strCommandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteScalar(ctpCommandType, strCommandText, (SpParameters)null);
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a 1x1 resultset and takes no parameters) against the database
        /// specified in the SqlConnection.
        /// This method create a command and prepare it for execution, then executes it.
        /// </summary>
        /// <param name="ctpCommandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="strCommandText">the stored procedure name or T-SQL command</param>
        /// <param name="prsCommandParameters">the object, which contains the HashTable of SqlParameters</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(CommandType ctpCommandType,
            string strCommandText,
            SpParameters prsCommandParameters)
        {
            //create a command and prepare it for execution
            IDbCommand dbCommand = ConnectivityFactory.GetDbCommand(enumRdbmsType);
            PrepareCommand(dbCommand, ctpCommandType, strCommandText, prsCommandParameters);

            //execute the command & return the results
            object oRetval = dbCommand.ExecuteScalar();

            // detach the SqlParameters from the command object, so they can be used again.
            dbCommand.Parameters.Clear();
            Close();
            return oRetval;
        }
        #endregion ExecuteScalar

        #region Connection Management
        /// <summary>
        /// This method is used to create and open a connection. 
        /// This method first checks whether the connection already exists, 
        /// if not, creates a connection using the connection string. 
        /// Then checks whether the connection state is open or not if not, it opens the connection. 
        /// Called from the PrepareCommand method.
        /// </summary>
        private void Open()
        {
            if (dbConnection == null)
            {
                dbConnection = ConnectivityFactory.GetDbConnection(enumRdbmsType, strConnectionString);
            }
            //Opening the connection if it is not already opened.  
            if (dbConnection.State == ConnectionState.Closed)
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    //Open();
                }
            }
        }

        /// <summary>
        /// This method is used to Close the connection 
        /// </summary>
        private void Close()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        /// <summary>
        /// This method in turn calls the dispose method of connection object. 
        /// The class implements IDisposable interface, so that the instance of the class can be created with in a using clause,
        /// which enables the CLR to automatically call the dispose method.
        /// </summary>
        public void Dispose()
        {
            if (dbConnection != null)
            {
                dbConnection.Dispose();
                dbConnection = null;
            }

        }
        #endregion Connection Management

        #region Transaction Handling
        /// <summary>
        /// This method is used for beginning a transaction. This in turn calls the Open method, 
        /// then calls BeginTransaction() on objSqlConnection, 
        /// and assigns the transaction object returned, to the member variable objTransaction.
        /// </summary>
        public void BeginTransaction()
        {
            //Opens Connection
            this.Open();
            dbTransaction = dbConnection.BeginTransaction();
        }

        /// <summary>
        /// This method is used for committing a transaction. 
        /// Also clears the Transaction object and calls the close method.
        /// </summary>
        public void CommitTransaction()
        {
            dbTransaction.Commit();
            dbTransaction = null;
            this.Close();
        }
        /// <summary>
        /// This method is used for committing a transaction. 
        /// Also clears the Transaction object and calls the close method.
        /// </summary>
        public void RollBackTransaction()
        {
            dbTransaction.Rollback();
            dbTransaction = null;
            this.Close();
        }

        #endregion Transaction Handling
    }
}
