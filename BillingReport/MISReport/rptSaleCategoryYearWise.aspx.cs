using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class MISReport_rptSaleBillingHeadBySaleCategory : System.Web.UI.Page
{
    DataRow[] foundRows;
    DataSet dsnew = new DataSet();
    Clay.Invoice.Bll.Report objSaleBillingReport = new Clay.Invoice.Bll.Report();
    DataSet dsSaleBillingReport = new DataSet();
    double sum = 0;
    double sum2 = 0;
    double sumZone = 0;
    double sum2Zone = 0;
    double zoneLastAmount = 0;
    double zoneCurrentAmount = 0;
    double zoneCurrentHeadCount = 0;

    double yearLastARPUCount = 0;
    double yearCurrentARPUCount = 0;

    double zoneLastARPUCount = 0;
    double zoneCurrentARPUCount = 0;
    double sumOfHeadCount = 0;

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

    public string Moneycomma(string CurStr)
    {
        string StrCur = "";
        string DecVal = "";
        Int32 LenAmt = 0;
        Int32 DecPos = 0;
        StrCur = CurStr;
        //Find the Decimal Position
        if (StrCur.IndexOf(".") == -1)
        {
            StrCur = StrCur + ".00";
        }
        DecPos = StrCur.IndexOf(".");

        // Find the Decimal Values
        StrCur = StrCur + "0";
        DecVal = StrCur.Substring(DecPos + 1, 2);

        //Seperate the Rupees
        StrCur = StrCur.Substring(0, DecPos);
        // Find the Length of amt
        LenAmt = StrCur.Length;

        //if Decimal Value is Null

        if (DecVal == "" || DecVal == null)
        {
            DecVal = "00";
        }

        //Adding the Commas

        if (LenAmt == 1)
        {
            StrCur = StrCur + "." + DecVal;
        }

        if (LenAmt == 2)
        {
            StrCur = StrCur + "." + DecVal;
        }

        if (LenAmt == 3)
        {
            StrCur = StrCur + "." + DecVal;
        }

        if (LenAmt == 4)
        {

            StrCur = StrCur.Substring(0, 1) + "," + StrCur.Substring(1, 3) + "." + DecVal;
        }

        if (LenAmt == 5)
        {
            StrCur = StrCur.Substring(0, 2) + "," + StrCur.Substring(2, 3) + "." + DecVal;
        }
        if (LenAmt == 6)
        {
            StrCur = StrCur.Substring(0, 1) + "," + StrCur.Substring(1, 2) + "," + StrCur.Substring(3, 3) + "." + DecVal;
        }

        if (LenAmt == 7)
        {
            StrCur = StrCur.Substring(0, 2) + "," + StrCur.Substring(2, 2) + "," + StrCur.Substring(4, 3) + "." + DecVal;
        }

        if (LenAmt == 8)
        {
            StrCur = StrCur.Substring(0, 1) + "," + StrCur.Substring(1, 2) + "," + StrCur.Substring(3, 2) + "," + StrCur.Substring(5, 3) + "." + DecVal;
        }

        if (LenAmt == 9)
        {
            StrCur = StrCur.Substring(0, 2) + "," + StrCur.Substring(2, 2) + "," + StrCur.Substring(4, 2) + "," + StrCur.Substring(6, 3) + "." + DecVal;
        }

        if (LenAmt == 10)
        {
            StrCur = StrCur.Substring(0, 1) + "," + StrCur.Substring(1, 2) + "," + StrCur.Substring(3, 2) + "," + StrCur.Substring(5, 2) + "," + StrCur.Substring(7, 3) + "." + DecVal;
        }
        return StrCur;
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

    protected string ConvertToMoneyFormat(double myval)
    {
        return myval.ToString(); //string.Format("{0:0.00}", myval);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            err.Text = "";
            Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();


            DataSet ds = new DataSet();

            int yearFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
            int yearTo = Convert.ToInt32(ddlToYear.SelectedValue);

            if (yearTo > yearFrom)
            {
                //lblReportHeader.Text = "COMBINED SALE REPORT POSTPAID FOR PAN INDIA YEARWISE ( " + ddlFromYear.SelectedItem.Text + " -" + ddlToYear.SelectedItem.Text + ")";
                //lblzoneHeader.Text = "COMBINED SALE REPORT POSTPAID FOR PAN INDIA  REGIONWISE ( " + ddlFromYear.SelectedItem.Text + " -" + ddlToYear.SelectedItem.Text + ")";

                //ds = objReport.rptSalesBillingYearWise(yearFrom, yearTo);
                //RadGrid1New.DataSource = ds.Tables[0];
                //RadGrid1New.DataBind();
                //RadGrid1New.Visible = true;

                //// Create New Data SEt For zone 
                ds = objReport.getSaleCountBillingHeadCount(yearFrom, yearTo,"");


                createNewDS(ds);
            }
            else
            {
                err.Text = "To year should be greater then From Year";
            }

        }
        catch (Exception ex)
        {
            err.Text = ex.Message;
        }

    }

    protected void createNewDS(DataSet dsZone)
    {
        DataSet dsNewSaleReport = new DataSet();
        DataTable dtSaleCategory = new DataTable();

        dtSaleCategory = dsZone.Tables[0];

        dsNewSaleReport.Tables.Add("abc");
        dsNewSaleReport.Tables[0].Columns.Add("salecategoryname");
        dsNewSaleReport.Tables[0].Columns.Add("cyear");
        dsNewSaleReport.Tables[0].Columns.Add("lsaletotal");
        dsNewSaleReport.Tables[0].Columns.Add("lrevenuetotal");
        dsNewSaleReport.Tables[0].Columns.Add("headcountTotal");
        //dsNewSaleReport.Tables[0].Columns.Add("saleProdAvgPerHead");
        //dsNewSaleReport.Tables[0].Columns.Add("billingProdyAvgPerHead");


        DataTable dtNorth = new DataTable();
        DataTable dtNorthBilling = new DataTable();
        DataTable dtHeadCount = new DataTable();

        int iFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
        int iTo = Convert.ToInt32(ddlToYear.SelectedValue);
        string strSaleCategory = string.Empty;

        double saleTotal = 0;
        double sale = 0;
        double revenue = 0;
        double revenueTotal = 0;
        double saleTotalGrand = 0;
        double revenueTotalGrand = 0;

        double headcount = 0;
        double headCountGrandTotal = 0;
        double headCountTotal = 0;

        int tempToYEar = 0;
        saleTotalGrand = 0;
        revenueTotalGrand = 0;
        int iRowsToAdd = 0;

        foreach (DataRow drAnand in dtSaleCategory.Rows)
        {
            strSaleCategory = drAnand["salecategoryname"].ToString();

            for (int iAnand = iFrom; iAnand < iTo; iAnand++)
            {
                saleTotal = 0;
                revenueTotal = 0;
                headCountTotal = 0;

                tempToYEar = iAnand + 1;
                dsNewSaleReport.Tables[0].Rows.Add(strSaleCategory, iAnand + "-" + tempToYEar, 0, 0, 0);
                iRowsToAdd += 1;
                dtNorth = getsaleByYearMonthZone(0, iAnand, strSaleCategory, dsZone.Tables["sale"]);

                for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
                {
                    sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                    saleTotal += sale;
                }

                dtNorthBilling = getBillingByYearMonthZone(0, iAnand, strSaleCategory, dsZone.Tables["Billing"]);

                for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
                {
                    revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                    revenueTotal += revenue;
                }

                dtHeadCount = getHeadCount(0, iAnand, strSaleCategory, dsZone.Tables["headcount"]);
                for (int iSSDN = 0; iSSDN < dtHeadCount.Rows.Count; iSSDN++)
                {
                    headcount = Convert.ToDouble(dtHeadCount.Rows[iSSDN]["headcountTotal"]);
                    headCountTotal += headcount;
                }

                headCountGrandTotal += headCountTotal;
                saleTotalGrand += saleTotal;
                revenueTotalGrand += revenueTotal;

                if (saleTotal > 0 || revenueTotal > 0 || headCountTotal > 0)
                {
                    dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                    dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                    dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["headcountTotal"] = Math.Round(headCountTotal).ToString();
                }
                else
                {
                    dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1].Delete();
                    iRowsToAdd -= 1;
                }
            }

            if (saleTotalGrand > 0)
            {
                dsNewSaleReport.Tables[0].Rows.Add(strSaleCategory + " Total", "", Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString(), Math.Round(headCountGrandTotal).ToString());
                iRowsToAdd += 1;
            }

            saleTotalGrand = 0;
            revenueTotalGrand = 0;
            headCountGrandTotal = 0;
        }

        RadGrid1Zone.DataSource = dsNewSaleReport.Tables[0];
        RadGrid1Zone.DataBind();
        RadGrid1Zone.Visible = true;
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
                foundRows = dsAll.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) and salecategoryname='" + strZone + "'");
            }
            else
            {
                foundRows = dsAll.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) ");
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
                foundRows2 = dsAll.Select("saleyear=" + year + " and salemonth in (1,2,3) and salecategoryname='" + strZone + "'");
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
                foundRows = dsAll.Select("billingyear=" + year + " and billingmonth in (4,5,6,7,8,9,10,11,12) and salecategoryname='" + strZone + "'");
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
                foundRows2 = dsAll.Select("billingyear=" + year + " and billingmonth in (1,2,3) and salecategoryname='" + strZone + "'");
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

    private DataTable getHeadCount(int month, int year, string strZone, DataTable dsAll)
    {
        DataTable ds = new DataTable();
        DataTable ds2 = new DataTable();

        try
        {
            DataRow[] foundRows;
            DataRow[] foundRows2;

            if (strZone != "")
            {
                foundRows = dsAll.Select("headcountyear=" + year + " and headcountmonth in (4,5,6,7,8,9,10,11,12) and salecategoryname='" + strZone + "'");
            }
            else
            {
                foundRows = dsAll.Select("headcountyear=" + year + " and headcountmonth in (4,5,6,7,8,9,10,11,12)");
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
                foundRows2 = dsAll.Select("headcountyear=" + year + " and headcountmonth in (1,2,3) and salecategoryname='" + strZone + "'");
            }
            else
            {
                foundRows2 = dsAll.Select("headcountyear=" + year + " and headcountmonth in (1,2,3)");
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

    protected void RadGrid1Zone_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        double zoneCurrentSaleCount = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].CssClass = "hpCSS";
            // e.Row.Cells[0].ForeColor = System.Drawing.Color.Gray;
            string sZone = string.Empty;
            e.Row.Cells[0].CssClass = "openmenu2";

            Label lblzone = e.Row.FindControl("lblzone") as Label;
            //Image imgShowGrowth = e.Row.FindControl("imgShowGrowth") as Image;

            if (lblzone.Text.Contains("Total"))
            {
                zoneLastARPUCount = 0;
                //imgShowGrowth.Visible = false;
                sZone = lblzone.Text;
                sZone = sZone.Replace("Total", "").Trim();

                Label lblFromToYear = e.Row.FindControl("lblYear") as Label;
                lblFromToYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();

                //HyperLink hpYear = e.Row.FindControl("hpYear") as HyperLink;

                //hpYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();
                //hpYear.NavigateUrl = "rptSaleBillingBranchWisePopUP.aspx?yearfromto=" + hpYear.Text + "&zonename=" + sZone;

                //double sumZoneTotal = 0;
                //double sumZoneTotal2 = 0;

                e.Row.BackColor = System.Drawing.Color.DarkGray;
                Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
                if (lbl1.Text != "")
                {
                    zoneCurrentSaleCount = Convert.ToDouble(lbl1.Text);
                }

                Label lbl2 = e.Row.FindControl("lblRevenueTotal") as Label;
                if (lbl2.Text != "")
                {
                    zoneCurrentAmount = Convert.ToDouble(lbl2.Text);
                }

                Label lbl3 = e.Row.FindControl("lblHeadCount") as Label;
                if (lbl3.Text != "")
                {
                    zoneCurrentHeadCount = Convert.ToDouble(lbl3.Text);
                }
                double saleProdPerHead = 0;
                double billingProdPerHEad = 0;

                if (zoneCurrentHeadCount > 0)
                {
                    saleProdPerHead = zoneCurrentSaleCount / zoneCurrentHeadCount / 12;
                    billingProdPerHEad = zoneCurrentAmount / zoneCurrentHeadCount / 12;
                }

                Label lblSaleProdPerHead = e.Row.FindControl("lblSaleProdPerHead") as Label;
                Label lblBillingProdPerHead = e.Row.FindControl("lblBillingProdPerHead") as Label;

                lblSaleProdPerHead.Text = Math.Round(saleProdPerHead).ToString();
                lblBillingProdPerHead.Text = Math.Round(billingProdPerHEad).ToString();

                //lbl3.Text = Math.Round(sumHeadCount).ToString();
                zoneLastAmount = 0;
            }
            else
            {
               

                //HyperLink hpYear = e.Row.FindControl("hpYear") as HyperLink;
                //hpYear.Style.Add("background-color", "white");

                Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
                if (lbl1.Text != "")
                {
                    sumZone += Convert.ToDouble(lbl1.Text);
                    zoneCurrentSaleCount = Convert.ToDouble(lbl1.Text);
                }

                Label lbl2 = e.Row.FindControl("lblRevenueTotal") as Label;
                if (lbl2.Text != "")
                {
                    sum2Zone += Convert.ToDouble(lbl2.Text);
                    zoneCurrentAmount = Convert.ToDouble(lbl2.Text);
                }

                Label lbl8 = e.Row.FindControl("lblHeadCount") as Label;
                if (lbl8.Text != "")
                {
                    sumOfHeadCount += Convert.ToDouble(lbl8.Text);
                    zoneCurrentHeadCount = Convert.ToDouble(lbl8.Text);
                }

                double saleProdPerHead = 0;
                double billingProdPerHEad = 0;

                if (zoneCurrentHeadCount > 0)
                {
                    saleProdPerHead = zoneCurrentSaleCount / zoneCurrentHeadCount / 12;
                    billingProdPerHEad = zoneCurrentAmount / zoneCurrentHeadCount / 12;
                }

                Label lblSaleProdPerHead = e.Row.FindControl("lblSaleProdPerHead") as Label;
                Label lblBillingProdPerHead = e.Row.FindControl("lblBillingProdPerHead") as Label;

                lblSaleProdPerHead.Text = Math.Round(saleProdPerHead).ToString();
                lblBillingProdPerHead.Text = Math.Round(billingProdPerHEad).ToString();




                //if (zoneLastAmount > 0 && zoneCurrentAmount > 0) // for Percentage and As Per Billing amount
                //{
                //    Label lblPercentage = e.Row.FindControl("lblPercentage") as Label;
                //    Label lblAsPerBillingAmount = e.Row.FindControl("lblAsPerBillingAmount") as Label;

                //    asPerBillingAmount = zoneCurrentAmount - zoneLastAmount;
                //    lblAsPerBillingAmount.Text = Math.Round(asPerBillingAmount).ToString();

                //    percentageOfAmount = asPerBillingAmount / zoneCurrentAmount * 100;

                //    lblPercentage.Text = Math.Round(percentageOfAmount).ToString() + "%";

                //}
                //if (lbl8.Text != "")
                //{
                //    zoneCurrentARPUCount = Convert.ToDouble(lbl8.Text);
                //}


                //// Image Display Growth and Down...
                //if (zoneLastARPUCount > 0)
                //{

                //    if (zoneLastARPUCount - zoneCurrentARPUCount > 0)
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


                //if (lbl2.Text != "")
                //{
                //    zoneLastAmount = Convert.ToDouble(lbl2.Text);
                //}

                //if (lbl8.Text != "")
                //{
                //    zoneLastARPUCount = Convert.ToDouble(lbl8.Text);
                //}

            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].CssClass = "openmenu2";

            Label lblgrandtotal = e.Row.FindControl("lblSaleCountGrandTotal") as Label;
            Label lblgrandtotallow = e.Row.FindControl("lblRevenueGrandTotal") as Label;
            Label lblHeadCountTotal = e.Row.FindControl("lblHeadCountTotal") as Label;

            lblgrandtotal.Text = Convert.ToString(sumZone);
            lblgrandtotallow.Text = Convert.ToString(sum2Zone);

            lblHeadCountTotal.Text = Math.Round(sumOfHeadCount).ToString();

            Label lblFromToYear = e.Row.FindControl("lblFromToYear") as Label;
            lblFromToYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();

            //HyperLink lblFromToYear = e.Row.FindControl("lblFromToYear") as HyperLink;

            //lblFromToYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();
            //lblFromToYear.NavigateUrl = "rptSaleBillingBranchWisePopUP.aspx?yearfromto=" + lblFromToYear.Text + "&zonename=ALL";

            //HyperLink hpFromToYear = e.Row.FindControl("lblFromToYear") as HyperLink;
            //hpFromToYear.Style.Add("color", "black");

            //Label lblAmountWithServiceTaxGrandTotal = e.Row.FindControl("lblAmountWithServiceTaxGrandTotal") as Label;
            //Label lblServiceTaxGrandTotal = e.Row.FindControl("lblServiceTaxGrandTotal") as Label;

            //lblAmountWithServiceTaxGrandTotal.Text = Math.Round(sumOFAmountWithServiceTaxZone).ToString();
            //lblServiceTaxGrandTotal.Text = Math.Round(sumOfServiceTaxZone).ToString();

            e.Row.BackColor = System.Drawing.Color.DarkGray;
        }
    }

    public string Monthheader(Int32 mnthid)
    {
        string str = "";
        if (mnthid == 1)
        {
            str = "January";
        }
        if (mnthid == 2)
        {
            str = "February";
        }
        if (mnthid == 3)
        {
            str = "March";
        }
        if (mnthid == 4)
        {
            str = "April";
        }
        if (mnthid == 5)
        {
            str = "May";
        }
        if (mnthid == 6)
        {
            str = "June";
        }
        if (mnthid == 7)
        {
            str = "July";
        }
        if (mnthid == 8)
        {
            str = "August";
        }
        if (mnthid == 9)
        {
            str = "September";
        }
        if (mnthid == 10)
        {
            str = "October";
        }
        if (mnthid == 11)
        {
            str = "November";
        }
        if (mnthid == 12)
        {
            str = "December";
        }
        return str;

    }

}