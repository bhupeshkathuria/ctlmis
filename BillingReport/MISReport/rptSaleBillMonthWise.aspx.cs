using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MISReport_rptSaleBillMonthWise : System.Web.UI.Page
{
    double currentARPUCount = 0;
    double lastARPUCount = 0;

    int branchid = 0;
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

   

    decimal total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        checkSession();

        try
        {
            if (!IsPostBack)
            {
                loadYear();
            }

        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

    private void loadYear()
    {
        //Load Years
        DataRow drYear;
        DataSet dsYear = new DataSet();
        DataTable dtYears = new DataTable();
        dsYear.Tables.Add(dtYears);

        DataColumn SNoColumn1 = new DataColumn();
        SNoColumn1.ColumnName = "yearVal";
        dsYear.Tables[0].Columns.Add(SNoColumn1);

        DataColumn SNoColumn2 = new DataColumn();
        SNoColumn2.ColumnName = "yearTxt";
        dsYear.Tables[0].Columns.Add(SNoColumn2);

        for (int i = 2010; i <= DateTime.Now.AddYears(1).Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }

        ddlFromYear.DataSource = dsYear.Tables[0];
        ddlFromYear.DataTextField = "yearVal";
        ddlFromYear.DataValueField = "yearTxt";
        ddlFromYear.DataBind();
        ddlFromYear.SelectedIndex = 0;

        ddlToYear.DataSource = dsYear.Tables[0];
        ddlToYear.DataTextField = "yearVal";
        ddlToYear.DataValueField = "yearTxt";
        ddlToYear.DataBind();

        ddlToYear.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;

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

    void bindDataToDataSet()
    {
        try
        {
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();
            DataSet ds = new DataSet();
            DataSet dsSaleBilling = new DataSet();

            #region columns add

            dsSaleBilling.Tables.Add("salebilling");
            dsSaleBilling.Tables[0].Columns.Add("yearfromto");
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

            int fromYear = Convert.ToInt32(ddlFromYear.SelectedValue);
            int toYear = Convert.ToInt32(ddlToYear.SelectedValue);

            ds = objReport.rptSalesBillingMonthWise(fromYear, toYear);
            int ix = 0;
            int ixMonthNew = 0;

            int ixYearNew = 0;

            for (int iAnand = fromYear; iAnand < toYear; iAnand++)
            {

                strYearFromTo = iAnand.ToString() + "-" + (iAnand + 1).ToString();
                dsSaleBilling.Tables[0].Rows.Add(strYearFromTo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

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

                    dsSaleCount = getSaleCountByYearMonth(ixMonthNew, ixYearNew, ds.Tables["sale"]);
                    dsBillingCount = getBillingByYearMonth(ixMonthNew, ixYearNew, ds.Tables["Billing"]);

                    if (dsSaleCount.Rows.Count > 0)
                    {
                        saleCount = Convert.ToInt32(dsSaleCount.Rows[0]["salecount"]);
                        saleCountTotal += saleCount;
                    }
                    else
                    {
                        saleCount = 0;
                    }

                    if (dsBillingCount.Rows.Count > 0)
                    {
                        revenueAmount = Convert.ToDouble(dsBillingCount.Rows[0]["revenuetotal"]);
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

            //RadGrid1New.Visible = true;
            //RadGrid1New.DataSource = dsSaleBilling.Tables[0];
            //RadGrid1New.DataBind();
            RAFRepeater.DataSource = dsSaleBilling.Tables[0];
            RAFRepeater.DataBind();

            bindPercentageDataSet(dsSaleBilling);



        }
        catch (Exception ex)
        {

        }
    }

    void bindPercentageDataSet(DataSet dsSalebilling)
    {
        DataSet dsSaleBillingPercentage = new DataSet();

        #region columns add

        dsSaleBillingPercentage.Tables.Add("salebillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("yearfromtoper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("aprsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("aprbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("maysaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("maybillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("junsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("junbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("julsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("julbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("augsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("augbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("sepsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("sepbillingper");

        dsSaleBillingPercentage.Tables[0].Columns.Add("octsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("octbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("novsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("novbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("decsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("decbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("jansaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("janbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("febsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("febbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("marsaleper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("marbillingper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("saletotalper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("billingtotalper");
        dsSaleBillingPercentage.Tables[0].Columns.Add("arpusalebillingper");
        #endregion

        int ix = 0;
        int ixMonthNew = 0;
        int ixYearNew = 0;
        string strYearFromTo = string.Empty;
        double saleCountTotal = 0;
        double revenueAmountTotal = 0;

        if (dsSalebilling.Tables[0].Rows.Count > 1)
        {
            for (int iAnand = 0; iAnand < dsSalebilling.Tables[0].Rows.Count; iAnand++)
            {

                if (!(dsSalebilling.Tables[0].Rows.Count - 1 == iAnand))
                {
                    strYearFromTo = dsSalebilling.Tables[0].Rows[iAnand]["yearfromto"].ToString() + " to " + dsSalebilling.Tables[0].Rows[iAnand + 1]["yearfromto"].ToString();

                    dsSaleBillingPercentage.Tables[0].Rows.Add(strYearFromTo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    for (int iJS = 4; iJS <= 15; iJS++)
                    {
                        ixMonthNew = iJS;
                        ixYearNew = iAnand;

                        if (ixMonthNew > 12)
                        {
                            ixMonthNew = ixMonthNew - 12;
                            ixYearNew = iAnand + 1;
                        }

                        string strMonth = getMthName(ixMonthNew);

                        double saleCount = Convert.ToInt32(dsSalebilling.Tables[0].Rows[iAnand][strMonth + "sale"]);
                        double revenue = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand][strMonth + "Billing"]);

                        double saleCount2 = Convert.ToInt32(dsSalebilling.Tables[0].Rows[iAnand + 1][strMonth + "sale"]);
                        double revenue2 = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand + 1][strMonth + "Billing"]);

                        double saleCountPer = saleCount / saleCount2 * 100;
                        double revenuePer = revenue / revenue2 * 100;

                        if (saleCount > 0 && saleCount2 > 0)
                            dsSaleBillingPercentage.Tables[0].Rows[iAnand][getMthName(ixMonthNew) + "saleper"] = Math.Round(saleCountPer).ToString() + "%";

                        if (revenue > 0 && revenue2 > 0)
                            dsSaleBillingPercentage.Tables[0].Rows[iAnand][getMthName(ixMonthNew) + "billingper"] = Math.Round(revenuePer).ToString() + "%";

                        saleCountTotal = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand]["saletotal"]);
                        revenueAmountTotal = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand]["Billingtotal"]);

                        double saleCount2Total = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand + 1]["saletotal"]);
                        double revenue2AmountTotal = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand + 1]["Billingtotal"]);

                        double saleCountPerTotal = saleCountTotal / saleCount2Total * 100;
                        double revenuePerTotal = revenueAmountTotal / revenue2AmountTotal * 100;

                        if (saleCountTotal > 0 && saleCount2Total > 0)
                            dsSaleBillingPercentage.Tables[0].Rows[iAnand]["saletotalper"] = Math.Round(saleCountPerTotal).ToString() + "%";

                        if (revenueAmountTotal > 0 && revenue2AmountTotal > 0)
                            dsSaleBillingPercentage.Tables[0].Rows[iAnand]["billingtotalper"] = Math.Round(revenuePerTotal).ToString() + "%";

                        double arpuSaleBillingOne = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand]["arpusalebilling"]);
                        double arpuSaleBillingNext = Convert.ToDouble(dsSalebilling.Tables[0].Rows[iAnand + 1]["arpusalebilling"]);

                        double arpu = arpuSaleBillingOne / arpuSaleBillingNext * 100;

                        if (arpuSaleBillingNext > 0 && arpuSaleBillingOne > 0)
                            dsSaleBillingPercentage.Tables[0].Rows[iAnand]["arpusalebillingper"] = Math.Round(arpu).ToString() + "%";

                    }
                }
            }

            Repeater1.DataSource = dsSaleBillingPercentage.Tables[0];
            Repeater1.DataBind();
            Repeater1.Visible = true;
        }
        else
        {
            Repeater1.Visible = false;
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

    private DataTable getSaleCountByYearMonth(int month, int year, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("saleyear=" + year + " and salemonth=" + month);
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

    private DataTable getBillingByYearMonth(int month, int year, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        try
        {
            DataRow[] foundRows;
            foundRows = dsAll.Select("billingyear=" + year + " and billingmonth=" + month);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            bindDataToDataSet();
        }
        catch (Exception ex)
        {
            err.Text = ex.Message;
        }

    }

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image imgShowGrowth = e.Item.FindControl("imgShowGrowth") as Image;

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
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblaprilsaletotal = (Label)e.Item.FindControl("lblaprilsaletotal");
            Label lblaprilbillingtotal = (Label)e.Item.FindControl("lblaprilbillingtotal");

            Label lblmaysaletotal = (Label)e.Item.FindControl("lblmaysaletotal");
            Label lblmaybillingtotal = (Label)e.Item.FindControl("lblmaybillingtotal");

            Label lbljunesaletotal = (Label)e.Item.FindControl("lbljunesaletotal");
            Label lbljunebillingtotal = (Label)e.Item.FindControl("lbljunebillingtotal");

            Label lbljulysaletotal = (Label)e.Item.FindControl("lbljulysaletotal");
            Label lbljulybillingtotal = (Label)e.Item.FindControl("lbljulybillingtotal");

            Label lblaugsaletotal = (Label)e.Item.FindControl("lblaugsaletotal");
            Label lblaugbillingtotal = (Label)e.Item.FindControl("lblaugbillingtotal");

            Label lblseptsaletotal = (Label)e.Item.FindControl("lblseptsaletotal");
            Label lblseptbillingtotal = (Label)e.Item.FindControl("lblseptbillingtotal");

            Label lbloctsaletotal = (Label)e.Item.FindControl("lbloctsaletotal");
            Label lbloctbillingtotal = (Label)e.Item.FindControl("lbloctbillingtotal");

            Label lblnovsaletotal = (Label)e.Item.FindControl("lblnovsaletotal");
            Label lblnovbillingtotal = (Label)e.Item.FindControl("lblnovbillingtotal");

            Label lbldecsaletotal = (Label)e.Item.FindControl("lbldecsaletotal");
            Label lbldecbillingtotal = (Label)e.Item.FindControl("lbldecbillingtotal");

            Label lbljansaletotal = (Label)e.Item.FindControl("lbljansaletotal");
            Label lbljanbillingtotal = (Label)e.Item.FindControl("lbljanbillingtotal");

            Label lblfebsaletotal = (Label)e.Item.FindControl("lblfebsaletotal");
            Label lblfebbillingtotal = (Label)e.Item.FindControl("lblfebbillingtotal");

            Label lblmarsaletotal = (Label)e.Item.FindControl("lblmarsaletotal");
            Label lblmarbillingtotal = (Label)e.Item.FindControl("lblmarbillingtotal");

            Label lblsalegrandtotal = (Label)e.Item.FindControl("lblsalegrandtotal");
            Label lblbillinggrandtotal = (Label)e.Item.FindControl("lblbillinggrandtotal");

            lblsalegrandtotal.Text = Math.Round(sale_grand_total).ToString();
            lblbillinggrandtotal.Text = Math.Round(billing_grand_total).ToString();

            Label lblarpugrandtotal = (Label)e.Item.FindControl("lblarpugrandtotal");
            decimal arpu = billing_grand_total / sale_grand_total;

            lblarpugrandtotal.Text = Math.Round(arpu).ToString();
            // ========
            lblaprilsaletotal.Text = april_sale.ToString();
            lblaprilbillingtotal.Text = april_billing.ToString();
           
            lblmaysaletotal.Text = may_sale.ToString();
            lblmaybillingtotal.Text = may_billing.ToString();
            
            lbljunesaletotal.Text = june_sale.ToString();
            lbljunebillingtotal.Text = june_billing.ToString();
          
            lbljulysaletotal.Text = july_sale.ToString();
            lbljulybillingtotal.Text = july_billing.ToString();
           
            lblaugsaletotal.Text = aug_sale.ToString();
            lblaugbillingtotal.Text = aug_billing.ToString();
            
            lblseptsaletotal.Text = sept_sale.ToString();
            lblseptbillingtotal.Text = sept_billing.ToString();
            
            lbloctsaletotal.Text = oct_sale.ToString();
            lbloctbillingtotal.Text = oct_billing.ToString();
            
            lblnovsaletotal.Text = nov_sale.ToString();
            lblnovbillingtotal.Text = nov_billing.ToString();
           
            lbldecsaletotal.Text = dec_sale.ToString();
            lbldecbillingtotal.Text = dec_billing.ToString();
           
            lbljansaletotal.Text = jan_sale.ToString();
            lbljanbillingtotal.Text = jan_billing.ToString();
           
            lblfebsaletotal.Text = feb_sale.ToString();
            lblfebbillingtotal.Text = feb_billing.ToString();
           
            lblmarsaletotal.Text = mar_sale.ToString();
            lblmarbillingtotal.Text = mar_billing.ToString();
          
        }
    }

}