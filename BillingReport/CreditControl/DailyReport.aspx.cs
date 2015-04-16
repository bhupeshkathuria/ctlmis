using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;

public partial class CreditControl_DailyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void btnAddField_Click(object sender, EventArgs e)
    {
        string fromdate = string.Empty;
        string todate = string.Empty;
        DataSet ds_all = new DataSet();
        int branchid = 0;
        string branchname = string.Empty;
        string cheque = string.Empty;
        string cash = string.Empty;
        string cc = string.Empty;
        string bank = string.Empty;
        string online = string.Empty;
        string Other = string.Empty;
        decimal totalbranch = 0;
        decimal totalcheque = 0;
        decimal totalcash = 0;
        decimal totalcc = 0;
        decimal totalbank = 0;
        decimal totalonline = 0;
        lblInvoice.Text = "";

        if (!string.IsNullOrEmpty(txtfromdate.Text) && !string.IsNullOrEmpty(txttodate.Text))
        {
            BillingAmount();
            Clay.Sale.Bll.CreditDetail objcredit = new Clay.Sale.Bll.CreditDetail();
            ds_all = objcredit.Get_Daily_Credit_Report_Branch(txtfromdate.Text.Trim(), txttodate.Text.Trim());


            #region Create Datatable
            System.Data.DataTable dt = new System.Data.DataTable();
            // dt.Columns.Add("Branchid", string.Empty.GetType());
            dt.Columns.Add("Branch", string.Empty.GetType());
            dt.Columns.Add("ByCheque", string.Empty.GetType());
            dt.Columns.Add("ByCash", string.Empty.GetType());

            dt.Columns.Add("ByCreditCard", string.Empty.GetType());
            dt.Columns.Add("ByBank", string.Empty.GetType());
            dt.Columns.Add("ByOnline", string.Empty.GetType());
            dt.Columns.Add("Other", string.Empty.GetType());
            dt.Columns.Add("Total", string.Empty.GetType());

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

                #region None
                DataRow[] dr_none = ds_all.Tables["None"].Select("branchid=" + branchid);
                if (dr_none.Length > 0)
                {
                    if (dr_none[0]["other"] != DBNull.Value)
                    {
                        Other = Convert.ToString(dr_none[0]["other"]);
                        totalbranch += Convert.ToDecimal(dr_none[0]["other"]);
                        //    totalonline += Convert.ToDecimal(dr_online[0]["online_amt"]);
                    }
                    else
                    {
                        Other = "0.00";
                        totalbranch += Convert.ToDecimal(Other);
                    }
                }
                else
                {
                    Other = "0.00";
                    totalbranch += Convert.ToDecimal(Other);
                }

                #endregion


                DataRow dr1 = dt.NewRow();
                dr1["Branch"] = branchname.ToString();
                dr1["ByCheque"] = cheque.ToString();
                dr1["ByCash"] = cash.ToString();
                dr1["ByCreditCard"] = cc.ToString();
                dr1["ByBank"] = bank.ToString();
                dr1["ByOnline"] = online.ToString();
                dr1["Other"] = Other.ToString();
                dr1["Total"] = Convert.ToString(totalbranch);
                dt.Rows.Add(dr1);
                dt.AcceptChanges();
                totalbranch = 0;
                i++;

            }
            //DataRow drlast = dt.NewRow();
            //drlast["Branch"] = "Grand Total";
            //drlast["ByCheque"] = totalcheque.ToString();
            //drlast["ByCash"] = totalcash.ToString();
            //drlast["ByCreditCard"] = totalcc.ToString();
            //drlast["ByBank"] = totalbank.ToString();
            //drlast["ByOnline"] = totalonline.ToString();
            ////  dr1["Total"] = Convert.ToString(totalbranch);
            //dt.Rows.Add(drlast);
            //dt.AcceptChanges();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            AdjucementReport(0);
            imgexport.Visible = true;
        }
        else
        {
            lblInvoice.Text = "Please enter date";
            GridView1.DataSource = null;
            GridView1.DataBind();
            imgexport.Visible = false;
        }
    }

    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ExportToExcel.ExportToExcelGridView(GridView1);

        }
        catch (Exception ex)
        {
            ex = null;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    decimal totalcheque = 0;
    decimal totalcash = 0;
    decimal credit = 0;
    decimal bank = 0;
    decimal online = 0;
    decimal other = 0;
    decimal alltotal;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblcheque = (Label)e.Row.FindControl("lblByCheque");
            Label lblByCash = (Label)e.Row.FindControl("lblByCash");
            Label lblByCreditCard = (Label)e.Row.FindControl("lblByCreditCard");
            Label lblByBank = (Label)e.Row.FindControl("lblByBank");
            Label lblByOnline = (Label)e.Row.FindControl("lblByOnline");
            Label lblother = (Label)e.Row.FindControl("lblother");
            Label lblallTotal = (Label)e.Row.FindControl("lblTotal");
            totalcheque += Convert.ToDecimal(lblcheque.Text);
            totalcash += Convert.ToDecimal(lblByCash.Text);
            credit += Convert.ToDecimal(lblByCreditCard.Text);
            bank += Convert.ToDecimal(lblByBank.Text);
            online += Convert.ToDecimal(lblByOnline.Text);
            other += Convert.ToDecimal(lblother.Text);
            if (!string.IsNullOrEmpty(lblallTotal.Text))
            {
                alltotal += Convert.ToDecimal(lblallTotal.Text);
            }
            else
            {
                alltotal += 0;
            }
            //   alltotal += Convert.ToDecimal(lblallTotal.Text);

            // total += price;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalCheque = (Label)e.Row.FindControl("lblTotalCheque");
            Label lblTotalCash = (Label)e.Row.FindControl("lblTotalCash");
            Label lblTotalcredit = (Label)e.Row.FindControl("lblTotalcredit");
            Label lblTotalbank = (Label)e.Row.FindControl("lblTotalbank");
            Label lblTotalonline = (Label)e.Row.FindControl("lblTotalonline");
            Label lblTotalother = (Label)e.Row.FindControl("lblTotalother");
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");

            lblTotalCheque.Text = totalcheque.ToString();
            lblTotalCash.Text = totalcash.ToString();
            lblTotalcredit.Text = credit.ToString();
            lblTotalbank.Text = bank.ToString();
            lblTotalonline.Text = online.ToString();
            lblTotalother.Text = other.ToString();
            lblTotal.Text = alltotal.ToString();


        }
    }
    private void AdjucementReport(int BranchID)
    {
        try
        {

        string branchname = string.Empty;
        decimal _footertotalbranch = 0;
      
        Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
        DataSet ds_all = new DataSet();
        ds_all = cre.Get_Daily_Credit_Report_Branch_new(txtfromdate.Text, txttodate.Text, BranchID);
        if (ds_all.Tables[0].Rows.Count > 0)
        {
            object value = ds_all.Tables[0].Rows[0]["totalamt"];
            if (value == DBNull.Value)
            {
                _footertotalbranch += Convert.ToDecimal("0.00");
            }
            else
            {
                _footertotalbranch = Convert.ToDecimal(ds_all.Tables[0].Rows[0]["totalamt"]);
            }
           
        }
        decimal _totalamt = 0;
        decimal amountdiff = 0;

        DataSet dsrpt = new DataSet();
        dsrpt = cre.GetCollection_rpt_Monthly_New(txtfromdate.Text, txttodate.Text, "month");

        if (dsrpt.Tables["month"].Rows.Count > 0)
        {
            foreach (DataRow _dr in dsrpt.Tables["month"].Rows)
            {
                object value = _dr["Amount"];
                if (value == DBNull.Value)
                {
                    _totalamt += Convert.ToDecimal("0.00");
                }
                else
                {
                    _totalamt += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
                }
            }
        }
        lbltotalcollection.Text = _totalamt.ToString();
        lbltotalarjusted.Text = _footertotalbranch.ToString();
        amountdiff = _totalamt - _footertotalbranch;
        trAdjucement.Visible = true;
        lblunarjsustedamt.Text = amountdiff.ToString();
        }
        catch (Exception ex)
        {

            ex = null;
        }
    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }
    private void BillingAmount()
    {
       Clay.Sale.Bll.CreditDetail obj = new Clay.Sale.Bll.CreditDetail();
       DateTime dt = DateTime.Parse(txtfromdate.Text);
       //string smonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month);
       //int i = DateTime.ParseExact(smonth, "MMMM", CultureInfo.CurrentCulture).Month;
     
       int currentmonth = dt.Month;
       int currentYear = dt.Year;
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
    }
}