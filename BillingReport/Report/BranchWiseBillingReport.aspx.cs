using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
public partial class Report_BranchWiseBillingReport : System.Web.UI.Page
{
    ClayBillingLibrary.Report.DashBoard objDashBoard = new ClayBillingLibrary.Report.DashBoard();
    DataSet dsBranchDetails = new DataSet();
    DataSet dsBranchDetailsMonthWise = new DataSet();
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
                DisplayGraph();
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
    }

    protected void DisplayGraph()
    {
        string selectedFyear = Session["Fyear"].ToString();
        string fromYear, toYear;
        Session["Fyear"] = selectedFyear;
        string[] yearArray = selectedFyear.Split('-');

        if (yearArray.Length > 1)
        {
            fromYear = yearArray[0].ToString();
            toYear = yearArray[1].ToString();

            objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
            objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";
            objDashBoard.PMonthValue = Convert.ToInt32(Session["Month"].ToString());

            Session["FromDate"] = fromYear + "-" + "04" + "-" + "01";
            Session["ToDate"] = toYear + "-" + "03" + "-" + "31";
            Session["Month"] = Convert.ToInt32(Session["Month"].ToString());
            DataTable dtAllBranchDetails = new DataTable();
            dsBranchDetails = objDashBoard.GetBranchBillingDetailsBasedOnFinancialYear();
            if (dsBranchDetails.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                dtAllBranchDetails = dsBranchDetails.Tables[0];
                Session["BranchDetails"] = dtAllBranchDetails;
                DrawGraph();
                PanelCharT1.Visible = true;
            }
            else
            {
                lblMsg.Text = "No records to display !";
                return;
            }
        }

    }

    protected void DrawGraph()
    {
        lblMsg.Text = "";
        int TopValue = Convert.ToInt32(drpTopValue.SelectedValue);

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

            DataView dvBranch = new DataView(dtCreateNewBranch);
            Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
            if (TopValue == 10)
            {
                if (totalBranchRows > 5)
                {
                    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    Chart1.Series["Series1"]["PointWidth"] = "0.6";
                    Unit height = new Unit(600);
                    Chart1.Height = height;
                    title.Text = "Branch (Year Wise) Contribution";
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
                    title.Text = "Branch (Year Wise) Contribution";
                    Chart1.Titles[0] = title;
                    drpTopValue.Visible = false;
                }
            }
            else
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.4";
                Unit height = new Unit(1000);
                Chart1.Height = height;
                title.Text = "Branch (Year Wise) Contribution";
                Chart1.Titles[0] = title;
            }
            if (rbtrupees.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "totalamount");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";

                Chart1.Series["Series2"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "servicetaxinr");
                Chart1.Series["Series2"].PostBackValue = "#AXISLABEL";
                Chart1.Series["Series2"].LabelFormat = "{0:n2}";
            }
            if (rbtPercentage.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "amountper");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                Chart1.Series["Series1"].LabelFormat = "{0:n2}" + "%";

                Chart1.Series["Series2"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "servicetaxinr");
                Chart1.Series["Series2"].PostBackValue = "#AXISLABEL";
                Chart1.Series["Series2"].LabelFormat = "{0:n2}" + "%";
            }
        }
    
    }

    protected void drpTopValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }
    protected void rbtrupees_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }
    protected void rbtPercentage_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }


    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        try
        {
            string getBranchName = e.PostBackValue;
            Session["BranchName"] = getBranchName;
            DisplayMonthWiseBranchBillingReport();
            DrawGraph();
            panelChart2.Visible = true;
            lblMsg.Text = "";
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
    }

    protected void DisplayMonthWiseBranchBillingReport()
    {
        try
        {
            objDashBoard.Fromdate = Session["FromDate"].ToString();
            objDashBoard.Todate = Session["ToDate"].ToString();
            objDashBoard.BranchName = Session["BranchName"].ToString();
            dsBranchDetailsMonthWise = objDashBoard.GetMonthlyBillingDetailsBasedOnBranch();

            if (dsBranchDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                Session["MonthDetails"] = dsBranchDetailsMonthWise.Tables[0];
                Session["MonthDetailsLastYear"] = dsBranchDetailsMonthWise.Tables[1];
                DrawMonthWiseDetails();
                DrawMonthWiseDetailsLastYear();
            }
            else
            {
                lblMsg.Text = "No records to display !";
                return;
            }
        }
        catch( Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
    }

    protected void DrawMonthWiseDetails()
    {

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetails"];

        DataTable dtBranchDetailsMonthWise = new DataTable();
        dtBranchDetailsMonthWise.Columns.Add("monthid", typeof(int));
        dtBranchDetailsMonthWise.Columns.Add("monthidname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("branchname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("totalamount", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("amountper", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));
        dtBranchDetailsMonthWise.Columns.Add("servicetaxinr", typeof(double));

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        PanelBranchName.Visible = true;
        lblBranchName.Text = Session["BranchName"].ToString() + " " + Session["Fyear"].ToString();
        lblMsg.Text = "";
        string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        for (int i = 1; i <= 12; i++)
        {
            DataRow[] dtRowDetails = dtMonthDetails.Select("monthid=" + i);
            if (dtRowDetails.Length == 1)
            {
                dtBranchDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
                dtBranchDetailsMonthWise.ImportRow(dtRowDetails[0]);
                dtBranchDetailsMonthWise.AcceptChanges();
            }
            else
            {
                DataTable createtablenew = new DataTable();
                createtablenew.Columns.Add("monthid", typeof(int));
                createtablenew.Columns.Add("monthidname", typeof(string));
                createtablenew.Columns.Add("branchname", typeof(string));
                createtablenew.Columns.Add("totalamount", typeof(double));
                createtablenew.Columns.Add("amountper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Columns.Add("servicetaxinr", typeof(double));

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["BranchName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("monthid=" + i);
                dtBranchDetailsMonthWise.ImportRow(dtnewRow[0]);
            }
        }
        DataView dvdetails = new DataView(dtBranchDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;


        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
        Unit height = new Unit(600);
        ChartMonth.Height = height;
        title.Text = "Branch (Month Wise) Contribution";
        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        ChartMonth.Titles[0] = title;

        if (rbtRupeesmonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalamount");
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxinr");
            ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = "0.6";
        }

        if (rbtnpersentagemonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";

            ChartMonth.Series["SeriesMonthServicesTax"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxinr");
            ChartMonth.Series["SeriesMonthServicesTax"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonthServicesTax"].LabelFormat = "{0:n2}" + "%";
           
        }
    }

    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
        DrawMonthWiseDetailsLastYear();
    }
    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
        DrawMonthWiseDetailsLastYear();
    }

    protected void DrawMonthWiseDetailsLastYear()
    {

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)Session["MonthDetailsLastYear"];

        DataTable dtBranchDetailsMonthWise = new DataTable();
        dtBranchDetailsMonthWise.Columns.Add("monthid", typeof(int));
        dtBranchDetailsMonthWise.Columns.Add("monthidname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("branchname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("totalamount", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("amountper", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));
        dtBranchDetailsMonthWise.Columns.Add("servicetaxinr", typeof(double));

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        PanelBranchNameYear.Visible = true;
        lblBranchNameLastYear.Text = Session["BranchName"].ToString() + " " + GetLastYear(Session["Fyear"].ToString());
        lblMsg.Text = "";
        string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        for (int i = 1; i <= 12; i++)
        {
            DataRow[] dtRowDetails = dtMonthDetails.Select("monthid=" + i);
            if (dtRowDetails.Length == 1)
            {
                dtBranchDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
                dtBranchDetailsMonthWise.ImportRow(dtRowDetails[0]);
                dtBranchDetailsMonthWise.AcceptChanges();
            }
            else
            {
                DataTable createtablenew = new DataTable();
                createtablenew.Columns.Add("monthid", typeof(int));
                createtablenew.Columns.Add("monthidname", typeof(string));
                createtablenew.Columns.Add("branchname", typeof(string));
                createtablenew.Columns.Add("totalamount", typeof(double));
                createtablenew.Columns.Add("amountper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Columns.Add("servicetaxinr", typeof(double));

                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], Session["BranchName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("monthid=" + i);
                dtBranchDetailsMonthWise.ImportRow(dtnewRow[0]);
            }
        }
        DataView dvdetails = new DataView(dtBranchDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.IsMarginVisible = false;


        ChartMonthLastYear.ChartAreas["ChartAreaMonthLastYear"].AxisX.Interval = .5;
        Unit height = new Unit(600);
        ChartMonthLastYear.Height = height;
        title.Text = "Branch (Last Year Month Wise) Contribution";
        title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        ChartMonthLastYear.Titles[0] = title;

        if (rbtnpersentagemonthLastYear.Checked == true)
        {
            ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
            ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = "0.6";
            ChartMonthLastYear.Series["SeriesMonthLastYear"].LabelFormat = "{0:n2}" + "%";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxinr");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = "0.6";
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].LabelFormat = "{0:n2}" + "%";

        }
        else
        {
            ChartMonthLastYear.Series["SeriesMonthLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalamount");
            ChartMonthLastYear.Series["SeriesMonthLastYear"]["PointWidth"] = "0.6";

            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "servicetaxinr");
            ChartMonthLastYear.Series["SeriesMonthServicesTaxLastYear"]["PointWidth"] = "0.6";
        }
        panelChart2LastYear.Visible = true;
    }

    protected void rbtRupeesmonthLastYear_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
        DrawMonthWiseDetailsLastYear();
    }
    protected void rbtnpersentagemonthLastYear_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
        DrawMonthWiseDetailsLastYear();
    }

    protected string GetLastYear(string year)
    {
        string retval = year;
        string[] str = year.Split('-');
        int getYearVale = Convert.ToInt32(str[0]);

        retval = getYearVale - 1 + "-" + getYearVale;
        return retval;
    }
}