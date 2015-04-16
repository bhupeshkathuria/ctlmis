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

public partial class Rebelfone_Rpt_SaleComparission : System.Web.UI.Page
{
    ReportDocument doc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
        CrystalReportViewer1.DisplayGroupTree = false;
        DisplayReportSimSaleYearWise();
        
    }

   

    private void DisplayReportSimSaleYearWise()
    {

        ReportDocument crystalReport = new ReportDocument();

        crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/rptTest.rpt"));
        crystalReport.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");
        CrystalReportViewer1.ReportSource = crystalReport;

        //Rebelfone.Report.Report objReport = new Report();

        //ReportDocument crystalReport = new ReportDocument();

        //crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/SimSaleYearWise.rpt"));

        //DataSet ds = objReport.GetSimYearComparissionReport("","");
        //DataTable dt = ds.Tables[0];

        //if (dt.Rows.Count == 0)
        //{
        //    lblMsg.Text = "No Record found";

        //}
        //else
        //{
        //    crystalReport.SetDataSource(dt);
        //    CrystalReportViewer1.ReportSource = crystalReport;
        //}
       
    }
}