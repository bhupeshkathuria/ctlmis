using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

public partial class MISReport_InvoiceGenNoGenReport : System.Web.UI.Page
{
    Clay.Invoice.Bll.Invoice objInvoice = new Clay.Invoice.Bll.Invoice();

    Clay.Invoice.Bll.Query objQuery = new Clay.Invoice.Bll.Query();
    DataSet dsInvoice = new DataSet();
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userId = Convert.ToInt32(Session["UserId"]);
        }
        catch (Exception ex)
        {
            userId = 0;
        }

        if (userId == 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        else
        {
        }
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = objInvoice.Getcntmonths();
            ddlCountry.DataSource = ds.Tables[0];
            ddlCountry.DataTextField = "countryname";
            ddlCountry.DataValueField = "countryid";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, "--Select--");
            ddlCountry.SelectedIndex = -1;

        }
    }

    void checkpageright()
    {
        Clay.Invoice.Bll.Page objPage = new Clay.Invoice.Bll.Page();
        DataSet dspageright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        page = System.IO.Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);
        objPage.PageName = page;
        objPage.UserId = user;
        dspageright = objPage.CheckPageRight();

        if (dspageright.Tables[0].Rows.Count == 0)
        {
            Response.Redirect("../Default.aspx");
            return;
        }

    }

    protected string ConvertToMoneyFormat(string myval)
    {
        if (myval == "")
        {
            return "0.00";
        }
        else
        {
            return string.Format("{0:0.00}", Convert.ToDouble(myval));
        }
    }

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("../../Login.aspx", false);
            }
        }
        catch
        {
        }
    }

    protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        //Session["RadGridPageNo"] = e.NewPageIndex;
        if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
        {
            Session["RadGridItemNo"] = ((RadGrid1.PageCount - 1) * RadGrid1.PageSize);
            try
            {
                BindData();

            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            Session["RadGridItemNo"] = (e.NewPageIndex * RadGrid1.PageSize);
            try
            {
                BindData();
            }
            catch (Exception ex)
            {

            }
        }

    }

    protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {

        }
    }

    protected void RadGrid1_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception ex)
        {

        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            System.Web.UI.WebControls.TableCell cell = item["Sno"];

            Label labelSNo = (Label)cell.FindControl("lblSno");
            labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);
        }
    }

    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == RadGrid.FilterCommandName)
        {
            Pair filterPair = (Pair)e.CommandArgument;
            string filterPattern = ((System.Web.UI.WebControls.TextBox)(e.Item as GridFilteringItem)[filterPair.Second.ToString()].Controls[0]).Text;
            BindData();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        //create a string writer
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        DataSet ds = new DataSet();
        ds = (DataSet)Session["tripdata"];
        GVTrip.DataSource = (DataSet)Session["tripdata"];

        GVTrip.PageSize = 20000;
        GVTrip.DataBind();

        string myFileName = "Invoice" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + myFileName);

        GVTrip.RenderControl(htmlWrite);
        //all that's left is to output the html
        Response.Write(stringWrite.ToString());
        Response.End();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            RadGrid1.CurrentPageIndex = 0;
            BindData();
        }
        catch (Exception ex)
        {
        }
    }

    protected void BindData()
    {
        int countryid = 0;

        if (ddlCountry.SelectedIndex > 0)
        {
            countryid = Convert.ToInt32(ddlCountry.SelectedValue);
        }
        int month = 0;
        int year = 0;


        if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex > 0))
        {
            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);
        }
        else if ((ddlMonth.SelectedIndex <= 0) && (ddlYear.SelectedIndex <= 0))
        {
        }
        else if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex <= 0))
        {
            lblmsg.Text = "Please Select Year Also";
            return;
        }
        else if (ddlYear.SelectedIndex > 0)
        {
            year = Convert.ToInt32(ddlYear.SelectedValue);
        }

        lblmsg.Text = "";
        dsInvoice = objInvoice.GetInvoiceGenNotGenReport(year, month, countryid);
        //if (dsDepartment.Tables[0].Rows.Count > 0)
        //{
        RadGrid1.DataSource = dsInvoice.Tables[0];
        RadGrid1.DataBind();
        Session["tripdata"] = dsInvoice;

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}