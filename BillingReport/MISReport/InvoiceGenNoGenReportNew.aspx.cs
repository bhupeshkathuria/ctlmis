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


        DataSet dsRep = new DataSet();

        dsRep = obj.GetTotalCountInvoiceNotGenerate(year, month, 0);

        //if (dsRep.Tables[0].Rows.Count > 0)
        //{
        lblTotalRaf.Text = Convert.ToString(dsRep.Tables[0].Rows[0][0]);
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

            if (ddlMonth.SelectedIndex > 0)
            {
                month = Convert.ToInt32(ddlMonth.SelectedValue);
            }
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
            string rentalFree = "";
            string rentals = "";

            getTotalRaf(year, month, out rentals, out rentalFree);

            rentalFree = rentalFree.TrimEnd(',');
            DataTable dsInvoice = obj.GetCountRafByCriteria2(year, month, criteria, rentals, rentalFree);
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
        try
        {
            int month = 0;
            int year = 0;

            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);

            if (year == 0)
            {
                lblmsg.Text = "Please Select Year";
                return;
            }

            lblmsg.Text = "";
            RadGrid2.CurrentPageIndex = 0;
            DataSet dsInvoice = objInvSer.GetInvoiceGenNotGenReport(year, month, 0);
            RadGrid2.DataSource = dsInvoice.Tables[0];
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

    protected void getTotalRaf(int year, int month, out string rentals, out string rentalfree)
    {
        // Get Total Raf .........
        rentalfree = string.Empty;
        rentals = string.Empty;

        string strOrderIDNotGen = string.Empty;
        string strOrderIDCoponCostAdded = string.Empty;
        string strQry = string.Empty;



        string strTotalRAfWhichNotInvoiceGen = "select distinct so.orderid from clayerp.salesorder so "
+ "  INNER JOIN clayerp.salesorderdetails sod ON so.orderid = sod.orderid "
 + " LEFT OUTER JOIN clayerp.pi_sim_card_trans mobno ON so.orderid = mobno.orderid AND mobno.isdeleted =0 AND mobno.isrejected =0 "
 + " INNER JOIN clayerp.employee e ON e.employeeid = so.accountmanagerid        "
 + " INNER JOIN clayerp.package p ON p.packageid=mobno.packageid "
 + " LEFT JOIN clayerp.salesordercouponassignment socd ON socd.orderid = so.orderid AND socd.isdeleted=0 "
 + " LEFT JOIN clayerp.coupon cpn ON cpn.couponid=socd.couponid AND cpn.coupontypeid=3 "
+ " where so.branchid<>14 and "
+ "(select count(*) from ERPInvoicing.invoice i inner join ERPInvoicing.invoicing ina on i.invoicingid=ina.invoicingid "
+ " where i.orderid=so.orderid and ina.customertypeid=1)<=0 and "
+ " so.orderstatus<>'Reject' and so.orderstatus<>'Cancel' and so.orderstatus<>'Pending'  ";
        if (month == 0)
        {
            strTotalRAfWhichNotInvoiceGen += " AND YEAR(so.orderdate)= " + year + ";";
        }
        else
        {
            strTotalRAfWhichNotInvoiceGen += " AND YEAR(so.orderdate)= " + year + " AND MONTH(so.orderdate)= " + month + ";";
        }

        Clay.Invoice.Bll.Query objGetTotalRafNotGen = new Clay.Invoice.Bll.Query();
        DataSet dsGetTotalRafNotGen = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strTotalRAfWhichNotInvoiceGen);

        for (int x = 0; x < dsGetTotalRafNotGen.Tables[0].Rows.Count; x++)
        {
            strOrderIDNotGen += dsGetTotalRafNotGen.Tables[0].Rows[x][0].ToString() + ",";
        }

        strOrderIDNotGen = strOrderIDNotGen.TrimEnd(',');


        string strCheckCopnCost = "select distinct soc.orderid from clayerp.coupon c inner join clayerp.salesordercouponassignment soc on c.couponid=soc.couponid "
            + " where soc.isdeleted=0 and c.couponcost>0 and soc.orderid in (" + strOrderIDNotGen + ");";

        DataSet dsRentalOrders = new DataSet();
        dsRentalOrders = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strCheckCopnCost);

        for (int g = 0; g < dsRentalOrders.Tables[0].Rows.Count; g++)
        {
            strOrderIDCoponCostAdded += dsRentalOrders.Tables[0].Rows[g][0].ToString() + ",";
        }

        strOrderIDCoponCostAdded = strOrderIDCoponCostAdded.TrimEnd(',');



        string strGetTotalCouponWhichNotCouponCostAdded = string.Empty;
        if (strOrderIDCoponCostAdded.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.salesorder where orderid in (" + strOrderIDNotGen + ") and orderid not in (" + strOrderIDCoponCostAdded + ");";
        }
        else
        {
            strQry = "select distinct orderid from clayerp.salesorder where orderid in (" + strOrderIDNotGen + ");";
        }

        DataSet dsCopnCostNotAdded = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);

        for (int js = 0; js < dsCopnCostNotAdded.Tables[0].Rows.Count; js++)
        {
            strGetTotalCouponWhichNotCouponCostAdded += dsCopnCostNotAdded.Tables[0].Rows[js][0].ToString() + ",";
        }

        strGetTotalCouponWhichNotCouponCostAdded = strGetTotalCouponWhichNotCouponCostAdded.TrimEnd(',');


        string strTotalRafZero = string.Empty;
        if (strGetTotalCouponWhichNotCouponCostAdded.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.pi_sim_card_trans p inner join clayerp.package pkge on p.packageid=pkge.packageid "
                + "  where rentalcost<=0 and p.isdeleted =0 AND p.isrejected =0 and p.orderid in (" + strGetTotalCouponWhichNotCouponCostAdded + ");";

            DataSet dsTotalRafZero = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);


            for (int ss = 0; ss < dsTotalRafZero.Tables[0].Rows.Count; ss++)
            {
                strTotalRafZero += dsTotalRafZero.Tables[0].Rows[ss][0].ToString() + ",";
            }

            strTotalRafZero = strTotalRafZero.TrimEnd(',');
        }


        string strTotalRemainsRaf = string.Empty;

        if (strTotalRafZero.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.salesorder where orderid in (" + strGetTotalCouponWhichNotCouponCostAdded + ") and orderid not in (" + strTotalRafZero + ");";
        }
        else
        {
            strQry = "select  distinct orderid from clayerp.salesorder where orderid in (" + strGetTotalCouponWhichNotCouponCostAdded + ");";
        }

        DataSet dsRemainsRaf = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);
        for (int js = 0; js < dsRemainsRaf.Tables[0].Rows.Count; js++)
        {
            strTotalRemainsRaf += dsRemainsRaf.Tables[0].Rows[js][0].ToString() + ",";
        }
        strTotalRemainsRaf = strTotalRemainsRaf.TrimEnd(',');

        string strPackageRntalAded = string.Empty;

        if (strTotalRemainsRaf.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.pi_sim_card_trans p inner join clayerp.package pkge on p.packageid=pkge.packageid "
               + "  where rentalcost>0 and p.isdeleted =0 AND p.isrejected =0 and orderid in (" + strTotalRemainsRaf + ");";

            DataSet dsPackageREntalAdded = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);

            for (int js = 0; js < dsPackageREntalAdded.Tables[0].Rows.Count; js++)
            {
                strPackageRntalAded += dsPackageREntalAdded.Tables[0].Rows[js][0].ToString() + ",";
            }
            strPackageRntalAded = strPackageRntalAded.TrimEnd(',');
        }

        string strPckagRentalCopnAttached = string.Empty;
        if (strPackageRntalAded.Length > 0)
        {
            strQry = "select  distinct orderid from clayerp.salesordercouponassignment soc inner join clayerp.coupon c on c.couponid=soc.couponid"
                + " where soc.isdeleted=0 and coupontypeid=3 and orderid in (" + strPackageRntalAded + ")";

            DataSet dsRentalCopnAttached = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);

            for (int js = 0; js < dsRentalCopnAttached.Tables[0].Rows.Count; js++)
            {
                strPckagRentalCopnAttached += dsRentalCopnAttached.Tables[0].Rows[js][0].ToString() + ",";
            }
            strPckagRentalCopnAttached = strPckagRentalCopnAttached.TrimEnd(',');

            strTotalRafZero += "," + strPckagRentalCopnAttached;
        }


        string strTotalPckgRentalActualInLAst = string.Empty;

        if (strPckagRentalCopnAttached.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.salesorder where orderid in (" + strPackageRntalAded + ") and orderid not in (" + strPckagRentalCopnAttached + ");";
            DataSet dsActualLast = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);
            for (int js = 0; js < dsActualLast.Tables[0].Rows.Count; js++)
            {
                strTotalPckgRentalActualInLAst += dsActualLast.Tables[0].Rows[js][0].ToString() + ",";
            }
            strTotalPckgRentalActualInLAst = strTotalPckgRentalActualInLAst.TrimEnd(',');

            strOrderIDCoponCostAdded += "," + strTotalPckgRentalActualInLAst;

        }
        else if (strPackageRntalAded.Length > 0)
        {
            strQry = "select distinct orderid from clayerp.salesorder where orderid in (" + strPackageRntalAded + ");";
            DataSet dsActualLast = objGetTotalRafNotGen.RunSelectQueryDBDirect("ERPInvoicing", strQry);
            for (int js = 0; js < dsActualLast.Tables[0].Rows.Count; js++)
            {
                strTotalPckgRentalActualInLAst += dsActualLast.Tables[0].Rows[js][0].ToString() + ",";
            }
            strTotalPckgRentalActualInLAst = strTotalPckgRentalActualInLAst.TrimEnd(',');

            strOrderIDCoponCostAdded += "," + strTotalPckgRentalActualInLAst;

        }



        rentalfree = strTotalRafZero;
        rentals = strOrderIDCoponCostAdded;



    }
}