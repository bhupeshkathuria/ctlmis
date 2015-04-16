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


public partial class Rebelfone_Rpt_Month : System.Web.UI.Page
{
    ReportDocument doc;

    protected void Page_Load(object sender, EventArgs e)
    {

      //  DisplayReportSimSaleDayWise();
       
    }



   

    //private void DisplayReportSimSaleDayWise()
    //{
    //    lblMsg.Text = string.Empty;

    //    Rebelfone.Report.Report objReport = new Report();

    //    ReportDocument crystalReport = new ReportDocument();

    //    crystalReport.Load(Server.MapPath("~/Rebelfone_RPT/SimSaleDayWise.rpt"));

    //    string start_date = "01/" + drpMonth.SelectedItem.Value + "/" + drpYear.SelectedItem.Value;

    //    string end_date = "01/" + ((GetEndMonth(drpMonth.SelectedItem.Value) == "Jan") ? "Jan" : GetEndMonth(drpMonth.SelectedItem.Value)) + "/" + ((drpMonth.SelectedItem.Value == "Dec") ? (Convert.ToInt32(drpYear.SelectedItem.Value) + 1).ToString() : drpYear.SelectedItem.Value);

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
       
      //  DisplayReportSimSaleDayWise();
    }
}