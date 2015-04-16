function table2BarChart(clientID){

    /* variables */
    var chartClass = 'fromtable';
    var hideClass = 'hideChartTable';
    var chartColor = '0000ff';
    var chartSize = '300x150';
    var chartType = 'bhg';
    var chartBarSizeSpacing = '10,5,15';
    var chartBGFill = 'ffffff';
    /* end variables */
    
    /* Get references to all of the controls holding our values */
    var lblChartSize = Sys.UI.DomElement.getElementById(clientID + "_lblChartSize");
    var lblChartColor = Sys.UI.DomElement.getElementById(clientID + "_lblChartColor");
    var lblChartBarSizeSpacing = Sys.UI.DomElement.getElementById(clientID + "_lblChartBarSizeSpacing");
    var lblChartBGFill = Sys.UI.DomElement.getElementById(clientID + "_lblChartBGFill");
    var lblChartShowData = Sys.UI.DomElement.getElementById(clientID + "_lblChartShowData");
    var lblChartOrientationVertical = Sys.UI.DomElement.getElementById(clientID + "_lblChartOrientationVertical");
    var lblChartGridViewID = Sys.UI.DomElement.getElementById(clientID + "_lblChartGridViewID");

    /* Get variable values from the document elements if they have been set */
    if(lblChartSize.innerHTML != '')
        chartSize = lblChartSize.innerHTML;
    if(lblChartColor.innerHTML != '')
        chartColor = lblChartColor.innerHTML;
    if(lblChartBarSizeSpacing.innerHTML != '')
        chartBarSizeSpacing = lblChartBarSizeSpacing.innerHTML;
    if(lblChartBGFill.innerHTML != '')
        chartBGFill = lblChartBGFill.innerHTML;

    /* Determine whether or not to show the chart data */
    var showChartData = lblChartShowData.innerHTML;
    if(showChartData == "True")
        hideClass = '';

    /* Determine if this bar chart should be displayed vertically */
    var chartOrientationVertical = lblChartOrientationVertical.innerHTML;
    if(chartOrientationVertical == "True")
        chartType = 'bvg';

    /* Get the GridView ID to create the Google Chart for */
    var t = Sys.UI.DomElement.getElementById(lblChartGridViewID.innerHTML);
    if(t == null)
        t = this.findControl("table", lblChartGridViewID.innerHTML);
    
    // If we didn't find the table, just bail
    if(t == null)
        return;
        
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
    var midYValue = maxYValue / 2;

    /* Adjust the x & y labels depending on whether or not this is a vertical or horizontal chart */
    var chartLabels = '';
    if(chartType == 'bvg')
        chartLabels = '0:|' + labels.join('|') + '|1:|0|' + midYValue + '|' + (+maxYValue +10);

    if(chartType == 'bhg')
    {
        var verticalLabels = [];
        var verticalLabelIndex = 0;
        /* We need to reverse the label order for vertical labels to match the data */
        for(var y = (labels.length - 1); y > -1; y--)
        {
           verticalLabels[verticalLabelIndex] = labels[y];
           verticalLabelIndex++;
        }
        
        chartLabels = '0:|0|' + midYValue + '|' + (+maxYValue +10) + '|1:|' + verticalLabels.join('|');
    }

    var charturl = 'http://chart.apis.google.com/chart?cht=' + chartType + '*chco=' + chartColor + '*chs=' + chartSize + '*chbh=' + chartBarSizeSpacing + '*chf=' + chartBGFill + '*chxt=x,y' + '*chxl=' + chartLabels + '*chd=';

    var chart = document.createElement('img');
    chart.setAttribute('src','GoogleChartsHandler.ashx?GoogleChartsURL=' + charturl+simpleEncode(data, +maxYValue + 10)); 
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

