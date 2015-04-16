using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Report_DisplayBranchWiseSalesOfCountry : System.Web.UI.Page
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
            GetSalesDetails();
        }
    }

    private void GetSalesDetails()
    {
        DataTable dtAllCountryDetails = new DataTable();
        dtAllCountryDetails.Columns.Add("countryid", typeof(Int32));
        dtAllCountryDetails.Columns.Add("countryname", typeof(string));
        dtAllCountryDetails.Columns.Add("amount", typeof(double));
        dtAllCountryDetails.Columns.Add("amountper", typeof(double));

        panelChart2.Visible = false;
        string _fYear = Session["Fyear"].ToString();
        ViewState["Fyear"] = _fYear;
        string fromYear, toYear;
        string[] yearArray = _fYear.Split('-');

        if (yearArray.Length > 1)
        {
            fromYear = yearArray[0].ToString();
            toYear = yearArray[1].ToString();

            objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
            objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";
            objDashBoard.MonthID = Convert.ToInt32(Session["Month"].ToString());

            hiddenFromDate.Value = fromYear + "-" + "04" + "-" + "01";
            hiddenToDate.Value = toYear + "-" + "03" + "-" + "31";
            hiddenMonthValue.Value = Session["Month"].ToString();


            dsDetails = objDashBoard.GetSalesOfCountryBasedOnYearAndMonthly();
            if (dsDetails.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                dtAllCountryDetails = dsDetails.Tables[0];
                Session["CountryDetails"] = dtAllCountryDetails;
                DrawGraphOfCountry();
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

    protected void drpTopValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawGraphOfCountry();
    }
    protected void rbtrupees_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraphOfCountry();
    }
    protected void rbtPercentage_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraphOfCountry();
    }

    private void DrawGraphOfCountry()
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
        dvAllCountryAmount.Sort = "totalorder ASC";

        DataTable dtCreateCountry = new DataTable();
        dtCreateCountry.Columns.Add("countryname");
        dtCreateCountry.Columns.Add("totalorder");
        dtCreateCountry.Columns.Add("totalorderper");

        if (dvAllCountryAmount.Count > 0)
        {
            int totalCountryRows = dvAllCountryAmount.Count;

            if (totalCountryRows > 5)
            {
                int totalCountry = dvAllCountryAmount.Count;
                TopValue = TopValue == 0 ? totalCountry : TopValue;
                for (int j = (totalCountry - TopValue); j < totalCountry; j++)
                {
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
                    Unit height = new Unit(400);
                    Chart1.Height = height;
                    title.Text = "Country Sales Order";
                    title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    Chart1.Titles[0] = title;
                    drpTopValue.Visible = true;
                }
                else
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    Chart1.Series["Series1"]["PointWidth"] = "0.6";
                    Unit height = new Unit(200);
                    Chart1.Height = height;
                    title.Text = "Country Sales Order";
                    Chart1.Titles[0] = title;
                    drpTopValue.Visible = false;
                }

            }
            else if (TopValue == 15)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.6";
                Unit height = new Unit(600);
                Chart1.Height = height;
                title.Text = "Country Sales Order";
                Chart1.Titles[0] = title;
            }
            else if (TopValue == 20)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.6";
                Unit height = new Unit(800);
                Chart1.Height = height;
                title.Text = "Country Sales Order";
                Chart1.Titles[0] = title;
            }
            else
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.4";
                Unit height = new Unit(1200);
                Chart1.Height = height;
                title.Text = "Country Sales Order";
                Chart1.Titles[0] = title;
            }
            if (rbtrupees.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "totalorder");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
            }
            if (rbtPercentage.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "totalorderper");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                Chart1.Series["Series1"].LabelFormat = "{0:n2}" + "%";
            }
        }
    }
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        string getCountryName = e.PostBackValue;
        ViewState["CountryName"] = getCountryName;
        GetBranchWiseSalesOfCountry(getCountryName);
        DrawGraphOfCountry();
        panelChart2.Visible = true;
        lblMsg.Text = "";
    }

    private void GetBranchWiseSalesOfCountry(string countryName)
    {
        try
        {
            objDashBoard.Fromdate = hiddenFromDate.Value;
            objDashBoard.Todate = hiddenToDate.Value;
            objDashBoard.MonthID =Convert.ToInt32(hiddenMonthValue.Value);
            objDashBoard.CountryName = countryName.Trim();

            dsCountryDetailsMonthWise = objDashBoard.GetBranchWiseSalesDetailsOfCountry();
            if (dsCountryDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                Session["MonthDetails"] = dsCountryDetailsMonthWise.Tables[0];
                lblCountryName.Text = countryName.Trim() + " " + ViewState["Fyear"].ToString();
                Session["AllBranchId"] = dsCountryDetailsMonthWise.Tables[1];
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

    protected void DrawMonthWise()
    {
        DataTable dtCountryDetailsMonthWise = new DataTable();
        dtCountryDetailsMonthWise.Columns.Add("branchid", typeof(int));
        dtCountryDetailsMonthWise.Columns.Add("branchname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("countryname", typeof(string));
        dtCountryDetailsMonthWise.Columns.Add("totalorder", typeof(double));
        dtCountryDetailsMonthWise.Columns.Add("totalorderper", typeof(double));

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;


        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetails"];

        PanelCountryName.Visible = true;

        DataTable dt = (DataTable)Session["AllBranchId"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int branchId = Convert.ToInt32(dt.Rows[i]["branchid"]);
            string branchName = dt.Rows[i]["branchname"].ToString();

            DataRow[] dtRowDetails = dtMonthDetails.Select("branchid=" + branchId);

            if (dtRowDetails.Length > 0)
            {
                DataRow dr = dtCountryDetailsMonthWise.NewRow();
                dr["branchid"] = dtRowDetails[0]["branchId"];
                dr["branchname"] = dtRowDetails[0]["branchname"];
                dr["countryname"] = dtRowDetails[0]["countryname"];
                dr["totalorder"] = dtRowDetails[0]["totalorder"];
                dr["totalorderper"] = dtRowDetails[0]["totalorderper"];
                dtCountryDetailsMonthWise.Rows.Add(dr);
                dtCountryDetailsMonthWise.AcceptChanges();
            }
            else
            {
                DataRow dr = dtCountryDetailsMonthWise.NewRow();
                dr["branchid"] = branchId;
                dr["branchname"] = branchName;
                dr["countryname"] = ViewState["CountryName"].ToString();
                dr["totalorder"] = "0.00";
                dr["totalorderper"] = "0.00";
                dtCountryDetailsMonthWise.Rows.Add(dr);
                dtCountryDetailsMonthWise.AcceptChanges();
            }

        }

        //string[] MonthArrayVal = new string[] { "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        //string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        //for (int i = 1; i <= 12; i++)
        //{
        //    DataRow[] dtRowDetails = dtMonthDetails.Select("getmonth=" + i);

        //    if (dtRowDetails.Length == 1)
        //    {
        //        dtCountryDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
        //        dtCountryDetailsMonthWise.ImportRow(dtRowDetails[0]);

        //        dtCountryDetailsMonthWise.AcceptChanges();
        //    }
        //    else
        //    {
        //        DataTable createtablenew = new DataTable();
        //        createtablenew.Columns.Add("getmonth", typeof(int));
        //        createtablenew.Columns.Add("getmonthname", typeof(string));
        //        createtablenew.Columns.Add("countryname", typeof(string));
        //        createtablenew.Columns.Add("totalorder", typeof(double));
        //        createtablenew.Columns.Add("totalorderper", typeof(double));
        //        createtablenew.Columns.Add("monthserialno", typeof(Int16));
        //        createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], ViewState["CountryName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
        //        DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
        //        dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]);
        //    }
        //}


        DataTable dtNew = dtCountryDetailsMonthWise.Clone();

        DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
        dvdetails.Sort = "totalorder ASC";
        int TopValue = Convert.ToInt32(drpShowAllBranchSales.SelectedValue);

        if (dvdetails.Count > 0)
        {
            int totalBranchRows = dvdetails.Count;
            if (totalBranchRows > 5)
            {
                int totalBranch = dvdetails.Count;
                TopValue = TopValue == 0 ? totalBranch : TopValue;
                for (int j = (totalBranch - TopValue); j < totalBranch; j++)
                {
                    if (j < 0)
                    {
                        j = 0;
                    }
                    dtNew.ImportRow(dvdetails[j].Row);
                }
            }
            else
            {
                for (int j = 0; j < dvdetails.Count; j++)
                {
                    dtNew.ImportRow(dvdetails[j].Row);
                }
            }

            DataView dvdetailsNew = new DataView(dtNew);
            ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;

            if (TopValue == 10)
            {
                if (totalBranchRows > 5)
                {
                    ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
                    ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
                    Unit height = new Unit(400);
                    ChartMonth.Height = height;
                    title.Text = "Country-Branch Sales Order";
                    title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    ChartMonth.Titles[0] = title;
                    drpShowAllBranchSales.Visible = true;
                }
                else
                {
                    ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
                    ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
                    Unit height = new Unit(200);
                    ChartMonth.Height = height;
                    title.Text = "Country-Branch Sales Order";
                    ChartMonth.Titles[0] = title;
                    drpShowAllBranchSales.Visible = true;
                }
            }
            else
            {
                ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
                ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.4";
                Unit height = new Unit(600);
                ChartMonth.Height = height;
                title.Text = " Country-Branch Sales Order";
                ChartMonth.Titles[0] = title;
                drpShowAllBranchSales.Visible = true;
            }

            if (rbtRupeesmonth.Checked == true)
            {
                ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetailsNew, "branchname", dvdetailsNew, "totalorder");
                ChartMonth.Series["SeriesMonth"].PostBackValue = "#AXISLABEL";

                //ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
                //ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
                //Unit height = new Unit(400);
                //ChartMonth.Height = height;
                //title.Text = "Branch (Month Wise) Sales Order";
                //title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                //ChartMonth.Titles[0] = title;

            }

            if (rbtnpersentagemonth.Checked == true)
            {
                ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetailsNew, "branchname", dvdetailsNew, "totalorderper");
                ChartMonth.Series["SeriesMonth"].PostBackValue = "#AXISLABEL";
                ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";

                //ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
                //ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
                //Unit height = new Unit(400);
                //ChartMonth.Height = height;
                //title.Text = "Branch (Month Wise) Sales Order";
                //title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                //ChartMonth.Titles[0] = title;
            }

        }
    }

    protected void drpShowAllBranchSales_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawMonthWise();
    }
    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWise();
    }
    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWise();
    }
}