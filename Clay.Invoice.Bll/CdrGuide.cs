using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
   public class CdrGuide
    {
        #region Private Variables

        private int _countryId = 0;
        private int _providerId = 0;
        private string _cfiletype = string.Empty;
        private string _cip = string.Empty;
        private int _cdrguideId = 0;
       private int _headerincluded = 0;
       private int _skiptoprows = 0;
       private int _skiptoprowsnumber = 0;
       private int _skipbottomrows = 0;
       private int _skipbottomrowsnumber = 0;
       private int _skipfiletype = 0;
       private string _delimiter = string.Empty;
       private string _splitter = string.Empty;
       private int _secondAvailableYN = 0;
       private int _billingcycleStart = 0;

        #endregion

        #region Public Properties

       public int BillingCycleStart
       {
           get { return _billingcycleStart; }
           set { _billingcycleStart = value; }
       }

       public int SecondAvailableYN
       {
           get { return _secondAvailableYN; }
           set { _secondAvailableYN =value; }
       }
       public int HeaderIncluded
       {
           get { return _headerincluded; }
           set { _headerincluded = value; }
       }

       public int SkipTopRows
       {
           get { return _skiptoprows; }
           set { _skiptoprows = value; }
       }

       public int SkipTopRowsNumber
       {
           get { return _skiptoprowsnumber; }
           set { _skiptoprowsnumber = value; }
       }

       public int SkipBottomRows
       {
           get { return _skipbottomrows; }
           set { _skipbottomrows = value; }
       }

       public int SkipBottomRowsNumber
       {
           get { return _skipbottomrowsnumber; }
           set { _skipbottomrowsnumber = value; }
       }

       public int SkipFileType
       {
           get { return _skipfiletype; }
           set { _skipfiletype = value; }
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

       public string Delimitter
       {
           get { return _delimiter; }
           set { _delimiter = value; }
       }

       public string Splitter
       {
           get { return _splitter; }
           set { _splitter = value; }
       }

        public string CFileType
        {
            get { return _cfiletype; }
            set { _cfiletype = value; }
        }

        public string Ip
        {
            get { return _cip; }
            set { _cip = value; }
        }

        public int CdrGuideId
        {
            get { return _cdrguideId; }
            set { _cdrguideId = value; }
        }

        #endregion

        #region Public Methods

        public int CdrGuideInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcountry_id", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lprovider_id", DbType.Int32, _providerId, ParameterDirection.Input);
                objSpParameters.Add("cfiletype", DbType.String, _cfiletype, ParameterDirection.Input);
                objSpParameters.Add("cip", DbType.String, _cip, ParameterDirection.Input);
                objSpParameters.Add("lheaderincluded", DbType.Int32, _headerincluded, ParameterDirection.Input);
                objSpParameters.Add("lskiptoprows", DbType.Int32, _skiptoprows, ParameterDirection.Input);
                objSpParameters.Add("lskiptoprowsnumber", DbType.Int32, _skiptoprowsnumber, ParameterDirection.Input);
                objSpParameters.Add("lskipbottomrows", DbType.Int32, _skipbottomrows, ParameterDirection.Input);
                objSpParameters.Add("lskipbottomrowsnumber", DbType.Int32, _skipbottomrowsnumber, ParameterDirection.Input);
                objSpParameters.Add("lskipfiletype", DbType.Int32, _skipfiletype, ParameterDirection.Input);
                objSpParameters.Add("cdelimiter", DbType.String, _delimiter, ParameterDirection.Input);
                objSpParameters.Add("csplitter", DbType.String, _splitter, ParameterDirection.Input);
                objSpParameters.Add("lsecondavailableyn", DbType.Int32, _secondAvailableYN, ParameterDirection.Input);
                objSpParameters.Add("lbillingcyclestart", DbType.Int32, _billingcycleStart, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_cdrguide_insert", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

       public int CdrGuideUpdate()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideId, ParameterDirection.Input);
               objSpParameters.Add("lheaderincluded", DbType.Int32, _headerincluded, ParameterDirection.Input);
               objSpParameters.Add("lskiptoprows", DbType.Int32, _skiptoprows, ParameterDirection.Input);
               objSpParameters.Add("lskiptoprowsnumber", DbType.Int32, _skiptoprowsnumber, ParameterDirection.Input);
               objSpParameters.Add("lskipbottomrows", DbType.Int32, _skipbottomrows, ParameterDirection.Input);
               objSpParameters.Add("lskipbottomrowsnumber", DbType.Int32, _skipbottomrowsnumber, ParameterDirection.Input);
               objSpParameters.Add("lskipfiletype", DbType.Int32, _skipfiletype, ParameterDirection.Input);
               objSpParameters.Add("cdelimiter", DbType.String, _delimiter, ParameterDirection.Input);
               objSpParameters.Add("csplitter", DbType.String, _splitter, ParameterDirection.Input);
               objSpParameters.Add("lsecondavailableyn", DbType.Int32, _secondAvailableYN, ParameterDirection.Input);
               objSpParameters.Add("lbillingcyclestart", DbType.Int32, _billingcycleStart, ParameterDirection.Input);
               objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
               objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_cdrguide_update", objSpParameters);
               object objRcode = objSpParameters.GetOutputParamValue("rcode");
               int intRcode = int.Parse(objRcode.ToString());
               return intRcode;
           }
       }

        public DataSet GetCdrGuideByCdrGuideId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguide" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideId, ParameterDirection.Input);
                objSpParameters.Add("lcountryId", DbType.Int32, _countryId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguide_select_bycdrguideid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCdrGuideByCountryIdProviderId()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "cdrguide" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_cdrguide_select_bycountryid_providerid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        #endregion
    }
}
