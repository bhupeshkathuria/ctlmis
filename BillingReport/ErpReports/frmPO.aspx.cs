using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Clay.Sale.Bll;

public partial class ErpReports_frmPO : System.Web.UI.Page
{
    #region User Defined Fields

    DataSet dsPO = new DataSet();

    SalesSummaryReport objSales = new SalesSummaryReport();

    #endregion

    #region User Defined Methods

    private void BindPO(int SupplierId,string MonthName,string YearName)
    {
        dsPO = objSales.GetPurchaseOrder(SupplierId, MonthName, YearName);

        if (dsPO.Tables[0].Rows.Count > 0)
        {
            dgPO.DataSource = dsPO.Tables[0];
            dgPO.DataBind();
        }
    }


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _supplierid = 0;
            string _MonthName=string.Empty;
            string _YearName = string.Empty;

            _supplierid = Convert.ToInt32(Request.QueryString["id"]);
            _MonthName = Convert.ToString(Request.QueryString["monthname"]);
            _YearName = Convert.ToString(Request.QueryString["yearname"]);
            BindPO(_supplierid, _MonthName,_YearName);
        }
    }
    protected void dgPO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            e.Row.Cells[0].Text = Convert.ToString(sno);
        }
    }
}