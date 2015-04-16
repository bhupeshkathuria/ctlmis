using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_ShortFallReport : System.Web.UI.Page
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
        ds = objSalesSummaryReport.GetShortFallReport(Year, Month);
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

    protected void grdview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int average=0;
        int CountPerDay = 0;
        int CountToBe = 0;
        int TargetTotal = 0;
        int TotalCount = 0;
        int AverageAchievement = 0;
        int AverageAchievementToBe = 0;
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTarget = (Label)e.Row.Cells[0].FindControl("lblTarget");
                Label lblCount = (Label)e.Row.Cells[0].FindControl("lblCount");

                average = Convert.ToInt32((Convert.ToDouble(lblCount.Text) / Convert.ToDouble(lblTarget.Text)) * 100);
                Label lblAverage = (Label)e.Row.Cells[0].FindControl("lblAverage");
                lblAverage.Text = Convert.ToString(average) + "%" ;

                CountPerDay = Convert.ToInt32((Convert.ToDouble(lblCount.Text) / Convert.ToDouble(NoOfDaysInMonth)));
                Label lblCurrentAchievement = (Label)e.Row.Cells[0].FindControl("lblCurrentAchievement");
                lblCurrentAchievement.Text=Convert.ToString(CountPerDay);

                CountToBe = Convert.ToInt32(Convert.ToDouble(lblTarget.Text) / Convert.ToDouble(NoOfDaysInMonth));

                Label lblAchieved=(Label)e.Row.Cells[0].FindControl("lblAchieved");
                lblAchieved.Text = Convert.ToString(CountToBe);
                    
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {                
                average=0;
                int noofrows = 0;
                foreach (GridViewRow  row in grdview1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        Label lblTarget=(Label)row.FindControl("lblTarget");
                        if(lblTarget.Text.Trim().Length>0)
                        {
                            TargetTotal += int.Parse(lblTarget.Text.Trim());
                        }

                        Label lblCount = (Label)row.FindControl("lblCount");
                        if (lblCount.Text.Trim().Length > 0)
                        {
                            TotalCount += int.Parse(lblCount.Text.Trim());
                        }                        

                        Label lblAverage = (Label)row.FindControl("lblAverage");
                        if (lblAverage.Text.Trim().Length > 0)
                            average += int.Parse(lblAverage.Text.TrimEnd('%'));

                        Label lblCurrentAchievement = (Label)row.FindControl("lblCurrentAchievement");
                        if (lblCurrentAchievement.Text.Trim().Length > 0)
                        {
                            AverageAchievement +=int.Parse(lblCurrentAchievement.Text.Trim());
                        }

                        Label lblAchieved = (Label)row.FindControl("lblAchieved");
                        if(lblAchieved.Text.Trim().Length>0)
                        {
                            AverageAchievementToBe += int.Parse(lblAchieved.Text.Trim());
                        }


                        noofrows++;
                    }
                }
                average = average / noofrows;
                AverageAchievement = TotalCount / NoOfDaysInMonth;
                AverageAchievementToBe = TargetTotal / NoOfDaysInMonth;

                e.Row.Cells[1].Text = "Total: " + TargetTotal.ToString();

                e.Row.Cells[2].Text = "Total: " + TotalCount.ToString();

                e.Row.Cells[3].Text = "Avg.: " + average.ToString();

                e.Row.Cells[4].Text = "Avg.: " + AverageAchievement.ToString();

                e.Row.Cells[5].Text = "Avg.: " + AverageAchievementToBe.ToString();
                //e.Row.Cells[3].Text = "Total: " + _totalUnitsOnOrder.ToString();
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}