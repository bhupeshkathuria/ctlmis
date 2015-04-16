﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using System.Text;

public partial class Sales_SalesDashboardNew : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();

    static DateTime Todate = new DateTime();//year - 1, month, 1
    static DateTime FromDate = new DateTime();//year - 1, month - 2, 1

    static string cfromdate = string.Empty;
    static string ctodate = string.Empty;

    int year1 =  0 , year2 = 0 , year3  = 0 ;

    #endregion

    #region User Defined Methods

    private void LoadReport(string Year, string Month, string _fromDate, string _todate, string searchby, int _sbranch)
    {
        ds = objSalesSummaryReport.GetSummaryReport1(Year, Month, _fromDate, _todate, searchby, _sbranch);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //rptr1.DataSource = ds.Tables[2];
            //rptr1.DataBind();

            gvRegionSales.DataSource = ds.Tables[2];
            gvRegionSales.DataBind();

            gvBranch.DataSource = ds.Tables[0];
            gvBranch.DataBind();
            ViewState["Branch"] = ds.Tables[0];

            gvStatus.DataSource = ds.Tables[1];
            gvStatus.DataBind();
            //rptr6.DataSource = ds.Tables[4];
            //rptr6.DataBind();
            gvProduct.DataSource = ds.Tables[4];
            gvProduct.DataBind();

            //gvLastThreeMonth.DataSource = ds.Tables[5];
            //gvLastThreeMonth.DataBind();


            gvDailySales.DataSource = ds.Tables[5];
            gvDailySales.DataBind();
            ViewState["Daliy"] = ds.Tables[5];


            //gvleadsource.DataBind();

            lbllastyearcount.Text = ds.Tables[6].Rows[0]["count1"].ToString();


        }
    }

    public void GetRange(int year, int month)
    {


        Todate = new DateTime();
        FromDate = new DateTime();
        int _noofdays = 0;
        if (month.ToString() == "1" || month.ToString() == "3" || month.ToString() == "5" || month.ToString() == "7" || month.ToString() == "8" || month.ToString() == "10" || month.ToString() == "12")
        {
            _noofdays = 31;
        }
        else if (month.ToString() == "2")
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            {
                _noofdays = 29;
            }
            else
            {
             _noofdays = 28;
            }

        }
        else
        {
            _noofdays = 30;
        }
        //if (month < 3)
        //{
        //    Todate = new DateTime(year - 1, month, _noofdays);
        //    // month=12-(month - 2);
        //    FromDate = new DateTime(year - 2, 12 + (month - 2), 1);
        //}
        //else
        //{
        //    Todate = new DateTime(year - 1, month, _noofdays);
        //    FromDate = new DateTime(year - 1, month - 2, 1);
        //}

        if (month <= 3)
        {
            if (month != 1)
            {
                

                FromDate = new DateTime(year - 1, 12 + (month-1-2), 1);

                if ((month - 1).ToString() == "1" || (month - 1).ToString() == "3" || (month - 1).ToString() == "5" || (month - 1).ToString() == "7" || (month - 1).ToString() == "8" || (month - 1).ToString() == "10" || (month - 1).ToString() == "12")
                {
                    _noofdays = 31;
                }
                else if ((month - 1).ToString() == "2")
                {
                    if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                    {
                        _noofdays = 29;
                    }
                    else
                    {
                        _noofdays = 28;
                    }

                }
                Todate = new DateTime(year, (month-1), _noofdays);
                // month=12-(month - 2);                
            }
            else
            {
                FromDate = new DateTime(year - 1, 12 + (month - 3), 1);
                Todate = new DateTime(year - 1, 12, _noofdays);
                // month=12-(month - 2);                
            }
        }
        else
        {
            FromDate = new DateTime(year, ((month - 1) - 2), 1);
            if ((month - 1).ToString() == "1" || (month - 1).ToString() == "3" || (month - 1).ToString() == "5" || (month - 1).ToString() == "7" || (month - 1).ToString() == "8" || (month - 1).ToString() == "10" || (month - 1).ToString() == "12")
            {
                _noofdays = 31;
            }
            else if ((month - 1).ToString() == "2")
            {
                if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                {
                    _noofdays = 28;
                }
                else
                {
                    _noofdays = 29;
                }

            }
            else
            {
                _noofdays = 30;
            }
            Todate = new DateTime(year , (month-1), _noofdays);            
        }

        cfromdate = FromDate.ToString("yyyy-MM-dd");
        ctodate = Todate.ToString("yyyy-MM-dd");
        //if (month < 3)
        //{

        //    year = year - 1;

        //    month = 12 + (month - 2);
        //}

        //else

        //    month = month - 2;

        //DateTime FromDate = new DateTime(year - 1, month, 1);

    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        year1 = 0; year2 = 0; year3 = 0;
        if (!IsPostBack)
        {
            ddlYear.Items.Clear();
            for (int i = DateTime.Now.Year; i >= 2008; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
           // sortedMonth.Add("", "Select");
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
            int month = DateTime.Now.Month;
            for (int i = 0; i < ddlMonth.Items.Count; i++)
            {
                if (int.Parse(ddlMonth.Items[i].Value) == month)
                {
                    ddlMonth.SelectedIndex = i;
                }
            }

            gvRegionSales.Caption = "<span style='color:Black;font-weight: bold'> Region Sales</span>";
            gvProduct.Caption = "<span style='color:Black;font-weight: bold'> Product Sales</span>";
            gvStatus.Caption = "<span style='color:Black;font-weight: bold'> Order Status Sales</span>";
            gvBranch.Caption = "<span style='color:Black;font-weight: bold'> Branch Sales</span>";
           // gvLastThreeMonth.Caption = "<span style='color:Black;font-weight: bold'> Last Three Month Sales</span>";
            gvDailySales.Caption = "<span style='color:Black;font-weight: bold'> Daily Sales</span>";
            gvPrepaidSales.Caption = "<span style='color:Black;font-weight: bold'> Prepaid Sales Report</span>";
            gvPrepaidSales.Caption = "<span style='color:Black;font-weight: bold'> Prepaid Sales Report</span>";
        }
        DataSet dsCurrenDaySaleCount = objSalesSummaryReport.GetCurrentDaySaleCount(ddlsearch.Text.Trim());
        if (dsCurrenDaySaleCount.Tables[0].Rows.Count > 0)
        {
            lblcurrentdaycount.Text = dsCurrenDaySaleCount.Tables[0].Rows[0]["SaleCount"].ToString();
        }
        if (dsCurrenDaySaleCount.Tables[1].Rows.Count > 0)
        {
            lbllastyearday.Text = dsCurrenDaySaleCount.Tables[1].Rows[0]["SaleCount"].ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int _salebranch = 0;
        if (chksalesbranch.Checked)
        {
            _salebranch = 1;
        }
        else
        {
            _salebranch = 0;
        }

        lblMonth.Text = "Sales Report of " + ddlMonth.SelectedItem.Text.ToString() + "-" + ddlYear.SelectedItem.Text.ToString() + "";

        GetRange(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));

        this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), FromDate.ToString("yyyy-MM-dd"), Todate.ToString(("yyyy-MM-dd")), ddlsearch.Text.Trim(), _salebranch);
        LoadReport();
        //getReportyearwise();

        getReportyearwisenew(ddlsearch.Text.Trim());
    }

    private void getReportyearwisenew(string p)
    {
        DataSet dsr = new DataSet();
        dsr = objSalesSummaryReport.GetsalesYearly(p);

        grdthreeyearsale.DataSource = dsr.Tables[0];
        grdthreeyearsale.DataBind();
    }

    

    private void LoadReport()
    {
        try
        {
            gvPrepaidSales.DataSource = DataAccess.GetBusTypeMonthlySale(int.Parse(ddlYear.Text), short.Parse(ddlMonth.SelectedValue));
            gvPrepaidSales.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
   
    protected void gvPrepaidSales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Contains("Sales"))
        {
            LinkButton lnk=(LinkButton)e.CommandSource ;
            int Year = int.Parse(ddlYear.Text);
            short busTypeId = Convert.ToInt16(e.CommandArgument);
            int monthId = Convert.ToInt32(ddlMonth.Text);

            GridView2.DataSource = DataAccess.GetBranchWiseMonthlySale(Year, monthId, busTypeId);
            GridView2.DataBind();
            lblHeader.Text = "Branch Wise Sales";
            GridView2.Visible = true;
            GridView3.Visible = false;
            pnlBranch.Visible = true;
            if (GridView2.Rows.Count > 0)
                Popup(true);
            //System.Threading.Thread.Sleep(500);
        }
        else if (e.CommandName.Contains("Recharge"))
        {
            LinkButton lnk = (LinkButton)e.CommandSource;
            int Year = int.Parse(ddlYear.Text);
            short busTypeId = Convert.ToInt16(e.CommandArgument);
            int monthId = Convert.ToInt32(ddlMonth.Text);

            GridView3.DataSource = DataAccess.GetRechageSourceWise(Year, monthId, busTypeId);
            GridView3.DataBind();
            lblHeader.Text = "Recharge Source Wise";
            GridView3.Visible = true;
            GridView2.Visible = false;
            pnlBranch.Visible = true;
            if(GridView3.Rows.Count>0)
                Popup(true);
            //System.Threading.Thread.Sleep(500);
        }

    }
    protected void gvPrepaidSales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int noOfSale = 0;
            double activationAmount = 0;
            double rechargeAmount = 0;
            foreach (GridViewRow gr in gvPrepaidSales.Rows)
            {
                LinkButton lbSales = (LinkButton)gr.FindControl("lbSales");
                LinkButton lbRecharge = (LinkButton)gr.FindControl("lbRecharge");
                noOfSale += Convert.ToInt32(lbSales.Text);
                activationAmount += Convert.ToDouble(gr.Cells[2].Text);
                rechargeAmount += Convert.ToDouble(lbRecharge.Text);
            }
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = noOfSale.ToString();
            e.Row.Cells[2].Text = activationAmount.ToString("0.00");
            e.Row.Cells[3].Text = rechargeAmount.ToString("0.00");
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int noOfSale = 0;
            double activationAmount = 0;
            double rechargeAmount = 0;
            foreach (GridViewRow gr in GridView2.Rows)
            {
                noOfSale += Convert.ToInt32(gr.Cells[3].Text);
                //activationAmount += Convert.ToDouble(gr.Cells[4].Text);
                activationAmount += Convert.ToDouble(gr.Cells[4].Text.Replace("&nbsp;", "0"));
                rechargeAmount += Convert.ToDouble(gr.Cells[5].Text.Replace("&nbsp;", "0"));
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[3].Text = noOfSale.ToString();
            e.Row.Cells[4].Text = activationAmount.ToString("0.00");
            e.Row.Cells[5].Text = rechargeAmount.ToString("0.00");
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            double manualAmount = 0;
            double OnlineAmount = 0;
            foreach (GridViewRow gr in GridView3.Rows)
            {
                manualAmount += Convert.ToDouble(gr.Cells[3].Text);
                OnlineAmount += Convert.ToDouble(gr.Cells[4].Text);
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[3].Text = manualAmount.ToString("0.00");
            e.Row.Cells[4].Text = OnlineAmount.ToString("0.00");
        }
    }
    protected void gvRegionSales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales = 0;
            foreach (GridViewRow gr in gvRegionSales.Rows)
            {
                Label lblRegionCount = (Label)gr.FindControl("lblRegionCount");
                totalSales += int.Parse(lblRegionCount.Text);
            }
            Label lblRegionTotalCount = (Label)e.Row.FindControl("lblRegionTotalCount");
            lblRegionTotalCount.Text = totalSales.ToString();
        }
    }
    protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales = 0;
            foreach (GridViewRow gr in gvProduct.Rows)
            {
                Label lblProductCount = (Label)gr.FindControl("lblProductCount");
                totalSales += int.Parse(lblProductCount.Text);
            }
            Label lblProductTotalCount = (Label)e.Row.FindControl("lblProductTotalCount");
            lblProductTotalCount.Text = totalSales.ToString();
        }
    }
    protected void gvStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales = 0;
            foreach (GridViewRow gr in gvStatus.Rows)
            {
                Label lblStatusTotal = (Label)gr.FindControl("lblStatusTotal");
                totalSales += int.Parse(lblStatusTotal.Text);
            }
            Label lblStatusTotalCount = (Label)e.Row.FindControl("lblStatusTotalCount");
            lblStatusTotalCount.Text = totalSales.ToString();
        }
    }
    protected void gvBranch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales = 0;
            int totaldelivery = 0;
            foreach (GridViewRow gr in gvBranch.Rows)
            {
                Label lblBranchCount = (Label)gr.FindControl("lblBranchCount");
                totalSales += int.Parse(lblBranchCount.Text);

                Label lblBranchDeliveryCount = (Label)gr.FindControl("lblBranchDeliveryCount");
                totaldelivery += int.Parse(lblBranchDeliveryCount.Text);
            }
            Label lblBranchTotalCount = (Label)e.Row.FindControl("lblBranchTotalCount");
            lblBranchTotalCount.Text = totalSales.ToString();


            Label lblBranchDeliveryTotalCount = (Label)e.Row.FindControl("lblBranchDeliveryTotalCount");
            lblBranchDeliveryTotalCount.Text = totaldelivery.ToString();
        }
    }
    //protected void gvLastThreeMonth_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        int totalSales = 0;
    //        foreach (GridViewRow gr in gvLastThreeMonth.Rows)
    //        {
    //            Label lblLastThreeMonthCount = (Label)gr.FindControl("lblLastThreeMonthCount");
    //            totalSales += int.Parse(lblLastThreeMonthCount.Text);
    //        }
    //        Label lblLastThreeMonthTotalCount = (Label)e.Row.FindControl("lblLastThreeMonthTotalCount");
    //        lblLastThreeMonthTotalCount.Text = totalSales.ToString();
    //    }
    //}
    protected void gvDailySales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales = 0;
            int totalonline = 0;
            int totaloffline = 0;
            foreach (GridViewRow gr in gvDailySales.Rows)
            {
                Label lblonline = (Label)gr.FindControl("lblonline");
                totalonline += int.Parse(lblonline.Text);

                Label lbloffline = (Label)gr.FindControl("lbloffline");
                totaloffline += int.Parse(lbloffline.Text);

                Label lblDateCount = (Label)gr.FindControl("lblDateCount");
                totalSales += int.Parse(lblDateCount.Text);
            }
            Label lblTotalonline = (Label)e.Row.FindControl("lblTotalonline");
            lblTotalonline.Text = totalonline.ToString();

            Label lblTotaloffline = (Label)e.Row.FindControl("lblTotaloffline");
            lblTotaloffline.Text = totaloffline.ToString();

            Label lblDateTotalCount = (Label)e.Row.FindControl("lblDateTotalCount");
            lblDateTotalCount.Text = totalSales.ToString();

            
        }
    }

    public string SortExpressionBranch
    {
        get { return (ViewState["SortExpressionBranch"] != null ? ViewState["SortExpressionBranch"].ToString() : string.Empty); }
        set { ViewState["SortExpressionBranch"] = value; }
    }
    public string SortDirectionBranch
    {
        get { return (ViewState["SortDirectionBranch"] != null ? ViewState["SortDirectionBranch"].ToString() : string.Empty); }
        set { ViewState["SortDirectionBranch"] = value; }
    }

    public string SortExpressionDaily
    {
        get { return (ViewState["SortExpressionDaily"] != null ? ViewState["SortExpressionDaily"].ToString() : string.Empty); }
        set { ViewState["SortExpressionDaily"] = value; }
    }
    public string SortDirectionDaily
    {
        get { return (ViewState["SortDirectionDaily"] != null ? ViewState["SortDirectionDaily"].ToString() : string.Empty); }
        set { ViewState["SortDirectionDaily"] = value; }
    }

    private string GetSortDirection(string column, string SortExpressionName, string SortDirectionBranch)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState[SortExpressionName] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression.Contains(column))
            {
                string lastDirection = ViewState[SortDirectionBranch] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState[SortDirectionBranch] = sortDirection;
        ViewState[SortExpressionName] = column;

        return sortDirection;
    }
    protected void gvBranch_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpressionBranch = e.SortExpression + " " + GetSortDirection(e.SortExpression, "SortExpressionBranch","SortDirectionBranch");
            if (ViewState["Branch"] != null)
            {
                DataView dv = ((DataTable)ViewState["Branch"]).DefaultView;
                dv.Sort = SortExpressionBranch;
                gvBranch.DataSource = dv;
                gvBranch.DataBind();
            }
        }
    }
    protected void gvDailySales_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpressionBranch = e.SortExpression + " " + GetSortDirection(e.SortExpression, "SortExpressionDaliy", "SortDirectionDaliy");
            if (ViewState["Daliy"] != null)
            {
                DataView dv = ((DataTable)ViewState["Daliy"]).DefaultView;
                dv.Sort = SortExpressionBranch;
                gvDailySales.DataSource = dv;
                gvDailySales.DataBind();
            }
        }
    }

    //To show message after performing operations
    void Popup(bool isDisplay)
    {
        StringBuilder builder = new StringBuilder();
        if (isDisplay)
        {
            builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
        }
        else
        {
            builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
        }
    }

    protected void grdthreeyearsale_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalSales1 = 0;
            int totalSales2 = 0;
            int totalSales3 = 0;
            foreach (GridViewRow gr in grdthreeyearsale.Rows)
            {
                Label lbl1 = (Label)gr.FindControl("lbl1");
                totalSales1 += int.Parse(lbl1.Text);

                Label lbl2 = (Label)gr.FindControl("lbl2");
                totalSales2 += int.Parse(lbl2.Text);

                Label lbl3 = (Label)gr.FindControl("lbl3");
                totalSales3 += int.Parse(lbl3.Text);
            }
            Label lblfoter1 = (Label)e.Row.FindControl("lblfoter1");
            lblfoter1.Text = totalSales1.ToString();
            Label lblfoter2 = (Label)e.Row.FindControl("lblfoter2");
            lblfoter2.Text = totalSales2.ToString();
            Label lblfoter3 = (Label)e.Row.FindControl("lblfoter3");
            lblfoter3.Text = totalSales3.ToString();
        }
    }

    public void getReportyearwise()
    {
        int _month = 0;
        string _monthname = string.Empty;
        string amount2011 = string.Empty;
        string amount2012 = string.Empty;
        string amount2013 = string.Empty;
        string amountds1 = string.Empty;
        string amountds2 = string.Empty;
        string amountds3 = string.Empty;
        DataSet dsr = new DataSet();
        dsr = objSalesSummaryReport.GetsalesYearly(ddlsearch.Text.Trim());
        #region Create Datatable
        System.Data.DataTable dt3 = new System.Data.DataTable();
        dt3.Columns.Add("Monthno", string.Empty.GetType());
        dt3.Columns.Add("Month", string.Empty.GetType());
        dt3.Columns.Add("2012-2013", string.Empty.GetType());
        dt3.Columns.Add("TodaySales1", string.Empty.GetType());
        dt3.Columns.Add("2013-2014", string.Empty.GetType());
        dt3.Columns.Add("TodaySales2", string.Empty.GetType());
        dt3.Columns.Add("2014-2015", string.Empty.GetType());
        dt3.Columns.Add("TodaySales3", string.Empty.GetType());
        # endregion
        int[] month = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };
        int i = 0;
        for (i = 0; i < month.Length; i++)
        {
            foreach (DataRow dr in dsr.Tables["month"].Rows)
            {
                DataRow[] dr_month = dsr.Tables["month"].Select("monthno=" + month[i]);
                if (dr_month.Length > 0)
                {
                    _month = Convert.ToInt32(dr_month[0]["monthno"].ToString());
                    _monthname = (dr_month[0]["Month"].ToString());
                }


                DataRow[] dr_11 = dsr.Tables["T2011"].Select("monthno=" + month[i]);
                DataRow[] dr_111 = dsr.Tables["T2011D"].Select("monthno=" + month[i]);

                if (dr_11.Length > 0)
                {
                    //if (dr_11[0]["(2011-2012)"] != DBNull.Value)
                    //{
                    if (dr_11[0]["(2012-2013)"] != DBNull.Value)
                    {
                        amount2011 = Convert.ToString(dr_11[0]["(2012-2013)"]);
                    }
                    else
                    {
                        amount2011 = "0";

                    }
                }
                else
                {
                    amount2011 = "0";

                }
                if (_month==DateTime.Now.Month)
                {
                    if (dr_111.Length > 0)
                    {
                        if (dr_111[0]["TodaySales1"] != DBNull.Value)
                        {
                            amountds1 = Convert.ToString(dr_111[0]["TodaySales1"]);
                            amountds1 = "(" + amountds1 + ")";
                        }
                        else
                        {
                            amountds1 = string.Empty;

                        }
                       
                    }
                    else
                    {
                        amountds1 = string.Empty;

                    }
                }
                else
                {
                    amountds1 = string.Empty;

                }
                 
                #region Bysales2012-13
                DataRow[] dr_2 = dsr.Tables["T2012"].Select("monthno=" + month[i]);
                DataRow[] dr_22 = dsr.Tables["T2012D"].Select("monthno=" + month[i]);
                if (dr_2.Length > 0)
                {
                    if (dr_2[0]["(2013-2014)"] != DBNull.Value)
                    {
                        amount2012 = Convert.ToString(dr_2[0]["(2013-2014)"]);
                    }
                    else
                    {
                        amount2012 = "0";

                    }
                    
                }
                else
                {
                    amount2012 = "0.00";
                }
                if (_month==DateTime.Now.Month)
                {
                    if (dr_22.Length > 0)
                    {
                        if (dr_22[0]["TodaySales2"] != DBNull.Value)
                        {
                            amountds2 = Convert.ToString(dr_22[0]["TodaySales2"]);
                            amountds2 = "(" + amountds2 + ")";
                        }
                        else
                        {
                            amountds2 = string.Empty;
                        }
                    }
                    else
                    {
                        amountds2 = string.Empty;
                    }
                
                }
                else
                {
                    amountds2 = string.Empty;
                }
                
                #endregion

                #region Bysales2013-14
               
                DataRow[] dr_3 = dsr.Tables["T2013"].Select("monthno=" + month[i]);
                DataRow[] dr_33 = dsr.Tables["T2013D"].Select("monthno=" + month[i]);
                if (dr_3.Length > 0)
                {
                    if (dr_3[0]["(2014-2015)"] != DBNull.Value)
                    {
                        amount2013 = Convert.ToString(dr_3[0]["(2014-2015)"]);
                    }
                    else
                    {
                        amount2013 = "0";

                    }
                }
                else
                {
                    amount2013 = "0";
                }
                if (_month == DateTime.Now.Month)
                {
                    if (dr_33.Length > 0)
                    {
                        if (dr_33[0]["TodaySales3"] != DBNull.Value)
                        {
                            amountds3 = Convert.ToString(dr_33[0]["TodaySales3"]);
                            amountds3 = "(" + amountds3 + ")";
                        }
                        else
                        {
                            amountds3 = string.Empty;

                        }
                        
                    }
                    else
                    {
                        amountds3 = string.Empty;

                    }
                }
                else
                {
                    amountds3 = string.Empty;
                }
              
                #endregion

                DataRow dr1 = dt3.NewRow();
                dr1["monthno"] = _month.ToString();
                dr1["month"] = _monthname.ToString();
                dr1["2012-2013"] = amount2011.ToString();
                dr1["TodaySales1"] = amountds1.ToString();
                dr1["2013-2014"] = amount2012.ToString();
                dr1["TodaySales2"] = amountds2.ToString();
                dr1["2014-2015"] = amount2013.ToString();
                dr1["TodaySales3"] = amountds3.ToString();
                dt3.Rows.Add(dr1);
                dt3.AcceptChanges();
                break;
            }
        }
        grdthreeyearsale.DataSource = dt3;
        grdthreeyearsale.DataBind();
    }

    //protected void lnkbtn_Click(object sender, EventArgs e)
    //{
    //    double count = 0.00;
    //    double count1 = 0.00;
    //    double count3 = 0.00;
    //    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //    TextBox tb = (TextBox)grdrow.FindControl("txt");
    //    if (tb.Text!=null || tb.Text=="")
    //    {
    //         count = Convert.ToDouble(tb.Text);
    //    }
    //    Label label1 = (Label)grdrow.FindControl("lblCostSold");
    //     count1 = Convert.ToDouble(label1.Text);
    //     count3 = count * count1;
    //     tb.Text = count3.ToString();
    //     tb.ForeColor = System.Drawing.Color.Blue;
        
    //}
   
    protected void grdthreeyearsale_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chksalesbranch_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void grdthreeyearsale_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void grdthreeyearsale_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            year1 += Convert.ToInt32(e.Row.Cells[2].Text);
            year2 += Convert.ToInt32(e.Row.Cells[3].Text);
            year3 += Convert.ToInt32(e.Row.Cells[4].Text);

            int current_month = DateTime.Now.Month;
            if (current_month == Convert.ToInt32(e.Row.Cells[0].Text) )
            {
                DataSet ds = objSalesSummaryReport.GetsalesTillCurrentDay(ddlsearch.SelectedItem.Text);
                e.Row.Cells[2].Text += "&nbsp&nbsp;(" + ds.Tables[0].Rows[0]["(2012-13)"].ToString()+")";
                e.Row.Cells[3].Text += "&nbsp&nbsp;(" + ds.Tables[0].Rows[0]["(2013-14)"].ToString()+")";
                //e.Row.Cells[4].Text += "&nbsp&nbsp;" + ds.Tables[0].Rows[0]["(2014-15)"].ToString();
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[2].Text = year1.ToString();
            e.Row.Cells[3].Text = year2.ToString();
            e.Row.Cells[4].Text = year3.ToString();
        }
    }
}