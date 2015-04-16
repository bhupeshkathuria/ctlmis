using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;

public partial class User_CRM_MailMergeReport : System.Web.UI.Page
{
    string controlname = string.Empty;
    string controltype = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Button1.Enabled = false;
                loadCountryDDL();
                BindPackage();
                loadYear();
                BindRentalUsage();
                BindFinalNotFinal();
            }

            checkSession();
            checkpageright();
            BindCustType();
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message.ToString();
        }
    }

    private void BindFinalNotFinal()
    {
        DataSet dsFnl = new DataSet();
        dsFnl.Tables.Add("A");
        dsFnl.Tables[0].Columns.Add("id");
        dsFnl.Tables[0].Columns.Add("name");

        dsFnl.Tables[0].Rows.Add("2", "All");
        dsFnl.Tables[0].Rows.Add("1", "Final");
        dsFnl.Tables[0].Rows.Add("0", "Not Final");
        dsFnl.Tables[0].Rows.Add("3", "Cancel");

        ddlFinalNotFinal.DataSource = dsFnl;
        ddlFinalNotFinal.DataTextField = "name";
        ddlFinalNotFinal.DataValueField = "id";
        ddlFinalNotFinal.DataBind();
        ddlFinalNotFinal.SelectedValue = "2";
    }

    private void BindRentalUsage()
    {
        DataSet dsReUs = new DataSet();
        dsReUs.Tables.Add("A");
        dsReUs.Tables[0].Columns.Add("id");
        dsReUs.Tables[0].Columns.Add("name");

        dsReUs.Tables[0].Rows.Add("2", "All");
        dsReUs.Tables[0].Rows.Add("0", "Rental");
        dsReUs.Tables[0].Rows.Add("1", "Usage");
        dsReUs.Tables[0].Rows.Add("3", "Lost & Damage");

        ddlRentalUsage.DataSource = dsReUs;
        ddlRentalUsage.DataTextField = "name";
        ddlRentalUsage.DataValueField = "id";
        ddlRentalUsage.DataBind();
        ddlRentalUsage.SelectedValue = "2";
    }

    private void loadYear()
    {
        //Load Years
        DataRow drYear;
        DataSet dsYear = new DataSet();
        DataTable dtYears = new DataTable();
        dsYear.Tables.Add(dtYears);

        DataColumn SNoColumn1 = new DataColumn();
        SNoColumn1.ColumnName = "yearVal";
        dsYear.Tables[0].Columns.Add(SNoColumn1);

        DataColumn SNoColumn2 = new DataColumn();
        SNoColumn2.ColumnName = "yearTxt";
        dsYear.Tables[0].Columns.Add(SNoColumn2);

        drYear = dsYear.Tables[0].NewRow();
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }
        ddlYear.DataSource = dsYear.Tables[0];
        ddlYear.DataTextField = "yearVal";
        ddlYear.DataValueField = "yearTxt";
        ddlYear.DataBind();
        ddlYear.SelectedIndex = 0;
    }

    protected void BindCustType()
    {
        try
        {
            string str = "select * from customertype;";
            Clay.Invoice.Bll.Query objQry = new Clay.Invoice.Bll.Query();
            DataSet ds = new DataSet();

            ds = objQry.RunSelectQueryDBDirect("ERPInvoicing", str);

            ddlCustomerType.DataSource = ds;
            ddlCustomerType.DataTextField = "customertype";
            ddlCustomerType.DataValueField = "customertypeid";
            ddlCustomerType.DataBind();


        }
        catch (Exception ex)
        {
        }
    }

    protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        try
        {
            //Session["RadGridPageNo"] = e.NewPageIndex;
            if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
            {
                Session["RadGridItemNo"] = ((RadGrid1.PageCount - 1) * RadGrid1.PageSize);
                SearchData();
            }
            else
            {
                SearchData();
                Session["RadGridItemNo"] = (e.NewPageIndex * RadGrid1.PageSize);
            }

        }
        catch (Exception ex)
        {

        }

    }

    private void loadCountryDDL()
    {
        Clay.Common.Bll.Country objCountry = new Clay.Common.Bll.Country();
        DataSet dsCountry = new DataSet();

        objCountry.CountryId = 0;
        dsCountry = objCountry.GetCountry();

        ddlCountry.DataSource = dsCountry;
        ddlCountry.DataTextField = "countryname";
        ddlCountry.DataValueField = "countryid";
        ddlCountry.DataBind();
        //ddlCountry.Items.Insert(0, "Select Country");
    }

    protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        SearchData();
    }

    protected void RadGrid1_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        SearchData();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                TableCell cell = item["Sno"];

                Label labelSNo = (Label)cell.FindControl("lblSno");
                labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);

                DataRowView dr = (DataRowView)e.Item.DataItem;

                int CustomerTypeID = 0;
                string invoiceno = "";
                int invoiceTypeID = 0;


                CustomerTypeID = Convert.ToInt32(dr["CustomerTypeID"]);
                invoiceno = dr["invoicenumber"].ToString();
                invoiceTypeID = Convert.ToInt32(dr["invoicetypeid"]);


                HyperLink HyperLink1 = (HyperLink)cell.FindControl("Hyperlink1");
                HyperLink hpPrint = (HyperLink)cell.FindControl("hpPrint");
                HyperLink hpUpdateDueDate = (HyperLink)cell.FindControl("HyperLink3");
                Label lblDueDate = (Label)cell.FindControl("lblDuedate");

                if (invoiceTypeID != 0)
                {
                    hpUpdateDueDate.NavigateUrl = "";
                    hpUpdateDueDate.Visible = false;
                    lblDueDate.Visible = true;
                }
                if (CustomerTypeID == 3)
                {
                    HyperLink1.NavigateUrl = "http://ecomm.claytelecom.com/Downloadworddoc.aspx?invoiceNo=" + invoiceno;
                    hpPrint.NavigateUrl = "http://ecomm.claytelecom.com/Downloadworddoc.aspx?invoiceNo=" + invoiceno;
                }

            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void btnAddField_Click(object sender, EventArgs e)
    {
        RadGrid1.CurrentPageIndex = 0;
        SearchData();
    }

    protected void SearchData()
    {
        try
        {
            // Code added for Search Invoice

            int countryID = 0;
            int packageid = 0;
            int rafNo = 0;
            string mobileno = "";
            string invoiceNo = "";
            int year = 0;
            int month = 0;
            int custID = 0;
            int freezestatus = 0;
            int rentalusageSt = 0;
            string fromdate = string.Empty;
            string todate = string.Empty;
            #region Get ContryID, Pakgid, CustID, RAfNo etc
            try
            {
                if (Convert.ToInt32(ddlCountry.SelectedValue) > 0)
                {
                    countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                }
            }
            catch (Exception ex){}

            try
            {
                if (Convert.ToInt32(ddlFinalNotFinal.SelectedValue) > 0)
                {
                    freezestatus = Convert.ToInt32(ddlFinalNotFinal.SelectedValue);
                }
            }
            catch (Exception ex) { freezestatus = 2; }
            try
            {
                if (Convert.ToInt32(ddlRentalUsage.SelectedValue) > 0)
                {
                    rentalusageSt = Convert.ToInt32(ddlRentalUsage.SelectedValue);
                }
            }
            catch (Exception ex) { rentalusageSt = 2; }

            try
            {
                if (Convert.ToInt32(ddlPackage.SelectedValue) > 0)
                {
                    packageid = Convert.ToInt32(ddlPackage.SelectedValue);
                }
            }
            catch (Exception ex){}
            try
            {
                if (Convert.ToInt32(ddlCustomerType.SelectedValue) > 0)
                {
                    custID = Convert.ToInt32(ddlCustomerType.SelectedValue);
                }
            }
            catch (Exception ex){}
            try
            {
                if (txtRafNo.Text.ToString().Length > 0)
                {
                    rafNo = Convert.ToInt32(txtRafNo.Text);
                }
            }
            catch (Exception ex)
            {
                lblErr.Visible = true;
                lblErr.Text = "Raf No should be numeric";
                return;
            }
            #endregion


            mobileno = txtMobil.Text.ToString();
            invoiceNo = txtInvoiceNo.Text.ToString();

            if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex > 0))
            {
                month = Convert.ToInt32(ddlMonth.SelectedValue);
                year = Convert.ToInt32(ddlYear.SelectedValue);
            }
            else if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex <= 0))
            {
                lblErr.Visible = true;
                lblErr.Text = "Please Select Year Also";
                return;
            }
            else if (ddlYear.SelectedIndex > 0)
            {
                year = Convert.ToInt32(ddlYear.SelectedValue);
            }

            try
            {
                fromdate = Convert.ToDateTime(rdpMinDate.SelectedDate).ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
            }
            try
            {
                todate = Convert.ToDateTime(rdpMaxDate.SelectedDate).ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
            }

            Clay.Invoice.Bll.Invoice obj = new Clay.Invoice.Bll.Invoice();
            DataSet dsSearch = new DataSet();
            dsSearch = obj.MailMergeInvoiceReport(year, month, countryID, invoiceNo, 
                mobileno, packageid, rafNo, custID,freezestatus,rentalusageSt,fromdate,todate);

            if (dsSearch.Tables[0].Rows.Count > 0)
            {
                RadGrid1.Visible = true;
                RadGrid1.DataSource = dsSearch.Tables[0];
                RadGrid1.DataBind();
                lblErr.Visible = false;
                Session["tripdata"] = dsSearch;
                Button1.Enabled = true;
            }
            else
            {
                //Button1.Visible = false;
                lblErr.Text = "No Data Found";
                lblErr.Visible = true;

                RadGrid1.Visible = false;
                Button1.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            lblErr.Visible = true;
            lblErr.Text = ex.Message;
        }
    }

    protected void BindPackage()
    {
        try
        {
            string str = "select * from clayerp.package where isdeleted=0";
            Clay.Invoice.Bll.Query obj = new Clay.Invoice.Bll.Query();
            DataSet ds = new DataSet();
            ds = obj.RunSelectQueryDBDirect("ERPInvoicing", str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPackage.DataSource = ds;
                ddlPackage.DataTextField = "packagename";
                ddlPackage.DataValueField = "packageid";
                ddlPackage.DataBind();

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
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

            string myFileName = "Mail_Merge_Report" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + myFileName);

            GVTrip.RenderControl(htmlWrite);
            //all that's left is to output the html
            Response.Write(stringWrite.ToString());
            Response.End();
            //btnExport.Enabled = true;
        }
        catch (Exception ex) { }
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
            Response.Redirect("../invoice/Error500.aspx");
            return;
        }
        else
        {
            getpageparentcontrol(Convert.ToInt32(dspageright.Tables[0].Rows[0]["pageid"]));
            checkControlRight(Convert.ToInt32(dspageright.Tables[0].Rows[0]["pageid"]));
        }
    }

    void getpageparentcontrol(int pageid)
    {
        Clay.Invoice.Bll.PageControl objPageControl = new Clay.Invoice.Bll.PageControl();
        DataSet dsParent = new DataSet();
        objPageControl.PageId = pageid;
        dsParent = objPageControl.GetPageParentControl();
        if (dsParent.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= dsParent.Tables[0].Rows.Count - 1; i++)
            {

                controltype = dsParent.Tables[0].Rows[i]["controltype"].ToString();
                controlname = dsParent.Tables[0].Rows[i]["controlname"].ToString();
                switch (controltype)
                {
                    case "Button":
                        Button controlis = (Button)form1.FindControl(dsParent.Tables[0].Rows[i]["controlname"].ToString());
                        controlis.Visible = false;
                        break;
                }
            }

        }

    }

    void checkControlRight(int pageid)
    {
        Clay.Invoice.Bll.PageControl objControlPage = new Clay.Invoice.Bll.PageControl();
        DataSet dscontrolright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        objControlPage.UserId = user;
        objControlPage.PageId = pageid;
        dscontrolright = objControlPage.CheckControlRight();
        if (dscontrolright.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= dscontrolright.Tables[0].Rows.Count - 1; i++)
            {

                //controlname + ".Visible=true";
                //string controlis = controlname;
                controltype = dscontrolright.Tables[0].Rows[i]["controltype"].ToString();


                controlname = dscontrolright.Tables[0].Rows[i]["controlname"].ToString();


                switch (controltype)
                {
                    case "Button":
                        Button controlis = (Button)form1.FindControl(dscontrolright.Tables[0].Rows[i]["controlname"].ToString());
                        controlis.Visible = true;
                        break;
                }

            }
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

}

