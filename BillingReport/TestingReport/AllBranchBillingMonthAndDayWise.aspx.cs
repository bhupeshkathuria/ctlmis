using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
public partial class Report_AllBranchBillingYearWise : System.Web.UI.Page
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

            ViewState["FromDate"] = fromYear + "-" + "04" + "-" + "01";
            ViewState["ToDate"] = toYear + "-" + "03" + "-" + "31";
            DataTable dtAllBranchDetails = new DataTable();
            dsBranchDetails = objDashBoard.GetAllBranchBillingMonthWise();
            if (dsBranchDetails.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = "";
                dtAllBranchDetails = dsBranchDetails.Tables[0];
                ViewState["BranchDetails"] = dtAllBranchDetails;
                DrawGraph();
                panelChart1.Visible = true;
                PanelChart2.Visible = false;
               
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
        //int TopValue = Convert.ToInt32(drpTopValue.SelectedValue);
       
        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)ViewState["BranchDetails"];

        DataTable dtBranchDetailsMonthWise = new DataTable();
        dtBranchDetailsMonthWise.Columns.Add("monthid", typeof(int));
        dtBranchDetailsMonthWise.Columns.Add("monthidname", typeof(string));
        dtBranchDetailsMonthWise.Columns.Add("totalamount", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("amountper", typeof(double));
        dtBranchDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));
        
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
                createtablenew.Columns.Add("totalamount", typeof(double));
                createtablenew.Columns.Add("amountper", typeof(double));
                createtablenew.Columns.Add("monthserialno", typeof(Int16));
                createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], 0, 0, MonthArray[(i - 1), 1]);
                DataRow[] dtnewRow = createtablenew.Select("monthid=" + i);
                dtBranchDetailsMonthWise.ImportRow(dtnewRow[0]);
            }
        }
        DataView dvdetails = new DataView(dtBranchDetailsMonthWise);
        dvdetails.Sort = "monthserialno ASC";
        ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;
        if (rbtRupeesmonth.Checked == true)
        {

            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalamount");
            ChartMonth.Series["SeriesMonth"].PostBackValue = "#AXISLABEL";
            ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            Unit height = new Unit(400);
            ChartMonth.Height = height;
            title.Text = "All Branch (Month Wise) Contribution";
            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            ChartMonth.Titles[0] = title;
        }

        if (rbtnpersentagemonth.Checked == true)
        {
            ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
            ChartMonth.Series["SeriesMonth"].PostBackValue = "#AXISLABEL";
            ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
            ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
            ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";
            Unit height = new Unit(400);
            ChartMonth.Height = height;
            title.Text = "All Branch (Month Wise) Contribution";
            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            ChartMonth.Titles[0] = title;
        }

       

    }

    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }
    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }

   
    protected void ChartMonth_Click(object sender, ImageMapEventArgs e)
    {
        try
        {
            string getMonthName = e.PostBackValue;
            
            ViewState["MonthName"] = getMonthName;
            int monthId = 0;
            string[,] MonthArray = new string[,] { { "January", "1" }, { "February", "2" }, { "March", "3" }, { "April", "4" }, { "May", "5" }, { "June", "6" }, { "July", "7" }, { "August", "8" }, { "September", "9" }, { "October", "10" }, { "November", "11" }, { "December", "12" } };
            for (int i = 1; i <= 12; i++)
            {
                string monthName = MonthArray[(i - 1), 0];
                if (monthName == getMonthName)
                {
                    monthId =Convert.ToInt32(MonthArray[(i - 1), 1]);
                }
            }
            DisplayDayWiseAllBranchBillingReport(monthId);
            DrawGraph();
            PanelChart2.Visible = true;
            lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
    }

    protected void DisplayDayWiseAllBranchBillingReport(int monthId)
    {
        try
        {
            objDashBoard.Fromdate = ViewState["FromDate"].ToString();
            objDashBoard.Todate = ViewState["ToDate"].ToString();
            objDashBoard.MonthID = monthId;
            dsBranchDetailsMonthWise = objDashBoard.GetAllBranchBillingDayWiseBasedOnMonth();

            if (dsBranchDetailsMonthWise.Tables[0].Rows.Count > 0)
            {
                ViewState["DayDetails"] = dsBranchDetailsMonthWise.Tables[0];
                DrawDayWiseDetails();
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

    protected void DrawDayWiseDetails()
    {
        //int TopValue = Convert.ToInt32(drpTopValue.SelectedValue);
        int TopValue = 0;
        DataTable dtMonthDetails = new DataTable();
        dtMonthDetails = (DataTable)ViewState["DayDetails"];

        System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
        title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
        title.ShadowOffset = 0;
        title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        title.Alignment = System.Drawing.ContentAlignment.TopCenter;

        PanelMonthName.Visible = true;
        lblMonthName.Text = ViewState["MonthName"].ToString() + " " + ViewState["Fyear"].ToString();
        lblMsg.Text = "";

        DataView dvAllBranchAmount = new DataView(dtMonthDetails);
        dvAllBranchAmount.Sort = "invoicedate ASC";

        DataTable dtCreateNewBranch = new DataTable();
        dtCreateNewBranch.Columns.Add("invoicedate", typeof(string));
        dtCreateNewBranch.Columns.Add("totalamount");
        dtCreateNewBranch.Columns.Add("amountper");

        if (dvAllBranchAmount.Count > 0)
        {
            int totalBranchRows = dvAllBranchAmount.Count;
            if (totalBranchRows > 5)
            {
                int totalBranch = dvAllBranchAmount.Count;
                TopValue = TopValue == 0 ? totalBranch : TopValue;
                for (int j = (totalBranch - TopValue); j < totalBranch; j++)
                {
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

            if (dtCreateNewBranch.Rows.Count <= 10)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.6";
                Unit height = new Unit(400);
                Chart1.Height = height;
                title.Text = "All Branch (Day Wise) Contribution";
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                Chart1.Titles[0] = title;
            }
            else if (dtCreateNewBranch.Rows.Count <= 20)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.6";
                Unit height = new Unit(600);
                Chart1.Height = height;
                title.Text = "All Branch (Day Wise) Contribution";
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                Chart1.Titles[0] = title;
            }
            else
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                Chart1.Series["Series1"]["PointWidth"] = "0.6";
                Unit height = new Unit(700);
                Chart1.Height = height;
                title.Text = "All Branch (Day Wise) Contribution";
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                Chart1.Titles[0] = title;
            }
            if (rbtrupees.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "invoicedate", dvBranch, "totalamount");
            }
            if (rbtPercentage.Checked == true)
            {
                Chart1.Series["Series1"].Points.DataBindXY(dvBranch, "invoicedate", dvBranch, "amountper");
                Chart1.Series["Series1"].LabelFormat = "{0:n2}" + "%";
            }
        }





        //string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
        //for (int i = 1; i <= 12; i++)
        //{
        //    DataRow[] dtRowDetails = dtMonthDetails.Select("monthid=" + i);
        //    if (dtRowDetails.Length == 1)
        //    {
        //        dtBranchDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
        //        dtBranchDetailsMonthWise.ImportRow(dtRowDetails[0]);
        //        dtBranchDetailsMonthWise.AcceptChanges();
        //    }
        //    else
        //    {
        //        DataTable createtablenew = new DataTable();
        //        createtablenew.Columns.Add("monthid", typeof(int));
        //        createtablenew.Columns.Add("monthidname", typeof(string));
        //        createtablenew.Columns.Add("branchname", typeof(string));
        //        createtablenew.Columns.Add("totalamount", typeof(double));
        //        createtablenew.Columns.Add("amountper", typeof(double));
        //        createtablenew.Columns.Add("monthserialno", typeof(Int16));
        //        createtablenew.Rows.Add(i, MonthArray[(i - 1), 0], ViewState["BranchName"].ToString(), 0, 0, MonthArray[(i - 1), 1]);
        //        DataRow[] dtnewRow = createtablenew.Select("monthid=" + i);
        //        dtBranchDetailsMonthWise.ImportRow(dtnewRow[0]);
        //    }
        //}
        //DataView dvdetails = new DataView(dtBranchDetailsMonthWise);
        //dvdetails.Sort = "monthserialno ASC";
        //ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.IsMarginVisible = false;
        //if (rbtRupeesmonth.Checked == true)
        //{

        //    ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "totalamount");
        //    ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
        //    ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
        //    Unit height = new Unit(400);
        //    ChartMonth.Height = height;
        //    title.Text = "Branch (Month Wise) Contribution";
        //    title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        //    ChartMonth.Titles[0] = title;
        //}

        //if (rbtnpersentagemonth.Checked == true)
        //{
        //    ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "monthidname", dvdetails, "amountper");
        //    ChartMonth.ChartAreas["ChartAreaMonth"].AxisX.Interval = .5;
        //    ChartMonth.Series["SeriesMonth"]["PointWidth"] = "0.6";
        //    ChartMonth.Series["SeriesMonth"].LabelFormat = "{0:n2}" + "%";
        //    Unit height = new Unit(400);
        //    ChartMonth.Height = height;
        //    title.Text = "Branch (Month Wise) Contribution";
        //    title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        //    ChartMonth.Titles[0] = title;
        //}
    }
    protected void rbtrupees_CheckedChanged(object sender, EventArgs e)
    {
        DrawDayWiseDetails();
    }
    protected void rbtPercentage_CheckedChanged(object sender, EventArgs e)
    {
        DrawDayWiseDetails();
    }


 
}