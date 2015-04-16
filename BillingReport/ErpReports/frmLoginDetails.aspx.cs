using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using dal;

public partial class ErpReports_frmLoginDetails : System.Web.UI.Page
{
    #region User Defined Fields

    DataSet dsLoginDetails = new DataSet();

    SalesSummaryReport objSale = new SalesSummaryReport();

    string total = string.Empty;

    #endregion

    #region User Defined Method

    private void BindLoginDetails(int _userid,string _fromdate,string _todate)
    {
        dsLoginDetails = objSale.ERPUsageReport(_userid, _fromdate, _todate);
        if (dsLoginDetails.Tables[0].Rows.Count > 0)
        {
            grdLoginDetails.DataSource = dsLoginDetails.Tables[0];
            grdLoginDetails.DataBind();
        }
    }


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int _userid = 0;

            DateTime _fromdate = new DateTime();

            DateTime _todate = new DateTime();

            _userid = Convert.ToInt32(Request.QueryString["userId"]);

            _fromdate = Convert.ToDateTime(Request.QueryString["from"]);

            _todate = Convert.ToDateTime(Request.QueryString["to"]);

            BindLoginDetails(_userid, _fromdate.ToString("yyyy-MM-dd"), _todate.ToString("yyyy-MM-dd"));

        }
    }
    protected void grdLoginDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            e.Row.Cells[0].Text = Convert.ToString(sno);

            //Label lblTotalTime = (Label)e.Row.FindControl("lblTotalTime");
            //total += Convert.ToDecimal(lblTotalTime.Text);
        }
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    Label lbltotal = (Label)e.Row.FindControl("lblgrndtotal");
        //    lbltotal.Text = total.ToString();
        //}
    }
}