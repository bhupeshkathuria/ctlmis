using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using dal;

public partial class ErpReports_frmPODetails : System.Web.UI.Page
{
    #region User Defined Fields

    DataSet dsPODetails = new DataSet();

    SalesSummaryReport objSale = new SalesSummaryReport();

    #endregion

    #region User Defined Method

    private void BindPODetails(int _poid)
    {
        dsPODetails = objSale.GetPurchaseOrderLine(_poid, 0);
        if (dsPODetails.Tables[0].Rows.Count > 0)
        {
            grdPODetails.DataSource = dsPODetails.Tables[0];
            grdPODetails.DataBind();
        }
    }


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _poid = 0;

            _poid = Convert.ToInt32(Request.QueryString["Id"]);

            BindPODetails(_poid);
            
        }
    }
    decimal total = 0;
    protected void grdPODetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            e.Row.Cells[0].Text = Convert.ToString(sno);

             Label lblTotalPrice=(Label)e.Row.FindControl("lblTotalPrice");
            total+=Convert.ToDecimal(lblTotalPrice.Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotal = (Label)e.Row.FindControl("lblgrndtotal");
            lbltotal.Text = total.ToString();
        }

    }
}