using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.RAD;
using System.Web.UI.HtmlControls;
public partial class Rental_In_Out : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicermaster obj = new invoicermaster();
   // Country objcnt;
    provider objProvider;
    DataSet dsCountry = new DataSet();
    private void LoadProviderByCountry()
    {
        ddlnetworks.DataSource = null;
        objProvider = new provider();
        //objProvider.CountryId = countryid;
        DataSet dsPRovider = new DataSet();
        dsPRovider = objProvider.GetProviderGroup();
        ddlnetworks.DataSource = dsPRovider;
        ddlnetworks.DataTextField = "groupname";
        ddlnetworks.DataValueField = "groupid";
        ddlnetworks.DataBind();
        ddlnetworks.Items.Insert(0, "Select Provider");


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

        ddlyear.DataSource = dsYear.Tables[0];
        ddlyear.DataTextField = "yearVal";
        ddlyear.DataValueField = "yearTxt";
        ddlyear.DataBind();
        ddlyear.SelectedIndex = 0;



    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //   ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:fixHeader(); ", true);
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("Login.aspx", false);
            }

            if (!IsPostBack)
            {

                //loadCountryDDL();
                LoadProviderByCountry();
                loadYear();
                if (Convert.ToInt32(Session["UserID"]) == 385)
                {

                    
                }
                else
                {
                    
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int countryID = 0;
        int providerid = 0;
        string billingMonthfrom = string.Empty;
        string billingMonthto = string.Empty;
        int month = 0;
        lblmsg.Text = string.Empty;
        try
        {
            countryID = 0;// Convert.ToInt32(ddlcountry.SelectedValue);
        }
        catch { }

        try
        {
            providerid = Convert.ToInt32(ddlnetworks.SelectedValue);
        }
        catch { }

        try
        {
            if ((Convert.ToInt32(ddlyear.SelectedValue) > 0) && (Convert.ToInt32(ddlmonth.SelectedValue) <= 0))
            {
                lblmsg.Text = "Please Select Month and Year Both";
                return;
            }

            if ((Convert.ToInt32(ddlyear.SelectedValue) <= 0) && (Convert.ToInt32(ddlmonth.SelectedValue) > 0))
            {
                lblmsg.Text = "Please Select Month and Year Both";
                return;
            }
            if ((Convert.ToInt32(ddlyear.SelectedValue) >= 0) && (Convert.ToInt32(ddlmonth.SelectedValue) > 0))
            {
                // billingMonthfrom = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
               //  billingMonthto = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                billingMonthfrom = ddlyear.SelectedValue.ToString();
                billingMonthto = ddlmonth.SelectedValue.ToString();

            }
            else
            {
                billingMonthfrom = "0";// DateTime.Now.Year.ToString() + "-04" + "-01";
                billingMonthto = "0";// DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            }
        }
        catch { }

        try
        {
            DataSet dsReport = new DataSet();
            dsReport = obj.GetInvoiceRentalInOut(providerid, Convert.ToInt32(billingMonthfrom), Convert.ToInt32(billingMonthto));
           // dsReport = obj.GetInvoiceRentalInOut(providerid, 0, billingMonthfrom, billingMonthto);
           
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {


                RentalRepeater.DataSource = dsReport.Tables[0];
                RentalRepeater.DataBind();
                // pnlgrossary.Visible = false;

            }
            else
            {
                RentalRepeater.DataSource = null;
                RentalRepeater.DataBind();
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
    
    protected void RentalRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string from = string.Empty;
        string to = string.Empty;
        // DateTime abc;
        Label lblfrommmonth = (Label)e.Item.FindControl("lblbillmonth22");
        from = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");
        to = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");

        if (e.CommandName == "groupname")
        {
            string groupid = e.CommandArgument.ToString();
            string url = "Sub_Rpt_RentalInOut.aspx?groupid=" + groupid + "&fromdate=" + from + "&todate=" + to;
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=300,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=no,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
        }
    }
}