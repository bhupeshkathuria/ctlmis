using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Rebelfone.Report;
using System.Threading;


public partial class Rebelfone_Rpt_SIMSALE : System.Web.UI.Page
{
    ReportDocument doc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpMonth.SelectedValue = DateTime.Now.ToString("MM");
            //drpMonth.SelectedValue = DateTime.Now.ToString("MM");
        }
        DisplayReport();
       // DisplayReportSimSaleDayWise();
       
    }

    private void DisplayReport()
    {

        try
        {
            Report objSim = new Report();
            DataSet ds = new DataSet();
            DataSet ds1 = new dsReport();

            string start_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

            string end_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

            end_date = Convert.ToDateTime(start_date.ToString()).AddMonths(1).ToString("MM/dd/yyyy");    

            ds = objSim.GetSimMonthReport(start_date, end_date);

            ds1 = objSim.GetSimYearReport(drpYearCompare1.SelectedValue, drpYearCompare2.SelectedValue);


            if (ds.Tables["SIM_Sale"].Rows.Count > 0)
            {
                //Crystal Report****************
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/RptMainSIMSale.rpt"));
                rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");
                foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
                {
                    string SubRepName = ((SubreportObject)repOp).SubreportName;
                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];
                    if (SubRepName == "SimSaleYearWise.rpt")
                    {
                        subRepDoc.SetDataSource(ds1.Tables["MonthWise"]);
                    }
                    if (SubRepName == "SimSaleDayWise.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["SIM_Sale"]);// 
                    }
                    if (SubRepName == "Rpt_SimSaleYear.rpt")
                    {
                        subRepDoc.SetDataSource(ds1.Tables["VisitorsYear"]);// 
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

   

    //private void DisplayReportSimSaleDayWise()
    //{
    //    lblMsg.Text = string.Empty;

    //    Rebelfone.Report.Report objReport = new Report();

    //    ReportDocument crystalReport = new ReportDocument();

    //    crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/SimSaleDayWise.rpt"));

     //  string start_date = "01/" + drpMonth.SelectedItem.Value + "/" + drpYear.SelectedItem.Value;

      //  string end_date = "01/" + ((GetEndMonth(drpMonth.SelectedItem.Value) == "Jan") ? "Jan" : GetEndMonth(drpMonth.SelectedItem.Value)) + "/" + ((drpMonth.SelectedItem.Value == "Dec") ? (Convert.ToInt32(drpYear.SelectedItem.Value) + 1).ToString() : drpYear.SelectedItem.Value);

    //    SqlParameter[] parameters = new SqlParameter[]
    //    {
    //          new SqlParameter("start_date",start_date),
    //          new SqlParameter("end_date",end_date)
    //    };

    //    DataSet ds = objReport.GetSimMonthReport(start_date, end_date);// SqlHelper.ExecuteDataset(ConString, CommandType.StoredProcedure, "SimSaleDayWise", parameters);

    //    DataTable dt = ds.Tables[0];

    //    if (dt.Rows.Count == 0)
    //    {
    //        lblMsg.Text = "No Record found";

    //    }
    //    else
    //    {
    //        crystalReport.SetDataSource(dt);
    //        CrystalReportViewer1.ReportSource = crystalReport;
    //        CrystalReportViewer1.DisplayGroupTree = false;
    //    }
        
    //}

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        DisplayReport();
    }
    protected void btmYearWise_Click(object sender, EventArgs e)
    {
        DisplayReport();
    }
}