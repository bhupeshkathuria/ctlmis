using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
public partial class Report_BranchWiseSalesOrder : System.Web.UI.Page
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
            catch (Exception ex)
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
        ViewState["Fyear"] = selectedFyear;
        string[] yearArray = selectedFyear.Split('-');

        if (yearArray.Length > 1)
        {
            fromYear = yearArray[0].ToString();
            toYear = yearArray[1].ToString();

            objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
            objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";
            objDashBoard.MonthID = Convert.ToInt32(Session["Month"].ToString());

            ViewState["FromDate"] = fromYear + "-" + "04" + "-" + "01";
            ViewState["ToDate"] = toYear + "-" + "03" + "-" + "31";
            DataTable dtAllBranchDetails = new DataTable();
            dsBranchDetails = objDashBoard.GetBranchSalesOrderDetailsBasedOnFinancialYear();
            if (dsBranchDetails.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                dtAllBranchDetails = dsBranchDetails.Tables[0];
                ViewState["BranchDetails"] = dtAllBranchDetails;
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
        dtGetBranchDetails = (DataTable)ViewState["BranchDetails"];

        DataView dvAllBranchAmount = new DataView(dtGetBranchDetails);
        dvAllBranchAmount.Sort = "totalorder ASC";

        DataTable dtCreateNewBranch = new DataTable();
        dtCreateNewBranch.Columns.Add("branchname");
        dtCreateNewBranch.Columns.Add("totalorder");
        dtCreateNewBranch.Columns.Add("totalorderper");

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
                    Unit height = new Unit(400);
                    Chart1.Height = height;
                    title.Text = "Branch (Year Wise) Sales Order";
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
                    title.Text = "Branch (Year Wise)  Sales Order";
                    Chart1.Titles[0] = title;
                    drpTopValue.Visible = false;
                }
            }
            else
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.4";
                Unit height = new Unit(600);
                Chart1.Height = height;
                title.Text = "Branch (Year Wise)  Sales Order";
                Chart1.Titles[0] = title;
            }
            if (rbtrupees.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "totalorder");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
            }
            if (rbtPercentage.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "branchname", dvBranch, "totalorderper");
                Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                Chart1.Series["Series1"].LabelFormat = "{0:n2}" + "%";
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
            ViewState["BranchName"] = getBranchName;
            DisplayMonthWiseBranchSalesOrderReport();
            DrawGraph();
            panelChart2.Visible = true;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
    }

    protected void DisplayMonthWiseBranchSalesOrderReport()
    {
        try
        {
            objDashBoard.Fromdate = ViewState["FromDate"].ToString();
            objDashBoard.Todate = ViewState["ToDate"].ToString();
            objDashBoard.BranchName = ViewState["BranchName"].ToString();
            dsBranchDetailsMonthWise = objDashBoard.GetMonthlySalesOrderDetailsBasedOnBranch();

            if (dsBranchDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                ViewState["MonthDetails"] = dsBranchDetailsMonthWise.Tables[0];
                DrawMonthWiseDetails();
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

    protected void DrawMonthWiseDetails()
    {

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)ViewState["MonthDetails"];

        DataTable dtBranchDetailsMonthWise = new DataTable();
        dtBranchDetailsMonthWise.Columns.Add("monthid", typeof(int));
        dtBranchDetailsMonthWise.Columns.Add("monthidname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("branchname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("totalorder", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("totalorderper", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        PanelBranchName.Visible = true;
        lblBranchName.Text = ViewState["BranchName"].ToString() + " " + ViewState["Fyear"].ToString();
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
                createtablenew.Columns.Add("totalorder", typeof(double));
                createtablenew.Columns.Add("totalorderper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], ViewState["BranchName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("monthid=" + i);
                dtBranchDetailsMonthWise.ImportRow(dtnewRow[0]);
            }
        }
        DataView dvdetails = new DataView(dtBranchDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;
        if (rbtRupeesmonth.Checked == true)
        {

            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalorder");
            ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            Unit height = new Unit(400);
            ChartMonth.Height = height;
            title.Text = "Branch (Month Wise) Sales Order";
            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            ChartMonth.Titles[0] = title;
        }

        if (rbtnpersentagemonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalorderper");
            ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";
            Unit height = new Unit(400);
            ChartMonth.Height = height;
            title.Text = "Branch (Month Wise) Sales Order";
            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            ChartMonth.Titles[0] = title;
        }
    }

    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
    }
    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawMonthWiseDetails();
    }
}