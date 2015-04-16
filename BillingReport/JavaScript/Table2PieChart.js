function table2PieChart(clientID){

    /* variables */
    var chartClass = 'fromtable';
    var hideClass = 'hideChartTable';
    var chartColor = '0000ff';
    var chartSize = '450x150';
    var chartType = 'p';
    var chartBGFill = 'ffffff';
    /* end variables */
    
    /* Get references to all of the controls holding our values */
    var lblChartSize = Sys.UI.DomElement.getElementById(clientID + "_lblChartSize");
    var lblChartColor = Sys.UI.DomElement.getElementById(clientID + "_lblChartColor");
    var lblChartBGFill = Sys.UI.DomElement.getElementById(clientID + "_lblChartBGFill");
    var lblChartShowData = Sys.UI.DomElement.getElementById(clientID + "_lblChartShowData");
    var lblChart3D = Sys.UI.DomElement.getElementById(clientID + "_lblChart3D");
    var lblChartGridViewID = Sys.UI.DomElement.getElementById(clientID + "_lblChartGridViewID");
  
    /* Get variable values from the document elements */
    if(lblChartSize.innerHTML != '')
        chartSize = lblChartSize.innerHTML;
    if(lblChartColor.innerHTML != '')
        chartColor = lblChartColor.innerHTML;
    if(lblChartBGFill.innerHTML != '')
        chartBGFill = lblChartBGFill.innerHTML;

    /* Determine whether or not to show the chart data */
    var showChartData = lblChartShowData.innerHTML;
    if(showChartData == "True")
        hideClass = '';

    /* Determine whether or not to use a 3D pie chart */
    var use3DPieChart = lblChart3D.innerHTML;
    if(use3DPieChart == "True")
        chartType = 'p3';

    /* Get the GridView ID to create the Google Chart for */
    var t = Sys.UI.DomElement.getElementById(lblChartGridViewID.innerHTML);
    if(t == null)
        t = this.findControl("table", lblChartGridViewID.innerHTML);
    
    if(t == null)
        return;
        
    var c = t.className;
    var data = [];
    var labels = [];

    t.className += ' '+ hideClass;
    var tds = t.getElementsByTagName('tbody')[0].getElementsByTagName('td');
    for(var j=0;tds[j];j+=2){
        labels.push(tds[j].innerHTML);
        data.push(tds[j+1].innerHTML);
    };

    /* Determine the Y axis max range value */
    var maxYValue = 0;
    for(var z=0;data[z];z++)
    {
        var value = +data[z];
        if( value > maxYValue)
            maxYValue = data[z];
    };

    var charturl = 'http://chart.apis.google.com/chart?cht=' + chartType + '*chco=' + chartColor + '*chs=' + chartSize + '*chf=' + chartBGFill + '*chd=';

    var chart = document.createElement('img');
    chart.setAttribute('src','GoogleChartsHandler.ashx?GoogleChartsURL=' + charturl+simpleEncode(data, maxYValue) + '*chl=' + labels.join('|'));
    chart.setAttribute('alt',t.getAttribute('summary'));
    chart.className = chartClass;
    t.parentNode.insertBefore(chart,t);
}

/* Google Charts API function for encoding data */
function simpleEncode(values,maxValue) {
  var simpleEncoding = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  var chartData = ['s:'];
  for (var i = 0; i < values.length; i++) {
    var currentValue = values[i];
    if (!isNaN(currentValue) && currentValue >= 0) {
        chartData.push(simpleEncoding.charAt(Math.round((simpleEncoding.length-1) * currentValue / maxValue)));
    }
    else {
        chartData.push('_');
    }
  }
return chartData.join('');
}

/* Finds a control given the tagName and ControlID. This function is necessary for instances
where the clientID for a given control may have changed due to be embedded in another object
such as a MasterPage ContentPlaceHolder*/
function findControl(tagName, controlId)
{
    var aControls = document.getElementsByTagName(tagName);
    if (aControls==null)
        return null;
    for (var i=0; i< aControls.length; i++)
    {
        var j = aControls[i].id.lastIndexOf(controlId);
        if ((j -1) && (j == (aControls[i].id.length - controlId.length)))
        return aControls[i];
    }
    return null;
}

