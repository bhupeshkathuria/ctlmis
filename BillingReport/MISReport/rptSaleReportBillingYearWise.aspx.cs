using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class MISReport_TEST : System.Web.UI.Page
{
    DataRow[] foundRows;
    DataSet dsnew = new DataSet();
    Clay.Invoice.Bll.Report objSaleBillingReport = new Clay.Invoice.Bll.Report();
    DataSet dsSaleBillingReport = new DataSet();
    double accountmanagercountTotal = 0;
    double accountmanagercountGrandTotalZone = 0;

    double LastYearSalesCount = -100;
    double CurrectYearSalesCount = 0;

    double LastYearSalesCountZoneWise = -100;
    double CurrectYearSalesCountZoneWise = 0;

    //double FoundMonths = 0;


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

        for (int i = 2010; i <= DateTime.Now.AddYears(0).Year; i++)
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

    double sum = 0;
    double sum2 = 0;
    double sumZone = 0;
    double sum2Zone = 0;
    double zoneLastAmount = 0;
    double zoneCurrentAmount = 0;

    double yearLastARPUCount = 0;
    double yearCurrentARPUCount = 0;

    double zoneLastARPUCount = 0;
    double zoneCurrentARPUCount = 0;

    double sumOfServiceTAx = 0;
    double sumOfAmountWithServiceTax = 0;
    double sumOfServiceTaxZone = 0;
    double sumOFAmountWithServiceTaxZone = 0;

    DataSet DSEmpYearAndZoneWise = null;


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
            DataSet dsZone = new DataSet();

            int yearFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
            int yearTo = Convert.ToInt32(ddlToYear.SelectedValue);

            if (yearTo > yearFrom)
            {
                lblReportHeader.Text = "COMBINED SALE REPORT POSTPAID FOR PAN INDIA YEARWISE ( " + ddlFromYear.SelectedItem.Text + " -" + ddlToYear.SelectedItem.Text + ")";
                lblzoneHeader.Text = "COMBINED SALE REPORT POSTPAID FOR PAN INDIA  REGIONWISE ( " + ddlFromYear.SelectedItem.Text + " -" + ddlToYear.SelectedItem.Text + ")";

                //ds = objReport.rptSalesBillingYearWise(yearFrom, yearTo);
                //RadGrid1New.DataSource = ds.Tables[0];
                //RadGrid1New.DataBind();
                //RadGrid1New.Visible = true;

                //// Create New Data SEt For zone 

                dsZone = objReport.rptSalesBillingYearWiseZone(yearFrom, yearTo);

                int iFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
                int iTo = Convert.ToInt32(ddlToYear.SelectedValue);

                DSEmpYearAndZoneWise = objSaleBillingReport.GetDistinctEmpYearwiseNew(iFrom, iTo);

                lblEmpCount.Text = "Current Active Account Manager's Count (" + DSEmpYearAndZoneWise.Tables[2].Rows[0][0].ToString() +")";

                createNewDS(dsZone);
                bindNewYearWise(dsZone);
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
        dsNewSaleReport.Tables.Add("abc");

        dsNewSaleReport.Tables[0].Columns.Add("zone");
        dsNewSaleReport.Tables[0].Columns.Add("cyear");
        dsNewSaleReport.Tables[0].Columns.Add("lsaletotal");
        dsNewSaleReport.Tables[0].Columns.Add("lrevenuetotal");
        dsNewSaleReport.Tables[0].Columns.Add("accountmanagercount");

        dsNewSaleReport.Tables[0].Columns.Add("SaleAvgZoneWise");
        dsNewSaleReport.Tables[0].Columns.Add("RevAvgZoneWise");
        

        


        DataTable dtNorth = new DataTable();
        DataTable dtSouth = new DataTable();
        DataTable dtEast = new DataTable();
        DataTable dtWest = new DataTable();

        DataTable dtNorthBilling = new DataTable();
        DataTable dtSouthBilling = new DataTable();
        DataTable dtEastBilling = new DataTable();
        DataTable dtWestBilling = new DataTable();

        int iFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
        int iTo = Convert.ToInt32(ddlToYear.SelectedValue);


        double saleTotal = 0;
        double sale = 0;
        double laccountmanagercount = 0;

        double revenue = 0;
        double revenueTotal = 0;
        double laccountmanagercountTotal = 0;
        

        double saleTotalGrand = 0;
        double revenueTotalGrand = 0;
        double laccountmanagercountgrand = 0;
        

        int tempToYEar = 0;


        saleTotalGrand = 0;
        revenueTotalGrand = 0;
        int iRowsToAdd = 0;

        for (int iAnand = iFrom; iAnand < iTo; iAnand++)
        {
            saleTotal = 0;
            revenueTotal = 0;
            laccountmanagercount = 0;
            

            tempToYEar = iAnand + 1;
            dsNewSaleReport.Tables[0].Rows.Add("North", iAnand + "-" + tempToYEar, 0, 0);
            iRowsToAdd += 1;
            dtNorth = getsaleByYearMonthZone(0, iAnand, "North", dsZone.Tables["sale"]);

            

            for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
            {
                sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                saleTotal += sale;

                laccountmanagercount += Convert.ToDouble(dtNorth.Rows[iSSDN]["accountmanagercount"] ?? 0);

            }

            dtNorthBilling = getBillingByYearMonthZone(0, iAnand, "North", dsZone.Tables["Billing"]);

            for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
            {
                revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                revenueTotal += revenue;
            }

            saleTotalGrand += saleTotal;
            revenueTotalGrand += revenueTotal;
            laccountmanagercountgrand += laccountmanagercount;
            laccountmanagercountTotal += laccountmanagercount;

            double FoundMonths = getMonthsInYear(iAnand, dsZone.Tables["sale"], "North");

            double AccountManagerCount = getAccountManagerCountInYearZone(iAnand, "North", DSEmpYearAndZoneWise.Tables[1]);

            if (saleTotal > 0 && revenueTotal > 0)
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                //dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(laccountmanagercount).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountManagerCount).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["SaleAvgZoneWise"] = Math.Round(saleTotal / FoundMonths).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["RevAvgZoneWise"] = Math.Round(revenueTotal / FoundMonths).ToString();
                

            }
            else
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1].Delete();
                iRowsToAdd -= 1;
            }
        }

        if (saleTotalGrand > 0)
        {
            //Math.Round(laccountmanagercountTotal).ToString()
            dsNewSaleReport.Tables[0].Rows.Add("North Total", "", Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString(), "");
            iRowsToAdd += 1;
        }
        // West

        saleTotalGrand = 0;
        revenueTotalGrand = 0;
        laccountmanagercountTotal = 0;

        for (int iAnand = iFrom; iAnand < iTo; iAnand++)
        {
            saleTotal = 0;
            revenueTotal = 0;
            laccountmanagercount = 0;

            tempToYEar = iAnand + 1;
            dsNewSaleReport.Tables[0].Rows.Add("West", iAnand + "-" + tempToYEar, 0, 0);
            iRowsToAdd += 1;
            dtNorth = getsaleByYearMonthZone(0, iAnand, "West", dsZone.Tables["sale"]);

            for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
            {
                sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                saleTotal += sale;

                laccountmanagercount += Convert.ToDouble(dtNorth.Rows[iSSDN]["accountmanagercount"] ?? 0);
            }

            dtNorthBilling = getBillingByYearMonthZone(0, iAnand, "West", dsZone.Tables["Billing"]);
            laccountmanagercountTotal += laccountmanagercount;
            

            for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
            {
                revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                revenueTotal += revenue;
            }

            saleTotalGrand += saleTotal;
            revenueTotalGrand += revenueTotal;
            laccountmanagercountgrand += laccountmanagercount;

            double FoundMonths = getMonthsInYear(iAnand, dsZone.Tables["sale"], "West");
            double AccountManagerCount = getAccountManagerCountInYearZone(iAnand, "West", DSEmpYearAndZoneWise.Tables[1]);

            if (saleTotal > 0 && revenueTotal > 0)
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountManagerCount).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["SaleAvgZoneWise"] = Math.Round(saleTotal / FoundMonths).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["RevAvgZoneWise"] = Math.Round(revenueTotal / FoundMonths).ToString();
                
                
            }
            else
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1].Delete();
                iRowsToAdd -= 1;
            }
        }

        if (saleTotalGrand > 0)
        {
            //Math.Round(laccountmanagercountTotal).ToString()
            dsNewSaleReport.Tables[0].Rows.Add("West Total", "", Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString(),"" );
            iRowsToAdd += 1;
        }
        // South

        saleTotalGrand = 0;
        revenueTotalGrand = 0;
        laccountmanagercount = 0;
        laccountmanagercountTotal = 0;

        for (int iAnand = iFrom; iAnand < iTo; iAnand++)
        {
            saleTotal = 0;
            revenueTotal = 0;
            laccountmanagercount = 0;

            tempToYEar = iAnand + 1;
            dsNewSaleReport.Tables[0].Rows.Add("South", iAnand + "-" + tempToYEar, 0, 0);
            iRowsToAdd += 1;
            dtNorth = getsaleByYearMonthZone(0, iAnand, "South", dsZone.Tables["sale"]);

            for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
            {
                sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                saleTotal += sale;
                saleTotalGrand += sale;
                laccountmanagercount += Convert.ToDouble(dtNorth.Rows[iSSDN]["accountmanagercount"] ?? 0);


            }

            dtNorthBilling = getBillingByYearMonthZone(0, iAnand, "South", dsZone.Tables["Billing"]);
            laccountmanagercountTotal += laccountmanagercount;

            for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
            {
                revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                revenueTotal += revenue;
                revenueTotalGrand += revenue;
            }


            double FoundMonths = getMonthsInYear(iAnand, dsZone.Tables["sale"], "South");
            double AccountManagerCount = getAccountManagerCountInYearZone(iAnand, "South", DSEmpYearAndZoneWise.Tables[1]);
            if (saleTotal > 0 && revenueTotal > 0)
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountManagerCount).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["SaleAvgZoneWise"] = Math.Round(saleTotal / FoundMonths).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["RevAvgZoneWise"] = Math.Round(revenueTotal / FoundMonths).ToString();
                
            }
            else
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1].Delete();
                iRowsToAdd -= 1;
            }
        }

        if (saleTotalGrand > 0)
        {
            //Math.Round(laccountmanagercountTotal).ToString()
            dsNewSaleReport.Tables[0].Rows.Add("South Total", "", Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString(),"");
            iRowsToAdd += 1;
        }
        // dtEast 
        saleTotalGrand = 0;
        revenueTotalGrand = 0;
        laccountmanagercount = 0;
        laccountmanagercountTotal = 0;        

        for (int iAnand = iFrom; iAnand < iTo; iAnand++)
        {
            saleTotal = 0;
            revenueTotal = 0;
            laccountmanagercount = 0;
            

            tempToYEar = iAnand + 1;
            dsNewSaleReport.Tables[0].Rows.Add("East", iAnand + "-" + tempToYEar, 0, 0);
            iRowsToAdd += 1;
            dtNorth = getsaleByYearMonthZone(0, iAnand, "East", dsZone.Tables["sale"]);

            for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
            {
                sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                saleTotal += sale;
                laccountmanagercount += Convert.ToDouble(dtNorth.Rows[iSSDN]["accountmanagercount"] ?? 0);

            }

            dtNorthBilling = getBillingByYearMonthZone(0, iAnand, "East", dsZone.Tables["Billing"]);
            laccountmanagercountTotal += laccountmanagercount;

            double FoundMonths = getMonthsInYear(iAnand, dsZone.Tables["sale"], "East");
            double AccountManagerCount = getAccountManagerCountInYearZone(iAnand, "East", DSEmpYearAndZoneWise.Tables[1]);

            for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
            {
                revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                revenueTotal += revenue;
            }

            saleTotalGrand += saleTotal;
            revenueTotalGrand += revenueTotal;
            laccountmanagercountgrand += laccountmanagercount;

            if (saleTotal > 0 && revenueTotal > 0)
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountManagerCount).ToString();
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["SaleAvgZoneWise"] = Math.Round(saleTotal / FoundMonths).ToString();
                if (FoundMonths > 0 )
                {
                    dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1]["RevAvgZoneWise"] = Math.Round(revenueTotal / FoundMonths).ToString();
                }                
                
            }
            else
            {
                dsNewSaleReport.Tables[0].Rows[iRowsToAdd - 1].Delete();
                iRowsToAdd -= 1;
            }
        }

        if (saleTotalGrand > 0)
        {
            //Math.Round(laccountmanagercountTotal).ToString()
            dsNewSaleReport.Tables[0].Rows.Add("East Total", "", Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString(),"" );
            iRowsToAdd += 1;
        }


        RadGrid1Zone.DataSource = dsNewSaleReport.Tables[0];
        RadGrid1Zone.DataBind();
        RadGrid1Zone.Visible = true;
    }

    protected void bindNewYearWise(DataSet dsNewDataSetWithZone)
    {
        if (dsNewDataSetWithZone.Tables[0].Rows.Count > 0)
        {
            DataSet dsNewSaleReportYearWise = new DataSet();
            dsNewSaleReportYearWise.Tables.Add("abc");

            dsNewSaleReportYearWise.Tables[0].Columns.Add("cyear");
            dsNewSaleReportYearWise.Tables[0].Columns.Add("accountmanagercount");
            dsNewSaleReportYearWise.Tables[0].Columns.Add("lsaletotal");
            dsNewSaleReportYearWise.Tables[0].Columns.Add("lrevenuetotal");
            dsNewSaleReportYearWise.Tables[0].Columns.Add("SaleAvgYearWise");
            dsNewSaleReportYearWise.Tables[0].Columns.Add("RevAvgYearWise");

            
       
            


            int iFrom = Convert.ToInt32(ddlFromYear.SelectedValue);
            int iTo = Convert.ToInt32(ddlToYear.SelectedValue);


            double saleTotal = 0;
            double sale = 0;
            double AccountManager = 0;

            double revenue = 0;
            double revenueTotal = 0;
            double AccountMangagerTotal = 0;

            double saleTotalGrand = 0;
            double revenueTotalGrand = 0;
            double AccountMangagerTotalGrand = 0;

            int tempToYEar = 0;


            saleTotalGrand = 0;
            revenueTotalGrand = 0;
            int iRowsToAdd = 0;

            for (int iAnand = iFrom; iAnand < iTo; iAnand++)
            {
                saleTotal = 0;
                revenueTotal = 0;
                AccountMangagerTotal = 0;

                tempToYEar = iAnand + 1;
                dsNewSaleReportYearWise.Tables[0].Rows.Add(iAnand + "-" + tempToYEar, 0, 0);
                iRowsToAdd += 1;
                
                DataTable dtNorth = getsaleByYearMonthZone(0, iAnand, "", dsNewDataSetWithZone.Tables["sale"]);

                for (int iSSDN = 0; iSSDN < dtNorth.Rows.Count; iSSDN++)
                {
                    sale = Convert.ToDouble(dtNorth.Rows[iSSDN]["lsaletotal"]);
                    saleTotal += sale;

                    AccountManager = Convert.ToDouble(dtNorth.Rows[iSSDN]["accountmanagercount"]);
                    AccountMangagerTotal += AccountManager;
                }



                DataTable dtNorthBilling = getBillingByYearMonthZone(0, iAnand, "", dsNewDataSetWithZone.Tables["Billing"]);

                for (int iSSDN = 0; iSSDN < dtNorthBilling.Rows.Count; iSSDN++)
                {
                    revenue = Convert.ToDouble(dtNorthBilling.Rows[iSSDN]["lrevenuetotal"]);
                    revenueTotal += revenue;
                }                

                saleTotalGrand += saleTotal;
                revenueTotalGrand += revenueTotal;
                AccountMangagerTotalGrand += AccountMangagerTotal;

                double FoundMonths = getMonthsInYear(iAnand, dsNewDataSetWithZone.Tables["sale"], "");

                double AccountManagerCount = getAccountManagerCountInYear(iAnand , DSEmpYearAndZoneWise.Tables[0]);

                dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["lsaletotal"] = Math.Round(saleTotal).ToString();
                dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["lrevenuetotal"] = Math.Round(revenueTotal).ToString();
                //dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountMangagerTotal).ToString();
                dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["accountmanagercount"] = Math.Round(AccountManagerCount).ToString();
                dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["SaleAvgYearWise"] = Math.Round(saleTotal/FoundMonths).ToString();
                dsNewSaleReportYearWise.Tables[0].Rows[iRowsToAdd - 1]["RevAvgYearWise"] = Math.Round(revenueTotal / FoundMonths).ToString();
            }

            //if (saleTotalGrand > 0)
            //{
            //    dsNewSaleReportYearWise.Tables[0].Rows.Add(iFrom + "-" + iTo, Math.Round(saleTotalGrand).ToString(), Math.Round(revenueTotalGrand).ToString());
            //    iRowsToAdd += 1;
            //}

            RadGrid1New.DataSource = dsNewSaleReportYearWise.Tables[0];
            RadGrid1New.DataBind();
            RadGrid1New.Visible = true;

        }
        else
        {
            RadGrid1New.Visible = false;
        }

    }

    private int getAccountManagerCountInYear(int iAnand, DataTable DSEmpYearAndZoneWise)
    {
        if (DSEmpYearAndZoneWise.Select("saleyear = " + iAnand).Count() > 0)
	    {
            DataRow[] foundRows = DSEmpYearAndZoneWise.Select("saleyear = " + iAnand );
            return Convert.ToInt32(foundRows[0]["employeeid"]);
	    }
        else
        {
            return 0;
        }
    }

    private int getAccountManagerCountInYearZone(int iAnand, string zone , DataTable DSEmpYearAndZoneWise)
    {
        if (DSEmpYearAndZoneWise.Select("saleyear = " + iAnand + " and zone = '" + zone + "'").Count() > 0)
        {
            DataRow[] foundRows = DSEmpYearAndZoneWise.Select("saleyear = " + iAnand + " and zone = '" + zone + "'");
            return Convert.ToInt32(foundRows[0]["employeeid"]);
        }
        else
        {
            return 0;
        }
    }

    public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
    {
        DataTable dtUniqRecords = new DataTable();
        dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
        return dtUniqRecords;
    }

    private double getMonthsInYear(int year , DataTable dsAll , string Zone)
    {


        System.Data.DataView view = new System.Data.DataView(dsAll);
        System.Data.DataTable selected = view.ToTable(true, "saleyear", "salemonth");

        System.Data.DataTable selected2 = view.ToTable(true, "saleyear", "salemonth" , "zone");
        int FoundMonths = 0;

        DataRow[] foundRows;
        DataRow[] foundRows2;

        if (Zone == "")
        {
            if (selected.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) ").Count() > 0 )
            {
                DataTable dt = selected.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) ").Distinct().CopyToDataTable();
                FoundMonths = dt.Rows.Count;
                year = year + 1; 
            }
            else
	        {
                return 0 ;    
	        }

            if (selected.Select("saleyear=" + year + " and salemonth in (1,2,3)").Count() > 0 )
            {
                DataTable dt2 = selected.Select("saleyear=" + year + " and salemonth in (1,2,3)").Distinct().CopyToDataTable();
                FoundMonths += dt2.Rows.Count;                
            }

            
            
            
        }
        else
        {
            if (selected2.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) and zone='" + Zone + "'").Count() > 0)
            {
                DataTable dt = selected2.Select("saleyear=" + year + " and salemonth in (4,5,6,7,8,9,10,11,12) and zone='" + Zone + "'").Distinct().CopyToDataTable();
                FoundMonths = dt.Rows.Count;
                year = year + 1;                
            }
            else
            {
                return 0;   
            }
            if (selected2.Select("saleyear=" + year + " and salemonth in (1,2,3) and zone='" + Zone + "'").Count() > 0)
            {
                DataTable dt2 = selected2.Select("saleyear=" + year + " and salemonth in (1,2,3) and zone='" + Zone + "'").Distinct().CopyToDataTable();
                FoundMonths += dt2.Rows.Count;
            }
            else
            {
                return 0;
            }
        }
        return FoundMonths;
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
                foundRows = dsAll.Select("saleyear=" + year   + " and salemonth in (4,5,6,7,8,9,10,11,12) ");
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

    protected void RadGrid1Zone_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].CssClass = "hpCSS";
           // e.Row.Cells[0].ForeColor = System.Drawing.Color.Gray;

            

            Label lblSalePercentageCurrent = (Label)e.Row.FindControl("lblSalePercentage");

            if (LastYearSalesCountZoneWise != -100.0)
            {
                Label lblSaleCount = (Label)e.Row.FindControl("lblSaleCount");
                CurrectYearSalesCountZoneWise = Convert.ToDouble(lblSaleCount.Text);
                double SalesPer = (CurrectYearSalesCountZoneWise - LastYearSalesCountZoneWise) / CurrectYearSalesCountZoneWise * 100;
                lblSalePercentageCurrent.Text = Math.Round(SalesPer).ToString() + "%";

            }
            


            if (LastYearSalesCountZoneWise == -100)
            {
                Label lblSaleCount = (Label)e.Row.FindControl("lblSaleCount");
                LastYearSalesCountZoneWise = Convert.ToDouble(lblSaleCount.Text);
            }
            else
            {
                LastYearSalesCountZoneWise = CurrectYearSalesCountZoneWise;
            }


            Label lblRevenueAvg = (Label)e.Row.FindControl("lblRevenueAvg");

            if (lblRevenueAvg.Text == "")
            {
                LastYearSalesCountZoneWise = -100;
                lblSalePercentageCurrent.Text = "";
                
            }


            string sZone = string.Empty;
            e.Row.Cells[0].CssClass = "openmenu2";

            Label lblzone = e.Row.FindControl("lblzone") as Label;
            Image imgShowGrowth = e.Row.FindControl("imgShowGrowth") as Image;

            if (lblzone.Text.Contains("Total"))
            {
                zoneLastARPUCount = 0;
                imgShowGrowth.Visible = false;
                sZone = lblzone.Text;
                sZone = sZone.Replace("Total", "").Trim();

                Label lblFromToYear = e.Row.FindControl("lblYear") as Label;
                lblFromToYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();

                //HyperLink hpYear = e.Row.FindControl("hpYear") as HyperLink;

                //hpYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();
                //hpYear.NavigateUrl = "rptSaleBillingBranchWisePopUP.aspx?yearfromto=" + hpYear.Text + "&zonename=" + sZone;
             
                double sumZoneTotal = 0;
                double sumZoneTotal2 = 0;

                e.Row.BackColor = System.Drawing.Color.DarkGray;
                Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
                if (lbl1.Text != "")
                {
                    sumZoneTotal = Convert.ToDouble(lbl1.Text);
                }

                Label lbl2 = e.Row.FindControl("lblRevenueTotal") as Label;
                if (lbl2.Text != "")
                {
                    sumZoneTotal2 = Convert.ToDouble(lbl2.Text);
                }

                Label lbl3 = e.Row.FindControl("lblARPU") as Label;
                double sumArpu = 0;
                if (sumZoneTotal2 > 0)
                    sumArpu = sumZoneTotal2 / sumZoneTotal;

                lbl3.Text = Math.Round(sumArpu).ToString();
                zoneLastAmount = 0;
            }
            else
            {
                double zoneCurrentSaleCount = 0;
                double asPerBillingAmount = 0;
                double percentageOfAmount = 0;

                accountmanagercountGrandTotalZone += Convert.ToInt32((((Label)e.Row.FindControl("lblaccountmanagercount")).Text));

                

               

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

                Label lbl8 = e.Row.FindControl("lblARPU") as Label;
                double sumArpu = 0;
                if (zoneCurrentAmount > 0)
                    sumArpu = zoneCurrentAmount / zoneCurrentSaleCount;

                lbl8.Text = Math.Round(sumArpu).ToString();

                if (zoneLastAmount > 0 && zoneCurrentAmount > 0) // for Percentage and As Per Billing amount
                {
                    Label lblPercentage = e.Row.FindControl("lblPercentage") as Label;
                    Label lblAsPerBillingAmount = e.Row.FindControl("lblAsPerBillingAmount") as Label;

                    asPerBillingAmount = zoneCurrentAmount - zoneLastAmount;
                    lblAsPerBillingAmount.Text = Math.Round(asPerBillingAmount).ToString();

                    percentageOfAmount = asPerBillingAmount / zoneCurrentAmount * 100;

                    lblPercentage.Text = Math.Round(percentageOfAmount).ToString() + "%";

                }
                if (lbl8.Text != "")
                {
                    zoneCurrentARPUCount = Convert.ToDouble(lbl8.Text);
                }


                // Image Display Growth and Down...
                if (zoneLastARPUCount > 0)
                {

                    if (zoneLastARPUCount - zoneCurrentARPUCount > 0)
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


                if (lbl2.Text != "")
                {
                    zoneLastAmount = Convert.ToDouble(lbl2.Text);
                }

                if (lbl8.Text != "")
                {
                    zoneLastARPUCount = Convert.ToDouble(lbl8.Text);
                }

            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].CssClass = "openmenu2";

            Label lblgrandtotal = e.Row.FindControl("lblSaleCountGrandTotal") as Label;
            Label lblgrandtotallow = e.Row.FindControl("lblRevenueGrandTotal") as Label;
            Label lblGrandTotalARPU = e.Row.FindControl("lblGrandTotalARPU") as Label;

            lblgrandtotal.Text = Convert.ToString(sumZone);
            lblgrandtotallow.Text = Convert.ToString(sum2Zone);
            double arpu = 0;

            if (sum2Zone > 0)
                arpu = sum2Zone / sumZone;

            lblGrandTotalARPU.Text = Math.Round(arpu).ToString();

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
            //Label lblaccountmanagercountGrandTotal = (Label)e.Row.FindControl("lblaccountmanagercountGrandTotal");
            //lblaccountmanagercountGrandTotal.Text = Convert.ToString(accountmanagercountGrandTotalZone);

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

    protected void RadGrid1New_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        double zoneCurrentSaleCount = 0;
        double asPerBillingAmount = 0;
        double percentageOfAmount = 0;        
        yearCurrentARPUCount = 0;


        CurrectYearSalesCount = 0;
        

        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label lblSalePercentageCurrent = (Label)e.Row.FindControl("lblSalePercentage");

            if (LastYearSalesCount != -100.0)
            {                
                Label lblSaleCount = (Label)e.Row.FindControl("lblSaleCount");
                CurrectYearSalesCount = Convert.ToDouble(lblSaleCount.Text);
                double SalesPer = (CurrectYearSalesCount - LastYearSalesCount) / CurrectYearSalesCount * 100;
                lblSalePercentageCurrent.Text = Math.Round(SalesPer).ToString() + "%"; 
              
            }
            



            //e.Row.Attributes.Add("class", "customerRow");
            e.Row.Cells[0].CssClass = "openmenu";
            //GridIte item = (else.ro)e.Row;

            Label lbl1 = e.Row.FindControl("lblSaleCount") as Label;
            if (lbl1.Text != "")
            {
                sum += Convert.ToDouble(lbl1.Text);
                zoneCurrentSaleCount = Convert.ToDouble(lbl1.Text);
            }

            Label lbl2 = e.Row.FindControl("lblRevenueTotal") as Label;
            if (lbl2.Text != "")
            {
                sum2 += Convert.ToDouble(lbl2.Text);
                zoneCurrentAmount = Convert.ToDouble(lbl2.Text);
            }

            Label lbl8 = e.Row.FindControl("lblARPU") as Label;
            double sumArpu = 0;
            if (zoneCurrentAmount > 0)
                sumArpu = zoneCurrentAmount / zoneCurrentSaleCount;

            lbl8.Text = Math.Round(sumArpu).ToString();
            if (lbl8.Text != "")
            {
                yearCurrentARPUCount = Convert.ToDouble(lbl8.Text);
            }
            Image imgShowGrowth = e.Row.FindControl("imgShowGrowth") as Image;
            // Image Display Growth and Down...
            if (yearLastARPUCount > 0)
            {

                if (yearLastARPUCount - yearCurrentARPUCount > 0)
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


            if (zoneLastAmount > 0 && zoneCurrentAmount > 0) // for Percentage and As Per Billing amount
            {
                Label lblPercentage = e.Row.FindControl("lblPercentage") as Label;
                Label lblAsPerBillingAmount = e.Row.FindControl("lblAsPerBillingAmount") as Label;

                asPerBillingAmount = zoneCurrentAmount - zoneLastAmount;
                lblAsPerBillingAmount.Text = Math.Round(asPerBillingAmount).ToString();

                percentageOfAmount = asPerBillingAmount / zoneCurrentAmount * 100;

                lblPercentage.Text = Math.Round(percentageOfAmount).ToString() + "%";

            }

            if (lbl2.Text != "")
            {
                zoneLastAmount = Convert.ToDouble(lbl2.Text);
            }
            if (lbl8.Text != "")
            {
                yearLastARPUCount = Convert.ToDouble(lbl8.Text);
            }


            Label lblaccountmanagercount = (Label)e.Row.FindControl("lblaccountmanagercount");



            if (lblaccountmanagercount.Text != null && lblaccountmanagercount.Text != "")
            {
                //accountmanagercountTotal += Convert.ToDouble(lblaccountmanagercount.Text);
            }

            if (LastYearSalesCount == -100)
            {
                Label lblSaleCount = (Label)e.Row.FindControl("lblSaleCount");
                LastYearSalesCount = Convert.ToDouble(lblSaleCount.Text);
            }
            else
            {
                LastYearSalesCount = CurrectYearSalesCount;
            }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblgrandtotal = e.Row.FindControl("lblSaleCountGrandTotal") as Label;
            Label lblgrandtotallow = e.Row.FindControl("lblRevenueGrandTotal") as Label;
            Label lblGrandTotalARPU = e.Row.FindControl("lblGrandTotalARPU") as Label;

            Label lblFromToYear = e.Row.FindControl("lblFromToYear") as Label;

            lblFromToYear.Text = ddlFromYear.SelectedValue.ToString() + "-" + ddlToYear.SelectedValue.ToString();
            //lblFromToYear.NavigateUrl = "rptSaleBillMonthWisePopUP.aspx?yearfromto=" + lblFromToYear.Text;

            lblgrandtotal.Text = Convert.ToString(sum);
            lblgrandtotallow.Text = Convert.ToString(sum2);

            double arpu = 0;

            if (sum2 > 0)
                arpu = sum2 / sum;

            lblGrandTotalARPU.Text = Math.Round(arpu).ToString();
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            //e.Row.Attributes.Add("class", "customerRow");
            e.Row.Cells[0].CssClass = "openmenu";

            Label lblaccountmanagercountGrandTotal = (Label)e.Row.FindControl("lblaccountmanagercountGrandTotal");
            lblaccountmanagercountGrandTotal.Text = Convert.ToString(accountmanagercountTotal);
            lblaccountmanagercountGrandTotal.Text = "";
            accountmanagercountTotal = 0;
        }
    }
}