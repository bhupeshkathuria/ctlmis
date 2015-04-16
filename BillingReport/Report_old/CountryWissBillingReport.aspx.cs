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
                panelChart2.Visible = false;
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

                    Session["FromDate"] = fromYear + "-" + "04" + "-" + "01";
                    Session["ToDate"] = toYear + "-" + "03" + "-" + "31";
                    //Session["Month"] = Convert.ToInt32(Session["Month"].ToString());

                    dsDetails = objDashBoard.GetBillingDetailsBasedOnFinancialYear();
                    if (dsDetails.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Text = "";
                        dtAllCountryDetails = dsDetails.Tables[0];
                        Session["CountryDetails"] = dtAllCountryDetails;
                        DrawGraph();
                        PanelCharT1.Visible = true;

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
                            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                            Chart1.Series["Series1"]["PointWidth"] = "0.6";
                            Unit height = new Unit(600);
                            Chart1.Height = height;
                            title.Text = "Country (Year Wise) Contribution";
                            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            Chart1.Titles[0] = title;
                            drpTopValue.Visible = true;
                        }
                        else
                        {
                            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                            Chart1.Series["Series1"]["PointWidth"] = "0.6";
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
                        Chart1.Series["Series1"]["PointWidth"] = "0.6";
                        Unit height = new Unit(800);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    else if (TopValue == 20)
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Chart1.Series["Series1"]["PointWidth"] = "0.6";
                        Unit height = new Unit(1200);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    else
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Chart1.Series["Series1"]["PointWidth"] = "0.4";
                        Unit height = new Unit(2000);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    if (rbtrupees.Checked == true)
                    {
                        Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amount");
                        Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                        Chart1.Series["Series1"].LabelFormat = "{0:n2}";

                        Chart1.Series["Series2"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "servicetaxamount");
                        Chart1.Series["Series2"].PostBackValue = "#AXISLABEL";
                        Chart1.Series["Series2"].LabelFormat = "{0:n2}";
                    }
                    if (rbtPercentage.Checked == true)
                    {
                        Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amountper");
                        Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                        Chart1.Series["Series1"].LabelFormat = "{0:n2}" + "%";

                        Chart1.Series["Series2"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "servicetaxamount");
                        Chart1.Series["Series2"].PostBackValue = "#AXISLABEL";
                        Chart1.Series["Series2"].LabelFormat = "{0:n2}" + "%";
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
        DrawGraph();
        panelChart2.Visible = true;
        panelChart2LastYear.Visible = true;
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
        
        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetails"];

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        PanelCountryName.Visible = true;
        
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

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["CountryName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
                dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]);
            }

        }
        DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;

        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
        Unit height = new Unit(600);
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

        if (rbtnpersentagemonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxamount");
            ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonthServicesTax"].LabelFormat = "{0:n2}" + "%";
        }
        else
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
            ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = "0.6";
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

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetailsLastYear"];

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        panelChart2LastYear.Visible = true;
        PanelCountryNameLastYear.Visible = true;
        PanelLastYear.Visible = true;

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

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["CountryName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
                dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]);
            }

        }
        DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.IsMarginVisible = false;

        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.Interval = .5;
        Unit height = new Unit(600);
        ChartMonthLastYear.Height = height;
        title.Text = "Country (Last Year Month Wise) Contribution";
        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        ChartMonthLastYear.Titles[0] = title;

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
            ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = "0.6";
            ChartMonthLastYear.Series["SeriesMonthLastYear"].LabelFormat = "{0:n2}" + "%";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxamount");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = "0.6";
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].LabelFormat = "{0:n2}" + "%";
        }
        else
        {
            ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
            ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = "0.6";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "servicetaxamount");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = "0.6";
        }
    }

    protected void DisplayMonthWiseCountryBillingReport(string countryName)
    {
        try
        {
            objDashBoard.Fromdate = Session["FromDate"].ToString();
            objDashBoard.Todate = Session["ToDate"].ToString();
            objDashBoard.CountryName = countryName.Trim();
            dsCountryDetailsMonthWise = objDashBoard.GetYearBillingDetailsBasedOnCountry();
            if (dsCountryDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                Session["MonthDetails"] = dsCountryDetailsMonthWise.Tables[0];
                Session["MonthDetailsLastYear"] = dsCountryDetailsMonthWise.Tables[1];
                lblCountryName.Text = countryName.Trim() + " " + Session["Fyear"].ToString();
                lblCountryNameLastYear.Text = countryName.Trim() + " " + GetLastYear(Session["Fyear"].ToString());
                DrawMonthWiseLastYear();
                panelChart2LastYear.Visible = true;
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

    protected string  GetLastYear(string year)
    {
        string retval = year;
        string[] str = year.Split('-');
        int getYearVale =Convert.ToInt32(str[0]);

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

    protected void rbtRupeesmonthLastYear_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseLastYear();
        DrawMonthWise();
    }
    protected void rbtnpersentagemonthLastYear_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseLastYear();
        DrawMonthWise();
    }
}