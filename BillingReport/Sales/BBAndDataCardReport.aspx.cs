using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_BBAndDataCardReport : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();

    #endregion

    #region User Defined Methods

    private void LoadReport(string year,string month)
    {
        ds = objSalesSummaryReport.GetBBAndDataCardReport(year, month);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.LoadReport(ddlMonth.SelectedValue.ToString(),ddlMonth.SelectedValue.ToString());
    }
}