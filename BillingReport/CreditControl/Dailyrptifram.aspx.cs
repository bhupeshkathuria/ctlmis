using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CreditControl_Dailyrptifram : System.Web.UI.Page
{
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["from"] != null)
            {

                DateTime _from = Convert.ToDateTime(Request.QueryString["from"]);
                DateTime _todate = Convert.ToDateTime(Request.QueryString["todate"]);
                txtfromdate.Text = _from.Year + "-" + _from.Month + "-" + _from.Day;
                txttodate.Text = _todate.Year + "-" + _todate.Month + "-" + _todate.Day;
                getreport();
                AdjucementReport(0);
                //btnsearch.Enabled = false;

            }
        }
    }
    protected void btnAddField_Click(object sender, EventArgs e)
    {
        getreport();
    }
    public void getreport()
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
         string other = string.Empty;
        decimal totalbranch = 0;
        decimal totalcheque = 0;
        decimal totalcash = 0;
        decimal totalcc = 0;
        decimal totalbank = 0;
        decimal totalonline = 0;
        decimal totalother = 0;
        lblInvoice.Text = "";

        if (!string.IsNullOrEmpty(txtfromdate.Text) && !string.IsNullOrEmpty(txttodate.Text))
        {

            Clay.Sale.Bll.CreditDetail objcredit = new Clay.Sale.Bll.CreditDetail();
            ds_all = objcredit.Get_Daily_Credit_Report_Branch(txtfromdate.Text.Trim(), txttodate.Text.Trim());


            #region Create Datatable
            System.Data.DataTable dt = new System.Data.DataTable();
            // dt.Columns.Add("Branchid", string.Empty.GetType());
            dt.Columns.Add("Branch", string.Empty.GetType());
            dt.Columns.Add("ByCheque", typeof(System.Double));
            dt.Columns.Add("ByCash", typeof(System.Double));

            dt.Columns.Add("ByCreditCard", typeof(System.Double));
            dt.Columns.Add("ByBank", typeof(System.Double));
            dt.Columns.Add("ByOnline", typeof(System.Double));
             dt.Columns.Add("Other", typeof(System.Double));
            dt.Columns.Add("Total", typeof(System.Double));

            decimal _footertotalbranch = 0;
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

                #region ByOther
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

                DataRow dr1 = dt.NewRow();
                dr1["Branch"] = branchname.ToString();
                dr1["ByCheque"] = cheque.ToString();
                dr1["ByCash"] = cash.ToString();
                dr1["ByCreditCard"] = cc.ToString();
                dr1["ByBank"] = bank.ToString();
                dr1["ByOnline"] = online.ToString();
                dr1["Other"] = other.ToString();
                dr1["Total"] = Convert.ToString(totalbranch);
                _footertotalbranch += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(totalbranch)));
                dt.Rows.Add(dr1);
                dt.AcceptChanges();
                totalbranch = 0;
                i++;

            }
          

          //  hdadjuctmentamt.Value = Convert.ToString(_footertotalbranch);
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
            DataView dv = dt.DefaultView;
            dv.Sort = SortExpression;
            GridView1.DataSource = dv;
            GridView1.DataBind();
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
            string colchequeamt = e.Row.Cells[1].Text;
            GridView1.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

            string colcashamt = e.Row.Cells[2].Text;
            GridView1.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;

            string colcchamt = e.Row.Cells[3].Text;
            GridView1.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

            string colbankhamt = e.Row.Cells[4].Text;
            GridView1.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

            string colonlinehamt = e.Row.Cells[5].Text;
            GridView1.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            string colotherhamt = e.Row.Cells[6].Text;
            GridView1.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            GridView1.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            //Label lblcheque = (Label)e.Row.FindControl("lblByCheque");
            //Label lblByCash = (Label)e.Row.FindControl("lblByCash");
            //Label lblByCreditCard = (Label)e.Row.FindControl("lblByCreditCard");
            //Label lblByBank = (Label)e.Row.FindControl("lblByBank");
            //Label lblByOnline = (Label)e.Row.FindControl("lblByOnline");
            //Label lblallTotal = (Label)e.Row.FindControl("lblTotal");
            //totalcheque += Convert.ToDecimal(lblcheque.Text);
            //totalcash += Convert.ToDecimal(lblByCash.Text);
            //credit += Convert.ToDecimal(lblByCreditCard.Text);
            //bank += Convert.ToDecimal(lblByBank.Text);
            //online += Convert.ToDecimal(lblByOnline.Text);
            //if (!string.IsNullOrEmpty(lblallTotal.Text))
            //{
            //    alltotal += Convert.ToDecimal(lblallTotal.Text);
            //}
            //else
            //{
            //    alltotal += 0;
            //}
            //   alltotal += Convert.ToDecimal(lblallTotal.Text);

            // total += price;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lblTotalCheque = (Label)e.Row.FindControl("lblTotalCheque");
            //Label lblTotalCash = (Label)e.Row.FindControl("lblTotalCash");
            //Label lblTotalcredit = (Label)e.Row.FindControl("lblTotalcredit");
            //Label lblTotalbank = (Label)e.Row.FindControl("lblTotalbank");
            //Label lblTotalonline = (Label)e.Row.FindControl("lblTotalonline");
            //Label lblTotal = (Label)e.Row.FindControl("lblTotal");

            //lblTotalCheque.Text = totalcheque.ToString();
            //lblTotalCash.Text = totalcash.ToString();
            //lblTotalcredit.Text = credit.ToString();
            //lblTotalbank.Text = bank.ToString();
            //lblTotalonline.Text = online.ToString();
            //lblTotal.Text = alltotal.ToString();

            double total1_cheque = 0;
            double total2_cash = 0;
            double total3_cc = 0;
            double total4_bank = 0;
            double total5_online = 0;
            double total7_other = 0;
            double total6 = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                total1_cheque += double.Parse(gr.Cells[1].Text);
                
                total2_cash += double.Parse(gr.Cells[2].Text);


                total3_cc += double.Parse(gr.Cells[3].Text);

                
                total4_bank += double.Parse(gr.Cells[4].Text);

                
                total5_online += double.Parse(gr.Cells[5].Text);
                total7_other += double.Parse(gr.Cells[6].Text);

                total6 += double.Parse(gr.Cells[7].Text);

            }
            e.Row.Cells[0].Text = "Grand Total";
            e.Row.Cells[1].Text = total1_cheque.ToString("0.00");
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

            e.Row.Cells[2].Text = total2_cash.ToString("0.00");
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].Text = total3_cc.ToString("0.00");
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].Text = total4_bank.ToString("0.00");
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[5].Text = total5_online.ToString("0.00");
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[6].Text = total7_other.ToString("0.00");
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[7].Text = total6.ToString("0.00");
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

            


        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.SortExpression))
        {
            SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);

            //string reptype = string.Empty;
            //reptype = ddlRepType.SelectedValue.ToString();
            //DisplayReport(reptype);
            getreport();
        }
        //GridView1.DataSource = getreport();
        //GridView1.DataBind();
        //DataTable dtSortTable = GridView1.DataSource as DataTable;

        //if (dtSortTable != null)
        //{
        //    DataView dvSortedView = new DataView(dtSortTable);

        //    dvSortedView.Sort = e.SortExpression + " " + getSortDirectionString(e.SortDirection);

        //    GridView1.DataSource = dvSortedView;
        //    GridView1.DataBind();
        //}

        //string sortingDirection = string.Empty;

        //if (dir == SortDirection.Ascending)
        //{

        //    dir = SortDirection.Descending;

        //    sortingDirection = "Desc";

        //}

        //else
        //{

        //    dir = SortDirection.Ascending;

        //    sortingDirection = "Asc";

        //}


        //DataTable dtSortTable = GridView1.DataSource as DataTable;
        //DataView sortedView = new DataView(dtSortTable);

        //sortedView.Sort = e.SortExpression + " " + sortingDirection;

        //GridView1.DataSource = sortedView;

        //GridView1.DataBind();
    }
   // private string getSortDirectionString(SortDirection sortDirection)
   // {
        //string newSortDirection = String.Empty;
        //if (sortDirection == SortDirection.Ascending)
        //{
        //    newSortDirection = "ASC";
        //}
        //else
        //{
        //    newSortDirection = "DESC";
        //}
        //return newSortDirection;


  //  }

    //public SortDirection dir
    //{
    //    get
    //    {

    //        if (ViewState["dirState"] == null)
    //        {

    //            ViewState["dirState"] = SortDirection.Ascending;

    //        }

    //        return (SortDirection)ViewState["dirState"];

    //    }

    //    set
    //    {

    //        ViewState["dirState"] = value;

    //    }

    //}

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

    private void AdjucementReport(int BranchID)
    {
        try
        {

        
        decimal _footertotalbranch = 0;
        string branchname = string.Empty;
      
        Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();       
       
        decimal _totalamt = 0;
        decimal amountdiff = 0;
        DataSet ds_all = new DataSet();

        ds_all = cre.Get_Daily_Credit_Report_Branch_new(txttodate.Text, txttodate.Text, BranchID);
        if (ds_all.Tables[0].Rows.Count > 0)
        {
            _footertotalbranch = Convert.ToDecimal(ds_all.Tables[0].Rows[0]["totalamt"]);
        }


        DataSet dsrpt = new DataSet();
        dsrpt = cre.GetCollection_rpt_Monthly_New(txttodate.Text, txttodate.Text,"date");

        if (dsrpt.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in dsrpt.Tables[0].Rows)
            {
                _totalamt += Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(_dr["Amount"])));
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

}