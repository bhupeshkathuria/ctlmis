using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Clay.RAD;
using System.Data;
using System.Text;
public partial class Techscoot_rptdailysale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                DateTime fromdate =Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");
                DateTime todate = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
                getTotalsalerpt(fromdate, todate);
            }

            
        }
        catch (Exception ex)
        {
        }
    }
    public void getTotalsalerpt(DateTime from, DateTime todate)
    {
        

       
        techscoot_sale objorder = new techscoot_sale();
        DataSet dsorder = new DataSet();
        DataSet dsmap = new DataSet();
        dsorder = objorder.GetDailyTotalSale(from, todate);
        
        // dsmap = objorder.GetDailyTotalSaleMap();
        if (dsorder.Tables[0].Rows.Count > 0)
        {
            txtfromdate.Text = from.ToString("yyyy-MM-dd");
            txttodate.Text = todate.ToString("yyyy-MM-dd");
            grdtechscootsale.DataSource = dsorder.Tables[0];
            grdtechscootsale.DataBind();
              //chart_bind(dsmap);
             // dsrnew(dsmap.Tables[0]);
          //  btnExport.Visible = true;


        }
        else
        {
            txtfromdate.Text = from.ToString("yyyy-MM-dd");
            txttodate.Text = todate.ToString("yyyy-MM-dd");
            grdtechscootsale.DataSource = null;
            grdtechscootsale.DataBind();
            //btnExport.Visible = false;
        }
    }
    public void getdailyrpt(DateTime from,DateTime todate,string flag)
    {
        techscoot_sale objorder = new techscoot_sale();
        DataSet dsorder = new DataSet();
        dsorder = objorder.GetDailySale(from, todate, flag);

        if (dsorder.Tables[0].Rows.Count > 0)
        {
            txtfromdate.Text = from.ToString("yyyy-MM-dd");
            txttodate.Text = todate.ToString("yyyy-MM-dd");
            grdcard.DataSource = dsorder.Tables[0];
            grdcard.DataBind();
            btnExport.Visible = true;


        }
        else
        {
            txtfromdate.Text = from.ToString("yyyy-MM-dd");
            txttodate.Text = todate.ToString("yyyy-MM-dd");
            grdcard.DataSource = null;
            grdcard.DataBind();
            btnExport.Visible = false;
        }
    }
    protected void lnksearch_Click(object sender, EventArgs e)
    {
        
        techscoot_sale objorder = new techscoot_sale();
        DataSet dsorder = new DataSet();
        dsorder = objorder.GetDailyTotalSale(Convert.ToDateTime(txtfromdate.Text.Trim()), Convert.ToDateTime(txttodate.Text.Trim()));

        if (dsorder.Tables[0].Rows.Count > 0)
        {

            grdtechscootsale.DataSource = dsorder.Tables[0];
            grdtechscootsale.DataBind();
           // chart_bind(dsorder);
            grdcard.DataSource = null;
            grdcard.DataBind();



        }
        else
        {
            grdtechscootsale.DataSource = null;
            grdtechscootsale.DataBind();
            grdcard.DataSource = null;
            grdcard.DataBind();
           
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
          
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (grdcard.Rows.Count > 0)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter str = new StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);

            grdcard.RenderControl(HtmlTextWriter);
            Response.Write(str.ToString());
            Response.End();
        }

    }
    decimal _totalamt = 0;
    protected void grdcard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblamount = (Label)e.Row.FindControl("lblamount");
            _totalamt += Convert.ToDecimal(lblamount.Text);
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbltotal = (Label)e.Row.FindControl("lbltotal");
            lbltotal.Text = _totalamt.ToString();
        }
    }
    protected void grdcard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcard.PageIndex = e.NewPageIndex;
        lnksearch_Click(sender, e);
    }
    protected void grdtechscootsale_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            string from = string.Empty;
            string to = string.Empty;
            // DateTime abc;
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblfromdate = (Label)gvRow.FindControl("lblfromdate");
            Label lbltodate = (Label)gvRow.FindControl("lbltodate");
            Label lbldatehide = (Label)gvRow.FindControl("lbldatehide");

            from = Convert.ToDateTime(lbldatehide.Text).ToString("yyyy-MM-dd");
            to = Convert.ToDateTime(lbldatehide.Text).ToString("yyyy-MM-dd");
            string _flag = e.CommandArgument.ToString();
            getdailyrpt(Convert.ToDateTime(from), Convert.ToDateTime(to), _flag);
        }
        catch (Exception ex)
        {

        }


    }
    #region Varibles
    decimal plan1 = 0;
    decimal plan2 = 0;
    decimal plan3 = 0;
    decimal plan4 = 0;
    decimal totalsale = 0;
    decimal totalepin = 0;
    decimal totaltechscoot = 0;
    decimal totalbingsale = 0;
    
    #endregion
    protected void grdtechscootsale_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl99 = (Label)e.Row.FindControl("lbl99");
                Label lbl149 = (Label)e.Row.FindControl("lbl149");
                Label lbl199 = (Label)e.Row.FindControl("lbl199");
                Label lbl299 = (Label)e.Row.FindControl("lbl299");
                Label lbltotalSale = (Label)e.Row.FindControl("lbltotalSale");
                Label lblpayEpn = (Label)e.Row.FindControl("lblpayEpn");
                Label lblPayTechscoot = (Label)e.Row.FindControl("lblPayTechscoot");
                Label lblBingsale = (Label)e.Row.FindControl("lblBingsale");
                plan1 += Convert.ToDecimal(lbl99.Text);
                plan2 += Convert.ToDecimal(lbl149.Text);
                plan3 += Convert.ToDecimal(lbl199.Text);
                plan4 += Convert.ToDecimal(lbl299.Text);
                totalsale += Convert.ToDecimal(lbltotalSale.Text);
                totalepin += Convert.ToDecimal(lblpayEpn.Text);
                totaltechscoot += Convert.ToDecimal(lblPayTechscoot.Text);
                if(lblBingsale.Text!="NA")
                totalbingsale += Convert.ToDecimal(lblBingsale.Text);
                else
                    totalbingsale += 0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbltotal99 = (Label)e.Row.FindControl("lbltotal99");
                Label lbltotal149 = (Label)e.Row.FindControl("lbltotal149");
                Label lbltotal199 = (Label)e.Row.FindControl("lbltotal199");
                Label lbltotal299 = (Label)e.Row.FindControl("lbltotal299");
                Label lblgrosssale = (Label)e.Row.FindControl("lblgrosssale");
                Label lbltotalepn = (Label)e.Row.FindControl("lbltotalepn");
                Label lbltotaltechscoot = (Label)e.Row.FindControl("lbltotaltechscoot");
                Label lbltotalBingsale = (Label)e.Row.FindControl("lbltotalBingsale");

                lbltotal99.Text = plan1.ToString();
                lbltotal149.Text = plan2.ToString();
                lbltotal199.Text = plan3.ToString();
                lbltotal299.Text = plan4.ToString();
                lblgrosssale.Text = totalsale.ToString();
                lbltotalepn.Text = totalepin.ToString();
                lbltotaltechscoot.Text = totaltechscoot.ToString();
                
                lbltotalBingsale.Text = totalbingsale.ToString();

            }
        }
        catch (Exception ex)
        {

        }
    }

    private void chart_bind(DataSet ds)
    {
        StringBuilder str = new StringBuilder();
        // here i am using SqlDataAdapter for the sql server select query
        //SqlDataAdapter adp = new SqlDataAdapter("select top(7)* from tb_exp", con);
        // here am taking datatable
        DataTable dt = new DataTable();

        dt = ds.Tables[0];
        try
        {
            
            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Years');
        data.addColumn('number', 'TotalSale');
        data.addColumn('number', 'TotalSales');

        data.addRows(" + dt.Rows.Count + ");");
            Int32 i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
           
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Years"].ToString() + "');");               
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["TotalSale"].ToString() + ") ;");             
                str.Append(" data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["TotalSales"].ToString() + ");");
            }
           
            str.Append("   var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");           
            str.Append(" chart.draw(data, {width: 600, height: 240, title: 'Company Performance',");            
            str.Append("vAxis: {title: 'Year', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            //lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');


            //con.Close();
        }
        catch
        {

        }
        finally
        {
            // con.Close();
        }

    }

    private void dsrnew(DataTable dtnew)
    {
        StringBuilder str = new StringBuilder();
        try
        {
            // here datatale dt is fill wit the adp
            // adp.Fill(dt);
            // this string m catching in the stringbuilder class
            // in the str m writing same javascript code that is given by the google.

            str.Append(@"<script type=text/javascript>  google.load('visualization', '1', {'packages':['corechart']});
                     google.setOnLoadCallback(drawChart);
                     function drawChart() {
                     var data = new google.visualization.DataTable();");
            // but m changing  only below line
            // (" data.addColumn('string'(datatype), 'student_name'(column name));");
            // str.Append(" data.addColumn('number'(datatype), 'average_marks'(column name));");
            // my data that will come from the sql server
            str.Append(" data.addColumn('string', 'Years');");
            str.Append(" data.addColumn('number', 'Amount');");
           // str.Append(" data.addColumn('number', 'TotalSale');");
            str.Append(" data.addRows([");
            // here i am declairing the variable i in int32 for the looping statement
            Int32 i;
            // loop start from 0 and its end depend on the value inside dt.Rows.Count - 1
            for (i = 0; i <= dtnew.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" +   dtnew.Rows[i]["Years"].ToString()  + "'," + dtnew.Rows[i]["Amount"].ToString() + "],");
                //_totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
            }
            // other all string is fill according to the javascript code
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 600,backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'true', height: 500,vAxis: {title: 'Year', maxValue: 100},title: 'Company Performance'});}");
            //str.Append(" chart.draw(data, {width: 400, height: 240, is3D: 'true', title: 'Company Performance'});");
            str.Append("</script>");
            // here am using literal conrol to display the complete graph colors:['#FF1493','#00BFFF','#696969','#1E90FF','#B22222','#228B22','#FF00FF','#DCDCDC','#F8F8FF','#FFD700','#DAA520','#808080','#008000','#ADFF2F','#F0FFF0', '#FF69B4','#CD5C5C','#4B0082','#FFFFF0','#F0E68C','#E6E6FA','#FFF0F5','#7CFC00','#FFFACD','#ADD8E6','#F08080','#4169E1','#E0FFFF','#FAFAD2','#D3D3D3','#90EE90','#FFB6C1','#FFA07A','#20B2AA','#87CEFA','#778899','#B0C4DE','#FFFFE0','#00FF00','#32CD32','#FAF0E6','#FF00FF','#800000','#66CDAA','#0000CD','#BA55D3','#9370DB','#3CB371','#7B68EE','#00FA9A','#48D1CC','#C71585','#191970','#F5FFFA','#FFE4E1','#FFE4B5','#FFDEAD','#000080','#FDF5E6','#808000','#6B8E23','#FFA500','#FF4500','#DA70D6','#EEE8AA','#98FB98','#AFEEEE','#DB7093','#FFEFD5','#FFDAB9','#CD853F','#FFC0CB','#DDA0DD','#B0E0E6','#800080','#FF0000','#BC8F8F']
            //lt.Text = str.ToString().TrimEnd(',');
            // con.Close();
        }
        catch { }
    }

    //private void ExceptionMessage(string str)
    //{
    //    panel.Visible = true;
    //    imgMsg2.ImageUrl = "Error_red.png";
    //    lblmsg2.CssClass = "errorMsgRed";
    //    lblmsg2.Text = str;
    //    return;
    //}

    //private void SuccessMessage(string str)
    //{
    //    panel.Visible = true;
    //    imgMsg2.ImageUrl = "Saved_green.png";
    //    lblmsg2.CssClass = "errorMsgGreen";
    //    lblmsg2.Text = str;
    //    return;
    //}

    protected void DownloadFile(object sender, EventArgs e)
    {

        string filePath = (sender as LinkButton).CommandArgument;
        Label lblFilename = new Label();
        lblFilename.Text = (sender as LinkButton).CommandArgument;
        if (filePath != string.Empty && filePath != ("N/A"))
        {
            if (lblFilename.Text.EndsWith(".txt"))
            {
                Response.ContentType = "application/txt";
            }
            else if (lblFilename.Text.EndsWith(".pdf"))
            {
                Response.ContentType = "application/pdf";
            }
            else if (lblFilename.Text.EndsWith(".docx"))
            {
                Response.ContentType = "application/docx";
            }
            else
            {
                Response.ContentType = "image/jpg";
            }

            //string filePath = lblFilename.Text;

            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath("~/Aggrement/") + filePath);
            Response.End();
        }
        else
        {
            //ExceptionMessage("No File Exist");
        }
    }

        
    //protected void lblViewPo_Click(object sender, EventArgs e)
    //{
    //    string filePath = (sender as LinkButton).CommandArgument;
    //    Label lblFilename = new Label();
    //    lblFilename.Text = EncryptDecrypt.Encrypt(filePath); 

    //    string _url = "http://techscoot.com/Download.aspx?fname=" + lblFilename.Text;

    //    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.open(\"" + _url + "\");", true);
    //}


    public string GetUrl(object val)
    {
        string url = string.Empty;

        if (val != null)
        {
            string fileName = EncryptDecrypt.Encrypt("type=A&fname=" + val.ToString());//val.ToString());
            url = "http://techscoot.com/Downloadpdf.aspx?" + fileName;
        }

        return url;
    }
}