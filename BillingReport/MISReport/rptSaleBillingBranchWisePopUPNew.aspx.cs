using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class MISReport_rptSaleBillingBranchWise : System.Web.UI.Page
{
    //int branchid = 0;
    string branchname = string.Empty;

    //decimal april_sale = 0;
    //decimal may_sale = 0;
    //decimal june_sale = 0;
    //decimal july_sale = 0;
    //decimal aug_sale = 0;
    //decimal sept_sale = 0;
    //decimal oct_sale = 0;
    //decimal nov_sale = 0;
    //decimal dec_sale = 0;
    //decimal jan_sale = 0;
    //decimal feb_sale = 0;
    //decimal mar_sale = 0;

    //decimal sale_grand_total = 0;
    //decimal billing_grand_total = 0;
    //decimal arpu_grand_total = 0;


    //decimal april_billing = 0;
    //decimal may_billing = 0;
    //decimal june_billing = 0;
    //decimal july_billing = 0;
    //decimal aug_billing = 0;
    //decimal sept_billing = 0;
    //decimal oct_billing = 0;
    //decimal nov_billing = 0;
    //decimal dec_billing = 0;
    //decimal jan_billing = 0;
    //decimal feb_billing = 0;
    //decimal mar_billing = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            string yearFrom = Request.QueryString["yearfromto"].ToString();
            string strZone = Request.QueryString["zonename"].ToString();
            int iFromYear = Convert.ToInt32(yearFrom.Substring(0, 4));
            int iToYear = Convert.ToInt32(yearFrom.Substring(5, 4));
            if (strZone == "ALL")
            {
                strZone = "";
            }
            bindDataToDataSet(iFromYear, iToYear, strZone);

        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

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

    void bindDataToDataSet(int iFromYear, int iToYear, string strZoneParameter)
    {
        try
        {
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();
            DataSet ds = new DataSet();
            DataSet dsSaleBilling = new DataSet();

            string[] strZoneList = new string[4];

            if (strZoneParameter == "")
            {
                strZoneList[0] = "North";
                strZoneList[1] = "West";
                strZoneList[2] = "South";
                strZoneList[3] = "East";
            }
            else
            {
                strZoneList[0] = strZoneParameter;
            }

            #region columns add

            dsSaleBilling.Tables.Add("salebillingbranch");
            dsSaleBilling.Tables[0].Columns.Add("yearfromto");
            dsSaleBilling.Tables[0].Columns.Add("zone");
            dsSaleBilling.Tables[0].Columns.Add("branchname");
            dsSaleBilling.Tables[0].Columns.Add("aprsale");
            dsSaleBilling.Tables[0].Columns.Add("aprbilling");
            dsSaleBilling.Tables[0].Columns.Add("maysale");
            dsSaleBilling.Tables[0].Columns.Add("maybilling");
            dsSaleBilling.Tables[0].Columns.Add("junsale");
            dsSaleBilling.Tables[0].Columns.Add("junbilling");
            dsSaleBilling.Tables[0].Columns.Add("julsale");
            dsSaleBilling.Tables[0].Columns.Add("julbilling");
            dsSaleBilling.Tables[0].Columns.Add("augsale");
            dsSaleBilling.Tables[0].Columns.Add("augbilling");
            dsSaleBilling.Tables[0].Columns.Add("sepsale");
            dsSaleBilling.Tables[0].Columns.Add("sepbilling");

            dsSaleBilling.Tables[0].Columns.Add("octsale");
            dsSaleBilling.Tables[0].Columns.Add("octbilling");
            dsSaleBilling.Tables[0].Columns.Add("novsale");
            dsSaleBilling.Tables[0].Columns.Add("novbilling");
            dsSaleBilling.Tables[0].Columns.Add("decsale");
            dsSaleBilling.Tables[0].Columns.Add("decbilling");
            dsSaleBilling.Tables[0].Columns.Add("jansale");
            dsSaleBilling.Tables[0].Columns.Add("janbilling");
            dsSaleBilling.Tables[0].Columns.Add("febsale");
            dsSaleBilling.Tables[0].Columns.Add("febbilling");
            dsSaleBilling.Tables[0].Columns.Add("marsale");
            dsSaleBilling.Tables[0].Columns.Add("marbilling");

            dsSaleBilling.Tables[0].Columns.Add("saletotal");
            dsSaleBilling.Tables[0].Columns.Add("billingtotal");
            dsSaleBilling.Tables[0].Columns.Add("arpusalebilling");
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

            ds = objReport.rptSalesBillingBranchWise(fromYear, toYear, strZoneParameter);

            int ix = 0;
            int ixMonthNew = 0;
            int ixYearNew = 0;

            foreach (string strZone in strZoneList)
            {
                for (int iAnand = fromYear; iAnand < toYear; iAnand++)
                {
                    strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();


                    string[] strBranchList = getBranchName(ds, iAnand, strZone).Split(',');

                    foreach (string strBranch in strBranchList)
                    {
                        if (strBranch != "")
                        {
                            dsSaleBilling.Tables[0].Rows.Add(strYearFromTo, strZone, strBranch, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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

                                dsSaleCount = getSaleCountByYearMonth(ixMonthNew, ixYearNew, strZone, strBranch, ds.Tables["sale"]);
                                dsBillingCount = getBillingByYearMonth(ixMonthNew, ixYearNew, strZone, strBranch, ds.Tables["Billing"]);

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


                                dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = saleCount.ToString();
                                dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(revenueAmount).ToString();
                            }


                            dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountTotal.ToString();
                            dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountTotal).ToString();

                            double arpu = revenueAmountTotal / saleCountTotal;

                            dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpu).ToString();

                            ix = ix + 1;
                        }

                    }

                    DataTable dsSalecountTotal = getSaleBillingCountTotalByYear(strYearFromTo, strZone, dsSaleBilling.Tables[0]);

                    if (dsSalecountTotal.Rows.Count > 0)
                    {
                        // Get Total of the YEar 
                        dsSaleBilling.Tables[0].Rows.Add("", strZone + " Total", "",0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                        for (int iJS = 4; iJS <= 15; iJS++)
                        {
                            ixMonthNew = iJS;
                            ixYearNew = iAnand;

                            if (ixMonthNew > 12)
                            {
                                ixMonthNew = ixMonthNew - 12;
                                ixYearNew = iAnand + 1;
                            }
                            int dSaleCount = 0;
                            double dRevenueAmount = 0;

                            for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                            {
                                dSaleCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                                dRevenueAmount += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                            }

                            dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                            dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                        }

                        int saleCountGrandTotal = 0;
                        double revenueAmountGrandTotal = 0;

                        for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        {
                            saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["saletotal"]);
                            revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN]["billingtotal"]);
                        }

                        dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountGrandTotal.ToString();
                        dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                        double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                        dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                        ix = ix + 1;
                    }

                    //dsSaleBilling.Tables[0].Rows.Add("", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    //ix = ix + 1;

                }

                //RadGrid1New.Visible = true;
                //RadGrid1New.DataSource = dsSaleBilling.Tables[0];
                //RadGrid1New.DataBind();
                RAFRepeater.DataSource = dsSaleBilling.Tables[0];
                RAFRepeater.DataBind();

                RepeaterNew.DataSource = dsSaleBilling.Tables[0];
                RepeaterNew.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
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

    private DataTable getSaleCountByYearMonth(int month, int year, string strZone, string strBranch, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("saleyear=" + year + " and salemonth=" + month + " and zone='" + strZone + "'" + " and branchname='" + strBranch + "'");
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

    private DataTable getBillingByYearMonth(int month, int year, string strZone, string strBranch, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("billingyear=" + year + " and billingmonth=" + month + " and zone='" + strZone + "'" + " and branchname='" + strBranch + "'");
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

    private DataTable getSaleBillingCountTotalByYear(string cYearFromTo, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "'" + " and zone='" + strZone + "'");
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

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblZone = e.Item.FindControl("lblZone") as Label;
            if (lblZone.Text.Contains("Total"))
            {

                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
                row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");

            }

            //Label lblaprilsale = (Label)e.Item.FindControl("lblaprilsale");
            //Label lblaprilbilling = (Label)e.Item.FindControl("lblaprilbilling");

            //Label lblmaysale = (Label)e.Item.FindControl("lblmaysale");
            //Label lblmaybilling = (Label)e.Item.FindControl("lblmaybilling");

            //Label lbljunesale = (Label)e.Item.FindControl("lbljunesale");
            //Label lbljunebilling = (Label)e.Item.FindControl("lbljunebilling");

            //Label lbljulysale = (Label)e.Item.FindControl("lbljulysale");
            //Label lbljulybilling = (Label)e.Item.FindControl("lbljulybilling");

            //Label lblaugsale = (Label)e.Item.FindControl("lblaugsale");
            //Label lblaugbilling = (Label)e.Item.FindControl("lblaugbilling");

            //Label lblseptsale = (Label)e.Item.FindControl("lblseptsale");
            //Label lblseptbilling = (Label)e.Item.FindControl("lblseptbilling");

            //Label lbloctsale = (Label)e.Item.FindControl("lbloctsale");
            //Label lbloctbilling = (Label)e.Item.FindControl("lbloctbilling");

            //Label lblnovsale = (Label)e.Item.FindControl("lblnovsale");
            //Label lblnovbilling = (Label)e.Item.FindControl("lblnovbilling");

            //Label lbldecsale = (Label)e.Item.FindControl("lbldecsale");
            //Label lbldecbilling = (Label)e.Item.FindControl("lbldecbilling");

            //Label lbljansale = (Label)e.Item.FindControl("lbljansale");
            //Label lbljanbilling = (Label)e.Item.FindControl("lbljanbilling");

            //Label lblfebsale = (Label)e.Item.FindControl("lblfebsale");
            //Label lblfebbilling = (Label)e.Item.FindControl("lblfebbilling");

            //Label lblmarsale = (Label)e.Item.FindControl("lblmarsale");
            //Label lblmarbilling = (Label)e.Item.FindControl("lblmarbilling");

            //Label lblsalegrandtotal = (Label)e.Item.FindControl("lblsaletotal");
            //Label lblbillinggrandtotal = (Label)e.Item.FindControl("lblbillingtotal");


            //sale_grand_total += Convert.ToDecimal(lblsalegrandtotal.Text);
            //billing_grand_total += Convert.ToDecimal(lblbillinggrandtotal.Text);

            //april_sale += Convert.ToDecimal(lblaprilsale.Text);
            //may_sale += Convert.ToDecimal(lblmaysale.Text);
            //june_sale += Convert.ToDecimal(lbljunesale.Text);
            //july_sale += Convert.ToDecimal(lbljulysale.Text);
            //aug_sale += Convert.ToDecimal(lblaugsale.Text);
            //sept_sale += Convert.ToDecimal(lblseptsale.Text);
            //oct_sale += Convert.ToDecimal(lbloctsale.Text);
            //nov_sale += Convert.ToDecimal(lblnovsale.Text);
            //dec_sale += Convert.ToDecimal(lbldecsale.Text);
            //jan_sale += Convert.ToDecimal(lbljansale.Text);
            //feb_sale += Convert.ToDecimal(lblfebsale.Text);
            //mar_sale += Convert.ToDecimal(lblmarsale.Text);



            //april_billing += Convert.ToDecimal(lblaprilbilling.Text);
            //may_billing += Convert.ToDecimal(lblmaybilling.Text);
            //june_billing += Convert.ToDecimal(lbljunebilling.Text);
            //july_billing += Convert.ToDecimal(lbljulybilling.Text);
            //aug_billing += Convert.ToDecimal(lblaugbilling.Text);
            //sept_billing += Convert.ToDecimal(lblseptbilling.Text);
            //oct_billing += Convert.ToDecimal(lbloctbilling.Text);
            //nov_billing += Convert.ToDecimal(lblnovbilling.Text);
            //dec_billing += Convert.ToDecimal(lbldecbilling.Text);
            //jan_billing += Convert.ToDecimal(lbljanbilling.Text);
            //feb_billing += Convert.ToDecimal(lblfebbilling.Text);
            //mar_billing += Convert.ToDecimal(lblmarbilling.Text);



        }

    }

    protected string getBranchName(DataSet ds, int iyear, string strZone)
    {
        DataTable dtSaleBillBranch = new DataTable();
        DataTable dtSale = new DataTable();

        dtSale = getsaleByYearMonthZone(0, iyear, strZone, ds.Tables["sale"]);
        dtSaleBillBranch = getBillingByYearMonthZone(0, iyear, strZone, ds.Tables["billing"]);

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
}