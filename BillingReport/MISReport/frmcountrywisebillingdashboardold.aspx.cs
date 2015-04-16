using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MISReport_frmcountrywisebillingdashboard : System.Web.UI.Page
{
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
        if (!IsPostBack)
        {
            loadYear();
            mylevel = 0;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       // GenerateQuickStats();
        BindGrid();
      // BindChart();
      // chart_bind();
        ddlreport_SelectedIndexChanged(sender, e);
        
    }
    private void GenerateQuickStats()
    {
        google chart = new google();
        chart.title = "Quick Stats";
        chart.width = 250;
        chart.height = 200;
        chart.addColumn("string", "Year");
        chart.addColumn("number", "Value");
        chart.addColumn("number", "Profit");
        chart.addRow("'2014', 2000, 1000");
        // asp literal
        lt.Text = chart.generateChart(google.ChartType.BarChart);
    }
    private void BindChart( )
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
        {   }
    }

    private void dsrnew( string reptype)
    {
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
                    str.Append("['" + (dtnew.Rows[i]["totalSale"].ToString()) + " [" + dtnew.Rows[i]["countryname"].ToString() + "]" + "'," + dtnew.Rows[i]["totalSale"].ToString() + "],");
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
                    dt.Columns.Add(drrow["countryname"].ToString(), typeof(string));
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
                              if(column.ColumnName.ToString() ==dr_arr[0]["countryname"].ToString())
                              {
                                 //column = dr_arr[0]["countryname"].ToString();
                                  dr[column] = dr_arr[0]["totalSale"].ToString();
                                  break;
                              }
                               
                            }                     
                        
                    }
                    dr_arr=null;

                    
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
                                dr1[column] = dr_arr[0]["totalBilling"].ToString();
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
                //dt.Columns["insertdatetime"].ColumnMapping = MappingType.Hidden;
                grdcountry.DataSource = dt;
                grdcountry.DataBind();
             

            }
        }
    }


    protected void ddlreport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (mylevel == 0)
        {
            if (ddlreport.SelectedValue == "1")
            {
                dsrnew("1");

            }
            if (ddlreport.SelectedValue == "2")
            {
                dsrnew("2");

            }
            if (ddlreport.SelectedValue == "3")
            {
                dsrnew("3");

            }
        }
    }
    protected void grdcountry_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
           
            string countryName = e.SortExpression;
            Clay.RAD.Billingsale objbill = new Clay.RAD.Billingsale();
            DataSet ds_countrysales = objbill.GetSaleDetails(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), countryName);


        }
        catch (Exception ex)
        {

            ex = null;
        }
    }
    
    protected void grdcountry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    
}