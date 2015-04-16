using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Drawing;
using System.Text;
using System.Globalization;

public partial class MISReport_MISReportBrachCountryWise : System.Web.UI.Page
{
    Clay.Invoice.Bll.Invoice objinv = new Clay.Invoice.Bll.Invoice();
    Clay.Invoice.Bll.Web objmisReport = new Clay.Invoice.Bll.Web();
    DataSet ds = new DataSet();
    string controlname = string.Empty;
    string controltype = string.Empty;
    double t = 0;
    double allTotalServiceChrg = 0;
    double allTotalServiceTax = 0;
    double alltotalWithoutSTSC = 0;
    double allCreditNoteTotalContryWise = 0;
    DataRow[] foundRows;
    DataSet dsnew = new DataSet();
    int branchID = 0;
    double amountTotalINR = 0;
    double totalCreditNoteAmount = 0;
    double serviceTaxINR = 0;
    double serviceChrgeTotal = 0;
    double withoutSCSTAmountINR = 0;
    double allAmountTotal = 0;

    double allAmountWithoutSCSTTotalByBranch = 0;
    double allServiceChrgeTotalByBranch = 0;
    double allServiceTaxTotalByBranch = 0;
    double allAmountTotalINRByBranch = 0;
    double allTotalCreditNoteAmount = 0;

    public static Color GetRandomColor()
    {
        KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        return Color.FromKnownColor(colors[GetRandomNo(colors.Length)]);
    }

    private static int GetRandomNo(int MaxValue)
    {
        RandomNumberGenerator rng = RNGCryptoServiceProvider.Create();

        byte[] bytes = new byte[4];

        rng.GetBytes(bytes);

        int rndNum = BitConverter.ToInt32(bytes, 0);

        return Math.Abs(rndNum % MaxValue);
    }

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

