using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Rebelfone.Report;
using System.Threading;

public partial class Rebelfone_Rpt_Revenue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpMonth.SelectedValue = DateTime.Now.ToString("MM");
            //drpMonth.SelectedValue = DateTime.Now.ToString("MM");
        }
        DisplayReport();
       
    }

  

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DisplayReport();
        
    }

    protected void btmYearWise_Click(object sender, EventArgs e)
    {
        DisplayReport();
       
    }

    private void DisplayReport()
    {

        try
        {
            drpMonth.SelectedItem.Value = drpMonth.SelectedValue;

            Report objRevenue = new Report();

            DataSet ds = new DataSet();

            DataSet ds1 = new DataSet();

            DataSet ds2 = new DataSet();

            string start_date = drpMonth.SelectedItem.Value + "/01/"  + drpYear.SelectedItem.Value;

            string end_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

            string startdate2 = drpMonth.SelectedItem.Value + "/01/" + drpYearCompare1.SelectedItem.Value;

            string end_date2 = drpMonth.SelectedItem.Value + "/01/" + drpYearCompare2.SelectedItem.Value;

            end_date = Convert.ToDateTime(start_date.ToString()).AddMonths(1).ToString("MM/dd/yyyy");

            end_date2 = Convert.ToDateTime(end_date2.ToString()).AddMonths(1).ToString("MM/dd/yyyy");

          //  string end_date = ((GetEndMonth(drpMonth.SelectedItem.Value) == "Jan") ? "Jan" : GetEndMonth(drpMonth.SelectedItem.Value)) + "/" + ((drpMonth.SelectedItem.Value == "Dec") ? (Convert.ToInt32(drpYear.SelectedItem.Value) + 1).ToString() : drpYear.SelectedItem.Value);

           ds = objRevenue.GetRevenueMonthReport(start_date, end_date);

           ds1 = objRevenue.GetRevenueCompareReport(startdate2, end_date, drpMonth.SelectedItem.Value);

           end_date2 = "12" + "/31/" + drpYearCompare2.SelectedItem.Value;

           startdate2 = "01" + "/01/" + drpYearCompare1.SelectedItem.Value;

          ds2 = objRevenue.GetRevenueCompareReport2(startdate2, end_date2);


            if (ds.Tables["Revenue_Month"].Rows.Count > 0)
            {
                //Crystal Report****************
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/RPT_Main_Revenue.rpt"));

                rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

                foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
                {
                    string SubRepName = ((SubreportObject)repOp).SubreportName;

                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];

                    if (SubRepName == "RPT_Revenue_first.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["Revenue_Month"]);
                    }

                    if (SubRepName == "RPT_Revenue_second.rpt")
                    {

                        subRepDoc.SetDataSource(ds1.Tables["Revenue_Compare"]);// 

                    }

                    if (SubRepName == "Rpt_RevenueYear.rpt")
                    {

                        subRepDoc.SetDataSource(ds2.Tables["Revenue_Compare2"]);// 

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

    private void RevenueReportOnlineSale()
    {
        Rebelfone.Report.Report objReport = new Report();
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/rptRevenue_Report_online_sale.rpt"));

        string start_date = "01/" + drpMonth.SelectedItem.Value + "/" + drpYear.SelectedItem.Value;
        string end_date = "01/" + ((GetEndMonth(drpMonth.SelectedItem.Value) == "Jan") ? "Jan" : GetEndMonth(drpMonth.SelectedItem.Value)) + "/" + ((drpMonth.SelectedItem.Value == "Dec") ? (Convert.ToInt32(drpYear.SelectedItem.Value) + 1).ToString() : drpYear.SelectedItem.Value);

        SqlParameter[] parameters = new SqlParameter[]
        {
              new SqlParameter("start_date",start_date),
              new SqlParameter("end_date",end_date)
        };

        DataSet ds = objReport.GetRevenueReportByYear(start_date, end_date); 
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count == 0)
        {
            lblMsg.Text = "No Record found";

        }
        else
        {
            crystalReport.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = crystalReport;
            CrystalReportViewer1.DisplayGroupTree = false;
        }
       
    }

    protected string GetEndMonth(string s)
    {
        if (s == "Jan")
            return "Feb";
        else if (s == "Feb")
            return "Mar";
        else if (s == "Mar")
            return "Apr";
        else if (s == "Apr")
            return "May";
        else if (s == "May")
            return "Jun";
        else if (s == "Jun")
            return "Jul";
        else if (s == "Jul")
            return "Aug";
        else if (s == "Aug")
            return "Sep";
        else if (s == "Sep")
            return "Oct";
        else if (s == "Oct")
            return "Nov";
        else if (s == "Nov")
            return "Dec";
        else if (s == "Dec")
            return "Jan";
        else
            return "";


    }
}