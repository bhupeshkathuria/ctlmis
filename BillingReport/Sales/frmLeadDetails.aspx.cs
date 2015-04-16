using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sales_frmLeadDetails : System.Web.UI.Page
{
    Clay.Sale.Bll.SalesSummaryReport objlead = new Clay.Sale.Bll.SalesSummaryReport();
    System.Data.DataTable dt = new System.Data.DataTable();
    string _month = string.Empty;
    string _leadsource = string.Empty;
    string _fromyear = string.Empty;
    string _toyear = string.Empty;
    int SaleConfirmed = 0;
    int CardSold = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (!Page.IsPostBack)
            {
                _month = Convert.ToString(Request.QueryString["month"]);
                _leadsource = Convert.ToString(Request.QueryString["leadsource"]);
                _fromyear = Convert.ToString(Request.QueryString["fromyear"]);
                _toyear = Convert.ToString(Request.QueryString["toyear"]);
                this.LoadReport(_month, _leadsource, _fromyear, _toyear);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private void LoadReport(string _month, string _leadsource, string _fromyear, string _toyear)
    {  

        DataSet ds = new DataSet();

        ds = objlead.GetLeadDetails(_month, _leadsource, _fromyear, _toyear);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grdlead.DataSource = ds.Tables[0];
            grdlead.DataBind();
        }
    }

    protected void grdlead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //string abc = string.Empty;
            //abc = DataBinder.Eval(e.Row.DataItem, "LeadSource").ToString();
            //if (abc.Contains("CardSold"))
            //{
            //    e.Row.Cells[2].Font.Bold = true;// = Color.Black;
            //    e.Row.Cells[3].Font.Bold = true;

            //    TotalSales += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CardSold"));
            //}
            SaleConfirmed += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SaleConfirmed"));
            CardSold += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CardSold"));
            
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Grand Total";
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].Text = SaleConfirmed.ToString();
            e.Row.Cells[3].Font.Bold = true;

            e.Row.Cells[4].Text = CardSold.ToString();
            e.Row.Cells[4].Font.Bold = true;

        }
    }
}