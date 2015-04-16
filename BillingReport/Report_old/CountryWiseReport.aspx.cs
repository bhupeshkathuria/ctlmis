using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
public partial class Report_MainReport : System.Web.UI.Page  // Country Wise Report change name
{
    ClayBillingLibrary.Report.DashBoard objDashBoard = new ClayBillingLibrary.Report.DashBoard();
    DataSet dsDetails = new DataSet();
    DataTable dtCountryDetails = new DataTable();
    DataTable dtCountryName = new DataTable();
    double totalAllCountryAmount = 0;
    DataSet dsCountryDetailsMonthWise=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
           
        }
        //ChartMonth.Series["SeriesMonth"]["Funnel3DRotationAngle"] = "7";
        //ChartMonth.Series["SeriesMonth"]["Funnel3DDrawingStyle"] = "CircularBase";
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {

        this.MasterPageFile = "~/CopyofSite.master";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            panelChart2.Visible = false;
            string _fYear = drpFyear.SelectedItem.Text.Trim();
            ViewState["Fyear"] = drpFyear.SelectedItem.Text.Trim();
            string fromYear, toYear;
            string[] yearArray = _fYear.Split('-');

            DataTable dtAllCountryDetails = new DataTable();
            dtAllCountryDetails.Columns.Add("countryid", typeof(Int32));
            dtAllCountryDetails.Columns.Add("countryname", typeof(string));
            dtAllCountryDetails.Columns.Add("amount", typeof(double));
            dtAllCountryDetails.Columns.Add("amountper", typeof(double));

            if (yearArray.Length > 1)
            {
                fromYear = yearArray[0].ToString();
                toYear = yearArray[1].ToString();

                objDashBoard.Fromdate = fromYear + "-" + "04" + "-" + "01";
                objDashBoard.Todate = toYear + "-" + "03" + "-" + "31";

                ViewState["FromDate"] = fromYear + "-" + "04" + "-" + "01";
                ViewState["ToDate"] = toYear + "-" + "03" + "-" + "31";

                dsDetails = objDashBoard.GetBillingDetailsBasedOnFinancialYear();
                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    dtAllCountryDetails = dsDetails.Tables[0];
                    //DataView dvAllCountryAmount = new DataView(dtAllCountryDetails);
                    //dvAllCountryAmount.Sort = "amount ASC";
                    ViewState["CountryDetails"] = dtAllCountryDetails;
                    DrawGraph();
                    PanelCharT1.Visible = true;

                }
                else
                {
                    lblMsg.Text = "No records to display!";
                    return;
                }

                //if (dsDetails.Tables[0].Rows.Count > 0)
                //{
                //    dtCountryDetails = dsDetails.Tables[0];
                //    dtCountryName = dsDetails.Tables[1];

                //   foreach (DataRow dr in dtCountryName.Rows)
                //   {
                //       int countryId = Convert.ToInt32(dr["countryid"]);
                //       string countryName = dr["countryname"].ToString();

                //       DataRow[] dtRowDetails = dtCountryDetails.Select("countryId=" + countryId);
                //       double totalCountryAmount = 0;
                //       for (int i = 0; i < dtRowDetails.Length; i++)
                //       {
                //           totalCountryAmount = totalCountryAmount + Convert.ToDouble(dtRowDetails[i]["amountinr"]);
                //           totalAllCountryAmount = totalAllCountryAmount + Convert.ToDouble(dtRowDetails[i]["amountinr"]);
                //       }
                //       DataRow newCountryRow = dtAllCountryDetails.NewRow();
                //       newCountryRow["CountryName"] = countryName;
                //       newCountryRow["CountryAmount"] = totalCountryAmount;
                //       dtAllCountryDetails.Rows.Add(newCountryRow);
                //       dtAllCountryDetails.DefaultView.Sort = "CountryAmount ASC"; 
                //       dtAllCountryDetails.AcceptChanges();
                //   }
                //   //DataView dvAllCountryAmount = new DataView(dtAllCountryDetails);
                //   //dvAllCountryAmount.Sort = "CountryAmount ASC";
                //   ViewState["CountryDetails"] = dtAllCountryDetails;
                //   DrawGraph();
                //}
            }
            else
            {
                lblMsg.Text = "Please Select financial year !";
                return;
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
        
    }
    protected void drpTopValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }

    protected void DrawGraph()
    {
        try
        {
            if (drpFyear.SelectedValue == "0")
            {
                lblMsg.Text = "Please select financial year !";
                return;
            }
            else
            {
                lblMsg.Text = "";
                int TopValue = Convert.ToInt32(drpTopValue.SelectedValue);

                System.Web.UI.DataVisualization.Charting.Title title = new System.Web.UI.DataVisualization.Charting.Title();
                title.Font = new System.Drawing.Font("Trebuchet MS", (float)(10.25), System.Drawing.FontStyle.Bold);
                title.ShadowOffset = 0;
                title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                title.Alignment = System.Drawing.ContentAlignment.TopCenter;

                DataTable dtGetCountryDetails = new DataTable();
                dtGetCountryDetails = (DataTable)ViewState["CountryDetails"];

                DataView dvAllCountryAmount = new DataView(dtGetCountryDetails);
                dvAllCountryAmount.Sort = "amount ASC";

                DataTable dtCreateCountry = new DataTable();
                dtCreateCountry.Columns.Add("countryname");
                dtCreateCountry.Columns.Add("amount");
                dtCreateCountry.Columns.Add("amountper");

               

                if(dvAllCountryAmount.Count >0)
                {
                    int totalCountryRows = dvAllCountryAmount.Count;

                    if (totalCountryRows > 5)
                    {
                        int totalCountry = dvAllCountryAmount.Count;
                        TopValue = TopValue == 0 ? totalCountry : TopValue;
                        for (int j = (totalCountry - TopValue); j < totalCountry; j++)
                        {
                            if (j < 0)
                            {
                                j = 0;
                            }
                            dtCreateCountry.ImportRow(dvAllCountryAmount[j].Row);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < dvAllCountryAmount.Count; j++)
                        {
                            dtCreateCountry.ImportRow(dvAllCountryAmount[j].Row);
                        }
                    }
                    
                    DataView dvCountry = new DataView(dtCreateCountry);
                    Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
                    //if (TopValue == 5)
                    //{
                    //    Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                    //    Chart1.Series["Series1"]["PointWidth"] = "0.6";
                    //    Unit height = new Unit(200);
                    //    Chart1.Height = height;
                    //    title.Text = "Country Wise Contribution";
                    //    title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                    //    Chart1.Titles[0] = title;
                    //}
                    if (TopValue == 10)
                    {
                        if (totalCountryRows > 5)
                        {
                            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                            Chart1.Series["Series1"]["PointWidth"] = "0.6";
                            Unit height = new Unit(400);
                            Chart1.Height = height;
                            title.Text = "Country (Year Wise) Contribution";
                            title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                            Chart1.Titles[0] = title;
                            drpTopValue.Visible = true;
                        }
                        else
                        {
                            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                            Chart1.Series["Series1"]["PointWidth"] = "0.6";
                            Unit height = new Unit(200);
                            Chart1.Height = height;
                            title.Text = "Country (Year Wise) Contribution";
                            Chart1.Titles[0] = title;
                            drpTopValue.Visible = false;
                        }
                        
                    }
                    else if (TopValue == 15)
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Chart1.Series["Series1"]["PointWidth"] = "0.6";
                        Unit height = new Unit(600);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    else if (TopValue == 20)
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Chart1.Series["Series1"]["PointWidth"] = "0.6";
                        Unit height = new Unit(800);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    else
                    {
                        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = .5;
                        Chart1.Series["Series1"]["PointWidth"] = "0.4";
                        Unit height = new Unit(1200);
                        Chart1.Height = height;
                        title.Text = "Country (Year Wise) Contribution";
                        Chart1.Titles[0] = title;
                    }
                    if (rbtrupees.Checked == true)
                    {
                        Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amount");
                       Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                        //Chart1.Series["Series1"].PostBackValue = "##VALX";
                    }
                    if (rbtPercentage.Checked == true)
                    {
                        Chart1.Series["Series1"].Points.DataBindXY(dvCountry, "countryname", dvCountry, "amountper");
                        Chart1.Series["Series1"].PostBackValue = "#AXISLABEL";
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        string getCountryName =e.PostBackValue;
        ViewState["CountryName"] = getCountryName;
        DisplayMonthWiseCountryBillingReport(getCountryName);
        DrawGraph();
        panelChart2.Visible = true;
        lblMsg.Text = "";

    }
    protected void rbtrupees_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }
    protected void rbtPercentage_CheckedChanged(object sender, EventArgs e)
    {
        DrawGraph();
    }

    protected void DisplayMonthWiseCountryBillingReport(string countryName)
    {
        try
        {
            DataTable dtCountryDetailsMonthWise = new DataTable();
            dtCountryDetailsMonthWise.Columns.Add("getmonth", typeof(int));
            dtCountryDetailsMonthWise.Columns.Add("getmonthname", typeof(string));
            dtCountryDetailsMonthWise.Columns.Add("countryname", typeof(string));
            dtCountryDetailsMonthWise.Columns.Add("amount", typeof(double));
            dtCountryDetailsMonthWise.Columns.Add("amountper", typeof(double));
            dtCountryDetailsMonthWise.Columns.Add("monthserialno", typeof(Int16));

            objDashBoard.Fromdate= ViewState["FromDate"].ToString();
            objDashBoard.Todate= ViewState["ToDate"].ToString();
            objDashBoard.CountryName = countryName.Trim();
            dsCountryDetailsMonthWise=objDashBoard.GetYearBillingDetailsBasedOnCountry();
            if(dsCountryDetailsMonthWise.Tables[0].Rows.Count>0)
            {
                PanelCountryName.Visible = true;
                lblCountryName.Text = countryName.Trim() + " " + ViewState["Fyear"].ToString(); 
                string[] MonthArrayVal = new string[] { "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                string[,] MonthArray = new string[,] { { "January", "10" }, { "February", "11" }, { "March", "12" }, { "April", "1" }, { "May", "2" }, { "June", "3" }, { "July", "4" }, { "August", "5" }, { "September", "6" }, { "October", "7" }, { "November", "8" }, { "December", "9" } };
                for(int i=1;i <=12; i++)
                {
                    DataRow[] dtRowDetails = dsCountryDetailsMonthWise.Tables[0].Select("getmonth=" + i);

                    if(dtRowDetails.Length==1)
                    {
                        dtCountryDetailsMonthWise.Columns["monthserialno"].DefaultValue = MonthArray[(i - 1), 1];
                        dtCountryDetailsMonthWise.ImportRow(dtRowDetails[0]);                     
                        
                        dtCountryDetailsMonthWise.AcceptChanges();
                    }
                    else
                    {
                        //string[] MonthArray = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                        
                       

                        DataTable createtablenew = new DataTable();
	                    createtablenew.Columns.Add("getmonth", typeof(int));
                        createtablenew.Columns.Add("getmonthname", typeof(string));
	                    createtablenew.Columns.Add("countryname", typeof(string));
	                    createtablenew.Columns.Add("amount", typeof(double));
	                    createtablenew.Columns.Add("amountper", typeof(double));
                        createtablenew.Columns.Add("monthserialno", typeof(Int16));
                        createtablenew.Rows.Add(i, MonthArray[(i - 1),0], countryName, 0, 0, MonthArray[(i - 1), 1]);
                        DataRow[] dtnewRow = createtablenew.Select("getmonth=" + i);
                        dtCountryDetailsMonthWise.ImportRow(dtnewRow[0]); 
                    }

                }
                 
                

               // dtCountryDetailsMonthWise = dsCountryDetailsMonthWise.Tables[0];
                DataView dvdetails = new DataView(dtCountryDetailsMonthWise);
                dvdetails.Sort="monthserialno ASC";

                if (rbtRupeesmonth.Checked == true)
                {
                    ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amount");
                }

                if (rbtnpersentagemonth.Checked == true)
                {
                    ChartMonth.Series["SeriesMonth"].Points.DataBindXY(dvdetails, "getmonthname", dvdetails, "amountper");
                }
                
                ChartMonth.Series["SeriesMonth"]["PyramidOutsideLabelPlacement"] = "Left";
                ChartMonth.Series["SeriesMonth"]["PyramidPointGap"] = "3";
                ChartMonth.Series["SeriesMonth"]["PyramidMinPointHeight"] = "2";
                ChartMonth.ChartAreas["ChartAreaMonth"].Area3DStyle.Enable3D = true;
                ChartMonth.Series["SeriesMonth"]["Pyramid3DRotationAngle"] = "5";
                ChartMonth.Series["SeriesMonth"]["Pyramid3DDrawingStyle"] = "CircularBase";
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
            return;
        }
        
    }
    protected void rbtnpersentagemonth_CheckedChanged(object sender, EventArgs e)
    {
        DisplayMonthWiseCountryBillingReport(ViewState["CountryName"].ToString());
    }
    protected void rbtRupeesmonth_CheckedChanged(object sender, EventArgs e)
    {
        DisplayMonthWiseCountryBillingReport(ViewState["CountryName"].ToString());
    }
}