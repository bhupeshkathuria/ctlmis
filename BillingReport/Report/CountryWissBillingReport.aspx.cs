using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
public partial class Report_CountryWissBillingReport : System.Web.UI.Page
{
    ClayBillingLibrary.Report.DashBoard objDashBoard = new ClayBillingLibrary.Report.DashBoard();
    DataSet dsDetails = new DataSet();
    DataTable dtCountryDetails = new DataTable();
    DataTable dtCountryName = new DataTable();
    double totalAllCountryAmount = 0;
    DataSet dsCountryDetailsMonthWise = new DataSet();
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userId = Convert.ToInt32(Session["UserId"]);
        }
        catch (Exception ex)
        {
            userId = 0;
        }

        if (userId == 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        else
        {
        }

        if (!Page.IsPostBack)
        {
            try
            {
                //panelChart2.Visible = false;
                string _fYear = Session["Fyear"].ToString();
                Session["Fyear"] = _fYear;
                string fromYear, toYear;
                string[] yearArray = _fYear.Split('-');

                DataTable dtAllCountryDetails = new DataTable();
                dtAllCountryDetails.Columns.Add("countryid", typeof(Int32));
                dtAllCountryDetails.Columns.Add("countryname", typeof(string));
                dtAllCountryDetails.Columns.Add("amount", typeof(double));
                dtAllCountryDetails.Columns.Add("amountper", typeof(double));

                if (yearArray.Length > 1)
                {
                    fromYear = yearArray[0].ToString();
                    toYear = yearArray[1].ToString();

                    objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
                    objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";
                    objDashBoard.MonthID = Convert.ToInt32(Session["Month"].ToString());
                    objDashBoard.PCustomerType = Convert.ToInt32(Session["CustomerType"].ToString());

                    Session["FromDate"] = fromYear + "-" + "04" + "-" + "01";
                    Session["ToDate"] = toYear + "-" + "03" + "-" + "31";
                    //Session["Month"] = Convert.ToInt32(Session["Month"].ToString());

                    dsDetails = objDashBoard.GetBillingDetailsBasedOnFinancialYear();
                    if (dsDetails.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        dtAllCountryDetails = dsDetails.Tables[0];
                        Session["CountryDetails"] = dtAllCountryDetails;
                        rbtrupees.Checked = true;
                        PanelMonthWiseCountryBilling.Visible = false;
                        PanelLastMonthWiseCountryBilling.Visible = false ;
                        DrawGraph();
                        //PanelCharT1.Visible = true;

                    }
                    else
                    {
                        lblMsg.Text = "No records to display!";
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "Please Select financial year !";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
    }


    protected void drpTopValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }

    protected void DrawGraph()
    {
        try
        {
            lblMsg.Text = "";
            int TopValue = Convert.ToInt32(drpTopValue.SelectedValue);

            System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
            title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
            title.ShadowOffset = 0;
            title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title.Alignment = System.Drawing.ContentAlignment.TopCenter;

            DataTable dtGetCountryDetails = new DataTable();
            dtGetCountryDetails = (DataTable)Session["CountryDetails"];

            DataView dvAllCountryAmount = new DataView(dtGetCountryDetails);
            dvAllCountryAmount.Sort = "amount ASC";

            DataTable dtCreateCountry = new DataTable();
            dtCreateCountry.Columns.Add("countryname");
            dtCreateCountry.Columns.Add("amount");
            dtCreateCountry.Columns.Add("amountper");
            dtCreateCountry.Columns.Add("servicetaxamount");
            dtCreateCountry.Columns.Add("countorder");
            dtCreateCountry.Columns.Add("ARPU");


            if (dvAllCountryAmount.Count > 0)
            {
                int totalCountryRows = dvAllCountryAmount.Count;

                if (totalCountryRows > 5)
                {
                    int totalCountry = dvAllCountryAmount.Count;
                    TopValue = TopValue == 0 ? totalCountry : TopValue;
                    for (int j = (totalCountry - TopValue); j < totalCountry; j++)
                    {
                        if (j < 0)
                        {
                            j = 0;
                        }
                        dtCreateCountry.ImportRow(dvAllCountryAmount[j].Row);

                    }
                }
                else
                {
                    for (int j = 0; j < dvAllCountryAmount.Count; j++)
                    {
                        dtCreateCountry.ImportRow(dvAllCountryAmount[j].Row);
                    }
                }

                DataView dvCountry = new DataView(dtCreateCountry);
                Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

                if (TopValue == 10)
                {
                    if (totalCountryRows > 5)
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "M";

                        Unit height = new Unit(900);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                        Chart1.Titles[0] = title;
                        drpTopValue.Visible = true;
                    }
                    else
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Unit height = new Unit(600);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                        drpTopValue.Visible = false;
                    }

                }
                else if (TopValue == 15)
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    Unit height = new Unit(800);
                    Chart1.Height = height;
                    title.Text = "Country (Year Wise) Contribution";
                    Chart1.Titles[0] = title;
                }
                else if (TopValue == 20)
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    Unit height = new Unit(1200);
                    Chart1.Height = height;
                    title.Text = "Country (Year Wise) Contribution";
                    Chart1.Titles[0] = title;
                }
                else
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    Unit height = new Unit(2500);
                    Chart1.Height = height;
                    title.Text = "Country (Year Wise) Contribution";
                    Chart1.Titles[0] = title;
                }

                Chart1.Series["Billing"]["PointWidth"] = ".9";
                Chart1.Series["ServiceTax"]["PointWidth"] = ".9";
                Chart1.Series["Orders"]["PointWidth"] = ".9";
                Chart1.Series["ARPU"]["PointWidth"] = ".9";


                if (rbtPercentage.Checked == true)
                {
                    Chart1.Series["Billing"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amountper");
                    Chart1.Series["Billing"].PostBackValue = "#AXISLABEL";
                    Chart1.Series["Billing"].LabelFormat = "{0:n2}" + "%";

                    Chart1.Series["ServiceTax"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "servicetaxamount");
                    Chart1.Series["ServiceTax"].PostBackValue = "#AXISLABEL";
                    Chart1.Series["ServiceTax"].LabelFormat = "{0:n2}" + "%";

                    Chart1.Series["Orders"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "countorder");
                    Chart1.Series["Orders"].PostBackValue = "#AXISLABEL";
                    Chart1.Series["Orders"].LabelFormat = "{0:n2}";

                    Chart1.Series["ARPU"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "ARPU");
                    Chart1.Series["ARPU"].PostBackValue = "#AXISLABEL";
                }
                else
                {
                    Chart1.Series["Billing"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amount");
                    Chart1.Series["Billing"].PostBackValue = "#AXISLABEL";
                    Chart1.Series["Billing"].LabelFormat = "{0:n2}";

                    Chart1.Series["ServiceTax"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "servicetaxamount");
                    Chart1.Series["ServiceTax"].PostBackValue = "#AXISLABEL";
                    Chart1.Series["ServiceTax"].LabelFormat = "{0:n2}";

                    Chart1.Series["Orders"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "countorder");
                    Chart1.Series["Orders"].PostBackValue = "#AXISLABEL";

                    Chart1.Series["ARPU"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "ARPU");
                    Chart1.Series["ARPU"].PostBackValue = "#AXISLABEL";

                }
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        string getCountryName = e.PostBackValue;
        Session["CountryName"] = getCountryName;
        DisplayMonthWiseCountryBillingReport(getCountryName);
        rbtrupees.Checked = true;
        DrawGraph();
        PanelMonthWiseCountryBilling.Visible = true;
        PanelLastMonthWiseCountryBilling.Visible = true;
        lblMsg.Text = "";
    }

    protected void rbtrupees_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }
    protected void rbtPercentage_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }

    protected void DrawMonthWise()
    {
        DataTable dtCountryDetailsMonthWise = new DataTable();
        dtCountryDetailsMonthWise.Columns.Add("getmonth", typeof(int));
        dtCountryDetailsMonthWise.Columns.Add("getmonthname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("countryname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("amount", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("amountper", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));
        dtCountryDetailsMonthWise.Columns.Add("servicetaxamount", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("countorder");
        dtCountryDetailsMonthWise.Columns.Add("ARPU");

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetails"];

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        //PanelCountryName.Visible = true;

        string[] MonthArrayVal = new string[] { "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        for (int i = 1; i <= 12; i++)
        {
            DataRow[] dtRowDetails = dtMonthDetails.Select("getmonth=" + i);

            if (dtRowDetails.Length == 1)
            {
                dtCountryDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
                dtCountryDetailsMonthWise.ImportRow(dtRowDetails[0]);

                dtCountryDetailsMonthWise.AcceptChanges();
            }
            else
            {
                DataTable createtablenew = new DataTable();
                createtablenew.Columns.Add("getmonth", typeof(int));
                createtablenew.Columns.Add("getmonthname", typeof(string));
                createtablenew.Columns.Add("countryname", typeof(string));
                createtablenew.Columns.Add("amount", typeof(double));
                createtablenew.Columns.Add("amountper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Columns.Add("servicetaxamount", typeof(double));
                createtablenew.Columns.Add("countorder");
                createtablenew.Columns.Add("ARPU");

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["CountryName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
                dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]);
            }

        }
        DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;

        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
        Unit height = new Unit(1200);
        ChartMonth.Height = height;
        title.Text = "Country (Month Wise) Contribution";
        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        ChartMonth.Titles[0] = title;

        //if (rbtRupeesmonth.Checked == true)
        //{
        //    ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
        //    ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";

        //    ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
        //    ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = "0.6";
        //}

        ChartMonth.Series["SeriesMonth"]["PointWidth"] = ".9";
        ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = ".9";
        ChartMonth.Series["Orders"]["PointWidth"] = ".9";
        ChartMonth.Series["ARPU"]["PointWidth"] = ".9";

        if (rbtnpersentagemonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amountper");
            ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
            ChartMonth.Series["SeriesMonthServicesTax"].LabelFormat = "{0:n2}" + "%";

            ChartMonth.Series["Orders"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "countorder");
            ChartMonth.Series["Orders"].PostBackValue = "#AXISLABEL";

            ChartMonth.Series["ARPU"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "ARPU");
            ChartMonth.Series["ARPU"].PostBackValue = "#AXISLABEL";
        }
        else
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
            ChartMonth.Series["SeriesMonth"].PostBackValue = "#AXISLABEL";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
            ChartMonth.Series["SeriesMonthServicesTax"].PostBackValue = "#AXISLABEL";

            ChartMonth.Series["Orders"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "countorder");
            ChartMonth.Series["Orders"].PostBackValue = "#AXISLABEL";

            ChartMonth.Series["ARPU"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "ARPU");
            ChartMonth.Series["ARPU"].PostBackValue = "#AXISLABEL";
        }
    }

    protected void DrawMonthWiseLastYear()
    {
        DataTable dtCountryDetailsMonthWise = new DataTable();
        dtCountryDetailsMonthWise.Columns.Add("getmonth", typeof(int));
        dtCountryDetailsMonthWise.Columns.Add("getmonthname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("countryname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("amount", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("amountper", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));
        dtCountryDetailsMonthWise.Columns.Add("servicetaxamount", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("countorder");
        dtCountryDetailsMonthWise.Columns.Add("ARPU");

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetailsLastYear"];

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        //panelChart2LastYear.Visible = true;
        //PanelCountryNameLastYear.Visible = true;
        //PanelLastYear.Visible = true;

        string[] MonthArrayVal = new string[] { "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        for (int i = 1; i <= 12; i++)
        {
            DataRow[] dtRowDetails = dtMonthDetails.Select("getmonth=" + i);

            if (dtRowDetails.Length == 1)
            {
                dtCountryDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
                dtCountryDetailsMonthWise.ImportRow(dtRowDetails[0]);

                dtCountryDetailsMonthWise.AcceptChanges();
            }
            else
            {
                DataTable createtablenew = new DataTable();
                createtablenew.Columns.Add("getmonth", typeof(int));
                createtablenew.Columns.Add("getmonthname", typeof(string));
                createtablenew.Columns.Add("countryname", typeof(string));
                createtablenew.Columns.Add("amount", typeof(double));
                createtablenew.Columns.Add("amountper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Columns.Add("servicetaxamount", typeof(double));
                createtablenew.Columns.Add("countorder");
                createtablenew.Columns.Add("ARPU");

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["CountryName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
                dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]);
            }

        }
        DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.IsMarginVisible = false;

        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.Interval = .5;
        Unit height = new Unit(1200);
        ChartMonthLastYear.Height = height;
        title.Text = "Country (Last Year Month Wise) Contribution";
        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        ChartMonthLastYear.Titles[0] = title;

        ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = ".9";
        ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = ".9";
        ChartMonthLastYear.Series["Orders"]["PointWidth"] = ".9";
        ChartMonthLastYear.Series["ARPU"]["PointWidth"] = ".9";

        //if (rbtRupeesmonthLastYear.Checked == true)
        //{
        //    ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
        //    ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = "0.6";

        //    ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
        //    ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = "0.6";
        //}

        if (rbtnpersentagemonthLastYear.Checked == true)
        {
            ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
            ChartMonthLastYear.Series["SeriesMonthLastYear"].LabelFormat = "{0:n2}" + "%";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxamount");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].LabelFormat = "{0:n2}" + "%";

            ChartMonthLastYear.Series["Orders"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "countorder");
            ChartMonthLastYear.Series["Orders"].PostBackValue = "#AXISLABEL";

            ChartMonthLastYear.Series["ARPU"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "ARPU");
            ChartMonthLastYear.Series["ARPU"].PostBackValue = "#AXISLABEL";
        }
        else
        {
            ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
            ChartMonthLastYear.Series["SeriesMonthLastYear"].PostBackValue = "#AXISLABEL";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].PostBackValue = "#AXISLABEL";

            ChartMonthLastYear.Series["Orders"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "countorder");
            ChartMonthLastYear.Series["Orders"].PostBackValue = "#AXISLABEL";

            ChartMonthLastYear.Series["ARPU"].Points.DataBindXY(dvdetails, "countryname", dvdetails, "ARPU");
            ChartMonthLastYear.Series["ARPU"].PostBackValue = "#AXISLABEL";
        }
    }

    protected void DisplayMonthWiseCountryBillingReport(string countryName)
    {
        try
        {
            objDashBoard.Fromdate = Session["FromDate"].ToString();
            objDashBoard.Todate = Session["ToDate"].ToString();
            objDashBoard.CountryName = countryName.Trim();
            objDashBoard.PCustomerType = Convert.ToInt32(Session["CustomerType"].ToString());
            dsCountryDetailsMonthWise = objDashBoard.GetYearBillingDetailsBasedOnCountry();
            if (dsCountryDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                Session["MonthDetails"] = dsCountryDetailsMonthWise.Tables[0];
                Session["MonthDetailsLastYear"] = dsCountryDetailsMonthWise.Tables[1];
                lblCountryName.Text = countryName.Trim() + " " + Session["Fyear"].ToString();
                lblCountryNameLastYear.Text = countryName.Trim() + " " + GetLastYear(Session["Fyear"].ToString());
                DrawMonthWiseLastYear();
                //panelChart2LastYear.Visible = true;
                DrawMonthWise();
            }
            else
            {
                lblMsg.Text = "No records to display !";
                return;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }

    }

    protected string GetLastYear(string year)
    {
        string retval = year;
        string[] str = year.Split('-');
        int getYearVale = Convert.ToInt32(str[0]);

        retval = getYearVale - 1 + "-" + getYearVale;
        return retval;
    }

    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWise();
        DrawMonthWiseLastYear();
    }
    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWise();
        DrawMonthWiseLastYear();
    }

    //protected void rbtRupeesmonthLastYear_CheckedChanged(object sender, EventArgs e)
    //{
    //    DrawMonthWiseLastYear();
    //    DrawMonthWise();
    //}
    //protected void rbtnpersentagemonthLastYear_CheckedChanged(object sender, EventArgs e)
    //{
    //    DrawMonthWiseLastYear();
    //    DrawMonthWise();
    //}

    protected void ChartMonth_Click(object sender, ImageMapEventArgs e)
    {
        string getMonthName = e.PostBackValue;
        string[] str = lblCountryName.Text.Split(' ');
        string countryName = str[0];
        DisplayMonthWiseCountryBillingReport(countryName.Trim());
        DrawGraph();

        string _fYear = Session["Fyear"].ToString();
        Session["Fyear"] = _fYear;
        string fromYear, toYear;
        string[] yearArray = _fYear.Split('-');

        fromYear = yearArray[0].ToString();
        toYear = yearArray[1].ToString();

        objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
        objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";

        DataTable dtAllBranchDetails = new DataTable();
        objDashBoard.CountryName = countryName;
        objDashBoard.PMonthValue = GetMonthId(getMonthName);
        DataSet dsBranchDetails = objDashBoard.GetBranchBillingDetailsBasedMonthAndCountry();
        Session["BranchDetails"] = dsBranchDetails.Tables[0];

        DrawGraph_BranchBilling_Based_on_Month_And_Country(countryName, getMonthName, _fYear);
        lblMsg.Text = "";
        PanelBranchBilling_Main.Visible = true;
    }

    protected void ChartMonthLastYear_Click(object sender, ImageMapEventArgs e)
    {
        string getMonthName = e.PostBackValue;
        string[] str = lblCountryName.Text.Split(' ');
        string countryName = str[0];

        DisplayMonthWiseCountryBillingReport(countryName.Trim());
        DrawGraph();

        string _fYear = Session["Fyear"].ToString();
        Session["Fyear"] = _fYear;
        int fromYear, toYear;
        string[] yearArray = _fYear.Split('-');

        fromYear = Convert.ToInt32(yearArray[0].ToString())-1;
        toYear = Convert.ToInt32(yearArray[1].ToString())-1;

        string lastYear = fromYear.ToString() + "-" + toYear.ToString() ;

        objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
        objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";

        DataTable dtAllBranchDetails = new DataTable();
        objDashBoard.CountryName = countryName;
        objDashBoard.PMonthValue = GetMonthId(getMonthName);
        DataSet dsBranchDetails = objDashBoard.GetBranchBillingDetailsBasedMonthAndCountry();
        Session["BranchDetails"] = dsBranchDetails.Tables[0];

        DrawGraph_BranchBilling_Based_on_Month_And_Country(countryName, getMonthName, lastYear);
        lblMsg.Text = "";
        PanelBranchBilling_Main.Visible = true;
    }

    protected void DrawGraph_BranchBilling_Based_on_Month_And_Country(string CountryName, string getMonthName,string Fyear)
    {
        

        lblMsg.Text = "";
        int TopValue = 0;

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        DataTable dtGetBranchDetails = new DataTable();
        dtGetBranchDetails = (DataTable)Session["BranchDetails"];

        DataView dvAllBranchAmount = new DataView(dtGetBranchDetails);
        dvAllBranchAmount.Sort = "totalamount ASC";

        DataTable dtCreateNewBranch = new DataTable();
        dtCreateNewBranch.Columns.Add("branchname");
        dtCreateNewBranch.Columns.Add("totalamount");
        dtCreateNewBranch.Columns.Add("amountper");
        dtCreateNewBranch.Columns.Add("servicetaxinr");

        if (dvAllBranchAmount.Count > 0)
        {
            int totalBranchRows = dvAllBranchAmount.Count;
            if (totalBranchRows > 5)
            {
                int totalBranch = dvAllBranchAmount.Count;
                TopValue = TopValue == 0 ? totalBranch : TopValue;
                for (int j = (totalBranch - TopValue); j < totalBranch; j++)
                {
                    if (j < 0)
                    {
                        j = 0;
                    }
                    dtCreateNewBranch.ImportRow(dvAllBranchAmount[j].Row);
                }
            }
            else
            {
                for (int j = 0; j < dvAllBranchAmount.Count; j++)
                {
                    dtCreateNewBranch.ImportRow(dvAllBranchAmount[j].Row);
                }
            }

            string setMonthNameAndYear = getMonthName + " ( " + Fyear + " )";

            DataView dvBranch = new DataView(dtCreateNewBranch);
            ChartBranchBilling.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            ChartBranchBilling.ChartAreas["ChartArea1"].AxisX.Interval = .5;
            ChartBranchBilling.Series["Series1"]["PointWidth"] = "0.4";
            Unit height = new Unit(1200);
            ChartBranchBilling.Height = height;
            title.Text = "Branch Billing Month Wise Contribution : " + setMonthNameAndYear;
            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            ChartBranchBilling.Titles[0] = title;




            if (rbtPercentage.Checked == true)
            {
                ChartBranchBilling.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "amountper");
                ChartBranchBilling.Series["Series1"].PostBackValue = "#AXISLABEL";
                ChartBranchBilling.Series["Series1"].LabelFormat = "{0:n2}" + "%";

                ChartBranchBilling.Series["Series2"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "servicetaxinr");
                ChartBranchBilling.Series["Series2"].PostBackValue = "#AXISLABEL";
                ChartBranchBilling.Series["Series2"].LabelFormat = "{0:n2}" + "%";
            }
            else
            {

                ChartBranchBilling.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "totalamount");
                //ChartBranchBilling.Series["Series1"].PostBackValue = "#AXISLABEL";

                ChartBranchBilling.Series["Series2"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "servicetaxinr");
                //ChartBranchBilling.Series["Series2"].PostBackValue = "#AXISLABEL";
                ChartBranchBilling.Series["Series2"].LabelFormat = "{0:n2}";
            }
        }

    }

    private int GetMonthId(string monthName)
    {
        int returnMonthValue = 0;
        switch (monthName)
        {
            case "January":
                returnMonthValue = 1;
                break;
            case "February":
                returnMonthValue = 2;
                break;
            case "March":
                returnMonthValue = 3;
                break;
            case "April":
                returnMonthValue = 4;
                break;
            case "May":
                returnMonthValue = 5;
                break;
            case "June":
                returnMonthValue = 6;
                break;
            case "July":
                returnMonthValue = 7;
                break;
            case "August":
                returnMonthValue = 8;
                break;
            case "September":
                returnMonthValue = 9;
                break;
            case "October":
                returnMonthValue = 10;
                break;
            case "November":
                returnMonthValue = 11;
                break;
            case "December":
                returnMonthValue = 12;
                break;
        }

        return returnMonthValue;
    }
}