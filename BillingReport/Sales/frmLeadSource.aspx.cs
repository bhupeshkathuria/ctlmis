using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;

public partial class Sales_frmLeadSource : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();

    static DateTime Todate = new DateTime();//year - 1, month, 1
    static DateTime FromDate = new DateTime();//year - 1, month - 2, 1

    static string cfromdate = string.Empty;
    static string ctodate = string.Empty;

    #endregion

    #region User Defined Methods

    private void LoadReport(string Year, string Month,int _searchby)
    {
        ds = objSalesSummaryReport.GetLeadSourceReport(Year, Month, _searchby);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvleadsource.DataSource = ds.Tables[0];
            gvleadsource.DataBind();
            Cache["dataload"] = ds.Tables[0];
        }
        else
        {
            gvleadsource.DataSource = null;
            gvleadsource.DataBind();
        }
    }
   
    public void GetRange(int year, int month)
    {
        Todate = new DateTime();
        FromDate = new DateTime();
        int _noofdays = 0;
        if (month.ToString() == "1" || month.ToString() == "3" || month.ToString() == "5" || month.ToString() == "7" || month.ToString() == "8" || month.ToString() == "10" || month.ToString() == "12")
        {
            _noofdays = 31;
        }
        else if (month.ToString() == "2")
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            {
                _noofdays = 29;
            }
            else
            {
             _noofdays = 28;
            }

        }
        else
        {
            _noofdays = 30;
        }
        if (month <= 3)
        {
            if (month != 1)
            {
                

                FromDate = new DateTime(year - 1, 12 + (month-1-2), 1);

                if ((month - 1).ToString() == "1" || (month - 1).ToString() == "3" || (month - 1).ToString() == "5" || (month - 1).ToString() == "7" || (month - 1).ToString() == "8" || (month - 1).ToString() == "10" || (month - 1).ToString() == "12")
                {
                    _noofdays = 31;
                }
                else if ((month - 1).ToString() == "2")
                {
                    if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                    {
                        _noofdays = 29;
                    }
                    else
                    {
                        _noofdays = 28;
                    }

                }
                Todate = new DateTime(year, (month-1), _noofdays);
            }
            else
            {
                FromDate = new DateTime(year - 1, 12 + (month - 3), 1);
                Todate = new DateTime(year - 1, 12, _noofdays);
            }
        }
        else
        {
            FromDate = new DateTime(year, ((month - 1) - 2), 1);
            if ((month - 1).ToString() == "1" || (month - 1).ToString() == "3" || (month - 1).ToString() == "5" || (month - 1).ToString() == "7" || (month - 1).ToString() == "8" || (month - 1).ToString() == "10" || (month - 1).ToString() == "12")
            {
                _noofdays = 31;
            }
            else if ((month - 1).ToString() == "2")
            {
                if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                {
                    _noofdays = 28;
                }
                else
                {
                    _noofdays = 29;
                }

            }
            else
            {
                _noofdays = 30;
            }
            Todate = new DateTime(year , (month-1), _noofdays);            
        }

        cfromdate = FromDate.ToString("yyyy-MM-dd");
        ctodate = Todate.ToString("yyyy-MM-dd");
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            ddlYear.Items.Clear();
            for (int i = DateTime.Now.Year; i >= 2008; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
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
            int month = DateTime.Now.Month;
            for (int i = 0; i < ddlMonth.Items.Count; i++)
            {
                if (int.Parse(ddlMonth.Items[i].Value) == month)
                {
                    ddlMonth.SelectedIndex = i;
                }
            }
             if (rbLS.Checked)
            {
                searchby = 1;
                this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), searchby);
                rbAll.Checked = false;
            }
            gvleadsource.Caption = "<span style='color:Black;font-weight: bold'> Source Lead Sales</span>";
           
        }
    }
    int searchby = 0;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetRange(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
         searchby = 0;
        if (rbLS.Checked)
        {
            searchby = 1;
        }
        else if(rbAll.Checked)
        {
            searchby = 0;
        }
        this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(),searchby);
    }
    protected void gvleadsource_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (rbLS.Checked)
            {
                //lbl.Visible = true;
                e.Row.Cells[5].Visible = true;
            }
            else if (rbAll.Checked)
            {
                // lbl.Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (rbLS.Checked)
            {
                //lbl.Visible = true;
                e.Row.Cells[5].Visible = true;
            }
            else if (rbAll.Checked)
            {
                // lbl.Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }
        if (gvleadsource.Rows.Count > 0)
        {
            //Label lbl = (Label)e.Row.FindControl("lblaffAmt");


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int totalProspects = 0;
            int totalFollowUp = 0;
            int totalSalesConfirm = 0;
            int totalPricing = 0;
            int totalCostSold = 0;
            int totalallSold = 0;
            int totalallamt = 0;

            if (rbLS.Checked)
            {
                //lbl.Visible = true;
                e.Row.Cells[5].Visible = true;
            }
            else if (rbAll.Checked)
            {
                // lbl.Visible = false;
                e.Row.Cells[5].Visible = false;
            }
            foreach (GridViewRow gr in gvleadsource.Rows)
            {
                Label lbl1 = (Label)gr.FindControl("lblProspects");
                totalProspects += int.Parse(lbl1.Text);

                Label lbl2 = (Label)gr.FindControl("lblFollowUp");
                totalFollowUp += int.Parse(lbl2.Text);

                Label lbl3 = (Label)gr.FindControl("lblSalesConfirm");
                totalSalesConfirm += int.Parse(lbl3.Text);
                Label lbl4 = (Label)gr.FindControl("lblPricing");
                totalPricing += int.Parse(lbl4.Text);
                Label lbl5 = (Label)gr.FindControl("lblCostSold");
                totalCostSold += int.Parse(lbl5.Text);
                Label lbl6 = (Label)gr.FindControl("lblSumall");
                totalallSold += int.Parse(lbl6.Text);
                Label lbl7 = (Label)gr.FindControl("lblAmount");
                totalallamt += int.Parse(lbl7.Text);

            }
            Label lblfoter1 = (Label)e.Row.FindControl("lblTotalProspects");
            lblfoter1.Text = totalProspects.ToString();
            Label lblfoter2 = (Label)e.Row.FindControl("lblTotalFollowUp");
            lblfoter2.Text = totalFollowUp.ToString();
            Label lblfoter3 = (Label)e.Row.FindControl("lblTotalSalesConfirm");
            lblfoter3.Text = totalSalesConfirm.ToString();
            Label lblfoter4 = (Label)e.Row.FindControl("lblTotalPricing");
            lblfoter4.Text = totalPricing.ToString();
            Label lblfoter5 = (Label)e.Row.FindControl("lblTotalCostSold");
            lblfoter5.Text = totalCostSold.ToString();
            Label lblfoter6 = (Label)e.Row.FindControl("lblTotalSumall");
            lblfoter6.Text = totalallSold.ToString();
            Label lblfoter7 = (Label)e.Row.FindControl("lblTotalAmt");
            lblfoter7.Text = totalallamt.ToString();

        }
    }
   
    protected void rbLS_CheckedChanged(object sender, EventArgs e)
    {
       
        if (rbLS.Checked)
        {
            searchby = 1;
            rbAll.Checked = false;
            this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), searchby);
           
        }
        else
        {
           
            rbAll.Checked = true;
            searchby = 0;
            this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), searchby);
        }
    }
    protected void rbAll_CheckedChanged(object sender, EventArgs e)
    {
        
        if (rbAll.Checked)
        {
           
            rbLS.Checked = false;
            searchby = 0;
         
            this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), searchby);
        }
        else
        {
            rbLS.Checked = true;
            searchby = 1;

            this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), searchby);
        }
    }
    }
