using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dal;
namespace Clay.Invoice.Bll
{
    public class Alert
    {
        #region Private Variables

        private int _countryId = 0;
        private int _orderid = 0;
        private string _ipAddress = string.Empty;
        private int _createdBy = 0;
        private double _alertAmount = 0;
        private int _alertMasterID = 0;
        private int _modifiedBy = 0;
        private string _lastIPAddress = string.Empty;

        #endregion

        #region Public Properties

        public int AlertMasterID
        {
            get { return _alertMasterID; }
            set { _alertMasterID = value; }
        }

        public int ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

        public string LastIPAddress
        {
            get { return _lastIPAddress; }
            set { _lastIPAddress = value; }
        }
        public int CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public string IPAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        public double AlertAmount
        {
            get { return _alertAmount; }
            set { _alertAmount = value; }
        }

        #endregion

        #region Public Methods

     
        public int AddAlertMaster()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, _orderid, ParameterDirection.Input);
                objSpParameters.Add("lcreatedby", DbType.Int32, _createdBy, ParameterDirection.Input);
                objSpParameters.Add("lalertamount", DbType.Double, _alertAmount, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipAddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_alert_master_add", objSpParameters);
                return value;
            }
        }

       

        public int AlertGenerate(double totalcost, int orderid, int countryid, DateTime month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("ltotalcost", DbType.Double, totalcost, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, orderid, ParameterDirection.Input);
                objSpParameters.Add("dmonth", DbType.Date, month, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_alert_generate", objSpParameters);
                return value;
            }
        }

        public DataSet GetAlertGenerated(int CountryIDD,int year, int month)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, CountryIDD, ParameterDirection.Input);
                objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_alert_generate_select_bycountry2", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetTotalAmount(int CountryIDD,int Orderidd)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, CountryIDD, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, Orderidd, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_alert_total_cost_select_by_pt", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetAlertMaster(int CountryIDD, int alertmasterid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, CountryIDD, ParameterDirection.Input);
                objSpParameters.Add("lalertmasterid", DbType.Int32, alertmasterid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_alert_master_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public int EditAlertMaster()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lalertmasterid", DbType.Int32, _alertMasterID, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, _orderid, ParameterDirection.Input);
                objSpParameters.Add("lmodifiedby", DbType.Int32, _modifiedBy, ParameterDirection.Input);
                objSpParameters.Add("lalertamount", DbType.Double, _alertAmount, ParameterDirection.Input);
                objSpParameters.Add("clastipaddress", DbType.String, _lastIPAddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_alert_master_edit", objSpParameters);
                return value;
            }
        }
        #endregion
    }
}
