using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dal;

namespace Clay.Invoice.Bll
{
    public class Provider
    {
        #region Private Variables

        private int _countryId = 0;
        private int _providerId = 0;
        private string _providerName = string.Empty;

        #endregion

        #region Public Properties

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
                objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_provider_select_bycountryid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetProviderByProviderId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "provider" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lprovider_id", DbType.Int32, _providerId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_provider_select_byproviderid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public int NewProvider()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                //objSpParameters.Add("llanguageid", DbType.Int32, _languageId, ParameterDirection.Input);
                objSpParameters.Add("cprovider_name", DbType.String, _providerName, ParameterDirection.Input);
                objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_provider_insert", objSpParameters);
                return value;
            }
        }

        public int EditProvider()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lprovider_id", DbType.Int32, _providerId, ParameterDirection.Input);
                objSpParameters.Add("cprovider_name", DbType.String, _providerName, ParameterDirection.Input);
                objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_provider_edit", objSpParameters);
                return value;
            }
        }

        #endregion
    }
}
