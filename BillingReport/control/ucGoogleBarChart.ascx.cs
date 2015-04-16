using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ucGoogleBarChart : System.Web.UI.UserControl
{
    #region Public Properties 

    // Local property to hold the GridView ID to chart
    public string ChartGridViewID
    {
        get { return this.lblChartGridViewID.Text; }
        set { this.lblChartGridViewID.Text = value; }
    }

    // Local property to hold the chart color (if defined)
    public string ChartColor
    {
        get { return this.lblChartColor.Text; }
        set { this.lblChartColor.Text = value; }
    }

    // Local property to hold the chart color (if defined)
    public string ChartSize
    {
        get { return this.lblChartSize.Text; }
        set { this.lblChartSize.Text = value; }
    }

    // Local property to hold the chart backgound fill & color
    public string ChartBGFill
    {
        get { return this.lblChartBGFill.Text; }
        set { this.lblChartBGFill.Text = value; }
    }

    // Local property to hold the chart bar spacing & size
    public string ChartBarSizeSpacing
    {
        get { return this.lblChartBarSizeSpacing.Text; }
        set { this.lblChartBarSizeSpacing.Text = value; }
    }

    // Local property to hold the chart orientation value
    public bool ChartOrientationVertical
    {
        get
        {
            if (this.lblChartOrientationVertical.Text != string.Empty)
                return bool.Parse(this.lblChartOrientationVertical.Text);
            else
                return false;
        }
        set { this.lblChartOrientationVertical.Text = value.ToString(); }
    }

    // Local property that determines whether or not the table data is 
    // displayed along with the Google Chart image
    public bool ChartShowData
    {
        get
        {
            if (this.lblChartShowData.Text != string.Empty)
                return bool.Parse(this.lblChartShowData.Text);
            else
                return true;
        }
        set { this.lblChartShowData.Text = value.ToString(); }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // The ChartGridViewID value is required, throw an exception if it hasn't been set
        if (this.ChartGridViewID == string.Empty)
            throw new Exception(this.ClientID + " ChartGridViewID value must be defined.");

        if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "SetClientId"))
        {
            // Register the script that executes and displays the Google Charts image
            if (!Page.ClientScript.IsClientScriptBlockRegistered("GoogleBarChartTableScript"))
                Page.ClientScript.RegisterStartupScript(this.GetType(), "GoogleBarChartTableScript", "<script type='text/javascript' src='JavaScript/Table2BarChart.js'></script>");

            // Call the function to build the chart
            Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID + "_BuildGoogleChart", "table2BarChart('" + this.ClientID + "');", true);
        }
    }
}
