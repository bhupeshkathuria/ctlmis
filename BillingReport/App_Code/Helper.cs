using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
/// <summary>
/// Summary description for Helper
/// </summary>
public  class Helper
{
	
    public  string getmonthname(int month)
    {
        string month_name = null;
        switch (month)
        {

            case 1: month_name = "Jan";
                break;
            case 2: month_name = "Feb";
                break;
            case 3: month_name = "Mar";
                break;
            case 4: month_name = "Apr";
                break;
            case 5: month_name = "May";
                break;
            case 6: month_name = "Jun";
                break;
            case 7: month_name = "Jul";
                break;
            case 8: month_name = "Aug";
                break;
            case 9: month_name = "Sep";
                break;
            case 10: month_name = "Oct";
                break;
            case 11: month_name = "Nov";
                break;
            case 12: month_name = "Dec";
                break;
        }
        return month_name;
    }

    public int getmonthdays(int month)
    {
        int month_days = 0;
        switch (month)
        {

            case 1: month_days = 31;
                break;
            case 2: month_days = 29;
                break;
            case 3: month_days = 31;
                break;
            case 4: month_days = 30;
                break;
            case 5: month_days = 31;
                break;
            case 6: month_days = 30;
                break;
            case 7: month_days = 31;
                break;
            case 8: month_days = 31;
                break;
            case 9: month_days = 30;
                break;
            case 10: month_days = 31;
                break;
            case 11: month_days = 30;
                break;
            case 12: month_days = 31;
                break;
        }
        return month_days;
    }

    public static void ExportToExcel(string strFileName, GridView dg)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader(
           "content-disposition", string.Format("attachment; filename={0}", strFileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Charset = "";

        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

        // Create a form to contain the grid
        HtmlForm frm = new HtmlForm();
        dg.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(dg);
        frm.RenderControl(oHtmlTextWriter);

        //dg.RenderControl(oHtmlTextWriter);

        HttpContext.Current.Response.Write(oStringWriter.ToString());
        HttpContext.Current.Response.End();

    }

    public static Dictionary<string, string> BindYear()
    {
     Dictionary<string, string> list = new Dictionary<string, string>();
     for (int i = DateTime.Now.Year; i >= 2008; i--)
     {
         list.Add(i.ToString(), i.ToString());
     }
     return list;
    }

    public static Dictionary<string, string> BindMonth()
    {
     Dictionary<string, string> list = new Dictionary<string, string>();
     list.Add("1", "Jan");
     list.Add("2", "Feb");
     list.Add("3", "Mar");
     list.Add("4", "Apr");
     list.Add("5", "May");
     list.Add("6", "Jun");
     list.Add("7", "Jul");
     list.Add("8", "Aug");
     list.Add("9", "Sep");
     list.Add("10", "Oct");
     list.Add("11", "Nov");
     list.Add("12", "Dec");
     return list;
    }

}