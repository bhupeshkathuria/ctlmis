using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Threading;

public partial class CreditControl_frmTarVsAch : System.Web.UI.Page
{
    DataSet dsEmployee = new DataSet();
    Clay.Sale.Bll.CreditDetail creobj = new Clay.Sale.Bll.CreditDetail();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadEmployeeForReassign();
            BindYear();
            ddlFromMonth.SelectedValue = "01";           
            ddlToMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            ddlFromMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
        }
    }
    private void BindYear()
    {
        int Year = System.DateTime.Now.Year;
        for(int i=2010;i<=Year;i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.SelectedValue = "2014";
    }
    private void LoadEmployeeForReassign()
    {
        dsEmployee = creobj.GetEmployeeByEmployeeId(0, 12, 0, "");
        if (dsEmployee.Tables[0].Rows.Count > 0)
        {
            ddlExecutive.Items.Clear();
            ddlExecutive.DataSource = dsEmployee.Tables[0];
            ddlExecutive.DataTextField = "employeename";
            ddlExecutive.DataValueField = "employeeid";
            ddlExecutive.DataBind();
            //  ddlSIMNo.Items.Add(new ListItem("Select", "0"));
            ddlExecutive.Items.Insert(0, new ListItem("All", "0"));           
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlFromMonth.SelectedValue == ddlToMonth.SelectedValue)
        {
            DataSet dsDetails = new DataSet();
            string employeeid = string.Empty;
            if (ddlExecutive.SelectedIndex > 0)
            {
                employeeid = ddlExecutive.SelectedValue;
            }
            dsDetails = creobj.GetCcTargetVsAchivementReport(employeeid, Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlFromMonth.SelectedValue), Convert.ToInt32(ddlToMonth.SelectedValue));
            if (dsDetails.Tables[0].Rows.Count > 0)
            {
                 dv = dsDetails.Tables[0].DefaultView;
                 Session["dsDetails"] = dsDetails.Tables[0];

                foreach (DataColumn drcheck1 in dsDetails.Tables[0].Columns)
                {
                    if (SortExpression.ToString().Contains(drcheck1.ToString()))
                    {
                        dv.Sort = SortExpression;
                    }
                }

                GrdTarAchDetails.DataSource = dv;
                GrdTarAchDetails.DataBind();
                tdexporttoexcel.Visible = true;
            }
            else
            {
                GrdTarAchDetails.DataSource = null;
                GrdTarAchDetails.DataBind();
                tdexporttoexcel.Visible = false;
            }
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select the same from and to month!');", true);
        return;
    }

    decimal totaltarget = 0;
    decimal totalachivment = 0;
    decimal target0to30 = 0;
    decimal target31to90 = 0;
    decimal target90_above = 0;
    decimal achiv0to30 = 0;
    decimal achiv31to90 = 0;
    decimal achiv90above = 0;

    protected void GrdTarAchDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GrdTarAchDetails.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            GrdTarAchDetails.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            GrdTarAchDetails.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            GrdTarAchDetails.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            GrdTarAchDetails.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            GrdTarAchDetails.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            GrdTarAchDetails.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Left;
            GrdTarAchDetails.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            GrdTarAchDetails.HeaderRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;  

            string lblemployee = e.Row.Cells[0].Text;
            string lbltottarget = e.Row.Cells[1].Text;
            string lbltotachiv = e.Row.Cells[2].Text;

            string target30 = e.Row.Cells[3].Text;
            string target31_90 = e.Row.Cells[4].Text;
            string target90above = e.Row.Cells[5].Text;

            string achievement30 = e.Row.Cells[6].Text;
            string achievement30_90 = e.Row.Cells[7].Text;
            string achievement90above = e.Row.Cells[8].Text;

            /*  Label lbltottarget = (Label)e.Row.FindControl("lbltottarget");
              Label lbltotachiv = (Label)e.Row.FindControl("lbltotalAchi");

              Label target30 = (Label)e.Row.FindControl("target30");
              Label target31_90 = (Label)e.Row.FindControl("target31_90");
              Label target90above = (Label)e.Row.FindControl("target90above");

              Label achievement30 = (Label)e.Row.FindControl("achievement30");           
              Label achievement30_90 = (Label)e.Row.FindControl("achievement30_90");
              Label achievement90above = (Label)e.Row.FindControl("achievement90above");*/

              totaltarget += Convert.ToDecimal(lbltottarget);
              totalachivment += Convert.ToDecimal(lbltotachiv);
              target0to30 += Convert.ToDecimal(target30);
              target31to90 += Convert.ToDecimal(target31_90);
              target90_above += Convert.ToDecimal(target90above);
              achiv0to30 += Convert.ToDecimal(achievement30);
              achiv31to90 += Convert.ToDecimal(achievement30_90);
              achiv90above += Convert.ToDecimal(achievement90above);


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Grand Total";
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;  // this column[5] for branch id but we show total in this col
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;

            e.Row.Cells[1].Text = totaltarget.ToString();
            e.Row.Cells[2].Text = totalachivment.ToString();
            e.Row.Cells[3].Text = target0to30.ToString();
            e.Row.Cells[4].Text = target31to90.ToString();
            e.Row.Cells[5].Text = target90_above.ToString();
            e.Row.Cells[6].Text = achiv0to30.ToString();
            e.Row.Cells[7].Text = achiv31to90.ToString();
            e.Row.Cells[8].Text = achiv90above.ToString(); // 
        }

        if(e.Row.RowType==DataControlRowType.Header)
        {
            LinkButton Lnkemployee = e.Row.Cells[0].Controls[0] as LinkButton;
            LinkButton LnkHeaderText_colcheque = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
           // col1 = LnkHeaderText_colcheque.Text;
            LinkButton LnkHeaderText_colcash = e.Row.Cells[2].Controls[0] as LinkButton;
            //col2 = LnkHeaderText_colcash.Text;
            LinkButton LnkHeaderText_colcc = e.Row.Cells[3].Controls[0] as LinkButton;
            //col3 = LnkHeaderText_colcc.Text;
            LinkButton LnkHeaderText_colbank = e.Row.Cells[4].Controls[0] as LinkButton;
            //col4 = LnkHeaderText_colbank.Text;
            LinkButton LnkHeaderText_total = e.Row.Cells[5].Controls[0] as LinkButton;
            LinkButton lnkachiv0to30 = e.Row.Cells[6].Controls[0] as LinkButton;
            LinkButton lnkachiv31to90 = e.Row.Cells[7].Controls[0] as LinkButton;
              LinkButton lnkachiv90above = e.Row.Cells[8].Controls[0] as LinkButton;
           // col5 = LnkHeaderText_total.Text;

           
    }
    }
    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel.ExportToExcelGridView(GrdTarAchDetails);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public string SortExpression
    {      
        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
            set { ViewState["sortExpression"] = value; }
    }
    protected void GrdTarAchDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
        }
       // Session["dsDetails"] = dv;
        DataTable dt = (DataTable)Session["dsDetails"];
        dv = dt.DefaultView;
        foreach (DataColumn drcheck in dt.Columns)
        {
            if (SortExpression.ToString().Contains(drcheck.ToString()))
            {
                dv.Sort = SortExpression;
            }
        }
        GrdTarAchDetails.DataSource = null;
        GrdTarAchDetails.DataBind();
        GrdTarAchDetails.DataSource = dv;
        GrdTarAchDetails.DataBind();
        tdexporttoexcel.Visible = true;

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
    protected void GrdTarAchDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}