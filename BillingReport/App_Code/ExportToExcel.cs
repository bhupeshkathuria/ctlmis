using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ExportToExcel
/// </summary>
public class ExportToExcel
{
	public ExportToExcel()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void ExportToExcelGridView(GridView grdview)
    {
          System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdview.GridLines = GridLines.Both;
            grdview.HeaderStyle.Font.Bold = true;
            grdview.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Flush();
            //Response.End();
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}