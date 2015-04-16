using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class MISReport_frmSaleBillingLeadReport : System.Web.UI.Page
{
    #region User Defined Fields

    double currentARPUCount = 0;
    double lastARPUCount = 0;
    DataSet dsCRMPermission = null;
    DataSet dsEmployee = null;
    DataSet dsSearchBranch = null;
    DataSet dsSalesOrder = null;
    DataSet dsSaleCategory = null;
    static DataSet dssalecopy = new DataSet();
    Clay.Common.Bll.Employee objEmployee = null;
    Clay.Invoice.Bll.Web objEmployeeSales = new Clay.Invoice.Bll.Web();
    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new Clay.Sale.Bll.SalesSummaryReport();
    //Clay.Administrator.Bll.CRMPermission objCrmPermission = null;
    Clay.Common.Bll.Branch objBranch = null;
    //Clay.SalesOrder.Bll.SalesOrder objSalesOrder = null;
    Clay.Invoice.Bll.Report Rpt = new Clay.Invoice.Bll.Report();
    Clay.Invoice.Bll.Web objSalesOrderWeb = null;

    #endregion

    #region Used Defined Methods

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("../../Login.aspx", false);
            }
        }
        catch
        {
        }
    }
    private void loadYear()
    {
        //Load Years
        //DataRow drYear;
        //DataSet dsYear = new DataSet();
        //DataTable dtYears = new DataTable();
        //dsYear.Tables.Add(dtYears);

        //DataColumn SNoColumn1 = new DataColumn();
        //SNoColumn1.ColumnName = "yearVal";
        //dsYear.Tables[0].Columns.Add(SNoColumn1);

        //DataColumn SNoColumn2 = new DataColumn();
        //SNoColumn2.ColumnName = "yearTxt";
        //dsYear.Tables[0].Columns.Add(SNoColumn2);

        //for (int i = 2010; i <= DateTime.Now.AddYears(1).Year; i++)
        //{
        //    drYear = dsYear.Tables[0].NewRow();
        //    drYear["yearVal"] = i;
        //    drYear["yearTxt"] = i;
        //    dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        //}

        //ddlFromYear.DataSource = dsYear.Tables[0];
        //ddlFromYear.DataTextField = "yearVal";
        //ddlFromYear.DataValueField = "yearTxt";
        //ddlFromYear.DataBind();
        //ddlFromYear.SelectedIndex = 0;

        //ddlToYear.DataSource = dsYear.Tables[0];
        //ddlToYear.DataTextField = "yearVal";
        //ddlToYear.DataValueField = "yearTxt";
        //ddlToYear.DataBind();

        //ddlToYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;

        for (int year = 2010; year <= DateTime.Now.Year; year++)
        {
            ddlFromYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
        for (int year = 2011; year <= DateTime.Now.Year + 1; year++)
        {
            ddlToYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
        ddlToYear.SelectedValue = (DateTime.Now.Year + 1).ToString();
    }
    void bindDataToDataSet(int iFromYear, int iToYear, string strBranchParameter, int branchid, int accountmgrid, int categoryid)
    {
        try
        {
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();
            DataSet ds = new DataSet();
            DataSet dsSaleBilling = new DataSet();
            DataSet dsBranchTotal = new DataSet();

            #region columns add

            dsSaleBilling.Tables.Add("salebillingbranch");
            dsSaleBilling.Tables[0].Columns.Add("yearfromto");
            dsSaleBilling.Tables[0].Columns.Add("salecategoryname");
            dsSaleBilling.Tables[0].Columns.Add("branchname");
            dsSaleBilling.Tables[0].Columns.Add("employeename");
            dsSaleBilling.Tables[0].Columns.Add("aprsale");
            dsSaleBilling.Tables[0].Columns.Add("aprbilling");
            dsSaleBilling.Tables[0].Columns.Add("aprprepaid");
            dsSaleBilling.Tables[0].Columns.Add("maysale");
            dsSaleBilling.Tables[0].Columns.Add("maybilling");
            dsSaleBilling.Tables[0].Columns.Add("mayprepaid");
            dsSaleBilling.Tables[0].Columns.Add("junsale");
            dsSaleBilling.Tables[0].Columns.Add("junbilling");
            dsSaleBilling.Tables[0].Columns.Add("junprepaid");
            dsSaleBilling.Tables[0].Columns.Add("julsale");
            dsSaleBilling.Tables[0].Columns.Add("julbilling");
            dsSaleBilling.Tables[0].Columns.Add("julprepaid");
            dsSaleBilling.Tables[0].Columns.Add("augsale");
            dsSaleBilling.Tables[0].Columns.Add("augbilling");
            dsSaleBilling.Tables[0].Columns.Add("augprepaid");
            dsSaleBilling.Tables[0].Columns.Add("sepsale");
            dsSaleBilling.Tables[0].Columns.Add("sepbilling");
            dsSaleBilling.Tables[0].Columns.Add("sepprepaid");
            dsSaleBilling.Tables[0].Columns.Add("octsale");
            dsSaleBilling.Tables[0].Columns.Add("octbilling");
            dsSaleBilling.Tables[0].Columns.Add("octprepaid");
            dsSaleBilling.Tables[0].Columns.Add("novsale");
            dsSaleBilling.Tables[0].Columns.Add("novbilling");
            dsSaleBilling.Tables[0].Columns.Add("novprepaid");
            dsSaleBilling.Tables[0].Columns.Add("decsale");
            dsSaleBilling.Tables[0].Columns.Add("decbilling");
            dsSaleBilling.Tables[0].Columns.Add("decprepaid");
            dsSaleBilling.Tables[0].Columns.Add("jansale");
            dsSaleBilling.Tables[0].Columns.Add("janbilling");
            dsSaleBilling.Tables[0].Columns.Add("janprepaid");
            dsSaleBilling.Tables[0].Columns.Add("febsale");
            dsSaleBilling.Tables[0].Columns.Add("febbilling");
            dsSaleBilling.Tables[0].Columns.Add("febprepaid");
            dsSaleBilling.Tables[0].Columns.Add("marsale");
            dsSaleBilling.Tables[0].Columns.Add("marbilling");
            dsSaleBilling.Tables[0].Columns.Add("marprepaid");

            dsSaleBilling.Tables[0].Columns.Add("saletotal", typeof(double));
            dsSaleBilling.Tables[0].Columns.Add("billingtotal", typeof(double));
            dsSaleBilling.Tables[0].Columns.Add("prepaidtotal", typeof(double));
            dsSaleBilling.Tables[0].Columns.Add("arpusalebilling");

            dsSaleBilling.Tables[0].Columns.Add("srno");

            dsBranchTotal.Tables.Add("branchTotal");
            dsBranchTotal.Tables[0].Columns.Add("branchname");
            dsBranchTotal.Tables[0].Columns.Add("saletotal", typeof(double));

            #endregion

            DataTable dsSaleCount = new DataTable();
            DataTable dsBillingCount = new DataTable();
            string strYearFromTo = string.Empty;
            int saleCount = 0;
            double revenueAmount = 0;
            int saleCountTotal = 0;
            double revenueAmountTotal = 0;

            int fromYear = iFromYear;
            int toYear = iToYear;

            ds = objSalesSummaryReport.rptSalesBillingBranchAccountManagerWisewithsort(fromYear, toYear, branchid, accountmgrid, categoryid);



            string strbranchname = getBranchname(ds, 0, "");
            string strEmployeeName = getEmployeeName(ds, 0, "");
            string strSaleCategoryAll = getSaleCategory(ds.Tables["SaleCategory"]);

            int ix = 0;
            int ixMonthNew = 0;
            int ixYearNew = 0;

            //foreach (string strZone in strZoneList)
            //{
            string[] strBranchList = strbranchname.Split(',');// strBranchParameter.Split(','); // getBranchName(ds).Split(',');
            string[] strEmployeeList = strEmployeeName.Split(',');
            string[] strSaleCategoryList = strSaleCategoryAll.Split(',');
            string strSaleCategory = string.Empty;
            string categry = string.Empty;
            //foreach (string strSaleCategory in strSaleCategoryList)
            //{
            //    if (strSaleCategory != "")
            //    {
            foreach (string strBranch in strBranchList)
            {
                if (strBranch != "")
                {
                    for (int iAnand = fromYear; iAnand < toYear; iAnand++)
                    {
                        strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();

                        foreach (string strEmployee in strEmployeeList)
                        {
                            if (strEmployee != "")
                            {
                                dsSaleBilling.Tables[0].Rows.Add(strYearFromTo, strSaleCategory, strBranch, strEmployee, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ix);

                                saleCountTotal = 0;
                                revenueAmountTotal = 0;

                                for (int iJS = 4; iJS <= 15; iJS++)
                                {
                                    ixMonthNew = iJS;
                                    ixYearNew = iAnand;

                                    if (ixMonthNew > 12)
                                    {
                                        ixMonthNew = ixMonthNew - 12;
                                        ixYearNew = iAnand + 1;
                                    }

                                    dsSaleCount = getSaleCountByYearMonth(ixMonthNew, ixYearNew, strEmployee, strBranch, strSaleCategory, ds.Tables["sale"]);
                                    dsBillingCount = getBillingByYearMonth(ixMonthNew, ixYearNew, strEmployee, strBranch, strSaleCategory, ds.Tables["Billing"]);

                                    if (dsSaleCount.Rows.Count > 0)
                                    {
                                        saleCount = Convert.ToInt32(dsSaleCount.Rows[0]["lsaletotal"]);
                                        saleCountTotal += saleCount;
                                    }
                                    else
                                    {
                                        saleCount = 0;
                                    }

                                    if (dsBillingCount.Rows.Count > 0)
                                    {
                                        revenueAmount = Convert.ToDouble(dsBillingCount.Rows[0]["lrevenuetotal"]);
                                        revenueAmountTotal += revenueAmount;
                                    }
                                    else
                                    {
                                        revenueAmount = 0;
                                    }
                                    if (dsSaleCount.Rows.Count > 0)
                                    {
                                        categry = dsSaleCount.Rows[0]["salecategoryname"].ToString();
                                        // saleCountTotal += saleCount;
                                    }
                                    else
                                    {
                                        categry = string.Empty;
                                    }


                                    dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = saleCount.ToString();
                                    dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(revenueAmount).ToString();
                                    if (categry == string.Empty || categry == "")
                                    {

                                    }
                                    else
                                    {
                                        dsSaleBilling.Tables[0].Rows[ix]["salecategoryname"] = categry.ToString();
                                    }
                                }


                                dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountTotal.ToString();
                                dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountTotal).ToString();

                                double arpu = revenueAmountTotal / saleCountTotal;

                                dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpu).ToString();
                                if (saleCountTotal == 0 && revenueAmountTotal == 0)
                                {
                                    dsSaleBilling.Tables[0].Rows[ix].Delete();
                                }
                                else
                                {
                                    ix = ix + 1;
                                }
                            }
                        }
                        #region Comment Code
                        // Total of the Year 
                        //DataTable dsSalecountTotal =  getSaleBillingCountTotalByYear(strYearFromTo, strBranch, strSaleCategory, dsSaleBilling.Tables[0]);

                        //if (dsSalecountTotal.Rows.Count > 0)
                        //{
                        //    // Get Total of the YEar 
                        //    dsSaleBilling.Tables[0].Rows.Add("", "", strBranch + " Total", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ix);

                        //    for (int iJS = 4; iJS <= 15; iJS++)
                        //    {
                        //        ixMonthNew = iJS;
                        //        ixYearNew = 0;

                        //        if (ixMonthNew > 12)
                        //        {
                        //            ixMonthNew = ixMonthNew - 12;
                        //            ixYearNew = 1;
                        //        }
                        //        int dSaleCount = 0;
                        //        double dRevenueAmount = 0;

                        //        for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        //        {
                        //            dSaleCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                        //            dRevenueAmount += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                        //        }

                        //        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                        //        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                        //    }

                        //    int saleCountGrandTotal = 0;
                        //    double revenueAmountGrandTotal = 0;

                        //    for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        //    {
                        //        saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["saletotal"]);
                        //        revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN]["billingtotal"]);
                        //    }

                        //    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountGrandTotal.ToString();
                        //    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                        //    double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                        //    dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                        //    if (saleCountGrandTotal == 0 && revenueAmountGrandTotal == 0)
                        //    {
                        //        dsSaleBilling.Tables[0].Rows[ix].Delete();
                        //    }
                        //    else
                        //    {

                        //        ix = ix + 1;
                        //    }


                        //}
                        #endregion


                    }

                    #region Comment Code
                    //DataTable dsSalecountTotal2 = getSaleBillingCountTotalByYear("", strBranch,strSaleCategory, dsSaleBilling.Tables[0]);

                    //if (dsSalecountTotal2.Rows.Count > 0)
                    //{
                    //    // Get Total of the YEar 
                    //    dsSaleBilling.Tables[0].Rows.Add("", "", strBranch + " Grand Total", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ix);

                    //    for (int iJS = 4; iJS <= 15; iJS++)
                    //    {
                    //        ixMonthNew = iJS;
                    //        ixYearNew = 0;

                    //        if (ixMonthNew > 12)
                    //        {
                    //            ixMonthNew = ixMonthNew - 12;
                    //            ixYearNew = 1;
                    //        }
                    //        int dSaleCount = 0;
                    //        double dRevenueAmount = 0;

                    //        for (int iSSDN = 0; iSSDN < dsSalecountTotal2.Rows.Count; iSSDN++)
                    //        {
                    //            dSaleCount += Convert.ToInt32(dsSalecountTotal2.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                    //            dRevenueAmount += Convert.ToDouble(dsSalecountTotal2.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                    //        }

                    //        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                    //        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                    //    }

                    //    int saleCountGrandTotal = 0;
                    //    double revenueAmountGrandTotal = 0;

                    //    for (int iSSDN = 0; iSSDN < dsSalecountTotal2.Rows.Count; iSSDN++)
                    //    {
                    //        saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal2.Rows[iSSDN]["saletotal"]);
                    //        revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal2.Rows[iSSDN]["billingtotal"]);
                    //    }

                    //    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountGrandTotal.ToString();
                    //    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                    //    double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                    //    dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                    //    if (saleCountGrandTotal == 0 && revenueAmountGrandTotal == 0)
                    //    {
                    //        dsSaleBilling.Tables[0].Rows[ix].Delete();
                    //    }
                    //    else
                    //    {
                    //        dsBranchTotal.Tables[0].Rows.Add(strBranch, saleCountGrandTotal);
                    //        ix = ix + 1;
                    //    }
                    //    //}

                    //}
                    #endregion
                }
            }
            //    }
            //}

            UpdatePrepaidSale(ref dsSaleBilling);

            DataTable ds1 = new DataTable();
            DataTable dtnew = new DataTable();
            if (rdosalebill.SelectedValue == "2")
            {

                DataView dv = dsSaleBilling.Tables[0].DefaultView;
                if (rdovalue.SelectedValue == "1")
                {
                    dsSaleBilling.Tables[0].DefaultView.Sort = "billingtotal desc";
                    //dv.Sort = "billingtotal DESC";
                }
                else
                {
                    dsSaleBilling.Tables[0].DefaultView.Sort = "billingtotal ASC";
                    //dv.Sort = "billingtotal asc";
                }


                dtnew = dsSaleBilling.Tables[0].DefaultView.ToTable();
                // dtnew.AsEnumerable().Take(Convert.ToInt32(ddlvalue.SelectedValue)).CopyToDataTable();
                DataTable dtcopy = new DataTable();
                dtcopy = dtnew.Clone();
                for (int iAnand = fromYear; iAnand < toYear; iAnand++)
                {
                    strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                    DataTable dsSalecountTotal = getSaleBillingCountTotalByYearcopy(strYearFromTo, "", strSaleCategory, dtnew);
                    int i = 0;
                    foreach (DataRow drcopy in dsSalecountTotal.Rows)
                    {
                        i++;
                        if (i == Convert.ToInt32(ddlvalue.SelectedValue))
                        {
                            dtcopy.ImportRow(drcopy);
                            break;
                        }
                        else
                        {
                            dtcopy.ImportRow(drcopy);
                        }
                    }

                }
                dtnew = dtcopy;
            }
            else if (rdosalebill.SelectedValue == "1")
            {

                DataView dv = dsSaleBilling.Tables[0].DefaultView;
                if (rdovalue.SelectedValue == "1")
                {
                    dsSaleBilling.Tables[0].DefaultView.Sort = "saletotal desc";
                    //dv.Sort = "billingtotal DESC";
                }
                else
                {
                    dsSaleBilling.Tables[0].DefaultView.Sort = "saletotal ASC";
                    //dv.Sort = "billingtotal asc";
                }


                dtnew = dsSaleBilling.Tables[0].DefaultView.ToTable();


            }
            else
            {
                dtnew = dsSaleBilling.Tables[0];
            }

            #region Total Year Wise
            DataTable dttotal = new DataTable();
            for (int iAnand = fromYear; iAnand < toYear; iAnand++)
            {
                strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                DataTable dsSalecountTotal = getSaleBillingCountTotalByYearcopy(strYearFromTo, "", strSaleCategory, dtnew);

                if (dsSalecountTotal.Rows.Count > 0)
                {
                    // Get Total of the YEar 
                    dttotal.Merge(dsSalecountTotal);
                    int countval = dttotal.Rows.Count;
                    dttotal.Rows.Add("", "", "" + " Total", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ix);

                    for (int iJS = 4; iJS <= 15; iJS++)
                    {
                        ixMonthNew = iJS;
                        ixYearNew = 0;

                        if (ixMonthNew > 12)
                        {
                            ixMonthNew = ixMonthNew - 12;
                            ixYearNew = 1;
                        }
                        int dSaleCount = 0;
                        double dRevenueAmount = 0;

                        for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        {
                            dSaleCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                            dRevenueAmount += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                        }

                        dttotal.Rows[countval][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                        dttotal.Rows[countval][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                    }

                    int saleCountGrandTotal = 0;
                    double revenueAmountGrandTotal = 0;

                    for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                    {
                        saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["saletotal"]);
                        revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN]["billingtotal"]);
                    }

                    dttotal.Rows[countval]["saletotal"] = saleCountGrandTotal.ToString();
                    dttotal.Rows[countval]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                    double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                    dttotal.Rows[countval]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                    if (saleCountGrandTotal == 0 && revenueAmountGrandTotal == 0)
                    {
                        //dttotal.Rows[ix].Delete();
                    }
                    else
                    {

                        // ix = ix + 1;
                    }


                }
            }
            #endregion

            #region Grandtotal
            DataTable dsSalecountTotal2 = new DataTable();
            DataTable dtgrandtotal2 = new DataTable();
            DataTable dtgrandtotal = new DataTable();
            for (int iAnand = fromYear; iAnand < toYear; iAnand++)
            {
                strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                dsSalecountTotal2 = getSaleBillingCountTotalByYearcopy(strYearFromTo, "", strSaleCategory, dtnew);
                dtgrandtotal2.Merge(dsSalecountTotal2);
            }
            //  DataTable dsSalecountTotal2 = getSaleBillingCountTotalByYearcopy("", "", strSaleCategory, dsSaleBilling.Tables[0]);

            if (dtgrandtotal2.Rows.Count > 0)
            {
                // dtgrandtotal = dtgrandtotal2;
                int countvalgrandtotal = dttotal.Rows.Count;
                // Get Total of the YEar 
                dttotal.Rows.Add("", "", "" + " Grand Total", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ix);

                for (int iJS = 4; iJS <= 15; iJS++)
                {
                    ixMonthNew = iJS;
                    ixYearNew = 0;

                    if (ixMonthNew > 12)
                    {
                        ixMonthNew = ixMonthNew - 12;
                        ixYearNew = 1;
                    }
                    int dSaleCount = 0;
                    double dRevenueAmount = 0;

                    for (int iSSDN = 0; iSSDN < dtgrandtotal2.Rows.Count; iSSDN++)
                    {
                        dSaleCount += Convert.ToInt32(dtgrandtotal2.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                        dRevenueAmount += Convert.ToDouble(dtgrandtotal2.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                    }

                    dttotal.Rows[countvalgrandtotal][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                    dttotal.Rows[countvalgrandtotal][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                }

                int saleCountGrandTotal = 0;
                double revenueAmountGrandTotal = 0;

                for (int iSSDN = 0; iSSDN < dsSalecountTotal2.Rows.Count; iSSDN++)
                {
                    saleCountGrandTotal += Convert.ToInt32(dtgrandtotal2.Rows[iSSDN]["saletotal"]);
                    revenueAmountGrandTotal += Convert.ToDouble(dtgrandtotal2.Rows[iSSDN]["billingtotal"]);
                }

                dttotal.Rows[countvalgrandtotal]["saletotal"] = saleCountGrandTotal.ToString();
                dttotal.Rows[countvalgrandtotal]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                dttotal.Rows[countvalgrandtotal]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                if (saleCountGrandTotal == 0 && revenueAmountGrandTotal == 0)
                {
                    // dsSaleBilling.Tables[0].Rows[ix].Delete();
                }
                else
                {
                    // dsBranchTotal.Tables[0].Rows.Add(strBranch, saleCountGrandTotal);
                    //  ix = ix + 1;
                }
                //}

            }

            #endregion
            //update prepaid total
            int[] totals = new int[13];
            int[] grandtotals = new int[13];
            for (int i = 0; i < dttotal.Rows.Count; i++)
            {
                DataRow dr = dttotal.Rows[i];

                if (dr["branchname"].ToString() == " Total")
                {
                    dr["aprprepaid"] = totals[0];
                    dr["mayprepaid"] = totals[1];
                    dr["junprepaid"] = totals[2];
                    dr["julprepaid"] = totals[3];
                    dr["augprepaid"] = totals[4];
                    dr["sepprepaid"] = totals[5];
                    dr["octprepaid"] = totals[6];
                    dr["novprepaid"] = totals[7];
                    dr["decprepaid"] = totals[8];
                    dr["janprepaid"] = totals[9];
                    dr["febprepaid"] = totals[10];
                    dr["marprepaid"] = totals[11];
                    dr["prepaidtotal"] = totals[12];

                    for (int j = 0; j < totals.Length; j++)
                    {
                        grandtotals[j] += totals[j];
                        totals[j] = 0;
                    }
                }
                else if (dr["branchname"].ToString() == " Grand Total")
                {
                    dr["aprprepaid"] = grandtotals[0];
                    dr["mayprepaid"] = grandtotals[1];
                    dr["junprepaid"] = grandtotals[2];
                    dr["julprepaid"] = grandtotals[3];
                    dr["augprepaid"] = grandtotals[4];
                    dr["sepprepaid"] = grandtotals[5];
                    dr["octprepaid"] = grandtotals[6];
                    dr["novprepaid"] = grandtotals[7];
                    dr["decprepaid"] = grandtotals[8];
                    dr["janprepaid"] = grandtotals[9];
                    dr["febprepaid"] = grandtotals[10];
                    dr["marprepaid"] = grandtotals[11];
                    dr["prepaidtotal"] = grandtotals[12];
                    grandtotals = null;
                    totals = null;
                }
                else
                {
                    totals[0] += dr["aprprepaid"] != DBNull.Value ? Convert.ToInt32(dr["aprprepaid"]) : 0;
                    totals[1] += dr["mayprepaid"] != DBNull.Value ? Convert.ToInt32(dr["mayprepaid"]) : 0;
                    totals[2] += dr["junprepaid"] != DBNull.Value ? Convert.ToInt32(dr["junprepaid"]) : 0;
                    totals[3] += dr["julprepaid"] != DBNull.Value ? Convert.ToInt32(dr["julprepaid"]) : 0;
                    totals[4] += dr["augprepaid"] != DBNull.Value ? Convert.ToInt32(dr["augprepaid"]) : 0;
                    totals[5] += dr["sepprepaid"] != DBNull.Value ? Convert.ToInt32(dr["sepprepaid"]) : 0;
                    totals[6] += dr["octprepaid"] != DBNull.Value ? Convert.ToInt32(dr["octprepaid"]) : 0;
                    totals[7] += dr["novprepaid"] != DBNull.Value ? Convert.ToInt32(dr["novprepaid"]) : 0;
                    totals[8] += dr["decprepaid"] != DBNull.Value ? Convert.ToInt32(dr["decprepaid"]) : 0;
                    totals[9] += dr["janprepaid"] != DBNull.Value ? Convert.ToInt32(dr["janprepaid"]) : 0;
                    totals[10] += dr["febprepaid"] != DBNull.Value ? Convert.ToInt32(dr["febprepaid"]) : 0;
                    totals[11] += dr["marprepaid"] != DBNull.Value ? Convert.ToInt32(dr["marprepaid"]) : 0;
                    totals[12] += dr["prepaidtotal"] != DBNull.Value ? Convert.ToInt32(dr["prepaidtotal"]) : 0;

                }
            }



            RAFRepeater.DataSource = dttotal;// dsSaleBilling.Tables[0];// dsSaleBilling;// ds1;// dssalecopy;
            RAFRepeater.DataBind();

            //}
        }
        catch (Exception ex)
        {
            err.Text = ex.Message;
        }
    }

    private void UpdatePrepaidSale(ref DataSet dsSaleBilling)
    {
        int BranchID = 0;
        int acmgrId = 0;

        string yearfromto = string.Empty;
        string branchname = string.Empty;
        string employeename = string.Empty;


        if (ddlBranch.SelectedIndex > 0)
            BranchID = int.Parse(ddlBranch.SelectedValue);
        if (ddlManager.SelectedIndex > 0)
            acmgrId = int.Parse(ddlManager.SelectedValue);

        DataTable dtPrepaidSale = DataAccess.GetSalesPrepaidBranchAccountManagerWisewithsort(int.Parse(ddlFromYear.SelectedValue), int.Parse(ddlToYear.SelectedValue), BranchID, acmgrId);
        for (int i = 0; i < dsSaleBilling.Tables[0].Rows.Count; i++)
        {
            yearfromto = dsSaleBilling.Tables[0].Rows[i]["yearfromto"].ToString();
            branchname = dsSaleBilling.Tables[0].Rows[i]["branchname"].ToString();
            employeename = dsSaleBilling.Tables[0].Rows[i]["employeename"].ToString();

            BranchID = GetBranchID(branchname);
            acmgrId = GetEmployeeID(employeename);
            foreach (DataRow dtr in dtPrepaidSale.Select("FinYear='" + yearfromto + "' and BranchId='" + BranchID + "' and EmpId='" + acmgrId + "'"))
            {
                dsSaleBilling.Tables[0].Rows[i]["aprprepaid"] = dtr["Apr"];
                dsSaleBilling.Tables[0].Rows[i]["mayprepaid"] = dtr["May"];
                dsSaleBilling.Tables[0].Rows[i]["junprepaid"] = dtr["Jun"];
                dsSaleBilling.Tables[0].Rows[i]["julprepaid"] = dtr["July"];
                dsSaleBilling.Tables[0].Rows[i]["augprepaid"] = dtr["Aug"];
                dsSaleBilling.Tables[0].Rows[i]["sepprepaid"] = dtr["Sep"];
                dsSaleBilling.Tables[0].Rows[i]["octprepaid"] = dtr["Oct"];
                dsSaleBilling.Tables[0].Rows[i]["novprepaid"] = dtr["Nov"];
                dsSaleBilling.Tables[0].Rows[i]["decprepaid"] = dtr["Dec"];
                dsSaleBilling.Tables[0].Rows[i]["janprepaid"] = dtr["Jan"];
                dsSaleBilling.Tables[0].Rows[i]["febprepaid"] = dtr["Feb"];
                dsSaleBilling.Tables[0].Rows[i]["marprepaid"] = dtr["Mar"];
                dsSaleBilling.Tables[0].Rows[i]["prepaidtotal"] = dtr["Total"];
            }
        }


    }

    private int GetBranchID(string branchname)
    {
        int branchid = 0;
        foreach (Telerik.Web.UI.RadComboBoxItem item in ddlBranch.Items)
        {
            if (item.Text == branchname)
            {
                branchid = int.Parse(item.Value);
                break;
            }
        }
        return branchid;
    }
    private int GetEmployeeID(string employeename)
    {
        int employeeId = 0;
        foreach (Telerik.Web.UI.RadComboBoxItem item in ddlManager.Items)
        {
            if (item.Text == employeename)
            {
                employeeId = int.Parse(item.Value);
                break;
            }
        }
        return employeeId;
    }

    private DataTable dsOrderBySale(DataTable dsSale, DataTable dsBranchTot)
    {
        DataTable dsNew = new DataTable();
        DataTable dsNewAll = new DataTable();
        dsBranchTot = getOrderByBranchTotal(dsBranchTot);
        string brnch = string.Empty;
        string brnchtotal = string.Empty;
        string bTotl = string.Empty;

        if (dsBranchTot.Rows.Count > 0)
        {
            foreach (DataRow dr in dsBranchTot.Rows)
            {
                DataRow[] foundRows;
                brnch = dr["branchname"].ToString();
                brnchtotal = brnch + " Grand Total";
                bTotl = brnch + " Total";

                foundRows = dsSale.Select("branchname='" + brnch + "' or branchname='" + brnchtotal + "' or branchname='" + bTotl + "'");
                int i = 0;

                dsNew = dsSale.Clone();
                for (i = 0; i < foundRows.Length; i++)
                {
                    dsNew.ImportRow(foundRows[i]);
                }
                dsNewAll.Merge(dsNew);
            }
        }

        return dsNewAll;
    }

    private DataTable getOrderByBranchTotal(DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("saletotal>0", " saletotal desc");
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    private string getMthName(int val)
    {
        string strVal = string.Empty;

        switch (val)
        {
            case 1:
                strVal = "jan";
                break;
            case 2:
                strVal = "feb";
                break;
            case 3:
                strVal = "mar";
                break;
            case 4:
                strVal = "apr";
                break;
            case 5:
                strVal = "may";
                break;
            case 6:
                strVal = "jun";
                break;
            case 7:
                strVal = "jul";
                break;
            case 8:
                strVal = "aug";
                break;
            case 9:
                strVal = "sep";
                break;
            case 10:
                strVal = "oct";
                break;

            case 11:
                strVal = "nov";
                break;

            case 12:
                strVal = "dec";
                break;


            default:
                strVal = "";
                break;
        }

        return strVal;
    }

    private DataTable getSaleCountByYearMonth(int month, int year, string strEmpName, string strBranch, string strSaleCategoryNAme, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("saleyear=" + year + " and salemonth=" + month
                + " and employeename='" + strEmpName + "'"
                // + " and salecategoryname='" + strSaleCategoryNAme + "'"
                + " and branchname='" + strBranch + "'");
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    private DataTable getBillingByYearMonth(int month, int year, string strEmpName, string strBranch, string strSaleCategoryNAme, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("billingyear=" + year + " and billingmonth=" + month
                + " and employeename='" + strEmpName + "'"
                // + " and salecategoryname='" + strSaleCategoryNAme + "'"
                + " and branchname='" + strBranch + "'");
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    private DataTable getSaleBillingCountTotalByYear(string cYearFromTo, string strBranchNames, string strSaleCategory, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            if (cYearFromTo != "")
            {
                //foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "' and branchname='" + strBranchNames + "' and salecategoryname='" + strSaleCategory + "'");
                foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "' and branchname='" + strBranchNames + "'");
            }
            else
            {
                //foundRows = dsAll.Select("branchname='" + strBranchNames + "' and salecategoryname='" + strSaleCategory + "'");
                foundRows = dsAll.Select("branchname='" + strBranchNames + "'");
            }
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    private DataTable getSaleBillingCountTotalByYearcopy(string cYearFromTo, string strBranchNames, string strSaleCategory, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        DataTable dt2 = new DataTable();
        try
        {
            DataRow[] foundRows;
            if (cYearFromTo != "")
            {
                //foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "' and branchname='" + strBranchNames + "' and salecategoryname='" + strSaleCategory + "'");
                foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "'");
            }
            else
            {
                //foundRows = dsAll.Select("branchname='" + strBranchNames + "' and salecategoryname='" + strSaleCategory + "'");
                foundRows = dsAll.Select("branchname='" + strBranchNames + "'");
            }
            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    protected string getBranchName(DataSet ds)
    {
        string strBranch = string.Empty;
        for (int ianand = 0; ianand < ds.Tables["Branch"].Rows.Count; ianand++)
        {
            strBranch += ds.Tables["Branch"].Rows[ianand]["branchname"].ToString() + ",";
        }
        return strBranch;
    }

    protected string getSaleCategory(DataTable ds)
    {
        string strBranch = string.Empty;
        for (int ianand = 0; ianand < ds.Rows.Count; ianand++)
        {
            strBranch += ds.Rows[ianand]["salecategoryname"].ToString() + ",";
        }
        return strBranch;
    }

    private DataTable getBillingByYearMonthZone(int month, int year, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        DataTable ds2 = new DataTable();

        try
        {
            DataRow[] foundRows;
            DataRow[] foundRows2;

            if (strZone != "")
            {
                foundRows = dsAll.Select("billingyear=" + year + " and billingmonth in (4,5,6,7,8,9,10,11,12) and zone='" + strZone + "'");
            }
            else
            {
                foundRows = dsAll.Select("billingyear=" + year + " and billingmonth in (4,5,6,7,8,9,10,11,12)");
            }

            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
            year = year + 1;
            if (strZone != "")
            {
                foundRows2 = dsAll.Select("billingyear=" + year + " and billingmonth in (1,2,3) and zone='" + strZone + "'");
            }
            else
            {
                foundRows2 = dsAll.Select("billingyear=" + year + " and billingmonth in (1,2,3)");
            }
            ds2 = dsAll.Clone();
            for (i = 0; i < foundRows2.Length; i++)
            {
                ds2.ImportRow(foundRows2[i]);
            }

            ds.Merge(ds2);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    private DataTable getsaleByYearMonthZone(int month, int year, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        DataTable ds2 = new DataTable();

        try
        {
            DataRow[] foundRows;
            DataRow[] foundRows2;

            if (strZone != "")
            {
                foundRows = dsAll.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) and zone='" + strZone + "'");
            }
            else
            {
                foundRows = dsAll.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12)");
            }

            int i = 0;

            ds = dsAll.Clone();
            for (i = 0; i < foundRows.Length; i++)
            {
                ds.ImportRow(foundRows[i]);
            }
            year = year + 1;
            if (strZone != "")
            {
                foundRows2 = dsAll.Select("saleyear=" + year + " and salemonth in (1,2,3) and zone='" + strZone + "'");
            }
            else
            {
                foundRows2 = dsAll.Select("saleyear=" + year + " and salemonth in (1,2,3)");
            }
            ds2 = dsAll.Clone();
            for (i = 0; i < foundRows2.Length; i++)
            {
                ds2.ImportRow(foundRows2[i]);
            }

            ds.Merge(ds2);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    protected string getEmployeeName(DataSet ds, int iyear, string strBranchName)
    {
        DataTable dtSaleBillBranch = new DataTable();
        DataTable dtSale = new DataTable();

        //dtSale = getsaleByYearMonthZone(0, iyear, strBranchName, ds.Tables["sale"]);
        //dtSaleBillBranch = getBillingByYearMonthZone(0, iyear, strBranchName, ds.Tables["billing"]);
        dtSale = ds.Tables["sale"];
        dtSaleBillBranch = ds.Tables["billing"];

        dtSaleBillBranch.Merge(dtSale);

        string strBranch = string.Empty;
        string strtempBranch = string.Empty;

        for (int iAnand = 0; iAnand < dtSaleBillBranch.Rows.Count; iAnand++)
        {
            strtempBranch = "--" + dtSaleBillBranch.Rows[iAnand]["employeename"].ToString() + "--";

            if (!(strBranch.Contains(strtempBranch)))
            {
                strBranch += "--" + dtSaleBillBranch.Rows[iAnand]["employeename"].ToString() + "--,";
            }
        }

        strBranch = strBranch.Replace("--", "");

        return strBranch;
    }

    protected string getBranchname(DataSet ds, int iyear, string strBranchName)
    {
        DataTable dtSaleBillBranch = new DataTable();
        DataTable dtSale = new DataTable();

        //dtSale = getsaleByYearMonthZone(0, iyear, strBranchName, ds.Tables["sale"]);
        //dtSaleBillBranch = getBillingByYearMonthZone(0, iyear, strBranchName, ds.Tables["billing"]);
        dtSale = ds.Tables["sale"];
        dtSaleBillBranch = ds.Tables["billing"];

        dtSaleBillBranch.Merge(dtSale);

        string strBranch = string.Empty;
        string strtempBranch = string.Empty;

        for (int iAnand = 0; iAnand < dtSaleBillBranch.Rows.Count; iAnand++)
        {
            strtempBranch = "--" + dtSaleBillBranch.Rows[iAnand]["branchname"].ToString() + "--";

            if (!(strBranch.Contains(strtempBranch)))
            {
                strBranch += "--" + dtSaleBillBranch.Rows[iAnand]["branchname"].ToString() + "--,";
            }
        }

        strBranch = strBranch.Replace("--", "");

        return strBranch;
    }

    void LoadBusRelManagerTocbManager()
    {
        dsEmployee = new DataSet();
        dsCRMPermission = new DataSet();
        objEmployee = new Clay.Common.Bll.Employee();
        // objCrmPermission = new Clay.Administrator.Bll.CRMPermission();
        string _emplId = string.Empty;
        string assignedEmplId = string.Empty;
        StringBuilder strEmplId = new StringBuilder();

        //if (Convert.ToInt32(Session["UserID"]) != 0)
        //{
        //    if (Convert.ToBoolean(Session["Administrator"]) == true)
        //    {
        dsEmployee = new DataSet();
        objEmployee = new Clay.Common.Bll.Employee();

        //dsEmployee = objEmployee.GetEmployeeByEmployeeId(0, 0, 0, "");
        //dsEmployee = objEmployeeSales.GetEmployeeSalesAndCre();
        dsEmployee = Rpt.GetEmployeeSalesAndCre();
        if (dsEmployee.Tables.Count > 0)
        {
            DataRow dr;
            //dr = dsEmployee.Tables[0].NewRow();
            //dr["employeename"] = "Select Manager";
            //dr["employeeid"] = "0";
            //dsEmployee.Tables[0].Rows.InsertAt(dr, 0);
            ddlManager.DataSource = dsEmployee.Tables[0];
            ddlManager.DataTextField = "employeename";
            ddlManager.DataValueField = "employeeid";
            ddlManager.DataBind();
        }


    }

    void LoadBranchTcbSearchBranch()
    {
        dsSearchBranch = new DataSet();
        objBranch = new Clay.Common.Bll.Branch();
        dsSearchBranch = objBranch.GetBranch();

        if (dsSearchBranch.Tables.Count > 0)
        {
            DataRow dr;
            dr = dsSearchBranch.Tables[0].NewRow();
            dr["branchname"] = "Select Branch";
            dr["branchid"] = 0;
            dsSearchBranch.Tables[0].Rows.InsertAt(dr, 0);
            ddlBranch.DataSource = dsSearchBranch.Tables[0];
            ddlBranch.DataTextField = "branchname";
            ddlBranch.DataValueField = "branchid";
            ddlBranch.DataBind();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            if (!IsPostBack)
            {
                loadYear();
                //  LoadBusRelManagerTocbManager();
                LoadBranchTcbSearchBranch();
                BindSaleCategory();
                BindManager();

            }
            //string yearFrom = Request.QueryString["yearfromto"].ToString();
            //string strZone = string.Empty;

            //strZone = Request.QueryString["branchname"].ToString();

            //int iFromYear = Convert.ToInt32(yearFrom.Substring(0, 4));
            //int iToYear = Convert.ToInt32(yearFrom.Substring(5, 4));
            //if (strZone.Contains("Total"))
            //{
            //    strZone = strZone.Replace("Total", "").Trim();
            //}
            //bindDataToDataSet(iFromYear, iToYear, strZone);

        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblBranchName = e.Item.FindControl("lblBranchName") as Label;
            //Image imgShowGrowth = e.Item.FindControl("imgShowGrowth") as Image;

            if (lblBranchName.Text.Contains("Total"))
            {
                //imgShowGrowth.Visible = false;
                lastARPUCount = 0;
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
                row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            }
            else
            {

                //Label lblCurrentARPUCount = e.Item.FindControl("lblARPUTotal") as Label;

                //if (lblCurrentARPUCount.Text != "")
                //{
                //    currentARPUCount = Convert.ToDouble(lblCurrentARPUCount.Text);
                //}

                //// Image Display Growth and Down...
                //if (lastARPUCount > 0)
                //{

                //    if (lastARPUCount - currentARPUCount > 0)
                //    {
                //        imgShowGrowth.ImageUrl = "~/MISReport/down.png";
                //    }
                //    else
                //    {
                //        imgShowGrowth.ImageUrl = "~/MISReport/up.png";
                //    }
                //}
                //else
                //{
                //    imgShowGrowth.Visible = false;
                //}

                //if (lblCurrentARPUCount.Text != "")
                //{
                //    lastARPUCount = Convert.ToDouble(lblCurrentARPUCount.Text);
                //}
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            #region Varibles
            int _branchid = 0;
            int _accmgrid = 0;
            int _fromyear = 0;
            int _toyear = 0;
            int _catgoryid = 0;
            string _branchname = string.Empty;
            Boolean _flag = false;
            #endregion
            // if (dsSaleBilling.Tables ==null)
            //{
            if (ddlBranch.SelectedIndex > 0)
            {
                _branchid = Convert.ToInt32(ddlBranch.SelectedValue);
                _branchname = ddlBranch.SelectedItem.Text.ToString();
                _flag = true;
            }
            if (ddlManager.SelectedIndex > 0)
            {
                _accmgrid = Convert.ToInt32(ddlManager.SelectedValue);
                _flag = true;
            }
            if (ddlCategory.SelectedIndex > 0)
            {
                _catgoryid = Convert.ToInt32(ddlCategory.SelectedValue);
            }

            _fromyear = Convert.ToInt32(ddlFromYear.SelectedValue);

            _toyear = Convert.ToInt32(ddlToYear.SelectedValue);

            bindDataToDataSet(_fromyear, _toyear, _branchname, _branchid, _accmgrid, _catgoryid);
        }
        catch (Exception ex)
        {

        }
        //}
    }
}