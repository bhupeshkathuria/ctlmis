using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
//using InfoSoftGlobal;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using InfoSoftGlobal;
using System.Data.SqlClient;


public partial class frmdsrdashboard : System.Web.UI.Page
{
    DataSet dsSearchBranch = null;
    Clay.Common.Bll.Branch objBranch = null;
    Clay.Sale.Bll.CreditDetail objcr = new Clay.Sale.Bll.CreditDetail();
    DataSet ds_all = new DataSet();
    StringBuilder str = new StringBuilder();
    string X, Y;
    string GraphWidth = "450";
    string GraphHeight = "420";
    string[] color = new string[32];
    int _totalDSR = 0;
    private void loadYear()
    {
        //Load Years
        DataRow drYear;
        DataSet dsYear = new DataSet();
        DataTable dtYears = new DataTable();
        dsYear.Tables.Add(dtYears);

        DataColumn SNoColumn1 = new DataColumn();
        SNoColumn1.ColumnName = "yearVal";
        dsYear.Tables[0].Columns.Add(SNoColumn1);

        DataColumn SNoColumn2 = new DataColumn();
        SNoColumn2.ColumnName = "yearTxt";
        dsYear.Tables[0].Columns.Add(SNoColumn2);

        drYear = dsYear.Tables[0].NewRow();
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }

