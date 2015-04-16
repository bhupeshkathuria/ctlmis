using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.IO;

public partial class MISReport_HighestCorporate : System.Web.UI.Page
{
    double totalCountSale = 0;
    double totalCountSale2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadYear();
        }
    }

    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        this.UpdateToolTip(args.Value, args.UpdatePanel);
    }

    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        Control ctrl = Page.LoadControl("HighestCorporateSale.ascx");
        panel.ContentTemplateContainer.Controls.Add(ctrl);
        ASP.misreport_highestcorporatesale_ascx details = (ASP.misreport_highestcorporatesale_ascx)ctrl;

        details.customerID = Convert.ToInt32(elementID);
        details.yearVAl = Convert.ToInt32(ddlYear.SelectedValue);
        details.monthVAl = Convert.ToInt32(ddlMonth.SelectedValue);
    }

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

        ddlYear2.DataSource = dsYear.Tables[0];
        ddlYear2.DataTextField = "yearVal";
        ddlYear2.DataValueField = "yearTxt";
        ddlYear2.DataBind();
        ddlYear2.SelectedIndex = 0;
    }

    private void search()
    {
        lblmsg.Text = "";
        int month = 0;
        int year = 0;
        int monthTo = 0;
        int yearTo = 0;
        RadGrid1New.Visible = true;

        month = Convert.ToInt32(ddlMonth.SelectedValue);
        year = Convert.ToInt32(ddlYear.SelectedValue);

        //if (month == 0)
        //{
        //    lblmsg.Text = "Please Select Month";
        //    RadGrid1New.Visible = false;
        //    mainPnl.Visible = false;
        //    return;
        //}
        if (year == 0)
        {
            lblmsg.Text = "Please Select Year";
            RadGrid1New.Visible = false;
            mainPnl.Visible = false;
            return;
        }

        monthTo = Convert.ToInt32(ddlMonthTo.SelectedValue);
        yearTo = Convert.ToInt32(ddlYear2.SelectedValue);

        if (yearTo == 0)
        {
            lblmsg.Text = "Please Select To Year";
            RadGrid1New.Visible = false;
            mainPnl.Visible = false;
            return;
        }

        mainPnl.Visible = true;

        Clay.Invoice.Bll.Report obj = new Clay.Invoice.Bll.Report();
        DataSet dsRep = new DataSet();

        DataSet dsRepByCustID = new DataSet();

        dsRep = obj.GetTop10HighestCorporateFAC(year, month, Convert.ToInt32(ddlTop.SelectedValue));

        if (dsRep.Tables[0].Rows.Count > 0)
        {
            // Get CustomerID 
            string strCustomerID = string.Empty;

            for (int iAnand = 0; iAnand < dsRep.Tables[0].Rows.Count; iAnand++)
            {
                strCustomerID += dsRep.Tables[0].Rows[iAnand]["FalconFACLedgerID"].ToString() + ",";
            }
            strCustomerID = strCustomerID.TrimEnd(',');

            dsRepByCustID = obj.GetTopHighestCorporateByCustomerIDFAC(yearTo, monthTo, strCustomerID);

            DataTable dtNew = new DataTable();

            dtNew = bindNewData(dsRep.Tables[0], dsRepByCustID.Tables[0]);

            RadGrid1New.DataSource = dtNew;
            RadGrid1New.DataBind();
            lblsell.Visible = false;
        }
        else
        {
            lblsell.Visible = true;
            RadGrid1New.Visible = false;
        }

    }

    private DataTable bindNewData(DataTable dsRepMain, DataTable dsRepCustID)
    {
        DataTable ds = new DataTable();
        try
        {
            for (int iAnand = 0; iAnand < dsRepMain.Rows.Count; iAnand++)
            {
                int CustID = Convert.ToInt32(dsRepMain.Rows[iAnand]["FalconFACLedgerID"]);

                DataRow[] foundRows;
                foundRows = dsRepCustID.Select("FalconFACLedgerID=" + CustID);
                int i = 0;

                ds = dsRepCustID.Clone();
                for (i = 0; i < foundRows.Length; i++)
                {
                    ds.ImportRow(foundRows[i]);
                }

                if (ds.Rows.Count > 0)
                {
                    dsRepMain.Rows[iAnand]["salecount2"] = ds.Rows[0]["salecount"].ToString();
                }
                dsRepMain.Rows[iAnand]["lyear2"] = ddlYear2.SelectedValue.ToString();
                dsRepMain.Rows[iAnand]["lmonth2"] = ddlMonthTo.SelectedValue.ToString();

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsRepMain;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search();
    }

    protected void RadGrid1New_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.ItemType == GridItemType.Header)
        {
            Label lblHeader = e.Item.FindControl("lblHeader") as Label;
            if (ddlMonth.SelectedItem.Text == "Select")
            {
                lblHeader.Text = ddlYear.SelectedItem.Text;
            }
            else
            {
                lblHeader.Text = ddlMonth.SelectedItem.Text + "-" + ddlYear.SelectedItem.Text;
            }

            Label lblHeader2 = e.Item.FindControl("lblHeader2") as Label;
            if (ddlMonthTo.SelectedItem.Text == "Select")
            {
                lblHeader2.Text = ddlYear2.SelectedItem.Text;
            }
            else
            {
                lblHeader2.Text = ddlMonthTo.SelectedItem.Text + "-" + ddlYear2.SelectedItem.Text;
            }


        }

        if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        {
            Control target = e.Item.FindControl("hpSellCount");
            double countSale = 0;

            Control target2 = e.Item.FindControl("hpSellCount2");
            double countSale2 = 0;

            HyperLink hpAmt = e.Item.FindControl("hpSellCount") as HyperLink;
            HyperLink hpAmt2 = e.Item.FindControl("hpSellCount2") as HyperLink;

            countSale = Convert.ToDouble(hpAmt.Text);
            countSale2 = Convert.ToDouble(hpAmt2.Text);

            totalCountSale += countSale;
            totalCountSale2 += countSale2;

            //if (!Object.Equals(target, null))
            //{
            //    if (!Object.Equals(this.RadToolTipManager1, null))
            //    {
            //        //Add the button (target) id to the tooltip manager
            //        this.RadToolTipManager1.TargetControls.Add(target.ClientID, (e.Item as GridDataItem).GetDataKeyValue("FalconFACLedgerID").ToString(), true);
            //    }
            //}
        }
        else if (e.Item.ItemType == GridItemType.Footer)
        {
            Label lb = e.Item.FindControl("lblTotal") as Label;
            lb.Text = Math.Round(totalCountSale).ToString();

            Label lb2 = e.Item.FindControl("lblTotal2") as Label;
            lb2.Text = Math.Round(totalCountSale2).ToString();
        }
    }
}