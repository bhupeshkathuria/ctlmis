using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;

public partial class CreditControl_rpt_monthly_branch : System.Web.UI.Page
{
    Clay.Sale.Bll.CreditDetail objrep = new Clay.Sale.Bll.CreditDetail();
    DataSet ds_all = new DataSet();

    #region Varibles
    int branchid = 0;
    string branchname = string.Empty;

    decimal _1st = 0;
    decimal _2st = 0;
    decimal _3st = 0;
    decimal _4st = 0;
    decimal _5st = 0;
    decimal _6st = 0;
    decimal _7st = 0;
    decimal _8st = 0;
    decimal _9st = 0;
    decimal _10st = 0;
    decimal _11st = 0;
    decimal _12st = 0;



    decimal _13st = 0;
    decimal _14st = 0;
    decimal _15st = 0;
    decimal _16st = 0;
    decimal _17st = 0;
    decimal _18st = 0;
    decimal _19st = 0;
    decimal _20st = 0;
    decimal _21st = 0;
    decimal _22st = 0;
    decimal _23st = 0;
    decimal _24st = 0;

    decimal _25st = 0;
    decimal _26st = 0;
    decimal _27st = 0;
    decimal _28st = 0;
    decimal _29st = 0;
    decimal _30st = 0;
    decimal _31st = 0;

    decimal _alldaytotal = 0;
    decimal _daytotal = 0;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

