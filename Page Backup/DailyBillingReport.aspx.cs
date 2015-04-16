using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using System.Data;

public partial class MISReport_DailyBillingReport : System.Web.UI.Page
{
    DataRow[] foundRows;
    DataSet dsnew = new DataSet();
    Clay.Invoice.Bll.Report objOneDayBillingReport = new Clay.Invoice.Bll.Report();
    DataSet dsOneDay = new DataSet();
    DataSet dsOneDayWholesale = new DataSet();
    double sum = 0;
    double sum2 = 0;

    double sum3 = 0;
    double sum4 = 0;

    double sumServiceTax = 0;
    double sumCreditNote = 0;
    double sumTotalfinalAmount = 0;

    double totalAmountAll = 0;
    int totalInvoiceAll = 0;
    double totalARPUAll = 0;

    double totalAmount = 0;
    int totalInvoice = 0;
    int totalARPU = 0;

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
            //err.Text = ex.Message.ToString();
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

        //drYear = dsYear.Tables[0].NewRow();
        //drYear["yearVal"] = "Select";
        //drYear["yearTxt"] = 0;
        //dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
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
        //ddlFromYear.SelectedIndex = 0;

        ddlToYear.DataSource = dsYear.Tables[0];
        ddlToYear.DataTextField = "yearVal";
        ddlToYear.DataValueField = "yearTxt";
        ddlToYear.DataBind();
        //ddlToYear.SelectedIndex = 0;

        ddlFromYear.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
        ddlToYear.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;

        ddlToMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        ddlFromMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
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

    protected void RadGrid1New_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            Label lbl1 = item.FindControl("lblTotalAmount") as Label;
            if (lbl1.Text != "")
            {
                sum += Convert.ToDouble(lbl1.Text);
            }

            Label lbl2 = item.FindControl("lblTotalInvoice") as Label;
            if (lbl2.Text != "")
            {
                sum2 += Convert.ToDouble(lbl2.Text);
            }

            Label lblST = item.FindControl("lblTotalServiceTaxAmount") as Label;
            if (lblST.Text != "")
            {
                sumServiceTax += Convert.ToDouble(lblST.Text);
            }

            Label lblCreditNote = item.FindControl("lblTotalCreditNoteAmount") as Label;
            if (lblCreditNote.Text != "")
            {
                sumCreditNote += Convert.ToDouble(lblCreditNote.Text);
            }

            Label lblTotalFinalAmount = item.FindControl("lblTotalFinalAmount") as Label;
            if (lblTotalFinalAmount.Text != "")
            {
                sumTotalfinalAmount += Convert.ToDouble(lblTotalFinalAmount.Text);
            }


        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandTotalAmount") as Label;
            Label lblgrandtotallow = item.FindControl("lblGrandTotalInvoice") as Label;
            Label lblGrandTotalARPU = item.FindControl("lblGrandTotalARPU") as Label;
            
            Label lblGrandTotalFinalAmount = item.FindControl("lblGrandTotalFinalAmount") as Label;
            Label lblGrandTotalServiceTaxAmount = item.FindControl("lblGrandTotalServiceTaxAmount") as Label;
            Label lblGrandTotalCreditNoteAmount = item.FindControl("lblGrandTotalCreditNoteAmount") as Label;

            lblgrandtotal.Text = Convert.ToString(sum);
            lblgrandtotallow.Text = Convert.ToString(sum2);
            double arpu = sum / sum2;

            lblGrandTotalARPU.Text = Math.Round(arpu).ToString();

