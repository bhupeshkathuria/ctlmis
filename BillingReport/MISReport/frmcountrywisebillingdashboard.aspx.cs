using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.DataVisualization.Charting;
using InfoSoftGlobal;
public partial class MISReport_frmcountrywisebillingdashboard : System.Web.UI.Page
{
    string X, Y;
    string GraphWidth = "550";
    string GraphHeight = "420";
    string GraphWidthfirlecvel = "1000";
    string GraphHeightfirlecvel = "420";
    string[] color = new string[22];
    string[] colorfirlevel = new string[50];
    static int mylevel = 0;
    DataSet ds_collection = new DataSet();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        ConfigureColors();
        ConfigureColorsfirslevt();
        if (!IsPostBack)
        {
            pnlsearch.Visible = true;
            loadYear();
            mylevel = 0;
        }
        if (Request.QueryString["countryid"] != null)
        {
            pnlsearch.Visible = false;
            mylevel = Convert.ToInt32(Request.QueryString["level"]);
            if (mylevel == 2)
            {
                ddlMonth.SelectedValue = Request.QueryString["month"].ToString();
                ddlYear.SelectedValue = Request.QueryString["year"].ToString();
                lbllevel.Text ="Third Level "+ Request.QueryString["countryname"].ToString();
                // getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]));
                BindCalltype(Convert.ToInt32(Request.QueryString["month"]), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["countryid"]));
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // GenerateQuickStats();
        pnlsalewise.Visible = false;
        pnlCountryWise.Visible = true;
        BindGrid();
        if (mylevel == 0)
        {
            if (ddlreport.SelectedValue == "1")
            {
                //dsrnew("1");
                CreateFirstlvelGraph("1");
            }
            if (ddlreport.SelectedValue == "2")
            {
                // dsrnew("2");
                CreateFirstlvelGraph("2");

            }
            if (ddlreport.SelectedValue == "3")
            {
                // dsrnew("3");
                CreateFirstlvelGraph("3");

            }
        }
        // BindChart();
        // chart_bind();
        //ddlreport_SelectedIndexChanged(sender, e);

    }
    

