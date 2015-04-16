using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class CdrGuideFields
    {
        #region Private Variables

        private int _cdrguideid = 0;
        private int _cdrfieldid = 0;
        private string _fieldname = string.Empty;
        private string _fieldtype = string.Empty;
        private int _fieldminlength = 0;
        private int _fieldmaxlength = 0;
        private int _sequence = 0;
        private int _countryId = 0;
        private int _providerId = 0;
        private string _details = string.Empty;

        #endregion



        #region Public Properties

        public int CdrGuideId
        {
            get { return _cdrguideid; }
            set { _cdrguideid = value; }
        }
        public int CdrFieldId
        {
            get { return _cdrfieldid; }
            set { _cdrfieldid = value; }
        }
        public string CdrFiledName
        {
            get { return _fieldname; }
            set { _fieldname = value; }
        }
        public string CdrFiledType
        {
            get { return _fieldtype; }
            set { _fieldtype = value; }
        }
        public int CdrFieldMinLength
        {
            get { return _fieldminlength; }
            set { _fieldminlength = value; }
        }
        public int CdrFieldMaxLength
        {
            get { return _fieldmaxlength; }
            set { _fieldmaxlength = value; }
        }
        public int CdrFieldSequence
        {
            get { return _sequence; }
            set { _sequence = value; }
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

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        #endregion



        #region Public Methods

        public object CdrGuideFieldsInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrguide_id", DbType.Int32, _cdrguideid, ParameterDirection.Input);
                objSpParameters.Add("cfieldname", DbType.String, _fieldname, ParameterDirection.Input);
                objSpParameters.Add("cfieldtype", DbType.String, _fieldtype, ParameterDirection.Input);
                objSpParameters.Add("lfieldminlength", DbType.Int16, _fieldminlength, ParameterDirection.Input);
                objSpParameters.Add("lfieldmaxlength", DbType.Int16, _fieldmaxlength, ParameterDirection.Input);
                objSpParameters.Add("lsequence", DbType.Int16, _sequence, ParameterDirection.Input);
                objSpParameters.Add("cdetails", DbType.String, _details, ParameterDirection.Input);
                object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_cdrguidefields_insert", objSpParameters);
                return value;
            }
        }

        public DataSet GetCdrFieldsByCdrGuideId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidefields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidefields_select_bycdrguideid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrFieldByCdrFieldId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidefields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrfieldid", DbType.Int32, _cdrfieldid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidefields_select_bycdrfieldid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrFieldsByCountryIdAndProviderId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidefields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidefields_select_bycountryid_providerid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrFieldsByCountryIdAndProviderIdStringNumeric()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidefields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidefields_select_countryid_provideridstringnumeric", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrFieldsByCountryIdAndProviderIdDuration()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguidefields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguidefields_select_countryid_provideridduration", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

            public object CdrMappingCostFieldsInsert(int mappingid, int cdrguideid, int costfieldid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lmappingid", DbType.Int32, mappingid, ParameterDirection.Input);
                objSpParameters.Add("lcdrguideid", DbType.Int32, cdrguideid, ParameterDirection.Input);
                objSpParameters.Add("lcostfieldid", DbType.Int32, costfieldid, ParameterDirection.Input);
                object value = objCommandExecutor.ExecuteDBQuery1(CommandType.StoredProcedure, "sp_mappingcostfield_insert", objSpParameters);
                return value;
            }
        }


        
        #endregion
    }
}
