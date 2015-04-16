using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Finance_NetworkWisePurchase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindNetwork();
            AddingFromYear();
            AddingToYear();            
        }
    }
    private void BindNetwork()
    {
        try
        {
            FinanceDataAccess objData = new FinanceDataAccess();
            ddlNetwork.Items.Clear();
            DataTable dt = new DataTable();
            dt = objData.GetNetworkList();
            ddlNetwork.DataSource = dt;
            ddlNetwork.DataValueField = "NetworkID";
            ddlNetwork.DataTextField = "NetworkName";
            ddlNetwork.DataBind();
            ddlNetwork.Items.Insert(0, new ListItem("----Select----", "0"));
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    private void AddingFromYear()
    {
        try
        {
            int i = 2010;
            int curryear = DateTime.Now.Year;
            int diff = curryear - i;
            ddlfromyear.Items.Add(new ListItem("----Select----", "0"));
            for (int x = 0; x <= diff; x++)
            {
                int newyear=i+x;
                ddlfromyear.Items.Add(new ListItem(newyear.ToString(), newyear.ToString()));
            }
        }
        catch (Exception ex) 
        {
            
            throw;
        }
    }
    private void AddingToYear()
    {
        try
        {
            int i = 2010;
            int curryear = DateTime.Now.Year;
            int diff = curryear - i;
            ddlToYear.Items.Add(new ListItem("----Select----", "0"));
            for (int x = 0; x <= diff; x++)
            {
                int newyear = i + x;
                ddlToYear.Items.Add(new ListItem(newyear.ToString(), newyear.ToString()));
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void BindGrid()
    {
        try
        {
            string fromdate = "01/01/" + ddlfromyear.SelectedValue.ToString();
            string todate = "12/31/" + ddlToYear.SelectedValue.ToString();
            string networkid = ddlNetwork.SelectedValue.ToString();
            string reptype = ddlType.SelectedValue.ToString();
            FinanceDataAccess objData = new FinanceDataAccess();
            DataTable dt = objData.GetNetworkPurchase(fromdate, todate, networkid,reptype);
            if (dt.Rows.Count > 0)
            {
                grdPurchase.DataSource = dt;
                grdPurchase.DataBind();
            }
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }
    protected void cmdSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}