using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Threading;
public partial class User_CreditControl_Collection_Agging2 : System.Web.UI.Page
{

    static bool _flag = false;
    static int mylevel = 0;
    static int _month = 0;
    static int _year = 0;
   
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
        try
        {
            if (Request.QueryString["level"] != null)
            {
                mylevel = Convert.ToInt32(Request.QueryString["level"]);
            }
            else
            {
                mylevel = 0;
            }
            lblmess.Visible = false;
            trbrname.Visible = false;
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("../Default.aspx", false);
            }
            // System.Threading.Thread.Sleep(2000);
            if (!IsPostBack)
            {                
                loadYear();               
                //string script = "$(document).ready(function () { $('[id*=Submit]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                if (mylevel == 0)
                {
                    ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    getreport(0, DateTime.Now.Month, DateTime.Now.Year);
                    AdjucementReport(0);
                }
                if (mylevel == 1)
                {
                     
                    ddlMonth.SelectedValue = Request.QueryString["month"].ToString();
                    ddlYear.SelectedValue = Request.QueryString["year"].ToString();
                    getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["month"]), Convert.ToInt32(Request.QueryString["year"]));
                  //  AdjucementReport(Convert.ToInt32(Request.QueryString["branchid"]));
                }
                if (mylevel == 2)
                {
                    ddlMonth.SelectedValue = Request.QueryString["month"].ToString();
                    ddlYear.SelectedValue = Request.QueryString["year"].ToString();
                    getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]), Convert.ToInt32(Request.QueryString["month"]), Convert.ToInt32(Request.QueryString["year"]));
                }
                BillingAmount();
            }

        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    private void getreport_Customerwise(int brid, int month, int year)
    {
        try
        {
            #region Create Datatable
            System.Data.DataTable dt2 = new System.Data.DataTable();


            //dt2.Columns.Add("Name", typeof(string));
            //dt2.Columns.Add("0-60", typeof(System.Double));
            //dt2.Columns.Add("60-90", typeof(System.Double));

            //dt2.Columns.Add("90-180", typeof(System.Double));
            //dt2.Columns.Add("Above-180", typeof(System.Double));
            //dt2.Columns.Add("id", string.Empty.GetType());
            //dt2.Columns.Add("brid", string.Empty.GetType());
            //dt2.Columns.Add("Total", typeof(System.Double));
            //dt2.Columns.Add("month", string.Empty.GetType());
            //dt2.Columns.Add("year", string.Empty.GetType());



            #endregion
            _flag = false;
            #region Varible
            string customername = string.Empty;
            int customerid = 0;
            int branchid = 0;
            decimal _outstanding1 = 0;
            decimal _outstanding2 = 0;
            decimal _outstanding3 = 0;
            decimal _outstanding4 = 0;
            int oldcustid = 0;
            decimal _total = 0;
            #endregion
            Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
            DataSet ds_aggging = new DataSet();
            dt2 = cre.Get_Collection_Agging_New(brid, month, year).Tables[0];

            if (dt2.Rows.Count > 0)
            {
                _month = month;
                _year = year;

                //dt2 = ds_aggging.Tables["customerwise"];
                DataView dv2 = dt2.DefaultView;

                foreach (DataColumn drcheck in dt2.Columns)
                {
                    if (SortExpression.ToString().Contains(drcheck.ToString()))
                    {
                        dv2.Sort = SortExpression;
                    }
                }
                lblbr.Text = "Branch: ";
                trbrname.Visible = true;
                lblbranchname.Text = Request.QueryString["name"].ToString();
                lblbranchname.Text = HttpUtility.UrlDecode(lblbranchname.Text);
                grdagging_2.DataSource = dv2;
                grdagging_2.DataBind();
                trexport.Visible = true;
                for (int i = 0; i < grdagging_2.Rows.Count; i++)
                {
                    grdagging_2.Rows[i].Cells[9].Visible = false;
                    grdagging_2.HeaderRow.Cells[9].Visible = false;
                    grdagging_2.Rows[i].Cells[11].Visible = false;
                    grdagging_2.HeaderRow.Cells[11].Visible = false;

                    grdagging_2.Rows[i].Cells[12].Visible = false;
                    grdagging_2.HeaderRow.Cells[12].Visible = false;
                    grdagging_2.Rows[i].Cells[13].Visible = false;
                    grdagging_2.HeaderRow.Cells[13].Visible = false;
                }
            }
            else
            {
                grdagging_2.DataSource = null;
                grdagging_2.DataBind();
                trexport.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    private void getreport_CustomerwiseDeatil(int brid, int custid, int month, int year)
    {
        try
        {

            _flag = false;
            #region Varible
            string customername = string.Empty;
            int customerid = 0;
            int branchid = 0;
            decimal _outstanding1 = 0;
            decimal _outstanding2 = 0;
            decimal _outstanding3 = 0;
            decimal _outstanding4 = 0;
            int oldcustid = 0;
            #endregion

            Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
            DataSet ds_aggging = new DataSet();
            ds_aggging = cre.Get_collection_Agging_customer_Detail(brid, custid, month, year);

            if (ds_aggging.Tables["customerDetail"].Rows.Count > 0)
            {
                _month = month;
                _year = year;
                //grdagging_2.AllowPaging = true;
                //grdagging_2.PageSize = 50;
                DataView dv3 = ds_aggging.Tables[0].DefaultView;

                foreach (DataColumn drcheck in ds_aggging.Tables[0].Columns)
                {
                    if (SortExpression.ToString().Contains(drcheck.ToString()))
                    {
                        dv3.Sort = SortExpression;
                    }
                }
                trbrname.Visible = true;
                lblbr.Text = "Customer: ";
                lblbranchname.Text = ds_aggging.Tables[0].Rows[0]["customername"].ToString();
                grdagging_2.DataSource = dv3;
                grdagging_2.DataBind();
                trexport.Visible = true;
                for (int i = 0; i < grdagging_2.Rows.Count; i++)
                {
                    grdagging_2.Rows[i].Cells[5].Visible = false;
                    grdagging_2.HeaderRow.Cells[5].Visible = false;
                    grdagging_2.Rows[i].Cells[6].Visible = false;
                    grdagging_2.HeaderRow.Cells[6].Visible = false;
                }
            }
            else
            {
                grdagging_2.DataSource = null;
                grdagging_2.DataBind();
                trexport.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    protected void imgexport_Click(object sender, ImageClickEventArgs e)
    {
        if (grdagging_2.Rows.Count > 0)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.xls";
            //StringWriter str = new StringWriter();
            //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
            //grdagging_2.AllowPaging = false;
            //grdagging_2.RenderControl(HtmlTextWriter);
            //Response.Write(str.ToString());
            //Response.End();
            try
            {
                System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                grdagging_2.GridLines = GridLines.Both;
                grdagging_2.HeaderStyle.Font.Bold = true;
                grdagging_2.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Flush();
                //Response.End();
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                ex = null;
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    private void getreport(int brid, int month, int year)
    {
        try
        {
            #region Create Datatable
            System.Data.DataTable dt = new System.Data.DataTable();

            //dt.Columns.Add("Name", typeof(string));
            //dt.Columns.Add("0-60", typeof(System.Double));
            //dt.Columns.Add("60-90", typeof(System.Double));

            //dt.Columns.Add("90-180", typeof(System.Double));
            //dt.Columns.Add("Above-180", typeof(System.Double));
            //dt.Columns.Add("id", string.Empty.GetType());
            //dt.Columns.Add("Total", typeof(System.Double));
            //dt.Columns.Add("month", string.Empty.GetType());
            //dt.Columns.Add("year", string.Empty.GetType());




            #endregion

            #region Varible
            string branchname = string.Empty;
            int branchid = 0;
            decimal _outstanding1 = 0;
            decimal _outstanding2 = 0;
            decimal _outstanding3 = 0;
            decimal _outstanding4 = 0;
            decimal _total = 0;
            #endregion

            Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
            DataSet ds_aggging = new DataSet();
            dt = cre.Get_Collection_Agging_New(brid, month, year).Tables[0];

            if (dt.Rows.Count > 0)
            {
                _flag = true;
                _month = month;
                _year = year;

                // dt = ds_aggging.Tables["Outstanding1"];

                DataView dv = dt.DefaultView;

                foreach (DataColumn drcheck in dt.Columns)
                {

                    if (SortExpression.ToString().Contains(drcheck.ToString()))
                    {
                        dv.Sort = SortExpression;
                    }

                }
                grdagging_2.DataSource = null;
                grdagging_2.DataBind();
                grdagging_2.DataSource = dv;
                grdagging_2.DataBind();
                trexport.Visible = true;
                for (int i = 0; i < grdagging_2.Rows.Count; i++)
                {
                    grdagging_2.Rows[i].Cells[9].Visible = false;
                    grdagging_2.Rows[i].Cells[11].Visible = false;
                    grdagging_2.Rows[i].Cells[12].Visible = false;

                    grdagging_2.HeaderRow.Cells[9].Visible = false;
                    grdagging_2.HeaderRow.Cells[11].Visible = false;
                    grdagging_2.HeaderRow.Cells[12].Visible = false;
                }
            }
            else
            {
                grdagging_2.DataSource = null;
                grdagging_2.DataBind();
                trexport.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    decimal Outstanding1 = 0;
    decimal Outstanding2 = 0;
    decimal Outstanding3 = 0;
    decimal Outstanding4 = 0;
    decimal Outstanding5 = 0;
    decimal Outstanding6 = 0;
    decimal Outstanding7 = 0;
    decimal Outstanding8 = 0;
    decimal TotalAmt = 0;
    string col1 = string.Empty;
    string col2 = string.Empty;
    string col3 = string.Empty;
    string col4 = string.Empty;
    string col5 = string.Empty;
    string cols6 = string.Empty;

    protected void grdagging_2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // System.Threading.Thread.Sleep(500); 


        #region Branch Wise
        if (mylevel == 0)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //LinkButton LnkHeaderText_colcheque = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                //col1 = LnkHeaderText_colcheque.Text;
                //LinkButton LnkHeaderText_colcash = e.Row.Cells[2].Controls[0] as LinkButton;
                //col2 = LnkHeaderText_colcash.Text;
                //LinkButton LnkHeaderText_colcc = e.Row.Cells[3].Controls[0] as LinkButton;
                //col3 = LnkHeaderText_colcc.Text;
                //LinkButton LnkHeaderText_colbank = e.Row.Cells[4].Controls[0] as LinkButton;
                //col4 = LnkHeaderText_colbank.Text;
                //LinkButton LnkHeaderText_total = e.Row.Cells[5].Controls[0] as LinkButton;
                //col5 = LnkHeaderText_total.Text;

                Outstanding1 = 0;
                Outstanding2 = 0;
                Outstanding3 = 0;
                Outstanding4 = 0;
                Outstanding5 = 0;
                Outstanding6 = 0;
                Outstanding7 = 0;
                Outstanding8 = 0;               
                TotalAmt = 0;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string branchid = e.Row.Cells[9].Text;
                string monthid = e.Row.Cells[11].Text;
                string year = e.Row.Cells[12].Text;
                string branchname = e.Row.Cells[0].Text;
                string parmbranchname = string.Empty;

                //string hlink2 = "javascript:callreport('" + branchid + "','1')";
                parmbranchname = HttpUtility.UrlEncode(branchname);
                string hlink2 = "javascript:callreport('" + branchid + "','" + parmbranchname + "','" + monthid + "','" + year + "','1')";
                //  string hlink2 = getreport_Customerwise2(Convert.ToInt32(branchid), Convert.ToInt32(monthid), Convert.ToInt32(year));
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + branchname + "</a>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
               
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

                Outstanding1 += decimal.Parse(e.Row.Cells[1].Text);
                Outstanding2 += decimal.Parse(e.Row.Cells[2].Text);
                Outstanding3 += decimal.Parse(e.Row.Cells[3].Text);
                Outstanding4 += decimal.Parse(e.Row.Cells[4].Text);
                Outstanding5 += decimal.Parse(e.Row.Cells[5].Text);
                Outstanding6 += decimal.Parse(e.Row.Cells[6].Text);
                Outstanding7 += decimal.Parse(e.Row.Cells[7].Text);
                Outstanding8 += decimal.Parse(e.Row.Cells[8].Text);
               

                TotalAmt += decimal.Parse(e.Row.Cells[10].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;  // this column[5] for branch id but we show total in this col

                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;               
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[1].Text = Outstanding1.ToString();
                e.Row.Cells[2].Text = Outstanding2.ToString();
                e.Row.Cells[3].Text = Outstanding3.ToString();
                e.Row.Cells[4].Text = Outstanding4.ToString();

                e.Row.Cells[5].Text = Outstanding5.ToString();
                e.Row.Cells[6].Text = Outstanding6.ToString();
                e.Row.Cells[7].Text = Outstanding7.ToString();
                e.Row.Cells[8].Text = Outstanding8.ToString();
                
               
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[10].Text = TotalAmt.ToString(); // this column[5] for branch id but we show total in this col

            }
        }
        #endregion


        #region Customer Wise
        if (mylevel == 1)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //LinkButton LnkHeaderText_1 = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                //col1 = LnkHeaderText_1.Text;
                //LinkButton LnkHeaderText_2 = e.Row.Cells[2].Controls[0] as LinkButton;
                //col2 = LnkHeaderText_2.Text;
                //LinkButton LnkHeaderText_3 = e.Row.Cells[3].Controls[0] as LinkButton;
                //col3 = LnkHeaderText_3.Text;
                //LinkButton LnkHeaderText_4 = e.Row.Cells[4].Controls[0] as LinkButton;
                //col4 = LnkHeaderText_4.Text;

                Outstanding1 = 0;
                Outstanding2 = 0;
                Outstanding3 = 0;
                Outstanding4 = 0;
                Outstanding5 = 0;
                Outstanding6 = 0;
                Outstanding7 = 0;
                Outstanding8 = 0;
              
                TotalAmt = 0;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customername = e.Row.Cells[0].Text;
                string monthid = e.Row.Cells[11].Text;
                string yearid = e.Row.Cells[12].Text;
                string customerid = e.Row.Cells[13].Text;
                string branchid = e.Row.Cells[9].Text;
                string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + customerid + "','" + monthid + "','" + yearid + "','2')";
                //string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + branchname + "','1')";
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + customername + "</a>";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

                Outstanding1 += decimal.Parse(e.Row.Cells[1].Text);
                Outstanding2 += decimal.Parse(e.Row.Cells[2].Text);
                Outstanding3 += decimal.Parse(e.Row.Cells[3].Text);
                Outstanding4 += decimal.Parse(e.Row.Cells[4].Text);
                Outstanding5 += decimal.Parse(e.Row.Cells[5].Text);
                Outstanding6 += decimal.Parse(e.Row.Cells[6].Text);
                Outstanding7 += decimal.Parse(e.Row.Cells[7].Text);
                Outstanding8 += decimal.Parse(e.Row.Cells[8].Text);
              
                TotalAmt += decimal.Parse(e.Row.Cells[10].Text);


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;


                e.Row.Cells[1].Text = Outstanding1.ToString();
                e.Row.Cells[2].Text = Outstanding2.ToString();
                e.Row.Cells[3].Text = Outstanding3.ToString();
                e.Row.Cells[4].Text = Outstanding4.ToString();

                e.Row.Cells[5].Text = Outstanding5.ToString();
                e.Row.Cells[6].Text = Outstanding6.ToString();
                e.Row.Cells[7].Text = Outstanding7.ToString();
                e.Row.Cells[8].Text = Outstanding8.ToString();
               
                e.Row.Cells[9].Visible = false;
               
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[10].Text = TotalAmt.ToString();
            }
        }
        #endregion

        #region Customer Wise Detail
        if (mylevel == 2)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText_invno = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                col1 = LnkHeaderText_invno.Text;
                LinkButton LnkHeaderText_date = e.Row.Cells[2].Controls[0] as LinkButton;
                col2 = LnkHeaderText_date.Text;
                LinkButton LnkHeaderText_amt = e.Row.Cells[3].Controls[0] as LinkButton;
                col3 = LnkHeaderText_amt.Text;
                LinkButton LnkHeaderText_recamt = e.Row.Cells[4].Controls[0] as LinkButton;
                col4 = LnkHeaderText_recamt.Text;
                LinkButton LnkHeaderText_cramt = e.Row.Cells[5].Controls[0] as LinkButton;
                col4 = LnkHeaderText_cramt.Text;
                LinkButton LnkHeaderText_crpayable = e.Row.Cells[7].Controls[0] as LinkButton;
                col4 = LnkHeaderText_crpayable.Text;
                Outstanding1 = 0;
                Outstanding2 = 0;
                Outstanding3 = 0;
                Outstanding4 = 0;
                Outstanding7 = 0;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customername = e.Row.Cells[0].Text;
                string customerid = e.Row.Cells[5].Text;
                string branchid = e.Row.Cells[6].Text;
                //  string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + customerid + "','2')";
                //string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + branchname + "','1')";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                grdagging_2.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                // Label lblOutstanding1 = (Label)gr.FindControl("lblOutstanding1");
                Outstanding1 += decimal.Parse(e.Row.Cells[2].Text);

                // Label lblOutstanding2 = (Label)gr.FindControl("lblOutstanding2");
                Outstanding2 += decimal.Parse(e.Row.Cells[3].Text);

                //Label lblOutstanding3 = (Label)gr.FindControl("lblOutstanding3");
                Outstanding3 += decimal.Parse(e.Row.Cells[4].Text);

                Outstanding7 += decimal.Parse(e.Row.Cells[7].Text);
                //  Label lblOutstanding4 = (Label)gr.FindControl("lblOutstanding4");
                //Outstanding4 += decimal.Parse(e.Row.Cells[4].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                //e.Row.Cells[1].Text = Outstanding1.ToString();
                e.Row.Cells[2].Text = Outstanding1.ToString();
                e.Row.Cells[3].Text = Outstanding2.ToString();
                e.Row.Cells[4].Text = Outstanding3.ToString();
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Text = Outstanding7.ToString();
                //Label lblTotalOutstanding1 = (Label)e.Row.FindControl("lblTotalOutstanding1");
                //lblTotalOutstanding1.Text = Outstanding1.ToString();
                //Label lblTotalOutstanding2 = (Label)e.Row.FindControl("lblTotalOutstanding2");
                //lblTotalOutstanding2.Text = Outstanding2.ToString();
                //Label lblTotalOutstanding3 = (Label)e.Row.FindControl("lblTotalOutstanding3");
                //lblTotalOutstanding3.Text = Outstanding3.ToString();

                //Label lblTotalOutstanding4 = (Label)e.Row.FindControl("lblTotalOutstanding4");
                //lblTotalOutstanding4.Text = Outstanding4.ToString();
            }
        }
        #endregion


    }

    protected void grdagging_2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Request.QueryString["branchid"] != null)
        {
            mylevel = Convert.ToInt32(Request.QueryString["level"]);
        }
        if (mylevel == 0)
        {
            grdagging_2.PageIndex = e.NewPageIndex;
            getreport(0, DateTime.Now.Month, DateTime.Now.Year);
        }
        else if (mylevel == 2)
        {
            grdagging_2.PageIndex = e.NewPageIndex;
            getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]), _month, _year);
        }
        else
        {
            grdagging_2.PageIndex = e.NewPageIndex;
            getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]), _month, _year);
        }

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

    protected void grdagging_2_Sorting(object sender, GridViewSortEventArgs e)
    {
        switch (mylevel)
        {
            case 0:
                if (!string.IsNullOrWhiteSpace(e.SortExpression))
                {
                    SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                }
                getreport(0, DateTime.Now.Month, DateTime.Now.Year);
                break;
            case 1:
                if (!string.IsNullOrWhiteSpace(e.SortExpression))
                {
                    SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                }
                getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]), _month, _year);
                break;
            case 2:
                if (!string.IsNullOrWhiteSpace(e.SortExpression))
                {
                    SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                }
                getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]), _month, _year); ;
                break;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
           

            int month = 0;
            int year = 0;

            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);
            BillingAmount();
            if (month == 0)
            {
                lblmess.Visible = true;
                lblmess.Text = "Please Select Month";
                return;
            }
            if (year == 0)
            {
                lblmess.Visible = true;
                lblmess.Text = "Please Select Year";
                return;
            }
            if (mylevel == 0)
            {
                getreport(0, month, year);
                AdjucementReport(0);
            }
            else if (mylevel == 1)
            {
                AdjucementReport(Convert.ToInt32(Request.QueryString["branchid"]));
                getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]), month, year);
            }
            else if (mylevel == 2)
            {
                getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]), month, year);
            }

        }
        catch (Exception ex)
        {
            lblmess.Visible = true;
            lblmess.Text = ex.Message;
        }

    }

    private void AdjucementReport(int BranchID)
    {
        try
        {
            string branchname = string.Empty;
            decimal _footertotalbranch = 0;

            string fromdate = string.Empty;
            string todate = string.Empty;
            int days = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
            fromdate = Convert.ToInt32(ddlYear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth.SelectedValue) + "-" + "01";
            todate = Convert.ToInt32(ddlYear.SelectedValue) + "-" + Convert.ToInt32(ddlMonth.SelectedValue) + "-" + days.ToString();

            Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
            DataSet ds_all = new DataSet();
            ds_all = cre.Get_Daily_Credit_Report_Branch_new(fromdate, todate, BranchID);
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
            decimal _totalamt = Convert.ToDecimal("0.00");
            decimal amountdiff = Convert.ToDecimal("0.00");

            DataSet dsrpt = new DataSet();
            dsrpt = cre.GetCollection_rpt_Monthly(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), "month");

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
    private void BillingAmount()
    {
        Clay.Sale.Bll.CreditDetail obj = new Clay.Sale.Bll.CreditDetail();
        int currentmonth = Convert.ToInt32(ddlMonth.SelectedValue);
        int currentYear = Convert.ToInt32(ddlYear.SelectedValue);
        int previousmonth=0;
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