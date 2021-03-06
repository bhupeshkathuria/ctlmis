using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class MappingFields
    {
        #region Private Variables

        private int _cdrguideId = 0;
        private int _mobilenofieldid = 0;
        private int _callednofieldid = 0;
        private int _datefieldid = 0;
        private int _timefieldid = 0;
        private int _durationfieldid = 0;
        private string _durationfieldtype = string.Empty;
        private int _costfieldid = 0;
        #endregion



        #region Public Properties

        public int CdrGuideId
        {
            get { return _cdrguideId; }
            set { _cdrguideId = value; }
        }

        public int MobileNoFieldId
        {
            get { return _mobilenofieldid; }
            set { _mobilenofieldid = value; }
        }

        public int CalledNoFieldId
        {
            get { return _callednofieldid; }
            set { _callednofieldid = value; }
        }

        public int DateFieldId
        {
            get { return _datefieldid; }
            set { _datefieldid = value; }
        }

        public int TimeFieldId
        {
            get { return _timefieldid; }
            set { _timefieldid = value; }
        }

        public int DurationFieldId
        {
            get { return _durationfieldid; }
            set { _durationfieldid = value; }
        }

        public string DurationFieldType
        {
            get { return _durationfieldtype; }
            set { _durationfieldtype = value; }
        }
        
        public int CostFieldId
        {
            get { return _costfieldid; }
            set { _costfieldid = value; }
        }

        #endregion



        #region Public Methods

        public int MappingFieldsInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrguideId", DbType.Int32, _cdrguideId, ParameterDirection.Input);
                objSpParameters.Add("lmobilenofieldid", DbType.Int32, _mobilenofieldid, ParameterDirection.Input);
                objSpParameters.Add("lcallednofieldid", DbType.Int32, _callednofieldid, ParameterDirection.Input);
                objSpParameters.Add("ldatefieldid", DbType.Int32, _datefieldid, ParameterDirection.Input);
                objSpParameters.Add("ltimefieldid", DbType.Int32, _timefieldid, ParameterDirection.Input);
                objSpParameters.Add("ldurationfieldid", DbType.Int32, _durationfieldid, ParameterDirection.Input);
                objSpParameters.Add("cdurationfieldtype", DbType.String, _durationfieldtype, ParameterDirection.Input);
                objSpParameters.Add("lcostfieldid", DbType.String, _costfieldid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_mapping_cdr_fields_insert", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public DataSet GetMappingFieldsByCdrGuideId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "mappingfields" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_mapping_cdr_fields_select_by_cdrguideid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetDurationTypeByCdrTestID(int CdrTestID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrtestid", DbType.Int32, CdrTestID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_durationtype_from_cdrtestid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }
        #endregion
    }
}