        ddlYear.DataSource = dsYear.Tables[0];
        ddlYear.DataTextField = "yearVal";
        ddlYear.DataValueField = "yearTxt";
        ddlYear.DataBind();
        ddlYear.SelectedIndex = 0;

    }

    private void ConfigureColors()
    {
        color[0] = "BDB76B";
        color[1] = "8B008B";
        color[2] = "556B2F";
        color[3] = "FF8C00";
        color[4] = "9932CC";
        color[5] = "8B0000";
        color[6] = "E9967A";
        color[7] = "8FBC8B";
        color[8] = "483D8B";
        color[9] = "2F4F4F";
        color[10] = "00CED1";
        color[11] = "9400D3";
        
 color[12] = "FAEBD7";
 color[13] = "00FFFF";
 color[14] = "7FFFD4";
 color[15] = "F0FFFF";
 color[16] = "F5F5DC";
 color[17] = "FFE4C4";
 color[18] = "000000";
 color[19] = "FFEBCD";
 color[20] = "0000FF";
 color[22] = "8A2BE2";
 color[23] = "A52A2A";
 color[24] = "DEB887";
 color[25] = "5F9EA0";
 color[26] = "7FFF00";
 color[27] = "D2691E";
 color[28] = "FF7F50";
 color[29] = "6495ED";
 color[30] = "FFF8DC";
 color[31] = "DC143C";
 

 //#FF1493
 //#00BFFF
 //#696969
 //#1E90FF
 //#B22222
 //#FFFAF0
 //#228B22
 //#FF00FF
 //#DCDCDC
 //#F8F8FF
 //#FFD700
 //#DAA520
 //#808080
 //#008000
 //#ADFF2F
 //#F0FFF0
 //#FF69B4
 //#CD5C5C
 //#4B0082
 //#FFFFF0
 //#F0E68C
 //#E6E6FA
 //#FFF0F5
 //#7CFC00
 //#FFFACD
 //#ADD8E6
 //#F08080
 //#E0FFFF
 //#FAFAD2
 //#D3D3D3
 //#90EE90
 //#FFB6C1
 //#FFA07A
 //#20B2AA
 //#87CEFA
 //#778899
 //#B0C4DE
 //#FFFFE0
 //#00FF00
 //#32CD32
 //#FAF0E6
 //#FF00FF
 //#800000
 //#66CDAA
 //#0000CD
 //#BA55D3
 //#9370DB
 //#3CB371
 //#7B68EE
 //#00FA9A
 //#48D1CC
 //#C71585
 //#191970
 //#F5FFFA
 //#FFE4E1
 //#FFE4B5
 //#FFDEAD
 //#000080
 //#FDF5E6
 //#808000
 //#6B8E23
 //#FFA500
 //#FF4500
 //#DA70D6
 //#EEE8AA
 //#98FB98
 //#AFEEEE
 //#DB7093
 //#FFEFD5
 //#FFDAB9
 //#CD853F
 //#FFC0CB
 //#DDA0DD
 //#B0E0E6
 //#800080
 //#FF0000
 //#BC8F8F
 //#4169E1

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadYear();
            LoadBranchTcbSearchBranch();
            ConfigureColors();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ds_all = objcr.Getdsr_rpt(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), Convert.ToInt32(ddlBranch.SelectedValue));
        
        DataTable dt_new = ds_all.Tables["new"];
        DataTable dt_old = ds_all.Tables["old"];
        DataTable dtFolNew = ds_all.Tables["followupnew"];
        DataTable dtFolOld = ds_all.Tables["followupold"];
        dsrnew(dt_new);
        dsrold(dt_old);
        dsrFollowupinnew(dtFolNew);
        dsrFollowupinold(dtFolOld);
       // CreatePieGraph(dt_new);
      //  CreateDoughnutGraph(dt_old);
        if (ds_all.Tables["totalnew"].Rows.Count > 0)
        {
            tr.Visible = true;
            tr1.Visible = true;
            lbltotalnew.Text = ds_all.Tables["totalnew"].Rows[0]["Total"].ToString();

            lblold.Text = ds_all.Tables["totalold"].Rows[0]["Total"].ToString();

            lblTotalFolNew.Text = ds_all.Tables["totalfolNew"].Rows[0]["Total"].ToString();

            lblTotalFolOld.Text = ds_all.Tables["totalfolOld"].Rows[0]["Total"].ToString();

            _totalDSR += _totalDSR + Convert.ToInt32(lbltotalnew.Text);

            _totalDSR += Convert.ToInt32(lblold.Text);
            _totalDSR += Convert.ToInt32(lblTotalFolNew.Text);
            _totalDSR += Convert.ToInt32(lblTotalFolOld.Text);

            lbltotaldsr.Text = "<b>Total DSR= " + _totalDSR.ToString() + "</b>";
        }
        else
        {
            tr.Visible = false;
            tr1.Visible =false;
        }
        btnexport.Visible = true;
    }

    decimal _totalnewmeeting = 0;

    private void dsrnew(DataTable dtnew)
    {
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
            str.Append(" data.addColumn('string', 'Empname');");
            str.Append(" data.addColumn('number', 'total');");
            str.Append(" data.addRows([");
            // here i am declairing the variable i in int32 for the looping statement
            Int32 i;
            // loop start from 0 and its end depend on the value inside dt.Rows.Count - 1
            for (i = 0; i <= dtnew.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" + (dtnew.Rows[i]["Total"].ToString()) + " [" + dtnew.Rows[i]["employeename"].ToString() + "]" + "'," + dtnew.Rows[i]["Total"].ToString() + "],");
                _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
            }
            // other all string is fill according to the javascript code
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_divnew'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 600,backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'True',legend:'right', height: 500,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Meeting In NEW Account '});}");
            str.Append("</script>");
            // here am using literal conrol to display the complete graph colors:['#FF1493','#00BFFF','#696969','#1E90FF','#B22222','#228B22','#FF00FF','#DCDCDC','#F8F8FF','#FFD700','#DAA520','#808080','#008000','#ADFF2F','#F0FFF0', '#FF69B4','#CD5C5C','#4B0082','#FFFFF0','#F0E68C','#E6E6FA','#FFF0F5','#7CFC00','#FFFACD','#ADD8E6','#F08080','#4169E1','#E0FFFF','#FAFAD2','#D3D3D3','#90EE90','#FFB6C1','#FFA07A','#20B2AA','#87CEFA','#778899','#B0C4DE','#FFFFE0','#00FF00','#32CD32','#FAF0E6','#FF00FF','#800000','#66CDAA','#0000CD','#BA55D3','#9370DB','#3CB371','#7B68EE','#00FA9A','#48D1CC','#C71585','#191970','#F5FFFA','#FFE4E1','#FFE4B5','#FFDEAD','#000080','#FDF5E6','#808000','#6B8E23','#FFA500','#FF4500','#DA70D6','#EEE8AA','#98FB98','#AFEEEE','#DB7093','#FFEFD5','#FFDAB9','#CD853F','#FFC0CB','#DDA0DD','#B0E0E6','#800080','#FF0000','#BC8F8F']
            ltnew.Text = str.ToString().TrimEnd(',');
            // con.Close();
        }
        catch { }
    }

    private void dsrold(DataTable dtold)
    {
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
            str.Append(" data.addColumn('string', 'Empname');");
            str.Append(" data.addColumn('number', 'total');");
            str.Append(" data.addRows([");
            // here i am declairing the variable i in int32 for the looping statement
            Int32 i;
            // loop start from 0 and its end depend on the value inside dt.Rows.Count - 1
            for (i = 0; i <= dtold.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" + (dtold.Rows[i]["Total"].ToString()) + " [" + dtold.Rows[i]["employeename"].ToString() + "]" + "'," + dtold.Rows[i]["Total"].ToString() + "],");
            }
            // other all string is fill according to the javascript code
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_divold'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
            str.Append("chart.draw(data, {width: 600,backgroundColor: 'transparent', height: 500,is3D:'True',animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Meeting In Old Account'});}");
            str.Append("</script>");
            // here am using literal conrol to display the complete graph colors:['#FF1493','#00BFFF','#696969','#1E90FF','#B22222','#228B22','#FF00FF','#DCDCDC','#F8F8FF','#FFD700','#DAA520','#808080','#008000','#ADFF2F','#F0FFF0', '#FF69B4','#CD5C5C','#4B0082','#FFFFF0','#F0E68C','#E6E6FA','#FFF0F5','#7CFC00','#FFFACD','#ADD8E6','#F08080','#4169E1','#E0FFFF','#FAFAD2','#D3D3D3','#90EE90','#FFB6C1','#FFA07A','#20B2AA','#87CEFA','#778899','#B0C4DE','#FFFFE0','#00FF00','#32CD32','#FAF0E6','#FF00FF','#800000','#66CDAA','#0000CD','#BA55D3','#9370DB','#3CB371','#7B68EE','#00FA9A','#48D1CC','#C71585','#191970','#F5FFFA','#FFE4E1','#FFE4B5','#FFDEAD','#000080','#FDF5E6','#808000','#6B8E23','#FFA500','#FF4500','#DA70D6','#EEE8AA','#98FB98','#AFEEEE','#DB7093','#FFEFD5','#FFDAB9','#CD853F','#FFC0CB','#DDA0DD','#B0E0E6','#800080','#FF0000','#BC8F8F']
            ltold.Text = str.ToString().TrimEnd(',');
            // con.Close();
        }
        catch { }
    }

    private void CreateDoughnutGraph(DataTable dt)
    {
        string strCaption = "Meeting IN Old Account";
        string strSubCaption = "For the year " + ddlYear.SelectedValue.ToString();
        string xAxis = "Name";
        string yAxis = "DSR";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr2 in dt.Rows)
        {
            strXML += "<set name='" + dr2["employeename"].ToString() + "' value='" + dr2["Total"].ToString() + "' color='" + color[i] + @"'/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral4.Text = FusionCharts.RenderChartHTML(
        //    "FusionCharts/FCF_Column3D.swf", // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

    private void CreatePieGraph(DataTable dt)
    {
        string strCaption = "Meeting NEW Account";
        string strSubCaption = "For the year "+ddlYear.SelectedValue.ToString();
        string xAxis = "employeename";
        string yAxis = "Total";

        //strXML will be used to store the entire XML document generated
        string strXML = null;

        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0'
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;

        foreach (DataRow dr2 in dt.Rows)
        {
            strXML += "<set name='" + dr2["employeename"].ToString() + "' value='" +  dr2["Total"].ToString() + "' color='" + color[i] + @"'/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        //FCLiteral3.Text = FusionCharts.RenderChartHTML("FusionCharts/FCF_Pie3D.swf", 
        //     // Path to chart's SWF
        //    "",                              // Leave blank when using Data String method
        //    strXML,                          // xmlStr contains the chart data
        //    "mygraph1",                      // Unique chart ID
        //    GraphWidth, GraphHeight,                   // Width & Height of chart
        //    false
        //    );
    }

    void LoadBranchTcbSearchBranch()
    {
        dsSearchBranch = new DataSet();
        objBranch = new Clay.Common.Bll.Branch();
        dsSearchBranch = objBranch.GetBranch();

        if (dsSearchBranch.Tables.Count > 0)
        {
            DataRow dr;
            dr = dsSearchBranch.Tables[0].NewRow();
            dr["branchname"] = "Select Branch";
            dr["branchid"] = 0;
            dsSearchBranch.Tables[0].Rows.InsertAt(dr, 0);
            ddlBranch.DataSource = dsSearchBranch.Tables[0];
            ddlBranch.DataTextField = "branchname";
            ddlBranch.DataValueField = "branchid";
            ddlBranch.DataBind();
        }
    }

    private void dsrFollowupinnew(DataTable dtFolNew)
    {
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
            str.Append(" data.addColumn('string', 'Empname');");
            str.Append(" data.addColumn('number', 'total');");
            str.Append(" data.addRows([");
            // here i am declairing the variable i in int32 for the looping statement
            Int32 i;
            // loop start from 0 and its end depend on the value inside dt.Rows.Count - 1
            for (i = 0; i <= dtFolNew.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" + (dtFolNew.Rows[i]["Total"].ToString()) + " [" + dtFolNew.Rows[i]["employeename"].ToString() + "]" + "'," + dtFolNew.Rows[i]["Total"].ToString() + "],");
                _totalnewmeeting += Convert.ToDecimal(dtFolNew.Rows[i]["Total"].ToString());
            }
            // other all string is fill according to the javascript code
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_DivFolNew'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 600,backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'True',legend:'right', height: 500,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Meeting In FollowUp NEW Account '});}");
            str.Append("</script>");
            // here am using literal conrol to display the complete graph colors:['#FF1493','#00BFFF','#696969','#1E90FF','#B22222','#228B22','#FF00FF','#DCDCDC','#F8F8FF','#FFD700','#DAA520','#808080','#008000','#ADFF2F','#F0FFF0', '#FF69B4','#CD5C5C','#4B0082','#FFFFF0','#F0E68C','#E6E6FA','#FFF0F5','#7CFC00','#FFFACD','#ADD8E6','#F08080','#4169E1','#E0FFFF','#FAFAD2','#D3D3D3','#90EE90','#FFB6C1','#FFA07A','#20B2AA','#87CEFA','#778899','#B0C4DE','#FFFFE0','#00FF00','#32CD32','#FAF0E6','#FF00FF','#800000','#66CDAA','#0000CD','#BA55D3','#9370DB','#3CB371','#7B68EE','#00FA9A','#48D1CC','#C71585','#191970','#F5FFFA','#FFE4E1','#FFE4B5','#FFDEAD','#000080','#FDF5E6','#808000','#6B8E23','#FFA500','#FF4500','#DA70D6','#EEE8AA','#98FB98','#AFEEEE','#DB7093','#FFEFD5','#FFDAB9','#CD853F','#FFC0CB','#DDA0DD','#B0E0E6','#800080','#FF0000','#BC8F8F']
            ltFolNew.Text = str.ToString().TrimEnd(',');
            // con.Close();
        }
        catch { }
    }

    private void dsrFollowupinold(DataTable dtFolOld)
    {
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
            str.Append(" data.addColumn('string', 'Empname');");
            str.Append(" data.addColumn('number', 'total');");
            str.Append(" data.addRows([");
            // here i am declairing the variable i in int32 for the looping statement
            Int32 i;
            // loop start from 0 and its end depend on the value inside dt.Rows.Count - 1
            for (i = 0; i <= dtFolOld.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" + (dtFolOld.Rows[i]["Total"].ToString()) + " [" + dtFolOld.Rows[i]["employeename"].ToString() + "]" + "'," + dtFolOld.Rows[i]["Total"].ToString() + "],");
                _totalnewmeeting += Convert.ToDecimal(dtFolOld.Rows[i]["Total"].ToString());
            }
            // other all string is fill according to the javascript code
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_DivFolOld'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 600,backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'True',legend:'right', height: 500,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Meeting In FollowUp Old Account '});}");
            str.Append("</script>");
            // here am using literal conrol to display the complete graph colors:['#FF1493','#00BFFF','#696969','#1E90FF','#B22222','#228B22','#FF00FF','#DCDCDC','#F8F8FF','#FFD700','#DAA520','#808080','#008000','#ADFF2F','#F0FFF0', '#FF69B4','#CD5C5C','#4B0082','#FFFFF0','#F0E68C','#E6E6FA','#FFF0F5','#7CFC00','#FFFACD','#ADD8E6','#F08080','#4169E1','#E0FFFF','#FAFAD2','#D3D3D3','#90EE90','#FFB6C1','#FFA07A','#20B2AA','#87CEFA','#778899','#B0C4DE','#FFFFE0','#00FF00','#32CD32','#FAF0E6','#FF00FF','#800000','#66CDAA','#0000CD','#BA55D3','#9370DB','#3CB371','#7B68EE','#00FA9A','#48D1CC','#C71585','#191970','#F5FFFA','#FFE4E1','#FFE4B5','#FFDEAD','#000080','#FDF5E6','#808000','#6B8E23','#FFA500','#FF4500','#DA70D6','#EEE8AA','#98FB98','#AFEEEE','#DB7093','#FFEFD5','#FFDAB9','#CD853F','#FFC0CB','#DDA0DD','#B0E0E6','#800080','#FF0000','#BC8F8F']
            ltFolOld.Text = str.ToString().TrimEnd(',');
            // con.Close();
        }
        catch { }
    }


}