using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_frmSalesReportDateWise : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();

    Clay.Sale.Bll.SalesSummaryReport onj = new SalesSummaryReport();
    DataSet ds = new DataSet();

    #endregion

    #region User Defined Methods
    int RunningTotal = 0;
    protected void rptr1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                int val = Convert.ToInt32(dr["ZoneCount"]);
                RunningTotal += val;

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl = (Label)e.Item.FindControl("lblZoneTotal");
                //lbl.Text = RunningTotal.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    int RunningTotal_6 = 0;
    protected void rptr6_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                int val = Convert.ToInt32(dr["count1"]);
                RunningTotal_6 += val;

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl = (Label)e.Item.FindControl("lblTotal");
                lbl.Text = RunningTotal_6.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSerach_Click(object sender, EventArgs e)
    {
        string _searchBy = "ByOrderDate";

        _searchBy = Convert.ToString(ddlSearch.Text.Trim());
        if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
        {
            this.LoadReport(txtFromDate.Text, txtToDate.Text, _searchBy);
            lblMsg.Text = "";
        }
        else
        {
            lblMsg.Text = "Record not found!!!";
        }
    }
    private void LoadReport(string fromdate, string todate, string _searchBy)
    {
        ds = objSalesSummaryReport.GetSummaryReportDateWise(fromdate, todate,_searchBy);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptr1.DataSource = ds.Tables[0];
            rptr1.DataBind();
            rptr6.DataSource = ds.Tables[1];
            rptr6.DataBind();
            rptr7.DataSource = ds.Tables[2];
            rptr7.DataBind();
        }
    }
    int RunningTotal1 = 0;
    protected void rptr7_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                int val = Convert.ToInt32(dr["count1"]);
                string abc = dr["zone"].ToString();
                if (abc.Contains("Total"))
                {
                    RunningTotal1 += val;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl = (Label)e.Item.FindControl("lblzoneTotal");
                lbl.Text = RunningTotal1.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}