    private void BindChart()
    {

        StringBuilder str = new StringBuilder();
        DataTable dt = new DataTable();
        try
        {
            dt = Session["dschart"] as DataTable; ;

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'countryname');
        data.addColumn('number', 'totalSale');     
 
        data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["countryname"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["totalSale"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 700, height: 300, title: 'Company Performance',");
            str.Append("hAxis: {title: 'Year', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        { }
    }

    private void ConfigureColors()
    {
        color[0] = "AFD8F8";
        color[1] = "F6BD0F";
        color[2] = "8BBA00";
        color[3] = "FF8E46";
        color[4] = "008E8E";
        color[5] = "D64646";
        color[6] = "8E468E";
        color[7] = "588526";
        color[8] = "B3AA00";
        color[9] = "008ED6";
        color[10] = "9D080D";
        color[11] = "A186BE";
        color[12] = "AFD8F8";
        color[13] = "F6BD0F";
        color[14] = "8BBA00";
        color[15] = "FF8E46";
        color[16] = "008E8E";
        color[17] = "D64646";
        color[18] = "8E468E";
        color[19] = "588526";
        color[20] = "B3AA00";
    }
    private void ConfigureColorsfirslevt()
    {
        colorfirlevel[0] = "AFD8F8";
        colorfirlevel[1] = "F6BD0F";
        colorfirlevel[2] = "8BBA00";
        colorfirlevel[3] = "FF8E46";
        colorfirlevel[4] = "008E8E";
        colorfirlevel[5] = "D64646";
        colorfirlevel[6] = "8E468E";
        colorfirlevel[7] = "588526";
        colorfirlevel[8] = "B3AA00";
        colorfirlevel[9] = "008ED6";
        colorfirlevel[10] = "9D080D";
        colorfirlevel[11] = "A186BE";
        colorfirlevel[12] = "AFD8F8";
        colorfirlevel[13] = "F6BD0F";
        colorfirlevel[14] = "8BBA00";
        colorfirlevel[15] = "FF8E46";
        colorfirlevel[16] = "008E8E";
        colorfirlevel[17] = "D64646";
        colorfirlevel[18] = "8E468E";
        colorfirlevel[19] = "588526";
        colorfirlevel[20] = "B3AA00";
        colorfirlevel[21] = "FAEBD7";
        colorfirlevel[22] = "00FFFF";
        colorfirlevel[23] = "7FFFD4";
        colorfirlevel[24] = "F0FFFF";
        colorfirlevel[25] = "F5F5DC";
        colorfirlevel[26] = "FFE4C4";
        colorfirlevel[27] = "000000";
        colorfirlevel[28] = "FFEBCD";
        colorfirlevel[29] = "0000FF";
        colorfirlevel[30] = "8A2BE2";
        colorfirlevel[31] = "A52A2A";
        colorfirlevel[32] = "DEB887";
        colorfirlevel[33] = "5F9EA0";
        colorfirlevel[34] = "7FFF00";
        colorfirlevel[35] = "D2691E";
        colorfirlevel[36] = "FF7F50";
        colorfirlevel[37] = "6495ED";
        colorfirlevel[38] = "FFF8DC";
        colorfirlevel[39] = "DC143C";
       
        
    }

    private void dsrnew(string reptype)
    {
        lbllevel.Text = "First Level " + ddlreport.SelectedItem.Text;
        StringBuilder str = new StringBuilder();
        try
        {
            DataTable dtnew = Session["dschart"] as DataTable; ;


            str.Append(@"<script type=text/javascript>  google.load('visualization', '1', {'packages':['corechart']});
                     google.setOnLoadCallback(drawChart);
                     function drawChart() {
                     var data = new google.visualization.DataTable();");



            Int32 i;
            if (reptype == "1")
            {
                str.Append(" data.addColumn('string', 'countryname');");
                str.Append(" data.addColumn('number', 'totalSale');");
                str.Append(" data.addRows([");
                for (i = 0; i <= dtnew.Rows.Count - 1; i++)
                {
                    // here i am fill the string builder with the value from the database
                    str.Append("['" + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                    //str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                    // _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
                }
            }
            else if (reptype == "2")
            {
                str.Append(" data.addColumn('string', 'countryname');");
                str.Append(" data.addColumn('number', 'totalBilling');");
                str.Append(" data.addRows([");
                for (i = 0; i <= dtnew.Rows.Count - 1; i++)
                {
                    // here i am fill the string builder with the value from the database
                    str.Append("['" + (dtnew.Rows[i]["totalBilling"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalBilling"].ToString() + "],");
                    //str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                    // _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
                }
            }
            else if (reptype == "3")
            {
                str.Append(" data.addColumn('string', 'countryname');");
                str.Append(" data.addColumn('number', 'arpugraph');");
                str.Append(" data.addRows([");
                for (i = 0; i <= dtnew.Rows.Count - 1; i++)
                {
                    // here i am fill the string builder with the value from the database
                    str.Append("['" + (dtnew.Rows[i]["arpugraph"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["arpugraph"].ToString() + "],");
                    //str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                    // _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
                }
            }
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 1400,isStacked:true, backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'True',legend:'right', height: 400,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Country Wise Billing DashBoard'});}");
            str.Append("</script>");

            lt.Text = str.ToString().TrimEnd(',');

        }
        catch { }
    }

    private void Bindgraph_WithService()
    {
        StringBuilder str = new StringBuilder();
        try
        {
            DataTable dtnew = Session["dschartservice"] as DataTable; ;


            str.Append(@"<script type=text/javascript>  google.load('visualization', '1', {'packages':['corechart']});
                     google.setOnLoadCallback(drawChart);
                     function drawChart() {
                     var data = new google.visualization.DataTable();");



            Int32 i;


            str.Append(" data.addColumn('string', 'packagetypename');");
            str.Append(" data.addColumn('number', 'total');");
                str.Append(" data.addRows([");
                for (i = 0; i <= dtnew.Rows.Count - 1; i++)
                {
                    // here i am fill the string builder with the value from the database
                    str.Append("['" + (dtnew.Rows[i]["total"].ToString()) + " [" + dtnew.Rows[i]["packagetypename"].ToString() + "]" + "'," + dtnew.Rows[i]["total"].ToString() + "],");
                    //str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                    // _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
                }
            
            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.PieChart(document.getElementById('divservice'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 800,isStacked:true, backgroundColor: 'transparent',alternatingRowStyle: 'true',is3D:'True',legend:'right', height: 300,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Country Wise Billing DashBoard'});}");
            str.Append("</script>");

            lpservice.Text = str.ToString().TrimEnd(',');

        }
        catch { }
    }

    private void Bindgraph_WithCallType()
    {
        StringBuilder str = new StringBuilder();
        try
        {
            DataTable dtnew = Session["dschartcalltype"] as DataTable; ;


            str.Append(@"<script type=text/javascript>  google.load('visualization', '1', {'packages':['corechart']});
                     google.setOnLoadCallback(drawChart);
                     function drawChart() {
                     var data = new google.visualization.DataTable();");



            Int32 i;


            str.Append(" data.addColumn('string', 'CallType');");
            str.Append(" data.addColumn('number', 'total');");
            str.Append(" data.addRows([");
            for (i = 0; i <= dtnew.Rows.Count - 1; i++)
            {
                // here i am fill the string builder with the value from the database
                str.Append("['" + (dtnew.Rows[i]["total"].ToString()) + " [" + dtnew.Rows[i]["CallType"].ToString() + "]" + "'," + dtnew.Rows[i]["total"].ToString() + "],");
                //str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
                // _totalnewmeeting += Convert.ToDecimal(dtnew.Rows[i]["Total"].ToString());
            }

            str.Append(" ]);");
            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('divservice'));");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");

            str.Append("chart.draw(data, {width: 1000, backgroundColor: 'transparent',alternatingRowStyle: 'true',legend:'right', height: 300,animation:{duration:500,easing: 'out',},vAxis: {minValue:0, maxValue:1000},title: 'Country Wise Billing DashBoard'});}");
            str.Append("</script>");

            lpservice.Text = str.ToString().TrimEnd(',');

        }
        catch { }
    }

    private void chart_bind()
    {
        // here i am using SqlDataAdapter for the sql server select query
        StringBuilder str = new StringBuilder();
        // here am taking datatable
        DataTable dt = new DataTable();
        try
        {
            // here datatale dt is fill wit the adp
            dt = Session["dschart"] as DataTable; ;
            // this string m catching in the stringbuilder class
            // in the str m writing same javascript code that is given by the google.
            // but m changing  only below line
            //data.addColumn('string'(datatype), 'Year'(columnname according to the sql table));
            //data.addColumn('number'(datatype), 'Sales'(columnname according to the sql table));
            //data.addColumn('number'(datatype), 'Expenses'(columnname according to the sql table));
            // my data that will come from the sql server
            // in the below line i need " in place of *
            // stringbuilder can't return us " so at the last line i am
            // replacing * with the " using Replace('*', '"'); function
            // and other code is same like the google code
            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'totalSale');
        data.addColumn('number', 'countryname');
        data.addColumn('number', 'arpu');

        data.addRows(" + dt.Rows.Count + ");");

            Int32 i;
            //here i am using for loop to fetch multiple recorod from the database
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                // i need this type of output " data.setValue(0, 0, '2004');",(1, 0, '2005');" * so on  in the first line so for this
                //m using i for the 1& 2 and so on . and after this i am writting zero and after this year using datatable
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["totalSale"].ToString() + "');");
                // i need this type of output " data.setValue(0, 1, 'sales');",(1, 1, 'sales');" * so on  in the first line so for this
                //m using i for the 1& 2 and so on . and after this i am writting 1 and after this sales using datatable
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["countryname"].ToString() + ") ;");
                // i need this type of output " data.setValue(0,2, 'expences');",(1, 2, 'sales');" * so on  in the first line so for this
                //m using i for the 1& 2 and so on . and after this i am writting 2 and after this expences using datatable
                str.Append(" data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["arpu"].ToString() + ");");



            }
            // the other code same like as google's javascript code
            str.Append("   var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
            // in the below line you can set width height of the chart according to your need
            str.Append(" chart.draw(data, {width: 600, height: 240, title: 'Company Performance',");
            //  str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
            str.Append("vAxis: {title: 'Year', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');



        }
        catch
        {

        }
        finally
        {

        }

    }

    private void BindGrid()
    {
        Clay.RAD.Billingsale objbill = new Clay.RAD.Billingsale();
        lbllevel.Text = "First Level " + ddlreport.SelectedItem.Text;
        mylevel = 0;
        if (mylevel == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
            //dt.Columns.Add("Amount", typeof(string));
            //dt.Columns.Add("insertdatetime", typeof(string));


            ds_collection = objbill.GetBillingDashBoard(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "month");
            Session["dschart"] = ds_collection.Tables[1];
            if (ds_collection.Tables["Billing"].Rows.Count > 0)
            {
                foreach (DataRow drrow in ds_collection.Tables[1].Rows)
                {
                    //string S =  dt.Columns.Add(drrow["countryname"].ToString()).ToString();
                    dt.Columns.Add(drrow["countryname"].ToString(), typeof(string));
                    //TemplateField templateEmail = new TemplateField();
                    //templateEmail.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, S);
                    //templateEmail.att
                }

                dt.AcceptChanges();
                #region Sale
                DataRow dr = dt.NewRow();
                foreach (DataRow drtxt in ds_collection.Tables["country"].Rows)
                {
                    #region Sales
                    DataRow[] dr_arr = ds_collection.Tables[1].Select("countryid=" + drtxt["countryid"].ToString());
                    if (dr_arr.Length > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName.ToString() == "Type")
                            {
                                dr[column] = "Sale";

                            }
                            if (column.ColumnName.ToString() == dr_arr[0]["countryname"].ToString())
                            {
                                //column = dr_arr[0]["countryname"].ToString();
                                dr[column] = dr_arr[0]["totalSale"].ToString();
                                break;
                            }

                        }

                    }
                    dr_arr = null;


                    #endregion
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                #endregion

                #region Biling
                DataRow dr1 = dt.NewRow();
                foreach (DataRow drtxt in ds_collection.Tables["country"].Rows)
                {
                    #region Billing
                    DataRow[] dr_arr = ds_collection.Tables[1].Select("countryid=" + drtxt["countryid"].ToString());
                    if (dr_arr.Length > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName.ToString() == "Type")
                            {
                                dr1[column] = "Billing";

                            }
                            if (column.ColumnName.ToString() == dr_arr[0]["countryname"].ToString())
                            {
                                //column = dr_arr[0]["countryname"].ToString();
                                dr1[column] = dr_arr[0]["bill"].ToString();
                                break;
                            }

                        }

                    }
                    dr_arr = null;


                    #endregion
                }
                dt.Rows.Add(dr1);
                dt.AcceptChanges();
                #endregion

                #region Arpu
                DataRow dr2 = dt.NewRow();
                foreach (DataRow drtxt in ds_collection.Tables["country"].Rows)
                {
                    #region Arpu
                    DataRow[] dr_arr = ds_collection.Tables[1].Select("countryid=" + drtxt["countryid"].ToString());
                    if (dr_arr.Length > 0)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName.ToString() == "Type")
                            {
                                dr2[column] = "Arpu";

                            }
                            if (column.ColumnName.ToString() == dr_arr[0]["countryname"].ToString())
                            {
                                //column = dr_arr[0]["countryname"].ToString();
                                dr2[column] = dr_arr[0]["arpu"].ToString();
                                break;
                            }

                        }

                    }
                    dr_arr = null;


                    #endregion
                }
                #endregion
                dt.Rows.Add(dr2);
                dt.AcceptChanges();
                pnlCountryWise.Visible = true;
                
                grdcountry.DataSource = dt;
                grdcountry.DataBind();
             

            }
        }
    }

    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {

       
        //if (mylevel == 0)
        //{
        //    if (ddlreport.SelectedValue == "1")
        //    {
        //        //dsrnew("1");
        //        CreateFirstlvelGraph("1");
        //    }
        //    if (ddlreport.SelectedValue == "2")
        //    {
        //       // dsrnew("2");
        //        CreateFirstlvelGraph("2");

        //    }
        //    if (ddlreport.SelectedValue == "3")
        //    {
        //       // dsrnew("3");
        //        CreateFirstlvelGraph("3");

        //    }
        //}
    }

    protected void grdcountry_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            string countryName = e.SortExpression;
            Clay.RAD.Billingsale objbill = new Clay.RAD.Billingsale();
            DataSet ds_countrysales = objbill.GetSaleDetails(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), countryName);

            //WebChart1.ChartAreas.Clear();
            //WebChart1.Series.Clear();

            //ChartArea area = new ChartArea("AREA");
            //WebChart1.ChartAreas.Add(area);
            //Series series = new Series("SERIES");
            //WebChart1.Series.Add(series);
            //series.IsValueShownAsLabel = true;
            //series.ChartType = SeriesChartType.Pie;
            //series.IsValueShownAsLabel = true;

            //foreach (DataRow dr in ds_countrysales.Tables[0].Rows)
            //{

            //    //series.Points.AddXY(dr["packagetypename"], dr["total"]);

            //}
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("Package", typeof(string));
            dt.Columns.Add("Total", typeof(string));
            dt.Columns.Add("countryid", typeof(string));
            
            if (ds_countrysales.Tables[0].Rows.Count > 0)
            {
                mylevel = 1;
                pnlsalewise.Visible = true;
                pnlCountryWise.Visible = false;
                Session["dschartservice"] = ds_countrysales.Tables[0];
                Bindgraph_WithService();
                #region Varibles
                string _countname = string.Empty;
                string _packname = string.Empty;
                int _total = 0;
                int _countryid = 0;
                #endregion
                foreach (DataRow drserive in ds_countrysales.Tables[0].Rows)
                {
                    DataRow dr_ = dt.NewRow();
                    _countname = drserive["countryname"].ToString();
                    _packname = drserive["packagetypename"].ToString();
                    _total = Convert.ToInt32(drserive["total"]);
                    _countryid = Convert.ToInt32(drserive["countryid"]);
                    dr_["Country"] = _countname;
                    dr_["Package"] = _packname;
                    dr_["Total"] =Convert.ToInt32(_total);
                    dr_["countryid"] = Convert.ToInt32(_countryid);
                    dt.Rows.Add(dr_);
                    dt.AcceptChanges();

                }
                lbllevel.Text = "Secound Level " + countryName;
                grdPackage.DataSource = dt;
                grdPackage.DataBind();
                for (int i = 0; i < grdPackage.Rows.Count; i++)
                {
                    
                    grdPackage.Rows[i].Cells[3].Visible = false;
                    grdPackage.HeaderRow.Cells[3].Visible = false;
                }
            }
            else
            {
                lbllevel.Text = "No Data ";// +countryName;
                pnlCountryWise.Visible = false;
                pnlsalewise.Visible = false;
                grdPackage.DataSource = null;
                grdPackage.DataBind();
            }

        }
        catch (Exception ex)
        {

            ex = null;
        }

      

    }

    protected void grdPackage_DataBound1(object sender, EventArgs e)
    {
        if (mylevel == 1)
        {
            #region Country Span
            for (int rowIndex = grdPackage.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = grdPackage.Rows[rowIndex];
                GridViewRow gvPreviousRow = grdPackage.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
                {
                    if (gvRow.Cells[0].Text == gvPreviousRow.Cells[0].Text)
                    {
                        if (gvPreviousRow.Cells[0].RowSpan < 2)
                        {
                            gvRow.Cells[0].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[0].RowSpan =gvPreviousRow.Cells[0].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[0].Visible = false;
                    }
                }
            }
            
            #endregion

        }
        
    }

    private void BindCalltype(int month,int year,int countryid)
    {
        pnlsalewise.Visible = true;
        pnlCountryWise.Visible = false;
        DataTable dt = new DataTable();
        dt.Columns.Add("CallTypeid", typeof(string)); 
        dt.Columns.Add("CallType", typeof(string));       
        dt.Columns.Add("Total", typeof(System.Int32));
        dt.Columns.Add("Totalall", typeof(System.Int32));
        string oldval = string.Empty;
        string newval = string.Empty;
        string calltypename = string.Empty;
        int _total =0;
        int calltypeid = 0;
        Clay.RAD.Billingsale objcalltype = new Clay.RAD.Billingsale();

        DataSet ds_calltype = objcalltype.GetCallType(month, year, countryid);
        if (ds_calltype.Tables[0].Rows.Count > 0)
        {

            foreach (DataRow drcall in ds_calltype.Tables[0].Rows)
            {
                newval = drcall["lcalltype"].ToString();
                if (newval != oldval)
                {
                    DataRow dr_ = dt.NewRow();
                    calltypename = drcall["calltypename"].ToString();
                    _total = Convert.ToInt32(drcall["total"]);
                    calltypeid = Convert.ToInt32(drcall["lcalltype"]);
                    dr_["CallType"] = calltypename;
                    dr_["Total"] = Convert.ToInt32(_total);                   
                    dr_["CallTypeid"] = Convert.ToInt32(calltypeid);
                    dr_["Totalall"] = Convert.ToInt32(_total);
                    dt.Rows.Add(dr_);
                    dt.AcceptChanges();
                    oldval = drcall["lcalltype"].ToString();
                }
                else
                {

                    oldval = drcall["lcalltype"].ToString();
                }
            }
           
            DataView dv = dt.DefaultView;
            dv.Sort = "Totalall desc";
            DataTable sortedDTcallytype = dv.ToTable();
            sortedDTcallytype.DefaultView.Sort = "Totalall DESC";
            Session["dschartcalltype"] = sortedDTcallytype;
            CreateBarGraph();
           // Bindgraph_WithCallType();
            grdPackage.DataSource = sortedDTcallytype;
            grdPackage.DataBind();
            for (int i = 0; i < grdPackage.Rows.Count; i++)
            {

                grdPackage.Rows[i].Cells[0].Visible = false;
                grdPackage.HeaderRow.Cells[0].Visible = false;
                grdPackage.Rows[i].Cells[3].Visible = false;
                grdPackage.HeaderRow.Cells[3].Visible = false;
            }
        }
        else
        {
            lbllevel.Text = "No Data ";// +Request.QueryString["countryname"].ToString(); ;
            pnlCountryWise.Visible = false;
            pnlsalewise.Visible = false;
            grdPackage.DataSource = null;
            grdPackage.DataBind();
        }
    }
    protected void grdPackage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (mylevel == 1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string countryid = e.Row.Cells[3].Text;
                string firslevel = e.Row.Cells[1].Text;
                string month = ddlMonth.SelectedValue.ToString();
                string year = ddlYear.SelectedValue.ToString();
                string countryname = e.Row.Cells[0].Text;
                countryname=countryname.Replace(" ",string.Empty);
                string hlink2 = "javascript:callreportcalltype('" + countryid + "','" + month + "','" + year + "','" + countryname + "','2')";
                //string hlink2 = "javascript:callreport('" + branchid + "','" + firslevel + "','1')";
                e.Row.Cells[1].Text = "<a href=" + hlink2 + ">" + firslevel + "</a>";
              
                
            }
        }
        if (mylevel == 2)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                grdPackage.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }

    private void CreateBarGraph()
    {
        string strCaption = "Country Wise Call Type";
        string strSubCaption = Request.QueryString["countryname"].ToString(); ;
        string xAxis = "CallType";
        string yAxis = "Total";
      
        //strXML will be used to store the entire XML document generated
        string strXML = null;
        DataTable dtnew = Session["dschartcalltype"] as DataTable; ;
        //Generate the graph element
        strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' 
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

        int i = 0;
        DataView dv = dtnew.DefaultView;
        dv.Sort = "Total desc";
        DataTable sortedDTbill = dv.ToTable();
        GraphWidth = "1000";
        foreach (DataRow dr2 in dtnew.Rows)
        {
            strXML += "<set name='" + dr2[1].ToString() + "' value='" + dr2[2].ToString() + "' color='" + color[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["CallType"].ToString() + ", " + dr2["Total"].ToString() + "'); &quot;/>";
            i++;
        }

        //Finally, close <graph> element
        strXML += "</graph>";

        lpservice.Text = FusionCharts.RenderChartHTML(
            "../FusionCharts/FCF_Column3D.swf", // Path to chart's SWF
            "",                              // Leave blank when using Data String method
            strXML,                          // xmlStr contains the chart data
            "mygraph1",                      // Unique chart ID
            GraphWidth, GraphHeight,                   // Width & Height of chart
            false
            );
    }
    private void CreateFirstlvelGraph(string reptype)
    {
        lbllevel.Text = "First Level " + ddlreport.SelectedItem.Text;
        string strCaption = "Country Billing DashBord";
        string strSubCaption = ddlreport.SelectedItem.Text ;
        DataTable dtnew = Session["dschart"] as DataTable; 
        string strXML = null;
        if (reptype == "1")
        {
            string xAxis = "countryname";
            string yAxis = "totalSale";

            GraphWidthfirlecvel = "2000";
            //Generate the graph element
            strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' 
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

            int i = 0;

            foreach (DataRow dr2 in dtnew.Rows)
            {
                strXML += "<set name='" + dr2[5].ToString() + "' value='" + dr2[4].ToString() + "' color='" + colorfirlevel[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["countryname"].ToString() + ", " + dr2["totalSale"].ToString() + "'); &quot;/>";
                i++;
            }
        }
        else if (reptype == "2")
        {
            string xAxis = "countryname";
            string yAxis = "bill";
            DataView dv = dtnew.DefaultView;
            dv.Sort = "bill desc";
            DataTable sortedDTbill = dv.ToTable();
            GraphWidthfirlecvel = "2000";
            //Generate the graph element
            strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' 
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

            int i = 0;

            foreach (DataRow dr2 in sortedDTbill.Rows)
            {
                strXML += "<set name='" + dr2[5].ToString() + "' value='" + dr2[0].ToString() + "' color='" + colorfirlevel[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["countryname"].ToString() + ", " + dr2["totalBilling"].ToString() + "'); &quot;/>";
                i++;
            }
        }
        else if (reptype == "3")
        {
            string xAxis = "countryname";
            string yAxis = "arpugraph";
            GraphWidthfirlecvel = "2000";
            DataView dv = dtnew.DefaultView;
            dv.Sort = "arpugraph desc";
            DataTable sortedDT = dv.ToTable();
            //Generate the graph element
            strXML = @"<graph caption='" + strCaption + @"' subCaption='" + strSubCaption + @"' decimalPrecision='0' 
                          pieSliceDepth='30' formatNumberScale='0' 
                          xAxisName='" + xAxis + @"' yAxisName='" + yAxis + @"' rotateNames='1'
                    >";

            int i = 0;

            foreach (DataRow dr2 in sortedDT.Rows)
            {
                strXML += "<set name='" + dr2[5].ToString() + "' value='" + dr2[2].ToString() + "' color='" + colorfirlevel[i] + @"'  link=&quot;JavaScript:myJS('" + dr2["countryname"].ToString() + ", " + dr2["arpugraph"].ToString() + "'); &quot;/>";
                i++;
            }
        }
       

        //Finally, close <graph> element
        strXML += "</graph>";

        lt.Text = FusionCharts.RenderChartHTML(
            "../FusionCharts/FCF_Column3D.swf", // Path to chart's SWF
            "",                              // Leave blank when using Data String method
            strXML,                          // xmlStr contains the chart data
            "mygraph1",                      // Unique chart ID
            GraphWidthfirlecvel, GraphHeightfirlecvel,                   // Width & Height of chart
            false
            );
    }
}