using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_frmSalesReportMonthly : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();

    #endregion

    #region User Defined Methods

    private void LoadReport(string fromDate, string toDate)
    {
        ds = objSalesSummaryReport.GetMonthlyReport(fromDate, toDate);
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
        this.LoadReport(Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd"));
    }

    protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdview1.PageIndex = e.NewPageIndex;
            this.LoadReport(Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd"));
        }
        catch (Exception ex)
        {

        }
    }
}