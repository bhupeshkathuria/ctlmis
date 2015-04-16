using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_frmTravelInsurance : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();

    DataSet dsTravel = new DataSet();

    double TotalSum = 0.00;

    #endregion

    #region User Defined Methods

    private void LoadData(string _year, string _fromMonth, string _toMonth)
    {
        DataSet dsData = new DataSet();

        dsData = objSalesSummaryReport.GetReportTravelInsurance(_year, _fromMonth, _toMonth);
        if (dsData.Tables.Count > 0)
        {
            if (dsData.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = string.Empty;
                grdTravel.DataSource = dsData.Tables[0];
                grdTravel.DataBind();
            }
            else
            {
                lblMsg.Text = "No Record found";
                grdTravel.DataSource = dsData.Tables[0];
                grdTravel.DataBind();
            }
        }
        else
        {
            lblMsg.Text = "No Record found";
            grdTravel.DataSource = dsData.Tables[0];
            grdTravel.DataBind();
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
            ddlFromMonth.DataSource = sortedMonth;
            ddlFromMonth.DataValueField = "Key";
            ddlFromMonth.DataTextField = "value";
            ddlFromMonth.DataBind();

            ddlToMonth.DataSource = sortedMonth;
            ddlToMonth.DataValueField = "Key";
            ddlToMonth.DataTextField = "value";
            ddlToMonth.DataBind();
        }
    }
    protected void btnSerach_Click(object sender, EventArgs e)
    {
        string _year = string.Empty;

        string _fromMonth = string.Empty;

        string _toMonth = string.Empty;        


        _year = ddlYear.SelectedValue.ToString();

        _fromMonth = ddlFromMonth.SelectedValue.ToString();

        _toMonth = ddlToMonth.SelectedValue.ToString();


        this.LoadData(_year, _fromMonth, _toMonth);
    }
    protected void grdTravel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblAmount = (Label)e.Row.FindControl("lblAmount");

            TotalSum += Convert.ToDouble(lblAmount.Text);

            lblTotalAmount.Text = TotalSum.ToString();
        }
    }
}