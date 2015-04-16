using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data;
namespace Clay.RAD
{
   public class invoicermaster
    {
       public DataSet GetInvoiceCDRInvoicerpt9(int pProviderID, int pCountryID, string billingMonthfrom, string billingMonthto)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_providerid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("_countryid", DbType.Int32, pCountryID, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_getinvoiceCDR_report_10",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetInvoiceCDRInvoicerptsubreport(int pProviderID, string billingMonthfrom, string billingMonthto)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_groupid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_getinvoiceCDR_report_provider",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       public DataSet GetServiceinfo(int groupid, int state, int serviceid, string fromdate, string todate)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "service" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lgroupid", DbType.Int32, groupid, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, fromdate, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, todate, ParameterDirection.Input);
               objSpParameters.Add("lstate", DbType.Int32, state, ParameterDirection.Input);
               objSpParameters.Add("lserviceid", DbType.Int32, serviceid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_getserviceinfo_select",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetInvoiceCDRInvoicerpt_2New(int pProviderID, int pCountryID, string billingMonthfrom, string billingMonthto)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_providerid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("_countryid", DbType.Int32, pCountryID, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_getinvoiceCDR_report_2",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetInvoiceCDRInvoicerptsubreport_2new(int pProviderID, string billingMonthfrom, string billingMonthto)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_groupid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_getinvoiceCDR_report_provider_sub2",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
       //public DataSet GetInvoiceCDRInvoicerpt_newutility(int pProviderID, int year, int month)
       //{
       //    using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
       //    {
       //        DataSet dsDataSet = new DataSet();
       //        string[] strDataTableName = { "Head" };
       //        SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
       //        objSpParameters.Add("lgroupproviderid", DbType.Int32, pProviderID, ParameterDirection.Input);
       //        objSpParameters.Add("_year", DbType.Int32, year, ParameterDirection.Input);
       //        objSpParameters.Add("_month", DbType.Int32, month, ParameterDirection.Input);
       //        objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_CDRinvoice_Select",
       //                                                        dsDataSet, strDataTableName, objSpParameters);

       //        if (dsDataSet != null)
       //            return dsDataSet;

       //        return null;
       //    }
       //}

       public DataSet GetInvoiceCDRInvoicerpt_newutility(int pProviderID, int year, int month, int cvalue)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("lgroupproviderid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("_year", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("_month", DbType.Int32, month, ParameterDirection.Input);
               if (cvalue == 1)
               {
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_CDRinvoice_Select",
                                                                   dsDataSet, strDataTableName, objSpParameters);
               }
               else
               {
                   objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_CDRinvoice_select_by_Invoicing",
                                                                   dsDataSet, strDataTableName, objSpParameters);
               }

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetCDRInvoiceEntrylist(string from, string To,int providerid)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Invoice" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("fromdate", DbType.String, from, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, To, ParameterDirection.Input);
               objSpParameters.Add("_providerid", DbType.Int32, providerid, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_sp_selectinvoicedetail",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetInvoiceRentalInOut(int pProviderID, int year, int month)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Rental" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);

               objSpParameters.Add("lgroupproviderid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("_year", DbType.Int32, year, ParameterDirection.Input);
               objSpParameters.Add("_month", DbType.Int32, month, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_rental_invoice_Select",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }

       public DataSet GetInvoiceRentalsubreport(int pProviderID, string billingMonthfrom, string billingMonthto)
       {
           using (CommandExecutor objCommandExecutor = new CommandExecutor("RAD"))
           {
               DataSet dsDataSet = new DataSet();
               string[] strDataTableName = { "Head" };
               SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
               objSpParameters.Add("_groupid", DbType.Int32, pProviderID, ParameterDirection.Input);
               objSpParameters.Add("fromdate", DbType.String, billingMonthfrom, ParameterDirection.Input);
               objSpParameters.Add("todate", DbType.String, billingMonthto, ParameterDirection.Input);
               objCommandExecutor.ExecuteDataSet(CommandType.StoredProcedure, "invrev_InvoiceRentalIn_out_subrpt",
                                                               dsDataSet, strDataTableName, objSpParameters);

               if (dsDataSet != null)
                   return dsDataSet;

               return null;
           }
       }
    }
}
