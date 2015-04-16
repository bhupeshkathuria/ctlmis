using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clay.Sale.Bll;
using System.Data;

public partial class Sales_frmSalesReportStatusWise : System.Web.UI.Page
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
        ds = objSalesSummaryReport.GetSalesorderStatusReport(Year, Month);
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvSalesStatus.DataSource = ds.Tables[0];
            gdvSalesStatus.DataBind();
        }
        else
        {
            gdvSalesStatus.DataSource = null;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
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
            //gdvSalesStatus.DataSource = null;
            //SortedList<string, string> sortedYear = new SortedList<string, string>();
            //sortedYear.Add("", "Select");
            //sortedYear.Add("2009", "2009");
            //sortedYear.Add("2010", "2010");
            //sortedYear.Add("2011", "2011");
            //sortedYear.Add("2012", "2012");
            //sortedYear.Add("2013", "2013");
            //sortedYear.Add("2014", "2014");
            //sortedYear.Add("2015", "2015");
            //sortedYear.Add("2016", "2016");
            //sortedYear.Add("2017", "2017");
            //sortedYear.Add("2018", "2018");
            //sortedYear.Add("2019", "2019");
            //sortedYear.Add("2020", "2020");
            //ddlYear.DataSource = sortedYear;
            //ddlYear.DataValueField = "Key";
            //ddlYear.DataTextField = "value";
            //ddlYear.DataBind();

            //SortedList<string, string> sortedMonth = new SortedList<string, string>();
            //sortedMonth.Add("", "Select");
            //sortedMonth.Add("01", "January");
            //sortedMonth.Add("02", "Febraury");
            //sortedMonth.Add("03", "March");
            //sortedMonth.Add("04", "April");
            //sortedMonth.Add("05", "May");
            //sortedMonth.Add("06", "June");
            //sortedMonth.Add("07", "July");
            //sortedMonth.Add("08", "August");
            //sortedMonth.Add("09", "September");
            //sortedMonth.Add("10", "October");
            //sortedMonth.Add("11", "November");
            //sortedMonth.Add("12", "December");
            //ddlMonth.DataSource = sortedMonth;
            //ddlMonth.DataValueField = "Key";
            //ddlMonth.DataTextField = "value";
            //ddlMonth.DataBind();
        }
    }
    protected void btnSerach_Click(object sender, EventArgs e)
    {
        Session["year"] = ddlYear.SelectedValue.ToString();
        Session["month"] = ddlMonth.SelectedValue.ToString();
          this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString());
       
    }
    protected void gdvSalesStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string from = string.Empty;
        //string to = string.Empty;
        //// DateTime abc;
        //GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        ////int index = Convert.ToInt32(e.CommandArgument.ToString());
        //Label lblfrommmonth = (Label)gvRow.FindControl("lblbillmonth22");
        //from = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");
        //to = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");

        //if (e.CommandName == "groupname")
        //{

        //    string groupid = e.CommandArgument.ToString();
        //    string url = "CDR_invoicerpt_sub1.aspx?groupid=" + groupid + "&fromdate=" + from + "&todate=" + to;
        //    Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=300,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=no,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
        //}
    }
}