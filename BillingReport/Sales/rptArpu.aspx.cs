using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Text;
using Clay.Sale.Bll;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Sales_rptArpu : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();
    Clay.Sale.Bll.CreditDetail objcollection = new Clay.Sale.Bll.CreditDetail();
    Clay.Common.Bll.Branch objBranch = null;
    DataSet ds = new DataSet();
    DataSet dsBilling = new DataSet();
    DataSet dsEmployee = new DataSet();
    DataSet dsBranch = new DataSet();
    DataSet dsCountry = new DataSet();
    DataSet dsSearchBranch = null;

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

        // grdview1.DataSource = dt;
        //  grdview1.DataBind();
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
        CheckBoxListExCtrl1.Attributes.Add("onclick", "readCheckBoxList('" +
                    CheckBoxListExCtrl1.ClientID + "','" + MultiSelectDDL.ClientID + "','" +
                    hf_checkBoxText.ClientID + "','" +
                    hf_checkBoxValue.ClientID + "','" + hf_checkBoxSelIndex.ClientID + "');");

        MultiSelectDDL.Attributes.Add("onmousemove", "showIE6Tooltip();");
        MultiSelectDDL.Attributes.Add("onmouseout", "hideIE6Tooltip();");

        if (!string.IsNullOrEmpty(hf_checkBoxValue.Value))
        {
            SetDropDownListText(hf_checkBoxValue.Value);
        }

        if (!string.IsNullOrEmpty(hf_checkBoxText.Value))
        {
            SetToolTip(hf_checkBoxText.Value);
        }

        if (!IsPostBack)
        {
            //SetCheckBoxList("1,3,5");
            loadyear();

        }
    }
    void loadyear()
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
    }
    internal void SetToolTip(string title)
    {
        MultiSelectDDL.Attributes.Add("title", title);
        MultiSelectDDL.ToolTip = title;
    }

    internal void SetDropDownListText(string txt)
    {
        MultiSelectDDL.Items.Clear();
        MultiSelectDDL.Items.Add(new ListItem(txt));
    }

    //check the checkboxlist
    private void LoadCountry()
    {
        DataRow dr;

        dsCountry = objSalesSummaryReport.GetCountry();
        dr = dsCountry.Tables[0].NewRow();
        dr["countryname"] = "All";
        dr["countryid"] = "0";
        dsCountry.Tables[0].Rows.InsertAt(dr, 0);

        //ddlcommon.DataSource = dsCountry.Tables[0];
        //ddlcommon.DataValueField = "countryid";
        //ddlcommon.DataTextField = "countryname";
        //ddlcommon.DataBind();       

        chkmultiple.DataSource = dsCountry.Tables[0];
        chkmultiple.DataValueField = "countryid";
        chkmultiple.DataTextField = "countryname";
        chkmultiple.DataBind();
        // chkmultiple.Items[0].Selected = true;

    }
    public void SetCheckBoxList(string index)
    {
        string[] strArray;
        strArray = index.Split(@",".ToCharArray());
        string chkBoxIndex = string.Empty;
        string chkBoxValue = string.Empty;
        string chkBoxText = string.Empty;

        if (strArray.Length > 0)
        {
            int result;
            foreach (string s in strArray)
            {
                result = 0;

                if (int.TryParse(s, out result))
                {
                    CheckBoxListExCtrl1.Items[result].Selected = true;

                    //index
                    if (chkBoxIndex.Length > 0)
                        chkBoxIndex += ", ";

                    chkBoxIndex += result.ToString();

                    //value
                    if (chkBoxValue.Length > 0)
                        chkBoxValue += ", ";

                    chkBoxValue += CheckBoxListExCtrl1.Items[result].Value;

                    //text
                    if (chkBoxText.Length > 0)
                        chkBoxText += ", ";

                    chkBoxText += CheckBoxListExCtrl1.Items[result].Text;

                }
            }

            SetDropDownListText(chkBoxValue);
            SetToolTip(chkBoxText);
            hf_checkBoxSelIndex.Value = chkBoxIndex;
            hf_checkBoxText.Value = chkBoxText;
            hf_checkBoxValue.Value = chkBoxValue;
        }
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
            dr["branchname"] = "All";
            dr["branchid"] = 0;
            dsSearchBranch.Tables[0].Rows.InsertAt(dr, 0);
            //ddlcommon.DataSource = dsSearchBranch.Tables[0];
            //ddlcommon.DataTextField = "branchname";
            //ddlcommon.DataValueField = "branchid";
            //ddlcommon.DataBind();

            chkmultiple.DataSource = dsSearchBranch.Tables[0];
            chkmultiple.DataTextField = "branchname";
            chkmultiple.DataValueField = "branchid";
            chkmultiple.DataBind();
            //chkmultiple.Items[0].Selected = true; 

        }
    }
    protected void cmdFind_Click(object sender, EventArgs e)
    {
        string reptype = string.Empty;
        string _field = string.Empty;
        // SortExpression = string.Empty;
        reptype = ddlRepType.SelectedValue.ToString();
        grdview1.DataSource = null;
        grdview1.DataBind();
        if (hf_checkBoxValue.Value != "")
        {
            lblMonth.Visible = false;
            displayrpt(reptype);
        }
        else
        {
            lblMonth.Text = "Please Select Month!";
            lblMonth.Visible = true;
        }
    }
    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }
    void displayrpt(string reptype)
    {
        int months = 0;
        decimal _saleamt = 0;
        decimal _billamt = 0;
        decimal _arpu = 0;
        string _month_val = string.Empty;
        string _country = string.Empty;
        string branch = string.Empty;
        string year = ddlYear.SelectedValue.ToString();
        StringBuilder sb = new StringBuilder(string.Empty);
        sb.Append(hf_checkBoxValue.Value);
        string month = sb.ToString();
        string[] _month_arr = month.Split(',');
        DataTable dt = new DataTable();
        string _field = string.Empty;// ddlcommon.SelectedValue.ToString();

        try
        {
            #region RepType 0
            if (reptype == "0")
            {
                DataColumn dctcol0 = new DataColumn();
                dctcol0.DataType = Type.GetType("System.String");
                dctcol0.ColumnName = "Month";
                dt.Columns.Add(dctcol0);

                DataColumn dcol0 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol0.AutoIncrement = true;
                dt.Columns.Add(dcol0);

                DataColumn dcol1 = new DataColumn("Total Billing", typeof(System.Decimal));
                dcol1.AutoIncrement = true;
                dt.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("ARPU", typeof(System.Int32));
                dcol2.AutoIncrement = true;
                dt.Columns.Add(dcol2);
                ds = objcollection.GetARPUReport(month, year, Convert.ToInt32(reptype), _field);


                foreach (string i in _month_arr)
                {
                    DataRow dr0 = dt.NewRow();
                    months = Convert.ToInt32(i);
                    foreach (DataRow item in ds.Tables["Billing"].Rows)
                    {
                        DataRow[] dr_arpu = ds.Tables["Billing"].Select("_month=" + i);
                        if (dr_arpu.Length > 0)
                        {
                            if (Convert.ToInt32(dr_arpu[0]["xtype"]) == 1)
                            {
                                _saleamt = Convert.ToDecimal(dr_arpu[0]["totalcount"].ToString());
                            }
                            else
                            {
                                _saleamt = 0;
                            }
                            if (dr_arpu.Length == 2 && Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                            {
                                if (Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                                {
                                    _billamt = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_arpu[1]["totalcount"].ToString())));
                                }
                                else
                                {
                                    _billamt = 0;
                                }
                            }
                            
                           



                            _arpu = Math.Round(_billamt / _saleamt, 0);
                            _month_val = dr_arpu[0]["_date"].ToString();
                            break;
                        }
                    }
                    dr0["Month"] = _month_val.ToString();
                    dr0["Total Sale"] = _saleamt.ToString();
                    dr0["Total Billing"] = _billamt.ToString();
                    dr0["ARPU"] = _arpu.ToString();
                    dt.Rows.Add(dr0);
                    _saleamt = 0;
                    _billamt = 0;
                    _arpu = 0;



                }
                DataView dv = dt.DefaultView;
                dv.Sort = SortExpression;
                grdview1.DataSource = dv;
                grdview1.DataBind();
            }
            #endregion

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
        for (int k = 0; k < chkmultiple.Items.Count; k++)
        {
            if (chkmultiple.Items[k].Selected == true)
            {
                if (chkmultiple.Items[0].Selected == true)
                {
                    _field = "0";
                    break;
                }
                else
                {
                    _field += chkmultiple.Items[k].Value + ",";
                }
            }
        }
        if (string.IsNullOrEmpty(_field))
        {
            _field = "0";
        }
       // try
     //   {
            #region  Country Wise
            if (reptype == "1")
            {

                DataTable dt1 = new DataTable();
                //DataColumn dctcol = new DataColumn("CountryName", typeof(System.String));
                //dctcol.AutoIncrement = true;
                //dt1.Columns.Add(dctcol);
                DataColumn dctcol0 = new DataColumn();
                dctcol0.DataType = Type.GetType("System.String");
                dctcol0.ColumnName = "Month";
                dt1.Columns.Add(dctcol0);

                DataColumn dctcol = new DataColumn();
                dctcol.DataType = Type.GetType("System.String");
                dctcol.ColumnName = "Country";
                dt1.Columns.Add(dctcol);


                DataColumn dcol1 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol1.AutoIncrement = true;
                dt1.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("Total Billing", typeof(System.Decimal));
                dcol2.AutoIncrement = true;
                dt1.Columns.Add(dcol2);

                DataColumn dcol3 = new DataColumn("ARPU", typeof(System.Int32));
                dcol3.AutoIncrement = true;
                dt1.Columns.Add(dcol3);
                ds = objcollection.GetARPUReport(month, year, Convert.ToInt32(reptype), _field.TrimEnd(','));
                foreach (DataRow _datarow in ds.Tables["table2"].Rows)
                {


                    foreach (string i in _month_arr)
                    {
                        DataRow dr1 = dt1.NewRow();
                        months = Convert.ToInt32(i);
                        foreach (DataRow item in ds.Tables["Billing"].Rows)
                        {

                            DataRow[] dr_arpu = ds.Tables["Billing"].Select("_month=" + i + " and countryid=" + _datarow["travellingcountryid"]);
                            // DataRow[] dr_arpu = ds.Tables["Billing"].Select("_month=" + i + " and countryid=" + a);

                            if (dr_arpu.Length > 0)
                            {
                                if (Convert.ToInt32(dr_arpu[0]["xtype"]) == 1)
                                {
                                    _saleamt = Convert.ToDecimal(dr_arpu[0]["totalcount"] != "0" ? dr_arpu[0]["totalcount"] : 0.00);
                                }
                                else
                                {
                                    _saleamt = 0;
                                }
                                if (dr_arpu.Length == 2 && Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                                {
                                    if (Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                                    {
                                        _billamt = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_arpu[1]["totalcount"] != "0" ? dr_arpu[1]["totalcount"] : 0.00)));
                                    }
                                    else
                                    {
                                        _billamt = 0;
                                    }
                                }
                                
                                

                                _arpu = Math.Round(_billamt / _saleamt, 0);
                                _month_val = dr_arpu[0]["_date"].ToString();
                                _country = dr_arpu[0]["countryname"].ToString();
                                dr1["Month"] = _month_val.ToString();
                                dr1["Country"] = _country.ToString();
                                dr1["Total Sale"] = _saleamt.ToString();
                                dr1["Total Billing"] = _billamt.ToString();
                                dr1["ARPU"] = _arpu.ToString();
                                dt1.Rows.Add(dr1);
                                _saleamt = 0;
                                _billamt = 0;
                                _arpu = 0;
                                break;
                            }
                            break;
                        }



                    }
                }

                DataView dv = dt1.DefaultView;
                dv.Sort = SortExpression;
                grdview1.DataSource = dv;
                grdview1.DataBind();
            }
            #endregion

        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = ex.ToString();
        //}
        try
        {
            #region Barnch Wise
            if (reptype == "2")
            {
                DataTable dt2 = new DataTable();
                //DataColumn dcol0 = new DataColumn("Branch", typeof(System.String));
                //dcol0.AutoIncrement = true;
                //dt.Columns.Add(dcol0);
                DataColumn dctcol0 = new DataColumn();
                dctcol0.DataType = Type.GetType("System.String");
                dctcol0.ColumnName = "Month";
                dt2.Columns.Add(dctcol0);

                DataColumn dctcol = new DataColumn();
                dctcol.DataType = Type.GetType("System.String");
                dctcol.ColumnName = "Branch";
                dt2.Columns.Add(dctcol);

                DataColumn dcol1 = new DataColumn("Total Sale", typeof(System.Int32));
                dcol1.AutoIncrement = true;
                dt2.Columns.Add(dcol1);

                DataColumn dcol2 = new DataColumn("Total Billing", typeof(System.Decimal));
                dcol2.AutoIncrement = true;
                dt2.Columns.Add(dcol2);

                DataColumn dcol3 = new DataColumn("ARPU", typeof(System.Int32));
                dcol3.AutoIncrement = true;
                dt2.Columns.Add(dcol3);
                ds = objcollection.GetARPUReport(month, year, Convert.ToInt32(reptype), _field.TrimEnd(','));
                foreach (DataRow _datarow in ds.Tables["table2"].Rows)
                {
                    foreach (string i in _month_arr)
                    {
                        DataRow dr2 = dt2.NewRow();
                        months = Convert.ToInt32(i);
                        foreach (DataRow item in ds.Tables["Billing"].Rows)
                        {
                            DataRow[] dr_arpu = ds.Tables["Billing"].Select("_month=" + i + " and branchid=" + _datarow["branchid"]);
                            if (dr_arpu.Length > 0)
                            {
                                // _saleamt = Convert.ToDecimal(dr_arpu[0]["totalcount"].ToString());
                                //_billamt = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_arpu[1]["totalcount"].ToString())));
                                if (Convert.ToInt32(dr_arpu[0]["xtype"]) == 1)
                                {
                                    _saleamt = Convert.ToDecimal(dr_arpu[0]["totalcount"] != "0" ? dr_arpu[0]["totalcount"] : 0.00);
                                }
                                else
                                {
                                    _saleamt = 0;
                                }
                                if (dr_arpu.Length == 2 && Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                                {
                                    if (Convert.ToInt32(dr_arpu[1]["xtype"]) == 2)
                                    {
                                        _billamt = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_arpu[1]["totalcount"] != "0" ? dr_arpu[1]["totalcount"] : 0.00)));
                                    }
                                    else
                                    {
                                        _billamt = 0;
                                    }
                                }
                                _arpu = Math.Round(_billamt / _saleamt, 0);
                                _month_val = dr_arpu[0]["_date"].ToString();
                                branch = dr_arpu[0]["branchname"].ToString();
                                dr2["Month"] = _month_val.ToString();
                                dr2["Branch"] = branch.ToString();
                                dr2["Total Sale"] = _saleamt.ToString();
                                dr2["Total Billing"] = _billamt.ToString();
                                dr2["ARPU"] = _arpu.ToString();
                                dt2.Rows.Add(dr2);
                                _saleamt = 0;
                                _billamt = 0;
                                _arpu = 0;
                                break;
                            }
                            break;
                        }

                    }
                }

                DataView dv = dt2.DefaultView;
                dv.Sort = SortExpression;
                grdview1.DataSource = dv;
                grdview1.DataBind();
            }
            #endregion

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
    protected void ddlRepType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRepType.SelectedValue == "1")
        {
            LoadCountry();
            // ddlcommon.Visible = true;
            chkmultiple.Visible = true;
            divitem.Visible = true;
            grdview1.DataSource = null;
            grdview1.DataBind();
            lblMonth.Visible = false;
        }
        else if (ddlRepType.SelectedValue == "2")
        {
            LoadBranchTcbSearchBranch();
            // ddlcommon.Visible = true;
            chkmultiple.Visible = true;
            divitem.Visible = true;
            grdview1.DataSource = null;
            grdview1.DataBind();
            lblMonth.Visible = false;
        }
        else
        {
            //ddlcommon.Visible = false;
            chkmultiple.Visible = false;
            divitem.Visible = false;
            grdview1.DataSource = null;
            grdview1.DataBind();
            lblMonth.Visible = false;
        }
    }
    protected void grdview1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);

            string reptype = string.Empty;


            reptype = ddlRepType.SelectedValue.ToString();

            displayrpt(reptype);
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
    public string SortExpression
    {
        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
        set { ViewState["sortExpression"] = value; }
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
                grdview1.RenderControl(hw);

                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);//.ToString();
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

}