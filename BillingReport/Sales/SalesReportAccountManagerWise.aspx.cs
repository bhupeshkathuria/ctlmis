﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_SalesReportAccountManagerWise : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();
    int NoOfDaysInMonth = 0;
    int NoOfTotalDays = 0;

    #endregion

    #region User Defined Methods

    private void LoadReport(string Year, string Month)
    {
        NoOfDaysInMonth = System.DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
        ds = objSalesSummaryReport.GetReportAccountManagerWise(Year, Month);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdview1.DataSource = ds.Tables[0];
            grdview1.DataBind();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SortedList<string, string> sortedYear = new SortedList<string, string>();
            sortedYear.Add("", "Select");
            sortedYear.Add("2009", "2009");
            sortedYear.Add("2010", "2010");
            sortedYear.Add("2011", "2011");
            sortedYear.Add("2012", "2012");
            sortedYear.Add("2013", "2013");
            sortedYear.Add("2014", "2014");
            sortedYear.Add("2015", "2015");
            sortedYear.Add("2016", "2016");
            sortedYear.Add("2017", "2017");
            sortedYear.Add("2018", "2018");
            sortedYear.Add("2019", "2019");
            sortedYear.Add("2020", "2020");
            ddlYear.DataSource = sortedYear;
            ddlYear.DataValueField = "Key";
            ddlYear.DataTextField = "value";
            ddlYear.DataBind();

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
            sortedMonth.Add("", "Select");
            sortedMonth.Add("01", "January");
            sortedMonth.Add("02", "Febraury");
            sortedMonth.Add("03", "March");
            sortedMonth.Add("04", "April");
            sortedMonth.Add("05", "May");
            sortedMonth.Add("06", "June");
            sortedMonth.Add("07", "July");
            sortedMonth.Add("08", "August");
            sortedMonth.Add("09", "September");
            sortedMonth.Add("10", "October");
            sortedMonth.Add("11", "Novemver");
            sortedMonth.Add("12", "December");
            ddlMonth.DataSource = sortedMonth;
            ddlMonth.DataValueField = "Key";
            ddlMonth.DataTextField = "value";
            ddlMonth.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString());
    }
}