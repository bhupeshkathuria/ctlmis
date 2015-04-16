using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using System.Data;

public partial class MISReport_BusinessDownReport : System.Web.UI.Page
{
    DataSet dsEmployee = null;

    Clay.Invoice.Bll.Report rpt = new Clay.Invoice.Bll.Report();
    Clay.Invoice.Bll.Web objSalesOrderWeb = null;

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
        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            ddlYear1bymonth.DataSource = dsYear.Tables[0];
            ddlYear1bymonth.DataTextField = "yearVal";
            ddlYear1bymonth.DataValueField = "yearTxt";
            ddlYear1bymonth.DataBind();
            ddlYear1bymonth.SelectedIndex = 0;

            ddlYear2bymonth.DataSource = dsYear.Tables[0];
            ddlYear2bymonth.DataTextField = "yearVal";
            ddlYear2bymonth.DataValueField = "yearTxt";
            ddlYear2bymonth.DataBind();
            ddlYear2bymonth.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            ddlyear1byquarter.DataSource = dsYear.Tables[0];
            ddlyear1byquarter.DataTextField = "yearVal";
            ddlyear1byquarter.DataValueField = "yearTxt";
            ddlyear1byquarter.DataBind();
            ddlyear1byquarter.SelectedIndex = 0;

            ddlyear2byquarter.DataSource = dsYear.Tables[0];
            ddlyear2byquarter.DataTextField = "yearVal";
            ddlyear2byquarter.DataValueField = "yearTxt";
            ddlyear2byquarter.DataBind();
            ddlyear2byquarter.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            ddlyear1bysemi.DataSource = dsYear.Tables[0];
            ddlyear1bysemi.DataTextField = "yearVal";
            ddlyear1bysemi.DataValueField = "yearTxt";
            ddlyear1bysemi.DataBind();
            ddlyear1bysemi.SelectedIndex = 0;

            ddlyear2bysemi.DataSource = dsYear.Tables[0];
            ddlyear2bysemi.DataTextField = "yearVal";
            ddlyear2bysemi.DataValueField = "yearTxt";
            ddlyear2bysemi.DataBind();
            ddlyear2bysemi.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            ddlyear1byyear.DataSource = dsYear.Tables[0];
            ddlyear1byyear.DataTextField = "yearVal";
            ddlyear1byyear.DataValueField = "yearTxt";
            ddlyear1byyear.DataBind();
            ddlyear1byyear.SelectedIndex = 0;

