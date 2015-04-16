using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class MISReport_rptSaleCategoryMonthWise : System.Web.UI.Page
{
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

    int april_headcount = 0;
    int may_headcount = 0;
    int june_headcount = 0;
    int july_headcount = 0;
    int aug_headcount = 0;
    int sept_headcount = 0;
    int oct_headcount = 0;
    int nov_headcount = 0;
    int dec_headcount = 0;
    int jan_headcount = 0;
    int feb_headcount = 0;
    int mar_headcount = 0;
    int headcount_grand_total = 0;

    double currentARPUCount = 0;
    double lastARPUCount = 0;

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
            string saleCategory = Request.QueryString["zonename"].ToString();

            saleCategory = saleCategory.Replace("Total", "");

            int iFromYear = Convert.ToInt32(yearFrom.Substring(0, 4));
            int iToYear = Convert.ToInt32(yearFrom.Substring(5, 4));

            bindDataToDataSet(iFromYear, iToYear, saleCategory);

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

    void bindDataToDataSet(int iFromYear, int iToYear, string saleCate)
    {
        try
        {
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();
            DataSet ds = new DataSet();
            DataSet dsSaleBilling = new DataSet();

            DataSet dsSaleCategoryTotal = new DataSet();
            dsSaleCategoryTotal.Tables.Add("salecatetotal");
            dsSaleCategoryTotal.Tables[0].Columns.Add("salecategoryname");
            dsSaleCategoryTotal.Tables[0].Columns.Add("saletotal", typeof(double));


            #region columns add

            dsSaleBilling.Tables.Add("salebilling");
            dsSaleBilling.Tables[0].Columns.Add("yearfromto");
            dsSaleBilling.Tables[0].Columns.Add("salecategoryname");
            dsSaleBilling.Tables[0].Columns.Add("aprsale");
            dsSaleBilling.Tables[0].Columns.Add("aprbilling");
            dsSaleBilling.Tables[0].Columns.Add("aprheadcount");

            dsSaleBilling.Tables[0].Columns.Add("maysale");
            dsSaleBilling.Tables[0].Columns.Add("maybilling");
            dsSaleBilling.Tables[0].Columns.Add("mayheadcount");

            dsSaleBilling.Tables[0].Columns.Add("junsale");
            dsSaleBilling.Tables[0].Columns.Add("junbilling");
            dsSaleBilling.Tables[0].Columns.Add("junheadcount");

            dsSaleBilling.Tables[0].Columns.Add("julsale");
            dsSaleBilling.Tables[0].Columns.Add("julbilling");
            dsSaleBilling.Tables[0].Columns.Add("julheadcount");

            dsSaleBilling.Tables[0].Columns.Add("augsale");
            dsSaleBilling.Tables[0].Columns.Add("augbilling");
            dsSaleBilling.Tables[0].Columns.Add("augheadcount");

            dsSaleBilling.Tables[0].Columns.Add("sepsale");
            dsSaleBilling.Tables[0].Columns.Add("sepbilling");
            dsSaleBilling.Tables[0].Columns.Add("sepheadcount");

            dsSaleBilling.Tables[0].Columns.Add("octsale");
            dsSaleBilling.Tables[0].Columns.Add("octbilling");
            dsSaleBilling.Tables[0].Columns.Add("octheadcount");

            dsSaleBilling.Tables[0].Columns.Add("novsale");
            dsSaleBilling.Tables[0].Columns.Add("novbilling");
            dsSaleBilling.Tables[0].Columns.Add("novheadcount");

            dsSaleBilling.Tables[0].Columns.Add("decsale");
            dsSaleBilling.Tables[0].Columns.Add("decbilling");
            dsSaleBilling.Tables[0].Columns.Add("decheadcount");

            dsSaleBilling.Tables[0].Columns.Add("jansale");
            dsSaleBilling.Tables[0].Columns.Add("janbilling");
            dsSaleBilling.Tables[0].Columns.Add("janheadcount");

            dsSaleBilling.Tables[0].Columns.Add("febsale");
            dsSaleBilling.Tables[0].Columns.Add("febbilling");
            dsSaleBilling.Tables[0].Columns.Add("febheadcount");

            dsSaleBilling.Tables[0].Columns.Add("marsale");
            dsSaleBilling.Tables[0].Columns.Add("marbilling");
            dsSaleBilling.Tables[0].Columns.Add("marheadcount");

            dsSaleBilling.Tables[0].Columns.Add("saletotal");
            dsSaleBilling.Tables[0].Columns.Add("billingtotal");
            dsSaleBilling.Tables[0].Columns.Add("headcounttotal");
            #endregion

            DataTable dsSaleCount = new DataTable();
            DataTable dsBillingCount = new DataTable();
            DataTable dtHeadCount = new DataTable();

            string strYearFromTo = string.Empty;
            int saleCount = 0;
            double revenueAmount = 0;
            int saleCountTotal = 0;
            double revenueAmountTotal = 0;

            int headCount = 0;
            int headCountTotal = 0;

            int fromYear = iFromYear;
            int toYear = iToYear;

            ds = objReport.getSaleCountBillingHeadCount(fromYear, toYear, saleCate);

            int ix = 0;
            int ixMonthNew = 0;

            int ixYearNew = 0;
            string strSaleCategory = string.Empty;

            foreach (DataRow drAnand in ds.Tables["salecategory"].Rows)
            {
                strSaleCategory = drAnand["salecategoryname"].ToString();
                for (int iAnand = fromYear; iAnand < toYear; iAnand++)
                {

                    strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                    dsSaleBilling.Tables[0].Rows.Add(strYearFromTo, strSaleCategory, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    saleCountTotal = 0;
                    revenueAmountTotal = 0;
                    headCountTotal = 0;

                    for (int iJS = 4; iJS <= 15; iJS++)
                    {
                        ixMonthNew = iJS;
                        ixYearNew = iAnand;

                        if (ixMonthNew > 12)
                        {
                            ixMonthNew = ixMonthNew - 12;
                            ixYearNew = iAnand + 1;
                        }

                        dsSaleCount = getSaleCountByYearMonth(strSaleCategory, ixMonthNew, ixYearNew, ds.Tables["sale"]);
                        dsBillingCount = getBillingByYearMonth(strSaleCategory, ixMonthNew, ixYearNew, ds.Tables["Billing"]);
                        dtHeadCount = getHeadCountByYearMonth(strSaleCategory, ixMonthNew, ixYearNew, ds.Tables["headcount"]);


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

                        if (dtHeadCount.Rows.Count > 0)
                        {
                            headCount = Convert.ToInt32(dtHeadCount.Rows[0]["headcountTotal"]);
                            headCountTotal += headCount;
                        }
                        else
                        {
                            headCount = 0;
                        }

                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = saleCount.ToString();
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(revenueAmount).ToString();
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "headcount"] = headCount.ToString();
                    }

                    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountTotal.ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountTotal).ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["headcounttotal"] = headCountTotal.ToString();

                    //double arpu = revenueAmountTotal / saleCountTotal;

                    //dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpu).ToString();
                    if (saleCountTotal == 0 && revenueAmountTotal == 0 && headCountTotal == 0)
                    {
                        dsSaleBilling.Tables[0].Rows[ix].Delete();
                    }
                    else
                    {
                        ix = ix + 1;
                    }

                }


                DataTable dsSalecountTotal = getSaleBillingHeadCountByCategory(strSaleCategory, dsSaleBilling.Tables[0]);

                if (dsSalecountTotal.Rows.Count > 0)
                {
                    // Get Total of the YEar 
                    dsSaleBilling.Tables[0].Rows.Add("", strSaleCategory + " Total", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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
                        int dHeadCount = 0;

                        for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                        {
                            dSaleCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "sale"]);
                            dRevenueAmount += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "billing"]);
                            dHeadCount += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN][getMthName(ixMonthNew) + "headcount"]);
                        }

                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "sale"] = dSaleCount.ToString();
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "billing"] = Math.Round(dRevenueAmount).ToString();
                        dsSaleBilling.Tables[0].Rows[ix][getMthName(ixMonthNew) + "headcount"] = dHeadCount.ToString();
                    }

                    int saleCountGrandTotal = 0;
                    double revenueAmountGrandTotal = 0;
                    int headcountGrandTotal = 0;

                    for (int iSSDN = 0; iSSDN < dsSalecountTotal.Rows.Count; iSSDN++)
                    {
                        saleCountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["saletotal"]);
                        revenueAmountGrandTotal += Convert.ToDouble(dsSalecountTotal.Rows[iSSDN]["billingtotal"]);
                        headcountGrandTotal += Convert.ToInt32(dsSalecountTotal.Rows[iSSDN]["headcounttotal"]);
                    }

                    dsSaleBilling.Tables[0].Rows[ix]["saletotal"] = saleCountGrandTotal.ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["billingtotal"] = Math.Round(revenueAmountGrandTotal).ToString();
                    dsSaleBilling.Tables[0].Rows[ix]["headcounttotal"] = (headcountGrandTotal).ToString();

                    //double arpuGrand = revenueAmountGrandTotal / saleCountGrandTotal;
                    //dsSaleBilling.Tables[0].Rows[ix]["arpusalebilling"] = Math.Round(arpuGrand).ToString();

                    if (saleCountGrandTotal == 0 && revenueAmountGrandTotal == 0 && headcountGrandTotal == 0)
                    {
                        dsSaleBilling.Tables[0].Rows[ix].Delete();
                    }
                    else
                    {
                        dsSaleCategoryTotal.Tables[0].Rows.Add(strSaleCategory, saleCountGrandTotal);
                        ix = ix + 1;
                    }
                    //}

                }

            }
            DataTable dtNewSale = new DataTable();
            dtNewSale = dsOrderBySale(dsSaleBilling.Tables[0], dsSaleCategoryTotal.Tables[0]);

            RAFRepeater.DataSource = dsSaleBilling.Tables[0];
            RAFRepeater.DataBind();

        }
        catch (Exception ex)
        {
            err.Text = ex.Message;
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

    private DataTable getSaleBillingHeadCountByCategory(string saleCategory, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("salecategoryname='" + saleCategory + "'");
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

    private DataTable getSaleCountByYearMonth(string saleCategory, int month, int year, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("salecategoryname='" + saleCategory + "'" + " and saleyear=" + year + " and salemonth=" + month);
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

    private DataTable getBillingByYearMonth(string saleCategory, int month, int year, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("salecategoryname='" + saleCategory + "'" + " and billingyear=" + year + " and billingmonth=" + month);
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

    private DataTable getHeadCountByYearMonth(string saleCategory, int month, int year, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("salecategoryname='" + saleCategory + "'" + " and headcountyear=" + year + " and headcountmonth=" + month);
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
            //Image imgShowGrowth = e.Item.FindControl("imgShowGrowth") as Image;
            Label lblSaleCategory = e.Item.FindControl("lblSaleCategory") as Label;

            if (lblSaleCategory.Text.Contains("Total"))
            {
                //imgShowGrowth.Visible = false;
                //lastARPUCount = 0;
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
                row.Attributes.Add("style", "background-color:gray;color:White;font-weight:bold");
            }
            else
            {
                //HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("drow");
                ////row.Cells[0].CssClass = "openmenu";
                //row.Cells[2].Attributes.Add("style", "background-color:#ccc;color:Black;");
                //row.Cells[3].Attributes.Add("style", "background-color:#ccc;color:Black;");
                //row.Cells[4].Attributes.Add("style", "background-color:#ccc;color:Black;");

                ////row.Cells[5].Attributes.Add("style", "background-color:red;color:White;");
                ////row.Cells[6].Attributes.Add("style", "background-color:red;color:White;");
                ////row.Cells[7].Attributes.Add("style", "background-color:red;color:White;");

                //row.Cells[8].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[9].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[10].Attributes.Add("style", "background-color:#CCC;color:Black;");

                ////row.Cells[11].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[12].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[13].Attributes.Add("style", "background-color:#CCC;color:Black;");

                //row.Cells[14].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[15].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[16].Attributes.Add("style", "background-color:#CCC;color:Black;");

                ////row.Cells[17].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[18].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[19].Attributes.Add("style", "background-color:#CCC;color:Black;");

                //row.Cells[20].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[21].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[22].Attributes.Add("style", "background-color:#CCC;color:Black;");

                ////row.Cells[23].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[24].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[25].Attributes.Add("style", "background-color:#CCC;color:Black;");

                //row.Cells[26].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[27].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[28].Attributes.Add("style", "background-color:#CCC;color:Black;");

                ////row.Cells[29].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[30].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[31].Attributes.Add("style", "background-color:#CCC;color:Black;");

                //row.Cells[32].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[33].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[34].Attributes.Add("style", "background-color:#CCC;color:Black;");

                ////row.Cells[35].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[36].Attributes.Add("style", "background-color:#CCC;color:Black;");
                ////row.Cells[37].Attributes.Add("style", "background-color:#CCC;color:Black;");

                //row.Cells[38].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[39].Attributes.Add("style", "background-color:#CCC;color:Black;");
                //row.Cells[40].Attributes.Add("style", "background-color:#CCC;color:Black;");

                
                Label lblaprilsale = (Label)e.Item.FindControl("lblaprilsale");
                Label lblaprilbilling = (Label)e.Item.FindControl("lblaprilbilling");
                Label lblaprilheadcount = (Label)e.Item.FindControl("lblaprilheadcount");

                Label lblmaysale = (Label)e.Item.FindControl("lblmaysale");
                Label lblmaybilling = (Label)e.Item.FindControl("lblmaybilling");
                Label lblmayheadcount = (Label)e.Item.FindControl("lblmayheadcount");

                Label lbljunesale = (Label)e.Item.FindControl("lbljunesale");
                Label lbljunebilling = (Label)e.Item.FindControl("lbljunebilling");
                Label lbljuneheadcount = (Label)e.Item.FindControl("lbljuneheadcount");

                Label lbljulysale = (Label)e.Item.FindControl("lbljulysale");
                Label lbljulybilling = (Label)e.Item.FindControl("lbljulybilling");
                Label lbljulyheadcount = (Label)e.Item.FindControl("lbljulyheadcount");

                Label lblaugsale = (Label)e.Item.FindControl("lblaugsale");
                Label lblaugbilling = (Label)e.Item.FindControl("lblaugbilling");
                Label lblaugheadcount = (Label)e.Item.FindControl("lblaugheadcount");

                Label lblseptsale = (Label)e.Item.FindControl("lblseptsale");
                Label lblseptbilling = (Label)e.Item.FindControl("lblseptbilling");
                Label lblseptheadcount = (Label)e.Item.FindControl("lblseptheadcount");

                Label lbloctsale = (Label)e.Item.FindControl("lbloctsale");
                Label lbloctbilling = (Label)e.Item.FindControl("lbloctbilling");
                Label lbloctheadcount = (Label)e.Item.FindControl("lbloctheadcount");

                Label lblnovsale = (Label)e.Item.FindControl("lblnovsale");
                Label lblnovbilling = (Label)e.Item.FindControl("lblnovbilling");
                Label lblnovheadcount = (Label)e.Item.FindControl("lblnovheadcount");

                Label lbldecsale = (Label)e.Item.FindControl("lbldecsale");
                Label lbldecbilling = (Label)e.Item.FindControl("lbldecbilling");
                Label lbldecheadcount = (Label)e.Item.FindControl("lbldecheadcount");

                Label lbljansale = (Label)e.Item.FindControl("lbljansale");
                Label lbljanbilling = (Label)e.Item.FindControl("lbljanbilling");
                Label lbljanheadcount = (Label)e.Item.FindControl("lbljanheadcount");

                Label lblfebsale = (Label)e.Item.FindControl("lblfebsale");
                Label lblfebbilling = (Label)e.Item.FindControl("lblfebbilling");
                Label lblfebheadcount = (Label)e.Item.FindControl("lblfebheadcount");

                Label lblmarsale = (Label)e.Item.FindControl("lblmarsale");
                Label lblmarbilling = (Label)e.Item.FindControl("lblmarbilling");
                Label lblmarheadcount = (Label)e.Item.FindControl("lblmarheadcount");

                Label lblsalegrandtotal = (Label)e.Item.FindControl("lblsaletotal");
                Label lblbillinggrandtotal = (Label)e.Item.FindControl("lblbillingtotal");
                Label lblheadcountgrandtotal = (Label)e.Item.FindControl("lblheadcounttotal");


                sale_grand_total += Convert.ToDecimal(lblsalegrandtotal.Text);
                billing_grand_total += Convert.ToDecimal(lblbillinggrandtotal.Text);
                headcount_grand_total += Convert.ToInt32(lblheadcountgrandtotal.Text); 

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

                april_headcount += Convert.ToInt32(lblaprilheadcount.Text);
                may_headcount += Convert.ToInt32(lblmayheadcount.Text);
                june_headcount += Convert.ToInt32(lbljuneheadcount.Text);
                july_headcount += Convert.ToInt32(lbljulyheadcount.Text);
                aug_headcount += Convert.ToInt32(lblaugheadcount.Text);
                sept_headcount += Convert.ToInt32(lblseptheadcount.Text);
                oct_headcount += Convert.ToInt32(lbloctheadcount.Text);
                nov_headcount += Convert.ToInt32(lblnovheadcount.Text);
                dec_headcount += Convert.ToInt32(lbldecheadcount.Text);
                jan_headcount += Convert.ToInt32(lbljanheadcount.Text);
                feb_headcount += Convert.ToInt32(lblfebheadcount.Text);
                mar_headcount += Convert.ToInt32(lblmarheadcount.Text);
            }

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
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblaprilsaletotal = (Label)e.Item.FindControl("lblaprilsaletotal");
            Label lblaprilbillingtotal = (Label)e.Item.FindControl("lblaprilbillingtotal");
            Label lblaprilheadcounttotal = (Label)e.Item.FindControl("lblaprilheadcounttotal");

            Label lblmaysaletotal = (Label)e.Item.FindControl("lblmaysaletotal");
            Label lblmaybillingtotal = (Label)e.Item.FindControl("lblmaybillingtotal");
            Label lblmayheadcounttotal = (Label)e.Item.FindControl("lblmayheadcounttotal");

            Label lbljunesaletotal = (Label)e.Item.FindControl("lbljunesaletotal");
            Label lbljunebillingtotal = (Label)e.Item.FindControl("lbljunebillingtotal");
            Label lbljuneheadcounttotal = (Label)e.Item.FindControl("lbljuneheadcounttotal");

            Label lbljulysaletotal = (Label)e.Item.FindControl("lbljulysaletotal");
            Label lbljulybillingtotal = (Label)e.Item.FindControl("lbljulybillingtotal");
            Label lbljulyheadcounttotal = (Label)e.Item.FindControl("lbljulyheadcounttotal");

            Label lblaugsaletotal = (Label)e.Item.FindControl("lblaugsaletotal");
            Label lblaugbillingtotal = (Label)e.Item.FindControl("lblaugbillingtotal");
            Label lblaugheadcounttotal = (Label)e.Item.FindControl("lblaugheadcounttotal");

            Label lblseptsaletotal = (Label)e.Item.FindControl("lblseptsaletotal");
            Label lblseptbillingtotal = (Label)e.Item.FindControl("lblseptbillingtotal");
            Label lblseptheadcounttotal = (Label)e.Item.FindControl("lblseptheadcounttotal");

            Label lbloctsaletotal = (Label)e.Item.FindControl("lbloctsaletotal");
            Label lbloctbillingtotal = (Label)e.Item.FindControl("lbloctbillingtotal");
            Label lbloctheadcounttotal = (Label)e.Item.FindControl("lbloctheadcounttotal");

            Label lblnovsaletotal = (Label)e.Item.FindControl("lblnovsaletotal");
            Label lblnovbillingtotal = (Label)e.Item.FindControl("lblnovbillingtotal");
            Label lblnovheadcounttotal = (Label)e.Item.FindControl("lblnovheadcounttotal");

            Label lbldecsaletotal = (Label)e.Item.FindControl("lbldecsaletotal");
            Label lbldecbillingtotal = (Label)e.Item.FindControl("lbldecbillingtotal");
            Label lbldecheadcounttotal = (Label)e.Item.FindControl("lbldecheadcounttotal");

            Label lbljansaletotal = (Label)e.Item.FindControl("lbljansaletotal");
            Label lbljanbillingtotal = (Label)e.Item.FindControl("lbljanbillingtotal");
            Label lbljanheadcounttotal = (Label)e.Item.FindControl("lbljanheadcounttotal");

            Label lblfebsaletotal = (Label)e.Item.FindControl("lblfebsaletotal");
            Label lblfebbillingtotal = (Label)e.Item.FindControl("lblfebbillingtotal");
            Label lblfebheadcounttotal = (Label)e.Item.FindControl("lblfebheadcounttotal");

            Label lblmarsaletotal = (Label)e.Item.FindControl("lblmarsaletotal");
            Label lblmarbillingtotal = (Label)e.Item.FindControl("lblmarbillingtotal");
            Label lblmarheadcounttotal = (Label)e.Item.FindControl("lblmarheadcounttotal");

            Label lblsalegrandtotal = (Label)e.Item.FindControl("lblsalegrandtotal");
            Label lblbillinggrandtotal = (Label)e.Item.FindControl("lblbillinggrandtotal");
            Label lblheadcountgrandtotal = (Label)e.Item.FindControl("lblheadcountgrandtotal");

            lblsalegrandtotal.Text = Math.Round(sale_grand_total).ToString();
            lblbillinggrandtotal.Text = Math.Round(billing_grand_total).ToString();
            lblheadcountgrandtotal.Text = headcount_grand_total.ToString();

            //Label lblarpugrandtotal = (Label)e.Item.FindControl("lblarpugrandtotal");
            //decimal arpu = billing_grand_total / sale_grand_total;

            //lblarpugrandtotal.Text = Math.Round(arpu).ToString();
            // ========
            lblaprilsaletotal.Text = april_sale.ToString();
            lblaprilbillingtotal.Text = april_billing.ToString();
            lblaprilheadcounttotal.Text = april_headcount.ToString();

            lblmaysaletotal.Text = may_sale.ToString();
            lblmaybillingtotal.Text = may_billing.ToString();
            lblmayheadcounttotal.Text = may_headcount.ToString();

            lbljunesaletotal.Text = june_sale.ToString();
            lbljunebillingtotal.Text = june_billing.ToString();
            lbljuneheadcounttotal.Text = june_headcount.ToString();

            lbljulysaletotal.Text = july_sale.ToString();
            lbljulybillingtotal.Text = july_billing.ToString();
            lbljulyheadcounttotal.Text = july_headcount.ToString();

            lblaugsaletotal.Text = aug_sale.ToString();
            lblaugbillingtotal.Text = aug_billing.ToString();
            lblaugheadcounttotal.Text = aug_headcount.ToString();

            lblseptsaletotal.Text = sept_sale.ToString();
            lblseptbillingtotal.Text = sept_billing.ToString();
            lblseptheadcounttotal.Text = sept_headcount.ToString();

            lbloctsaletotal.Text = oct_sale.ToString();
            lbloctbillingtotal.Text = oct_billing.ToString();
            lbloctheadcounttotal.Text = oct_headcount.ToString();

            lblnovsaletotal.Text = nov_sale.ToString();
            lblnovbillingtotal.Text = nov_billing.ToString();
            lblnovheadcounttotal.Text = nov_headcount.ToString();

            lbldecsaletotal.Text = dec_sale.ToString();
            lbldecbillingtotal.Text = dec_billing.ToString();
            lbldecheadcounttotal.Text = dec_headcount.ToString();

            lbljansaletotal.Text = jan_sale.ToString();
            lbljanbillingtotal.Text = jan_billing.ToString();
            lbljanheadcounttotal.Text = jan_headcount.ToString();

            lblfebsaletotal.Text = feb_sale.ToString();
            lblfebbillingtotal.Text = feb_billing.ToString();
            lblfebheadcounttotal.Text = feb_headcount.ToString();

            lblmarsaletotal.Text = mar_sale.ToString();
            lblmarbillingtotal.Text = mar_billing.ToString();
            lblmarheadcounttotal.Text = mar_headcount.ToString();


        }
    }

    private DataTable dsOrderBySale(DataTable dsSale, DataTable dsBranchTot)
    {
        DataTable dsNew = new DataTable();
        DataTable dsNewAll = new DataTable();
        dsBranchTot = getOrderByBranchTotal(dsBranchTot);
        string brnch = string.Empty;
        string brnchtotal = string.Empty;

        if (dsBranchTot.Rows.Count > 0)
        {
            foreach (DataRow dr in dsBranchTot.Rows)
            {
                DataRow[] foundRows;
                brnch = dr["salecategoryname"].ToString();
                brnchtotal = brnch + " Total";

                foundRows = dsSale.Select("salecategoryname='" + brnch + "' or salecategoryname='" + brnchtotal + "'");
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

   
}