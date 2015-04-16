using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CreditControl_DayWiseReportIframe : System.Web.UI.Page
{
    Clay.Sale.Bll.CreditDetail objcredit = new Clay.Sale.Bll.CreditDetail();
    string _modename = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["mode"] != null)
        {
            _modename = Request.QueryString["mode"].ToString();
        }
        lblbname.Text = Request.QueryString["branchname"].ToString() + "(" + Request.QueryString["mode"].ToString() + ")";
        lblbname.Text = HttpUtility.UrlDecode(lblbname.Text);
      //  lbldate.Text = Request.QueryString["branchname"].ToString();
       // lblmode.Text = 
        getdaywiserpt();
    }
    void getdaywiserpt()
    {
        string branchid = Request.QueryString["branchid"].ToString();
        string _month = Request.QueryString["month"].ToString();
        string _year = Request.QueryString["year"].ToString();

        string _modeid = string.Empty;
        switch (_modename)
        {
            case "Cheque":
             _modeid = "1";
             break;
            case "Cash":
                 _modeid = "2";
             break;
            case "CreditCard":
             _modeid = "3";
             break;
            case "Bank":
             _modeid = "4";
             break;
            case "Online":
             _modeid = "6";
             break;
        }
        DataSet ds_all = new DataSet();
        ds_all = objcredit.Getdaywise_rpt(_month, _year, branchid, _modeid);
        if (ds_all.Tables["day"].Rows.Count > 0)
        {
            grddaywiserpt.DataSource = ds_all;
            grddaywiserpt.DataBind();
        }
    }
    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter str = new StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
        grddaywiserpt.AllowPaging = false;
        //BindVehicleGrid();
        grddaywiserpt.RenderControl(HtmlTextWriter);
        Response.Write(str.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void grddaywiserpt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow valu = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
        
        int RowIndex = valu.RowIndex;
        Label lblbranchid = (Label)grddaywiserpt.Rows[RowIndex].FindControl("lblbranchid");
        Label lmode = (Label)grddaywiserpt.Rows[RowIndex].FindControl("lblmode");
        LinkButton lnkdate = (LinkButton)grddaywiserpt.Rows[RowIndex].FindControl("lnkvew");
        DateTime dt = Convert.ToDateTime(lnkdate.CommandArgument);
        string fromdate = dt.Year + "-" + dt.Month + "-" + dt.Day;
       
        gettransaction(fromdate, lmode.Text, Convert.ToInt32(lblbranchid.Text));

        //string _month = Convert.ToString(dt.Month);
        //string _year = Convert.ToString(dt.Year);
       /// getdatewise_amount(_month, _year);
    }
    void gettransaction(string fromdate, string mode, int branchid)
    {
        DataSet ds_trans = new DataSet();
        ds_trans = objcredit.Gettransaction_detail(fromdate, fromdate, branchid, mode);
        if (ds_trans.Tables["transaction"].Rows.Count > 0)
        {
            grddetail.DataSource = ds_trans;
            grddetail.DataBind();
        }
    }
    decimal _totalamtbymode = 0;
    protected void grddaywiserpt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            _totalamtbymode += Convert.ToDecimal(lblamt.Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotamt = (Label)e.Row.FindControl("lbltotamt");
            lbltotamt.Text = _totalamtbymode.ToString();
        }
    }
    decimal _totalamttrans = 0;
    protected void grddetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblamount = (Label)e.Row.FindControl("lblamount");
            _totalamttrans += Convert.ToDecimal(lblamount.Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotamt = (Label)e.Row.FindControl("lbltotamt");
            lbltotamt.Text = _totalamttrans.ToString();
        }
    }
}