            lblGrandTotalCreditNoteAmount.Text = sumCreditNote.ToString();
            lblGrandTotalFinalAmount.Text = sumTotalfinalAmount.ToString();
            lblGrandTotalServiceTaxAmount.Text = sumServiceTax.ToString();

        }
    }

    protected string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Clay.Invoice.Bll.Report objReport = new Clay.Invoice.Bll.Report();

      

        short lserviceTax = 0;
        int customerTypeID = 0;

        DateTime dtFromDate = new DateTime();
        DateTime dtToDate = new DateTime();
        DataSet ds = new DataSet();
        DataSet dsWholesale = new DataSet();

        //DataTable dtFromToDate = new DataTable();
        //dtFromToDate.Columns.Add("dtDate");

        dtFromDate = Convert.ToDateTime(ddlFromYear.SelectedValue + "-" + ddlFromMonth.SelectedValue + "-01");
        dtToDate = Convert.ToDateTime(ddlToYear.SelectedValue + "-" + ddlToMonth.SelectedValue + "-01");

        //if (ddlServiceTaxYesNo.SelectedValue.ToString() == "Yes")
        //{
        //    lserviceTax = 1;
        //}

        customerTypeID = Convert.ToInt32(ddlRetailWholesale.SelectedValue);


        int mthFrom = 0;
        int mthDay = 0;
        int mthYear = 0;
        if (rdpDate.SelectedDate == null)
        {
            mthFrom = Convert.ToDateTime(DateTime.Now).Month;
            mthDay = Convert.ToDateTime(DateTime.Now).Day;
            mthYear = Convert.ToDateTime(DateTime.Now).Year;
        }
        else
        {
            mthFrom = Convert.ToDateTime(rdpDate.SelectedDate).Month;
            mthDay = Convert.ToDateTime(rdpDate.SelectedDate).Day;
            mthYear = Convert.ToDateTime(rdpDate.SelectedDate).Year;
        }

        lblDate.Text = "Date - " + mthDay.ToString() + "-" + Monthheader(mthFrom) + "-" + mthYear;



        if (customerTypeID == 0)
        {
            ds = objReport.rpt_Daily_Billing_wise(lserviceTax, Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue),1, 1);

            dsWholesale = objReport.rpt_Daily_Billing_wise(lserviceTax, Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1, 3);

            dsOneDay = objReport.rpt_Daily_Billing_wise_By_day(lserviceTax, mthYear, mthFrom, mthYear, mthFrom, mthDay, 1);
            dsOneDayWholesale = objReport.rpt_Daily_Billing_wise_By_day(lserviceTax, mthYear, mthFrom, mthYear, mthFrom, mthDay, 3);

            RadGrid1New.DataSource = dsOneDay.Tables[0];
            RadGrid1New.DataBind();
            RadGrid1New.Visible = true;

            RadGridWholesale.DataSource = dsOneDayWholesale.Tables[0];
            RadGridWholesale.DataBind();
            RadGridWholesale.Visible = true;

            lblWholesale.Visible = true;
            lblRetail.Text = "Retail";
            lblWholesale.Text = "Wholesale";
        }
        else
        {
            ds = objReport.rpt_Daily_Billing_wise(lserviceTax, Convert.ToInt32(ddlFromYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), Convert.ToInt32(ddlToYear.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue), 1, customerTypeID);

            dsOneDay = objReport.rpt_Daily_Billing_wise_By_day(lserviceTax, mthYear, mthFrom, mthYear, mthFrom, mthDay, customerTypeID);

            RadGrid1New.DataSource = dsOneDay.Tables[0];
            RadGrid1New.DataBind();
            RadGrid1New.Visible = true;

            lblWholesale.Visible = false;
            RadGridWholesale.Visible = false;

            lblRetail.Text = ddlRetailWholesale.SelectedItem.Text;

        }


        if (dtFromDate > dtToDate)
        {
            return;
        }

        if (customerTypeID == 0)
        {
            lblreport.Text = bindReportRETAIL(dtFromDate, dtToDate, ds, 1);
            lblReportWholesale.Text = bindReport(dtFromDate, dtToDate, dsWholesale,3);
        }
        else
        {
            if (customerTypeID == 1)
            {
                lblreport.Text = bindReportRETAIL(dtFromDate, dtToDate, ds, 1);
            }
            else
            {
                lblreport.Text = bindReport(dtFromDate, dtToDate, ds, customerTypeID);
            }
            lblReportWholesale.Text = "";
        }
    }

    protected string bindReport(DateTime dtFromDate , DateTime dtToDate, DataSet ds, int customertypeid)
    {
        string strReport = string.Empty;
        string custType = "";
        if (customertypeid == 1)
        {
            custType = "Retail";
        }
        else
        {
            custType = "Wholesale";
        }

        strReport = "<table cellpadding='1px' cellspacing='1px' border='2px'><tr>";

        while (dtFromDate <= dtToDate)
        {

            strReport += "<td style='vertical-align:top'>";
            strReport += "<table cellpadding='3px' cellspacing='1px' style='background-color:gray' ";

            strReport += "width='400px'>"; // CHANGE 21-Aug-2013

            strReport += "<colgroup span='4' style='background-color:white'></colgroup>";
            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";

            // Print the Month and Year on the header ***********************************
            strReport += "<td colspan='4' align='center'>" + Monthheader(dtFromDate.Month) + "-" + dtFromDate.Year + "  (" + custType + ") </td> </tr>";

            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
            strReport += "<td style='width:50px' align='center'>Day </td>";

            strReport += "<td style='width:135px'>Total Amount </td>";
            strReport += "<td style='width:135px'> Total Invoice </td>";
            strReport += "<td style='width:135px'> ARPU </td>";

            strReport += "</tr>";



            totalAmountAll = 0;
            totalInvoiceAll = 0;
            totalARPUAll = 0;

            for (int i = 1; i <= 31; i++)
            {

                //DateTime tempDatenew = Convert.ToDateTime(dtFromDate.Year + "-" + dtFromDate.Month + "-" + i);

                string Expression = "day=" + i + " and month=" + dtFromDate.Month + " and year=" + dtFromDate.Year;

                foundRows = ds.Tables[0].Select(Expression);

                if (foundRows.Length > 0)
                {
                    dsnew = ds.Clone();

                    for (int ix = 0; ix < foundRows.Length; ix++)
                    {
                        dsnew.Tables[0].ImportRow(foundRows[ix]);
                    }
                    try
                    {
                        totalAmountAll += Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalAmount"]);
                        totalInvoiceAll += Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalInvoice"]);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            totalARPUAll = Math.Round(totalAmountAll / totalInvoiceAll);


            for (int i = 1; i <= 31; i++)
            {
                string Expression = "day=" + i + " and month=" + dtFromDate.Month + " and year=" + dtFromDate.Year;

                foundRows = ds.Tables[0].Select(Expression);

                totalAmount = 0;
                totalInvoice = 0;
                totalARPU = 0;

                if (foundRows.Length > 0)
                {
                    dsnew = ds.Clone();
                    for (int ix = 0; ix < foundRows.Length; ix++)
                    {
                        dsnew.Tables[0].ImportRow(foundRows[ix]);
                    }

                    try
                    {
                        totalInvoice = (Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalInvoice"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalInvoice = 0;
                    }

                    try
                    {
                        totalAmount = Math.Round(Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalAmount"].ToString()), 2);
                    }
                    catch (Exception ex)
                    {
                        totalAmount = 0;
                    }

                    try
                    {
                        totalARPU = (Convert.ToInt32(dsnew.Tables[0].Rows[0]["arpu"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalARPU = 0;
                    }


                }


                if (i % 2 == 0)
                {
                    strReport += "<tr style='font-weight:normal;background-color:white;color:black'>";
                }
                else
                {
                    strReport += "<tr style='font-weight:normal;background-color:#e3e3e3;color:black'>";
                }


                strReport += "<td style='font-weight:bold' align='Left'>" + i + "</td>";


                if (string.Format("{0:0.00}", totalAmount) != "0.00")
                {
                    strReport += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(totalAmount, 2).ToString()) + "</td>";
                }
                else
                {
                    strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmount, 2).ToString()) + "</td>";
                }

                strReport += "<td align='Right' style='color:Green'>" + totalInvoice + "</td>";

                strReport += "<td align='Right' style='color:Green'>" + totalARPU + "</td>";

                strReport += "</tr>";
            }


            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
            //if (Convert.ToInt32("04") == mthone)
            //{
            strReport += "<td align='Right'>Total </td>";
            //}
            // PRint the Total Amount 
            strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmountAll, 2).ToString()) + " </td>";
            strReport += "<td align='Right'>" + totalInvoiceAll + " </td>";
            strReport += "<td align='Right'>" + Math.Round(totalARPUAll) + " </td>";
            strReport += "</tr>";
            strReport += "</table>";
            strReport += "</td>";

            dtFromDate = dtFromDate.AddMonths(1);
        }


        strReport += "</tr></table>";

        return strReport;
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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        string myFileName = "Mis_Report_" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + myFileName);
        lblreport.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void RadGridWholesale_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            Label lbl1 = item.FindControl("lblTotalAmount") as Label;
            if (lbl1.Text != "")
            {
                sum3 += Convert.ToDouble(lbl1.Text);
            }

            Label lbl2 = item.FindControl("lblTotalInvoice") as Label;
            if (lbl2.Text != "")
            {
                sum4 += Convert.ToDouble(lbl2.Text);
            }


        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandTotalAmount") as Label;
            Label lblgrandtotallow = item.FindControl("lblGrandTotalInvoice") as Label;
            Label lblGrandTotalARPU = item.FindControl("lblGrandTotalARPU") as Label;

            lblgrandtotal.Text = Convert.ToString(sum3);
            lblgrandtotallow.Text = Convert.ToString(sum4);
            double arpu = sum3 / sum4;

            lblGrandTotalARPU.Text = Math.Round(arpu).ToString();
        }
    }

    protected string bindReportRETAIL(DateTime dtFromDate, DateTime dtToDate, DataSet ds, int customertypeid)
    {
        double totalCreditNoteAll = 0;
        double totalServiceTaxAll = 0;
        double totalAmountFinalAll = 0;

        double totalCreditNote = 0;
        double totalServiceTax = 0;
        double totalAmountFinal = 0;

        string strReport = string.Empty;
        string custType = "";
        if (customertypeid == 1)
        {
            custType = "Retail";
        }
        else
        {
            custType = "Wholesale";
        }

        strReport = "<table cellpadding='1px' cellspacing='1px' border='2px'><tr>";

        while (dtFromDate <= dtToDate)
        {

            strReport += "<td style='vertical-align:top'>";
            strReport += "<table cellpadding='3px' cellspacing='1px' style='background-color:gray' ";

            strReport += "width='800px'>"; // CHANGE 21-Aug-2013

            strReport += "<colgroup span='7' style='background-color:white'></colgroup>";
            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";

            // Print the Month and Year on the header ***********************************
            strReport += "<td colspan='7' align='center'>" + Monthheader(dtFromDate.Month) + "-" + dtFromDate.Year + "  (" + custType + ") </td> </tr>";

            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
            strReport += "<td style='width:50px' align='center'>Day </td>";

            strReport += "<td style='width:135px'>Revenue Amount </td>";
            strReport += "<td style='width:135px'>Service Tax </td>";
            strReport += "<td style='width:135px'>Credit Note</td>";
            strReport += "<td style='width:135px'>Total Amount </td>";

            strReport += "<td style='width:135px'> Total Invoice </td>";
            strReport += "<td style='width:135px'> ARPU </td>";

            strReport += "</tr>";



            totalAmountAll = 0;
            totalInvoiceAll = 0;
            totalARPUAll = 0;

            totalCreditNoteAll = 0;
            totalServiceTaxAll = 0;
            totalAmountFinalAll = 0;

            for (int i = 1; i <= 31; i++)
            {

                //DateTime tempDatenew = Convert.ToDateTime(dtFromDate.Year + "-" + dtFromDate.Month + "-" + i);

                string Expression = "day=" + i + " and month=" + dtFromDate.Month + " and year=" + dtFromDate.Year;

                foundRows = ds.Tables[0].Select(Expression);

                if (foundRows.Length > 0)
                {
                    dsnew = ds.Clone();

                    for (int ix = 0; ix < foundRows.Length; ix++)
                    {
                        dsnew.Tables[0].ImportRow(foundRows[ix]);
                    }
                    try
                    {
                        totalAmountAll += Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalAmount"]);
                        totalInvoiceAll += Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalInvoice"]);

                        totalAmountFinalAll += Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalFinalAmount"]);
                        totalCreditNoteAll += Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalCreditAmount"]);
                        totalServiceTaxAll += Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalServiceTax"]);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            totalARPUAll = Math.Round(totalAmountAll / totalInvoiceAll);


            for (int i = 1; i <= 31; i++)
            {
                string Expression = "day=" + i + " and month=" + dtFromDate.Month + " and year=" + dtFromDate.Year;

                foundRows = ds.Tables[0].Select(Expression);

                totalAmount = 0;
                totalInvoice = 0;
                totalARPU = 0;

                totalCreditNote = 0;
                totalServiceTax = 0;
                totalAmountFinal = 0;

                if (foundRows.Length > 0)
                {
                    dsnew = ds.Clone();
                    for (int ix = 0; ix < foundRows.Length; ix++)
                    {
                        dsnew.Tables[0].ImportRow(foundRows[ix]);
                    }

                    try
                    {
                        totalInvoice = (Convert.ToInt32(dsnew.Tables[0].Rows[0]["totalInvoice"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalInvoice = 0;
                    }

                    try
                    {
                        totalAmount = Math.Round(Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalAmount"].ToString()), 2);
                    }
                    catch (Exception ex)
                    {
                        totalAmount = 0;
                    }

                    try
                    {
                        totalARPU = (Convert.ToInt32(dsnew.Tables[0].Rows[0]["arpu"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalARPU = 0;
                    }

                    try
                    {
                        totalCreditNote = (Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalCreditAmount"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalCreditNote = 0;

                    }

                    try
                    {
                        totalServiceTax = Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalServiceTax"]);
                    }
                    catch (Exception ex)
                    {
                        totalServiceTax = 0;
                    }

                    try
                    {
                        totalAmountFinal = (Convert.ToDouble(dsnew.Tables[0].Rows[0]["totalFinalAmount"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        totalAmountFinal = 0;
                    }


                }


                if (i % 2 == 0)
                {
                    strReport += "<tr style='font-weight:normal;background-color:white;color:black'>";
                }
                else
                {
                    strReport += "<tr style='font-weight:normal;background-color:#e3e3e3;color:black'>";
                }


                strReport += "<td style='font-weight:bold' align='Left'>" + i + "</td>";


                if (string.Format("{0:0.00}", totalAmount) != "0.00")
                {
                    strReport += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(totalAmount, 2).ToString()) + "</td>";
                }
                else
                {
                    strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmount, 2).ToString()) + "</td>";
                }

                if (string.Format("{0:0.00}", totalServiceTax) != "0.00")
                {
                    strReport += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(totalServiceTax, 2).ToString()) + "</td>";
                }
                else
                {
                    strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalServiceTax, 2).ToString()) + "</td>";
                }

                if (string.Format("{0:0.00}", totalCreditNote) != "0.00")
                {
                    strReport += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(totalCreditNote, 2).ToString()) + "</td>";
                }
                else
                {
                    strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalCreditNote, 2).ToString()) + "</td>";
                }

                if (string.Format("{0:0.00}", totalAmountFinal) != "0.00")
                {
                    strReport += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(totalAmountFinal, 2).ToString()) + "</td>";
                }
                else
                {
                    strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmountFinal, 2).ToString()) + "</td>";
                }

                strReport += "<td align='Right' style='color:Green'>" + totalInvoice + "</td>";

                strReport += "<td align='Right' style='color:Green'>" + totalARPU + "</td>";

                strReport += "</tr>";
            }


            strReport += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
            //if (Convert.ToInt32("04") == mthone)
            //{
            strReport += "<td align='Right'>Total </td>";
            //}
            // PRint the Total Amount 
            strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmountAll, 2).ToString()) + " </td>";
            strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalServiceTaxAll, 2).ToString()) + " </td>";
            strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalCreditNoteAll, 2).ToString()) + " </td>";
            strReport += "<td align='Right'>" + Moneycomma(Math.Round(totalAmountFinalAll, 2).ToString()) + " </td>";
            strReport += "<td align='Right'>" + totalInvoiceAll + " </td>";
            strReport += "<td align='Right'>" + Math.Round(totalARPUAll) + " </td>";
            strReport += "</tr>";
            strReport += "</table>";
            strReport += "</td>";

            dtFromDate = dtFromDate.AddMonths(1);
        }


        strReport += "</tr></table>";

        return strReport;
    }
}
