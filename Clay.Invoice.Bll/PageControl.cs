using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class PageControl
    {
        #region Private Variables

        private int _controlid = 0;
        private int _pageid = 0;
        private string _controlname = string.Empty;
        private string _controltype = string.Empty;
        private int _userid = 0;
        #endregion

        #region Public Properties


        public int ControlId
        {
            get { return _controlid; }
            set { _controlid = value; }
        }
        public int PageId
        {
            get { return _pageid; }
            set { _pageid = value; }
        }

        public string ControlName
        {
            get { return _controlname; }
            set { _controlname = value; }
        }

        public string ControlType
        {
            get { return _controltype; }
            set { _controltype = value; }
        }

        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        #endregion

        // region for method
        #region for method

        public int ControlInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("ccontrolname", DbType.String, _controlname, ParameterDirection.Input);
                objSpParameters.Add("ccontroltype", DbType.String, _controltype, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_insert_control", objSpParameters);
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
        public DataSet GetControlDetail()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcontrolid", DbType.Int32, _controlid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_allControl",
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
        public int ControlUpdate()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcontrolid", DbType.Int32, _controlid, ParameterDirection.Input);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("ccontrolname", DbType.String, _controlname, ParameterDirection.Input);
                objSpParameters.Add("ccontroltype", DbType.String, _controltype, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_update_control", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        /// <summary>
        /// method for insert the page right
        /// </summary>
        /// <returns></returns>
        public int PageControlRightInsert()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lcontrolid", DbType.Int32, _controlid, ParameterDirection.Input);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("ccontrolname", DbType.String, _controlname, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_insert_control_right", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }


        public DataSet GetControlRight()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page", "page2" };
                // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_user_controlright",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public void PageRightDelete()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objSpParameters.Add("lcontrolid", DbType.Int32, _controlid, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);

                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_web_delete_controlrightsecond", objSpParameters);
               
            }
        }



        public DataSet CheckControlRight()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page", "page2" };
                // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("luserid", DbType.Int32, _userid, ParameterDirection.Input);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                //objSpParameters.Add("ccontrolname", DbType.String, _controlname, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_check_controlright",
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
        public DataSet GetPageParentControl()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                DataSet dsDataSet = new DataSet();
                string[] strDataTableName ={ "page" };
                // string[] strDataTableName2 ={  };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpageid", DbType.Int32, _pageid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_web_select_page_parent_control",
                                                                dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        #endregion
    }
}
