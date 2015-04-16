using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
public partial class MISReport_RptComparison : System.Web.UI.Page
{
    DataSet dsEmployee = null;

    Clay.Invoice.Bll.Report rpt = new Clay.Invoice.Bll.Report();
    Clay.Invoice.Bll.Web objSalesOrderWeb = null;

    void LoadBusRelManagerTocbManager()
    {
        dsEmployee = new DataSet();
        dsEmployee = rpt.GetEmployeeSalesAndCre();
        if (dsEmployee.Tables.Count > 0)
        {
            //DataRow dr;
            ddlManager.DataSource = dsEmployee.Tables[0];
            ddlManager.DataTextField = "employeename";
            ddlManager.DataValueField = "employeeid";
            ddlManager.DataBind();
        }


    }

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
        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            ddlYear1bymonth.DataSource = dsYear.Tables[0];
            ddlYear1bymonth.DataTextField = "yearVal";
            ddlYear1bymonth.DataValueField = "yearTxt";
            ddlYear1bymonth.DataBind();
            ddlYear1bymonth.SelectedIndex = 0;

            ddlYear2bymonth.DataSource = dsYear.Tables[0];
            ddlYear2bymonth.DataTextField = "yearVal";
            ddlYear2bymonth.DataValueField = "yearTxt";
            ddlYear2bymonth.DataBind();
            ddlYear2bymonth.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            ddlyear1byquarter.DataSource = dsYear.Tables[0];
            ddlyear1byquarter.DataTextField = "yearVal";
            ddlyear1byquarter.DataValueField = "yearTxt";
            ddlyear1byquarter.DataBind();
            ddlyear1byquarter.SelectedIndex = 0;

            ddlyear2byquarter.DataSource = dsYear.Tables[0];
            ddlyear2byquarter.DataTextField = "yearVal";
            ddlyear2byquarter.DataValueField = "yearTxt";
            ddlyear2byquarter.DataBind();
            ddlyear2byquarter.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            ddlyear1bysemi.DataSource = dsYear.Tables[0];
            ddlyear1bysemi.DataTextField = "yearVal";
            ddlyear1bysemi.DataValueField = "yearTxt";
            ddlyear1bysemi.DataBind();
            ddlyear1bysemi.SelectedIndex = 0;

