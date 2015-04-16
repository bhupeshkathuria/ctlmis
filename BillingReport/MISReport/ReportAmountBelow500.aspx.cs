using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

public partial class MISReport_InvoiceGenNoGenReportNew : System.Web.UI.Page
{
    #region userDefinedFunction
    Clay.Invoice.Bll.Report obj = new Clay.Invoice.Bll.Report();
    Clay.Invoice.Bll.Invoice objInvSer = new Clay.Invoice.Bll.Invoice();

    private void loadYear()
    {
        //Load Years
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
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }
        ddlYear.DataSource = dsYear.Tables[0];
        ddlYear.DataTextField = "yearVal";
        ddlYear.DataValueField = "yearTxt";
        ddlYear.DataBind();
        ddlYear.SelectedIndex = 0;
    }

    private void search()
    {
        lblmsg.Text = "";
        int month = 0;
        int year = 0;
        //RadGrid1New.Visible = true;

        month = Convert.ToInt32(ddlMonth.SelectedValue);
        year = Convert.ToInt32(ddlYear.SelectedValue);

        if (year == 0)
        {
            lblmsg.Text = "Please Select Year";
            //RadGrid1New.Visible = false;
            //mainPnl.Visible = false;
            return;
        }


        DataTable dsRep = new DataTable();

        dsRep = obj.GetTotalCountLess500(year, month, 0, "<", 500);

        //if (dsRep.Tables[0].Rows.Count > 0)
        //{
        lblTotalRaf.Text = Convert.ToString(dsRep.Rows.Count);
        //}
        //else
        //{
        //    lblTotalRaf.Text = "0";
        //}

    }

    private void bindReportByCriteria()
    {
        try
        {
            string criteria = string.Empty;

            //if (ddlCriteria.SelectedIndex > 0)
            //{
            criteria = ddlCriteria.SelectedItem.Text;
            //}
            int month = 0;
            int year = 0;


            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);

            if (year == 0)
            {
                lblmsg.Text = "Please Select Year";
                //RadGrid1New.Visible = false;
                //mainPnl.Visible = false;
                return;
            }

            lblmsg.Text = "";
            RadGrid1.CurrentPageIndex = 0;
            DataTable dsInvoice = obj.GetTotalInvoiceLess500DiffWise(criteria, year, month, 0, "<", 500);
            RadGrid1.DataSource = dsInvoice;
            RadGrid1.DataBind();

        }
        catch (Exception x)
        {
            lblmsg.Text = x.Message;
        }
    }

    private void bindReportByCriteriaAllData()
    {
        //try
        //{
        //    int month = 0;
        //    int year = 0;

        //    month = Convert.ToInt32(ddlMonth.SelectedValue);
        //    year = Convert.ToInt32(ddlYear.SelectedValue);

        //    if (year == 0)
        //    {
        //        lblmsg.Text = "Please Select Year";
        //        return;
        //    }

        //    lblmsg.Text = "";
        //    RadGrid2.CurrentPageIndex = 0; 
        //    DataSet dsInvoice = objInvSer.GetHighLowValueInvoiceReport(year, month, 0,"<",500);
        //    RadGrid2.DataSource = dsInvoice.Tables[0];
        //    RadGrid2.DataBind();

        try
        {
            string criteria = string.Empty;

            //if (ddlCriteria.SelectedIndex > 0)
            //{
            criteria = ddlCriteria.SelectedItem.Text;
            //}
            int month = 0;
            int year = 0;


            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);

            if (year == 0)
            {
                lblmsg.Text = "Please Select Year";
                //RadGrid1New.Visible = false;
                //mainPnl.Visible = false;
                return;
            }

            lblmsg.Text = "";
            RadGrid2.CurrentPageIndex = 0;
            DataTable dsInvoice = obj.GetTotalInvoiceLess500DiffWise(criteria, year, month, 0, "<", 500);
            RadGrid2.DataSource = dsInvoice;
            RadGrid2.DataBind();

        }
        catch (Exception x)
        {
            lblmsg.Text = x.Message;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadYear();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search();
        if (ddlCriteria.SelectedItem.Text == "All Data")
        {
            RadGrid1.Visible = false;
            RadGrid2.Visible = true;
            bindReportByCriteriaAllData();
        }
        else
        {
            RadGrid1.Visible = true;
            RadGrid2.Visible = false;
            bindReportByCriteria();
        }
    }


    protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        //Session["RadGridPageNo"] = e.NewPageIndex;
        if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
        {
            Session["RadGridItemNo"] = ((RadGrid1.PageCount - 1) * RadGrid1.PageSize);
            bindReportByCriteria();
        }
        else
        {
            Session["RadGridItemNo"] = (e.NewPageIndex * RadGrid1.PageSize);
            bindReportByCriteria();
        }
    }

    protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        bindReportByCriteria();
    }

    protected void RadGrid1_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        bindReportByCriteria();
    }

    protected void RadGrid2_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
        {
            Session["RadGridItemNo"] = ((RadGrid1.PageCount - 1) * RadGrid1.PageSize);
            bindReportByCriteriaAllData();
        }
        else
        {
            Session["RadGridItemNo"] = (e.NewPageIndex * RadGrid1.PageSize);
            bindReportByCriteriaAllData();
        }
    }

    protected void RadGrid2_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        bindReportByCriteriaAllData();
    }

    protected void RadGrid2_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        bindReportByCriteriaAllData();
    }
    protected string ConvertToMoneyFormat(string myval)
    {
        if (myval == "")
        {
            return "0.00";
        }
        else
        {
            return string.Format("{0:0.00}", Convert.ToDouble(myval));
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            System.Web.UI.WebControls.TableCell cell = item["Sno"];

            Label labelSNo = (Label)cell.FindControl("lblSno");
            labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);
        }
    }

    protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            System.Web.UI.WebControls.TableCell cell = item["Sno"];

            Label labelSNo = (Label)cell.FindControl("lblSno");
            labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (ddlCriteria.SelectedItem.Text == "All Data")
        {
            if (RadGrid2.Items.Count > 0)
            {
                RadGrid2.ExportSettings.ExportOnlyData = true;
                RadGrid2.ExportSettings.IgnorePaging = true;
                RadGrid2.ExportSettings.OpenInNewWindow = true;
                RadGrid2.AllowPaging = false;
                bindReportByCriteriaAllData();
                RadGrid2.BackColor = System.Drawing.Color.White;
                RadGrid2.MasterTableView.ExportToExcel();

            }
        }
        else
        {
            if (RadGrid1.Items.Count > 0)
            {
                RadGrid1.ExportSettings.ExportOnlyData = true;
                RadGrid1.ExportSettings.IgnorePaging = true;
                RadGrid1.ExportSettings.OpenInNewWindow = true;
                RadGrid1.AllowPaging = false;
                bindReportByCriteria();
                RadGrid1.BackColor = System.Drawing.Color.White;
                RadGrid1.MasterTableView.ExportToExcel();
            }
        }


       
    }
   
}