            ddlyear2byyear.DataSource = dsYear.Tables[0];
            ddlyear2byyear.DataTextField = "yearVal";
            ddlyear2byyear.DataValueField = "yearTxt";
            ddlyear2byyear.DataBind();
            ddlyear2byyear.SelectedIndex = 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["dataset"] = null;
        }
    }

    void checkpageright()
    {
        Clay.Invoice.Bll.Page objPage = new Clay.Invoice.Bll.Page();
        DataSet dspageright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        page = System.IO.Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);
        objPage.PageName = page;
        objPage.UserId = user;
        dspageright = objPage.CheckPageRight();

        if (dspageright.Tables[0].Rows.Count == 0)
        {
            Response.Redirect("../invoice/Error500.aspx");
            return;
        }

    }

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Write("<script language='javascript'>window.open('../../LoginWebErp.aspx','_parent','');</script>");
            }

        }
        catch
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        RadGrid1New.Visible = true;
        BindRadGrid();
    }

    private void search(out string fromdate1, out string todate1, out string fromdate2, out string todate2)
    {
        lblmsg.Text = "";
        int month_1 = 0;
        int year_1 = 0;
        int month_2 = 0;
        int year_2 = 0;
        int managerid = 0;
        fromdate1 = string.Empty;
        todate1 = string.Empty;
        fromdate2 = string.Empty;
        todate2 = string.Empty;
        RadGrid1New.Visible = true;

        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            #region  By Month Report
            if ((ddlMonth1bymonth.SelectedIndex > 0) && (ddlYear1bymonth.SelectedIndex > 0) && (ddlMonth2bymonth.SelectedIndex > 0) && (ddlYear2bymonth.SelectedIndex > 0))
            {
                month_1 = Convert.ToInt32(ddlMonth1bymonth.SelectedValue);
                year_1 = Convert.ToInt32(ddlYear1bymonth.SelectedValue);
                month_2 = Convert.ToInt32(ddlMonth2bymonth.SelectedValue);
                year_2 = Convert.ToInt32(ddlYear2bymonth.SelectedValue);

                DataSet ds_bymonthsale1 = new DataSet();
                DataSet ds_bymonthsale2 = new DataSet();

                int days = DateTime.DaysInMonth(year_1, month_1);
                fromdate1 = year_1 + "-" + month_1 + "-" + "01";
                todate1 = year_1 + "-" + month_1 + "-" + days.ToString();
                //Bind Dataset 
                //ds_bymonthsale1 = rpt.GetReportByMonthBilling1(fromdate1, todate1, managerid);

                int days2 = DateTime.DaysInMonth(year_2, month_2);
                fromdate2 = year_2 + "-" + month_2 + "-" + "01";
                todate2 = year_2 + "-" + month_2 + "-" + days2.ToString();
                //Bind Dataset 
                //ds_bymonthsale2 = rpt.GetReportByMonthBilling2(fromdate2, todate2, managerid);

                ////////////RadGrid1New.Visible = true;
                ////////////if (ds_bymonthsale1.Tables[0].Rows.Count > 0)
                ////////////{
                ////////////    RadGrid1New.DataSource = ds_bymonthsale1.Tables[0];
                ////////////    RadGrid1New.DataBind();

                ////////////    //Session["dataset"] = ds_bymonth;
                ////////////}
                ////////////else
                ////////////{
                ////////////    RadGrid1New.DataSource = ds_bymonthsale1.Tables[0];
                ////////////    RadGrid1New.DataBind();

                ////////////    // RadGrid1.DataSource = null;
                ////////////}
            }
            else
            {
                lblmsg.Text = "Yoh have choose incorrect values";
                RadGrid1New.DataSource = null;
                RadGrid1New.DataBind();
            }
            #endregion

        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            #region By Quarter Report
            if ((ddlmonth1byquarter.SelectedIndex > 0) && (ddlyear1byquarter.SelectedIndex > 0) && (ddlmonth2byquarter.SelectedIndex > 0) && (ddlyear2byquarter.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;
                string month1 = string.Empty;
                string month2 = string.Empty;
                int year1 = 0;
                int year2 = 0;

                caseval = Convert.ToInt32(ddlmonth1byquarter.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2byquarter.SelectedValue);
                year_1 = Convert.ToInt32(ddlyear1byquarter.SelectedValue);
                year_2 = Convert.ToInt32(ddlyear2byquarter.SelectedValue);
                switch (caseval)
                {
                    case 1:
                        month1 = "4,5,6";
                        fromdate1 = year_1 + "-04-01";
                        todate1 = year_1 + "-06-30";
                        break;
                    case 2:
                        month1 = "7,8,9";
                        fromdate1 = year_1 + "-07-01";
                        todate1 = year_1 + "-09-30";
                        break;
                    case 3:
                        month1 = "10,11,12";
                        fromdate1 = year_1 + "-10-01";
                        todate1 = year_1 + "-12-31";
                        break;
                    case 4:
                        month1 = "1,2,3";
                        fromdate1 = year_1 + 1 + "-01-01";
                        todate1 = year_1 + 1 + "-03-31";
                        break;
                }
                switch (caseval2)
                {
                    case 1:
                        month2 = "4,5,6";
                        fromdate2 = year_2 + "-04-01";
                        todate2 = year_2 + "-06-30";
                        break;
                    case 2:
                        month2 = "7,8,9";
                        fromdate2 = year_2 + "-07-01";
                        todate2 = year_2 + "-09-30";
                        break;
                    case 3:
                        month2 = "10,11,12";
                        fromdate2 = year_2 + "-10-01";
                        todate2 = year_2 + "-12-31";
                        break;
                    case 4:
                        month2 = "1,2,3";
                        fromdate2 = year_2 + 1 + "-01-01";
                        todate2 = year_2 + 1 + "-03-31";
                        break;
                }
            }
            else
            {
                lblmsg.Text = "Yoh have choose incorrect values";
            }
            #endregion
        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            #region By Semi Year Report
            if ((ddlmonth1bysemi.SelectedIndex > 0) && (ddlyear1bysemi.SelectedIndex > 0) && (ddlmonth2bysemi.SelectedIndex > 0) && (ddlyear2bysemi.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;
                string month1 = string.Empty;
                string month2 = string.Empty;
                int year1 = 0;
                int year2 = 0;
                caseval = Convert.ToInt32(ddlmonth1bysemi.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2bysemi.SelectedValue);
                year1 = Convert.ToInt32(ddlyear1bysemi.SelectedValue);
                year2 = Convert.ToInt32(ddlyear2bysemi.SelectedValue);
                switch (caseval)
                {
                    case 1:
                        month1 = "4,5,6,7,8,9";
                        fromdate1 = year1 + "-04-01";
                        todate1 = year1 + "-09-30";
                        break;
                    case 2:
                        month1 = "10,11,12,1,2,3";
                        fromdate1 = year1 + "-10-01";
                        todate1 = year1 + 1 + "-03-31";
                        break;

                }
                switch (caseval2)
                {
                    case 1:
                        month2 = "4,5,6,7,8,9";
                        fromdate2 = year2 + "-04-01";
                        todate2 = year2 + "-09-30";
                        break;
                    case 2:
                        month2 = "10,11,12,1,2,3";
                        fromdate2 = year2 + "-10-01";
                        todate2 = year2 + 1 + "-03-31";
                        break;

                }

            }
            else
            {
                lblmsg.Text = "You have choose incorrect values";
            }
            #endregion
        }

        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            #region By Year Report
            if ((ddlyear1byyear.SelectedIndex > 0) && (ddlyear2byyear.SelectedIndex > 0))
            {


                int year1 = 0;
                int year2 = 0;


                year1 = Convert.ToInt32(ddlyear1byyear.SelectedValue);
                year2 = Convert.ToInt32(ddlyear2byyear.SelectedValue);



                DataSet ds_byYearsale1 = new DataSet();
                DataSet ds_byYearsale2 = new DataSet();
                RadGrid1New.Visible = true;
                fromdate1 = year1 + "-04-01";
                todate1 = year1 + 1 + "-03-31";

                fromdate2 = year2 + "-04-01";
                todate2 = year2 + 1 + "-03-31";

            }
            else
            {
                lblmsg.Text = "You have choose incorrect values";
            }
            #endregion
        }

    }

    protected void rdiobtnlst_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            //  RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            trbymonth.Visible = true;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = false;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";


        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            //  RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = true;
            trbysemiyear.Visible = false;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";

        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            //  RadGrid1.DataSource = null;
            // RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = true;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";

        }
        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            // RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = false;
            trbyyear.Visible = true;
            loadYear();
            lblmsg.Text = "";

        }
    }

    protected void RadGrid1New_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGrid1New.PageSize) > RadGrid1New.PageCount)
        {
            BindRadGrid();
        }
        else
        {
            BindRadGrid();
        }
    }
    protected void RadGrid1New_SortCommand(object source, GridSortCommandEventArgs e)
    {
        BindRadGrid();
    }
    protected void RadGrid1New_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        BindRadGrid();
    }

    double sum = 0;
    double sum2 = 0;
    protected void RadGrid1New_ItemDataBound(object sender, GridItemEventArgs e)
    {
        decimal orders = 0;

        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            Label lbl1 = item.FindControl("lblsalecount") as Label;
            sum += Convert.ToDouble(lbl1.Text);

            Label lbl2 = item.FindControl("lbllowsalecount") as Label;
            sum2 += Convert.ToDouble(lbl2.Text);

        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandtotalsalecount") as Label;
            Label lblgrandtotallow = item.FindControl("lblgrandtotallowsalecount") as Label;

            lblgrandtotal.Text = Convert.ToString(sum);
            lblgrandtotallow.Text = Convert.ToString(sum2);


        }
    }

    //protected string ConvertToMoneyFormat(string myval)
    //{
    //    //if (radiobtnlstType.SelectedItem.Value == "1")
    //    //{
    //    //    return myval;
    //    //}
    //    //else
    //    //{
    //    //    if (myval == "")
    //    //    {
    //    //        return "0.00";
    //    //    }
    //    //    else
    //    //    {
    //    //        return string.Format("{0:0.00}", Convert.ToDouble(myval));
    //    //    }
    //    //}
    //}

    protected DataSet GetDataSet(DataSet dsFirst, DataSet dsSecond, int topCount)
    {
        int custID = 0;
        int saleCount = 0;
        string customerName = string.Empty;
        int lowSalecount = 0;
        DataSet dsReturn = new DataSet();
        dsReturn.Tables.Add("A");
        dsReturn.Tables[0].Columns.Add("customerid");
        dsReturn.Tables[0].Columns.Add("salecount");
        dsReturn.Tables[0].Columns.Add("customername");
        dsReturn.Tables[0].Columns.Add("lowsalecount");

        try
        {
            if (dsFirst.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < dsFirst.Tables[0].Rows.Count; x++)
                {
                    custID = Convert.ToInt32(dsFirst.Tables[0].Rows[x]["customerid"]);
                    saleCount = Convert.ToInt32(dsFirst.Tables[0].Rows[x]["cnt"]);
                    customerName = Convert.ToString(dsFirst.Tables[0].Rows[x]["customername"]);

                    DataSet dsGet = ApplyDataSearch(custID, dsSecond);

                    if (dsGet.Tables[0].Rows.Count > 0)
                    {
                        lowSalecount = Convert.ToInt32(dsGet.Tables[0].Rows[0]["cnt"]);

                        if (saleCount > lowSalecount)
                        {
                            dsReturn.Tables[0].Rows.Add(custID.ToString(), saleCount.ToString(), customerName, lowSalecount.ToString());
                        }
                    }

                    if (dsReturn.Tables[0].Rows.Count == topCount)
                    {
                        break;
                    }



                }

            }
        }
        catch (Exception ex)
        {
        }

        return dsReturn;
    }

    private DataSet ApplyDataSearch(int customerID, DataSet dsAll)
    {
        DataSet ds = new DataSet();

        try
        {
            DataRow[] foundRows;

            foundRows = dsAll.Tables[0].Select("customerid=" + customerID);
            int i = 0;

            ds = dsAll.Clone();

            for (i = 0; i < foundRows.Length; i++)
            {
                ds.Tables[0].ImportRow(foundRows[i]);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;

    }

    private void BindRadGrid()
    {
        //    Clay.Invoice.Bll.Query obj = new Clay.Invoice.Bll.Query();
        //    string str = "select count(*) as cnt, customerid,customername from clayerp.salesorder "
        //        + " where orderdate between '2012-04-01' and '2012-06-30' group by customerid order by customerid";
        Clay.Invoice.Bll.Report obj = new Clay.Invoice.Bll.Report();

        string fromDate1 = string.Empty;
        string fromDate2 = string.Empty;
        string toDate1 = string.Empty;
        string toDate2 = string.Empty;

        search(out fromDate1, out toDate1, out fromDate2, out toDate2);
        if ((fromDate1 == "") || (fromDate2 == "") || (toDate1 == "") || (toDate2 == ""))
        {
            return;
        }
        DataSet dsOne = obj.GetDownBusinessReport(fromDate1, toDate1, fromDate2, toDate2, Convert.ToInt32(ddlTop.SelectedValue));

        //    string str2 = "select count(*) as cnt, customerid,customername from clayerp.salesorder "
        //+ " where orderdate between '2012-09-01' and '2012-12-30' group by customerid order by customerid";

        DataSet dsTwo = new DataSet();
        dsTwo.Merge(dsOne.Tables[1]);


        DataSet dsFinal = GetDataSet(dsOne, dsTwo, Convert.ToInt32(ddlTop.SelectedValue));
        RadGrid1New.Visible = true;
        RadGrid1New.DataSource = dsFinal;
        RadGrid1New.DataBind();


    }

}