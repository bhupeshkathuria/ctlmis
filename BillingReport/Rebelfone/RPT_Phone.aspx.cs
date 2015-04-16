using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using Rebelfone.Report;
using System.Threading;

public partial class Rebelfone_Rpt_Airtime_Phone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpMonth.SelectedValue = DateTime.Now.ToString("MM");
            
        }

        GetPhoneMainReport();
        // DisplayReport();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GetPhoneMainReport();


    }

    protected void btmYearWise_Click(object sender, EventArgs e)
    {
        GetPhoneMainReport();
    }

    

    private void GetPhoneMainReport()
    {

        Rebelfone.Report.Report objReport = new Report();

        string start_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

        string end_date = drpMonth.SelectedItem.Value + "/01/" + drpYear.SelectedItem.Value;

        string startdate2 = "01" + "/01/" + drpYearCompare1.SelectedItem.Value;

        string end_date2 = "12" + "/31/" + drpYearCompare2.SelectedItem.Value;

        end_date = Convert.ToDateTime(start_date.ToString()).AddMonths(1).ToString("MM/dd/yyyy");

        end_date2 = Convert.ToDateTime(end_date2.ToString()).AddMonths(1).ToString("MM/dd/yyyy");


       

        DataSet ds2 = objReport.GetPhone(start_date, end_date);

        DataSet ds22 = objReport.GetPhone(startdate2, end_date2);

       

        ReportDocument rptDoc = new ReportDocument();

        rptDoc.Load(Server.MapPath("~/Rebelfone_RPT/Rpt_Main_Phone.rpt"));

        rptDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

        if (ds22.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = "";

            foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
            
            {
                if (repOp.Kind == ReportObjectKind.SubreportObject)
                {
                    string SubRepName = ((SubreportObject)repOp).SubreportName;
                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];
                    subRepDoc.SetDatabaseLogon("rebelsa", "dYe95Efs78*", "64.91.226.230", "Rebelfone");

                    if (SubRepName == "GetPhone2.rpt")
                    {
                        subRepDoc.SetDataSource(ds2.Tables[0]);
                    }
                    if (SubRepName == "GetPhone22.rpt")
                    {  
                        subRepDoc.SetDataSource(ds22.Tables[0]);
                    }
                    if (SubRepName == "GetPhone22Yearwise.rpt")
                    {
                        subRepDoc.SetDataSource(ds22.Tables[0]);
                    }
                   
                }
            }
        }

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.ReportSource = rptDoc;
        CrystalReportViewer1.DataBind();
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



    private DataTable GetPhoneDataTable()
    {
        Rebelfone.Report.Report objReport = new Report();

        string start_date = "01/" + drpMonth.SelectedItem.Value + "/" + drpYear.SelectedItem.Value;
        string end_date = "01/" + ((GetEndMonth(drpMonth.SelectedItem.Value) == "Jan") ? "Jan" : GetEndMonth(drpMonth.SelectedItem.Value)) + "/" + ((drpMonth.SelectedItem.Value == "Dec") ? (Convert.ToInt32(drpYear.SelectedItem.Value) + 1).ToString() : drpYear.SelectedItem.Value);

        SqlParameter[] parameters = new SqlParameter[]
        {
              new SqlParameter("start_date",start_date),
              new SqlParameter("end_date",end_date)
        };

        DataSet ds = objReport.GetPhone(start_date, end_date);
        DataTable dt = ds.Tables[0];
        return dt;
    }
}