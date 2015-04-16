using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
public partial class Sales_frmSalesReporBranchManagerWise : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();
    int NoOfDaysInMonth = 0;
    int NoOfTotalDays = 0;

    #endregion

    #region User Defined Methods

    private void LoadReport(int branch,string Year, string Month)
    {
        NoOfDaysInMonth = System.DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
        ds = objSalesSummaryReport.GetSalesorderStatusReportBranchmangerwise(branch,Year, Month);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gdvSalesbranch.DataSource = ds.Tables[0];
            gdvSalesbranch.DataBind();
        }
        else
        {
            gdvSalesbranch.DataSource = null;
            lblMsg.Visible = true;
            lblMsg.Text = "Record Not Found";
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string _year = Session["year"].ToString();
            string _month = Session["month"].ToString();
            int _branchid = Convert.ToInt32(Request.QueryString["branchid"]);
            this.LoadReport(_branchid, _year, _month);
        }
        catch (Exception)
        {
            throw;
        }
       
    }
}