            loadYear();
        }
    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }
    
    private void getmonthly_report_branchwise()
    {
        #region Create Datatable
        System.Data.DataTable dt = new System.Data.DataTable();
        // dt.Columns.Add("Branchid", string.Empty.GetType());
        dt.Columns.Add("Branch", string.Empty.GetType());

        dt.Columns.Add("1", string.Empty.GetType());
        dt.Columns.Add("2", string.Empty.GetType());
        dt.Columns.Add("3", string.Empty.GetType());
        dt.Columns.Add("4", string.Empty.GetType());
        dt.Columns.Add("5", string.Empty.GetType());
        dt.Columns.Add("6", string.Empty.GetType());
        dt.Columns.Add("7", string.Empty.GetType());
        dt.Columns.Add("8", string.Empty.GetType());
        dt.Columns.Add("9", string.Empty.GetType());
        dt.Columns.Add("10", string.Empty.GetType());
        dt.Columns.Add("11", string.Empty.GetType());
        dt.Columns.Add("12", string.Empty.GetType());
        dt.Columns.Add("13", string.Empty.GetType());
        dt.Columns.Add("14", string.Empty.GetType());
        dt.Columns.Add("15", string.Empty.GetType());
        dt.Columns.Add("16", string.Empty.GetType());
        dt.Columns.Add("17", string.Empty.GetType());
        dt.Columns.Add("18", string.Empty.GetType());
        dt.Columns.Add("19", string.Empty.GetType());
        dt.Columns.Add("20", string.Empty.GetType());
        dt.Columns.Add("21", string.Empty.GetType());
        dt.Columns.Add("22", string.Empty.GetType());
        dt.Columns.Add("23", string.Empty.GetType());
        dt.Columns.Add("24", string.Empty.GetType());
        dt.Columns.Add("25", string.Empty.GetType());
        dt.Columns.Add("26", string.Empty.GetType());
        dt.Columns.Add("27", string.Empty.GetType());
        dt.Columns.Add("28", string.Empty.GetType());
        dt.Columns.Add("29", string.Empty.GetType());
        dt.Columns.Add("30", string.Empty.GetType());
        dt.Columns.Add("31", string.Empty.GetType());
        dt.Columns.Add("total", string.Empty.GetType());
        #endregion
        try
        {
            lblmess.Text = "";
            string fromdate = string.Empty;
            string todate = string.Empty;
            int year = 0;
            int month = 0;
            year = Convert.ToInt32(ddlyear.SelectedValue);
            month = Convert.ToInt32(ddlMonth1bymonth.SelectedValue);

            int days = DateTime.DaysInMonth(year, month);
            fromdate = year + "-" + month + "-" + "01";
            todate = year + "-" + month + "-" + days.ToString();
            int[] day = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            ds_all = objrep.GetMonthly_report_by_branch(fromdate, todate);

            foreach (DataRow dr in ds_all.Tables["branch"].Rows)
            {
                DataRow dr_ = dt.NewRow();
                _alldaytotal = 0;
                branchid = Convert.ToInt32(dr["branchid"]);
                branchname = dr["branchname"].ToString();
                for (int i = 0; i < day.Length; i++)
                {
                    DataRow[] dr_day = ds_all.Tables["report"].Select("day1=" + day[i] + " and branch=" + branchid);
                    if (dr_day.Length > 0)
                    {
                        _daytotal = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_day[0]["amount"])));
                        _alldaytotal += _daytotal;
                    }
                    else
                    {
                        _daytotal = 0;
                        _alldaytotal += _daytotal;
                    }

                    #region Days Wise Amount
                    if (day[i] == 1)
                    {
                        dr_["1"] = _daytotal;
                    }
                    else if (day[i] == 2)
                    {
                        dr_["2"] = _daytotal;
                    }
                    else if (day[i] == 3)
                    {
                        dr_["3"] = _daytotal;
                    }
                    else if (day[i] == 4)
                    {
                        dr_["4"] = _daytotal;
                    }
                    else if (day[i] == 5)
                    {
                        dr_["5"] = _daytotal;
                    }
                    else if (day[i] == 6)
                    {
                        dr_["6"] = _daytotal;
                    }
                    else if (day[i] == 7)
                    {
                        dr_["7"] = _daytotal;
                    }
                    else if (day[i] == 8)
                    {
                        dr_["8"] = _daytotal;
                    }
                    else if (day[i] == 9)
                    {
                        dr_["9"] = _daytotal;
                    }
                    else if (day[i] == 10)
                    {
                        dr_["10"] = _daytotal;
                    }
                    else if (day[i] == 11)
                    {
                        dr_["11"] = _daytotal;
                    }
                    else if (day[i] == 12)
                    {
                        dr_["12"] = _daytotal;
                    }
                    else if (day[i] == 13)
                    {
                        dr_["13"] = _daytotal;
                    }
                    else if (day[i] == 14)
                    {
                        dr_["14"] = _daytotal;
                    }
                    else if (day[i] == 15)
                    {
                        dr_["15"] = _daytotal;
                    }
                    else if (day[i] == 16)
                    {
                        dr_["16"] = _daytotal;
                    }
                    else if (day[i] == 17)
                    {
                        dr_["17"] = _daytotal;
                    }
                    else if (day[i] == 18)
                    {
                        dr_["18"] = _daytotal;
                    }
                    else if (day[i] == 19)
                    {
                        dr_["19"] = _daytotal;
                    }
                    else if (day[i] == 20)
                    {
                        dr_["20"] = _daytotal;
                    }
                    else if (day[i] == 21)
                    {
                        dr_["21"] = _daytotal;
                    }
                    else if (day[i] == 22)
                    {
                        dr_["22"] = _daytotal;
                    }
                    else if (day[i] == 23)
                    {
                        dr_["23"] = _daytotal;
                    }
                    else if (day[i] == 24)
                    {
                        dr_["24"] = _daytotal;
                    }
                    else if (day[i] == 25)
                    {
                        dr_["25"] = _daytotal;
                    }
                    else if (day[i] == 26)
                    {
                        dr_["26"] = _daytotal;
                    }
                    else if (day[i] == 27)
                    {
                        dr_["27"] = _daytotal;
                    }
                    else if (day[i] == 28)
                    {
                        dr_["28"] = _daytotal;
                    }
                    else if (day[i] == 29)
                    {
                        dr_["29"] = _daytotal;
                    }
                    else if (day[i] == 30)
                    {
                        dr_["30"] = _daytotal;
                    }
                    else if (day[i] == 31)
                    {
                        dr_["31"] = _daytotal;
                    }

                    #endregion
                }
                dr_["total"] = _alldaytotal;
                dr_["Branch"] = branchname.ToString();
                dt.Rows.Add(dr_);
                dt.AcceptChanges();




            }
            grdrept.DataSource = dt;
            grdrept.DataBind();
            trexcel.Visible = true;
        }
        catch (Exception ex)
        {
            ErrorLog(ex.ToString());
        }

    }

    #region Varibles for rowdatabound
    decimal total_1day = 0;
    decimal total_2day = 0;
    decimal total_3day = 0;
    decimal total_4day = 0;
    decimal total_5day = 0;
    decimal total_6day = 0;
    decimal total_7day = 0;
    decimal total_8day = 0;
    decimal total_9day = 0;
    decimal total_10day = 0;
    decimal total_11day = 0;
    decimal total_12day = 0;
    decimal total_13day = 0;
    decimal total_14day = 0;
    decimal total_15day = 0;
    decimal total_16day = 0;
    decimal total_17day = 0;
    decimal total_18day = 0;
    decimal total_19day = 0;
    decimal total_20day = 0;
    decimal total_21day = 0;
    decimal total_22day = 0;
    decimal total_23day = 0;
    decimal total_24day = 0;
    decimal total_25day = 0;
    decimal total_26day = 0;
    decimal total_27day = 0;
    decimal total_28day = 0;
    decimal total_29day = 0;
    decimal total_30day = 0;
    decimal total_31day = 0;
    decimal total_grtotal = 0;
    #endregion

    protected void grdrept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl1st = (Label)e.Row.FindControl("lbl1st");
            total_1day += Convert.ToDecimal(lbl1st.Text);

            Label lbl2st = (Label)e.Row.FindControl("lbl2st");
            total_2day += Convert.ToDecimal(lbl2st.Text);

            Label lbl3st = (Label)e.Row.FindControl("lbl3st");
            total_3day += Convert.ToDecimal(lbl3st.Text);

            Label lbl4st = (Label)e.Row.FindControl("lbl4st");
            total_4day += Convert.ToDecimal(lbl4st.Text);

            Label lbl5st = (Label)e.Row.FindControl("lbl5st");
            total_5day += Convert.ToDecimal(lbl5st.Text);

            Label lbl6st = (Label)e.Row.FindControl("lbl6st");
            total_6day += Convert.ToDecimal(lbl6st.Text);

            Label lbl7st = (Label)e.Row.FindControl("lbl7st");
            total_7day += Convert.ToDecimal(lbl7st.Text);

            Label lbl8st = (Label)e.Row.FindControl("lbl8st");
            total_8day += Convert.ToDecimal(lbl8st.Text);

            Label lbl9st = (Label)e.Row.FindControl("lbl9st");
            total_9day += Convert.ToDecimal(lbl9st.Text);

            Label lbl10st = (Label)e.Row.FindControl("lbl10st");
            total_10day += Convert.ToDecimal(lbl10st.Text);

            Label lbl11st = (Label)e.Row.FindControl("lbl11st");
            total_11day += Convert.ToDecimal(lbl11st.Text);

            Label lbl12st = (Label)e.Row.FindControl("lbl12st");
            total_12day += Convert.ToDecimal(lbl12st.Text);

            Label lbl13st = (Label)e.Row.FindControl("lbl13st");
            total_13day += Convert.ToDecimal(lbl13st.Text);

            Label lbl14st = (Label)e.Row.FindControl("lbl14st");
            total_14day += Convert.ToDecimal(lbl14st.Text);

            Label lbl15st = (Label)e.Row.FindControl("lbl15st");
            total_15day += Convert.ToDecimal(lbl15st.Text);

            Label lbl16st = (Label)e.Row.FindControl("lbl16st");
            total_16day += Convert.ToDecimal(lbl16st.Text);

            Label lbl17st = (Label)e.Row.FindControl("lbl17st");
            total_17day += Convert.ToDecimal(lbl17st.Text);

            Label lbl18st = (Label)e.Row.FindControl("lbl18st");
            total_18day += Convert.ToDecimal(lbl18st.Text);

            Label lbl19st = (Label)e.Row.FindControl("lbl19st");
            total_19day += Convert.ToDecimal(lbl19st.Text);

            Label lbl20st = (Label)e.Row.FindControl("lbl20st");
            total_20day += Convert.ToDecimal(lbl20st.Text);

            Label lbl21st = (Label)e.Row.FindControl("lbl21st");
            total_21day += Convert.ToDecimal(lbl21st.Text);

            Label lbl22st = (Label)e.Row.FindControl("lbl22st");
            total_22day += Convert.ToDecimal(lbl22st.Text);

            Label lbl23st = (Label)e.Row.FindControl("lbl23st");
            total_23day += Convert.ToDecimal(lbl23st.Text);

            Label lbl24st = (Label)e.Row.FindControl("lbl24st");
            total_24day += Convert.ToDecimal(lbl24st.Text);

            Label lbl25st = (Label)e.Row.FindControl("lbl25st");
            total_25day += Convert.ToDecimal(lbl25st.Text);

            Label lbl26st = (Label)e.Row.FindControl("lbl26st");
            total_26day += Convert.ToDecimal(lbl26st.Text);

            Label lbl27st = (Label)e.Row.FindControl("lbl27st");
            total_27day += Convert.ToDecimal(lbl27st.Text);

            Label lbl28st = (Label)e.Row.FindControl("lbl28st");
            total_28day += Convert.ToDecimal(lbl28st.Text);

            Label lbl29st = (Label)e.Row.FindControl("lbl29st");
            total_29day += Convert.ToDecimal(lbl29st.Text);

            Label lbl30st = (Label)e.Row.FindControl("lbl30st");
            total_30day += Convert.ToDecimal(lbl30st.Text);

            Label lbl31st = (Label)e.Row.FindControl("lbl31st");
            total_31day += Convert.ToDecimal(lbl31st.Text);


            Label lbltotal = (Label)e.Row.FindControl("lbltotal");
            total_grtotal += Convert.ToDecimal(lbltotal.Text);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotal1 = (Label)e.Row.FindControl("lbltotal1");
            Label lbltotal2 = (Label)e.Row.FindControl("lbltotal2");
            Label lbltotal3 = (Label)e.Row.FindControl("lbltotal3");
            Label lbltotal4 = (Label)e.Row.FindControl("lbltotal4");
            Label lbltotal5 = (Label)e.Row.FindControl("lbltotal5");
            Label lbltotal6 = (Label)e.Row.FindControl("lbltotal6");
            Label lbltotal7 = (Label)e.Row.FindControl("lbltotal7");
            Label lbltotal8 = (Label)e.Row.FindControl("lbltotal8");
            Label lbltotal9 = (Label)e.Row.FindControl("lbltotal9");
            Label lbltotal10 = (Label)e.Row.FindControl("lbltotal10");
            Label lbltotal11 = (Label)e.Row.FindControl("lbltotal11");
            Label lbltotal12 = (Label)e.Row.FindControl("lbltotal12");
            Label lbltotal13 = (Label)e.Row.FindControl("lbltotal13");
            Label lbltotal14 = (Label)e.Row.FindControl("lbltotal14");
            Label lbltotal15 = (Label)e.Row.FindControl("lbltotal15");
            Label lbltotal16 = (Label)e.Row.FindControl("lbltotal16");
            Label lbltotal17 = (Label)e.Row.FindControl("lbltotal17");
            Label lbltotal18 = (Label)e.Row.FindControl("lbltotal18");
            Label lbltotal19 = (Label)e.Row.FindControl("lbltotal19");
            Label lbltotal20 = (Label)e.Row.FindControl("lbltotal20");
            Label lbltotal21 = (Label)e.Row.FindControl("lbltotal21");
            Label lbltotal22 = (Label)e.Row.FindControl("lbltotal22");
            Label lbltotal23 = (Label)e.Row.FindControl("lbltotal23");
            Label lbltotal24 = (Label)e.Row.FindControl("lbltotal24");
            Label lbltotal25 = (Label)e.Row.FindControl("lbltotal25");
            Label lbltotal26 = (Label)e.Row.FindControl("lbltotal26");
            Label lbltotal27 = (Label)e.Row.FindControl("lbltotal27");
            Label lbltotal28 = (Label)e.Row.FindControl("lbltotal28");
            Label lbltotal29 = (Label)e.Row.FindControl("lbltotal29");
            Label lbltotal30 = (Label)e.Row.FindControl("lbltotal30");
            Label lbltotal31 = (Label)e.Row.FindControl("lbltotal31");
            Label lblgrandtotal = (Label)e.Row.FindControl("lblgrandtotal");


            lbltotal1.Text = total_1day.ToString();
            lbltotal2.Text = total_2day.ToString();
            lbltotal3.Text = total_3day.ToString();
            lbltotal4.Text = total_4day.ToString();
            lbltotal5.Text = total_5day.ToString();
            lbltotal6.Text = total_6day.ToString();
            lbltotal7.Text = total_7day.ToString();
            lbltotal8.Text = total_8day.ToString();
            lbltotal9.Text = total_9day.ToString();
            lbltotal10.Text = total_10day.ToString();
            lbltotal11.Text = total_11day.ToString();
            lbltotal12.Text = total_12day.ToString();
            lbltotal13.Text = total_13day.ToString();
            lbltotal14.Text = total_14day.ToString();
            lbltotal15.Text = total_15day.ToString();
            lbltotal16.Text = total_16day.ToString();
            lbltotal17.Text = total_17day.ToString();
            lbltotal18.Text = total_18day.ToString();
            lbltotal19.Text = total_19day.ToString();
            lbltotal20.Text = total_20day.ToString();
            lbltotal21.Text = total_21day.ToString();
            lbltotal22.Text = total_22day.ToString();
            lbltotal23.Text = total_23day.ToString();
            lbltotal24.Text = total_24day.ToString();
            lbltotal25.Text = total_25day.ToString();
            lbltotal26.Text = total_26day.ToString();
            lbltotal27.Text = total_27day.ToString();
            lbltotal28.Text = total_28day.ToString();
            lbltotal29.Text = total_29day.ToString();
            lbltotal30.Text = total_30day.ToString();
            lbltotal31.Text = total_31day.ToString();
            lblgrandtotal.Text = total_grtotal.ToString();



        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if ((ddlyear.SelectedIndex > 0) && (ddlMonth1bymonth.SelectedIndex > 0))
        {
            BillingAmount();
            getmonthly_report_branchwise();
            AdjucementReport(0);
            divReport.Visible = true;
        }
        else
        {
            lblmess.Text = "You have choose incorrect values";
            grdrept.DataSource = null;
            grdrept.DataBind();
            trexcel.Visible = false;
            divReport.Visible = false;
        }
    }

    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ExportToExcel.ExportToExcelGridView(grdrept);

        }
        catch (Exception ex)
        {
            ex = null;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

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

        ddlyear.DataSource = dsYear.Tables[0];
        ddlyear.DataTextField = "yearVal";
        ddlyear.DataValueField = "yearTxt";
        ddlyear.DataBind();
        //ddlyear.SelectedIndex = 0;




    }

    public void ErrorLog(string Message)
    {
        StreamWriter sw = null;

        try
        {
            string sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string sPathName = "~/ErrorLog.txt";
            if ((!File.Exists(System.Web.HttpContext.Current.Server.MapPath(sPathName))))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(sPathName)).Close();
            }
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();

            string sErrorTime = sDay + "-" + sMonth + "-" + sYear;
            using (sw = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(sPathName)))
            {
                //sw = new StreamWriter(sPathName + "ContractReport_ErrorLog_" + sErrorTime + ".txt", true);
                sw.WriteLine("Log Entry : ");
                sw.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() + sLogFormat + ". Error Message:" + Message;
                sw.WriteLine(err);


                sw.WriteLine(sLogFormat + Message);
                sw.WriteLine("__________________________");
                sw.Flush();
            }

        }
        catch (Exception ex)
        {
            ErrorLog(ex.ToString());
        }
        finally
        {
            if (sw != null)
            {
                sw.Dispose();
                sw.Close();
            }
        }


    }

    private void AdjucementReport(int BranchID)
    {
        try
        {

        string branchname = string.Empty;
        decimal _footertotalbranch = 0;
        string fromdate = string.Empty;
        string todate = string.Empty;
        int days = DateTime.DaysInMonth(Convert.ToInt32(ddlyear.SelectedValue), Convert.ToInt32(ddlMonth1bymonth.SelectedValue));
        fromdate = Convert.ToInt32(ddlyear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth1bymonth.SelectedValue) + "-" + "01";
        todate = Convert.ToInt32(ddlyear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth1bymonth.SelectedValue) + "-" + days.ToString();

        Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
        DataSet ds_all = new DataSet();
        ds_all = cre.Get_Daily_Credit_Report_Branch_new(fromdate, todate, BranchID);
        if (ds_all.Tables[0].Rows.Count > 0 )
        {
             object value = ds_all.Tables[0].Rows[0]["totalamt"];
             if (value == DBNull.Value)
             {
                 _footertotalbranch += Convert.ToDecimal("0.00");
             }
             else
             {
                 _footertotalbranch = Convert.ToDecimal(ds_all.Tables[0].Rows[0]["totalamt"]);
             }
           
        }
        decimal _totalamt = Convert.ToDecimal("0.00");
        decimal amountdiff = Convert.ToDecimal("0.00");

        DataSet dsrpt = new DataSet();
        dsrpt = cre.GetCollection_rpt_Monthly(ddlMonth1bymonth.SelectedValue.ToString(), ddlyear.SelectedValue.ToString(), "month");

        if (dsrpt.Tables["month"].Rows.Count > 0)
        {
            foreach (DataRow _dr in dsrpt.Tables["month"].Rows)
            {   object value = _dr["Amount"];
            if (value == DBNull.Value)
            {
                _totalamt += Convert.ToDecimal("0.00");
            }
            else
            {
                _totalamt += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
            }
            }
        }
        lbltotalcollection.Text = _totalamt.ToString();
        lbltotalarjusted.Text = _footertotalbranch.ToString();
        amountdiff = _totalamt - _footertotalbranch;
        trAdjucement.Visible = true;
        lblunarjsustedamt.Text = amountdiff.ToString();
        }

        catch (Exception ex)
        {

            ex = null;
        }
    }
    private void BillingAmount()
    {
        Clay.Sale.Bll.CreditDetail obj = new Clay.Sale.Bll.CreditDetail();
        int currentmonth = Convert.ToInt32(ddlMonth1bymonth.SelectedValue);
        int currentYear = Convert.ToInt32(ddlyear.SelectedValue);
        int previousmonth = 0;
        int previousYear = currentYear;
        if (currentmonth == 1)
        {
            previousmonth = 12;
            previousYear = currentYear - 1;
        }
        else
        {
            previousmonth = currentmonth - 1;
        }

        DataSet dsBilling = new DataSet();
        dsBilling = obj.GetBillingAmountByMonthYear(currentmonth, currentYear, previousmonth, previousYear);
        if (dsBilling.Tables[0].Rows.Count > 0)
        {
            lblcurrentmonthBilling.Text = Convert.ToString(dsBilling.Tables[0].Rows[0]["totalAmount"]);
        }
        else
        {
            lblcurrentmonthBilling.Text = "0.00";
        }
        if (dsBilling.Tables[1].Rows.Count > 0)
        {
            lblPreviousmonthBilling.Text = Convert.ToString(dsBilling.Tables[1].Rows[0]["totalAmount"]);
        }
        else
        {
            lblPreviousmonthBilling.Text = "0.00";
        }
    }

}