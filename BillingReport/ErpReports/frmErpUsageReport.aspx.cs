using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class ErpReports_frmErpUsageReport : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();

    DataSet ds = new DataSet();

    #endregion

    #region User Defined Methods

    private void LoadReport(int _userid,string _fromDate, string _todate)
    {
        ds = objSalesSummaryReport.ERPUsageReport(_userid,_fromDate, _todate);
        Session["ds"] = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {

            grdview1.DataSource = ds.Tables[0];
            grdview1.DataBind();

        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSerach_Click(object sender, EventArgs e)
    {
        //lblMonth.Text = "Sales Report of " + ddlMonth.SelectedItem.Text.ToString() + "-" + ddlYear.SelectedItem.Text.ToString() + "";
        this.LoadReport(0,txtFromDate.Text, txtToDate.Text);
    }
    protected void lnkemployee_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label UserID = (Label)gv.FindControl("lbluserid");



    }
    protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdview1.PageIndex = e.NewPageIndex;

        grdview1.DataSource = Session["ds"];
        grdview1.DataBind();


        //this.btnSerach_Click(sender, e);
    }
}