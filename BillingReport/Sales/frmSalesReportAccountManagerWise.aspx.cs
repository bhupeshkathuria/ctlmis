using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using System.Drawing;
using System.Text;
public partial class Sales_frmSalesReportAccountManagerWise : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();

    DataSet dsSaleCategory = new DataSet();

    DataSet dsEmployee = new DataSet();

    static string assignedEmplId = string.Empty;

    StringBuilder strEmplId = new StringBuilder();

    int NoOfDaysInMonth = 0;
    int NoOfTotalDays = 0;
    int TotalSales = 0;
    #endregion

    #region User Defined Methods

    private void LoadReport(string Year, string Month,string searchby,string employeeid)
    {

        if (ddlYear.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0)
        {
            lblMsg.Text = string.Empty;
            NoOfDaysInMonth = System.DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
            ds = objSalesSummaryReport.GetReportAccountManagerWise(Year, Month, searchby, employeeid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdview1.DataSource = ds.Tables[0];
                grdview1.DataBind();
            }
            else
            {
              lblMsg.Text = "No Record found";
              grdview1.DataSource = ds.Tables[0];
              grdview1.DataBind();
            }
        }
        else
        {
            lblMsg.Text = "No Record Found!!!";
            grdview1.DataSource = ds.Tables[0];
            grdview1.DataBind();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
             
            SortedList<string, string> sortedYear = new SortedList<string, string>();
            sortedYear.Add("", "Select");
            sortedYear.Add("2009", "2009");
            sortedYear.Add("2010", "2010");
            sortedYear.Add("2011", "2011");
            sortedYear.Add("2012", "2012");
            sortedYear.Add("2013", "2013");
            sortedYear.Add("2014", "2014");
            sortedYear.Add("2015", "2015");
            sortedYear.Add("2016", "2016");
            sortedYear.Add("2017", "2017");
            sortedYear.Add("2018", "2018");
            sortedYear.Add("2019", "2019");
            sortedYear.Add("2020", "2020");
            ddlYear.DataSource = sortedYear;
            ddlYear.DataValueField = "Key";
            ddlYear.DataTextField = "value";
            ddlYear.DataBind();

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
            sortedMonth.Add("", "Select");
            sortedMonth.Add("01", "January");
            sortedMonth.Add("02", "Febraury");
            sortedMonth.Add("03", "March");
            sortedMonth.Add("04", "April");
            sortedMonth.Add("05", "May");
            sortedMonth.Add("06", "June");
            sortedMonth.Add("07", "July");
            sortedMonth.Add("08", "August");
            sortedMonth.Add("09", "September");
            sortedMonth.Add("10", "October");
            sortedMonth.Add("11", "Novemver");
            sortedMonth.Add("12", "December");
            ddlMonth.DataSource = sortedMonth;
            ddlMonth.DataValueField = "Key";
            ddlMonth.DataTextField = "value";
            ddlMonth.DataBind();


            dsSaleCategory = objSalesSummaryReport.GetSaleCategory(0);

            if (dsSaleCategory.Tables[0].Rows.Count > 0)
            {
                ddlSaleCategory.DataSource = dsSaleCategory.Tables[0];
                ddlSaleCategory.DataValueField = "salescategoryid";
                ddlSaleCategory.DataTextField = "salecategoryname";
                ddlSaleCategory.DataBind();
                ddlSaleCategory.Items.Insert(0, "Select");
            }

            this.ddlSaleCategory_SelectedIndexChanged(sender, e);
        }
    }

    protected void btnSerach_Click(object sender, EventArgs e)
    {

        //this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), ddlSearch.Text.Trim(), assignedEmplId);

        string _accountManagerId = string.Empty;

        string _year = string.Empty;

        string _fromMonth = string.Empty;

        string _toMonth = string.Empty;

        if (ddlEmployee.SelectedIndex > 0)
        {
            _accountManagerId = ddlEmployee.SelectedValue.ToString();
        }
        else
        {
            _accountManagerId = assignedEmplId;
        }


        _year = ddlYear.SelectedValue.ToString();

        _fromMonth = ddlMonth.SelectedValue.ToString();


        this.LoadReport(_year, _fromMonth, ddlSearch.Text.Trim(), _accountManagerId);
      
    }

    protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdview1.PageIndex = e.NewPageIndex;
            this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), ddlSearch.Text.Trim(), assignedEmplId);
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void grdview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            string abc=string.Empty;
                    abc=DataBinder.Eval(e.Row.DataItem, "branchname").ToString();
            if(abc.Contains("Total"))
            {
                e.Row.Cells[2].Font.Bold=true;// = Color.Black;
                e.Row.Cells[3].Font.Bold = true;

            TotalSales += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = "Grand Total";
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].Text = TotalSales.ToString();
            e.Row.Cells[3].Font.Bold = true;

        }
    }

    protected void ddlSaleCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSaleCategory.SelectedIndex == 0)
        {
            dsEmployee = objSalesSummaryReport.GetAccountManagerSaleCategory(0);

            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = dsEmployee.Tables[0];
                ddlEmployee.DataValueField = "employeeid";
                ddlEmployee.DataTextField = "employeename";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select");

                foreach (DataRow DR in dsEmployee.Tables[0].Rows)
                {
                    assignedEmplId = DR["employeeid"].ToString();

                    strEmplId.Append(assignedEmplId);
                    strEmplId.Append(",");
                }
                assignedEmplId = strEmplId.ToString();
                assignedEmplId = assignedEmplId.TrimEnd(',');
            }
        }
        else
        {
            dsEmployee = objSalesSummaryReport.GetAccountManagerSaleCategory(Convert.ToInt32(ddlSaleCategory.SelectedValue));

            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = dsEmployee.Tables[0];
                ddlEmployee.DataValueField = "employeeid";
                ddlEmployee.DataTextField = "employeename";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select");

                foreach (DataRow DR in dsEmployee.Tables[0].Rows)
                {
                    assignedEmplId = DR["employeeid"].ToString();

                    strEmplId.Append(assignedEmplId);
                    strEmplId.Append(",");
                }
                assignedEmplId = strEmplId.ToString();
                assignedEmplId = assignedEmplId.TrimEnd(',');
            }
        }
    }
}