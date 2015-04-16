using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Analytics;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Text;
using Telerik.Charting;
using System.Threading;
using Rebelfone.Report;
using System.Data.SqlClient;
public partial class Rebelfone_Rpt_Visitors : System.Web.UI.Page
{
    #region User Defined Data

    StringBuilder str = new StringBuilder();

    string connection = @"server=64.91.226.230;user id=rebelsa;Password=dYe95Efs78*;database=Rebelfone";

    #endregion
    

    protected void Page_Load(object sender, EventArgs e)
    {  
           
            getlastrowdata();

            DisplayReport();
       

    }
    void getlastrowdata()
    {
        SqlConnection con = new SqlConnection(connection);
        SqlDataAdapter adp = new SqlDataAdapter("Select top 1 * from google_visitors order by id desc", connection);
        DataSet ds_getLastRowData = new DataSet();
        adp.Fill(ds_getLastRowData);
        string _fromdate = ds_getLastRowData.Tables[0].Rows[0]["monthid"].ToString() + "/01/" + ds_getLastRowData.Tables[0].Rows[0]["yearname"].ToString();
        decimal adcost = Convert.ToDecimal(ds_getLastRowData.Tables[0].Rows[0]["visitors"].ToString());
        DateTime dtf = Convert.ToDateTime(_fromdate);
        DateTime dtt = dtf.AddMonths(1);
        dtt = dtt.AddDays(-1);
        string retdata = VisitsNumber(dtf, dtt, "ga:visits");
        if (!string.IsNullOrEmpty(retdata))
        {
        }
        else
        {
            retdata = "0";
        }
        if (Convert.ToDecimal(retdata) > adcost)
        {
            SqlCommand cmd = new SqlCommand("UPDATE google_visitors set visitors='" + retdata + "' where id='" + Convert.ToInt32(ds_getLastRowData.Tables[0].Rows[0]["id"]) + "'");

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        con.Close();
        InsertNewData(dtf);
    }
    void InsertNewData(DateTime senddate)
    {
        SqlConnection con = new SqlConnection(connection);
        if (senddate.Year == DateTime.Now.Year)
        {
            if (senddate.Month != DateTime.Now.Month)
            {
                senddate = senddate.AddMonths(1);
                string from = senddate.Month.ToString() + "/01/" + senddate.Year.ToString();
                DateTime dt_from = Convert.ToDateTime(from);
                DateTime dt_to = dt_from.AddMonths(1);
                dt_to = dt_to.AddDays(-1);
                string retdata = VisitsNumber(dt_from, dt_to, "ga:visits");
                if (!string.IsNullOrEmpty(retdata))
                {
                }
                else
                {
                    retdata = "0";
                }
                SqlCommand cmd = new SqlCommand("Insert into google_visitors(monthid,yearname,visitors)values('" + Convert.ToInt32(dt_from.Month) + "','" + Convert.ToInt32(dt_from.Year) + "','" + Convert.ToDecimal(retdata) + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                InsertNewData(dt_from);

            }
            con.Close();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DisplayReport();
    }


    private void DisplayReport()
    {

        try
        {
          
            Report objVisitors = new Report();
              

            DataSet ds = new dsReport();
            ds = objVisitors.GetGoogleVisitors(Convert.ToInt32(drpFrom.SelectedValue),Convert.ToInt32(drpTo.SelectedValue));
            if (ds.Tables["yearwisesale"].Rows.Count > 0)
            {
                //Crystal Report****************
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/RptMain_Visitors.rpt"));
                rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");               
                foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
                {
                    string SubRepName = ((SubreportObject)repOp).SubreportName;
                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];                   
                    if (SubRepName == "Rpt_VisitorYear.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["VisitorsYear"]);
                    }
                    if (SubRepName == "rpt_Visitornew.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["yearwisesale"]);// 
                    }                    
                }
                CrystalReportViewer1.ReportSource = rptDoc;
                CrystalReportViewer1.DataBind();
                CrystalReportViewer1.DisplayGroupTree = false; 
            }
            
        }
        catch (Exception ex)
        {
            ex.ToString();
        }


    }


    public string VisitsNumber(DateTime validatefrom, DateTime validateto, string Metrics)
    {
        string data = string.Empty;
        string username = "rebelfone1@gmail.com";
        string pass = "rebel4n123";

        string gkey = "?key=AIzaSyApvwdBbpXUUooH4VgGsqZccDff0WtdhpA";

        string dataFeedUrl = "https://www.google.com/analytics/feeds/data" + gkey;
        string accountFeedUrl = "https://www.googleapis.com/analytics/v2.4/management/accounts" + gkey;

        AnalyticsService service = new AnalyticsService("www.rebelfone.com");
        service.setUserCredentials(username, pass);

        DataQuery query1 = new DataQuery(dataFeedUrl);
        //query1.Dimensions = "ga:visits";
        query1.Ids = "ga:11397690";



        query1.Metrics = Metrics;


        //You were setting 2013-09-01 and thats an invalid date because it hasn't been reached yet, be sure you set valid dates
        //For start date is better to place an aprox date when you registered the domain on Google Analytics for example January 2nd 2012, for an end date the actual date is enough, no need to go further
        query1.GAStartDate = validatefrom.ToString("yyyy-MM-dd");
        query1.GAEndDate = validateto.ToString("yyyy-MM-dd");
        //  query1.StartIndex = 1;

        DataFeed dataFeedVisits = service.Query(query1);

        foreach (DataEntry entry in dataFeedVisits.Entries)
        {
            data = entry.Metrics[0].Value;
        }

        return data;
    }

    public DataTable Getdata(string matrics)
    {

        DataTable dtData = new DataTable();
        dtData.Columns.Add("Year");
        dtData.Columns.Add("Month");
        dtData.Columns.Add("MonthID");
        dtData.Columns.Add("mycount");
        for (int year = 2013; year <= Convert.ToInt16(DateTime.Now.Year); year++)
        {
            DateTime dtfrom = new DateTime();
            DateTime dtto = new DateTime();
            for (int month = 1; month <= 12; month++)
            {
                dtfrom = new DateTime(year, month, 1);

                dtto = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                if (dtto.Year == DateTime.Now.Year && dtto.Month > DateTime.Now.Month)
                    break;
                string data = this.VisitsNumber(dtfrom, dtto, matrics);
                DataRow dr = dtData.NewRow();
                dr["MonthID"] = dtfrom.Month;
                dr["Month"] = dtfrom.ToString("MMM");
                dr["Year"] = year;//
                dr["mycount"] = data;
                dtData.Rows.Add(dr);
            }
        }
        return dtData;
    }

    //public void BindGraph()
    //{
    //    DataTable dt = new DataTable();
    //    dt = Getdata("ga:visits");

    //    gvVisitors.DataSource = dt;
    //    gvVisitors.DataBind();
    //    RadToolTipManager1.ToolTipZoneID = RadChart1.ClientID;

    //    ChartSeries chartSeries = new ChartSeries();
    //    chartSeries.Appearance.LabelAppearance.Visible = true;
    //    chartSeries.Name = "2009";
    //    chartSeries.Type = ChartSeriesType.Line;
    //    chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.BlueViolet;

    //    ChartSeries chartSeries2 = new ChartSeries();
    //    chartSeries2.Appearance.LabelAppearance.Visible = true;
    //    chartSeries2.Name = "2010";
    //    chartSeries2.Type = ChartSeriesType.Line;
    //    chartSeries2.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Blue;


    //    ChartSeries chartSeries3 = new ChartSeries();
    //    chartSeries3.Appearance.LabelAppearance.Visible = true;
    //    chartSeries3.Name = "2011";
    //    chartSeries3.Type = ChartSeriesType.Line;
    //    chartSeries3.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Gray;

    //    ChartSeries chartSeries4 = new ChartSeries();
    //    chartSeries4.Appearance.LabelAppearance.Visible = true;
    //    chartSeries4.Name = "2012";
    //    chartSeries4.Type = ChartSeriesType.Line;
    //    chartSeries4.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Brown;

    //    ChartSeries chartSeries5 = new ChartSeries();
    //    chartSeries5.Appearance.LabelAppearance.Visible = true;
    //    chartSeries5.Name = "2013";
    //    chartSeries5.Type = ChartSeriesType.Line;
    //    chartSeries5.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Bisque;


    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        if (dr["Year"].ToString() == "2009")
    //        {


    //            chartSeries.AddItem(Convert.ToInt32(dr["mycount"].ToString()));
    //        }
    //        if (dr["Year"].ToString() == "2010")
    //        {


    //            chartSeries2.AddItem(Convert.ToInt32(dr["mycount"].ToString()));
    //        }
    //        if (dr["Year"].ToString() == "2011")
    //        {


    //            chartSeries3.AddItem(Convert.ToInt32(dr["mycount"].ToString()));
    //        }

    //        if (dr["Year"].ToString() == "2012")
    //        {


    //            chartSeries4.AddItem(Convert.ToInt32(dr["mycount"].ToString()));
    //        }

    //        if (dr["Year"].ToString() == "2013")
    //        {


    //            chartSeries5.AddItem(Convert.ToInt32(dr["mycount"].ToString()));
    //        }

    //    }

    //    chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries.Appearance.PointMark.Visible = true;

    //    chartSeries2.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries2.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries2.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries2.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries2.Appearance.PointMark.Visible = true;

    //    chartSeries3.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries3.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries3.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries3.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries3.Appearance.PointMark.Visible = true;

    //    chartSeries4.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries4.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries4.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries4.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries4.Appearance.PointMark.Visible = true;

    //    chartSeries5.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries5.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries5.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries5.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries5.Appearance.PointMark.Visible = true;
    //    //set the plot area gradient background fill

    //    RadChart1.PlotArea.XAxis.DataLabelsColumn = "Month";
    //    RadChart1.PlotArea.XAxis.MaxValue = 12;
    //    RadChart1.PlotArea.XAxis.AutoScale = false;
    //    RadChart1.PlotArea.XAxis.Appearance.CustomFormat = Telerik.Charting.Styles.ChartValueFormat.ShortDate.ToString("G");



    //    RadChart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Gradient;
    //    RadChart1.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(65, 201, 254);
    //    RadChart1.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(0, 107, 186);
    //    //// Set text and line for X axis
    //    RadChart1.PlotArea.XAxis.AxisLabel.TextBlock.Text = "Month";
    //    RadChart1.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
    //    RadChart1.PlotArea.XAxis.Appearance.Width = 3;
    //    RadChart1.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.Red;
    //    //// Set text and line for Y axis
    //    //RadChart1.PlotArea.YAxis.AxisLabel.TextBlock.Text = "%";
    //    //RadChart1.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
    //    //RadChart1.PlotArea.YAxis.Appearance.Width = 3;
    //    //RadChart1.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.Red;
    //    // Populate the chart
    //    RadChart1.Series.Add(chartSeries);
    //    RadChart1.Series.Add(chartSeries2);
    //    RadChart1.Series.Add(chartSeries3);
    //    RadChart1.Series.Add(chartSeries4);
    //    RadChart1.Series.Add(chartSeries5);





    //}


    //public void BindGraph2()
    //{
    //    DataTable dt = new DataTable();
    //    dt = Getdata("ga:adCost");

    //    gvVisitors.DataSource = dt;
    //    gvVisitors.DataBind();
    //    RadToolTipManager1.ToolTipZoneID = RadChart1.ClientID;

    //    ChartSeries chartSeries = new ChartSeries();
    //    chartSeries.Appearance.LabelAppearance.Visible = true;
    //    chartSeries.Name = "2009";
    //    chartSeries.Type = ChartSeriesType.Line;
    //    chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.BlueViolet;

    //    ChartSeries chartSeries2 = new ChartSeries();
    //    chartSeries2.Appearance.LabelAppearance.Visible = true;
    //    chartSeries2.Name = "2010";
    //    chartSeries2.Type = ChartSeriesType.Line;
    //    chartSeries2.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Blue;


    //    ChartSeries chartSeries3 = new ChartSeries();
    //    chartSeries3.Appearance.LabelAppearance.Visible = true;
    //    chartSeries3.Name = "2011";
    //    chartSeries3.Type = ChartSeriesType.Line;
    //    chartSeries3.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Gray;

    //    ChartSeries chartSeries4 = new ChartSeries();
    //    chartSeries4.Appearance.LabelAppearance.Visible = true;
    //    chartSeries4.Name = "2012";
    //    chartSeries4.Type = ChartSeriesType.Line;
    //    chartSeries4.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Brown;

    //    ChartSeries chartSeries5 = new ChartSeries();
    //    chartSeries5.Appearance.LabelAppearance.Visible = true;
    //    chartSeries5.Name = "2013";
    //    chartSeries5.Type = ChartSeriesType.Line;
    //    chartSeries5.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Bisque;


    //    foreach (DataRow dr in dt.Rows)
    //    {

    //        if (dr["Year"].ToString() == "2009")
    //        {

    //            if (dr["mycount"] != string.Empty)
    //            {
    //                chartSeries.AddItem(Math.Round(Convert.ToDouble(dr["mycount"]), 2));
    //            }
    //            else
    //            {
    //                chartSeries.AddItem(Math.Round(0.00, 2));
    //            }

    //        }
    //        if (dr["Year"].ToString() == "2010")
    //        {

    //            if (dr["mycount"] != string.Empty)
    //            {
    //                chartSeries2.AddItem(Math.Round(Convert.ToDouble(dr["mycount"]), 2));
    //            }
    //            else
    //            {
    //                chartSeries2.AddItem(Math.Round(0.00, 2));
    //            }
    //        }
    //        if (dr["Year"].ToString() == "2011")
    //        {


    //            if (dr["mycount"] != string.Empty)
    //            {
    //                chartSeries3.AddItem(Math.Round(Convert.ToDouble(dr["mycount"]), 2));
    //            }
    //            else
    //            {
    //                chartSeries3.AddItem(Math.Round(0.00, 2));
    //            }
    //        }

    //        if (dr["Year"].ToString() == "2012")
    //        {


    //            if (dr["mycount"] != string.Empty)
    //            {
    //                chartSeries4.AddItem(Math.Round(Convert.ToDouble(dr["mycount"]), 2));
    //            }
    //            else
    //            {
    //                chartSeries4.AddItem(Math.Round(0.00, 2));
    //            }
    //        }

    //        if (dr["Year"].ToString() == "2013")
    //        {

    //            if (dr["mycount"] != string.Empty)
    //            {
    //                chartSeries5.AddItem(Math.Round(Convert.ToDouble(dr["mycount"]), 2));
    //            }
    //            else
    //            {
    //                chartSeries5.AddItem(Math.Round(0.00, 2));
    //            }
    //        }

    //    }

    //    chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries.Appearance.PointMark.Visible = true;

    //    chartSeries2.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries2.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries2.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries2.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries2.Appearance.PointMark.Visible = true;

    //    chartSeries3.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries3.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries3.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries3.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries3.Appearance.PointMark.Visible = true;

    //    chartSeries4.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries4.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries4.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries4.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries4.Appearance.PointMark.Visible = true;

    //    chartSeries5.Appearance.PointMark.Dimensions.AutoSize = false;
    //    chartSeries5.Appearance.PointMark.Dimensions.Width = 5;
    //    chartSeries5.Appearance.PointMark.Dimensions.Height = 5;
    //    chartSeries5.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Black;
    //    chartSeries5.Appearance.PointMark.Visible = true;
    //    //set the plot area gradient background fill

    //    RadChart2.PlotArea.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Gradient;
    //    RadChart2.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(65, 201, 254);
    //    RadChart2.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(0, 107, 186);
    //    // Set text and line for X axis
    //    RadChart2.PlotArea.XAxis.AxisLabel.TextBlock.Text = "Years";
    //    RadChart2.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
    //    RadChart2.PlotArea.XAxis.Appearance.Width = 3;
    //    RadChart2.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.Red;
    //    // Set text and line for Y axis
    //    RadChart2.PlotArea.YAxis.AxisLabel.TextBlock.Text = "%";
    //    RadChart2.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
    //    RadChart2.PlotArea.YAxis.Appearance.Width = 3;
    //    RadChart2.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.Red;
    //    // Populate the chart
    //    RadChart2.Series.Add(chartSeries);
    //    RadChart2.Series.Add(chartSeries2);
    //    RadChart2.Series.Add(chartSeries3);
    //    RadChart2.Series.Add(chartSeries4);
    //    RadChart2.Series.Add(chartSeries5);




    //}

    //protected void RadChart1_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    //{


    //    e.SeriesItem.ActiveRegion.Tooltip += ((DataRowView)e.DataItem)["Month"].ToString() + ": Year: " + ((DataRowView)e.DataItem)["Year"].ToString();
    //}

    //protected void RadChart2_ItemDataBound(object sender, Telerik.Charting.ChartItemDataBoundEventArgs e)
    //{


    //    e.SeriesItem.ActiveRegion.Tooltip += ((DataRowView)e.DataItem)["Month"].ToString() + ": Year: " + ((DataRowView)e.DataItem)["Year"].ToString();
    //}

    public void Visitors()
    {
        Report objReport = new Report();

        CrystalReportViewer1.Visible = true;

        ReportDocument crystalReport = new ReportDocument();

        crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/rpt_Visitor.rpt"));

        crystalReport.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

        DataTable dt = new DataTable();
        dt = Getdata("ga:visits");

        foreach (DataRow dr in dt.Rows)
        {
            objReport.AddGoolge_Visitors_Adcost(Convert.ToInt32(dr["MonthID"]), Convert.ToInt32(dr["Year"]), (dr["mycount"]) != string.Empty ? Convert.ToDecimal(dr["mycount"]) : 0);
        }

        DataSet ds = new dsReport();
        ds.Tables["yearwisesale"].Merge(dt);

        crystalReport.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

        crystalReport.SetDataSource(ds.Tables["yearwisesale"]);

        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
    }

    //    public void Advetisement()
    //    {
    //        CrystalReportViewer1.Visible = true;
    //        ReportDocument crystalReport = new ReportDocument();

    //        crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/rpt_Adcost.rpt"));
    //        crystalReport.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

    //        DataTable dt = new DataTable();
    //        dt = Getdata("ga:adCost");
    //        DataSet ds = new dsReport();
    //        ds.Tables["yearwisesale"].Merge(dt);

    //        crystalReport.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");
    //        crystalReport.SetDataSource(ds.Tables["yearwisesale"]);

    //        CrystalReportViewer1.ReportSource = crystalReport;
    //        CrystalReportViewer1.DataBind();
    //    }

    //    protected void btnVisitor_Click(object sender, EventArgs e)
    //    {
    //        Thread.Sleep(2000);
    //        Visitors();
    //        // RadChart1.Visible = true;
    //        // RadChart2.Visible = false;
    //        // Thread.Sleep(2000);
    //        //BindGraph();
    //    }

    //    protected void btnAdCost_Click(object sender, EventArgs e)
    //    {
    //        Thread.Sleep(2000);
    //        Advetisement();
    //        // RadChart2.Visible = true;
    //        // RadChart1.Visible = false;

    //        // BindGraph2();
    //    }

    //    protected void gvVisitors_RowDataBound(object sender, GridViewRowEventArgs e)
    //    {
    //        // gvVisitors.HeaderRow.Cells[2].Text = "Hi";
    //    }
    //}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 