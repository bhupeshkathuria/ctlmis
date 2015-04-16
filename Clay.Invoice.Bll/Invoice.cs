using System;
using System.Collections.Generic;
using System.Text;
using dal;
using System.Data;

namespace Clay.Invoice.Bll
{
    public class Invoice
    {
        #region Public Methods

        public DataSet GetInvoicingDetails(int InvoiceTypeID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("invoicetypeid", DbType.Int32, InvoiceTypeID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_invoicing_details", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetInvoiceDetailsByInvoicingID(int InvoicingID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                //objSpParameters.Add("linvoicetypeid", DbType.Int32, invoiceTypeID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_invoice_details_ByInvoicingID", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetInvoiceDetailsByInvoicingIDWEB(int InvoicingID, int invoiceTypeID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                objSpParameters.Add("linvoicetypeid", DbType.Int32, invoiceTypeID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_invoice_details_ByInvoicingIDweb", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetInvoiceDetailsByInvoiceID(int InvoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoiceid", DbType.Int32, InvoiceID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_invoice_details_by_invoiceid", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        // Crate a Function for Rollback Invoice Details by Deepak on 22-Oct-2010
        public DataSet GetInvoicingDetailByID(int InvoicingID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_select_invoicing_details_byid", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetRollbackInvoiceByID(int InvoicingID, int InvoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                objSpParameters.Add("linvoiceid", DbType.Int32, InvoiceID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_rollbackinvoice_select_by_invoicingid_invoiceid", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public int DeleteInvoiceDetails(int InvoicingID, int InvoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                objSpParameters.Add("linvoiceid", DbType.Int32, InvoiceID, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_invoice_detail_delete", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public int DeleteInvoiceDetailsOld(int InvoicingID, int InvoiceID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("linvoicingid", DbType.Int32, InvoicingID, ParameterDirection.Input);
                objSpParameters.Add("linvoiceid", DbType.Int32, InvoiceID, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_invoice_detail_delete_old", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }


        public DataSet GetUnbilledMainByID(int Rollbackunbilledmainid, int UnbilledTypeID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrollbackunbilledmainid", DbType.Int32, Rollbackunbilledmainid, ParameterDirection.Input);
                objSpParameters.Add("lunbilledtypeid", DbType.Int32, UnbilledTypeID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_unbilledmain_select", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }
        public DataSet GetUnbilledMainDetailsByID(int Rollbackunbilledmainid, int Rollbackunbilledid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrollbackunbilledmainid", DbType.Int32, Rollbackunbilledmainid, ParameterDirection.Input);
                objSpParameters.Add("lrollbackunbilledid", DbType.Int32, Rollbackunbilledid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_unbilleddetails_select", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public int DeleteUnbilledDetails(int Rollbackunbilledmainid, int Rollbackunbilledid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrollbackunbilledmainid", DbType.Int32, Rollbackunbilledmainid, ParameterDirection.Input);
                objSpParameters.Add("lrollbackunbilledid", DbType.Int32, Rollbackunbilledid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_unbilled_detail_delete2", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public DataSet InvoiceCheckIFExist(int orderid, string mobilenumber, DateTime unbilledMonth)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lorderid", DbType.Int32, orderid, ParameterDirection.Input);
                objSpParameters.Add("cmobilenumber", DbType.String, mobilenumber, ParameterDirection.Input);
                objSpParameters.Add("unbilledmonth", DbType.DateTime, unbilledMonth, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_invoice_check_if_exist", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetRafDetailByID(int orderID)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "contractinfo", "coupan", "date", "Discount", "mulrefname" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ordid", DbType.Int32, orderID, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sproc_Select_Rafdetails", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }


        // function Start by Mithilesh 
        //Mks Country and month dropdoun 
        public DataSet Getcntmonths()
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Country", "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cntid", DbType.Int32, 0, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_dropdouninvoice", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet Getcntmonthsonlyforcountry(Int32 countyid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Country", "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cntid", DbType.Int32, countyid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_dropdouninvoice", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }

        public DataSet GetInvoicingDetailsSearch(string cntname, string mtyr)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cntname", DbType.String, cntname, ParameterDirection.Input);
                objSpParameters.Add("mnthyr", DbType.String, mtyr, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sp_searchInvoice", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public DataSet GetMisReportCountryWise(string from, string to)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("fryr", DbType.String, from, ParameterDirection.Input);
                objSpParameters.Add("toyr", DbType.String, to, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sp_CitywiseMisreport", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        public DataSet GetCoumntrynameExp(Int32 id)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "Country", "Unbilledmonth" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("cntid", DbType.Int32, id, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "Sp_Select_CountryName", dsDataSet, strDataTableName, objSpParameters);
                if (dsDataSet != null)
                    return dsDataSet;
                return null;
            }
        }
        // Function add on 24 Dec by Badesara
        public DataSet GetInvoiceGenNotGenReport(int year, int month, int countryid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_invoice_report_select", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        // Function add on 6 Jan 2012 by Badesara
        public DataSet GetHighLowValueInvoiceReport(int year, int month, int countryid, string HighLow, double amountinr)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("chighlow", DbType.String, HighLow, ParameterDirection.Input);
                objSpParameters.Add("lamountinr", DbType.Double, amountinr, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_invoice_report_high_low_value", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }

        // Function add on 6 Jan 2012 by Badesara
        public DataSet MailMergeInvoiceReport(int year, int month, int countryid, string invoiceno, string mobileno, int packageid, int orderid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                DataSet dsDataSet = new DataSet();
                dsDataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
                string[] strDataTableName ={ "invoicing" };
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lyear", DbType.Int32, year, ParameterDirection.Input);
                objSpParameters.Add("lmonth", DbType.Int32, month, ParameterDirection.Input);
                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lpackageid", DbType.Int32, packageid, ParameterDirection.Input);
                objSpParameters.Add("lorderid", DbType.Int32, orderid, ParameterDirection.Input);

                objSpParameters.Add("cinvoiceno", DbType.String, invoiceno, ParameterDirection.Input);
                objSpParameters.Add("cmobileno", DbType.String, mobileno, ParameterDirection.Input);
                objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "sp_invoice_mail_merge_report", dsDataSet, strDataTableName, objSpParameters);

                if (dsDataSet != null)
                    return dsDataSet;

                return null;
            }
        }


        public int TrafficControlInsert(int countryid, int providerid , int callcount, int calltypeid, int duration, double filecost, 
            double clientcost , double discount, double actualcost, DateTime generatedDay, int userid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("lcountryid", DbType.Int32, countryid , ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, providerid , ParameterDirection.Input);
                objSpParameters.Add("lcallcount", DbType.Int32, callcount , ParameterDirection.Input);
                objSpParameters.Add("lcalltypeid", DbType.Int32, calltypeid, ParameterDirection.Input);
                objSpParameters.Add("lnoofunit", DbType.Int32, duration , ParameterDirection.Input);
                objSpParameters.Add("lfilecost", DbType.Double, filecost , ParameterDirection.Input);
                objSpParameters.Add("lclientcost", DbType.Double, clientcost , ParameterDirection.Input);
                objSpParameters.Add("ldiscount", DbType.Double, discount , ParameterDirection.Input);
                objSpParameters.Add("lclientcosttotal", DbType.Double, actualcost , ParameterDirection.Input);
                objSpParameters.Add("dgenerateday", DbType.Date, generatedDay , ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, userid, ParameterDirection.Input);

                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_traffic_control_insert", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }

        public int TrafficControlInsertNew(int countryid, int providerid, DateTime generatedDay, int userid)
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("ERPInvoicing"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);


                objSpParameters.Add("lcountryid", DbType.Int32, countryid, ParameterDirection.Input);
                objSpParameters.Add("lproviderid", DbType.Int32, providerid, ParameterDirection.Input);
                objSpParameters.Add("dgenerateday", DbType.Date, generatedDay, ParameterDirection.Input);
                objSpParameters.Add("luserid", DbType.Int32, userid, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sp_traffic_control_insert2", objSpParameters);
                object objRcode = objSpParameters.GetOutputParamValue("rcode");
                int intRcode = int.Parse(objRcode.ToString());
                return intRcode;
            }
        }



        #endregion
    }
}
