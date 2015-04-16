using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data;
namespace Clay.RAD
{
  public  class provider
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
      public DataSet GetProviderGroup()
      {
          using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
          {
              DataSet dsDataSet = new DataSet();
              dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
              string[] strDataTableName = { "provider" };
              SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
              objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_groupprovider_select", dsDataSet, strDataTableName, objSpParameters);

              if (dsDataSet != null)
                  return dsDataSet;

              return null;
          }
      }

      public DataSet GetProviderByCountryId()
      {
          using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
          {
              DataSet dsDataSet = new DataSet();
              dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
              string[] strDataTableName = { "provider" };
              SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
              objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
              objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_provider_select_bycountryid", dsDataSet, strDataTableName, objSpParameters);

              if (dsDataSet != null)
                  return dsDataSet;

              return null;
          }
      }
    }
}
