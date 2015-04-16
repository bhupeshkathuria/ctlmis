using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class MISReport_rptSaleBillingZoneWisePopUP : System.Web.UI.Page
{
    double currentARPUCount = 0;
    double lastARPUCount = 0;
    string branchname = string.Empty;

    decimal april_sale = 0;
    decimal may_sale = 0;
    decimal june_sale = 0;
    decimal july_sale = 0;
    decimal aug_sale = 0;
    decimal sept_sale = 0;
    decimal oct_sale = 0;
    decimal nov_sale = 0;
    decimal dec_sale = 0;
    decimal jan_sale = 0;
    decimal feb_sale = 0;
    decimal mar_sale = 0;


    decimal apr_salesforce = 0;
    decimal may_salesforce = 0;
    decimal jun_salesforce = 0;
    decimal jul_salesforce = 0;
    decimal aug_salesforce = 0;
    decimal sep_salesforce = 0;
    decimal oct_salesforce = 0;
    decimal nov_salesforce = 0;
    decimal dec_salesforce = 0;
    decimal jan_salesforce = 0;
    decimal feb_salesforce = 0;
    decimal mar_salesforce = 0;

    decimal salesforceGrandTotal = 0;

    decimal sale_grand_total = 0;
    decimal billing_grand_total = 0;
    decimal arpu_grand_total = 0;


    decimal april_billing = 0;
    decimal may_billing = 0;
    decimal june_billing = 0;
    decimal july_billing = 0;
    decimal aug_billing = 0;
    decimal sept_billing = 0;
    decimal oct_billing = 0;
    decimal nov_billing = 0;
    decimal dec_billing = 0;
    decimal jan_billing = 0;
    decimal feb_billing = 0;
    decimal mar_billing = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            //if (!IsPostBack)
            //{
            //    loadYear();
            //}
            string yearFrom = Request.QueryString["yearfromto"].ToString();

            int iFromYear = Convert.ToInt32(yearFrom.Substring(0, 4));
            int iToYear = Convert.ToInt32(yearFrom.Substring(5, 4));

            bindDataToDataSet(iFromYear, iToYear);

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

    void bindDataToDataSet(int iFromYear, int iToYear)
    {
        try
        {
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();
            DataSet ds = new DataSet();
            DataSet dsSaleBilling = new DataSet();

            string[] strZones = new string[4];

            strZones[0] = "North";
            strZones[1] = "West";
            strZones[2] = "South";
            strZones[3] = "East";

            #region columns add

            dsSaleBilling.Tables.Add("salebilling");
            dsSaleBilling.Tables[0].Columns.Add("yearfromto");
            dsSaleBilling.Tables[0].Columns.Add("zone");
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


            dsSaleBilling.Tables[0].Columns.Add("aprSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("maySalesForce");
            dsSaleBilling.Tables[0].Columns.Add("junSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("julSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("augSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("sepSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("octSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("novSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("decSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("janSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("febSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("marSalesForce");
            dsSaleBilling.Tables[0].Columns.Add("totalSalesForce");


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

            double accountmanagercount = 0;
            double accountmanagertotal = 0;
            double accountmanagergrand = 0;

            int fromYear = iFromYear;
            int toYear = iToYear;

            ds = objReport.rptSalesBillingYearWiseZone(fromYear, toYear);
            int ix = 0;
            int ixMonthNew = 0;

            int ixYearNew = 0;

            for (int iAnand = fromYear; iAnand < toYear; iAnand++)
            {
                strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                
                

                foreach (string strZone in strZones)
                {

                    dsSaleBilling.Tables[0].Rows.Add(strYearFromTo, strZone, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    saleCountTotal = 0;
                    revenueAmountTotal = 0;
                    accountmanagertotal = 0;

                   
                    

                    for (int iJS = 4; iJS <= 15; iJS++)
                    {
                        ixMonthNew = iJS;
                        ixYearNew = iAnand;
                        

                        if (ixMonthNew > 12)
                        {
                            ixMonthNew = ixMonthNew - 12;
                            ixYearNew = iAnand + 1;
                        }

                        dsSaleCount = getSaleCountByYearMonth(ixMonthNew, ixYearNew, strZone, ds.Tables["sale"]);
                        dsBillingCount = getBillingByYearMonth(ixMonthNew, ixYearNew, strZone, ds.Tables["Billing"]);

                        if (dsSaleCount.Rows.Count > 0)
                        {
                            saleCount = Convert.ToInt32(dsSaleCount.Rows[0]["lsaletotal"]);
                            saleCountTotal += saleCount;

                            accountmanagercount = Convert.ToInt32(dsSaleCount.Rows[0]["accountmanagercount"]);

                            accountmanagertotal += accountmanagercount;

                            
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
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "SalesForce"] = Math.Round(accountmanagercount).ToString();

                    }

                    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountTotal.ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountTotal).ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["totalSalesForce"] = Math.Round(accountmanagertotal).ToString();

                    accountmanagergrand += accountmanagertotal;

                    double arpu = revenueAmountTotal / saleCountTotal;

                    dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpu).ToString();

                    if (saleCountTotal > 0 && revenueAmountTotal > 0)
                    {
                        ix = ix + 1;
                    }
                    else
                    {
                        dsSaleBilling.Tables[0].Rows[ix].Delete();
                    }

                }

                DataTable dsSalecountTotal = getSaleBillingCountTotalByYear(strYearFromTo, dsSaleBilling.Tables[0]);

                if (dsSalecountTotal.Rows.Count > 0)
                {
                    // Get Total of the YEar 
                    dsSaleBilling.Tables[0].Rows.Add("", "Grand Total", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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

                        accountmanagertotal = 0;
                        for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        {
                            dSaleCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                            dRevenueAmount += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                            accountmanagertotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "SalesForce"]);

                        }



                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                       // dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "SalesForce"] = Math.Round(accountmanagertotal).ToString();

                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "SalesForce"] = "";

                            
                    }

                    int saleCountGrandTotal = 0;
                    double revenueAmountGrandTotal = 0;
                    //accountmanagertotal = 0;

                    for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                    {
                        saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["saletotal"]);
                        revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN]["billingtotal"]);
                    }

                    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountGrandTotal.ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                    double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                    dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpuGrand).ToString();
                    //dsSaleBilling.Tables[0].Rows[ix]["totalSalesForce"] = Math.Round(accountmanagergrand).ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["totalSalesForce"] = "";
                    accountmanagergrand = 0;

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

    private DataTable getSaleCountByYearMonth(int month, int year, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("saleyear=" + year + " and salemonth=" + month + " and zone='" + strZone + "'");
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

    private DataTable getBillingByYearMonth(int month, int year, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("billingyear=" + year + " and billingmonth=" + month + " and zone='" + strZone + "'");
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
    
    private DataTable getSaleBillingCountTotalByYear(string cYearFromTo, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("yearfromto='" + cYearFromTo + "'");
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
            Image imgShowGrowth = e.Item.FindControl("imgShowGrowth") as Image;
            Label lblzone = e.Item.FindControl("lblzone") as Label;
            if (lblzone.Text.Contains("Total"))
            {
                lastARPUCount = 0;
                imgShowGrowth.Visible = false;
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
                row.Attributes.Add("style", "background-color:gray; color:white;font-weight:bold");
            }
            else
            {
                Label lblCurrentARPUCount = e.Item.FindControl("lblARPUTotal") as Label;

                if (lblCurrentARPUCount.Text != "")
                {
                    currentARPUCount = Convert.ToDouble(lblCurrentARPUCount.Text);
                }

                // Image Display Growth and Down...
                if (lastARPUCount > 0)
                {

                    if (lastARPUCount - currentARPUCount > 0)
                    {
                        imgShowGrowth.ImageUrl = "~/MISReport/down.png";
                    }
                    else
                    {
                        imgShowGrowth.ImageUrl = "~/MISReport/up.png";
                    }
                }
                else
                {
                    imgShowGrowth.Visible = false;
                }

                if (lblCurrentARPUCount.Text != "")
                {
                    lastARPUCount = Convert.ToDouble(lblCurrentARPUCount.Text);
                }
            }

            Label lblaprilsale = (Label)e.Item.FindControl("lblaprilsale");
            Label lblaprilbilling = (Label)e.Item.FindControl("lblaprilbilling");

            Label lblmaysale = (Label)e.Item.FindControl("lblmaysale");
            Label lblmaybilling = (Label)e.Item.FindControl("lblmaybilling");

            Label lbljunesale = (Label)e.Item.FindControl("lbljunesale");
            Label lbljunebilling = (Label)e.Item.FindControl("lbljunebilling");

            Label lbljulysale = (Label)e.Item.FindControl("lbljulysale");
            Label lbljulybilling = (Label)e.Item.FindControl("lbljulybilling");

            Label lblaugsale = (Label)e.Item.FindControl("lblaugsale");
            Label lblaugbilling = (Label)e.Item.FindControl("lblaugbilling");

            Label lblseptsale = (Label)e.Item.FindControl("lblseptsale");
            Label lblseptbilling = (Label)e.Item.FindControl("lblseptbilling");

            Label lbloctsale = (Label)e.Item.FindControl("lbloctsale");
            Label lbloctbilling = (Label)e.Item.FindControl("lbloctbilling");

            Label lblnovsale = (Label)e.Item.FindControl("lblnovsale");
            Label lblnovbilling = (Label)e.Item.FindControl("lblnovbilling");

            Label lbldecsale = (Label)e.Item.FindControl("lbldecsale");
            Label lbldecbilling = (Label)e.Item.FindControl("lbldecbilling");

            Label lbljansale = (Label)e.Item.FindControl("lbljansale");
            Label lbljanbilling = (Label)e.Item.FindControl("lbljanbilling");

            Label lblfebsale = (Label)e.Item.FindControl("lblfebsale");
            Label lblfebbilling = (Label)e.Item.FindControl("lblfebbilling");

            Label lblmarsale = (Label)e.Item.FindControl("lblmarsale");
            Label lblmarbilling = (Label)e.Item.FindControl("lblmarbilling");

            Label lblsalegrandtotal = (Label)e.Item.FindControl("lblsaletotal");
            Label lblbillinggrandtotal = (Label)e.Item.FindControl("lblbillingtotal");


            sale_grand_total += Convert.ToDecimal(lblsalegrandtotal.Text);
            billing_grand_total += Convert.ToDecimal(lblbillinggrandtotal.Text);

            april_sale += Convert.ToDecimal(lblaprilsale.Text);
            may_sale += Convert.ToDecimal(lblmaysale.Text);
            june_sale += Convert.ToDecimal(lbljunesale.Text);
            july_sale += Convert.ToDecimal(lbljulysale.Text);
            aug_sale += Convert.ToDecimal(lblaugsale.Text);
            sept_sale += Convert.ToDecimal(lblseptsale.Text);
            oct_sale += Convert.ToDecimal(lbloctsale.Text);
            nov_sale += Convert.ToDecimal(lblnovsale.Text);
            dec_sale += Convert.ToDecimal(lbldecsale.Text);
            jan_sale += Convert.ToDecimal(lbljansale.Text);
            feb_sale += Convert.ToDecimal(lblfebsale.Text);
            mar_sale += Convert.ToDecimal(lblmarsale.Text);



            april_billing += Convert.ToDecimal(lblaprilbilling.Text);
            may_billing += Convert.ToDecimal(lblmaybilling.Text);
            june_billing += Convert.ToDecimal(lbljunebilling.Text);
            july_billing += Convert.ToDecimal(lbljulybilling.Text);
            aug_billing += Convert.ToDecimal(lblaugbilling.Text);
            sept_billing += Convert.ToDecimal(lblseptbilling.Text);
            oct_billing += Convert.ToDecimal(lbloctbilling.Text);
            nov_billing += Convert.ToDecimal(lblnovbilling.Text);
            dec_billing += Convert.ToDecimal(lbldecbilling.Text);
            jan_billing += Convert.ToDecimal(lbljanbilling.Text);
            feb_billing += Convert.ToDecimal(lblfebbilling.Text);
            mar_billing += Convert.ToDecimal(lblmarbilling.Text);

           

        }
       
    }
}