        drYear = dsYear.Tables[0].NewRow();
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            if (DateTime.Now.Year == i)
            {
                if ((DateTime.Now.Month > 3))
                {
                    int temp = i + 1;
                    drYear = dsYear.Tables[0].NewRow();
                    drYear["yearVal"] = i + "-" + temp;
                    drYear["yearTxt"] = i;
                    dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
                }
            }
            else
            {
                int temp = i + 1;
                drYear = dsYear.Tables[0].NewRow();
                drYear["yearVal"] = i + "-" + temp;
                drYear["yearTxt"] = i;
                dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
            }

        }

        ddlYear.DataSource = dsYear.Tables[0];
        ddlYear.DataTextField = "yearVal";
        ddlYear.DataValueField = "yearTxt";
        ddlYear.DataBind();
        ddlYear.SelectedIndex = 0;
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

    private DataSet ApplyDataSearchOnBranch(int branchID, int invMonth, DataSet dsAll)
    {
        DataSet ds = new DataSet();

        try
        {
            DataRow[] foundRows;

            foundRows = dsAll.Tables[0].Select("branchid=" + branchID + " and mth=" + invMonth);
            int i = 0;

            ds = dsAll.Clone();

            for (i = 0; i < foundRows.Length; i++)
            {
                ds.Tables[0].ImportRow(foundRows[i]);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;

    }

    private DataSet ApplyDataSearchOnBranchByMonthOnly(int invMonth, DataSet dsAll)
    {
        DataSet ds = new DataSet();

        try
        {
            DataRow[] foundRows;

            foundRows = dsAll.Tables[0].Select("mth=" + invMonth);
            int i = 0;

            ds = dsAll.Clone();

            for (i = 0; i < foundRows.Length; i++)
            {
                ds.Tables[0].ImportRow(foundRows[i]);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;

    }

    private string printAllAmount(string ssdnTemp, double allTotalAmt, DataSet ds)
    {
        string strApr = string.Empty;

        if (ds.Tables[0].Rows.Count > 0)
        {
            amountTotalINR = Convert.ToDouble(ds.Tables[0].Rows[0]["amountinr"]);
            serviceChrgeTotal = Convert.ToDouble(ds.Tables[0].Rows[0]["SCTotal"]);
            serviceTaxINR = Convert.ToDouble(ds.Tables[0].Rows[0]["servicetaxinr"]);
            withoutSCSTAmountINR = Convert.ToDouble(ds.Tables[0].Rows[0]["AmountTotal"]);

            if (ds.Tables[0].Rows[0]["CreditNoteAmount"].ToString() != "")
            {
                totalCreditNoteAmount = Convert.ToDouble(ds.Tables[0].Rows[0]["CreditNoteAmount"]);
            }
            else
            {
                totalCreditNoteAmount = 0;
            }
        }
        else
        {
            amountTotalINR = 0;
            serviceChrgeTotal = 0;
            serviceTaxINR = 0;
            withoutSCSTAmountINR = 0;
            totalCreditNoteAmount = 0;
        }

        strApr += ssdnTemp + "<td  align='right'>" + Moneycomma(Math.Round(withoutSCSTAmountINR, 2).ToString()) + " </td>"
            + "<td  align='right'>" + Moneycomma(Math.Round(serviceChrgeTotal, 2).ToString()) + " </td>"
              + "<td  align='right'>" + Moneycomma(Math.Round(serviceTaxINR, 2).ToString()) + " </td>"
               + "<td  align='right'>" + Moneycomma(Math.Round(totalCreditNoteAmount, 2).ToString()) + " </td>"

               + "<td  align='right'>" + Moneycomma(Math.Round(amountTotalINR, 2).ToString()) + " </td>"
            + "<td align='Right' style='color:black'>" + string.Format("{0:0.00}%", amountTotalINR / allTotalAmt * 100) + "</td>";
        strApr += "</tr>";

        return strApr;
    }

    protected void BindBranchWiseReport(DataSet ds)
    {
        try
        {

            DataSet dsGetDataMth = new DataSet();
            DataSet dsGetDataByMthBranch = new DataSet();

            lblBranchReport.Text = "";
            err.Text = "";
            string strBranchCol = "";

            Boolean blJan = false;
            Boolean blFeb = false;
            Boolean blMar = false;
            Boolean blApr = false;
            Boolean blMay = false;
            Boolean blJun = false;
            Boolean blJul = false;
            Boolean blAug = false;
            Boolean blSep = false;
            Boolean blOct = false;
            Boolean blNov = false;
            Boolean blDec = false;

            string strJan = "", strFeb = "", strMar = "", strApr = "", strMay = "", strJun = "",
                strJul = "", strAug = "", strSep = "", strOct = "", strNov = "", strDec = "";


            err.Visible = true;
            lblBranchReport.Text = "<table cellpadding='1px' cellspacing='1px' border='2px'>";

            strBranchCol = "<td style='vertical-align:top'>"
                 + "<table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='165px'>"
                 + "<colgroup span='2' style='background-color:white'></colgroup>"
                 + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
                + "<td style='width:165px' align='center'>Branch</td></tr>";


            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(4, ds);
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {

                for (int jaiSachi = 0; jaiSachi < dsGetDataMth.Tables[0].Rows.Count; jaiSachi++)
                {
                    allAmountWithoutSCSTTotalByBranch += Convert.ToDouble(dsGetDataMth.Tables[0].Rows[jaiSachi]["amountinr"]);
                }

                blApr = true;

                strApr = "<td style='vertical-align:top'>"
               + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
               + "<colgroup span='2' style='background-color:white'></colgroup>"
           + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
           + "<td colspan='6' style='width:575px' align='center'>" + "April" + "-"
           + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
           + "</tr>";

            }

            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(5, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blMay = true;
                strMay = "<td style='vertical-align:top'>"
              + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
              + "<colgroup span='2' style='background-color:white'></colgroup>"
          + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
          + "<td colspan='6' style='width:575px' align='center'>" + "May" + "-"
          + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
          + "</tr>";


            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(6, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blJun = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "June" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";
                strJun = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "June" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(7, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blJul = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "July" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";
                strJul = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "July" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(8, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blAug = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "August" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";

                strAug = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "August" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(9, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blSep = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "September" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";
                strSep = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "September" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(10, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blOct = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "October" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";

                strOct = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "October" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(11, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blNov = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "November" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";

                strNov = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "November" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(12, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blDec = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "December" + "-" + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>";
                strDec = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "December" + "-"
         + ddlYear.SelectedItem.Text.Substring(0, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(1, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blJan = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "January" + "-" + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>";

                strJan = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "January" + "-"
         + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(2, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blFeb = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "Febuary" + "-" + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>";

                strFeb = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "Febuary" + "-"
         + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>"
         + "</tr>";
            }
            dsGetDataMth = ApplyDataSearchOnBranchByMonthOnly(3, ds);
            //if (Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1]) != 0)
            if (dsGetDataMth.Tables[0].Rows.Count > 0)
            {
                blMar = true;
                //lblBranchReport.Text += "<td colspan='2' align='center'>" + "March" + "-" + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>";

                strMar = "<td style='vertical-align:top'>"
             + " <table cellpadding='3px' cellspacing='1px' style='background-color:gray' width='575px'>"
             + "<colgroup span='2' style='background-color:white'></colgroup>"
         + "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>"
         + "<td colspan='6' style='width:575px' align='center'>" + "March" + "-"
         + ddlYear.SelectedItem.Text.Substring(5, 4).ToString() + " </td>"
         + "</tr>";
            }




            string ssdnTemp = "";
            string ssBranchHead = "";

            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {

                if (i % 2 == 0)
                {
                    ssdnTemp = "<tr style='font-weight:normal;background-color:#e3e3e3;color:black'>";
                    ssBranchHead = "<tr style='font-weight:bold;background-color:#e3e3e3;color:black'>";
                }
                else
                {
                    ssdnTemp = "<tr style='font-weight:normal;background-color:white;color:black'>";
                    ssBranchHead = "<tr style='font-weight:bold;background-color:white;color:black'>";
                }


                strBranchCol += ssBranchHead + "<td align='left'>" + ds.Tables[1].Rows[i][1].ToString() + " </td></tr>";
                branchID = Convert.ToInt32(ds.Tables[1].Rows[i][0]);

                if (blApr == true)
                {


                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 4, ds);

                    allAmountTotal = getTotalAmtByBranch(4, ds);
                    strApr += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blMay == true)
                {
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 5, ds);
                    allAmountTotal = getTotalAmtByBranch(5, ds);
                    strMay += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blJun == true)
                {

                    allAmountTotal = getTotalAmtByBranch(6, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 6, ds);
                    strJun += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blJul == true)
                {

                    allAmountTotal = getTotalAmtByBranch(7, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 7, ds);
                    strJul += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);


                }
                if (blAug == true)
                {

                    allAmountTotal = getTotalAmtByBranch(8, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 8, ds);
                    strAug += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blSep == true)
                {

                    allAmountTotal = getTotalAmtByBranch(9, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 9, ds);
                    strSep += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blOct == true)
                {

                    allAmountTotal = getTotalAmtByBranch(10, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 10, ds);
                    strOct += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blNov == true)
                {

                    allAmountTotal = getTotalAmtByBranch(11, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 11, ds);
                    strNov += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blDec == true)
                {

                    allAmountTotal = getTotalAmtByBranch(12, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 12, ds);
                    strDec += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blJan == true)
                {

                    allAmountTotal = getTotalAmtByBranch(1, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 1, ds);
                    strJan += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
                if (blFeb == true)
                {

                    allAmountTotal = getTotalAmtByBranch(2, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 2, ds);
                    strFeb += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);
                }
                if (blMar == true)
                {

                    allAmountTotal = getTotalAmtByBranch(3, ds);
                    dsGetDataByMthBranch = ApplyDataSearchOnBranch(branchID, 3, ds);
                    strMar += printAllAmount(ssdnTemp, allAmountTotal, dsGetDataByMthBranch);

                }
            }

            strBranchCol += "</td></table>";

            #region jan check blank

            if (strApr != "")
            {
                strApr += printTotal(4, ds);
                strApr += "</td></table>";

                lblBranchReport.Text += strBranchCol + strApr;

            }
            if (strMay != "")
            {
                strMay += printTotal(5, ds);
                strMay += "</td></table>";

                lblBranchReport.Text += strBranchCol + strMay;

            }
            if (strJun != "")
            {
                strJun += printTotal(6, ds);
                strJun += "</td></table>";

                lblBranchReport.Text += strBranchCol + strJun;

            }
            if (strJul != "")
            {
                strJul += printTotal(7, ds);
                strJul += "</td></table>";

                lblBranchReport.Text += strBranchCol + strJul;
            }
            if (strAug != "")
            {
                strAug += printTotal(8, ds);
                strAug += "</td></table>";

                lblBranchReport.Text += strBranchCol + strAug;
            }
            if (strSep != "")
            {
                strSep += printTotal(9, ds);
                strSep += "</td></table>";

                lblBranchReport.Text += strBranchCol + strSep;
            }
            if (strOct != "")
            {
                strOct += printTotal(10, ds);
                strOct += "</td></table>";

                lblBranchReport.Text += strBranchCol + strOct;
            }
            if (strNov != "")
            {
                strNov += printTotal(11, ds);
                strNov += "</td></table>";

                lblBranchReport.Text += strBranchCol + strNov;
            }
            if (strDec != "")
            {
                strDec += printTotal(12, ds);
                strDec += "</td></table>";

                lblBranchReport.Text += strBranchCol + strDec;
            }

            if (strJan != "")
            {
                strJan += printTotal(1, ds);

                strJan += "</td></table>";

                lblBranchReport.Text += strBranchCol + strJan;
            }
            if (strFeb != "")
            {
                strFeb += printTotal(2, ds);
                strFeb += "</td></table>";
                lblBranchReport.Text += strBranchCol + strFeb;
            }
            if (strMar != "")
            {
                strMar += printTotal(3, ds);
                strMar += "</td></table>";
                lblBranchReport.Text += strBranchCol + strMar;
            }
            #endregion



            lblBranchReport.Text = lblBranchReport.Text.ToString().Replace("NaN", "0.00");
        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

    private double getTotalAmtByBranch(int mth, DataSet dsAll)
    {
        double tempAmountINR = 0;
        DataSet dsGetDAtaByM = new DataSet();
        dsGetDAtaByM = ApplyDataSearchOnBranchByMonthOnly(mth, dsAll);

        for (int j = 0; j < dsGetDAtaByM.Tables[0].Rows.Count; j++)
        {
            tempAmountINR += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["amountinr"]);
        }

        return tempAmountINR;

    }

    private string printTotal(int mth, DataSet dsAll)
    {
        DataSet dsGetDAtaByM = new DataSet();
        dsGetDAtaByM = ApplyDataSearchOnBranchByMonthOnly(mth, dsAll);

        allAmountTotalINRByBranch = 0;
        allServiceChrgeTotalByBranch = 0;
        allServiceTaxTotalByBranch = 0;
        allAmountWithoutSCSTTotalByBranch = 0;
        allTotalCreditNoteAmount = 0;

        if (dsGetDAtaByM.Tables[0].Rows.Count > 0)
        {
            for (int j = 0; j < dsGetDAtaByM.Tables[0].Rows.Count; j++)
            {
                allAmountTotalINRByBranch += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["amountinr"]);
                allServiceChrgeTotalByBranch += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["SCTotal"]);
                allServiceTaxTotalByBranch += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["servicetaxinr"]);
                allAmountWithoutSCSTTotalByBranch += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["AmountTotal"]);

                if (dsGetDAtaByM.Tables[0].Rows[j]["CreditNoteAmount"].ToString() != "")
                {
                    allTotalCreditNoteAmount += Convert.ToDouble(dsGetDAtaByM.Tables[0].Rows[j]["CreditNoteAmount"]);
                }
            }
        }
        else
        {
            allAmountTotalINRByBranch = 0;
            allServiceChrgeTotalByBranch = 0;
            allServiceTaxTotalByBranch = 0;
            allAmountWithoutSCSTTotalByBranch = 0;
        }

        string ssdnTemp = "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";

        string strJan = ssdnTemp + "<td  align='right'>" + Moneycomma(Math.Round(allAmountWithoutSCSTTotalByBranch, 2).ToString()) + " </td>"
   + "<td  align='right'>" + Moneycomma(Math.Round(allServiceChrgeTotalByBranch, 2).ToString()) + " </td>"
     + "<td  align='right'>" + Moneycomma(Math.Round(allServiceTaxTotalByBranch, 2).ToString()) + " </td>"
     + "<td  align='right'>" + Moneycomma(Math.Round(allTotalCreditNoteAmount, 2).ToString()) + " </td>"
      + "<td  align='right'>" + Moneycomma(Math.Round(allAmountTotalINRByBranch, 2).ToString()) + " </td>"
   + "<td align='Right' style='color:black'>" + string.Format("100.00%</td>");

        strJan += "</tr>";
        return strJan;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strCheckForCountry = string.Empty;
        // Bind Branch Wise Report ..... 
        try
        {
            DataSet dsBranch = new DataSet();
            err.Text = "";
            if (ddlYear.SelectedIndex == 0 || ddlYear.SelectedItem.Text == "Select")
            {
                err.Text = "Please Select Financial Year";
                ddlYear.Focus();
                return;
            }

            dsBranch = objmisReport.MisReportCountryBranch(ddlYear.SelectedItem.Text.Substring(0, 4) + "-04-01", ddlYear.SelectedItem.Text.Substring(5, 4) + "-03-01");

            if (dsBranch.Tables[0].Rows.Count > 0)
            {

                BindBranchWiseReport(dsBranch);

                btnExport.Visible = true;
            }
        }
        catch (Exception ex)
        {
            err.Text = ex.ToString();
        }

        try
        {
            lblreport.Text = "";
            Label1.Text = "";
            Label1.Visible = true;
            err.Text = "";

            DateTime small = new DateTime();
            DateTime large = new DateTime();
            err.Visible = true;
            Int32 clspan = 0;
            Int32 mthone = Convert.ToInt32(4);
            Int32 mth = Convert.ToInt32(3);
            Int32 mth1 = Convert.ToInt32(3);
            Int32 yrfr = Convert.ToInt32(ddlYear.SelectedItem.Text.Substring(0, 4));
            Int32 yrto = Convert.ToInt32(ddlYear.SelectedItem.Text.Substring(5, 4));

            small = Convert.ToDateTime("04" + "/" + "01" + "/" + yrfr);
            large = Convert.ToDateTime("03" + "/" + "01" + "/" + yrto);
            lblreport.Text = "<table cellpadding='1px' cellspacing='1px' border='2px'>";

            Label1.Text = "<table cellpadding='1px' cellspacing='1px' border='2px'>";
            Label1.Text += "<tr style='font-weight:normal;background-color:#e3e3e3;color:black'><td  align='center' style='font-size:large'><strong> " + Monthheader(small.Month) + "-" + ddlYear.SelectedItem.Text.Substring(0, 4) + " To " + Monthheader(large.Month) + "-" + ddlYear.SelectedItem.Text.Substring(5, 4) + "</strong></td></tr></table>";

            ds = objmisReport.MisReportBycountry(small, large, 2);
            //bool countryTd = false;
            while (small <= large)
            {
                strCheckForCountry = string.Empty;
                clspan = clspan + 1;

                t = 0;
                alltotalWithoutSTSC = 0;
                allTotalServiceChrg = 0;
                allTotalServiceTax = 0;
                allCreditNoteTotalContryWise = 0;

                foundRows = ds.Tables[0].Select("monthval=" + small.Month + " and yearval=" + small.Year);
                if (foundRows.Length == 0)
                {

                    mth = mth + 1;
                    small = small.AddMonths(1);
                    clspan = clspan - 1;
                    if (mth == 13)
                    {
                        mth = 1;
                        yrfr = yrfr + 1;
                    }
                    continue;
                }
                lblreport.Text += "<td style='vertical-align:top'>";
                lblreport.Text += "<table cellpadding='3px' cellspacing='1px' style='background-color:gray' ";
                //if (countryTd == true)
                //{
                //    lblreport.Text += "width='575px'>";
                //}
                //else
                //{
                lblreport.Text += "width='840px'>"; // CHANGE 21-Aug-2013
                //}

                lblreport.Text += "<colgroup span='6' style='background-color:white'></colgroup>";
                lblreport.Text += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";

                // Print the Month and Year on the header ***********************************
                lblreport.Text += "<td colspan='8' align='center'>" + Monthheader(small.Month) + "-" + small.Year + " </td> </tr>"; // CHANGE 21-Aug-2013

                lblreport.Text += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
                //if (Convert.ToInt32("04") == mthone)
                //{
                lblreport.Text += "<td style='width:300px' align='center'>Country </td>";
                // CHANGE 21-Aug-2013
                lblreport.Text += "<td style='width:300px' align='center'>Network </td>";
                // CHANGE 21-Aug-2013
                //countryTd = true;
                //}

                lblreport.Text += "<td style='width:135px'>Amount</td>";
                lblreport.Text += "<td style='width:140px'>S.Charge</td>";
                lblreport.Text += "<td style='width:140px'>S.Tax</td>";
                lblreport.Text += "<td style='width:140px'>Credit Note</td>";
                lblreport.Text += "<td style='width:135px'>Total Amount</td>";

                lblreport.Text += "<td>Amount%</td>";
                lblreport.Text += "</tr>";
                string CountryName = string.Empty;
                string providerName = string.Empty;
                double AmountInr = 0;
                double creditNoteAmtCW = 0;

                #region // -- Get Total Amount of A Month of all country --
                for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                {
                    string Expression = "monthval=" + small.Month
                        + " and countryid=" + ds.Tables[1].Rows[j]["countryid"].ToString()
                        + " and providerid=" + ds.Tables[1].Rows[j]["provider_id"].ToString()
                        + " and yearval=" + small.Year;
                    foundRows = ds.Tables[0].Select(Expression);

                    if (foundRows.Length > 0)
                    {
                        dsnew = ds.Clone();

                        for (int i = 0; i < foundRows.Length; i++)
                        {
                            dsnew.Tables[0].ImportRow(foundRows[i]);
                        }
                        try
                        {
                            t += Convert.ToDouble(dsnew.Tables[0].Rows[0]["amountinr"].ToString());
                            alltotalWithoutSTSC += Convert.ToDouble(dsnew.Tables[0].Rows[0]["AmountTotal"].ToString());
                            allTotalServiceTax += Convert.ToDouble(dsnew.Tables[0].Rows[0]["servicetaxinr"].ToString());
                            allTotalServiceChrg += Convert.ToDouble(dsnew.Tables[0].Rows[0]["SCTotal"].ToString());
                            if (dsnew.Tables[0].Rows[0]["CreditNoteAmount"].ToString() != "")
                            {
                                allCreditNoteTotalContryWise += Convert.ToDouble(dsnew.Tables[0].Rows[0]["CreditNoteAmount"].ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                #endregion
                
                short blackWhite = 0;

                for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                {
                    blackWhite = Convert.ToInt16(ds.Tables[1].Rows[j]["BW"]);

                    string Expression = "monthval=" + small.Month
                        + " and countryid=" + ds.Tables[1].Rows[j]["countryid"].ToString()
                        + " and providerid=" + ds.Tables[1].Rows[j]["provider_id"].ToString()
                        + " and yearval=" + small.Year;

                    CountryName = ds.Tables[1].Rows[j]["countryname"].ToString();
                    providerName = ds.Tables[1].Rows[j]["provider_name"].ToString();

                    foundRows = ds.Tables[0].Select(Expression);

                    AmountInr = 0;// Get A Total Amount of a country of a month...
                    withoutSCSTAmountINR = 0;
                    serviceChrgeTotal = 0;
                    serviceTaxINR = 0;
                    creditNoteAmtCW = 0;

                    if (foundRows.Length > 0)
                    {
                        dsnew = ds.Clone();
                        for (int i = 0; i < foundRows.Length; i++)
                        {
                            dsnew.Tables[0].ImportRow(foundRows[i]);
                        }

                        getAmount(dsnew, out AmountInr, out withoutSCSTAmountINR, out serviceChrgeTotal, out serviceTaxINR, out creditNoteAmtCW);

                    }


                    if (blackWhite % 2 == 0)
                    {
                        lblreport.Text += "<tr style='font-weight:normal;background-color:white;color:black'>";
                    }
                    else
                    {
                        lblreport.Text += "<tr style='font-weight:normal;background-color:#e3e3e3;color:black'>";
                    }
                    //if (CountryName == "UAE")
                    //{ }
                    //if (Convert.ToInt32("04") == mthone)
                    //{
                   

                    if (!(strCheckForCountry.Contains("**" + CountryName + "**")))
                    {
                        lblreport.Text += "<td style='font-weight:bold' align='Left'>" + CountryName + "</td>";
                        strCheckForCountry += "**" + CountryName + "**";
                    }
                    else
                    {
                        lblreport.Text += "<td style='' align='Left'>" + "" + "</td>";
                    }

                    lblreport.Text += "<td style='font-weight:bold' align='Left'>" + providerName + "</td>";
                    //}

                    printContryAmt(withoutSCSTAmountINR, dsnew, t, 0, providerName);
                    printContryAmt(serviceChrgeTotal, dsnew, t, 0, providerName);
                    printContryAmt(serviceTaxINR, dsnew, t, 0, providerName);
                    printContryAmt(creditNoteAmtCW, dsnew, t, 0, providerName);
                    printContryAmt(AmountInr, dsnew, t, 1, providerName);


                    lblreport.Text += "</tr>";
                }


                lblreport.Text += "<tr style='font-weight:bold;background-color:#e0e5f5;color:black'>";
                //if (Convert.ToInt32("04") == mthone)
                //{
                lblreport.Text += "<td align='Right'>Total </td>";
                lblreport.Text += "<td align='Right'> </td>";
                //}
                // PRint the Total Amount 
                lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(alltotalWithoutSTSC, 2).ToString()) + " </td>";
                lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(allTotalServiceChrg, 2).ToString()) + " </td>";
                lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(allTotalServiceTax, 2).ToString()) + " </td>";
                lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(allCreditNoteTotalContryWise, 2).ToString()) + " </td>";
                lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(t, 2).ToString()) + " </td>";
                lblreport.Text += "<td align='Right'> " + "100.00" + "% </td>";
                lblreport.Text += "</tr>";
                lblreport.Text += "</table>";
                lblreport.Text += "</td>";
                mth = mth + 1;

                small = small.AddMonths(1);
                if (mth == 13)
                {
                    mth = 1;
                    yrfr = yrfr + 1;
                }
                mthone += 1;
            }

            lblreport.Text += "</tr></table>";

        }
        catch (Exception ex)
        {
            err.Text = ex.Message.ToString();
        }
    }

    private void getAmount(DataSet ds, out double AmountInr, out double amountTotal, out double serviceChrge, out double serviceTaxINR, out double creditNotAmt)
    {
        try
        {
            AmountInr = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["amountinr"].ToString()), 2);
        }
        catch (Exception ex)
        {
            AmountInr = 0;
        }
        try
        {
            amountTotal = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["AmountTotal"].ToString()), 2);
        }
        catch (Exception ex)
        {
            amountTotal = 0;
        }
        try
        {
            serviceChrge = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["SCTotal"].ToString()), 2);
        }
        catch (Exception ex)
        {
            serviceChrge = 0;
        }
        try
        {
            serviceTaxINR = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["servicetaxinr"].ToString()), 2);
        }
        catch (Exception ex)
        {
            serviceTaxINR = 0;
        }

        try
        {
            creditNotAmt = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0]["CreditNoteAmount"].ToString()), 2);
        }
        catch (Exception ex)
        {
            creditNotAmt = 0;
        }
    }

    private void printContryAmt(double AmountInr, DataSet dsnew, double t, int displayPer, string provider_Name)
    {
        if (string.Format("{0:0.00}", AmountInr) != "0.00")
        {
            if (provider_Name.ToUpper() == "UNKNOWN")
            {
                lblreport.Text += "<td align='Right' style='color:Red'>" + Moneycomma(Math.Round(AmountInr, 2).ToString()) + "(" + dsnew.Tables[0].Rows[0]["Reptype"].ToString() + ")" + "</td>";
            }
            else
            {
                if (dsnew.Tables[0].Rows[0]["Reptype"].ToString() == "A")
                {
                    lblreport.Text += "<td align='Right' style='color:Green'>" + Moneycomma(Math.Round(AmountInr, 2).ToString()) + "(" + dsnew.Tables[0].Rows[0]["Reptype"].ToString() + ")" + "</td>";
                }
                else
                {
                    lblreport.Text += "<td align='Right' style='color:Maroon'>" + Moneycomma(Math.Round(AmountInr, 2).ToString()) + "(" + dsnew.Tables[0].Rows[0]["Reptype"].ToString() + ")" + "</td>";
                }
            }
        }
        else
        {
            lblreport.Text += "<td align='Right'>" + Moneycomma(Math.Round(AmountInr, 2).ToString()) + "(" + "-" + ")" + "</td>";
        }

        if (displayPer == 1)
        {
            if (Convert.ToDouble(AmountInr) > 0)
            {
                if (provider_Name.ToUpper() == "UNKNOWN")
                {
                    lblreport.Text += "<td align='Right' style='color:Red'>" + string.Format("{0:0.00}%", Convert.ToDouble(AmountInr) / t * 100) + "</td>";
                }
                else
                {
                    if (dsnew.Tables[0].Rows[0]["Reptype"].ToString() == "A")
                    {
                        lblreport.Text += "<td align='Right' style='color:Green'>" + string.Format("{0:0.00}%", Convert.ToDouble(AmountInr) / t * 100) + "</td>";
                    }
                    else
                    {
                        lblreport.Text += "<td align='Right' style='color:Maroon'>" + string.Format("{0:0.00}%", Convert.ToDouble(AmountInr) / t * 100) + "</td>";
                    }
                }
            }
            else
            {
                lblreport.Text += "<td align='Right'style='color:Black'>" + string.Format("{0:0.00}%", 0) + "</td>";
            }
        }
    }

    public string decimalval(string val)
    {

        string DecVal = "";
        Int32 DecPos = 0;
        DecPos = val.IndexOf(".");

        // Find the Decimal Values
        DecVal = val.Substring(DecPos + 1, 2);
        val = val.Substring(0, DecPos);

        if (DecVal != "00")
        {
            DecVal = "00";
        }
        val = val + DecVal;
        return val;
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
        lblBranchReport.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
