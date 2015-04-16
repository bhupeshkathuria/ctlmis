using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class Page
    {
        
        #region Private Variables

        private int _pageid = 0;
        private string _pagename = string.Empty;
        private int _userid = 0;
        #endregion

        #region Public Properties

        public int PageId
        {
            get { return _pageid; }
            set { _pageid = value; }
        }

        public string PageName
        {
            get { return _pagename; }
            set { _pagename = value; }
        }

        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        #endregion

        // region for method
        #region for method

        public int PageInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               // objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("cpagename", DbType.String, _pagename, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_insert_page", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        /// <summary>
        /// method for select the page detail
        /// </summary>
        /// <param name="lorderid"></param>
        /// <returns></returns>
        public DataSet GetPageDetail()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_page",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        /// <summary>
        /// method for edit the page detail
        /// </summary>
        /// <returns></returns>
        public int PageUpdate()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("cpagename", DbType.String, _pagename, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_update_page", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        /// <summary>
        /// method for insert the page right
        /// </summary>
        /// <returns></returns>
        public int PageRightInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("cpagename", DbType.String, _pagename, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_insert_pageright", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }
        

        public DataSet GetPageRight()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page", "page2" };
               // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_user_pageright",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        

        public int PageRightDelete()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
               
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_delete_pageright", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }



        public DataSet CheckPageRight()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page", "page2" };
               // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("cpagename", DbType.String, _pagename, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_check_pageright",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }



        /// <summary>
        /// method to select the all web user
        /// </summary>
        /// <returns></returns>
        public DataSet SelectWebUser()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page"};
               // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_all_web_user",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }
        
        #endregion
    }
}
