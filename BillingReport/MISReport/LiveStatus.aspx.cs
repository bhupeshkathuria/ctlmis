using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;

public partial class MISReport_LiveStatus : System.Web.UI.Page
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

            DataRowView dr = (DataRowView)e.Item.DataItem;


            Label lblImport = (Label)cell.FindControl("lblImport");
            Label lblCharge = (Label)cell.FindControl("lblCharge");
            Label lblDiscount = (Label)cell.FindControl("lblDiscount");
            Label lblUnbilled = (Label)cell.FindControl("lblUnbilled");
            Label lblInvoice = (Label)cell.FindControl("lblInvoice");

            Image imgImport = (Image)cell.FindControl("imgImport");
            Image imgCharge = (Image)cell.FindControl("imgCharge");
            Image imgDiscount = (Image)cell.FindControl("imgDiscount");
            Image imgUnbilled = (Image)cell.FindControl("imgUnbilled");
            Image imgInvoice = (Image)cell.FindControl("imgInvoice");


            int invoiceStatus = 0;
            int countryID = 0;
            int providerID = 0;

            invoiceStatus = Convert.ToInt32(dr["cntInvoice"]);
            countryID = Convert.ToInt32(dr["countryid"]);
            providerID = Convert.ToInt32(dr["provider_id"]);



            if (invoiceStatus > 0)
            {
                // Data Invoiced ... Charged...Discount....Unbilled....Imported...
                imgImport.ImageUrl = "~/Images/correct.png";
                imgCharge.ImageUrl = "~/Images/correct.png";
                imgDiscount.ImageUrl = "~/Images/correct.png";
                imgUnbilled.ImageUrl = "~/Images/correct.png";
                imgInvoice.ImageUrl = "~/Images/correct.png";
            }
            else
            {
                imgInvoice.ImageUrl = "~/Images/cross.png";
                // If the invoice not done for the month then Check for Unbilled...
                int countryCode = GetCountryCode(Convert.ToInt32(countryID));

                int billingCycle = GetBillingCycle(countryID);

                if (countryCode > 0)
                {
                    int TotalUnbilled = 0;
                    TotalUnbilled = CheckUnbilledChargeDiscont(3, countryCode, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), providerID, billingCycle);

                    if (TotalUnbilled > 50)
                    {
                        imgImport.ImageUrl = "~/Images/correct.png";
                        imgCharge.ImageUrl = "~/Images/correct.png";
                        imgDiscount.ImageUrl = "~/Images/correct.png";
                        imgUnbilled.ImageUrl = "~/Images/correct.png";
                    }
                    else
                    {
                        imgUnbilled.ImageUrl = "~/Images/cross.png";
                        int TotalDiscount = 0;
                        TotalDiscount = CheckUnbilledChargeDiscont(2, countryCode, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), providerID, billingCycle);

                        if (TotalDiscount > 50)
                        {
                            imgImport.ImageUrl = "~/Images/correct.png";
                            imgCharge.ImageUrl = "~/Images/correct.png";
                            imgDiscount.ImageUrl = "~/Images/correct.png";
                        }
                        else
                        {
                            imgDiscount.ImageUrl = "~/Images/cross.png";
                            int TotalCharge = 0;
                            TotalCharge = CheckUnbilledChargeDiscont(1, countryCode, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), providerID, billingCycle);

                            if (TotalCharge > 50)
                            {
                                imgImport.ImageUrl = "~/Images/correct.png";
                                imgCharge.ImageUrl = "~/Images/correct.png";
                            }
                            else
                            {
                                imgCharge.ImageUrl = "~/Images/cross.png";
                                int TotalImport = 0;
                                TotalImport = CheckUnbilledChargeDiscont(0, countryCode, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), providerID, billingCycle);
                                if (TotalImport > 0)
                                {
                                    imgImport.ImageUrl = "~/Images/correct.png";
                                }
                                else
                                {
                                    imgImport.ImageUrl = "~/Images/cross.png";
                                }
                            }
                        }
                    }
                }
                else
                {
                    // If the Not Done Country Code....
                    imgImport.ImageUrl = "~/Images/cross.png";
                    imgCharge.ImageUrl = "~/Images/cross.png";
                    imgDiscount.ImageUrl = "~/Images/cross.png";
                    imgUnbilled.ImageUrl = "~/Images/cross.png";
                }
            }
        }
    }

    private int GetBillingCycle(int countryID)
    {
        int billingCycleStart = 0;
        string strQry = "select distinct billingcyclestart from cdrguide where country_id=" + countryID;
        DataSet dsGet = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQry);

        if (dsGet.Tables[0].Rows.Count > 0)
        {
            billingCycleStart = Convert.ToInt32(dsGet.Tables[0].Rows[0][0]);

        }
        return billingCycleStart;
    }


    //private int CheckImportCDROrNot(int countryID, int ProviderID, int month, int year)
    //{
    //    int count = 0;

    //    DateTime dtNew = Convert.ToDateTime(month + "-01-" + year);

    //    dtNew = dtNew.AddMonths(1);

    //    month = dtNew.Month;
    //    year = dtNew.Year;

    //    string strQry = "select count(*) from cdrtest c inner join cdrtestdetails cd on c.cdrtestid=cd.cdrtestid where " 
    //        +"  providerid in (select provider_id from ERPInvoicing.provider "
    //            + " where underproviderid=" + ProviderID + ")"
    //        + " and cd.status=1 and month(c.createddatetime)=" + month + " and year(c.createddatetime)=" + year + ";";
    //    DataSet dsCheck = objQuery.RunSelectQueryDBDirect("ERPInvoicing" , strQry);

    //    count = Convert.ToInt32(dsCheck.Tables[0].Rows[0][0]);

    //    return count;

    //}

    private int CheckUnbilledChargeDiscont(int status, int countryCode, int month, int year, int providerid, int billingCycle)
    {
        int count = 0;

        DateTime dtStart = Convert.ToDateTime(month + "-01-" + year);

        DateTime dtEnd = new DateTime();

        if (billingCycle == 1)
        {
            dtStart = dtStart.AddDays(2);
            dtEnd = dtStart.AddDays(23);
        }
        else
        {
            dtStart = dtStart.AddMonths(-1);
            dtStart = dtStart.AddDays(billingCycle);

            dtEnd = dtStart.AddDays(billingCycle - 1);
        }

        try
        {
            string strQry = "select count(*) from P" + countryCode + ".PT where status=" + status + " and calldate>='"
                + dtStart.ToString("yyyy-MM-dd") + "' and calldate<='" + dtEnd.ToString("yyyy-MM-dd") + "' and providerid in (select provider_id from ERPInvoicing.provider "
                + " where underproviderid=" + providerid + ")";

            DataSet dsQry = new DataSet();
            dsQry = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQry);

            count = Convert.ToInt32(dsQry.Tables[0].Rows[0][0]);


        }
        catch (Exception ex)
        { }

        return count;
    }

    private int GetCountryCode(int countryid)
    {
        Clay.Common.Bll.Country objCountry = new Clay.Common.Bll.Country();
        DataSet dsCountry = new DataSet();

        dsCountry = objCountry.GetCountryByCountryId(0, countryid);

        if (dsCountry.Tables[0].Rows.Count > 0)
        {
            return Convert.ToInt32(dsCountry.Tables[0].Rows[0]["countrydicode"]);
        }
        else
        {
            return 0;
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
        int month = 0;
        int year = 0;

        if (ddlMonth.SelectedIndex <= 0)
        {
            lblmsg.Text = "Please Select Month";
            return;
        }

        if (ddlYear.SelectedIndex <= 0)
        {
            lblmsg.Text = "Please Select Year";
            return;
        }

        //DateTime dtDateTime = Convert.ToDateTime(ddlMonth.SelectedValue + "-01-" + ddlYear.SelectedValue);

        //dtDateTime = dtDateTime.AddMonths(-1);


        month = Convert.ToInt32(ddlMonth.SelectedValue);
        year = Convert.ToInt32(ddlYear.SelectedValue);

        lblmsg.Text = "";

        string strQry = "select c.countryid,p.provider_id, c.countryname,p.provider_name, (select count(*) from invoicing where countryid=p.country_id and "
            + " month(invoicingmonth)=" + month + " and year(invoicingmonth)=" + year + ") as cntInvoice from provider p "
            + " inner join clayerp.country c on p.country_id=c.countryid where p.underproviderid=0 and p.isdeleted=0";

        dsInvoice = objQuery.RunSelectQueryDBDirect("ERPInvoicing", strQry);

        RadGrid1.Visible = true;
        RadGrid1.DataSource = dsInvoice.Tables[0];
        RadGrid1.DataBind();
        Session["tripdata"] = dsInvoice;

    }
}