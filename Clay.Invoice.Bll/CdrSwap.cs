using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using dal;

namespace Clay.Invoice.Bll
{
   public class CdrSwap
    {
        #region Private Variables

        private int _countryId = 0;
        private int _providerId = 0;
       
        private int _calltypeid = 0;
       
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

        

        public int CallTypeId
        {
            get { return _calltypeid; }
            set { _calltypeid = value; }
        }

       
        #endregion

       #region Public Methods

       public int CdrSwapInsert()
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
           {
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("lproviderid", DbType.Int32, _providerId, ParameterDirection.Input);
               objSpParameters.Add("lcountryid", DbType.Int32, _countryId, ParameterDirection.Input);
               objSpParameters.Add("lcalltypeid", DbType.Int32, _calltypeid, ParameterDirection.Input);
               objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
               objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_insert_cdrswap", objSpParameters);
               object objRcode = objSpParameters.GetOutputParamValue("rcode");
               int intRcode = int.Parse(objRcode.ToString());
               return intRcode;
           }
       }

       #endregion
    }
}
