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

public partial class Rebelfone_Rpt_Sim_CountryWise : System.Web.UI.Page
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

            Report objCountrySale = new Report();


            DataSet ds = new DataSet();


            DataSet ds1 = new DataSet();

            DataSet ds2 = new DataSet();

            string start_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;
            string end_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;
            string startdate2 = "01" + "/01/" + drpYearCompare1.SelectedItem.Value;
            string end_date2 = "12" + "/31/" + drpYearCompare2.SelectedItem.Value;
            end_date = Convert.ToDateTime(start_date.ToString()).AddMonths(1).ToString("MM/dd/yyyy");    
  
            ds = objCountrySale.GetSimByCountry(start_date, end_date);

            ds1 = objCountrySale.GetCountrySaleCompareReport(startdate2, end_date2, Convert.ToInt32(drpMonth.SelectedItem.Value));

            ds2 = objCountrySale.GetCountrySaleCompareYearReport(startdate2, end_date2);

            if (ds1.Tables["CountrySale_Compare"].Rows.Count > 0)
            {
                //Crystal Report****************
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/Rpt_MainCountrySale.rpt"));
                rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");
                foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
                {
                    string SubRepName = ((SubreportObject)repOp).SubreportName;
                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];
                    if (SubRepName == "SimSaleCountryWise.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["SimByCountry"]);
                    }
                    if (SubRepName == "Rpt_CountrySale1.rpt")
                    {
                        subRepDoc.SetDataSource(ds1.Tables["CountrySale_Compare"]);// 
                    }
                    if (SubRepName == "Rpt_CountrySale2.rpt")
                    {
                        subRepDoc.SetDataSource(ds2.Tables["CountrySale_Compare"]);// 
                    }

                    if (SubRepName == "RPT_CountryYearSale.rpt")
                    {
                        subRepDoc.SetDataSource(ds2.Tables["CountrySale_Compare"]);// 
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