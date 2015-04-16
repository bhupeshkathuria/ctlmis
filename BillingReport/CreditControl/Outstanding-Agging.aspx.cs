using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Threading;
public partial class CreditControl_Outstanding_Agging : System.Web.UI.Page
{
    static int mylevel = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { 
            
            trbrname.Visible = false;
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("../Default.aspx", false);
            }
            // checkSession();
            //checkpageright();
            //System.Threading.Thread.Sleep(2000);
            if (!IsPostBack)
            {
                //string script = "$(document).ready(function () { $('[id*=Submit]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);   
                mylevel = -1;
                Wholeoutstanding();
            }
            if (Request.QueryString["branchid"] != null)
            {
                mylevel = Convert.ToInt32(Request.QueryString["level"]);
                if (mylevel == 0)
                {
                   // getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]));
                    getreport();
                }
            }
            if (Request.QueryString["branchid"] != null)
            {
                mylevel = Convert.ToInt32(Request.QueryString["level"]);
                if (mylevel == 1)
                {
                    getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]));
                }
            }
            if (Request.QueryString["custid"] != null)
            {
                mylevel = Convert.ToInt32(Request.QueryString["level"]);
                if (mylevel == 2)
                {
                    getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]));
                }
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    
    }

    private void getreport_Customerwise(int brid)
    {
        try
        {
            #region Create Datatable
            System.Data.DataTable dt2 = new System.Data.DataTable();
            // dt.Columns.Add("Branchid", string.Empty.GetType());
            //dt.Columns.Add("Name", string.Empty.GetType());
            //dt.Columns.Add("Outstanding1", string.Empty.GetType());
            //dt.Columns.Add("Outstanding2", string.Empty.GetType());

            //dt.Columns.Add("Outstanding3", string.Empty.GetType());
            //dt.Columns.Add("Outstanding4", string.Empty.GetType());

            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("0-60", typeof(System.Double));
            dt2.Columns.Add("60-90", typeof(System.Double));

            dt2.Columns.Add("90-180", typeof(System.Double));
            dt2.Columns.Add("180 Above", typeof(System.Double));
            dt2.Columns.Add("id", string.Empty.GetType());
            dt2.Columns.Add("brid", string.Empty.GetType());
            dt2.Columns.Add("Total", typeof(System.Double));



            #endregion

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
            ds_aggging = cre.Get_Outstanding_Agging(brid);

            if (ds_aggging.Tables["customerwise"].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_aggging.Tables["customerwise"].Rows)
                {

                    DataRow dr_ = dt2.NewRow();
                    customerid = Convert.ToInt32(dr["customerid"]);
                    branchid = Convert.ToInt32(dr["branchid"]);
                    customername = dr["customername"].ToString();
                    if (customerid != oldcustid)
                    {
                        DataRow[] dr_outstanding1 = ds_aggging.Tables["customerwise"].Select("xtype=" + 1 + " and customerid=" + customerid);
                        DataRow[] dr_outstanding2 = ds_aggging.Tables["customerwise"].Select("xtype=" + 2 + " and customerid=" + customerid);
                        DataRow[] dr_outstanding3 = ds_aggging.Tables["customerwise"].Select("xtype=" + 3 + " and customerid=" + customerid);
                        DataRow[] dr_outstanding4 = ds_aggging.Tables["customerwise"].Select("xtype=" + 4 + " and customerid=" + customerid);
                        //0 to 60
                        #region 0 to 60
                        if (dr_outstanding1.Length > 0)
                        {
                            if (dr_outstanding1[0]["total"] != DBNull.Value)
                            {
                                _outstanding1 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding1[0]["total"])));
                                _total += _outstanding1;

                            }
                            else
                            {
                                _outstanding1 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                _total += _outstanding1;
                            }
                        }
                        else
                        {
                            _outstanding1 = 0;
                            _total += _outstanding1;
                        }
                        #endregion

                        #region 60 to 90
                        if (dr_outstanding2.Length > 0)
                        {
                            if (dr_outstanding2[0]["total"] != DBNull.Value)
                            {
                                _outstanding2 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding2[0]["total"])));
                                _total += _outstanding2;
                            }
                            else
                            {
                                _outstanding2 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                _total += _outstanding2;
                            }
                        }
                        else
                        {
                            _outstanding2 = 0;
                            _total += _outstanding2;
                        }
                        #endregion

                        #region 90 to 180
                        if (dr_outstanding3.Length > 0)
                        {
                            if (dr_outstanding3[0]["total"] != DBNull.Value)
                            {
                                _outstanding3 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding3[0]["total"])));
                                _total += _outstanding3;
                            }
                            else
                            {
                                _outstanding3 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                _total += _outstanding3;
                            }
                        }
                        else
                        {
                            _outstanding3 = 0;
                            _total += _outstanding3;
                        }
                        #endregion

                        #region 180 Above
                        if (dr_outstanding4.Length > 0)
                        {
                            if (dr_outstanding4[0]["total"] != DBNull.Value)
                            {
                                _outstanding4 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding4[0]["total"])));
                                _total += _outstanding4;
                            }
                            else
                            {
                                _outstanding4 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                                _total += _outstanding4;
                            }
                        }
                        else
                        {
                            _outstanding4 = 0;
                            _total += _outstanding4;
                        }
                        #endregion

                        dr_["Name"] = customername.ToString();
                        dr_["0-60"] = _outstanding1.ToString();
                        dr_["60-90"] = _outstanding2.ToString();
                        dr_["90-180"] = _outstanding3.ToString();
                        dr_["180 Above"] = _outstanding4.ToString();
                        dr_["id"] = customerid.ToString();
                        dr_["brid"] = branchid.ToString();
                        dr_["Total"] = _total;
                        dt2.Rows.Add(dr_);
                        oldcustid = Convert.ToInt32(dr["customerid"]);
                        dt2.AcceptChanges();
                        _total = 0;
                    }
                }
                //grdagging_2.AllowPaging = true;
                //grdagging_2.PageSize = 50;
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
                grdagging_2.DataSource = dv2;
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
        
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    private void getreport_CustomerwiseDeatil(int brid,int custid)
    {
        try
        {
            

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
            ds_aggging = cre.Get_Agging_customer_Detail(brid, custid);

            if (ds_aggging.Tables["customerDetail"].Rows.Count > 0)
            {

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
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter str = new StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
            grdagging_2.AllowPaging = false;
            grdagging_2.RenderControl(HtmlTextWriter);
            Response.Write(str.ToString());
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private string ConvertToMoneyFormat(double myval)
    {
        return string.Format("{0:0.00}", myval);
    }

    private void getreport()
    {
        try
        {
            #region Create Datatable
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("0-60", typeof(System.Double));
            dt.Columns.Add("60-90", typeof(System.Double));

            dt.Columns.Add("90-180", typeof(System.Double));
            dt.Columns.Add("180 Above", typeof(System.Double));
            dt.Columns.Add("id", string.Empty.GetType());
            dt.Columns.Add("Total", typeof(System.Double));
            //dt.Columns.Add("Name", string.Empty.GetType());
            //dt.Columns.Add("amount1", string.Empty.GetType());
            //dt.Columns.Add("amount2", string.Empty.GetType());

            //dt.Columns.Add("amount3", string.Empty.GetType());
            //dt.Columns.Add("amount", string.Empty.GetType());
            //dt.Columns.Add("id", string.Empty.GetType());



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
            ds_aggging = cre.Get_Outstanding_Agging(0);

            if (ds_aggging.Tables["Outstanding1"].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_aggging.Tables["branch"].Rows)
                {
                    DataRow dr_ = dt.NewRow();
                    branchid = Convert.ToInt32(dr["branchid"]);
                    branchname = dr["branchname"].ToString();

                    DataRow[] dr_outstanding1 = ds_aggging.Tables["Outstanding1"].Select("branchid=" + branchid);
                    DataRow[] dr_outstanding2 = ds_aggging.Tables["Outstanding2"].Select("branchid=" + branchid);
                    DataRow[] dr_outstanding3 = ds_aggging.Tables["Outstanding3"].Select("branchid=" + branchid);
                    DataRow[] dr_outstanding4 = ds_aggging.Tables["Outstanding4"].Select("branchid=" + branchid);
                    //0 to 60

                    #region 0 to 60
                    if (dr_outstanding1.Length > 0)
                    {
                        if (dr_outstanding1[0]["total"] != DBNull.Value)
                        {
                            _outstanding1 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding1[0]["total"])));
                            _total += _outstanding1;
                        }
                        else
                        {
                            _outstanding1 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                            _total += _outstanding1;
                        }
                    }
                    else
                    {
                        _outstanding1 = 0;
                        _total += _outstanding1;
                    }
                    #endregion

                    #region 60 to 90
                    if (dr_outstanding2.Length > 0)
                    {
                        if (dr_outstanding2[0]["total"] != DBNull.Value)
                        {
                            _outstanding2 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding2[0]["total"])));
                            _total += _outstanding2;
                        }
                        else
                        {
                            _outstanding2 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                            _total += _outstanding2;
                        }
                    }
                    else
                    {
                        _outstanding2 = 0;
                        _total += _outstanding2;
                    }
                    #endregion

                    #region 90 to 180
                    if (dr_outstanding3.Length > 0)
                    {
                        if (dr_outstanding3[0]["total"] != DBNull.Value)
                        {
                            _outstanding3 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding3[0]["total"])));
                            _total += _outstanding3;
                        }
                        else
                        {
                            _outstanding3 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                            _total += _outstanding3;
                        }
                    }
                    else
                    {
                        _outstanding3 = 0;
                        _total += _outstanding3;
                    }
                    #endregion

                    #region 180 Above
                    if (dr_outstanding4.Length > 0)
                    {
                        if (dr_outstanding4[0]["total"] != DBNull.Value)
                        {
                            _outstanding4 = Convert.ToDecimal(ConvertToMoneyFormat(Convert.ToDouble(dr_outstanding4[0]["total"])));
                            _total += _outstanding4;
                        }
                        else
                        {
                            _outstanding4 = 0;// Convert.ToDecimal(dr_april_bill[0]["amount"]);
                            _total += _outstanding4;
                        }
                    }
                    else
                    {
                        _outstanding4 = 0;
                        _total += _outstanding4;
                    }
                    #endregion

                    dr_["Name"] = branchname.ToString();
                    dr_["0-60"] = _outstanding1.ToString();
                    dr_["60-90"] = _outstanding2.ToString();
                    dr_["90-180"] = _outstanding3.ToString();
                    dr_["180 Above"] = _outstanding4.ToString();
                    dr_["id"] = branchid.ToString();
                    dr_["Total"] = _total.ToString();
                    dt.Rows.Add(dr_);
                    dt.AcceptChanges();
                    _total = 0;
                }
                DataView dv = dt.DefaultView;

                foreach (DataColumn drcheck in dt.Columns)
                {


                    if (SortExpression.ToString().Contains(drcheck.ToString()))
                    {
                        dv.Sort = SortExpression;
                    }

                }
                grdagging_2.DataSource = dv;
                grdagging_2.DataBind();
                trexport.Visible = true;
                for (int i = 0; i < grdagging_2.Rows.Count; i++)
                {
                    grdagging_2.Rows[i].Cells[5].Visible = false;
                    grdagging_2.HeaderRow.Cells[5].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }
    private void Wholeoutstanding()
    {
        try
        {
            #region Create Datatable
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("TotalInvoiceAmount", typeof(System.Double));
            dt.Columns.Add("TotalCollection", typeof(System.Double));
            dt.Columns.Add("TotalAdjustment", typeof(System.Double));
            dt.Columns.Add("TotalCreditNote", typeof(System.Double));
            
            //dt.Columns.Add("id", string.Empty.GetType());
            dt.Columns.Add("Outstd As Per Payment", typeof(System.Double));
            dt.Columns.Add("Outstd As Per Adjustment", typeof(System.Double));
            //dt.Columns.Add("Name", string.Empty.GetType());
            //dt.Columns.Add("amount1", string.Empty.GetType());
            //dt.Columns.Add("amount2", string.Empty.GetType());

            //dt.Columns.Add("amount3", string.Empty.GetType());
            //dt.Columns.Add("amount", string.Empty.GetType());
            //dt.Columns.Add("id", string.Empty.GetType());



            #endregion

            #region Varible
            string branchname = string.Empty;
            int branchid = 0;
            decimal _outstanding1 = 0;
            decimal _outstanding2 = 0;
            decimal _outstanding3 = 0;
            decimal _outstanding4 = 0;
            decimal _allcollection = 0;
            decimal _total = 0;
            decimal totalout_as_perrecipt = 0;
            #endregion
            Clay.Sale.Bll.CreditDetail cre = new Clay.Sale.Bll.CreditDetail();
            DataSet ds_aggging_nobranch = new DataSet();
            ds_aggging_nobranch = cre.Get_Outstanding_Agging_WthoutBranch();

            if (ds_aggging_nobranch.Tables["Outstanding1"].Rows.Count > 0)
            {
                
                    DataRow dr_ = dt.NewRow();


                    _outstanding1 = Convert.ToDecimal(ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["Totalinv"]);
                    _outstanding2 = Convert.ToDecimal(ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["Recived"]);
                    _outstanding3 = Convert.ToDecimal(ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["toatalcreditnote"]);

                    _allcollection = Convert.ToDecimal(ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["allcollection"]);
                    //_outstanding4 = Convert.ToDecimal(ds_aggging_nobranch.Tables["Outstanding4"].Rows[0]["total"]);
                    //0 to 60


                    _total = (_outstanding1 - (_allcollection + _outstanding3));
                    totalout_as_perrecipt = (_outstanding1 - (_outstanding2 + _outstanding3));
                    dr_["Name"] = "All";
                    dr_["TotalInvoiceAmount"] = ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["Totalinv"].ToString();
                    dr_["TotalCollection"] = ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["allcollection"].ToString(); ;
                    dr_["TotalAdjustment"] = ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["Recived"].ToString(); ;
                    dr_["TotalCreditNote"] = ds_aggging_nobranch.Tables["Outstanding1"].Rows[0]["toatalcreditnote"].ToString(); ;

                    dr_["Outstd As Per Payment"] = _total.ToString();
                    dr_["Outstd As Per Adjustment"] = totalout_as_perrecipt.ToString();
                   // dr_["id"] = branchid.ToString();
                    //dr_["Total"] = _total.ToString();
                    dt.Rows.Add(dr_);
                    dt.AcceptChanges();
                    _total = 0;
                
                DataView dv = dt.DefaultView;

                foreach (DataColumn drcheck in dt.Columns)
                {


                    if (SortExpression.ToString().Contains(drcheck.ToString()))
                    {
                        dv.Sort = SortExpression;
                    }

                }
                grdagging_2.DataSource = dv;
                grdagging_2.DataBind();
                trexport.Visible = true;
                
            }
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }
    //protected void grdagging_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        decimal Outstanding1 = 0;
    //        decimal Outstanding2 = 0;
    //        decimal Outstanding3 = 0;
    //        decimal Outstanding4 = 0;
    //        foreach (GridViewRow gr in grdagging.Rows)
    //        {
    //            Label lblOutstanding1 = (Label)gr.FindControl("lblOutstanding1");
    //            Outstanding1 += decimal.Parse(lblOutstanding1.Text);

    //            Label lblOutstanding2 = (Label)gr.FindControl("lblOutstanding2");
    //            Outstanding2 += decimal.Parse(lblOutstanding2.Text);

    //           Label lblOutstanding3 = (Label)gr.FindControl("lblOutstanding3");
    //           Outstanding3 += decimal.Parse(lblOutstanding3.Text);

    //           Label lblOutstanding4 = (Label)gr.FindControl("lblOutstanding4");
    //           Outstanding4 += decimal.Parse(lblOutstanding4.Text);
    //        }
    //        //e.Row.Cells[0].Text = "Grand Total";
    //        //e.Row.Cells[1].Text = Outstanding1.ToString();
    //        //e.Row.Cells[2].Text = Outstanding2.ToString("0.00");
    //        //e.Row.Cells[3].Text = Outstanding3.ToString("0.00");
    //        //e.Row.Cells[4].Text = Outstanding4.ToString("0.00");
    //        Label lblTotalOutstanding1 = (Label)e.Row.FindControl("lblTotalOutstanding1");
    //        lblTotalOutstanding1.Text = Outstanding1.ToString();
    //        Label lblTotalOutstanding2 = (Label)e.Row.FindControl("lblTotalOutstanding2");
    //        lblTotalOutstanding2.Text = Outstanding2.ToString();
    //        Label lblTotalOutstanding3 = (Label)e.Row.FindControl("lblTotalOutstanding3");
    //        lblTotalOutstanding3.Text = Outstanding3.ToString();

    //        Label lblTotalOutstanding4 = (Label)e.Row.FindControl("lblTotalOutstanding4");
    //        lblTotalOutstanding4.Text = Outstanding4.ToString();
    //    }
    //}
    decimal Outstanding1 = 0;
    decimal Outstanding2 = 0;
    decimal Outstanding3 = 0;
    decimal Outstanding4 = 0;
    decimal Outstanding7 = 0;
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
        #region First Level
        if (mylevel == -1)
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
                TotalAmt = 0;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string branchid = "0";
                string firslevel = e.Row.Cells[0].Text;
               
                string hlink2 = "javascript:callreportfirstlevel('" + branchid + "','0')";
                //string hlink2 = "javascript:callreport('" + branchid + "','" + firslevel + "','1')";
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + firslevel + "</a>";
                grdagging_2.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
            }
            
        }
        #endregion

        #region Branch Wise
        if (mylevel == 0)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText_colcheque = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                col1 = LnkHeaderText_colcheque.Text;
                LinkButton LnkHeaderText_colcash = e.Row.Cells[2].Controls[0] as LinkButton;
                col2 = LnkHeaderText_colcash.Text;
                LinkButton LnkHeaderText_colcc = e.Row.Cells[3].Controls[0] as LinkButton;
                col3 = LnkHeaderText_colcc.Text;
                LinkButton LnkHeaderText_colbank = e.Row.Cells[4].Controls[0] as LinkButton;
                col4 = LnkHeaderText_colbank.Text;
                LinkButton LnkHeaderText_total = e.Row.Cells[5].Controls[0] as LinkButton;
                col5 = LnkHeaderText_total.Text;

                 Outstanding1 = 0;
                 Outstanding2 = 0;
                 Outstanding3 = 0;
                 Outstanding4 = 0;
                 TotalAmt = 0;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string branchid = e.Row.Cells[5].Text;
                string branchname = e.Row.Cells[0].Text;
                //string hlink2 = "javascript:callreport('" + branchid + "','1')";
                string hlink2 = "javascript:callreport('" + branchid + "','" + branchname + "','1')";
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + branchname + "</a>";
                grdagging_2.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;   
                Outstanding1 += decimal.Parse(e.Row.Cells[1].Text);               
                Outstanding2 += decimal.Parse(e.Row.Cells[2].Text);
                Outstanding3 += decimal.Parse(e.Row.Cells[3].Text);               
                Outstanding4 += decimal.Parse(e.Row.Cells[4].Text);
                TotalAmt += decimal.Parse(e.Row.Cells[6].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;  // this column[5] for branch id but we show total in this col

                e.Row.Cells[1].Text = Outstanding1.ToString();
                e.Row.Cells[2].Text = Outstanding2.ToString();
                e.Row.Cells[3].Text = Outstanding3.ToString();
                e.Row.Cells[4].Text = Outstanding4.ToString();
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Text = TotalAmt.ToString(); // this column[5] for branch id but we show total in this col
               
            }
        }
        #endregion

        #region Customer Wise
        if (mylevel == 1)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText_colcheque = e.Row.Cells[1].Controls[0] as LinkButton;// e.Row.Cells[2].Text;
                col1 = LnkHeaderText_colcheque.Text;
                LinkButton LnkHeaderText_colcash = e.Row.Cells[2].Controls[0] as LinkButton;
                col2 = LnkHeaderText_colcash.Text;
                LinkButton LnkHeaderText_colcc = e.Row.Cells[3].Controls[0] as LinkButton;
                col3 = LnkHeaderText_colcc.Text;
                LinkButton LnkHeaderText_colbank = e.Row.Cells[4].Controls[0] as LinkButton;
                col4 = LnkHeaderText_colbank.Text;

                 Outstanding1 = 0;
                 Outstanding2 = 0;
                 Outstanding3 = 0;
                 Outstanding4 = 0;
                 TotalAmt = 0;

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customername = e.Row.Cells[0].Text;
                string customerid = e.Row.Cells[5].Text;
                string branchid = e.Row.Cells[6].Text;
                string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + customerid + "','2')";
                //string hlink2 = "javascript:callreportcustomer('" + branchid + "','" + branchname + "','1')";
                e.Row.Cells[0].Text = "<a href=" + hlink2 + ">" + customername + "</a>";
                grdagging_2.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                grdagging_2.HeaderRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                grdagging_2.HeaderRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right; 
                Outstanding1 += decimal.Parse(e.Row.Cells[1].Text);               
                Outstanding2 += decimal.Parse(e.Row.Cells[2].Text);               
                Outstanding3 += decimal.Parse(e.Row.Cells[3].Text);              
                Outstanding4 += decimal.Parse(e.Row.Cells[4].Text);
                TotalAmt += decimal.Parse(e.Row.Cells[7].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;  //this column[5] [6] for branch id && custid but we show total in this col

                e.Row.Cells[1].Text = Outstanding1.ToString();
                e.Row.Cells[2].Text = Outstanding2.ToString();
                e.Row.Cells[3].Text = Outstanding3.ToString();
                e.Row.Cells[4].Text = Outstanding4.ToString();
                e.Row.Cells[5].Visible = false; e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Text = TotalAmt.ToString(); //this column[5] [6] for branch id && custid but we show total in this col
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
            getreport();
        }
        else if (mylevel == 2)
        {
            grdagging_2.PageIndex = e.NewPageIndex;
            getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]));
        }
        else
        {
            grdagging_2.PageIndex = e.NewPageIndex;
            getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]));
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
                getreport();
                break;
            case 1:
                if (!string.IsNullOrWhiteSpace(e.SortExpression))
                {
                    SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                }
               getreport_Customerwise(Convert.ToInt32(Request.QueryString["branchid"]));
                break;
            case 2:
                if (!string.IsNullOrWhiteSpace(e.SortExpression))
                {
                    SortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                }
                getreport_CustomerwiseDeatil(Convert.ToInt32(Request.QueryString["branchid"]), Convert.ToInt32(Request.QueryString["custid"]));;
                break;
        }
    }
  
}