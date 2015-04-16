using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class ErpReports_HigestInvoiceReport : System.Web.UI.Page
{
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
        if (!Page.IsPostBack)
        {
            loadYear();
            BindCountry();
            RadGridHigestInvoiceDetails.Visible = false;
        }
    }


    private void loadYear()
    {
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
        drYear["yearVal"] = "Select Year";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }
        drpYear.Items.Clear();
        drpYear.DataSource = dsYear.Tables[0];
        drpYear.DataTextField = "yearVal";
        drpYear.DataValueField = "yearTxt";
        drpYear.DataBind();
        drpYear.SelectedIndex = 0;
    }

    private void BindCountry()
    {
        drpCountry.Items.Clear();
        drpCountry.DataSourceID = "OdsBindCountry";
        drpCountry.DataTextField = "countryname";
        drpCountry.DataValueField = "countryid";
        drpCountry.DataBind();
        drpCountry.Items.Insert(0, "Select Country");
        drpCountry.SelectedIndex = 0;

    }
    
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCountry.SelectedValue == "0" || drpCountry.SelectedValue == "Select Country")
        {
        }
        else
        {
            drpCallType.Items.Clear();
            drpCallType.DataSourceID = "OdsBindcallType";
            drpCallType.DataTextField = "calltypename";
            drpCallType.DataValueField = "calltypeid";
            drpCallType.DataBind();
            drpCallType.Items.Insert(0, "Select Call Type");
            drpCallType.SelectedIndex = 0;
        }
    }

    protected void OdsBindcallType_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["CountryId"] =Convert.ToInt32(drpCountry.SelectedValue);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        RadGridHigestInvoiceDetails.DataSourceID = "OdsBindHigestInvoice";
        RadGridHigestInvoiceDetails.DataBind();
        RadGridHigestInvoiceDetails.Visible = true;
    }
    protected void OdsBindHigestInvoice_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["CountryId"] =Convert.ToInt32(drpCountry.SelectedValue);
        e.InputParameters["Year"] = Convert.ToInt32(drpYear.SelectedValue);
        e.InputParameters["Month"] = Convert.ToInt32(drpMonth.SelectedValue);
        if (drpCallType.SelectedIndex == 0)
        {
            e.InputParameters["CallTypeId"] = 0;
        }
        else
        {
            e.InputParameters["CallTypeId"] = Convert.ToInt32(drpCallType.SelectedValue);
        }
        if (drpShowRocords.SelectedValue == "All" || drpShowRocords.SelectedValue == "0")
        {
            e.InputParameters["limitvalue"] = 0;
        }
        else
        {
            e.InputParameters["limitvalue"] =Convert.ToInt32(drpShowRocords.SelectedValue);
        }
    }
    protected void RadGridHigestInvoiceDetails_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            Label lblCmdCountryName = (Label)e.Item.FindControl("lblCountryName");
            Label lblCmdYearMonthName = (Label)e.Item.FindControl("lblYearMonthname");

            if(drpCountry.SelectedIndex==0)
            {
                lblCmdCountryName.Visible=false;
                lblCmdYearMonthName.Visible=false;
            }
            else
            {
                if (drpYear.SelectedIndex == 0 || drpMonth.SelectedIndex == 0)
                {
                    lblCmdCountryName.Visible=false;
                    lblCmdYearMonthName.Visible=false;
                }
                else
                {
                    lblCmdCountryName.Text = drpCountry.SelectedItem.Text;
                    lblCmdYearMonthName.Text = drpMonth.SelectedItem.Text + " " + "(" + drpYear.SelectedItem.Text + ")";
                }
            }
        }
        else if (e.Item is GridDataItem)
        {

        }
    }
}