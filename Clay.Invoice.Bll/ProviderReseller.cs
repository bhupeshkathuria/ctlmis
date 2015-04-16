using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dal;

namespace Clay.Invoice.Bll
{
   public class ProviderReseller
    {
        #region Private Variables

        private int _countryId = 0;
        private int _providerId = 0;
        private string _providerName = string.Empty;
        private int _createdby = 0;
        private int _modifiedby = 0;
        private int _underProviderID = 0;
       private string _ipAddress = string.Empty;
       private string _lastIPAddrss = string.Empty;

        #endregion

        #region Public Properties

       public int CreatedBy
       {
           get { return _createdby; }
           set { _createdby = value; }
       }

       public int ModifiedBy
       {
           get { return _modifiedby; }
           set { _modifiedby = value; }
       }

       public int UnderProviderID
       {
           get { return _underProviderID; }
           set { _underProviderID = value; }
       }

       public string IPAddress
       {
           get { return _ipAddress; }
           set { _ipAddress = value; }
       }


       public string LastIPAddress
       {
           get { return _lastIPAddrss; }
           set { _lastIPAddrss = value; }
       }

        public int CountryId
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        public int ProviderId
        {
            get { return _providerId; }
            set { _providerId = value; }
        }

        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        #endregion

        #region Public Methods

        
        public DataSet GetProviderByCountryId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_provider_reseller_select_bycountryid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public DataSet GetProviderReseller()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_provider_reseller_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int NewProviderReseller()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                //objSpParameters.Add("llanguageid", DbType.Int32, _languageId, ParameterDirection.Input);
                objSpParameters.Add("cprovidername", DbType.String, _providerName, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lcreatedby", DbType.Int32, _createdby, ParameterDirection.Input);
                objSpParameters.Add("lunderproviderid", DbType.Int32, _underProviderID, ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, _ipAddress, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_provider_reseller_insert", objSpParameters);
                return value;
            }
        }

       public int EditProviderReseller()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
               objSpParameters.Add("cprovidername", DbType.String, _providerName, ParameterDirection.Input);
               objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
               objSpParameters.Add("lmodifiedby", DbType.Int32, _modifiedby, ParameterDirection.Input);
               objSpParameters.Add("lunderproviderid", DbType.Int32, _underProviderID, ParameterDirection.Input);
               objSpParameters.Add("clastipaddress", DbType.String, _lastIPAddrss, ParameterDirection.Input);
               objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
               int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_provider_reseller_edit", objSpParameters);
               return value;
           }
       }

        #endregion
    }
}
