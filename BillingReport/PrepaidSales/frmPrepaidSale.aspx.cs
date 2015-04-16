using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrepaidSales_frmPrepaidSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCountry();
            pnlMain.Visible = false;
        }
    }
    private void LoadCountry()
    {
        ddlYear.Items.Clear();
        for (int i = DateTime.Now.Year; i >= 2008; i--)
        {
            ddlYear.Items.Add(i.ToString());
        }

    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {

        LoadReport();
        pnlBranch.Visible = false;
        GridView2.Visible = false;
        pnlMain.Visible = true;

    }

    private void LoadReport()
    {

        int Year = int.Parse(ddlYear.Text);
        short busTypeId = short.Parse(ddlBusType.SelectedValue);

        GridView1.DataSource = DataAccess.GetYearBusTypeSale(Year, busTypeId);
        GridView1.DataBind();

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Contains("Sales"))
        {
            int Year = int.Parse(ddlYear.Text);
            short busTypeId = short.Parse(ddlBusType.SelectedValue);
            int monthId = Convert.ToInt32(e.CommandArgument);

            GridView2.DataSource = DataAccess.GetBranchWiseMonthlySale(Year, monthId, busTypeId);
            GridView2.DataBind();
            pnlBranch.GroupingText = "Branch Wise Sales";
            GridView2.Visible = true;
            GridView3.Visible = false;
            pnlBranch.Visible = true;
            System.Threading.Thread.Sleep(500);
        }
        else if (e.CommandName.Contains("Recharge"))
        {
            int Year = int.Parse(ddlYear.Text);
            short busTypeId = short.Parse(ddlBusType.SelectedValue);
            int monthId = Convert.ToInt32(e.CommandArgument);

            GridView3.DataSource = DataAccess.GetRechageSourceWise(Year, monthId, busTypeId);
            GridView3.DataBind();
            pnlBranch.GroupingText = "Recharge Source Wise";
            GridView3.Visible = true;
            GridView2.Visible = false;
            pnlBranch.Visible = true;
            System.Threading.Thread.Sleep(500);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int noOfSale = 0;
            double activationAmount = 0;
            double rechargeAmount = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                LinkButton lbSales = (LinkButton)gr.FindControl("lbSales");
                LinkButton lbRecharge = (LinkButton)gr.FindControl("lbRecharge");
                noOfSale += Convert.ToInt32(lbSales.Text);
                activationAmount += Convert.ToDouble(gr.Cells[2].Text);
                rechargeAmount += Convert.ToDouble(lbRecharge.Text);
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = noOfSale.ToString();
            e.Row.Cells[2].Text = activationAmount.ToString("0.00");
            e.Row.Cells[3].Text = rechargeAmount.ToString("0.00");
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int noOfSale = 0;
            double activationAmount = 0;
            double rechargeAmount = 0;
            foreach (GridViewRow gr in GridView2.Rows)
            {
                noOfSale += Convert.ToInt32(gr.Cells[3].Text);
                //activationAmount += Convert.ToDouble(gr.Cells[4].Text);
                activationAmount += Convert.ToDouble(gr.Cells[4].Text.Replace("&nbsp;", "0"));
                rechargeAmount += Convert.ToDouble(gr.Cells[5].Text.Replace("&nbsp;", "0"));
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[3].Text = noOfSale.ToString();
            e.Row.Cells[4].Text = activationAmount.ToString("0.00");
            e.Row.Cells[5].Text = rechargeAmount.ToString("0.00");
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            double manualAmount = 0;
            double OnlineAmount = 0;
            foreach (GridViewRow gr in GridView3.Rows)
            {
                manualAmount += Convert.ToDouble(gr.Cells[3].Text);
                OnlineAmount += Convert.ToDouble(gr.Cells[4].Text);
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[3].Text = manualAmount.ToString("0.00");
            e.Row.Cells[4].Text = OnlineAmount.ToString("0.00");
        }
    }
}