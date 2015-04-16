using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
//using Oracle.DataAccess.Client;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace DalClayBilling
{
    /// SpParameters class provides Methods to Add sql parameters 
    /// to the HashTable of SqlParameters.
    /// </summary>
    public class SpParameters
    {
        #region Private Member Variable
        //Member variable of Type HashTable to hold the collection of Parameters.
        private Hashtable htDbParameter;
        private RdbmsType enumRdbmsType;
        #endregion Private Member Variable

        #region Constructor
        /// <summary>
        /// Constructor method, which instantiates the HashTable member variable.
        /// </summary>
        public SpParameters(RdbmsType enumRdbmsType)
        {
            htDbParameter = new Hashtable();
            this.enumRdbmsType = (RdbmsType)3;//enumRdbmsType;
        }
        #endregion Constructor

        #region HashTable
        /// <summary>
        /// This method is used to build and add SqlParameters to the HashTable member variable. 
        /// SqlParameter will be generated based on the parameters passed to this method.
        /// </summary>
        /// <param name="strParamName">Name of the parameter</param>
        /// <param name="dbtDataType">Data type of the parameter. Should be chosen from the enum System.data.SqlType</param>
        /// <param name="pdDirection">Direction of the parameter Should be chosen from the enum System.data.ParameterDirection</param>
        /// <param name="oValue">Parameter value</param>
        public void Add(string strParamName,
            DbType dbtDataType,
            object oValue,
            ParameterDirection pdDirection)
        {
            Add(strParamName, dbtDataType, 0, oValue, pdDirection);

        }

        /// <summary>
        /// This method is used to build and add SqlParameters to the HashTable member variable. 
        /// SqlParameter will be generated based on the parameters passed to this method.
        /// </summary>
        /// <param name="strParamName">Name of the parameter</param>
        /// <param name="stDataType">Data type of the parameter. Should be chosen from the enum System.data.SqlType</param>
        /// <param name="intSize">Size of the parameter</param> 
        /// <param name="pdDirection">Direction of the parameter Should be chosen from the enum System.data.ParameterDirection</param>
        /// <param name="oValue">Parameter value</param>
        public void Add(string strParamName,
            DbType dbtDataType,
            int intSize,
            object oValue,
            ParameterDirection pdDirection)
        {

            IDbDataParameter dbParameter = ConnectivityFactory.GetDbParam(enumRdbmsType);
            dbParameter.ParameterName = strParamName;
            dbParameter.DbType = dbtDataType;
            //Assigning  direction
            dbParameter.Direction = pdDirection;

            //Assumption, For dataypes which does n't need a size, 0 will be passed.
            if (intSize > 0)
            {
                dbParameter.Size = intSize;
            }
            //Assigning  value if direction is not output and value is not null 
            if ((pdDirection != ParameterDirection.Output) && (oValue != null))
            {
                dbParameter.Value = oValue;
            }

            //Adding to Hashtable member variable
            htDbParameter.Add(strParamName, dbParameter);
        }

        /// <summary>
        /// Clears the Hashtable.
        /// </summary>
        /// 

        public void ClearParameters()
        {
            htDbParameter.Clear();
        }

        /// <summary>
        /// This method is used for returning the HashTable, which stores the Collection of SqlParameter object.
        /// </summary>
        /// <returns>Returns an HashTable which stores the Collection of SqlParameter object</returns>
        public Hashtable GetParamArray()
        {
            return htDbParameter;
        }

        /// <summary>
        /// This method is used for returning the value of the output parameter passed.
        /// </summary>
        /// <param name="strParamName">Name of the output parameter</param>
        /// <returns>object Representing the output parameter value</returns>
        public object GetOutputParamValue(string strParamName)
        {
            return ((IDbDataParameter)htDbParameter[strParamName]).Value;
        }

        #endregion HashTable
    }
}
