using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using Clay.Sale.Bll;
using System.Web.UI.HtmlControls;

public partial class Sales_frmARPU : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    DataSet ds = new DataSet();
    DataSet dsBilling = new DataSet();
    DataSet dsEmployee = new DataSet();
    DataSet dsBranch = new DataSet();
    DataSet dsCountry = new DataSet();

    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    #endregion

    #region User Defined Methods

    private void LoadReport(string Year, string Month, int BranchId, int CountryId, int EmployeeId)
    {        
        DataTable dt = new DataTable();
        StringBuilder strOrderId = new StringBuilder();
        string _orderid = string.Empty;
        
        dt.Columns.Add("totalsale1");
        //dt.Columns.Add("totalbilling1");

        ds = objSalesSummaryReport.GetARPU(Year, Month, EmployeeId, CountryId, BranchId);




        DataRow dr = dt.NewRow();
        foreach (DataRow item in ds.Tables[0].Rows)
        {
            dr["totalsale1"] = item["totalsale"];
        }
        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    foreach (DataRow item in ds.Tables[1].Rows)
        //    {
        //        //dr["totalbilling1"] = item["totalbilling"];

        //        strOrderId.Append(",").Append(item["orderid"].ToString());
        //    }
        //        strOrderId.Remove(0, 1);
        //        _orderid = strOrderId.ToString();
           
        //}
        //else
        //{
        //    _orderid = "0";
        //}
        dt.Rows.Add(dr);
        dt.AcceptChanges();

        dsBilling = objSalesSummaryReport.GetTotalBilling(Year, Month, EmployeeId, CountryId, BranchId);

        grdview1.DataSource = dt;
        grdview1.DataBind();
    }

    //private void LoadEmployee()
    //{
    //    DataRow dr;
        
    //    dsEmployee = objSalesSummaryReport.GetEmployee();
    //    dr = dsEmployee.Tables[0].NewRow();
    //    dr["employeename"] = "Select Employee";
    //    dr["employeeid"] = "0";
    //    dsEmployee.Tables[0].Rows.InsertAt(dr, 0);

    //    ddlEmployee.DataSource = dsEmployee.Tables[0];
    //    ddlEmployee.DataValueField = "employeeid";
    //    ddlEmployee.DataTextField = "employeename";
    //    ddlEmployee.DataBind();
    //}

    ////private void LoadCountry()
    ////{
    ////    DataRow dr;
        
    ////    dsCountry = objSalesSummaryReport.GetCountry();
    ////    dr = dsCountry.Tables[0].NewRow();
    ////    dr["countryname"] = "Select Country";
    ////    dr["countryid"] = "0";
    ////    dsCountry.Tables[0].Rows.InsertAt(dr, 0);

    ////    ddlCountry.DataSource = dsCountry.Tables[0];
    ////    ddlCountry.DataValueField = "countryid";
    ////    ddlCountry.DataTextField = "countryname";
    ////    ddlCountry.DataBind();
    ////}

    //private void LoadBranch()
    //{
    //    DataRow dr;        

    //    dsBranch = objSalesSummaryReport.GetBranch();
    //    dr = dsBranch.Tables[0].NewRow();
    //    dr["branchname"] = "Select Branch";
    //    dr["branchid"] = "0";
    //    dsBranch.Tables[0].Rows.InsertAt(dr, 0);

    //    ddlBranch.DataSource = dsBranch.Tables[0];
    //    ddlBranch.DataValueField = "branchid";
    //    ddlBranch.DataTextField = "branchname";
    //    ddlBranch.DataBind();
    //}

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SortedList<string, string> sortedYear = new SortedList<string, string>();
            sortedYear.Add("--", "Select");
            sortedYear.Add("2009", "2009");
            sortedYear.Add("2010", "2010");
            sortedYear.Add("2011", "2011");
            sortedYear.Add("2012", "2012");
            sortedYear.Add("2013", "2013");
            sortedYear.Add("2014", "2014");
            sortedYear.Add("2015", "2015");
            sortedYear.Add("2016", "2016");
            sortedYear.Add("2017", "2017");
            sortedYear.Add("2018", "2018");
            sortedYear.Add("2019", "2019");
            sortedYear.Add("2020", "2020");
            
            ddlYear.DataSource = sortedYear;
            ddlYear.DataValueField = "Key";
            ddlYear.DataTextField = "value";
            ddlYear.DataBind();

            ddlCompYear.DataSource = sortedYear;
            ddlCompYear.DataValueField = "Key";
            ddlCompYear.DataTextField = "value";
            ddlCompYear.DataBind();

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
            sortedMonth.Add("--", "Select");
            sortedMonth.Add("01", "January");
            sortedMonth.Add("02", "Febraury");
            sortedMonth.Add("03", "March");
            sortedMonth.Add("04", "April");
            sortedMonth.Add("05", "May");
            sortedMonth.Add("06", "June");
            sortedMonth.Add("07", "July");
            sortedMonth.Add("08", "August");
            sortedMonth.Add("09", "September");
            sortedMonth.Add("10", "October");
            sortedMonth.Add("11", "November");
            sortedMonth.Add("12", "December");
            
            ddlMonth.DataSource = sortedMonth;
            ddlMonth.DataValueField = "Key";
            ddlMonth.DataTextField = "value";
            ddlMonth.DataBind();

            ddlCompMonth.DataSource = sortedMonth;
            ddlCompMonth.DataValueField = "Key";
            ddlCompMonth.DataTextField = "value";
            ddlCompMonth.DataBind();
            //this.LoadBranch();
            //this.LoadCountry();
            //this.LoadEmployee();
        }


    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    if (ddlMonth.SelectedIndex > 0)
    //    {
    //        lblMonth.Text = "ARPU Report of " + ddlMonth.SelectedItem.Text.ToString() + "-" + ddlYear.SelectedItem.Text.ToString() + "";
    //    }
    //    else
    //    {
    //        lblMonth.Text = "ARPU Report of " + ddlYear.SelectedItem.Text.ToString() + "";
    //    }


    //    this.LoadReport(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Convert.ToInt32(ddlBranch.SelectedValue), Convert.ToInt32(ddlCountry.SelectedValue), Convert.ToInt32(ddlEmployee.SelectedValue));
    //}

    protected void grdview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (chkCompare.Checked)
        {
            if ( ddlRepType.SelectedValue.ToString()=="0")
            {
                if (e.Row.Cells[6].Text=="UP")
                {
                    e.Row.Cells[6].Controls.Clear();
                    ImageButton img=new ImageButton();
                    img.ImageUrl="~/Images/up.png";
                    e.Row.Cells[6].Controls.Add(img);
                }
                if (e.Row.Cells[6].Text=="Down")
                {
                    e.Row.Cells[6].Controls.Clear();
                    ImageButton img=new ImageButton();
                    img.ImageUrl="~/Images/down.png";
                    e.Row.Cells[6].Controls.Add(img);
                }
            }
            if ( ddlRepType.SelectedValue.ToString()=="1")
            {
                if (e.Row.Cells[7].Text == "UP")
                {
                    e.Row.Cells[7].Controls.Clear();
                    ImageButton img = new ImageButton();
                    img.ImageUrl = "~/Images/up.png";
                    e.Row.Cells[7].Controls.Add(img);
                }
                if (e.Row.Cells[7].Text == "Down")
                {
                    e.Row.Cells[7].Controls.Clear();
                    ImageButton img = new ImageButton();
                    img.ImageUrl = "~/Images/down.png";
                    e.Row.Cells[7].Controls.Add(img);
                }
            }
            if ( ddlRepType.SelectedValue.ToString()=="2")
            {
                if (e.Row.Cells[7].Text == "UP")
                {
                    e.Row.Cells[7].Controls.Clear();
                    ImageButton img = new ImageButton();
                    img.ImageUrl = "~/Images/up.png";
                    e.Row.Cells[7].Controls.Add(img);
                }
                if (e.Row.Cells[7].Text == "Down")
                {
                    e.Row.Cells[7].Controls.Clear();
                    ImageButton img = new ImageButton();
                    img.ImageUrl = "~/Images/down.png";
                    e.Row.Cells[7].Controls.Add(img);
                }
            }
        }

        //int average = 0;
        //Double _totalbilling = 0.000;
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
           

        //    Label lblsale = (Label)e.Row.Cells[0].FindControl("lblsale");
        //    //Label lblbilling = (Label)e.Row.Cells[0].FindControl("lblbilling");
        //    Label lblTotalBilling = (Label)e.Row.Cells[0].FindControl("lblTotalBilling");

        //    if (dsBilling.Tables[0].Rows.Count > 0)
        //    {

        //        lblTotalBilling.Text = string.Format("{0:n3}", dsBilling.Tables[0].Rows[0]["totalbilling"].ToString());
        //    }
        //    else
        //    {
        //        lblTotalBilling.Text = "0";
        //    }

        //    if (lblTotalBilling.Text.ToString() != "")
        //    {

        //        _totalbilling = Convert.ToDouble(lblTotalBilling.Text);
        //    }
        //    else
        //    {
        //        _totalbilling = 0.00;
        //    }


        //    if (Convert.ToDouble(lblsale.Text) != 0)
        //    {
        //        average = Convert.ToInt32((_totalbilling / Convert.ToDouble(lblsale.Text)));
        //        Label lblARPU = (Label)e.Row.Cells[0].FindControl("lblARPU");
        //        lblARPU.Text = Convert.ToString(average);
        //    }
        //    else
        //    {
        //        Label lblARPU = (Label)e.Row.Cells[0].FindControl("lblARPU");
        //        lblARPU.Text = "0";
        //    }

        
    }
    protected void cmdFind_Click(object sender, EventArgs e)
    {
        string reptype = string.Empty;
        SortExpression = string.Empty;
        reptype = ddlRepType.SelectedValue.ToString();
        DisplayReport(reptype);
    }
    private void DisplayReport(string reptype)
    {
        try
        {
            string year=ddlYear.SelectedValue.ToString();
            string month=ddlMonth.SelectedValue.ToString();
            string compmonth = string.Empty;
            string compyear = string.Empty;
            double _billing=0;
            double _sale=0;
            double _arpu=0;
            double _compsale = 0;
            double _compbilling = 0;
            double _compARPU = 0;
            DataTable dt = new DataTable();
            if (chkCompare.Checked)
            {
                if (Convert.ToString(ddlCompMonth.SelectedValue)!="")
                {
                    compmonth = Convert.ToString(ddlCompMonth.SelectedValue);
                }
                if (Convert.ToString(ddlCompYear.SelectedValue) != "")
                {
                    compyear = Convert.ToString(ddlCompYear.SelectedValue);
                }
            }

            if (reptype == "0")
            {
                DataColumn dcol0 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol0.AutoIncrement = true;
                dt.Columns.Add(dcol0);

                DataColumn dcol1 = new DataColumn("Total Billing", typeof(System.Int32));
                dcol1.AutoIncrement = true;
                dt.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("ARPU", typeof(System.Int32));
                dcol2.AutoIncrement = true;
                dt.Columns.Add(dcol2);

                if ((compmonth != "") && (compyear != ""))
                {
                    DataColumn dcol3 = new DataColumn("Base Sale", typeof(System.Int32));
                    dcol3.AutoIncrement = true;
                    dt.Columns.Add(dcol3);

                    DataColumn dcol4 = new DataColumn("Base Billing", typeof(System.Int32));
                    dcol4.AutoIncrement = true;
                    dt.Columns.Add(dcol4);

                    DataColumn dcol5 = new DataColumn("Base ARPU", typeof(System.Int32));
                    dcol5.AutoIncrement = true;
                    dt.Columns.Add(dcol5);                    

                    DataColumn dcol6 = new DataColumn();
                    dcol6.DataType = Type.GetType("System.String");
                    dcol6.ColumnName = "Result";
                    dt.Columns.Add(dcol6);
                }
                if ((compmonth == "") && (compyear == ""))
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype),"","");
                }
                else
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype),compmonth,compyear);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow myrow = dt.NewRow();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToString(dr["xtype"]) == "1")
                        {
                            _sale = Convert.ToInt32(dr["totalcount"]);
                        }
                        if (Convert.ToString(dr["xtype"]) == "2")
                        {
                            _billing = Convert.ToInt32(dr["totalcount"]);
                        }                        
                        if (Convert.ToString(dr["xtype"]) == "3")
                        {
                            _compsale = Convert.ToInt32(dr["totalcount"]);
                        }
                        if (Convert.ToString(dr["xtype"]) == "4")
                        {
                            _compbilling = Convert.ToInt32(dr["totalcount"]);
                        }
                    }
                    
                    _arpu = Math.Round(_billing / _sale, 0);
                    _compARPU = Math.Round(_compbilling / _compsale, 0);
                    string _result = "UP";
                    if (_arpu < _compARPU)
                    {
                        _result = "Down";
                    }                    
                    myrow[0] = _sale;
                    myrow[1] = _billing;
                    myrow[2] = _arpu;
                    if ((compmonth != "") && (compyear != ""))
                    {
                        myrow[3] = _compsale;
                        myrow[4] = _compbilling;
                        myrow[5] = _compARPU;
                        myrow[6] = _result;
                    }
                    dt.Rows.Add(myrow);
                    dt.AcceptChanges();
                    DataView dv = dt.DefaultView;
                    dv.Sort = SortExpression;
                    grdview1.DataSource = dv;
                    grdview1.DataBind();                    
                }
                
            }
            if (reptype == "1")
            {
                DataTable dt1 = new DataTable();
                //DataColumn dctcol = new DataColumn("CountryName", typeof(System.String));
                //dctcol.AutoIncrement = true;
                //dt1.Columns.Add(dctcol);

                DataColumn dctcol = new DataColumn();
                dctcol.DataType = Type.GetType("System.String");
                dctcol.ColumnName = "Country";
                dt1.Columns.Add(dctcol);

                DataColumn dcol1 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol1.AutoIncrement = true;
                dt1.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("Total Billing", typeof(System.Int32));
                dcol2.AutoIncrement = true;
                dt1.Columns.Add(dcol2);

                DataColumn dcol3 = new DataColumn("ARPU", typeof(System.Int32));
                dcol3.AutoIncrement = true;
                dt1.Columns.Add(dcol3);

                if ((compmonth != "") && (compyear != ""))
                {
                    DataColumn dcol4 = new DataColumn("Base Sale", typeof(System.Int32));
                    dcol4.AutoIncrement = true;
                    dt1.Columns.Add(dcol4);

                    DataColumn dcol5 = new DataColumn("Base Billing", typeof(System.Int32));
                    dcol5.AutoIncrement = true;
                    dt1.Columns.Add(dcol5);

                    DataColumn dcol6 = new DataColumn("Base ARPU", typeof(System.Int32));
                    dcol6.AutoIncrement = true;
                    dt1.Columns.Add(dcol6);

                    DataColumn dcol7 = new DataColumn();
                    dcol7.DataType = Type.GetType("System.String");
                    dcol7.ColumnName = "Result";
                    dt1.Columns.Add(dcol7);
                }

                //ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype));
                if ((compmonth == "") && (compyear == ""))
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype), "", "");
                }
                else
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype), compmonth, compyear);
                }
                string mycountryid = string.Empty;
                string mycountryname=string.Empty;
                string _result = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow myrow = dt1.NewRow();
                    mycountryid = Convert.ToString(ds.Tables[0].Rows[0]["countryid"]);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (mycountryid==Convert.ToString(dr["countryid"]))
                        {
                            mycountryname=Convert.ToString(dr["countryname"]);
                            if (Convert.ToString(dr["xtype"]) == "1")
                            {
                                _sale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "2")
                            {
                                
                                _billing= Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "3")
                            {
                                _compsale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "4")
                            {
                                _compbilling = Convert.ToInt32(dr["totalcount"]);
                            }
                        } 
                        if (mycountryid!=Convert.ToString(dr["countryid"]))
                        {
                            
                            myrow[0]=mycountryname;
                            myrow[1]=_sale;
                            myrow[2]=_billing;
                            if (_sale > 0)
                            {
                                _arpu = Math.Round(_billing / _sale, 0);
                            }
                            myrow[3]=_arpu;
                            if (_compsale > 0)
                            {
                                _compARPU = Math.Round(_compbilling / _compsale, 0);
                            }
                            _result = "UP";
                            if (_arpu < _compARPU)
                            {
                                _result = "Down";
                            }
                            if ((compmonth != "") && (compyear != ""))
                            {
                                myrow[4] = _compsale;
                                myrow[5] = _compbilling;
                                myrow[6] = _compARPU;
                                myrow[7] = _result;
                            }
                            dt1.Rows.Add(myrow);
                            dt1.AcceptChanges();
                            myrow = dt1.NewRow();

                            _sale = 0;
                            _billing = 0;
                            _arpu = 0;
                            _compsale = 0;
                            _compbilling = 0;
                            _compARPU = 0;
                            mycountryname=Convert.ToString(dr["countryname"]);
                            if (Convert.ToString(dr["xtype"]) == "1")
                            {
                                _sale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "2")
                            {
                                
                                _billing= Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "3")
                            {
                                _compsale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "4")
                            {
                                _compbilling = Convert.ToInt32(dr["totalcount"]);
                            }
                        }
                        mycountryid=Convert.ToString(dr["countryid"]);
                    }
                    myrow[0]=mycountryname;
                    myrow[1]=_sale;
                    myrow[2]=_billing;
                    if (_sale > 0)
                    {
                        _arpu = Math.Round(_billing / _sale, 0);
                    }

                    myrow[3]=_arpu;
                    if (_compsale > 0)
                    {
                        _compARPU = Math.Round(_compbilling / _compsale, 0);
                    }
                    _result = "UP";
                    if (_arpu < _compARPU)
                    {
                        _result = "Down";
                    }
                    if ((compmonth != "") && (compyear != ""))
                    {
                        myrow[4] = _compsale;
                        myrow[5] = _compbilling;
                        myrow[6] = _compARPU;
                        myrow[7] = _result;
                    }
                    dt1.Rows.Add(myrow);
                    dt1.AcceptChanges();
                    DataView dv = dt1.DefaultView;
                    dv.Sort = SortExpression;
                    grdview1.DataSource = dv;
                    //grdview1.DataSource = dt1;
                    grdview1.DataBind();
                }
            }
            if (reptype == "2")
            {
                //DataColumn dcol0 = new DataColumn("Branch", typeof(System.String));
                //dcol0.AutoIncrement = true;
                //dt.Columns.Add(dcol0);

                DataColumn dctcol = new DataColumn();
                dctcol.DataType = Type.GetType("System.String");
                dctcol.ColumnName = "Branch";
                dt.Columns.Add(dctcol);

                DataColumn dcol1 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol1.AutoIncrement = true;
                dt.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("Total Billing", typeof(System.Int32));
                dcol2.AutoIncrement = true;
                dt.Columns.Add(dcol2);

                DataColumn dcol3 = new DataColumn("ARPU", typeof(System.Int32));
                dcol3.AutoIncrement = true;
                dt.Columns.Add(dcol3);
                //ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype));

                if ((compmonth != "") && (compyear != ""))
                {
                    DataColumn dcol4 = new DataColumn("Base Sale", typeof(System.Int32));
                    dcol4.AutoIncrement = true;
                    dt.Columns.Add(dcol4);

                    DataColumn dcol5 = new DataColumn("Base Billing", typeof(System.Int32));
                    dcol5.AutoIncrement = true;
                    dt.Columns.Add(dcol5);

                    DataColumn dcol6 = new DataColumn("Base ARPU", typeof(System.Int32));
                    dcol6.AutoIncrement = true;
                    dt.Columns.Add(dcol6);

                    DataColumn dcol7 = new DataColumn();
                    dcol7.DataType = Type.GetType("System.String");
                    dcol7.ColumnName = "Result";
                    dt.Columns.Add(dcol7);
                }
                if ((compmonth == "") && (compyear == ""))
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype), "", "");
                }
                else
                {
                    ds = objSalesSummaryReport.GetARPUReport(month, year, Convert.ToInt16(reptype), compmonth, compyear);
                }
                string mybranchid = string.Empty;
                string mybranchname = string.Empty;
                string _result = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow myrow = dt.NewRow();
                    mybranchid = Convert.ToString(ds.Tables[0].Rows[0]["branchid"]);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        
                        if (mybranchid == Convert.ToString(dr["branchid"]))
                        {
                            mybranchname = Convert.ToString(dr["branchname"]);
                            if (Convert.ToString(dr["xtype"]) == "1")
                            {
                                _sale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "2")
                            {

                                _billing = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "3")
                            {
                                _compsale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "4")
                            {
                                _compbilling = Convert.ToInt32(dr["totalcount"]);
                            }
                        }
                        if (mybranchid != Convert.ToString(dr["branchid"]))
                        {

                            myrow[0] = mybranchname;
                            myrow[1] = _sale;
                            myrow[2] = _billing;
                            if (_sale > 0)
                            {
                                _arpu = Math.Round(_billing / _sale, 0);
                            }
                            myrow[3] = _arpu;
                            if (_compsale > 0)
                            {
                                _compARPU = Math.Round(_compbilling / _compsale, 0);
                            }
                            _result = "UP";
                            if (_arpu < _compARPU)
                            {
                                _result = "Down";
                            }
                            if ((compmonth != "") && (compyear != ""))
                            {
                                myrow[4] = _compsale;
                                myrow[5] = _compbilling;
                                myrow[6] = _compARPU;
                                myrow[7] = _result;
                            }
                            dt.Rows.Add(myrow);
                            dt.AcceptChanges();
                            myrow = dt.NewRow();
                            _sale = 0;
                            _billing = 0;
                            _arpu = 0;
                            mybranchname = Convert.ToString(dr["branchname"]);
                            if (Convert.ToString(dr["xtype"]) == "1")
                            {
                                _sale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "2")
                            {

                                _billing = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "3")
                            {
                                _compsale = Convert.ToInt32(dr["totalcount"]);
                            }
                            if (Convert.ToString(dr["xtype"]) == "4")
                            {
                                _compbilling = Convert.ToInt32(dr["totalcount"]);
                            }
                        }
                        mybranchid = Convert.ToString(dr["branchid"]);
                    }
                    myrow[0] = mybranchname;
                    myrow[1] = _sale;
                    myrow[2] = _billing;
                    if (_sale > 0)
                    {
                        _arpu = Math.Round(_billing / _sale, 0);
                    }
                    myrow[3] = _arpu;
                    if (_compsale > 0)
                    {
                        _compARPU = Math.Round(_compbilling / _compsale, 0);
                    }
                    _result = "UP";
                    if (_arpu < _compARPU)
                    {
                        _result = "Down";
                    }
                    if ((compmonth != "") && (compyear != ""))
                    {
                        myrow[4] = _compsale;
                        myrow[5] = _compbilling;
                        myrow[6] = _compARPU;                        
                        myrow[7] = _result;
                    }
                    dt.Rows.Add(myrow);
                    dt.AcceptChanges();
                    DataView dv = dt.DefaultView;
                    dv.Sort = SortExpression;
                    grdview1.DataSource = dv;
                    //grdview1.DataSource = dt;
                    grdview1.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }


    protected void cmdExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdview1.Rows.Count > 0)
            {
                HtmlForm form = new HtmlForm();
                Response.Clear();
                Response.Buffer = true;
                string filename = "ARPU_" + DateTime.Now.ToString() + ".xls";

                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                //DisplayReport(ddlRepType.SelectedValue.ToString());
                
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //grdview1.AllowPaging = false;
                //grdview1.DataBind();
                form.Controls.Add(grdview1);
                this.Controls.Add(form);
                form.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

               
           }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void chkCompare_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCompare.Checked)
        {
            ddlCompMonth.Enabled = true;
            ddlCompYear.Enabled = true;
        }
        if(!chkCompare.Checked)
        {
            ddlCompMonth.SelectedIndex = -1;
            ddlCompYear.SelectedIndex = -1;
            ddlCompMonth.Enabled = false;
            ddlCompYear.Enabled = false;
        }
    }
    public string SortExpression
    {
        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
        set { ViewState["sortExpression"] = value; }
    }
    protected void grdview1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);

            string reptype = string.Empty;
            reptype = ddlRepType.SelectedValue.ToString();
            DisplayReport(reptype);
        }
    }
    private string GetSortDirection(string column)
    {

        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";

        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            // Check if the same column is being sorted.
            // Otherwise, the default value can be returned.
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC"))
                {
                    sortDirection = "DESC";
                }
            }
        }

        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }
}
