using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for google
/// </summary>
public class google
{

    //
    // TODO: Add constructor logic here
    //

    // Fields
    private string data = "";
    private string javascript;

    // Properties
    public string elementId { get; set; }

    public int height { get; set; }

    public string title { get; set; }

    public int width { get; set; }

    // ChartTypes
    public enum ChartType
    {
        BarChart,
        PieChart,
        LineChart,
        ColumnChart,
        AreaChart,
        BubbleChart,
        CandlestickChart,
        ComboChart,
        GeoChart,
        ScatterChart,
        SteppedAreaChart,
        TableChart
    }

    // Methods
    public void GoogleChart()
    {
        this.title = "Google Chart";
        this.width = 730;
        this.height = 300;
        this.elementId = "chart_div";
    }

    public void addColumn(string type, string columnName)
    {
        string data = this.data;
        this.data = data + "data.addColumn('" + type + "', '" + columnName + "');";
    }

    public void addRow(string value)
    {
        this.data = this.data + "data.addRow([" + value + "]);";
    }

    public string generateChart(ChartType chart)
    {
        this.javascript = "<script type=\"text/javascript\" src=\"https://www.google.com/jsapi\"></script>";
        this.javascript = this.javascript + "<script type=\"text/javascript\">";
        this.javascript = this.javascript + "google.load('visualization', '1.0', { 'packages': ['corechart']});";
        this.javascript = this.javascript + "google.setOnLoadCallback(drawChart);";
        this.javascript = this.javascript + "function drawChart() {";
        this.javascript = this.javascript + "var data = new google.visualization.DataTable();";
        this.javascript = this.javascript + this.data;
        this.javascript = this.javascript + "var options = {";
        this.javascript = this.javascript + "'title': '" + this.title + "',";
        object javascript = this.javascript;
        this.javascript = string.Concat(new object[] { javascript, "'width': ", this.width, ", 'height': ", this.height, "};" });
        string str = this.javascript;
        this.javascript = str + "var chart = new google.visualization." + chart.ToString() + "(document.getElementById('" + this.elementId + "'));";
        this.javascript = this.javascript + "chart.draw(data, options);";
        this.javascript = this.javascript + "} </script>";
        return this.javascript;
    }



}