using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class CreditControl_Monthly_outstanding : System.Web.UI.Page
{
    string controlname = string.Empty;
    string controltype = string.Empty;
    DataSet ds_all = new DataSet();

    #region Varibles
    decimal _outstanding = 0;
    decimal _collection = 0;
    decimal _yestrday = 0;
    decimal _tildate = 0;
    decimal _pending = 0;
    decimal _per_pending = 0;
    decimal _creditamount = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Convert.ToInt32(Session["UserID"]) > 0))
        {
            Response.Redirect("../Default.aspx", false);
        }
        // checkSession();
        //checkpageright();
        if (!IsPostBack)
        {
            getreport();
        }

    }

    

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }
    public void getreport()
    {
        #region Create Datatable
        System.Data.DataTable dt = new System.Data.DataTable();
        // dt.Columns.Add("Branchid", string.Empty.GetType());
        dt.Columns.Add("Name", string.Empty.GetType());
        dt.Columns.Add("Outstanding", string.Empty.GetType());
        dt.Columns.Add("Collected", string.Empty.GetType());

        dt.Columns.Add("Yesterday_coll", string.Empty.GetType());
        dt.Columns.Add("Till_date", string.Empty.GetType());
        dt.Columns.Add("Pending", string.Empty.GetType());
        dt.Columns.Add("per_Pending", string.Empty.GetType());
        dt.Columns.Add("Creditamount", string.Empty.GetType());
        #endregion
        string month = string.Empty;
        DateTime month_;
        string year = string.Empty;
        string prev_month = string.Empty;
        string yestrdate = string.Empty;
        int empid = 0;
        string employeeName = string.Empty;


        month = DateTime.Now.Month.ToString();
        month_ = DateTime.Now.AddMonths(-1);
        year = DateTime.Now.Year.ToString();
        prev_month = Convert.ToString(month_.Month);
        yestrdate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");


        // lblInvoice.Text = "Please Select Month Also";

        Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
      
        ds_all = cre.GetMonthlyOutstanding(month, year, prev_month, yestrdate);
        if (ds_all.Tables["outstanding"].Rows.Count > 0)
        {
            foreach (DataRow dr in ds_all.Tables["emp"].Rows)
            {
                DataRow dr_ = dt.NewRow();
                empid = Convert.ToInt32(dr["employeeid"]);
                employeeName = dr["employeename"].ToString();

                DataRow[] dr_outstanding = ds_all.Tables["outstanding"].Select("xtype=" + 1 + " and employeeid=" + empid);
                if (dr_outstanding.Length > 0)
                {
                    if (dr_outstanding[0]["xtype"] != DBNull.Value)
                    {
                        _outstanding = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding[0]["amount"])));
                    }
                    else
                    {
                        _outstanding = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                    }
                }
                else
                {
                    _outstanding = 0;
                }

                DataRow[] dr_collection = ds_all.Tables["outstanding"].Select("xtype=" + 2 + " and employeeid=" + empid);
                if (dr_collection.Length > 0)
                {
                    if (dr_collection[0]["xtype"] != DBNull.Value)
                    {
                        _collection = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_collection[0]["amount"])));
                    }
                    else
                    {
                        _collection = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                    }
                }
                else
                {
                    _collection = 0;
                }
                DataRow[] dr_yesterday = ds_all.Tables["outstanding"].Select("xtype=" + 3 + " and employeeid=" + empid);
                if (dr_yesterday.Length > 0)
                {
                    if (dr_yesterday[0]["xtype"] != DBNull.Value)
                    {
                        _yestrday = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_yesterday[0]["amount"])));
                    }
                    else
                    {
                        _yestrday = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                    }
                }
                else
                {
                    _yestrday = 0;
                }
                DataRow[] dr_credit = ds_all.Tables["outstanding"].Select("xtype=" + 4 + " and employeeid=" + empid);
                if (dr_credit.Length > 0)
                {
                    if (dr_credit[0]["xtype"] != DBNull.Value)
                    {
                        _creditamount = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_credit[0]["amount"])));
                    }
                    else
                    {
                        _creditamount = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                    }
                }
                else
                {
                    _creditamount = 0;
                }
                if (_collection != 0 && _outstanding != 0)
                {
                    _tildate = Convert.ToDecimal((_collection * 100) / _outstanding);
                }
                else
                {
                    _tildate = 0;
                }
                _pending = Convert.ToDecimal(_outstanding - (_collection + _creditamount));
                if (_outstanding != 0)
                {
                    _per_pending = Convert.ToDecimal((_pending * 100) / _outstanding);
                }
                else
                {
                    _per_pending = 0;
                }

                dr_["Name"] = employeeName.ToString();
                dr_["Outstanding"] = _outstanding.ToString();
                dr_["Collected"] = _collection.ToString();
                dr_["Yesterday_coll"] = _yestrday.ToString();
                dr_["Till_date"] = ConvertToMoneyFormat(Convert.ToDouble(_tildate)).ToString();
                dr_["Pending"] = _pending.ToString();
                dr_["per_Pending"] = ConvertToMoneyFormat(Convert.ToDouble(_per_pending)).ToString();
                dr_["Creditamount"] = ConvertToMoneyFormat(Convert.ToDouble(_creditamount)).ToString();
                dt.Rows.Add(dr_);
                dt.AcceptChanges();

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            trexport.Visible = true;

        }

    }

    #region Varibles
    decimal _outstandingTotal = 0;
    decimal _collectionTotal = 0;
    decimal _yestrdayTotal = 0;
    decimal _tildateTotal = 0;
    decimal _pendingTotal = 0;
    decimal _per_pendingTotal = 0;
    decimal _totaltilldatef = 0;
    decimal _totalperpendingf = 0;
    decimal _totalpendingf = 0;
    decimal _totalcreditamount = 0;
    #endregion
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbloutstatnding = (Label)e.Row.FindControl("lblOutstanding");
            Label lblcollected = (Label)e.Row.FindControl("lblCollected");
            Label lblyestrday_coll = (Label)e.Row.FindControl("lblYesterday_coll");
            Label lbltilldate = (Label)e.Row.FindControl("lblTill_date");
            Label lblpending = (Label)e.Row.FindControl("lblPending");
            Label lblperPending = (Label)e.Row.FindControl("lblper_Pending");
            Label lblCreditamount = (Label)e.Row.FindControl("lblCreditamount");

            _outstandingTotal += Convert.ToDecimal(lbloutstatnding.Text);
            _collectionTotal += Convert.ToDecimal(lblcollected.Text);
            _yestrdayTotal += Convert.ToDecimal(lblyestrday_coll.Text);
            _tildateTotal += Convert.ToDecimal(lbltilldate.Text);
            _pendingTotal += Convert.ToDecimal(lblpending.Text);
            _per_pendingTotal += Convert.ToDecimal(lblperPending.Text);
            _totalcreditamount += Convert.ToDecimal(lblCreditamount.Text);

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalOutstanding = (Label)e.Row.FindControl("lblTotalOutstanding");
            Label lblTotalCollected = (Label)e.Row.FindControl("lblTotalCollected");
            Label lblTotalYesterday_coll = (Label)e.Row.FindControl("lblTotalYesterday_coll");
            Label lblTotalTill_date = (Label)e.Row.FindControl("lblTotalTill_date");
            Label lblTotalPending = (Label)e.Row.FindControl("lblTotalPending");
            Label lblTotalper_Pending = (Label)e.Row.FindControl("lblTotalper_Pending");
            Label lblTotalCreditamount = (Label)e.Row.FindControl("lblTotalCreditamount");

            lblTotalOutstanding.Text = _outstandingTotal.ToString();
            lblTotalCollected.Text = _collectionTotal.ToString();
            lblTotalYesterday_coll.Text = _yestrdayTotal.ToString();
            if (_outstandingTotal != 0 && _collectionTotal != 0)
            {
                _totaltilldatef = Convert.ToDecimal((_collectionTotal * 100 / _outstandingTotal));
                lblTotalTill_date.Text = ConvertToMoneyFormat(Convert.ToDouble(_totaltilldatef)).ToString();
            }
            else
            {
                lblTotalTill_date.Text = "0.00";
            }
            _totalpendingf = Convert.ToDecimal(_outstandingTotal - (_collectionTotal + _totalcreditamount));
            lblTotalPending.Text = _totalpendingf.ToString();
            lblTotalCreditamount.Text = _totalcreditamount.ToString();
            if (_outstandingTotal != 0)
            {
                _totalperpendingf = Convert.ToDecimal((_totalpendingf * 100) / _outstandingTotal);
                lblTotalper_Pending.Text = ConvertToMoneyFormat(Convert.ToDouble(_totalperpendingf)).ToString();
            }
            else
            {
                lblTotalper_Pending.Text = "0.00";
            }
        }
    }
    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter str = new StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
        GridView1.AllowPaging = false;
        //BindVehicleGrid();
        GridView1.RenderControl(HtmlTextWriter);
        Response.Write(str.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}