using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Clay.Sale.Bll;
public partial class frmDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayReport();
        
    }
    private void DisplayReport()
    {

        try
        {
            DataSet ds = new dsReport();
            SalesSummaryReport objSale = new SalesSummaryReport();
            ds = objSale.GetHomeDashboard();
            if (ds.Tables["Product"].Rows.Count > 0)
            {
                //Crystal Report****************
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(Server.MapPath("rptDashboard.rpt"));
                //rptDoc.SetDataSource(ds.Tables["Product"]);
                foreach (ReportObject repOp in rptDoc.ReportDefinition.ReportObjects)
                {                    
                    string SubRepName = ((SubreportObject)repOp).SubreportName;                    
                    ReportDocument subRepDoc = rptDoc.Subreports[SubRepName];
                    if (SubRepName == "rptSaleDashboard.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["Product"]);
                    }
                    if (SubRepName == "rptReceivable.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["Receivable"]);
                    }
                    if (SubRepName == "rptBilling.rpt")
                    {
                        subRepDoc.SetDataSource(ds.Tables["Billing"]);
                    }                    
                }
                CrystalReportViewer1.ReportSource = rptDoc;
                CrystalReportViewer1.DataBind();
                CrystalReportViewer1.DisplayGroupTree = false;
                //CrystalReportViewer1.RefreshReport();
                //ReportViewer************************
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ds.Tables["Product"]));
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptSaleDashboard.rdlc");
                //ReportViewer1.LocalReport.Refresh();

            }
            //if (ds.Tables["Receivable"].Rows.Count > 0)
            //{
            //    ReportDocument rptDoc = new ReportDocument();
            //    rptDoc.Load(Server.MapPath("rptReceivable.rpt"));
            //    rptDoc.SetDataSource(ds.Tables["Receivable"]);
            //    CrystalReportViewer2.ReportSource = rptDoc;
            //    CrystalReportViewer2.DataBind();
            //    CrystalReportViewer2.DisplayGroupTree = false;
            //}
            //if (ds.Tables["Billing"].Rows.Count > 0)
            //{
            //    ReportDocument rptDoc = new ReportDocument();
            //    rptDoc.Load(Server.MapPath("rptBilling.rpt"));
            //    rptDoc.SetDataSource(ds.Tables["Billing"]);
            //    CrystalReportViewer3.ReportSource = rptDoc;
            //    CrystalReportViewer3.DataBind();
            //    CrystalReportViewer3.DisplayGroupTree = false;
            //}
        }
        catch (Exception ex)
        {
            ex.ToString();
        }


    }
}