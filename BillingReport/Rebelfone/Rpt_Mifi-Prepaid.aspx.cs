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

            DisplayReport();
        }
      
       
    }

    private void DisplayReport()
    {

        Report objSim = new Report();
        DataSet ds = new DataSet();
        DataSet ds1 = new dsReport();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new dsReport();

        string start_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

        string end_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

        end_date = Convert.ToDateTime(start_date.ToString()).AddMonths(1).ToString("MM/dd/yyyy");

        ds = objSim.GetPrepaidMonthReport(start_date, end_date);

        ds1 = objSim.GetPrepaidSimYearReport(drpYearCompare1.SelectedValue, drpYearCompare2.SelectedValue);

        ds2 = objSim.GetMIfiMonthReport(start_date, end_date);

        ds3 = objSim.GetMifiYearReport(drpYearCompare1.SelectedValue, drpYearCompare2.SelectedValue);


        if (ds1.Tables[0].Rows.Count > 0)
        {
            //Crystal Report****************
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/RptMainMifiPre.rpt"));
            rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");
            foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
            {
                string SubRepName = ((SubreportObject)repOp).SubreportName;
                ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];
                if (SubRepName == "SimSaleYearWise.rpt")
                {
                    subRepDoc.SetDataSource(ds1.Tables["MonthWise"]);
                }

                if (SubRepName == "MifiSaleYearWise.rpt")
                {
                    subRepDoc.SetDataSource(ds3.Tables["MonthWise"]);
                }
                if (SubRepName == "PrepaidSimSaleDayWise.rpt")
                {
                    subRepDoc.SetDataSource(ds.Tables["SIM_Sale"]);
                }
                if (SubRepName == "MifiSaleDayWise.rpt")
                {
                    subRepDoc.SetDataSource(ds2.Tables["SIM_Sale"]);
                }


                if (SubRepName == "MifiSaleYear.rpt")
                {
                    subRepDoc.SetDataSource(ds3.Tables["VisitorsYear"]);
                }

                if (SubRepName == "Rpt_SimSaleYear.rpt")
                {
                    subRepDoc.SetDataSource(ds1.Tables["VisitorsYear"]);
                }
            }
            CrystalReportViewer1.ReportSource = rptDoc;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.DisplayGroupTree = false;


        }
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