            ddlyear2bysemi.DataSource = dsYear.Tables[0];
            ddlyear2bysemi.DataTextField = "yearVal";
            ddlyear2bysemi.DataValueField = "yearTxt";
            ddlyear2bysemi.DataBind();
            ddlyear2bysemi.SelectedIndex = 0;
        }
        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            ddlyear1byyear.DataSource = dsYear.Tables[0];
            ddlyear1byyear.DataTextField = "yearVal";
            ddlyear1byyear.DataValueField = "yearTxt";
            ddlyear1byyear.DataBind();
            ddlyear1byyear.SelectedIndex = 0;

            ddlyear2byyear.DataSource = dsYear.Tables[0];
            ddlyear2byyear.DataTextField = "yearVal";
            ddlyear2byyear.DataValueField = "yearTxt";
            ddlyear2byyear.DataBind();
            ddlyear2byyear.SelectedIndex = 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session["dataset"] = null;
            LoadBusRelManagerTocbManager();

        }
        lblmsg.Text = "";
        grdview1.DataSource = null;
        grdview1.DataBind();
        GridView2.DataSource = null;
        GridView2.DataBind();
        // checkSession();
        // checkpageright();
    }

    void checkpageright()
    {
        Clay.Invoice.Bll.Page objPage = new Clay.Invoice.Bll.Page();
        DataSet dspageright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        page = System.IO.Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);
        objPage.PageName = page;
        objPage.UserId = user;
        dspageright = objPage.CheckPageRight();

        if (dspageright.Tables[0].Rows.Count == 0)
        {
            Response.Redirect("../invoice/Error500.aspx");
            return;
        }

    }

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Write("<script language='javascript'>window.open('../../LoginWebErp.aspx','_parent','');</script>");
            }
        }
        catch
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

       
        if (radiobtnlstType.SelectedItem.Value == "3")
        {
            searchArpu();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            RadGrid2.Visible = true;
            RadGrid1New.Visible = true;
            search();
        }
       

    }

    public string SortExpression
    {
        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
        set { ViewState["sortExpression"] = value; }
    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    void displayrpt(string reptype,string fromsaleyear1,string fromsalemonth1, string fromsalemonth2,string fromsaleyear2,
                                    string frombillyear1, string frombillmonth1, string frombillmonth2, string frombillyear2,
                                    string tosaleyear1, string tosalemonth1, string tosalemonth2, string tosaleyear2,
                                    string tobillyear1, string tobillmonth1, string tobillmonth2, string tobillyear2,    
                                    string field)
    {
        Clay.Sale.Bll.CreditDetail objcollection = new Clay.Sale.Bll.CreditDetail();

        //int months = 0;
        decimal _saleamt = 0;
        decimal _billamt = 0;
        decimal _saleamt2 = 0;
        decimal _billamt2 = 0;
        decimal _arpu = 0;
        decimal _arpu2 = 0;      
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();        
        string _field = ddlcommon.SelectedValue.ToString();
        DataSet ds = new DataSet();

        #region Table1
        

        DataColumn dtcolyear1 = new DataColumn();
        dtcolyear1.DataType = Type.GetType("System.String");
        dtcolyear1.ColumnName = "Year";
        dt.Columns.Add(dtcolyear1);

        DataColumn dctcol0 = new DataColumn();
        dctcol0.DataType = Type.GetType("System.String");
        dctcol0.ColumnName = "Month";
        dt.Columns.Add(dctcol0);

        //DataColumn dtcolyear2 = new DataColumn();
        //dtcolyear2.DataType = Type.GetType("System.String");
        //dtcolyear2.ColumnName =toyear;
        //dt.Columns.Add(dtcolyear2);

        DataColumn dcol0 = new DataColumn("Total Sale", typeof(System.Int32));
        dcol0.AutoIncrement = true;
        dt.Columns.Add(dcol0);

        DataColumn dcol1 = new DataColumn("Total Billing", typeof(System.Decimal));
        dcol1.AutoIncrement = true;
        dt.Columns.Add(dcol1);

        DataColumn dcol2 = new DataColumn("ARPU", typeof(System.Int32));
        dcol2.AutoIncrement = true;
        dt.Columns.Add(dcol2);
       #endregion

        #region Table2
       

        DataColumn dtcolyear21 = new DataColumn();
        dtcolyear21.DataType = Type.GetType("System.String");
        dtcolyear21.ColumnName = "Year";
        dt2.Columns.Add(dtcolyear21);

        DataColumn dctco20 = new DataColumn();
        dctco20.DataType = Type.GetType("System.String");
        dctco20.ColumnName = "Month";
        dt2.Columns.Add(dctco20);

        //DataColumn dtcolyear2 = new DataColumn();
        //dtcolyear2.DataType = Type.GetType("System.String");
        //dtcolyear2.ColumnName =toyear;
        //dt.Columns.Add(dtcolyear2);

        DataColumn dco20 = new DataColumn("Total Sale", typeof(System.Int32));
        dco20.AutoIncrement = true;
        dt2.Columns.Add(dco20);

        DataColumn dco21 = new DataColumn("Total Billing", typeof(System.Decimal));
        dco21.AutoIncrement = true;
        dt2.Columns.Add(dco21);

        DataColumn dco22 = new DataColumn("ARPU", typeof(System.Int32));
        dco22.AutoIncrement = true;
        dt2.Columns.Add(dco22);
        #endregion

        ds = objcollection.GetARPUReport_compare(fromsaleyear1, fromsalemonth1, fromsalemonth2, fromsaleyear2,
                                                frombillyear1, frombillmonth1, frombillmonth2, frombillyear2,
                                                tosaleyear1, tosalemonth1, tosalemonth2, tosaleyear2,
                                                tobillyear1, tobillmonth1, tobillmonth2, tobillyear2,
                                                    reptype, _field);

            DataRow[] dr_arpu_frommonth1 = null;
            DataRow[] dr_arpu_frommonth2 = null;
            DataRow[] dr_arpu_frommonth3 = null;
            DataRow[] dr_arpu_frommonth4 = null;
            DataRow dr0 = null;
            DataRow dr2 = null;

            #region By Month
            if (rdiobtnlst.SelectedItem.Value == "1")
           {
               int frommonthid = Convert.ToInt32(fromsalemonth1);
               int frombillmonthid = Convert.ToInt32(frombillmonth1);
               for (int k = 0; k < 1; k++)
               {
                   dr0 = dt.NewRow();
                   Hashtable hashtable = GetHashtable();
                   _saleamt = 0;
                   _billamt = 0;
                   _arpu = 0;
                   string value1 = (string)hashtable[Convert.ToInt32(frommonthid)];
                   dr_arpu_frommonth1 = ds.Tables["table1"].Select("transmonth=" + frommonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                   dr_arpu_frommonth2 = ds.Tables["table2"].Select("transmonth=" + frombillmonthid.ToString());
                   if (dr_arpu_frommonth1.Length > 0)
                   {
                       _saleamt = Convert.ToDecimal(dr_arpu_frommonth1[0]["amount"].ToString());                    
                      
                   }
                   if (dr_arpu_frommonth1.Length > 0)
                   {
                       _billamt = Convert.ToDecimal(dr_arpu_frommonth2[0]["amount"].ToString());
                   }
                   if (_billamt == 0 && _saleamt == 0)
                   {
                       _arpu = 0;
                   }
                   else
                   {
                       _arpu = Math.Round(_billamt / _saleamt, 0);
                   }
                   if (frommonthid == 1 || frommonthid == 2 || frommonthid == 3)
                   {
                       dr0["Year"] = fromsaleyear2.ToString();
                   }
                   else
                   {
                       dr0["Year"] = fromsaleyear1.ToString();
                   }
                   dr0["Month"] = value1.ToString();
                   dr0["Total Sale"] = _saleamt.ToString();
                   dr0["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt));// _billamt.ToString();
                   dr0["ARPU"] = _arpu.ToString();
                   dt.Rows.Add(dr0);

                   if (frommonthid == 12)
                   {
                       frommonthid = 1;

                   }
                   else
                   {
                       frommonthid = frommonthid + 1;
                   }

                   if (frombillmonthid == 12)
                   {
                       frombillmonthid = 1;
                   }
                   else
                   {
                       frombillmonthid = frombillmonthid + 1;
                   }

               }
               int tomonthid = Convert.ToInt32(tosalemonth1);
               int tobillmonthid = Convert.ToInt32(tobillmonth1);
               for (int k = 0; k < 1; k++)
               {
                   dr2 = dt2.NewRow();
                   Hashtable hashtable = GetHashtable();
                   _saleamt2 = 0;
                   _billamt2 = 0;
                   _arpu2 = 0;
                   string value2 = (string)hashtable[Convert.ToInt32(tomonthid)];
                   dr_arpu_frommonth3 = ds.Tables["table3"].Select("transmonth=" + tomonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                   dr_arpu_frommonth4 = ds.Tables["table4"].Select("transmonth=" + tobillmonthid.ToString());
                   if (dr_arpu_frommonth3.Length > 0)
                   {
                       _saleamt2 = Convert.ToDecimal(dr_arpu_frommonth3[0]["amount"].ToString());
                       
                      
                   }
                   if (dr_arpu_frommonth4.Length > 0)
                   {
                       _billamt2 = Convert.ToDecimal(dr_arpu_frommonth4[0]["amount"].ToString());
                   }
                   if (_billamt2 == 0 && _saleamt2 == 0)
                   {
                       _arpu2 = 0;
                   }
                   else
                   {
                       _arpu2 = Math.Round(_billamt2 / _saleamt2, 0);
                   }
                   if (tomonthid == 1 || tomonthid == 2 || tomonthid == 3)
                   {
                       dr2["Year"] = tosaleyear2.ToString();
                   }
                   else
                   {
                       dr2["Year"] = tosaleyear1.ToString();
                   }
                   dr2["Month"] = value2.ToString();
                   dr2["Total Sale"] = _saleamt2.ToString();

                   //dr2["Total Billing"] = _billamt2.ToString();
                   dr2["Total Billing"] =string.Format("{0:n2}", Convert.ToDouble(_billamt2));
                   dr2["ARPU"] = _arpu2.ToString();
                   dt2.Rows.Add(dr2);

                   if (tomonthid == 12)
                   {
                       tomonthid = 1;

                   }
                   else
                   {
                       tomonthid = tomonthid + 1;
                   }

                   if (tobillmonthid == 12)
                   {
                       tobillmonthid = 1;
                   }
                   else
                   {
                       tobillmonthid = tobillmonthid + 1;
                   }

               }
           


            }
           # endregion

            #region By Quarter
            else if (rdiobtnlst.SelectedItem.Value == "2")
            {
                int frommonthid = Convert.ToInt32(fromsalemonth1);
                int frombillmonthid = Convert.ToInt32(frombillmonth1);
                for (int k = 0; k < 3; k++)
                {
                    dr0 = dt.NewRow();
                    Hashtable hashtable = GetHashtable();
                    _saleamt = 0;
                    _billamt = 0;
                    _arpu = 0;
                    string value1 = (string)hashtable[Convert.ToInt32(frommonthid)];
                    dr_arpu_frommonth1 = ds.Tables["table1"].Select("transmonth=" + frommonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                    dr_arpu_frommonth2 = ds.Tables["table2"].Select("transmonth=" + frombillmonthid.ToString());
                    if (dr_arpu_frommonth1.Length > 0)
                    {
                        _saleamt = Convert.ToDecimal(dr_arpu_frommonth1[0]["amount"].ToString());
                       
                      
                    }

                    if (dr_arpu_frommonth1.Length > 0)
                    {
                        _billamt = Convert.ToDecimal(dr_arpu_frommonth2[0]["amount"].ToString());
                    }
                    if (_billamt == 0 && _saleamt == 0)
                    {
                        _arpu = 0;
                    }
                    else
                    {
                        _arpu = Math.Round(_billamt / _saleamt, 0);
                    }
                    if (frommonthid == 1 || frommonthid == 2 || frommonthid == 3)
                    {
                        dr0["Year"] = fromsaleyear2.ToString();
                    }
                    else
                    {
                        dr0["Year"] = fromsaleyear1.ToString();
                    }
                    dr0["Month"] = value1.ToString();
                    dr0["Total Sale"] = _saleamt.ToString();
                    dr0["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt));// _billamt.ToString();
                    //dr0["Total Billing"] = _billamt.ToString();
                    dr0["ARPU"] = _arpu.ToString();
                    dt.Rows.Add(dr0);

                    if (frommonthid == 12)
                    {
                        frommonthid = 1;

                    }
                    else
                    {
                        frommonthid = frommonthid + 1;
                    }

                    if (frombillmonthid == 12)
                    {
                        frombillmonthid = 1;
                    }
                    else
                    {
                        frombillmonthid = frombillmonthid + 1;
                    }

                }
                int tomonthid = Convert.ToInt32(tosalemonth1);
                int tobillmonthid = Convert.ToInt32(tobillmonth1);
                for (int k = 0; k < 3; k++)
                {
                    dr2 = dt2.NewRow();
                    Hashtable hashtable = GetHashtable();
                    _saleamt2 = 0;
                    _billamt2 = 0;
                    _arpu2 = 0;
                    string value2 = (string)hashtable[Convert.ToInt32(tomonthid)];
                    dr_arpu_frommonth3 = ds.Tables["table3"].Select("transmonth=" + tomonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                    dr_arpu_frommonth4 = ds.Tables["table4"].Select("transmonth=" + tobillmonthid.ToString());
                    if (dr_arpu_frommonth3.Length > 0)
                    {
                        _saleamt2 = Convert.ToDecimal(dr_arpu_frommonth3[0]["amount"].ToString());
                       
                       
                    }
                    if (dr_arpu_frommonth4.Length > 0)
                    {
                        _billamt2 = Convert.ToDecimal(dr_arpu_frommonth4[0]["amount"].ToString());

                    }
                    if (_billamt2 == 0 && _saleamt2 == 0)
                    {
                        _arpu2 = 0;
                    }
                    else
                    {
                        _arpu2 = Math.Round(_billamt2 / _saleamt2, 0);
                    }
                    if (tomonthid == 1 || tomonthid == 2 || tomonthid == 3)
                    {
                        dr2["Year"] = tosaleyear2.ToString();
                    }
                    else
                    {
                        dr2["Year"] = tosaleyear1.ToString();
                    }
                    dr2["Month"] = value2.ToString();
                    dr2["Total Sale"] = _saleamt2.ToString();
                    dr2["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt2)); //_billamt2.ToString();
                    dr2["ARPU"] = _arpu2.ToString();
                    dt2.Rows.Add(dr2);

                    if (tomonthid == 12)
                    {
                        tomonthid = 1;

                    }
                    else
                    {
                        tomonthid = tomonthid + 1;
                    }

                    if (tobillmonthid == 12)
                    {
                        tobillmonthid = 1;
                    }
                    else
                    {
                        tobillmonthid = tobillmonthid + 1;
                    }

                }
         

            }
            #endregion

            #region By Semi year
           else if (rdiobtnlst.SelectedItem.Value == "3")
           {
               int frommonthid = Convert.ToInt32(fromsalemonth1);
               int frombillmonthid = Convert.ToInt32(frombillmonth1);
               for (int k = 0; k < 6; k++)
               {
                   dr0 = dt.NewRow();
                   Hashtable hashtable = GetHashtable();
                   _saleamt = 0;
                   _billamt = 0;
                   _arpu = 0;
                   string value1 = (string)hashtable[Convert.ToInt32(frommonthid)];
                   dr_arpu_frommonth1 = ds.Tables["table1"].Select("transmonth=" + frommonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                   dr_arpu_frommonth2 = ds.Tables["table2"].Select("transmonth=" + frombillmonthid.ToString());
                   if (dr_arpu_frommonth1.Length > 0)
                   {
                       _saleamt = Convert.ToDecimal(dr_arpu_frommonth1[0]["amount"].ToString());
                      
                       
                   }
                   if (dr_arpu_frommonth2.Length > 0)
                   {
                       _billamt = Convert.ToDecimal(dr_arpu_frommonth2[0]["amount"].ToString());
                   }
                   if (_billamt == 0 && _saleamt == 0)
                   {
                       _arpu = 0;
                   }
                   else
                   {
                       _arpu = Math.Round(_billamt / _saleamt, 0);
                   }

                   if (frommonthid == 1 || frommonthid == 2 || frommonthid == 3)
                   {
                       dr0["Year"] = fromsaleyear2.ToString();
                   }
                   else
                   {
                       dr0["Year"] = fromsaleyear1.ToString();
                   }
                   dr0["Month"] = value1.ToString();
                   dr0["Total Sale"] = _saleamt.ToString();
                   dr0["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt)); //_billamt.ToString();
                   dr0["ARPU"] = _arpu.ToString();
                   dt.Rows.Add(dr0);

                   if (frommonthid == 12)
                   {
                       frommonthid = 1;

                   }
                   else
                   {
                       frommonthid = frommonthid + 1;
                   }

                   if (frombillmonthid == 12)
                   {
                       frombillmonthid = 1;
                   }
                   else
                   {
                       frombillmonthid = frombillmonthid + 1;
                   }

               }
               int tomonthid = Convert.ToInt32(tosalemonth1);
               int tobillmonthid = Convert.ToInt32(tobillmonth1);
               for (int k = 0; k < 6; k++)
               {
                   dr2 = dt2.NewRow();
                   Hashtable hashtable = GetHashtable();
                   _saleamt2 = 0;
                   _billamt2 = 0;
                   _arpu2 = 0;
                   string value2 = (string)hashtable[Convert.ToInt32(tomonthid)];
                   dr_arpu_frommonth3 = ds.Tables["table3"].Select("transmonth=" + tomonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                   dr_arpu_frommonth4 = ds.Tables["table4"].Select("transmonth=" + tobillmonthid.ToString());
                   if (dr_arpu_frommonth3.Length > 0)
                   {
                       _saleamt2 = Convert.ToDecimal(dr_arpu_frommonth3[0]["amount"].ToString());
                      
                       
                   }
                   if (dr_arpu_frommonth4.Length > 0)
                   {
                       _billamt2 = Convert.ToDecimal(dr_arpu_frommonth4[0]["amount"].ToString());
                   }
                   if (_billamt2 == 0 && _saleamt2 == 0)
                   {
                       _arpu2 = 0;
                   }
                   else
                   {
                       _arpu2 = Math.Round(_billamt2 / _saleamt2, 0);
                   }
                   if (tomonthid == 1 || tomonthid == 2 || tomonthid == 3)
                   {
                       dr2["Year"] = tosaleyear2.ToString();
                   }
                   else
                   {
                       dr2["Year"] = tosaleyear1.ToString();
                   }
                   dr2["Month"] = value2.ToString();
                   dr2["Total Sale"] = _saleamt2.ToString();
                   dr2["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt2)); //_billamt2.ToString();
                   dr2["ARPU"] = _arpu2.ToString();
                   dt2.Rows.Add(dr2);

                   if (tomonthid == 12)
                   {
                       tomonthid = 1;

                   }
                   else
                   {
                       tomonthid = tomonthid + 1;
                   }

                   if (tobillmonthid == 12)
                   {
                       tobillmonthid = 1;
                   }
                   else
                   {
                       tobillmonthid = tobillmonthid + 1;
                   }

               }
         

            }
            #endregion

            #region By  year
          else if (rdiobtnlst.SelectedItem.Value == "4")
            {

                int frommonthid = Convert.ToInt32(fromsalemonth1);
                int frombillmonthid = Convert.ToInt32(frombillmonth1);
                for (int k = 0; k < 12; k++)
                {
                    dr0 = dt.NewRow();
                    Hashtable hashtable = GetHashtable();
                    _saleamt = 0;
                    _billamt = 0;
                    _arpu = 0;

                    string value1 = (string)hashtable[Convert.ToInt32(frommonthid)];
                    dr_arpu_frommonth1 = ds.Tables["table1"].Select("transmonth=" + frommonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                    dr_arpu_frommonth2 = ds.Tables["table2"].Select("transmonth=" + frombillmonthid.ToString());
                     if (dr_arpu_frommonth1.Length > 0)
                     {
                         _saleamt = Convert.ToDecimal(dr_arpu_frommonth1[0]["amount"].ToString());
                         
                         
                     }
                     if (dr_arpu_frommonth2.Length > 0)
                     {
                         _billamt = Convert.ToDecimal(dr_arpu_frommonth2[0]["amount"].ToString());
                     }
                     if (_billamt == 0 && _saleamt == 0)
                     {
                         _arpu = 0;
                     }
                     else
                     {
                         _arpu = Math.Round(_billamt / _saleamt, 0);
                     }
                     if (frommonthid == 1 || frommonthid == 2 || frommonthid == 3)
                     {
                         dr0["Year"] = fromsaleyear2.ToString();
                     }
                     else
                     {
                         dr0["Year"] = fromsaleyear1.ToString();
                     }
                     dr0["Month"] = value1.ToString();
                     dr0["Total Sale"] = _saleamt.ToString();
                     dr0["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt));// _billamt.ToString();
                     dr0["ARPU"] = _arpu.ToString();
                     dt.Rows.Add(dr0);

                     if (frommonthid == 12)
                     {
                         frommonthid = 1;
                         
                     }
                     else
                     {
                         frommonthid = frommonthid + 1;
                     }

                     if (frombillmonthid == 12)
                     {
                         frombillmonthid = 1;
                     }
                     else
                     {
                         frombillmonthid = frombillmonthid + 1;
                     }
                     
                }
                int tomonthid = Convert.ToInt32(tosalemonth1);
                int tobillmonthid = Convert.ToInt32(tobillmonth1);
                for (int k = 0; k < 12; k++)
                {
                    dr2 = dt2.NewRow();
                    Hashtable hashtable = GetHashtable();
                    _saleamt2 = 0;
                    _billamt2 = 0;
                    _arpu2 = 0;
                    string value2 = (string)hashtable[Convert.ToInt32(tomonthid)];
                    dr_arpu_frommonth3 = ds.Tables["table3"].Select("transmonth=" + tomonthid);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                    dr_arpu_frommonth4 = ds.Tables["table4"].Select("transmonth=" + tobillmonthid.ToString());
                    if (dr_arpu_frommonth3.Length > 0)
                    {
                        _saleamt2 = Convert.ToDecimal(dr_arpu_frommonth3[0]["amount"].ToString());                      
                      
                    }
                    if (dr_arpu_frommonth4.Length > 0)
                    {
                        _billamt2 = Convert.ToDecimal(dr_arpu_frommonth4[0]["amount"].ToString());
                    }
                    if (_billamt2 == 0 && _saleamt2 == 0)
                    {
                        _arpu2 = 0;
                    }
                    else
                    {
                        if (_saleamt2 == 0)
                        {
                            _arpu2 = 0;
                        }
                        else
                        {
                            _arpu2 = Math.Round(_billamt2 / _saleamt2, 0);
                        }
                    }
                    if (tomonthid == 1 || tomonthid == 2 || tomonthid == 3)
                    {
                        dr2["Year"] = tosaleyear2.ToString();
                    }
                    else
                    {
                        dr2["Year"] = tosaleyear1.ToString();
                    }
                    dr2["Month"] = value2.ToString();
                    dr2["Total Sale"] = _saleamt2.ToString();
                    dr2["Total Billing"] = string.Format("{0:n2}", Convert.ToDouble(_billamt2));// _billamt2.ToString();
                    dr2["ARPU"] = _arpu2.ToString();
                    dt2.Rows.Add(dr2);

                    if (tomonthid == 12)
                    {
                        tomonthid = 1;

                    }
                    else
                    {
                        tomonthid = tomonthid + 1;
                    }

                    if (tobillmonthid == 12)
                    {
                        tobillmonthid = 1;
                    }
                    else
                    {
                        tobillmonthid = tobillmonthid + 1;
                    }

                }
                //string[] _arrfrommonth1 = frommonth.Split(',');               
                //string[] _arrtomonth1 = tomonth.Split(',');               
                //foreach (string _frommonth in _arrfrommonth1)
                //{
                //    dr0 = dt.NewRow();
                //    Hashtable hashtable = GetHashtable();
                //    int monthid = Convert.ToInt32(_frommonth);
                //    if (monthid == 12)
                //    {
                //        monthid = 1;
                //    }
                //    else
                //    {
                //        monthid = monthid + 1;
                //    }
                //    string value1 = (string)hashtable[Convert.ToInt32(_frommonth)];
                //    dr_arpu_frommonth1 = ds.Tables["table1"].Select("transmonth=" + _frommonth);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
                //    dr_arpu_frommonth2 = ds.Tables["table2"].Select("transmonth=" + monthid.ToString());
                //    if (dr_arpu_frommonth1.Length > 0)
                //    {
                //        _saleamt = Convert.ToDecimal(dr_arpu_frommonth1[0]["amount"].ToString());
                //        _billamt = Convert.ToDecimal(dr_arpu_frommonth2[0]["amount"].ToString());
                //        _arpu = Math.Round(_billamt / _saleamt, 0);
                //    }
                    
                //    dr0["Year"] = fromyear.ToString();
                //    dr0["Month"] = value1.ToString();
                //    dr0["Total Sale"] = _saleamt.ToString();
                //    dr0["Total Billing"] = _billamt.ToString();
                //    dr0["ARPU"] = _arpu.ToString();
                //    dt.Rows.Add(dr0);
                //}
            //    foreach (string _tomonth in _arrtomonth1)
            //    {
            //        dr2 = dt2.NewRow();
            //        Hashtable hashtable = GetHashtable();
            //        int monthid = Convert.ToInt32(_tomonth);
            //        if (monthid == 12)
            //        {
            //            monthid = 1;
            //        }
            //        else
            //        {
            //            monthid = monthid + 1;
            //        }
            //        string value2 = (string)hashtable[Convert.ToInt32(_tomonth)];
            //        dr_arpu_frommonth3 = ds.Tables["table3"].Select("transmonth=" + _tomonth);// ds.Tables["table1"].Select("transmonth=" + _frommonth1);
            //        dr_arpu_frommonth4 = ds.Tables["table4"].Select("transmonth=" + monthid.ToString());
            //        if (dr_arpu_frommonth3.Length > 0)
            //        {
            //            _saleamt2 = Convert.ToDecimal(dr_arpu_frommonth3[0]["amount"].ToString());
            //            _billamt2 = Convert.ToDecimal(dr_arpu_frommonth4[0]["amount"].ToString());
            //            _arpu2 = Math.Round(_billamt2 / _saleamt2, 0);
            //        }
                   
            //        dr2["Year"] = toyear.ToString();
            //        dr2["Month"] = value2.ToString();
            //        dr2["Total Sale"] = _saleamt2.ToString();
            //        dr2["Total Billing"] = _billamt2.ToString();
            //        dr2["ARPU"] = _arpu2.ToString();
            //        dt2.Rows.Add(dr2);
            //    }

           }
            #endregion

            
            DataView dv = dt.DefaultView;
            dv.Sort = SortExpression;
            DataView dv2 = dt2.DefaultView;
            dv2.Sort = SortExpression;
            grdview1.DataSource = dv;
            grdview1.DataBind();
            GridView2.DataSource = dv2;
            GridView2.DataBind();
        
        

    }

    private void searchArpu()
    {
        int fromsaleyear1 = 0;
        int fromsaleyear2 = 0;
        int frombillyear1 = 0;
        int frombillyear2 = 0;

        int tosaleyear1 = 0;
        int tosaleyear2 = 0;
        int tobillyear1 = 0;
        int tobillyear2 = 0;

        string fromsalemonth1 = string.Empty;
        string fromsalemonth2 = string.Empty;
        string frombillmonth1 = string.Empty;
        string frombillmonth2 = string.Empty;

        string tosalemonth1 = string.Empty;
        string tosalemonth2 = string.Empty;
        string tobillmonth1 = string.Empty;
        string tobillmonth2 = string.Empty;


        lblmsg.Text = "";
        int month_1 = 0;
        int year_1 = 0;
        int month_2 = 0;
        int year_2 = 0;
        int managerid = 0;
        string fromdate1 = string.Empty;
        string todate1 = string.Empty;
        string fromdate2 = string.Empty;
        string todate2 = string.Empty;
       
        string reptype = string.Empty;
        // SortExpression = string.Empty;
        reptype = ddlRepType.SelectedValue.ToString();
         string _field = ddlcommon.SelectedValue.ToString();
       
        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            #region  By Month Report
            if ((ddlMonth1bymonth.SelectedIndex > 0) && (ddlYear1bymonth.SelectedIndex > 0) && (ddlMonth2bymonth.SelectedIndex > 0) && (ddlYear2bymonth.SelectedIndex > 0))
            {
                fromsaleyear1 = Convert.ToInt32(ddlYear1bymonth.SelectedValue);
                fromsaleyear2 = fromsaleyear1;
                fromsalemonth1 = ddlMonth1bymonth.SelectedValue;
                fromsalemonth2 = fromsalemonth1;
                if (fromsalemonth1 == "12")
                {
                    frombillmonth1 = "1";
                    frombillmonth2 = "1";
                    frombillyear1 = fromsaleyear1 + 1;
                    frombillyear2 = frombillyear1;
                }
                else
                {
                    int nxtmonth = Convert.ToInt32(ddlMonth1bymonth.SelectedValue);
                    nxtmonth = nxtmonth + 1;
                    frombillmonth1 = nxtmonth.ToString();
                    frombillmonth2 = nxtmonth.ToString();
                    frombillyear1 = fromsaleyear1 ;
                    frombillyear2 = frombillyear1;
                }

                tosaleyear1 = Convert.ToInt32(ddlYear2bymonth.SelectedValue);
                tosaleyear2 = tosaleyear1;
                tosalemonth1 =ddlMonth2bymonth.SelectedValue;
                tosalemonth2 = tosalemonth1;
                if (tosalemonth1 == "12")
                {
                    tobillmonth1 = "1";
                    tobillmonth2 = "1";
                    tobillyear1 = tosaleyear1 + 1;
                    tobillyear2 = tobillyear1;
                }
                else
                {
                    int nxtmonth2 = Convert.ToInt32(ddlMonth2bymonth.SelectedValue);
                    nxtmonth2 = nxtmonth2 + 1;
                    tobillmonth1 = nxtmonth2.ToString();
                    tobillmonth2 = nxtmonth2.ToString();
                    tobillyear1 = tosaleyear1;
                    tobillyear2 = tobillyear1;
                }              

                if (radiobtnlstType.SelectedItem.Value == "3")
                {
                    
                    if (reptype == "0")
                    {
                        grdview1.Visible = true;
                        GridView2.Visible = true;
                        displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                           frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                           tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                           tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                           _field);
                    }
                    else if (reptype == "1")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                           frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                           tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                           tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                           _field);
                        }
                        else
                        {
                            lblmsg.Text = "Please select country";
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                        }
                    }

                    else if (reptype == "2")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                           frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                           tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                           tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                           _field);

                        }
                        else
                        {
                            lblmsg.Text = "Please select Branch";
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                        }
                    }

                }


            }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                grdview1.DataSource = null;
                grdview1.DataBind();
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            #endregion
        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            #region By Quarter Report
            if ((ddlmonth1byquarter.SelectedIndex > 0) && (ddlyear1byquarter.SelectedIndex > 0) && (ddlmonth2byquarter.SelectedIndex > 0) && (ddlyear2byquarter.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;



                caseval = Convert.ToInt32(ddlmonth1byquarter.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2byquarter.SelectedValue);
                fromsaleyear1 = Convert.ToInt32(ddlyear1byquarter.SelectedValue);
                tosaleyear1 = Convert.ToInt32(ddlyear2byquarter.SelectedValue);
                switch (caseval)
                {
                   
                    case 1:
                        fromsalemonth1 = "4";//,5,6,7,8,9";
                        fromsalemonth2 = "6";//,6,7,8,9,10";
                        frombillmonth1 = "5";
                        frombillmonth2 = "7";
                        fromsaleyear2 = fromsaleyear1;
                        frombillyear1 = fromsaleyear1;
                        frombillyear2 = frombillyear1;
                        break;
                    case 2:
                      
                        fromsalemonth1 = "7";//,5,6,7,8,9";
                        fromsalemonth2 = "9";//,6,7,8,9,10";
                        frombillmonth1 = "8";
                        frombillmonth2 = "10";
                        fromsaleyear2 = fromsaleyear1;
                        frombillyear1 = fromsaleyear1;
                        frombillyear2 = frombillyear1;
                        break;
                    case 3:
                       
                         fromsalemonth1 = "10";//,5,6,7,8,9";
                        fromsalemonth2 = "12";//,6,7,8,9,10";
                        frombillmonth1 = "11";
                        frombillmonth2 = "1";
                        fromsaleyear2 = fromsaleyear1;
                        frombillyear1 = fromsaleyear1;
                        frombillyear2 = frombillyear1+1;
                        break;
                    case 4:
                        
                        fromsalemonth1 = "1";//,5,6,7,8,9";
                        fromsalemonth2 = "3";//,6,7,8,9,10";
                        frombillmonth1 = "2";
                        frombillmonth2 = "4";
                        fromsaleyear2 = fromsaleyear1+1;
                        frombillyear1 = fromsaleyear1+1;
                        frombillyear2 = frombillyear1;
                        break;
                }
                switch (caseval2)
                {
                    case 1:
                        tosalemonth1 = "4";//,5,6,7,8,9";
                        tosalemonth2 = "6";//,6,7,8,9,10";
                        tobillmonth1 = "5";
                        tobillmonth2 = "7";
                        tosaleyear2 = tosaleyear1;
                        tobillyear1 = tosaleyear1;
                        tobillyear2 = tobillyear1;
                        break;
                    case 2:

                        tosalemonth1 = "7";//,5,6,7,8,9";
                        tosalemonth2 = "9";//,6,7,8,9,10";
                        tobillmonth1 = "8";
                        tobillmonth2 = "10";
                        tosaleyear2 = tosaleyear1;
                        tobillyear1 = tosaleyear1;
                        tobillyear2 = tobillyear1;
                        break;
                    case 3:

                        tosalemonth1 = "10";//,5,6,7,8,9";
                        tosalemonth2 = "12";//,6,7,8,9,10";
                        tobillmonth1 = "11";
                        tobillmonth2 = "1";
                        tosaleyear2 = tosaleyear1;
                        tobillyear1 = tosaleyear1;
                        tobillyear2 = tobillyear1 + 1;
                        break;
                    case 4:

                        tosalemonth1 = "1";//,5,6,7,8,9";
                        tosalemonth2 = "3";//,6,7,8,9,10";
                        tobillmonth1 = "2";
                        tobillmonth2 = "4";
                        tosaleyear2 = tosaleyear1 + 1;
                        tobillyear1 = tosaleyear1 + 1;
                        tobillyear2 = tobillyear1;
                        break;
                }

                RadGrid2.Visible = false;
                RadGrid1New.Visible = false;
                if (radiobtnlstType.SelectedItem.Value == "3")
                {
                    
                    if (reptype == "0")
                    {
                        grdview1.Visible = true;
                        GridView2.Visible = true;
                        displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                    }
                    else if (reptype == "1")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                             frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                             tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                             tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                             _field);

                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select country";
                        }
                    }

                    else if (reptype == "2")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);

                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select Branch";
                        }
                    }
                }
                
           }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                grdview1.DataSource = null;
                grdview1.DataBind();
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            #endregion
        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            #region By Semi Year Report
            if ((ddlmonth1bysemi.SelectedIndex > 0) && (ddlyear1bysemi.SelectedIndex > 0) && (ddlmonth2bysemi.SelectedIndex > 0) && (ddlyear2bysemi.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;

                caseval = Convert.ToInt32(ddlmonth1bysemi.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2bysemi.SelectedValue);
                fromsaleyear1=Convert.ToInt32(ddlyear1bysemi.SelectedValue);
                tosaleyear1=Convert.ToInt32(ddlyear2bysemi.SelectedValue);
            //    year1 = Convert.ToInt32(ddlyear1bysemi.SelectedValue);
            //    year2 = Convert.ToInt32(ddlyear2bysemi.SelectedValue);
                switch (caseval)
                {
                    case 1:
                        fromsalemonth1 = "4";//,5,6,7,8,9";
                        fromsalemonth2 = "9";//,6,7,8,9,10";
                        frombillmonth1 = "5";
                        frombillmonth2 = "10";
                        fromsaleyear2 = fromsaleyear1;
                        frombillyear1 = fromsaleyear1;
                        frombillyear2 = frombillyear1;
                        break;
                    case 2:
                       fromsalemonth1 = "10";//,5,6,7,8,9";
                        fromsalemonth2 = "3";//,6,7,8,9,10";
                        frombillmonth1 = "11";
                        frombillmonth2 = "4";

                        fromsaleyear2 = fromsaleyear1+1;
                        frombillyear1 = fromsaleyear1;
                        frombillyear2 = fromsaleyear1 + 1;                        
                        break;
                }
                switch (caseval2)
                {
                    case 1:
                        tosalemonth1 = "4";//,5,6,7,8,9";
                        tosalemonth2 = "9";//,6,7,8,9,10";
                        tobillmonth1 = "5";
                        tobillmonth2 = "10";
                        tosaleyear2 = tosaleyear1;
                        tobillyear1 = tosaleyear1;
                        tobillyear2 = tobillyear1;

                        break;
                    case 2:
                        tosalemonth1 = "10";//,5,6,7,8,9";
                        tosalemonth2 = "3";//,6,7,8,9,10";
                        tobillmonth1 = "11";
                        tobillmonth2 = "4";
                        tosaleyear2 = tosaleyear1 + 1;
                        tobillyear1 = tosaleyear1;
                        tobillyear2 = tosaleyear1 + 1;   

                        break;

                }

                RadGrid2.Visible = false;
                RadGrid1New.Visible = false;
                if (radiobtnlstType.SelectedItem.Value == "3")
                {
                    // displayrpt(reptype, year1.ToString(), month1.ToString(), frommonth2.ToString(), year2.ToString(), month2.ToString(), tomonth2.ToString(), _field);
                    if (reptype == "0")
                    {
                        grdview1.Visible = true;
                        GridView2.Visible = true;
                        displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                    }
                    else if (reptype == "1")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select country";
                        }
                    }

                    else if (reptype == "2")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select Branch";
                        }
                    }
                }

            }
            else
            {
                lblmsg.Text = "You have choosen incorrect values";
                grdview1.DataSource = null;
                grdview1.DataBind();
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            #endregion
        }

        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            #region By Year Report
            if ((ddlyear1byyear.SelectedIndex > 0) && (ddlyear2byyear.SelectedIndex > 0))
            {


                
                //string tomonth2 = string.Empty;
                //string month2 = string.Empty;

                fromsaleyear1 = Convert.ToInt32(ddlyear1byyear.SelectedValue);
                fromsaleyear2 = fromsaleyear1 + 1;

                frombillyear1 = Convert.ToInt32(ddlyear1byyear.SelectedValue);
                frombillyear2 = frombillyear1 + 1;

                tosaleyear1 = Convert.ToInt32(ddlyear2byyear.SelectedValue);
                tosaleyear2 = tosaleyear1 + 1;

                tobillyear1 = Convert.ToInt32(ddlyear2byyear.SelectedValue);
                tobillyear2 = tobillyear1 + 1;

                fromsalemonth1 = "4";
                fromsalemonth2 = "3";
                frombillmonth1 = "5";
                frombillmonth2 = "4";

                tosalemonth1 = "4";
                tosalemonth2 = "3";
                tobillmonth1 = "5";
                tobillmonth2 = "4";

               // month1 = "4,5,6,7,8,9,10,11,12,1,2,3";
                //frommonth2 = "5,6,7,8,9,10,11,12,1,2,3,4";

               // month2 = "4,5,6,7,8,9,10,11,12,1,2,3";
              //  tomonth2 = "5,6,7,8,9,10,11,12,1,2,3,4";

                
                RadGrid2.Visible = false;
                RadGrid1New.Visible = false;
                
                if (radiobtnlstType.SelectedItem.Value == "3")
                {
                   // displayrpt(reptype, year1.ToString(), month1.ToString(), frommonth2.ToString(), year2.ToString(), month2.ToString(), tomonth2.ToString(), _field);
                    if (reptype == "0")
                    {
                        grdview1.Visible = true;
                        GridView2.Visible = true;
                        displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                    }
                    else if (reptype == "1")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);

                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select country";
                        }
                    }

                    else if (reptype == "2")
                    {
                        if (_field != "0")
                        {
                            grdview1.Visible = true;
                            GridView2.Visible = true;
                            displayrpt(reptype, fromsaleyear1.ToString(), fromsalemonth1.ToString(), fromsalemonth2.ToString(), fromsaleyear2.ToString(),
                                            frombillyear1.ToString(), frombillmonth1.ToString(), frombillmonth2.ToString(), frombillyear2.ToString(),
                                            tosaleyear1.ToString(), tosalemonth1.ToString(), tosalemonth2.ToString(), tosaleyear2.ToString(),
                                            tobillyear1.ToString(), tobillmonth1.ToString(), tobillmonth2.ToString(), tobillyear2.ToString(),
                                            _field);
                        }
                        else
                        {
                            grdview1.Visible = false;
                            GridView2.Visible = false;
                            lblmsg.Text = "Please select Branch";
                        }
                    }
                }
                
            }
            else
            {
                lblmsg.Text = "You have choosen incorrect values";
                grdview1.DataSource = null;
                grdview1.DataBind();
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            #endregion
        }

    }

    void LoadBranchTcbSearchBranch()
    {
        Clay.Common.Bll.Branch objBranch = null;
        DataSet dsSearchBranch = null;
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
            ddlcommon.DataSource = dsSearchBranch.Tables[0];
            ddlcommon.DataTextField = "branchname";
            ddlcommon.DataValueField = "branchid";
            ddlcommon.DataBind();
        }
    }

    protected void ddlRepType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRepType.SelectedValue == "1")
        {
            LoadCountry();
            ddlcommon.Visible = true;
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            
        }
        else if (ddlRepType.SelectedValue == "2")
        {
            LoadBranchTcbSearchBranch();
            ddlcommon.Visible = true;
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            
        }
        else
        {
            ddlcommon.Visible = false;
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            
        }
    }

    private void search()
    {
        lblmsg.Text = "";
        int month_1 = 0;
        int year_1 = 0;
        int month_2 = 0;
        int year_2 = 0;
        int managerid = 0;
        string fromdate1 = string.Empty;
        string todate1 = string.Empty;
        string fromdate2 = string.Empty;
        string todate2 = string.Empty;
        RadGrid2.Visible = true;
        RadGrid1New.Visible = true;
        RadGridYear1.Visible = false;
        RadGridYear2.Visible = false;
        if (ddlManager.SelectedValue.Trim().Length > 0)
        {
            managerid = Convert.ToInt32(ddlManager.SelectedValue);
        }
        else
        {
            managerid = 0;
        }
        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            #region  By Month Report
            if ((ddlMonth1bymonth.SelectedIndex > 0) && (ddlYear1bymonth.SelectedIndex > 0) && (ddlMonth2bymonth.SelectedIndex > 0) && (ddlYear2bymonth.SelectedIndex > 0))
            {
                month_1 = Convert.ToInt32(ddlMonth1bymonth.SelectedValue);
                year_1 = Convert.ToInt32(ddlYear1bymonth.SelectedValue);
                month_2 = Convert.ToInt32(ddlMonth2bymonth.SelectedValue);
                year_2 = Convert.ToInt32(ddlYear2bymonth.SelectedValue);

                DataSet ds_bymonthsale1 = new DataSet();
                DataSet ds_bymonthsale2 = new DataSet();
                
                if (radiobtnlstType.SelectedItem.Value == "1")
                {
                    
                    ds_bymonthsale1 = rpt.GetReportByMonthsale1(month_1, year_1, managerid);
                    ds_bymonthsale2 = rpt.GetReportByMonthsale2(month_2, year_2, managerid);
                }
                else
                {
                        int days= DateTime.DaysInMonth(year_1, month_1);                    
                        fromdate1 = year_1 + "-" + month_1 + "-" + "01";
                        todate1 = year_1 + "-" + month_1 + "-" + days.ToString();
                        //Bind Dataset 
                        ds_bymonthsale1 = rpt.GetReportByMonthBilling1(fromdate1, todate1, managerid);
                      
                        int days2 = DateTime.DaysInMonth(year_2, month_2);
                        fromdate2 = year_2 + "-" + month_2 + "-" + "01";
                        todate2 = year_2 + "-" + month_2 + "-" + days2.ToString();
                        //Bind Dataset 
                        ds_bymonthsale2 = rpt.GetReportByMonthBilling2(fromdate2, todate2, managerid);
                }
                RadGrid2.Visible = true;
                RadGrid1New.Visible = true;
                if (ds_bymonthsale1.Tables[0].Rows.Count > 0)
                {
                    RadGrid1New.DataSource = ds_bymonthsale1.Tables[0];
                    RadGrid1New.DataBind();

                    //Session["dataset"] = ds_bymonth;
                }
                else
                {
                    RadGrid1New.DataSource = ds_bymonthsale1.Tables[0];
                    RadGrid1New.DataBind();

                    // RadGrid1.DataSource = null;
                }
                if (ds_bymonthsale2.Tables[0].Rows.Count > 0)
                {
                    RadGrid2.DataSource = ds_bymonthsale2.Tables[0];
                    RadGrid2.DataBind();
                }
                else
                {
                    RadGrid2.DataSource = ds_bymonthsale2.Tables[0];
                    RadGrid2.DataBind();
                }
            }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                RadGrid1New.DataSource = null;
                RadGrid1New.DataBind();
                RadGrid2.DataSource = null;
                RadGrid2.DataBind();
            }
            #endregion
            
        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            #region By Quarter Report
            if ((ddlmonth1byquarter.SelectedIndex > 0) && (ddlyear1byquarter.SelectedIndex > 0) && (ddlmonth2byquarter.SelectedIndex > 0) && (ddlyear2byquarter.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;
                string month1 = string.Empty;
                string month2 = string.Empty;
                int year1 = 0;
                int year2 = 0;
                
                caseval = Convert.ToInt32(ddlmonth1byquarter.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2byquarter.SelectedValue);
                year_1 =Convert.ToInt32(ddlyear1byquarter.SelectedValue);
                year_2 = Convert.ToInt32(ddlyear2byquarter.SelectedValue);
                switch (caseval)
                {
                    case 1:
                        month1 = "4,5,6";
                        fromdate1 = year_1 + "-04-01";
                        todate1 = year_1 + "-06-30";
                        break;
                    case 2:
                        month1 = "7,8,9";
                         fromdate1 = year_1 + "-07-01";
                         todate1 = year_1 + "-09-30";
                        break;
                    case 3:
                        month1 = "10,11,12";
                         fromdate1 = year_1 + "-10-01";
                         todate1 = year_1 + "-12-31";
                        break;
                    case 4:
                         month1 = "1,2,3";
                         fromdate1 = year_1+1+"-01-01";
                         todate1 = year_1+1+"-03-31";
                        break;
                }
                switch (caseval2)
                {
                    case 1:
                        month2 = "4,5,6";
                        fromdate2 = year_2 + "-04-01";
                        todate2 = year_2 + "-06-30";
                        break;
                    case 2:
                         month2 = "7,8,9";
                        fromdate2 = year_2 + "-07-01";
                        todate2 = year_2 + "-09-30";
                        break;
                    case 3:
                         month2 = "10,11,12";
                        fromdate2 = year_2 + "-10-01";
                        todate2 = year_2 + "-12-31";
                        break;
                    case 4:
                        month2 = "1,2,3";
                        fromdate2 = year_2+1+"-01-01";
                        todate2 = year_2+1+"-03-31";
                        break;
                }
                year1 = Convert.ToInt32(ddlyear1byquarter.SelectedValue);
                year2 = Convert.ToInt32(ddlyear2byquarter.SelectedValue);
                DataSet ds_byquartersale1 = new DataSet();
                DataSet ds_byquartersale2 = new DataSet();
                RadGrid2.Visible = true;
                RadGrid1New.Visible = true;
                if (radiobtnlstType.SelectedItem.Value == "1")
                {

                    ds_byquartersale1 = rpt.GetReportByquartersale1(fromdate1, todate1, managerid);
                    ds_byquartersale2 = rpt.GetReportByquartersale2(fromdate2, todate2, managerid);
                }
                else
                {
                    ds_byquartersale1 = rpt.GetReportByquarterBilling1(fromdate1, todate1, managerid);
                    ds_byquartersale2 = rpt.GetReportByquarterBilling2(fromdate2, todate2, managerid);
                }
                if (ds_byquartersale1.Tables[0].Rows.Count > 0)
                {
                    RadGrid1New.DataSource = ds_byquartersale1.Tables[0].DefaultView;
                    RadGrid1New.DataBind();
                    //Session["dataset"] = ds_byquarter;
                }
                else
                {
                    RadGrid1New.DataSource = ds_byquartersale1.Tables[0];
                    RadGrid1New.DataBind();
                    // RadGrid1.DataSource = null;
                }
                if (ds_byquartersale2.Tables[0].Rows.Count > 0)
                {
                    RadGrid2.DataSource = ds_byquartersale2.Tables[0].DefaultView;
                    RadGrid2.DataBind();
                    //Session["dataset"] = ds_byquarter;
                }
                else
                {
                    RadGrid2.DataSource = ds_byquartersale2.Tables[0];
                    RadGrid2.DataBind();
                    // RadGrid1.DataSource = null;
                }
            }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                //  RadGrid1.DataSource = null;
                //  RadGrid1.DataBind();
            }
            #endregion
        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            #region By Semi Year Report
            if ((ddlmonth1bysemi.SelectedIndex > 0) && (ddlyear1bysemi.SelectedIndex > 0) && (ddlmonth2bysemi.SelectedIndex > 0) && (ddlyear2bysemi.SelectedIndex > 0))
            {
                int caseval = 0;
                int caseval2 = 0;
                string month1 = string.Empty;
                string month2 = string.Empty;
                int year1 = 0;
                int year2 = 0;
                caseval = Convert.ToInt32(ddlmonth1bysemi.SelectedValue);
                caseval2 = Convert.ToInt32(ddlmonth2bysemi.SelectedValue);
                year1 = Convert.ToInt32(ddlyear1bysemi.SelectedValue);
                year2 = Convert.ToInt32(ddlyear2bysemi.SelectedValue);
                switch (caseval)
                {
                    case 1:
                        month1 = "4,5,6,7,8,9";
                        fromdate1 = year1 + "-04-01";
                        todate1 = year1 + "-09-30";
                        break;
                    case 2:
                        month1 = "10,11,12,1,2,3";
                        fromdate1 = year1 + "-10-01";
                        todate1 = year1+1 + "-03-31";
                        break;
                    //case 3:
                    //   month1 = "10,11,12";
                    //    break;
                    //case 4:
                    //    month1 = "1,2,3";
                    //    break;
                }
                switch (caseval2)
                {
                    case 1:
                          month2 = "4,5,6,7,8,9";
                        fromdate2 = year2 + "-04-01";
                        todate2 = year2 + "-09-30";
                        break;
                    case 2:
                         month2 = "10,11,12,1,2,3";
                        fromdate2 = year2 + "-10-01";
                        todate2 = year2 + 1 + "-03-31";
                        break;

                }
               

                DataSet ds_bysemisale1 = new DataSet();
                DataSet ds_bysemisale2 = new DataSet();
                RadGrid2.Visible = true;
                RadGrid1New.Visible = true;
                if (radiobtnlstType.SelectedItem.Value == "1")
                {
                    ds_bysemisale1 = rpt.GetReportBySemiyearsale1(fromdate1, todate1, managerid);
                    ds_bysemisale2 = rpt.GetReportBySemiyearsale2(fromdate2, todate2, managerid);
                }
                else
                {
                    ds_bysemisale1 = rpt.GetReportBySemiyearBilling1(fromdate1, todate1, managerid);
                    ds_bysemisale2 = rpt.GetReportBySemiyearBilling2(fromdate2, todate2, managerid);
                }
                if (ds_bysemisale1.Tables[0].Rows.Count > 0)
                {
                    RadGrid1New.DataSource = ds_bysemisale1.Tables[0].DefaultView;
                    RadGrid1New.DataBind();
                    //Session["dataset"] = ds_byquarter;
                }
                else
                {
                    RadGrid1New.DataSource = ds_bysemisale1.Tables[0];
                    RadGrid1New.DataBind();
                    // RadGrid1.DataSource = null;
                }
                if (ds_bysemisale2.Tables[0].Rows.Count > 0)
                {
                    RadGrid2.DataSource = ds_bysemisale2.Tables[0].DefaultView;
                    RadGrid2.DataBind();
                    //Session["dataset"] = ds_byquarter;
                }
                else
                {
                    RadGrid2.DataSource = ds_bysemisale2.Tables[0];
                    RadGrid2.DataBind();
                    // RadGrid1.DataSource = null;
                }
            }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                //  RadGrid1.DataSource = null;
                //  RadGrid1.DataBind();


            }
            #endregion
        }
        
        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            #region By Year Report
            if ((ddlyear1byyear.SelectedIndex > 0) && (ddlyear2byyear.SelectedIndex > 0))
            {


                int year1 = 0;
                int year2 = 0;


                year1 = Convert.ToInt32(ddlyear1byyear.SelectedValue);
                year2 = Convert.ToInt32(ddlyear2byyear.SelectedValue);
                
                

                DataSet ds_byYearsale1 = new DataSet();
                DataSet ds_byYearsale2 = new DataSet();
                
                if (radiobtnlstType.SelectedItem.Value == "1")
                {
                    fromdate1 = year1 + "-04-01";
                    todate1 = year1 + 1 + "-03-31";

                    fromdate2 = year2 + "-04-01";
                    todate2 = year2 + 1 + "-03-31";

                    ds_byYearsale1 = rpt.GetReportByyearsale1(fromdate1, todate1, managerid);
                    ds_byYearsale2 = rpt.GetReportByyearsale2(fromdate2, todate2, managerid);
                }
                else
                {
                    fromdate1 = year1 + "-04-01";
                    todate1 = year1 + 1 + "-03-31";

                    fromdate2 = year2 + "-04-01";
                    todate2 = year2 + 1 + "-03-31";

                    ds_byYearsale1 = rpt.GetReportByyearBilling1(fromdate1,todate1, managerid);
                    ds_byYearsale2 = rpt.GetReportByyearBilling2(fromdate2, todate2, managerid);
                }
                if (radiobtnlstType.SelectedItem.Value == "1")
                {
                    if (ds_byYearsale1.Tables[0].Rows.Count > 0)
                    {
                        RadGrid1New.DataSource = ds_byYearsale1.Tables[0].DefaultView;
                        RadGrid1New.DataBind();
                        //Session["dataset"] = ds_byquarter;
                    }
                    else
                    {
                        RadGrid1New.DataSource = ds_byYearsale1.Tables[0];
                        RadGrid1New.DataBind();
                        // RadGrid1.DataSource = null;
                    }
                    if (ds_byYearsale2.Tables[0].Rows.Count > 0)
                    {
                        RadGrid2.DataSource = ds_byYearsale2.Tables[0].DefaultView;
                        RadGrid2.DataBind();
                        //Session["dataset"] = ds_byquarter;
                    }
                    else
                    {
                        RadGrid2.DataSource = ds_byYearsale2.Tables[0];
                        RadGrid2.DataBind();
                        // RadGrid1.DataSource = null;
                    }
                }
                else
                {
                    RadGrid2.Visible = false;
                    RadGrid1New.Visible = false;
                    RadGridYear1.Visible = true;
                    RadGridYear2.Visible = true;
                    if (ds_byYearsale1.Tables[0].Rows.Count > 0)
                    {
                        RadGridYear1.DataSource = ds_byYearsale1.Tables[0].DefaultView;
                        RadGridYear1.DataBind();
                        //Session["dataset"] = ds_byquarter;
                    }
                    else
                    {
                        RadGridYear1.DataSource = ds_byYearsale1.Tables[0];
                        RadGridYear1.DataBind();
                        // RadGrid1.DataSource = null;
                    }
                    if (ds_byYearsale2.Tables[0].Rows.Count > 0)
                    {
                        RadGridYear2.DataSource = ds_byYearsale2.Tables[0].DefaultView;
                        RadGridYear2.DataBind();
                        //Session["dataset"] = ds_byquarter;
                    }
                    else
                    {
                        RadGridYear2.DataSource = ds_byYearsale2.Tables[0];
                        RadGridYear2.DataBind();
                        // RadGrid1.DataSource = null;
                    }
                }
            }
            else
            {
                lblmsg.Text = "You have choosenn incorrect values";
                // RadGrid1.DataSource = null;
                //  RadGrid1.DataBind();
            }
            #endregion
        }

    }

    private void LoadCountry()
    {
        DataRow dr;
        DataSet dsCountry = new DataSet();
        Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new Clay.Sale.Bll.SalesSummaryReport();
        dsCountry = objSalesSummaryReport.GetCountry();
        dr = dsCountry.Tables[0].NewRow();
        dr["countryname"] = "Select Country";
        dr["countryid"] = "0";
        dsCountry.Tables[0].Rows.InsertAt(dr, 0);

        ddlcommon.DataSource = dsCountry.Tables[0];
        ddlcommon.DataValueField = "countryid";
        ddlcommon.DataTextField = "countryname";
        ddlcommon.DataBind();
    }

    //protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    //{
    //    if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
    //    {
    //        search();
    //    }
    //    else
    //    {
    //        search();
    //    }
    //}

    //protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    //{
    //    search();
    //}

    //protected void RadGrid1_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    //{
    //    search();
    //}

    //protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    //{
    //    decimal orders = 0;

    //    if (e.Item is GridHeaderItem)
    //    {
    //        GridHeaderItem item = e.Item as GridHeaderItem;
    //        if (radiobtnlstType.SelectedItem.Value == "1")
    //        {
    //            item["column1"].Text = "Total Sale";
    //            item["column2"].Text = "Total Sale";


    //        }
    //        else
    //        {
    //            item["column1"].Text = "Total Amount";
    //            item["column2"].Text = "Total Amount";
    //        }
    //    }

    //    if (e.Item is GridDataItem)
    //    {
    //        GridDataItem item = (GridDataItem)e.Item;
    //        if (item["column1"].Text != " ")
    //        {
    //            if (radiobtnlstType.SelectedItem.Value == "1")
    //            {
    //                orders = Convert.ToDecimal(item["column1"].Text);
    //                orders = Math.Truncate(orders);
    //                item["column1"].Text = orders.ToString();
    //            }
    //        }
    //    }     

    //}

    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        // this.UpdateToolTip(args.Value, args.UpdatePanel);
    }

    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        Control ctrl = Page.LoadControl("RafDetails.ascx");
        panel.ContentTemplateContainer.Controls.Add(ctrl);
        // ASP.user_crm_rafdetails_ascx details = (ASP.user_crm_rafdetails_ascx)ctrl;
        //   details.brID = Convert.ToInt32(elementID);
    }

    protected void radiobtnlstType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //rdiobtnlst.Visible = true;
        if (radiobtnlstType.SelectedItem.Value == "1")
        {
            RadGrid1New.Columns[2].HeaderText = "Total Sale";
            RadGrid2.Columns[2].HeaderText = "Total Sale";
            lblmsg.Text = "";
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trmanager.Visible = true;
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            trmangerdrop.Visible = true;
            trarpucountry.Visible = false;
        }
        else if (radiobtnlstType.SelectedItem.Value == "2")
        {
            trmangerdrop.Visible = true;
            RadGrid1New.Columns[2].HeaderText = "Total Amount";
            RadGrid2.Columns[2].HeaderText = "Total Amount";
            lblmsg.Text = "";
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            trmanager.Visible = true;
            trarpucountry.Visible = false;
        }
        else if (radiobtnlstType.SelectedItem.Value == "3")
        {
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trmanager.Visible = true;
            trmangerdrop.Visible = false;
            trarpucountry.Visible = true;
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
        }
        //ddlManager.SelectedIndex = 0;

        //LoadBusRelManagerTocbManager();


    }

    protected void rdiobtnlst_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdiobtnlst.SelectedItem.Value == "1")
        {
            //  RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trbymonth.Visible = true;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = false;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            if (radiobtnlstType.SelectedItem.Value == "3")
            {
               // trarpucountry.Visible = true;
               
            }

        }
        else if (rdiobtnlst.SelectedItem.Value == "2")
        {
            //  RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = true;
            trbysemiyear.Visible = false;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            if (radiobtnlstType.SelectedItem.Value == "3")
            {
                //trarpucountry.Visible = true;
                
            }

        }
        else if (rdiobtnlst.SelectedItem.Value == "3")
        {
            //  RadGrid1.DataSource = null;
            // RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = true;
            trbyyear.Visible = false;
            loadYear();
            lblmsg.Text = "";
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            if (radiobtnlstType.SelectedItem.Value == "3")
            {
                //trarpucountry.Visible = true;
               
            }

        }
        else if (rdiobtnlst.SelectedItem.Value == "4")
        {
            // RadGrid1.DataSource = null;
            //  RadGrid1.DataBind();
            RadGrid1New.DataSource = null;
            RadGrid1New.DataBind();
            RadGrid2.DataSource = null;
            RadGrid2.DataBind();
            trbymonth.Visible = false;
            trbyquarter.Visible = false;
            trbysemiyear.Visible = false;
            trbyyear.Visible = true;
            loadYear();
            lblmsg.Text = "";
            GridView2.DataSource = null;
            GridView2.DataBind();
            grdview1.DataSource = null;
            grdview1.DataBind();
            if (radiobtnlstType.SelectedItem.Value == "3")
            {
               // trarpucountry.Visible = true;
                
            }

        }
    }

    protected void RadGrid1New_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGrid1New.PageSize) > RadGrid1New.PageCount)
        {
            search();
        }
        else
        {
            search();
        }
    }

    protected void RadGrid1New_SortCommand(object source, GridSortCommandEventArgs e)
    {
        search();
    }

    protected void RadGrid1New_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        search();
    }

    
    double sum = 0;
    double sum2 = 0;

    protected void RadGrid1New_ItemDataBound(object sender, GridItemEventArgs e)
    {
        decimal orders = 0;

        //if (e.Item is GridHeaderItem)
        //{
        //    GridHeaderItem item = (GridHeaderItem)e.Item;          
            //if (radiobtnlstType.SelectedItem.Value == "1")
            //{
            //  //  item["column1"].Text = "Total Sale";
            //    RadGrid1New.Columns[2].HeaderText = "";
            //    RadGrid1New.Columns[2].HeaderText = "Total Sale";
            //  //  item["totalamount1"].Text = "Total Sale";


            //}
            //else
            //{
            //    RadGrid1New.Columns[2].HeaderText = "";
            //  //  item["column1"].Text = "Total Amount";                
            //    RadGrid1New.Columns[2].HeaderText = "Total Amount";
            //}
       // }

        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
         
                if (radiobtnlstType.SelectedItem.Value == "1")
                {
                    Label lbl1 = item.FindControl("lblamount1") as Label;
                    orders = Convert.ToDecimal(lbl1.Text);
                    orders = Math.Truncate(orders);
                    lbl1.Text = orders.ToString();
                   
                    sum += Convert.ToDouble(lbl1.Text);
                   // sum += double.Parse(item["column1"].Text);
                }
                else
                {
                    DateTime lbldate = Convert.ToDateTime(item["date1"].Text);
                    item["date1"].Text = lbldate.ToString("MMMM-yyyy");
                    Label lbl1 = item.FindControl("lblamount1") as Label;
                    orders = Math.Round(Convert.ToDecimal(lbl1.Text), 2);
                    lbl1.Text = orders.ToString();                   
                    sum += Convert.ToDouble(lbl1.Text);
                  //  sum += double.Parse(item["column1"].Text);
                }
            
        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandtotal") as Label;
            
            lblgrandtotal.Text = Convert.ToString(sum);
        }
        
    }

    double sumservicetax = 0;
    double sumcreditnote = 0;
    double sumnetamount = 0;
    protected void RadGridYear1_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGridYear1.PageSize) > RadGridYear1.PageCount)
        {
            search();
        }
        else
        {
            search();
        }
    }

    protected void RadGridYear1_SortCommand(object source, GridSortCommandEventArgs e)
    {
        search();
    }

    protected void RadGridYear1_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        search();
    }


    double sumservicetax2 = 0;
    double sumcreditnote2 = 0;
    double sumnetamount2 = 0;
    protected void RadGridYear1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        decimal orders = 0;

       

        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (radiobtnlstType.SelectedItem.Value == "1")
            {
                Label lbl1 = item.FindControl("lblamount1") as Label;
                orders = Convert.ToDecimal(lbl1.Text);
                orders = Math.Truncate(orders);
                lbl1.Text = orders.ToString();

                sum += Convert.ToDouble(lbl1.Text);
                // sum += double.Parse(item["column1"].Text);
            }
            else
            {
                DateTime lbldate = Convert.ToDateTime(item["date1"].Text);
                item["date1"].Text = lbldate.ToString("MMMM-yyyy");
                Label lbl1 = item.FindControl("lblamount1") as Label;
                Label lblservicetax1 = item.FindControl("lblservicetax1") as Label;
                Label lblcreditnote1 = item.FindControl("lblcreditnote1") as Label;
                Label lblnetamount1 = item.FindControl("lblnetamount1") as Label;
                orders = Math.Round(Convert.ToDecimal(lbl1.Text), 2);
                lbl1.Text = orders.ToString();
                
                sum += Convert.ToDouble(lbl1.Text);
                sumservicetax += Convert.ToDouble(lblservicetax1.Text);
                sumcreditnote += Convert.ToDouble(lblcreditnote1.Text);
                sumnetamount += Convert.ToDouble(lblnetamount1.Text);
                //  sum += double.Parse(item["column1"].Text);
            }

        }
        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandtotal") as Label;

            Label lblservicegrandtotal = item.FindControl("lblservicegrandtotal") as Label;
            Label lblcreditgrandtotal = item.FindControl("lblcreditgrandtotal") as Label;
            Label lblnetamountgrandtotal = item.FindControl("lblnetamountgrandtotal") as Label;

            lblgrandtotal.Text = Convert.ToString(sum);
            lblservicegrandtotal.Text = Convert.ToString(sumservicetax);
            lblcreditgrandtotal.Text = Convert.ToString(sumcreditnote);
            lblnetamountgrandtotal.Text = Convert.ToString(sumnetamount);
        }

    }

    protected void RadGridYear2_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        search();
    }
    protected void RadGridYear2_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGridYear2.PageSize) > RadGridYear2.PageCount)
        {
            search();
        }
        else
        {
            search();
        }
    }
    protected void RadGridYear2_ItemDataBound(object sender, GridItemEventArgs e)
    {

        decimal orders = 0;


        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            //if (item["column2"].Text != " ")
            //{
            if (radiobtnlstType.SelectedItem.Value == "1")
            {
                Label lbl1 = item.FindControl("lblamount1") as Label;
                orders = Convert.ToDecimal(lbl1.Text);
                orders = Math.Truncate(orders);
                lbl1.Text = orders.ToString();
                sum2 += Convert.ToDouble(lbl1.Text);
            }
            else
            {
                DateTime lbldate = Convert.ToDateTime(item["date2"].Text);
                item["date2"].Text = lbldate.ToString("MMMM-yyyy");
                Label lbl1 = item.FindControl("lblamount1") as Label;
                Label lblservicetax2 = item.FindControl("lblservicetax2") as Label;
                Label lblcreditnote2 = item.FindControl("lblcreditnote2") as Label;
                Label lblnetamount2 = item.FindControl("lblnetamount2") as Label;
                orders = Math.Round(Convert.ToDecimal(lbl1.Text), 2);
                lbl1.Text = orders.ToString();
                // sum += double.Parse(item["column2"].Text);                  
                sum2 += Convert.ToDouble(lbl1.Text);
                sumservicetax2 += Convert.ToDouble(lblservicetax2.Text);
                sumcreditnote2 += Convert.ToDouble(lblcreditnote2.Text);
                sumnetamount2 += Convert.ToDouble(lblnetamount2.Text);
            }
            //}
        }

        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandtotal") as Label;

            Label lblservicegrandtotal2 = item.FindControl("lblservicegrandtotal2") as Label;
            Label lblcreditgrandtotal2 = item.FindControl("lblcreditgrandtotal2") as Label;
            Label lblnetamountgrandtotal2 = item.FindControl("lblnetamountgrandtotal2") as Label;

            lblservicegrandtotal2.Text = Convert.ToString(sumservicetax2);
            lblcreditgrandtotal2.Text = Convert.ToString(sumcreditnote2);
            lblnetamountgrandtotal2.Text = Convert.ToString(sumnetamount2);
            lblgrandtotal.Text = Convert.ToString(sum2);
        }
    }
    protected void RadGridYear2_SortCommand(object source, GridSortCommandEventArgs e)
    {
        search();
    }

    protected void RadGrid2_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
    {
        search();
    }
    protected void RadGrid2_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGrid2.PageSize) > RadGrid2.PageCount)
        {
            search();
        }
        else
        {
            search();
        }
    }
    protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
    {

        decimal orders = 0;


        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            //if (item["column2"].Text != " ")
            //{
            if (radiobtnlstType.SelectedItem.Value == "1")
            {
                Label lbl1 = item.FindControl("lblamount1") as Label;
                orders = Convert.ToDecimal(lbl1.Text);
                orders = Math.Truncate(orders);
                lbl1.Text = orders.ToString();
                sum2 += Convert.ToDouble(lbl1.Text);
            }
            else
            {
                DateTime lbldate = Convert.ToDateTime(item["date2"].Text);
                item["date2"].Text = lbldate.ToString("MMMM-yyyy");
                Label lbl1 = item.FindControl("lblamount1") as Label;
                orders = Math.Round(Convert.ToDecimal(lbl1.Text), 2);
                lbl1.Text = orders.ToString();
                // sum += double.Parse(item["column2"].Text);                  
                sum2 += Convert.ToDouble(lbl1.Text);
            }
            //}
        }

        if (e.Item is GridFooterItem)
        {
            GridFooterItem item = (GridFooterItem)e.Item;
            Label lblgrandtotal = item.FindControl("lblgrandtotal") as Label;

            lblgrandtotal.Text = Convert.ToString(sum2);
        }
    }
    protected void RadGrid2_SortCommand(object source, GridSortCommandEventArgs e)
    {
        search();
    }

    protected string ConvertToMoneyFormat(string myval)
    {
        if (radiobtnlstType.SelectedItem.Value == "1")
        {
            return myval;
        }
        else
        {
            if (myval == "")
            {
                return "0.00";
            }
            else
            {
                return string.Format("{0:0.00}", Convert.ToDouble(myval));
            }
        }
    }

    

    static Hashtable GetHashtable()
    {
        Hashtable hashtable = new Hashtable();
        hashtable[1] = "Jan";
        hashtable[2] = "Feb";
        hashtable[3] = "Mar";
        hashtable[4] = "Apr";
        hashtable[5] = "May";
        hashtable[6] = "Jun";
        hashtable[7] = "Jul";
        hashtable[8] = "Aug";
        hashtable[9] = "Sep";
        hashtable[10] = "Oct";
        hashtable[11] = "Nov";
        hashtable[12] = "Dec";
        return hashtable;       
    }
    decimal _totalsale1 = 0;
    decimal _totalbill1 = 0;
    decimal _totalarpu1 = 0;
    //protected void grdview1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string lbltotsale1 = e.Row.Cells[2].Text;
    //        string lbltotbill1 = e.Row.Cells[3].Text;
    //        string lbltotarpu1 = e.Row.Cells[4].Text;
    //        _totalsale1 += Convert.ToDecimal(lbltotsale1);
    //        _totalbill1 += Convert.ToDecimal(lbltotbill1);
    //        _totalarpu1 += Convert.ToDecimal(lbltotarpu1);

    //        if (e.Row.Cells[0].Text == "Grand Total")
    //        {
    //            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
    //            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
    //        }
           
    //    }
    //  if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        double totalsalefooter1 = 0;
    //        double totalbillfooter1 = 0;
    //        double totalarpufooter1 = 0;
    //        foreach (GridViewRow gr in grdview1.Rows)
    //        {
    //            totalsalefooter1 += double.Parse(gr.Cells[2].Text);
    //            totalbillfooter1 += double.Parse(gr.Cells[3].Text);
    //            totalarpufooter1 += double.Parse(gr.Cells[4].Text);
    //        }
    //        e.Row.Cells[0].Text = "Grand Total";
    //        e.Row.Cells[2].Text = totalsalefooter1.ToString();
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
    //        e.Row.Cells[3].Text = totalbillfooter1.ToString("0.00");
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
    //        e.Row.Cells[4].Text = totalarpufooter1.ToString();
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
    //    }
    //}
    decimal _totalsale2 = 0;
    decimal _totalbill2 = 0;
    decimal _totalarpu2 = 0;
    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string lbltotsale2 = e.Row.Cells[2].Text;
    //        string lbltotbill2 = e.Row.Cells[3].Text;
    //        string lbltotarpu2 = e.Row.Cells[4].Text;
    //        _totalsale2 += Convert.ToDecimal(lbltotsale2);
    //        _totalbill2 += Convert.ToDecimal(lbltotbill2);
    //        _totalarpu2 += Convert.ToDecimal(lbltotarpu2);

    //        if (e.Row.Cells[0].Text == "Grand Total")
    //        {
    //            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
    //            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
    //        }

    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        double totalsalefooter2 = 0;
    //        double totalbillfooter2 = 0;
    //        double totalarpufooter2 = 0;
    //        foreach (GridViewRow gr in GridView2.Rows)
    //        {
    //            totalsalefooter2 += double.Parse(gr.Cells[2].Text);
    //            totalbillfooter2 += double.Parse(gr.Cells[3].Text);
    //            totalarpufooter2 += double.Parse(gr.Cells[4].Text);
    //        }
    //        e.Row.Cells[0].Text = "Grand Total";
    //        e.Row.Cells[2].Text = totalsalefooter2.ToString();
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
    //        e.Row.Cells[3].Text = totalbillfooter2.ToString("0.00");
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
    //        e.Row.Cells[4].Text = totalarpufooter2.ToString();
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
    //    }
    //}
    protected void grdview1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridHeaderItem)
        {
           e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            string lbltotsale1 = e.Item.Cells[4].Text;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
           
            
            string lbltotbill1 = e.Item.Cells[5].Text;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            string lbltotarpu1 = e.Item.Cells[6].Text;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            _totalsale1 += Convert.ToDecimal(lbltotsale1);
            _totalbill1 += Convert.ToDecimal(lbltotbill1);
            //_totalarpu1 += Convert.ToDecimal(lbltotarpu1);

        }

        if (e.Item is GridFooterItem)
        {
            if (_totalsale1 > 0)
            {
                _totalarpu1 = Math.Round(_totalbill1 / _totalsale1, 0);
            }
            else
            {
                _totalarpu1 = 0;
            }
            
            GridFooterItem item = (GridFooterItem)e.Item;
            e.Item.Cells[3].Text = "Grand Total";
            e.Item.Cells[4].Text = _totalsale1.ToString();
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = _totalbill1.ToString("0.00");
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].Text = _totalarpu1.ToString();
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
    }
    protected void GridView2_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridHeaderItem)
        {
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            string lbltotsale2 = e.Item.Cells[4].Text;
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            string lbltotbill2 = e.Item.Cells[5].Text;
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            string lbltotarpu2 = e.Item.Cells[6].Text;
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            _totalsale2 += Convert.ToDecimal(lbltotsale2);
            _totalbill2 += Convert.ToDecimal(lbltotbill2);
            //_totalarpu2 += Convert.ToDecimal(lbltotarpu2);

        }

        if (e.Item is GridFooterItem)
        {
            if (_totalsale2 > 0)
            {
                _totalarpu2 = Math.Round(_totalbill2 / _totalsale2, 0);
            }
            else
            {
                _totalarpu2 = 0;
            }
            
            GridFooterItem item = (GridFooterItem)e.Item;
            e.Item.Cells[3].Text = "Grand Total";
            e.Item.Cells[4].Text = _totalsale2.ToString();
            e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[5].Text = _totalbill2.ToString("0.00");
            e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[6].Text = _totalarpu2.ToString();
            e.Item.Cells[6].HorizontalAlign = HorizontalAlign.Right;
        }
    }
}