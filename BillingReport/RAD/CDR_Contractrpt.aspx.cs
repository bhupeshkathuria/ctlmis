using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Clay.RAD;
using System.IO;
using System.Drawing;
using Clay.Common.Bll;
public partial class CDR_Contractrpt : System.Web.UI.Page
{
    #region namespce
    DataSet dsReport = new DataSet();
    invoicecontract obj = new invoicecontract();
    Clay.Common.Bll.Country objcnt;
    provider objProvider;
    DataSet dsCountry = new DataSet();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fixHeader(); ", true);
            //if (!(Convert.ToInt32(Session["UserID"]) > 0))
            //{
            //    Response.Redirect("Login.aspx", false);
            //}

            if (!IsPostBack)
            {

                loadCountryDDL();
                loadYear();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadProviderByCountry(Convert.ToInt32(ddlcountry.SelectedValue));
            grdcontract.DataSource = null;
            grdcontract.DataBind();
            lblmsg.Text = string.Empty;
        }
        catch
        {
        }
    }

    private void loadCountryDDL()
    {
        objcnt = new Country();
        objcnt.CountryId = 0;
        dsCountry = objcnt.GetCountry();

        ddlcountry.DataSource = dsCountry;
        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "countryid";
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, "Select Country");
    }

    private void LoadProviderByCountry(int countryid)
    {
        ddlnetworks.DataSource = null;
        objProvider = new provider();
        objProvider.CountryId = countryid;
        DataSet dsPRovider = new DataSet();
        dsPRovider = objProvider.GetProviderByCountryId();
        ddlnetworks.DataSource = dsPRovider;
        ddlnetworks.DataTextField = "provider_name";
        ddlnetworks.DataValueField = "provider_id";
        ddlnetworks.DataBind();
        ddlnetworks.Items.Insert(0, "Select Provider");


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

        ddlyear.DataSource = dsYear.Tables[0];
        ddlyear.DataTextField = "yearVal";
        ddlyear.DataValueField = "yearTxt";
        ddlyear.DataBind();
        ddlyear.SelectedIndex = 0;



    }

    protected void BindCDRCcontract()
    {
        int countryID = 0;
        int providerid = 0;
        string billingMonthfrom = string.Empty;
        string billingMonthto = string.Empty;
        int month = 0;
        lblmsg.Text = string.Empty;
        if (ddlcountry.SelectedIndex != 0)
        {
            countryID = Convert.ToInt32(ddlcountry.SelectedValue);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select country');", true);
            return;
        }
        

        try
        {
            providerid = Convert.ToInt32(ddlnetworks.SelectedValue);
        }
        catch { }

        try
        {
            if ((Convert.ToInt32(ddlyear.SelectedValue) > 0) && (Convert.ToInt32(ddlmonth.SelectedValue) <= 0))
            {
                lblmsg.Text = "Please Select Month and Year Both";
                return;
            }

            if ((Convert.ToInt32(ddlyear.SelectedValue) <= 0) && (Convert.ToInt32(ddlmonth.SelectedValue) > 0))
            {
                lblmsg.Text = "Please Select Month and Year Both";
                return;
            }
            if ((Convert.ToInt32(ddlyear.SelectedValue) >= 0) && (Convert.ToInt32(ddlmonth.SelectedValue) > 0))
            {
                billingMonthfrom = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                billingMonthto = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                
            }
            else
            {
                //billingMonthfrom = DateTime.Now.Year.ToString() + "-04" + "-01";
                billingMonthfrom = "2013-04" + "-01";
               // billingMonthto = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                billingMonthto = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            }
        }
        catch { }

        try
        {
            if (ddltype.SelectedValue == "0")
            {
                dsReport = obj.CDRContractrpt(countryID, providerid, billingMonthfrom, billingMonthto);
            }
            else if (ddltype.SelectedValue == "1")
            {
                dsReport = obj.CDRContractrptRetail(countryID, providerid, billingMonthfrom, billingMonthto);
            }
            else if (ddltype.SelectedValue == "2")
            {
                dsReport = obj.CDRContractrptWhs(countryID, providerid, billingMonthfrom, billingMonthto);
            }
            hdfcountry.Value = countryID.ToString();
            hdfcountryname.Value = ddlcountry.SelectedItem.Text;
            hdfprovider.Value = providerid.ToString();
            hdfprovidername.Value = ddlnetworks.SelectedItem.Text;
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                grdcontract.DataSource = dsReport.Tables[0];
                grdcontract.DataBind();
                // pnlgrossary.Visible = false;

            }
            else
            {
                // pnlgrossary.Visible = false;
            }


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        grdcontract.DataSource = null;
        grdcontract.DataBind();
        BindCDRCcontract();
    }

    #region VArible
    int totlblbillable_units = 0;
    int totlblduration = 0;
    decimal totlblprovidercost = 0;
    decimal totlblcalltyperate = 0;
    decimal totlblcontractamount = 0;
    decimal totlblDifference = 0;
    int totlbl0billable_units = 0;
    #endregion
    protected void grdcontract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblbillable_units = (Label)e.Row.FindControl("lblbillable_units");
            Label lblduration = (Label)e.Row.FindControl("lblduration");
            Label lblprovidercost = (Label)e.Row.FindControl("lblprovidercost");
            Label lblcalltyperate = (Label)e.Row.FindControl("lblcalltyperate");
            Label lblcontractamount = (Label)e.Row.FindControl("lblcontractamount");
            Label lblDifference = (Label)e.Row.FindControl("lblDifference");
            Label lblobillableunits = (Label)e.Row.FindControl("lblobillableunits");
            #region Addtion 
            if (!string.IsNullOrEmpty(lblbillable_units.Text))
                totlblbillable_units += Convert.ToInt32(lblbillable_units.Text);
            else
                totlblbillable_units += 0;
            if (!string.IsNullOrEmpty(lblobillableunits.Text))
                totlbl0billable_units += Convert.ToInt32(lblobillableunits.Text);
            else
                totlbl0billable_units += 0;

            if (!string.IsNullOrEmpty(lblduration.Text))
                totlblduration += Convert.ToInt32(lblduration.Text);
            else
                totlblduration += 0;

            if (!string.IsNullOrEmpty(lblprovidercost.Text))
                totlblprovidercost += Convert.ToDecimal(lblprovidercost.Text);
            else
                totlblprovidercost += 0;

            if (!string.IsNullOrEmpty(lblcalltyperate.Text))
                totlblcalltyperate += Convert.ToDecimal(lblcalltyperate.Text);
            else
                totlblcalltyperate += 0;

            if (!string.IsNullOrEmpty(lblcontractamount.Text))
                totlblcontractamount += Convert.ToDecimal(lblcontractamount.Text);
            else
                totlblcontractamount += 0;

            if (!string.IsNullOrEmpty(lblDifference.Text))
                totlblDifference += Convert.ToDecimal(lblDifference.Text);
            else
                totlblDifference += 0;

            if (!string.IsNullOrEmpty(lblDifference.Text))
            {
                if (Convert.ToDecimal(lblDifference.Text) > 0)
                {
                    e.Row.Cells[8].BackColor = Color.Green;
                    e.Row.Cells[8].ForeColor = Color.White;
                }
                else
                {
                    e.Row.Cells[8].BackColor = Color.Red;
                    e.Row.Cells[8].ForeColor = Color.White;
                }
            }
            #endregion


        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotunits = (Label)e.Row.FindControl("lbltotunits");
            Label lbltotduration = (Label)e.Row.FindControl("lbltotduration");
            Label lbltotprovidercost = (Label)e.Row.FindControl("lbltotprovidercost");
            Label lbltotcalltyperate = (Label)e.Row.FindControl("lbltotcalltyperate");
            Label lbltotcontractamount = (Label)e.Row.FindControl("lbltotcontractamount");
            Label lbltotDifference = (Label)e.Row.FindControl("lbltotDifference");
            Label lbltotobillableunits = (Label)e.Row.FindControl("lbltotobillableunits");

            lbltotunits.Text = totlblbillable_units.ToString();
            lbltotduration.Text = totlblduration.ToString();
            lbltotprovidercost.Text = totlblprovidercost.ToString();
            lbltotcalltyperate.Text = totlblcalltyperate.ToString();
            lbltotcontractamount.Text = totlblcontractamount.ToString();
            lbltotDifference.Text = totlblDifference.ToString();
            lbltotobillableunits.Text = totlbl0billable_units.ToString();
        }
    }
    public string SortExpression
    {

        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
        set { ViewState["sortExpression"] = value; }

    }

    private string GetSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }
    protected void grdcontract_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string from = string.Empty;
        // string to = string.Empty;
        // DateTime abc;
        int index = Convert.ToInt32(e.CommandArgument.ToString());
        Label lblcalltypeid = (Label)grdcontract.Rows[index].FindControl("lblcalltypeid");
        LinkButton lnkcalltypename = (LinkButton)grdcontract.Rows[index].FindControl("lnkcalltypename");
        Label from1 = (Label)grdcontract.Rows[index].FindControl("lblcdrdate");
        from = from1.Text;
        string[] month = from.Split('-');
        int iMonthNo = Convert.ToDateTime("01-" + month[0] + "-" + month[1]).Month;
        from = month[1] + "-" + iMonthNo + "-01";
        // Label to = from.Text.ToString();// (Label)grdcontract.Rows[index].FindControl("lblcdrdate");
        string calltypeid = e.CommandArgument.ToString();
        string url = "CDR_contract_sub.aspx?calltypeid=" + lblcalltypeid.Text + "&fromdate=" + from + "&todate=" + from + "&countryid=" + hdfcountry.Value + "&providerid=" + hdfprovider.Value + "&countryname=" + hdfcountryname.Value + "&providername=" + hdfprovidername.Value + "&calltypename=" + lnkcalltypename.Text;
        //  Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=600,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=no,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
        lnkcalltypename.OnClientClick = "javascript:window.open('" + url + "');";
    }

    static int mylevel = 0;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    protected void grdcontract_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        }
            
    }
}