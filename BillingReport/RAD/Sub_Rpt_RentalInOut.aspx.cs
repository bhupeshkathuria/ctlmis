using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ClayInvoiceRevenueBAL;
using Clay.RAD;
using System.IO;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class Sub_Rpt_RentalInOut : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicermaster obj = new invoicermaster();
    //Country objcnt;
    provider objProvider;
    DataSet dsCountry = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //   ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fixHeader(); ", true);
            //if (!(Convert.ToInt32(Session["UserID"]) > 0))
            //{
            //    Response.Redirect("Login.aspx", false);
            //}

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["groupid"].ToString()))
                    bindInvoiceRevenue(Convert.ToInt32(Request.QueryString["groupid"]), Request.QueryString["fromdate"].ToString(), Request.QueryString["todate"].ToString());
                //loadCountryDDL();
                // LoadProviderByCountry();
                // loadYear();

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void bindInvoiceRevenue(int groupproviderid, string fromdate, string todate)
    {
        int countryID = 0;
        int providerid = 0;
        string billingMonthfrom = string.Empty;
        string billingMonthto = string.Empty;
        int month = 0;


        try
        {

            dsReport = obj.GetInvoiceRentalsubreport(groupproviderid, fromdate, todate);
            DataTable dtreport = new DataTable();
            dtreport = dsReport.Tables[0].Clone();
            bool _exist = false;
            string _existval = string.Empty;
            string _newval = string.Empty;
            string _newmonth = string.Empty;
            string _existmonth = string.Empty;
            string _newinvamt = string.Empty;
            string _newinvamtrental = string.Empty;
            string _newinvamtvasrental = string.Empty;
            string _newinvamttotalrental = string.Empty;
            string _newinvamttotalrentalinr = string.Empty;

            string _extinvamt = string.Empty;
            string _extinvamtrental = string.Empty;
            string _extinvamtvasrental = string.Empty;
            string _extinvamttotalrental = string.Empty;
            string _extinvamttotalrentalinr = string.Empty;
            foreach (DataRow dr in dsReport.Tables[0].Rows)
            {
                _newval = dr["Network"].ToString();
                _newmonth = dr["BillingMonth"].ToString();

                _newinvamt = dr["invoiceamount"].ToString();
                _newinvamtrental = dr["invoicerental"].ToString();
                _newinvamtvasrental = dr["invoicevasrental"].ToString();
                _newinvamttotalrental = dr["totalinvRental"].ToString();
                _newinvamttotalrentalinr = dr["invTotalRentalINR"].ToString();
               
                if (_existval == _newval)
                {
                    dr["Network"] = string.Empty;
                }
                else
                {

                }
                if (_existmonth == _newval)
                {
                    dr["BillingMonth"] = string.Empty;
                }
                else
                {

                }
                if (_extinvamt == _newinvamt)
                {
                    dr["invoiceamount"] = string.Empty;
                }
                else
                {

                }

                if (_extinvamtrental == _newinvamtrental)
                {
                    dr["invoicerental"] = string.Empty;
                }
                else
                {

                }
                if (_extinvamtvasrental == _newinvamtvasrental)
                {
                    dr["invoicevasrental"] = string.Empty;
                }
                else
                {

                }
                if (_extinvamttotalrental == _newinvamttotalrental)
                {
                    dr["totalinvRental"] = string.Empty;
                }
                else
                {

                }
                if (_extinvamttotalrentalinr == _newinvamttotalrentalinr)
                {
                    dr["invTotalRentalINR"] = string.Empty;
                }
                else
                {

                }
                _existval = _newval;
                _existmonth = _newmonth;
                _extinvamt = _newinvamt;
                _extinvamtrental = _newinvamtrental;
                _extinvamtvasrental = _newinvamtvasrental;
                _extinvamttotalrental = _newinvamttotalrental;
                _extinvamttotalrentalinr = _newinvamttotalrentalinr;
                dsReport.Tables[0].AcceptChanges();
            }
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                RentalRepeater.DataSource = dsReport.Tables[0];

                RentalRepeater.DataBind();
                // pnlgrossary.Visible = false;

            }
            else
            {
                // pnlgrossary.Visible = false;
            }

            


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }
    #region Varibles
    decimal invoiceamount = 0;
    decimal invoicerental = 0;
    decimal invoicevasrental = 0;
    decimal invoicerentaltotal = 0;
    decimal invoicerentaltotalINR = 0;
    decimal retoutchargerentalinr = 0;
    decimal whsoutchargerentalinr = 0;
    decimal totaloutchargerentalinr = 0;
    decimal gap = 0;



    #endregion
    protected void RentalRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            #region Item Section
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblinvoiceamount = (Label)e.Item.FindControl("lblinvoiceamount");
                Label lblinvrental = (Label)e.Item.FindControl("lblinvrental");
                Label lblinvvasrental = (Label)e.Item.FindControl("lblinvvasrental");
                Label lblinvtotalrental = (Label)e.Item.FindControl("lblinvtotalrental");
                Label lblinvrentalinr = (Label)e.Item.FindControl("lblinvrentalinr");
                Label lblretoutrentalinr = (Label)e.Item.FindControl("lblretoutrentalinr");
                Label lblwhsoutrentalinr = (Label)e.Item.FindControl("lblwhsoutrentalinr");
                Label lbltotaloutrentalinr = (Label)e.Item.FindControl("lbltotaloutrentalinr");
                Label lbldifference = (Label)e.Item.FindControl("lbldifference");
                HtmlTableCell tdlblgap = (HtmlTableCell)e.Item.FindControl("tdlblgap");
                if (Convert.ToDecimal(lbldifference.Text) > 0)
                {
                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    lbldifference.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    lbldifference.ForeColor = System.Drawing.Color.White;
                }



                #region Calculation
                invoiceamount += Convert.ToDecimal(lblinvoiceamount.Text);
                invoicerental += Convert.ToDecimal(lblinvrental.Text);
                invoicevasrental += Convert.ToDecimal(lblinvvasrental.Text);
                invoicerentaltotal += Convert.ToDecimal(lblinvtotalrental.Text);
                invoicerentaltotalINR += Convert.ToDecimal(lblinvrentalinr.Text);
                retoutchargerentalinr += Convert.ToDecimal(lblretoutrentalinr.Text);
                whsoutchargerentalinr += Convert.ToDecimal(lblwhsoutrentalinr.Text);
                totaloutchargerentalinr += Convert.ToDecimal(lbltotaloutrentalinr.Text);

                // ret_inchargeINR += Convert.ToDecimal(lbltotaloutrentalinr.Text);

                #endregion
            }
            #endregion
            #region Footer Section
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblinvoiceamounttot = (Label)e.Item.FindControl("lblinvoiceamounttot");
                Label lblinvrentaltot = (Label)e.Item.FindControl("lblinvrentaltot");
                Label lblinvvasrentaltot = (Label)e.Item.FindControl("lblinvvasrentaltot");
                Label lblinvtotalrentaltot = (Label)e.Item.FindControl("lblinvtotalrentaltot");
                Label lblinvrentalinrtot = (Label)e.Item.FindControl("lblinvrentalinrtot");
                Label lblretoutrentalinrtot = (Label)e.Item.FindControl("lblretoutrentalinrtot");
                Label lblwhsoutrentalinrtot = (Label)e.Item.FindControl("lblwhsoutrentalinrtot");
                Label lbltotaloutrentalinrtot = (Label)e.Item.FindControl("lbltotaloutrentalinrtot");

                lblinvoiceamounttot.Text = invoiceamount.ToString();
                lblinvrentaltot.Text = invoicerental.ToString();
                lblinvvasrentaltot.Text = invoicevasrental.ToString();
                lblinvtotalrentaltot.Text = invoicerentaltotal.ToString();
                lblinvrentalinrtot.Text = invoicerentaltotalINR.ToString();
                lblretoutrentalinrtot.Text = retoutchargerentalinr.ToString();

                lblwhsoutrentalinrtot.Text = whsoutchargerentalinr.ToString();
                lbltotaloutrentalinrtot.Text = totaloutchargerentalinr.ToString();

            }
            #endregion
        }
        catch (Exception ex)
        {
            return;
        }
    }
}