using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using dal;

namespace Clay.Invoice.Bll
{
    public class Zones
    {
        #region Private Variables

        private int _zoneId = 0;
        private int _countryId = 0;
        private int _providerId = 0;
        private string _zoneName = string.Empty;
        private int _zoneCodeLength = 0;

        #endregion



        #region Public Properties

        public int ZoneId
        {
            get { return _zoneId; }
            set { _zoneId = value; }
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

        public string ZoneName
        {
            get { return _zoneName; }
            set { _zoneName = value; }
        }

        public int ZoneCodeLength
        {
            get { return _zoneCodeLength; }
            set { _zoneCodeLength = value; }
        }

        #endregion

        #region Public Methods

        public int NewProvider()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("czonename", DbType.String, _zoneName, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objSpParameters.Add("lcountrycodelength", DbType.Int32, _zoneCodeLength, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_zone_insert", objSpParameters);
                return value;
            }
        }

        public DataSet GetZoneByZoneId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "zone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lzoneid", DbType.Int32, _zoneId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_zones_select_byzoneid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetSubZoneByZoneId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "zone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lzoneid", DbType.Int32, _zoneId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_subzone_by_zoneid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCountryByCodeLength()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "zone" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ccountrycodelength", DbType.Int32, _zoneCodeLength, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_get_country_by_countrycodelength", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        public int NewSubZone()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lzoneid", DbType.Int32, _zoneId, ParameterDirection.Input);
                
                objSpParameters.Add("rcode", DbType.Int32, -1, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_subzone", objSpParameters);
                return value;
            }
        }

        #endregion
    }
}
