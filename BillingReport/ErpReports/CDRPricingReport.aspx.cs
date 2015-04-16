using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class ErpReports_CDRPricingReport : System.Web.UI.Page
{
    int userId = 0;
    double unitPrice = 0;
    double incomingRate = 0;
    double outgoingRate = 0;
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
            RadGridCDrPricingDetails.Visible = false;
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
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        RadGridCDrPricingDetails.DataSourceID = "OdsBindCDrPricing";
        RadGridCDrPricingDetails.DataBind();
        RadGridCDrPricingDetails.Visible = true;
    }
    protected void OdsBindCDrPricing_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["CountryId"] = Convert.ToInt32(drpCountry.SelectedValue);
        e.InputParameters["Year"] = Convert.ToInt32(drpYear.SelectedValue);
        e.InputParameters["Month"] = Convert.ToInt32(drpMonth.SelectedValue);
    }
    protected void RadGridCDrPricingDetails_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item.GetType() == typeof(GridDataItem))
        {
            Label lblUnitValue = (Label)e.Item.FindControl("lblUnits");
            Label lblincomingRateValue = (Label)e.Item.FindControl("lblIncommingRate");
            Label lblOutgoingRateVale = (Label)e.Item.FindControl("lblOutGoingRate");

            unitPrice = unitPrice + Convert.ToDouble(lblUnitValue.Text);
            lblUnitValue.Text = string.Format("{0:n2}", Convert.ToDouble(lblUnitValue.Text));

            incomingRate = incomingRate + Convert.ToDouble(lblincomingRateValue.Text);
            lblincomingRateValue.Text = string.Format("{0:n2}", Convert.ToDouble(lblincomingRateValue.Text));

            outgoingRate = outgoingRate + Convert.ToDouble(lblOutgoingRateVale.Text);
            lblOutgoingRateVale.Text = string.Format("{0:n2}", Convert.ToDouble(lblOutgoingRateVale.Text));
        }
        else if (e.Item.GetType() == typeof(GridFooterItem))
        {
            Label lblfooterUnitValue = (Label)e.Item.FindControl("lblFooterUnit");
            Label lblfooterincomingRateValue = (Label)e.Item.FindControl("lblFooterIncomingRate");
            Label lblfooterOutgoingRateVale = (Label)e.Item.FindControl("lblFooterOutGoingrate");

            lblfooterUnitValue.Text = string.Format("{0:n2}", unitPrice);
            lblfooterincomingRateValue.Text = string.Format("{0:n2}", incomingRate);
            lblfooterOutgoingRateVale.Text = string.Format("{0:n2}", outgoingRate);
        }
        else if (e.Item is GridCommandItem)
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
    }
}