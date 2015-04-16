using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class CreditControl_CollectionReport : System.Web.UI.Page
{
    Clay.Sale.Bll.CreditDetail objcollection = new Clay.Sale.Bll.CreditDetail();
    DataSet ds_collection = new DataSet();
    ArrayList arr = new ArrayList();
    int count = 0;
   static int mylevel = 0;
   private const string ASCENDING = " ASC";
   private const string DESCENDING = " DESC";

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
           // BillingAmount();
            loadYear();
            mylevel = 0;
        }
       
            if (Request.QueryString["month"] != null)
            {
                if (mylevel == 3)
                {
                }
                else
                {
                    mylevel = Convert.ToInt32(Request.QueryString["level"]);
                    BindGrid();
                }
               
            }
            if (Request.QueryString["from"] != null)
            {
                if (mylevel == 3)
                {
                }
                else
                {
                    mylevel = Convert.ToInt32(Request.QueryString["level"]);
                    BindGrid();
                }
            }
        
        //BindGrid();
    }

    public void getreport(string fromdate,string todate)
    {
        //string fromdate = string.Empty;
       // string todate = string.Empty;
        DataSet ds_all = new DataSet();
        int branchid = 0;
        string branchname = string.Empty;
        string cheque = string.Empty;
        string cash = string.Empty;
        string cc = string.Empty;
        string bank = string.Empty;
        string online = string.Empty;
        string other = string.Empty;
        decimal totalbranch = 0;
        decimal totalcheque = 0;
        decimal totalcash = 0;
        decimal totalcc = 0;
        decimal totalbank = 0;
        decimal totalonline = 0;
        decimal totalother = 0;
        string _footertext = string.Empty;
        decimal _footertotalbranch = 0;
        decimal _footertotalcheque = 0;
        decimal _footertotalcash = 0;
        decimal _footertotalcc = 0;
        decimal _footertotalbank = 0;
        decimal _footertotalonline = 0;
        decimal _footertotalother = 0;
       // lblInvoice.Text = "";

        //if (!string.IsNullOrEmpty(txtfromdate.Text) && !string.IsNullOrEmpty(txttodate.Text))
        //{

            Clay.Sale.Bll.CreditDetail objcredit = new Clay.Sale.Bll.CreditDetail();
            ds_all = objcredit.Get_Daily_Credit_Report_Branch(fromdate, todate);


            #region Create Datatable
            System.Data.DataTable dt3 = new System.Data.DataTable();
            // dt.Columns.Add("Branchid", string.Empty.GetType());
            dt3.Columns.Add("Branchid", string.Empty.GetType());
            dt3.Columns.Add("Branch", string.Empty.GetType());
            dt3.Columns.Add("Cheque", typeof(System.Double));
            dt3.Columns.Add("Cash", typeof(System.Double));

            dt3.Columns.Add("CreditCard", typeof(System.Double));
            dt3.Columns.Add("Bank", typeof(System.Double));
            dt3.Columns.Add("Online", typeof(System.Double));
            dt3.Columns.Add("Other", typeof(System.Double));
            dt3.Columns.Add("Total", typeof(System.Double));

            #endregion

            int i = 0;
            foreach (DataRow dr in ds_all.Tables["branch"].Rows)
            {

                branchid = Convert.ToInt32(dr["branchid"]);
                branchname = dr["branchname"].ToString();

                #region ByCheque
                DataRow[] dr_cheque = ds_all.Tables["cheque"].Select("branchid=" + branchid);
                if (dr_cheque.Length > 0)
                {
                    if (dr_cheque[0]["cheque_amt"] != DBNull.Value)
                    {
                        cheque = Convert.ToString(dr_cheque[0]["cheque_amt"]);
                        totalbranch = Convert.ToDecimal(dr_cheque[0]["cheque_amt"]);
                        // totalcheque += Convert.ToDecimal(dr_cheque[0]["cheque_amt"]);
                    }
                    else
                    {
                        cheque = "0.00";
                        totalbranch += Convert.ToDecimal(cheque);
                    }
                }
                else
                {
                    cheque = "0.00";
                    totalbranch += Convert.ToDecimal(cheque);
                }
                #endregion

                #region Bycash
                DataRow[] dr_cash = ds_all.Tables["cash"].Select("branchid=" + branchid);
                if (dr_cash.Length > 0)
                {
                    if (dr_cash[0]["cash_amt"] != DBNull.Value)
                    {
                        cash = Convert.ToString(dr_cash[0]["cash_amt"]);
                        totalbranch += Convert.ToDecimal(dr_cash[0]["cash_amt"]);
                        // totalcash += Convert.ToDecimal(dr_cash[0]["cash_amt"]);
                    }
                    else
                    {
                        cash = "0.00";
                        totalbranch += Convert.ToDecimal(cash);
                    }
                }
                else
                {
                    cash = "0.00";
                    totalbranch += Convert.ToDecimal(cash);
                }
                #endregion

                #region ByCreditCard
                DataRow[] dr_cc = ds_all.Tables["cc"].Select("branchid=" + branchid);
                if (dr_cc.Length > 0)
                {
                    if (dr_cc[0]["credit_amt"] != DBNull.Value)
                    {
                        cc = Convert.ToString(dr_cc[0]["credit_amt"]);
                        totalbranch += Convert.ToDecimal(dr_cc[0]["credit_amt"]);
                        //  totalcc += Convert.ToDecimal(dr_cc[0]["credit_amt"]);
                    }
                    else
                    {
                        cc = "0.00";
                        totalbranch += Convert.ToDecimal(cc);
                    }
                }
                else
                {
                    cc = "0.00";
                    totalbranch += Convert.ToDecimal(cc);
                }
                #endregion

                #region ByBank
                DataRow[] dr_bank = ds_all.Tables["bank"].Select("branchid=" + branchid);
                if (dr_bank.Length > 0)
                {
                    if (dr_bank[0]["bank_amt"] != DBNull.Value)
                    {
                        bank = Convert.ToString(dr_bank[0]["bank_amt"]);
                        totalbranch += Convert.ToDecimal(dr_bank[0]["bank_amt"]);
                        //   totalbank += Convert.ToDecimal(dr_bank[0]["bank_amt"]);
                    }
                    else
                    {
                        bank = "0.00";
                        totalbranch += Convert.ToDecimal(bank);
                    }
                }
                else
                {
                    bank = "0.00";
                    totalbranch += Convert.ToDecimal(bank);
                }
                #endregion

                #region Byonline
                DataRow[] dr_online = ds_all.Tables["online"].Select("branchid=" + branchid);
                if (dr_online.Length > 0)
                {
                    if (dr_online[0]["online_amt"] != DBNull.Value)
                    {
                        online = Convert.ToString(dr_online[0]["online_amt"]);
                        totalbranch += Convert.ToDecimal(dr_online[0]["online_amt"]);
                        //    totalonline += Convert.ToDecimal(dr_online[0]["online_amt"]);
                    }
                    else
                    {
                        online = "0.00";
                        totalbranch += Convert.ToDecimal(online);
                    }
                }
                else
                {
                    online = "0.00";
                    totalbranch += Convert.ToDecimal(online);
                }

                #endregion

                #region Other
                DataRow[] dr_other = ds_all.Tables["None"].Select("branchid=" + branchid);
                if (dr_other.Length > 0)
                {
                    if (dr_other[0]["other"] != DBNull.Value)
                    {
                        other = Convert.ToString(dr_other[0]["other"]);
                        totalbranch += Convert.ToDecimal(dr_other[0]["other"]);
                        //    totalonline += Convert.ToDecimal(dr_online[0]["online_amt"]);
                    }
                    else
                    {
                        other = "0.00";
                        totalbranch += Convert.ToDecimal(other);
                    }
                }
                else
                {
                    other = "0.00";
                    totalbranch += Convert.ToDecimal(other);
                }

                #endregion


                DataRow dr1 = dt3.NewRow();
                dr1["Branchid"] = branchid.ToString();
                dr1["Branch"] = branchname.ToString();
                dr1["Cheque"] =ConvertToMoneyFormat(Convert.ToDouble(cheque)).ToString();
                dr1["Cash"] = ConvertToMoneyFormat(Convert.ToDouble(cash)).ToString();
                dr1["CreditCard"] = ConvertToMoneyFormat(Convert.ToDouble(cc)).ToString();
                dr1["Bank"] = ConvertToMoneyFormat(Convert.ToDouble(bank)).ToString();
                dr1["Online"] = ConvertToMoneyFormat(Convert.ToDouble(online)).ToString();
                dr1["Other"] = ConvertToMoneyFormat(Convert.ToDouble(other)).ToString();
                dr1["Total"] = Convert.ToString(ConvertToMoneyFormat(Convert.ToDouble(totalbranch)));
                _footertotalbranch += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(totalbranch)));
                dt3.Rows.Add(dr1);
                dt3.AcceptChanges();
                totalbranch = 0;
                i++;
                _footertotalcheque +=Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(cheque)));
                _footertotalcash += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(cash)));
                _footertotalcc += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(cc)));
               _footertotalbank += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(bank)));
                _footertotalonline += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(online)));
                _footertotalother += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(other)));
                
            }
            DataSet dsrpt = new DataSet();
            decimal _totalamt = 0;
            decimal amountdiff = 0;
            dsrpt = objcollection.GetCollection_rpt_Monthly(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "date");

            if (dsrpt.Tables["month"].Rows.Count > 0)
            {
                foreach (DataRow _dr in dsrpt.Tables["month"].Rows)
                {
                    decimal d = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
                    _totalamt += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
                }
            }
            lbltotalcollection.Text = _totalamt.ToString();
            lbltotalarjusted.Text = _footertotalbranch.ToString();
            amountdiff = _totalamt - _footertotalbranch;
            trarjsted.Visible = true;
            lblunarjsustedamt.Text = amountdiff.ToString();
            //DataRow drlast = dt.NewRow();
            //drlast["Branch"] = "Grand Total";
            //drlast["Cheque"] = _footertotalcheque.ToString();
            //drlast["Cash"] = _footertotalcash.ToString();
            //drlast["CreditCard"] = _footertotalcc.ToString();
            //drlast["Bank"] = _footertotalbank.ToString();
            //drlast["Online"] = _footertotalonline.ToString();
            //drlast["Total"] = Convert.ToString(_footertotalbranch);
            //dt.Rows.Add(drlast);
            //dt.AcceptChanges();
            DataView dv = dt3.DefaultView;
            foreach (DataColumn drcheck3 in dt3.Columns)
            {


                if (SortExpression.ToString().Contains(drcheck3.ToString()))
                {
                    dv.Sort = SortExpression;
                }

            }
           // dv.Sort = SortExpression;
            grdcollection.DataSource = dv;
            grdcollection.DataBind();
          //  grdbranchtotal.DataSource = dt;
           // grdbranchtotal.DataBind();

            
        //}
        //else
        //{
        //    lblInvoice.Text = "Please enter date";
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    imgexport.Visible = false;
        //}
    }

    private void bindunarjustedamount()
    {
        DataSet dsrpt = new DataSet();
        decimal _totalamt = 0;
        dsrpt = objcollection.GetCollection_rpt_Monthly(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "date");

        if (dsrpt.Tables["month"].Rows.Count > 0)
        {
            foreach (DataRow _dr in dsrpt.Tables["month"].Rows)
            {
                _totalamt += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
            }
        }
    }
    private void BindGrid()
    {
       
          if (mylevel == 0)
          {
              DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Amount", typeof(string));
                dt.Columns.Add("insertdatetime", typeof(string));
                DataRow dr = dt.NewRow();

                ds_collection = objcollection.GetCollection_rpt_Monthly(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "month");
                if (ds_collection.Tables["month"].Rows.Count > 0)
                {
                    dr["Date"] = ds_collection.Tables["month"].Rows[0]["AmountDate"].ToString();
                    dr["Amount"] = ConvertToMoneyFormat(Convert.ToDouble(ds_collection.Tables["month"].Rows[0]["Amount"])).ToString();
                    dr["insertdatetime"] = ds_collection.Tables["month"].Rows[0]["insertdatetime"].ToString();
                    dt.Rows.Add(dr);
                    //dt.Columns["insertdatetime"].ColumnMapping = MappingType.Hidden;
                    grdcollection.DataSource = dt;
                    grdcollection.DataBind();
                   // grdcollection.Columns["insertdatetime"].Visible = false;
                    grdcollection.Rows[0].Cells[2].Visible = false;
                    grdcollection.HeaderRow.Cells[2].Visible = false;
                    //grdcollection.Rows[0].

                }
            }


          if (mylevel == 1)
          {
              DataTable dt1 = new DataTable();
              dt1.Clear();
              dt1.Columns.Add("Date", typeof(string));
              dt1.Columns.Add("Amount", typeof(System.Double));
              dt1.Columns.Add("insertdatetime", typeof(string));
              DataSet ds_datewiseamount = new DataSet();
              string _month = Request.QueryString["month"];
              string _year = Request.QueryString["year"];
              decimal _footertotalamt_1 = 0;
             
                  ds_datewiseamount = objcollection.GetCollection_rpt_Monthly(_month, _year, "date");
             
              if (ds_datewiseamount.Tables["month"].Rows.Count > 0)
              {
                  foreach (DataRow _dr in ds_datewiseamount.Tables["month"].Rows)
                  {
                      DataRow dr = dt1.NewRow();
                      dr["Date"] = _dr["AmountDate"].ToString();
                      dr["Amount"] = ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])).ToString();
                      dr["insertdatetime"] = _dr["insertdatetime"].ToString();
                      _footertotalamt_1 += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
                      dt1.Rows.Add(dr);
                  }
                  //dt.AcceptChanges();
                  //DataRow _drfooter = dt.NewRow();
                  //_drfooter["Date"] = "Grand Total".ToString();
                  //_drfooter["Amount"] = _footertotalamt_1.ToString();
                  //_drfooter["insertdatetime"] = DateTime.Now.ToString();
                  //dt.Rows.Add(_drfooter);
                  dt1.AcceptChanges();
                  DataView dv = dt1.DefaultView;

                  foreach (DataColumn drcheck1 in dt1.Columns)
                  {


                      if (SortExpression.ToString().Contains(drcheck1.ToString()))
                      {
                          dv.Sort = SortExpression;
                      }

                  }
                  grdcollection.DataSource = dv;
                  grdcollection.DataBind();                
                  for(int i=0;i<grdcollection.Rows.Count;i++)
                  {
                      grdcollection.Rows[i].Cells[2].Visible = false;
                      grdcollection.HeaderRow.Cells[2].Visible = false;
                  }
              }
          }
          if (mylevel == 2)
          {
              DataTable dt2 = new DataTable();
              dt2.Clear();

              dt2.Columns.Add("Date", typeof(string));
              dt2.Columns.Add("Amount", typeof(System.Double));
              dt2.Columns.Add("insertdatetime", typeof(string));
              decimal _footertotalamt_2 = 0;
              DataSet ds_datewiseamount = new DataSet();



              ds_datewiseamount = objcollection.GetCollection_rpt_Monthly(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "date");

              if (ds_datewiseamount.Tables["month"].Rows.Count > 0)
              {
                  foreach (DataRow _dr in ds_datewiseamount.Tables["month"].Rows)
                  {
                      DataRow dr = dt2.NewRow();
                      dr["Date"] = _dr["AmountDate"].ToString();
                      dr["Amount"] = ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])).ToString();
                      dr["insertdatetime"] = _dr["insertdatetime"].ToString();
                      _footertotalamt_2 += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
                      dt2.Rows.Add(dr);
                  }
                  dt2.AcceptChanges();

                  //DataRow _drfooter = dt.NewRow();
                  //_drfooter["Date"] = "Grand Total".ToString();
                  //_drfooter["Amount"] = _footertotalamt_2.ToString();
                  //_drfooter["insertdatetime"] = DateTime.Now.ToString();
                  //dt.Rows.Add(_drfooter);
                  //dt.AcceptChanges();
                  DataView dv = dt2.DefaultView;

                  foreach (DataColumn drcheck in dt2.Columns)
                  {


                      if (SortExpression.ToString().Contains(drcheck.ToString()))
                      {
                          dv.Sort = SortExpression;
                      }

                  }




                  grdcollection.DataSource = dv;
                  grdcollection.DataBind();
                  for (int i = 0; i < grdcollection.Rows.Count; i++)
                  {
                      grdcollection.Rows[i].Cells[2].Visible = false;
                      grdcollection.HeaderRow.Cells[2].Visible = false;
                  }


              }
          }
          else
          {
              grdcollection.DataSource = null;
              grdcollection.DataBind();
          }
          if (mylevel == 3)
          {
              string fromdate1 = string.Empty;
              string todate1 = string.Empty;
              int days = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
              fromdate1 = Convert.ToInt32(ddlYear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth.SelectedValue) + "-" + "01";
              todate1 =  Convert.ToInt32(ddlYear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth.SelectedValue) +"-" + days.ToString();
              getreport(fromdate1, todate1);
              for (int i = 0; i < grdcollection.Rows.Count; i++)
              {
                  grdcollection.Rows[i].Cells[0].Visible = false;
                  grdcollection.HeaderRow.Cells[0].Visible = false;
              }

          }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BillingAmount();
        if (ddlreport.SelectedIndex == 0)
        {
            mylevel = 0;
            //BindGrid();
        }
        else if (ddlreport.SelectedValue == "2")
        {
            mylevel = 2;          
            trarjsted.Visible = false;
            trbilling.Visible = true;
            //BindGrid();          
           //getdatewise_amount(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString());
       }
        else if (ddlreport.SelectedValue == "3")
        {

            trarjsted.Visible = true;
            trbilling.Visible = false;
            mylevel = 3;
            //BindGrid();
        }
        BindGrid();

    }

    private void twocolumngridview(string month, string year)
    {
        
        ds_collection = objcollection.GetCollection_rpt_Monthly(month, year,"month");
        if (ds_collection.Tables["month"].Rows.Count > 0)
        {
            grdcollection.Visible = true;
            grdcollection.DataSource = ds_collection;
            grdcollection.DataBind();
        }    

    }

    
    protected void grdcollection_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //GridViewRow valu = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;

        //int RowIndex = valu.RowIndex;
        //Label value = (Label)grdcollection.Rows[RowIndex].FindControl("lbldate");
        //DateTime dt = Convert.ToDateTime(value.Text);
        //string _month = Convert.ToString(dt.Month);
        //string _year = Convert.ToString(dt.Year);
        //getdatewise_amount(_month, _year);

       
    }

    private void getdatewise_amount(string _month,string _year)
    {
        //string hlink2 = "javascript:calldetails2('" + lblbillfilename.Text + "','" + POID.Text + "')";
        //e.Row.Cells[8].Text = "<a href=" + hlink2 + ">View</a>";
        DataSet ds_datewiseamount = new DataSet();
        ds_datewiseamount = objcollection.GetCollection_rpt_Monthly(_month, _year, "date");
        if (ds_datewiseamount.Tables["month"].Rows.Count > 0)
        {
           // grdviewamountwisedate.DataSource = ds_datewiseamount;
           // grdviewamountwisedate.DataBind();
        }
    }

    decimal _totalamt = 0;
    //protected void grdviewamountwisedate_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblfromdate = (Label)e.Row.Cells[0].FindControl("lbldatewiseamount");
    //        Label lbltodate = (Label)e.Row.Cells[0].FindControl("lbldatewiseamount");
    //        LinkButton lnk = (LinkButton)e.Row.Cells[0].FindControl("lnkamtdate");
    //        Label lblamt = (Label)e.Row.Cells[0].FindControl("lblamt");
    //        _totalamt += Convert.ToDecimal(lblamt.Text);
    //        lnk.Attributes["onclick"] = "JavaScript:window.open('DailyReport.aspx?from="+Server.UrlEncode(lblfromdate.Text.ToString()) +"&todate=" +Server.UrlEncode(lbltodate.Text.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";                    
    //       // string hlink = "javascript:calldetails('" + lblfromdate.Text + "','" + lbltodate.Text + "')";
    //       // lnk.Text = "<a href=" + hlink + "></a>";
    //    }
    //    else if(e.Row.RowType==DataControlRowType.Footer)
    //    {
    //        Label lbltotamt = (Label)e.Row.FindControl("lbltotamt");
    //        lbltotamt.Text = _totalamt.ToString();
    //    }
    //}
    int i = 0;
    string colcheque = string.Empty;
    string colcash = string.Empty;
    string colcc = string.Empty;
    string colbank = string.Empty;
    string colonline = string.Empty;
    string colother = string.Empty;
    protected void grdcollection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (mylevel == 0)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime _date = Convert.ToDateTime(e.Row.Cells[2].Text);
                string _month = Convert.ToString(_date.Month);
                string _year = Convert.ToString(_date.Year);
                string _curmonth = e.Row.Cells[0].Text;
                string hlink2 = "javascript:callreport('" + _month + "','" + _year + "','1')";
                //string hlink2 = getdatewise_amount(_month , _year );
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + _curmonth + "</a>";
                grdcollection.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdcollection.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                // mylevel = 1;<a href=" + hlink2 + ">View</a>
                // BindGrid();
            }
        }
        else if (mylevel == 1)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime _date = Convert.ToDateTime(e.Row.Cells[2].Text);
                string newdate = _date.Year + "-" + _date.Month + "-" + _date.Day;
                string lblamt = e.Row.Cells[1].Text;
                _totalamt += Convert.ToDecimal(lblamt);
                string _curmonth = e.Row.Cells[0].Text;
              //  IFrame1.Visible = true;
                IFrame1.Attributes.Add("style", "display:none");


                if (e.Row.Cells[0].Text == "Grand Total")
                {
                    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    string hlink2 = "javascript:calldailyreport('" + newdate + "','" + newdate + "','3')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                    e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + _curmonth + "</a>";
                    grdcollection.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    grdcollection.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                double total = 0;
                foreach (GridViewRow gr in grdcollection.Rows)
                {
                    total += double.Parse(gr.Cells[1].Text);
                }
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].Text = total.ToString("0.00");
            }
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //  //  e.Row.Cells[2].Text = _totalamt.ToString();
            //}
        }
        else if (mylevel == 2)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime _date = Convert.ToDateTime(e.Row.Cells[2].Text);
                string newdate = _date.Year + "-" + _date.Month + "-" + _date.Day;
                string lblamt = e.Row.Cells[1].Text;
                _totalamt += Convert.ToDecimal(lblamt);
                string _curmonth = e.Row.Cells[0].Text;
                //IFrame1.Visible = true;
                IFrame1.Attributes.Add("style", "display:none");

                if (e.Row.Cells[0].Text == "Grand Total")
                {
                    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    string hlink2 = "javascript:calldailyreport('" + newdate + "','" + newdate + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                    e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + _curmonth + "</a>";
                    grdcollection.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    grdcollection.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                double total = 0;
                foreach (GridViewRow gr in grdcollection.Rows)
                {
                    total += double.Parse(gr.Cells[1].Text);
                }
                e.Row.Cells[0].Text ="Grand Total";
                e.Row.Cells[1].Text = total.ToString("0.00");
            }
        }
        else if (mylevel == 3)
        {
            
           
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText_colcheque = e.Row.Cells[2].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                colcheque = LnkHeaderText_colcheque.Text;
                LinkButton LnkHeaderText_colcash = e.Row.Cells[3].Controls[0] as LinkButton;
                colcash = LnkHeaderText_colcash.Text;
                LinkButton LnkHeaderText_colcc = e.Row.Cells[4].Controls[0] as LinkButton;
                colcc = LnkHeaderText_colcc.Text;
                LinkButton LnkHeaderText_colbank = e.Row.Cells[5].Controls[0] as LinkButton;
                colbank = LnkHeaderText_colbank.Text;
                LinkButton LnkHeaderText_colonline = e.Row.Cells[6].Controls[0] as LinkButton;
                colonline = LnkHeaderText_colonline.Text;
                LinkButton LnkHeaderText_Other = e.Row.Cells[7].Controls[0] as LinkButton;
                colother = LnkHeaderText_Other.Text;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string branchid = e.Row.Cells[0].Text;
                string branchname = e.Row.Cells[1].Text;
                string parmbranchname = string.Empty;
                parmbranchname = HttpUtility.UrlEncode(branchname);
                // string colcheque = grdcollection.HeaderRow.Cells[2].Text;
                string colchequeamt = e.Row.Cells[2].Text;
                grdcollection.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                IFrame1.Attributes.Add("style", "display:none");
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    //grdcollection.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colchequeamt == "0.00")
                    {

                    }
                    else
                    {
                       
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colcheque + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[2].Text = "<a href=" + hlink2 + ">" + colchequeamt + "</a>";


                    }
                }

            //    string colcash = grdcollection.HeaderRow.Cells[3].Text;
                string colcashamt = e.Row.Cells[3].Text;
                grdcollection.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colcashamt == "0.00")
                    {

                    }
                    else
                    {
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colcash + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[3].Text = "<a href=" + hlink2 + ">" + colcashamt + "</a>";
                    }
                }
               // string colcc = grdcollection.HeaderRow.Cells[4].Text;
                string colcchamt = e.Row.Cells[4].Text;
                grdcollection.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colcchamt == "0.00")
                    {

                    }
                    else
                    {
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colcc + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[4].Text = "<a href=" + hlink2 + ">" + colcchamt + "</a>";
                    }
                }
               // string colbank = grdcollection.HeaderRow.Cells[5].Text;
                string colbankhamt = e.Row.Cells[5].Text;
                grdcollection.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colbankhamt == "0.00")
                    {

                    }
                    else
                    {
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colbank + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[5].Text = "<a href=" + hlink2 + ">" + colbankhamt + "</a>";
                    }
                }
                grdcollection.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
               // string colonline = grdcollection.HeaderRow.Cells[6].Text;
                string colonlinehamt = e.Row.Cells[6].Text;
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    //e.Row.Cells[7].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colonlinehamt == "0.00")
                    {

                    }

                    else
                    {
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colonline + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[6].Text = "<a href=" + hlink2 + ">" + colonlinehamt + "</a>";
                    }
                }

                grdcollection.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                // string colonline = grdcollection.HeaderRow.Cells[6].Text;
                string colother = e.Row.Cells[7].Text;
                if (branchname == "Grand Total")
                {
                    e.Row.Cells[7].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    e.Row.Cells[8].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }
                else
                {
                    if (colother == "0.00")
                    {

                    }

                    else
                    {
                        string hlink2 = "javascript:calldayreportbypaymentmode('" + branchid + "','" + colother + "','" + ddlMonth.SelectedValue.ToString() + "','" + ddlYear.SelectedValue.ToString() + "','" + parmbranchname + "')";// "JavaScript:window.open('DailyReport.aspx?from=" + Server.UrlEncode(_date.ToString()) + "&todate=" + Server.UrlEncode(_date.ToString()) + "', true,'width=800,height=600,top=100,left=100,scrollbars=no,directories=no,status=no,toolbar=no,resizable=no');";
                        e.Row.Cells[7].Text = "<a href=" + hlink2 + ">" + colother + "</a>";
                    }
                }
                grdcollection.HeaderRow.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                double total1_cheque = 0;
                double total2_cash = 0;
                double total3_cc = 0;
                double total4_bank = 0;
                double total5_online = 0;
                double total7_other = 0;
                double total6 = 0;
                foreach (GridViewRow gr in grdcollection.Rows)
                {
                    string[] abc_cheque = gr.Cells[2].Text.Split('>');
                    abc_cheque = abc_cheque[1].Split('<');

                    total1_cheque += double.Parse(abc_cheque[0]);
                    string[] abc_cash = gr.Cells[3].Text.Split('>');

                    abc_cash = abc_cash[1].Split('<');
                    total2_cash += double.Parse(abc_cash[0]);

                    string[] abc_cc = gr.Cells[4].Text.Split('>');
                    abc_cc = abc_cc[1].Split('<');
                    total3_cc += double.Parse(abc_cc[0]);

                    string[] abc_bank = gr.Cells[5].Text.Split('>');
                    abc_bank = abc_bank[1].Split('<');
                    total4_bank += double.Parse(abc_bank[0]);

                    string[] abc_online = gr.Cells[6].Text.Split('>');
                    abc_online = abc_online[1].Split('<');
                    total5_online += double.Parse(abc_online[0]);
                    string[] abc_other = gr.Cells[7].Text.Split('>');
                    abc_other = abc_other[1].Split('<');
                    total7_other += double.Parse(abc_other[0]);

                    total6 += double.Parse(gr.Cells[8].Text);

                }
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].Text = total1_cheque.ToString("0.00");
                e.Row.Cells[2].Text = total2_cash.ToString("0.00");
                e.Row.Cells[3].Text = total3_cc.ToString("0.00");
                e.Row.Cells[4].Text = total4_bank.ToString("0.00");
                e.Row.Cells[5].Text = total5_online.ToString("0.00");
                e.Row.Cells[6].Text = total7_other.ToString("0.00");
                e.Row.Cells[7].Text = total6.ToString("0.00");
            }
        }       
       
    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    public string SortExpression
    {
       
        get { return (ViewState["sortExpression"] != null ? ViewState["sortExpression"].ToString() : string.Empty); }
        set { ViewState["sortExpression"] = value; }
    
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
    
    protected void grdcollection_Sorting(object sender, GridViewSortEventArgs e)
    {   
 
            switch (mylevel)
            {
                case 1:
                    if (!string.IsNullOrWhiteSpace(e.SortExpression))
                    {
                        SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                    }
                    BindGrid();
                    break;
                case 2:
                    if (!string.IsNullOrWhiteSpace(e.SortExpression))
                    {
                       
                        SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                       
                    }
                    BindGrid();
                     trarjsted.Visible = false;
                        trbilling.Visible = true;
                    break;
                case 3:
                    if (!string.IsNullOrWhiteSpace(e.SortExpression))
                    {
                        SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                    }
                    BindGrid();
                     trarjsted.Visible = true;
                        trbilling.Visible = false;
                    break;
            }
            
       
       
    }
    private void BillingAmount()
    {
        Clay.Sale.Bll.CreditDetail obj = new Clay.Sale.Bll.CreditDetail();
        int currentmonth = Convert.ToInt32(ddlMonth.SelectedValue);
        int currentYear = Convert.ToInt32(ddlYear.SelectedValue);
        int previousmonth = 0;
        int previousYear = currentYear;
        if (currentmonth == 1)
        {
            previousmonth = 12;
            previousYear = currentYear - 1;
        }
        else
        {
            previousmonth = currentmonth - 1;
        }

        DataSet dsBilling = new DataSet();
        dsBilling = obj.GetBillingAmountByMonthYear(currentmonth, currentYear, previousmonth, previousYear);
        if (dsBilling.Tables[0].Rows.Count > 0)
        {
            lblcurrentmonthBilling.Text = Convert.ToString(dsBilling.Tables[0].Rows[0]["totalAmount"]);
        }
        else
        {
            lblcurrentmonthBilling.Text = "0.00";
        }
        if (dsBilling.Tables[1].Rows.Count > 0)
        {
            lblPreviousmonthBilling.Text = Convert.ToString(dsBilling.Tables[1].Rows[0]["totalAmount"]);
        }
        else
        {
            lblPreviousmonthBilling.Text = "0.00";
        }

        lblcurrentmonthBilling1.Text = lblcurrentmonthBilling.Text;
        lblPreviousmonthBilling1.Text = lblPreviousmonthBilling.Text;
    }
}