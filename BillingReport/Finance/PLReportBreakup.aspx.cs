using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Finance_PLReportBreakup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblAccount.Text = Request.QueryString["ledgername"];
            lblFromDT.Text = Request.QueryString["fromdt"];
            lblToDate.Text = Request.QueryString["todt"];
            BindGrid();
        }
    }
    private void BindGrid()
    {
        try
        {
            string ledgerid = Request.QueryString["ledgerid"];
            string fromdt = Request.QueryString["fromdt"];
            string todt = Request.QueryString["todt"];
            FinanceDataAccess objData = new FinanceDataAccess();
            DataTable dt = objData.GetVoucherBreakup(ledgerid, fromdt, todt);
            if (dt.Rows.Count > 0)
            {
                grdVoucher.DataSource = dt;
                grdVoucher.DataBind();
            }
            else
            {
                grdVoucher.DataSource = null;
                grdVoucher.DataBind();
            }
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
}