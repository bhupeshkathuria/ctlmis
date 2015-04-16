using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dal;

namespace Clay.Invoice.Bll
{
    public class CdrException
    {
        #region Private Variables

        private int _cdrguideid = 0;
        private int _cdrfieldid = 0;
        private string _exceptionval = string.Empty;
        private string _alternatevalue = string.Empty;
        private string _trimvalue = string.Empty;
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
        public string ExceptionVal
        {
            get { return _exceptionval; }
            set { _exceptionval = value; }
        }
        public string AlternateVal
        {
            get { return _alternatevalue; }
            set { _alternatevalue = value; }
        }
        public string TrimVal
        {
            get { return _trimvalue; }
            set { _trimvalue= value; }
        }

        #endregion

        #region Public Methods

        public int CdrExceptionInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideid, ParameterDirection.Input);
                objSpParameters.Add("lcdrguidefieldid", DbType.Int32, _cdrfieldid, ParameterDirection.Input);
                objSpParameters.Add("cexceptionval", DbType.String, _exceptionval, ParameterDirection.Input);
                objSpParameters.Add("calternatevalue", DbType.String, _alternatevalue, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_cdrexception", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }
        public int CdrExceptionInsertTrim()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objSpParameters.Add("lcdrguideid", DbType.Int32, _cdrguideid, ParameterDirection.Input);
                objSpParameters.Add("lcdrguidefieldid", DbType.Int32, _cdrfieldid, ParameterDirection.Input);
                objSpParameters.Add("ctrimval", DbType.String, _trimvalue, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_cdrexception_trim", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        #endregion
    }
}
