using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
//using ClayInvoiceRevenueBAL;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using System.Collections;
using Clay.RAD;


public partial class CDR_InvoiceReport : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicermaster obj = new invoicermaster();
  //  Country objcnt;
    provider objProvider;
    DataSet dsCountry = new DataSet();

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

                    btnExport.Visible = true;
                }
                else
                {
                    btnExport.Visible = false;
                }
              
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void bindInvoiceRevenue()
    {
        int countryID = 0;
        int providerid = 0;
        string billingMonthfrom = string.Empty;
        string billingMonthto = string.Empty;
        int month=0;
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
                //billingMonthfrom = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                //billingMonthto = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
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

            //dsReport = obj.GetInvoiceCDRInvoicerpt_2New(providerid, countryID, billingMonthfrom, billingMonthto);
            dsReport = obj.GetInvoiceCDRInvoicerpt_newutility(providerid, Convert.ToInt32(billingMonthfrom), Convert.ToInt32(billingMonthto),Convert.ToInt16(ddlCriteria.SelectedValue.ToString()));
            DataTable dtreport = new DataTable();
            dtreport = dsReport.Tables[0].Clone();
            bool _exist = false;
            string _existval = string.Empty;
            string _newval = string.Empty;
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {
               
                

            }
            if (dsReport.Tables[0].Rows.Count > 0)
            {
              //  RAFRepeater.DataSource = dsReport.Tables[0];
              //  RAFRepeater.DataBind();
                div.Visible = true;
                grdinvoice.DataSource = dsReport.Tables[0];
                grdinvoice.DataBind();
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindInvoiceRevenue();

    }

    //protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LoadProviderByCountry(Convert.ToInt32(ddlcountry.SelectedValue));
    //    }
    //    catch
    //    {
    //    }
    //}

    //private void loadCountryDDL()
    //{
    //    objcnt = new Country();
    //    objcnt.CountryId = 0;
    //    dsCountry = objcnt.GetCountry();

    //    ddlcountry.DataSource = dsCountry;
    //    ddlcountry.DataTextField = "countryname";
    //    ddlcountry.DataValueField = "countryid";
    //    ddlcountry.DataBind();
    //    ddlcountry.Items.Insert(0, "Select Country");
    //}

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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if(grdinvoice.Rows.Count>0)
        {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter str = new StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
        
        grdinvoice.RenderControl(HtmlTextWriter);
        Response.Write(str.ToString());
        Response.End();
        }

    }

    #region Varibles
    decimal invoiceamount = 0;
    decimal totalcdramt = 0;
   
    decimal gap = 0;

    int totallines = 0;
    decimal ret_incharge = 0;
    decimal ret_outcharge = 0;
    decimal ret_inchargeINR = 0;
    decimal ret_outchargeINR = 0;

    int totallineswhs = 0;
    decimal whole_incharge = 0;
    decimal whole_outcharge = 0;
    decimal whole_inchargeINR = 0;
    decimal whole_outchargeINR = 0;

    decimal tot_outchargefx = 0;
    decimal tot_outchargeINR = 0;
   
    
    decimal revinvoiceamt = 0;
    decimal totbillingamt = 0;
    decimal grossrevFX = 0;
    decimal grossrevINR = 0;
    //decimal fixedamt = 0;
    //decimal invamount = 0;
    //decimal invamtINR = 0;
    //decimal proloss = 0;
    decimal invoiceamountinr = 0;
    decimal cdramountinr = 0;
    decimal revinvoiceamountinr = 0;
    decimal totalbillinginr = 0;

    decimal totalcramount = 0;
    decimal totalcramountinr = 0;
    #endregion

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        try
        {            
            #region Item Section
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramt");
               // cell.Visible = false;
                Label lblinvoiceamount = (Label)e.Item.FindControl("lblinvoiceamount");

                Label lblinvoiceamountinr = (Label)e.Item.FindControl("lblinvoiceamountinr");
                Label lbltotallines = (Label)e.Item.FindControl("lbltotallines");

                Label lblcdramount = (Label)e.Item.FindControl("lblcdramount");
                Label lblcdramountallinr = (Label)e.Item.FindControl("lblcdramountallinr");
                Label lblgap = (Label)e.Item.FindControl("lblgap");
                HtmlTableCell tdlblgap = (HtmlTableCell)e.Item.FindControl("tdlblgap");
                if (Convert.ToDecimal(lblgap.Text) > 0)
                {
                    
                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green"); 
                    lblgap.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    lblgap.ForeColor = System.Drawing.Color.White;
                }

                // Retailer
                Label lblret_incharge = (Label)e.Item.FindControl("lblret_incharge");
                Label lblret_outcharge = (Label)e.Item.FindControl("lblret_outcharge");
                Label lblret_incharge_inr = (Label)e.Item.FindControl("lblret_incharge_inr");
                HtmlTableCell tdlblret_incharge_inr = (HtmlTableCell)e.Item.FindControl("tdlblret_incharge_inr");
                if (Convert.ToDecimal(lblret_incharge_inr.Text) > 0)
                {
                    tdlblret_incharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    lblret_incharge_inr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblret_incharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    lblret_incharge_inr.ForeColor = System.Drawing.Color.White;
                }
                Label lblret_outcharge_inr = (Label)e.Item.FindControl("lblret_outcharge_inr");
                HtmlTableCell tdlblret_outcharge_inr = (HtmlTableCell)e.Item.FindControl("tdlblret_outcharge_inr");
                if (Convert.ToDecimal(lblret_outcharge_inr.Text) > 0)
                {
                    tdlblret_outcharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    lblret_outcharge_inr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblret_outcharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    lblret_outcharge_inr.ForeColor = System.Drawing.Color.White;
                }

                //wholesaler

                Label lbltotallineswhs = (Label)e.Item.FindControl("lbltotallineswhs");
                Label lblwhole_incharge = (Label)e.Item.FindControl("lblwhole_incharge");
                Label lblwhole_outcharge = (Label)e.Item.FindControl("lblwhole_outcharge");
                Label lblwhole_incharge_inr = (Label)e.Item.FindControl("lblwhole_incharge_inr");
                HtmlTableCell tdlblwhole_incharge_inr = (HtmlTableCell)e.Item.FindControl("tdlblwhole_incharge_inr");
                if (Convert.ToDecimal(lblwhole_incharge_inr.Text) > 0)
                {
                    tdlblwhole_incharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                   // lblwhole_incharge_inr.BackColor = System.Drawing.Color.Green;
                    lblwhole_incharge_inr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblwhole_incharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    //lblwhole_incharge_inr.BackColor = System.Drawing.Color.Red;
                    lblwhole_incharge_inr.ForeColor = System.Drawing.Color.White;
                }
                Label lblwhole_outcharge_inr = (Label)e.Item.FindControl("lblwhole_outcharge_inr");
                HtmlTableCell tdlblwhole_outcharge_inr = (HtmlTableCell)e.Item.FindControl("tdlblwhole_outcharge_inr");
                if (Convert.ToDecimal(lblwhole_outcharge_inr.Text) > 0)
                {
                    tdlblwhole_outcharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                   // lblwhole_outcharge_inr.BackColor = System.Drawing.Color.Green;
                    lblwhole_outcharge_inr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblwhole_outcharge_inr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    //lblwhole_outcharge_inr.BackColor = System.Drawing.Color.Red;
                    lblwhole_outcharge_inr.ForeColor = System.Drawing.Color.White;
                }

                //Total
                Label lbltot_outchargefx = (Label)e.Item.FindControl("lbltot_outchargefx");
                Label lbltot_outchargeINR = (Label)e.Item.FindControl("lbltot_outchargeINR");


                //Revenue
                Label lblrevinvoiceamount = (Label)e.Item.FindControl("lblrevinvoiceamount");
                HtmlTableCell tdlblrevinvoiceamount = (HtmlTableCell)e.Item.FindControl("tdlblrevinvoiceamount");
                if (Convert.ToDecimal(lblrevinvoiceamount.Text) > 0)
                {
                    tdlblrevinvoiceamount.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    //lblrevinvoiceamount.BackColor = System.Drawing.Color.Green;
                    lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblrevinvoiceamount.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    //lblrevinvoiceamount.BackColor = System.Drawing.Color.Red;
                    lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                }
                Label lblrevinvoiceamountinr = (Label)e.Item.FindControl("lblrevinvoiceamountinr");
                
                Label lbltotalbilling = (Label)e.Item.FindControl("lbltotalbilling");
                HtmlTableCell tdlbltotalbilling = (HtmlTableCell)e.Item.FindControl("tdlbltotalbilling");
                if (Convert.ToDecimal(lbltotalbilling.Text) > 0)
                {
                    tdlbltotalbilling.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                   // lbltotalbilling.BackColor = System.Drawing.Color.Green;
                    lbltotalbilling.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlbltotalbilling.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                   // lbltotalbilling.BackColor = System.Drawing.Color.Red;
                    lbltotalbilling.ForeColor = System.Drawing.Color.White;
                }
                Label lbltotalbillinginr = (Label)e.Item.FindControl("lbltotalbillinginr");
                
               
                Label lblgrossrevinr = (Label)e.Item.FindControl("lblgrossrevinr");
                HtmlTableCell tdlblgrossrevinr = (HtmlTableCell)e.Item.FindControl("tdlblgrossrevinr");
                if (Convert.ToDecimal(lblgrossrevinr.Text) > 0)
                {
                    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    
                    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    
                    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                }

                Label lblcreditnote = (Label)e.Item.FindControl("lblcreditnote");
                Label lblcreditnoteinr = (Label)e.Item.FindControl("lblcreditnoteinr");
               
                #region Calculation
                invoiceamount += Convert.ToDecimal(lblinvoiceamount.Text);

                invoiceamountinr += Convert.ToDecimal(lblinvoiceamountinr.Text);
                totallines += Convert.ToInt32(lbltotallines.Text);

                totalcdramt += Convert.ToDecimal(lblcdramount.Text);

                cdramountinr += Convert.ToDecimal(lblcdramountallinr.Text);
                gap += Convert.ToDecimal(lblgap.Text);

                ret_incharge += Convert.ToDecimal(lblret_incharge.Text);
                ret_outcharge += Convert.ToDecimal(lblret_outcharge.Text);
                ret_inchargeINR += Convert.ToDecimal(lblret_incharge_inr.Text);
                ret_outchargeINR += Convert.ToDecimal(lblret_outcharge_inr.Text);

                totallineswhs += Convert.ToInt32(lbltotallineswhs.Text);
                whole_incharge += Convert.ToDecimal(lblwhole_incharge.Text);
                whole_outcharge += Convert.ToDecimal(lblwhole_outcharge.Text);
                whole_inchargeINR += Convert.ToDecimal(lblwhole_incharge_inr.Text);
                whole_outchargeINR += Convert.ToDecimal(lblwhole_outcharge_inr.Text);


                tot_outchargefx += Convert.ToDecimal(lbltot_outchargefx.Text);
                tot_outchargeINR += Convert.ToDecimal(lbltot_outchargeINR.Text);



                revinvoiceamt += Convert.ToDecimal(lblrevinvoiceamount.Text);
                revinvoiceamountinr += Convert.ToDecimal(lblrevinvoiceamountinr.Text);

                totbillingamt += Convert.ToDecimal(lbltotalbilling.Text);
                totalbillinginr += Convert.ToDecimal(lbltotalbillinginr.Text);
               // grossrevFX += Convert.ToDecimal(lblgrossrevfx.Text);
                grossrevINR += Convert.ToDecimal(lblgrossrevinr.Text);

                totalcramount += Convert.ToDecimal(lblcreditnote.Text);
                totalcramountinr += Convert.ToDecimal(lblcreditnoteinr.Text);
                

                #endregion
            }
            #endregion

            #region Footer Section
            if (e.Item.ItemType == ListItemType.Footer)
            {
               // HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramtfooter");
               // cell.Visible = false;

                Label lblgrandtot = (Label)e.Item.FindControl("lblgrandtot");
                Label lblinvoiceamountot = (Label)e.Item.FindControl("lblinvoiceamountot");
                Label lbllinestot = (Label)e.Item.FindControl("lbllinestot");
                

                Label lblinvoiceamouninrtot = (Label)e.Item.FindControl("lblinvoiceamouninrtot");
                Label lblcdramounttot = (Label)e.Item.FindControl("lblcdramounttot");
                Label lblcdramountinrtot = (Label)e.Item.FindControl("lblcdramountinrtot");
                
                Label lblgaptot = (Label)e.Item.FindControl("lblgaptot");
                // Retailer
                Label lblret_inchargetot = (Label)e.Item.FindControl("lblret_inchargetot");
                Label lblret_outchargetot = (Label)e.Item.FindControl("lblret_outchargetot");
                Label lblret_incharge_inrtot = (Label)e.Item.FindControl("lblret_incharge_inrtot");
                Label lblret_outcharge_inrtot = (Label)e.Item.FindControl("lblret_outcharge_inrtot");

                //wholesaler

                Label lbllineswhstot = (Label)e.Item.FindControl("lbllineswhstot");
                Label lblwhole_inchargetot = (Label)e.Item.FindControl("lblwhole_inchargetot");
                Label lblwhole_outchargetot = (Label)e.Item.FindControl("lblwhole_outchargetot");
                Label lblwhole_incharge_inrtot = (Label)e.Item.FindControl("lblwhole_incharge_inrtot");
                Label lblwhole_outcharge_inrtot = (Label)e.Item.FindControl("lblwhole_outcharge_inrtot");

                //Total
                Label lbltot_outchargefxtot = (Label)e.Item.FindControl("lbltot_outchargefxtot");
                Label lbltot_outchargeINRtot = (Label)e.Item.FindControl("lbltot_outchargeINRtot");
               

                //Invoice
                Label lblrevinvamount = (Label)e.Item.FindControl("lblrevinvamount");
                Label lblrevinvamountinr = (Label)e.Item.FindControl("lblrevinvamountinr");
                
                Label lbltotalbilltot = (Label)e.Item.FindControl("lbltotalbilltot");
                Label lbltotalbillinrtot = (Label)e.Item.FindControl("lbltotalbillinrtot");
                
               // Label lblgrossrevfxtot = (Label)e.Item.FindControl("lblgrossrevfxtot");
                Label lblgrossrevINRtot = (Label)e.Item.FindControl("lblgrossrevINRtot");

                if (Convert.ToInt32(Session["UserID"]) == 385)
                {

                    lblinvoiceamountot.Text = invoiceamount.ToString();
                    lblinvoiceamouninrtot.Text = invoiceamountinr.ToString();
                    lbllinestot.Text = totallines.ToString();
                    lblcdramounttot.Text = totalcdramt.ToString();
                    lblcdramountinrtot.Text = cdramountinr.ToString();
                    lblgaptot.Text = gap.ToString();

                    lblret_inchargetot.Text = ret_incharge.ToString();
                    lblret_outchargetot.Text = ret_outcharge.ToString();
                    lblret_incharge_inrtot.Text = ret_inchargeINR.ToString();
                    lblret_outcharge_inrtot.Text = ret_outchargeINR.ToString();

                    lbllineswhstot.Text = totallineswhs.ToString();
                    lblwhole_inchargetot.Text = whole_incharge.ToString();
                    lblwhole_outchargetot.Text = whole_outcharge.ToString();
                    lblwhole_incharge_inrtot.Text = whole_inchargeINR.ToString();
                    lblwhole_outcharge_inrtot.Text = whole_outchargeINR.ToString();


                    lbltot_outchargefxtot.Text = tot_outchargefx.ToString();
                    lbltot_outchargeINRtot.Text = tot_outchargeINR.ToString();



                    lblrevinvamount.Text = revinvoiceamt.ToString();
                    lblrevinvamountinr.Text = revinvoiceamountinr.ToString();
                    lbltotalbilltot.Text = totbillingamt.ToString();
                    lbltotalbillinrtot.Text = totalbillinginr.ToString();
                    //   lblgrossrevfxtot.Text = grossrevFX.ToString();
                    lblgrossrevINRtot.Text = grossrevINR.ToString();


                    //HtmlTableCell tdlblgrossrevINRtot = (HtmlTableCell)e.Item.FindControl("tdlblgrossrevINRtot");
                    //if (Convert.ToInt32(Session["UserID"]) == 385)
                    //{

                    //    tdlblgrossrevINRtot.Visible = true;
                    //}
                    //else
                    //{
                    //    tdlblgrossrevINRtot.Visible = false;
                    //}

                }
                else
                {
                    lblgrandtot.Visible = false;
                    lblinvoiceamountot.Visible = false;
                    lbllinestot.Visible = false;
                    lblinvoiceamouninrtot.Visible = false;
                    lblcdramounttot.Visible = false;
                    lblcdramountinrtot.Visible = false;
                    lblgaptot.Visible = false;

                    lblret_inchargetot.Visible = false;
                    lblret_outchargetot.Visible = false;
                    lblret_incharge_inrtot.Visible = false;
                    lblret_outcharge_inrtot.Visible = false;

                    lbllineswhstot.Visible = false;
                    lblwhole_inchargetot.Visible = false;
                    lblwhole_outchargetot.Visible = false;
                    lblwhole_incharge_inrtot.Visible = false;
                    lblwhole_outcharge_inrtot.Visible = false;


                    lbltot_outchargefxtot.Visible = false;
                    lbltot_outchargeINRtot.Visible = false;



                    lblrevinvamount.Visible = false;
                    lblrevinvamountinr.Visible = false;
                    lbltotalbilltot.Visible = false;
                    lbltotalbillinrtot.Visible = false;
                    //   lblgrossrevfxtot.Text = grossrevFX.ToString();
                    lblgrossrevINRtot.Visible = false;
                }

            }
            #endregion
        }
        catch (Exception ex)
        {
            return;
        }
    }
    protected void RAFRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
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
            string url = "CDR_invoicerpt_sub1.aspx?groupid=" + groupid + "&fromdate=" + from + "&todate=" + to;
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=300,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=no,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
        }
        else if (e.CommandName == "activeline")
        {
            lnkblackberry.Text = string.Empty;
            lnkdata.Text=string.Empty;
            LinkButton lnkprovider = (LinkButton)e.Item.FindControl("lnkprovider");
            Label lblbillingmonth = (Label)e.Item.FindControl("lblbillingmonth");
            DataSet ds_service = new DataSet();
            DateTime dt_time = new DateTime();
            string todate = string.Empty;
            dt_time = Convert.ToDateTime(from);
            dt_time = dt_time.AddMonths(1);
            dt_time = dt_time.AddDays(-1);

            todate = Convert.ToDateTime(dt_time).ToString("yyyy-MM-dd");
            obj = new invoicermaster();
            ds_service = obj.GetServiceinfo(Convert.ToInt32(lnkprovider.CommandArgument), 1, 0, from, todate);
            if (ds_service.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_service.Tables[0].Rows)
                {
                    if (dr["service"].ToString() == "Data Service")
                    {
                        lnkdata.Text = dr["total"].ToString();
                        lnkdata.CommandArgument = lnkprovider.CommandArgument; //ds_service.Tables[0].Rows[0]["serviceid"].ToString();
                    }
                    else
                    {
                        lnkblackberry.Text = dr["total"].ToString();
                        lnkblackberry.CommandArgument = lnkprovider.CommandArgument;// ds_service.Tables[0].Rows[0]["serviceid"].ToString();
                    }
                    
                    tblservice.Visible = true;
                    lnkblackberry.Visible = true;
                    lbldat2_2.Text = from;
                    lnkdata.Visible = true;
                    pnlBranch.Visible = true;
                    Popup(true);
                    lblHeader.Text = string.Empty;
                }
                lbldivprovider.Text = lnkprovider.Text;
                lbldate.Text = lblbillingmonth.Text;
                if (lnkblackberry.Text == string.Empty)
                    lnkblackberry.Text = "0";
                if (lnkdata.Text == string.Empty)
                    lnkdata.Text = "0";
            }
            else
            {
                tblservice.Visible = false;
                lblHeader.Text = "No Record Found";
                pnlBranch.Visible = true;
                Popup(true);
                
            }
        }
      //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success",
                               //     "DI('" + groupid.ToString() + "','" + from.ToString() + "','" + to.ToString() + "');", true);
    }
    void Popup(bool isDisplay)
    {
        StringBuilder builder = new StringBuilder();
        if (isDisplay)
        {
            builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
        }
        else
        {
            builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
        }
    }
    void Popup2(bool isDisplay)
    {
        StringBuilder builder = new StringBuilder();
        if (isDisplay)
        {
            builder.Append("<script language=JavaScript> ShowPopup2(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup2", builder.ToString());
        }
        else
        {
            builder.Append("<script language=JavaScript> HidePopup2(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup2", builder.ToString());
        }
    }
    protected void lnkdata_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lnkdata.Text) > 0)
        {
             string todate = string.Empty;
            string from = string.Empty;
            from = lbldat2_2.Text;
            DateTime dt_time = new DateTime();
            dt_time = Convert.ToDateTime(from);
            dt_time = dt_time.AddMonths(1);
            dt_time = dt_time.AddDays(-1);
            todate = Convert.ToDateTime(dt_time).ToString("yyyy-MM-dd");
            obj = new invoicermaster();
            DataSet ds_servicedetail;
            ds_servicedetail = obj.GetServiceinfo(Convert.ToInt32(lnkdata.CommandArgument), 2, 5, from, todate);
            if (ds_servicedetail.Tables[0].Rows.Count > 0)
            {
                grdservice.DataSource = ds_servicedetail.Tables[0];
                grdservice.DataBind();
                pnlBranch2.Visible = true;
                Popup2(true);
                lblheader2.Text = string.Empty;
                lblprovidersdet.Text = lbldivprovider.Text;
                lbldatesdet.Text = lbldate.Text;
            }
            else
            {
                lblheader2.Text = "No Record Found";
                pnlBranch.Visible = true;
                Popup2(true);
                grdservice.DataSource = null;
                grdservice.DataBind();
            }
        }
        else
        {
            lblheader2.Text = "No Record Found";
            pnlBranch.Visible = true;
            Popup2(true);
            grdservice.DataSource = null;
            grdservice.DataBind();
        }
           
            
        
    }
    protected void lnkblackberry_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lnkblackberry.Text) > 0)
        {
            string todate = string.Empty;
            string from = string.Empty;
            from = lbldat2_2.Text;
            DateTime dt_time = new DateTime();
            dt_time = Convert.ToDateTime(from);
            dt_time = dt_time.AddMonths(1);
            dt_time = dt_time.AddDays(-1);
            todate = Convert.ToDateTime(dt_time).ToString("yyyy-MM-dd");
            obj = new invoicermaster();
            DataSet ds_servicedetail;
            ds_servicedetail = obj.GetServiceinfo(Convert.ToInt32(lnkdata.CommandArgument), 2, 4,from,todate);
            if (ds_servicedetail.Tables[0].Rows.Count > 0)
            {
                grdservice.DataSource = ds_servicedetail.Tables[0];
                grdservice.DataBind();
                pnlBranch2.Visible = true;
                Popup2(true);
                lblheader2.Text = string.Empty;
            }
            else
            {
                lblheader2.Text = "No Record Found";
                pnlBranch.Visible = true;
                Popup2(true);
                grdservice.DataSource = null;
                grdservice.DataBind();
            }
        }
        else
        {
            lblheader2.Text = "No Record Found";
            pnlBranch.Visible = true;
            Popup2(true);
            grdservice.DataSource = null;
            grdservice.DataBind();
        }
           
            
    }
    protected void grdinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region Item Section
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblbillingmonth = (Label)e.Row.FindControl("lblbillingmonth");

            //HtmlTableCell tdpro = (HtmlTableCell)e.Row.FindControl("tdpro");

            //tdpro.Attributes.Add("class", "locked");
            Label lblinvoiceamount = (Label)e.Row.FindControl("lblinvoiceamount");
            Label lblinvoiceamountinr = (Label)e.Row.FindControl("lblinvoiceamountinr");
            Label lbltotallines = (Label)e.Row.FindControl("lbltotallines");
            Label lblcdramount = (Label)e.Row.FindControl("lblcdramount");
            Label lblcdramountallinr = (Label)e.Row.FindControl("lblcdramountallinr");
            Label lblgap = (Label)e.Row.FindControl("lblgap");
            HtmlTableCell tdgap = (HtmlTableCell)e.Row.FindControl("tdgap");
           
            if (Convert.ToDecimal(lblgap.Text) > 0)
            {
                tdgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblgap.ForeColor = System.Drawing.Color.White;
                //.BgColor = "Green";
                
                //e.Row.Cells[0].BackColor = Color.Green;
               // e.Row.Cells[0].ForeColor = Color.White;             
                
            }
            else
            {
                tdgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblgap.ForeColor = System.Drawing.Color.White;
                //tdgap.BgColor = "Red";
              //  e.Row.Cells[7].BackColor = Color.Red;
               // e.Row.Cells[7].ForeColor = Color.White;
            }
            // Retailer
            Label lblret_incharge = (Label)e.Row.FindControl("lblret_incharge");
            Label lblret_outcharge = (Label)e.Row.FindControl("lblret_outcharge");
            Label lblret_incharge_inr = (Label)e.Row.FindControl("lblret_incharge_inr");
            HtmlTableCell ret_in = (HtmlTableCell)e.Row.FindControl("ret_in");
            if (Convert.ToDecimal(lblret_incharge_inr.Text) > 0)
            {
                ret_in.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblret_incharge_inr.ForeColor = System.Drawing.Color.White;
               // e.Row.Cells[13].BackColor = Color.Green;
               // e.Row.Cells[13].ForeColor = Color.White;                  
            }
            else
            {
                ret_in.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblret_incharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[13].BackColor = Color.Red;
               // e.Row.Cells[13].ForeColor = Color.White;                   
            }
            Label lblret_outcharge_inr = (Label)e.Row.FindControl("lblret_outcharge_inr");
            HtmlTableCell ret_out = (HtmlTableCell)e.Row.FindControl("ret_out");
            if (Convert.ToDecimal(lblret_outcharge_inr.Text) > 0)
            {
                ret_out.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblret_outcharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[14].BackColor = Color.Green;
                //e.Row.Cells[14].ForeColor = Color.White;                    
            }
            else
            {
                ret_out.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblret_outcharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[14].BackColor = Color.Red;
                //e.Row.Cells[14].ForeColor = Color.White;    
            }
            //wholesaler
            Label lbltotallineswhs = (Label)e.Row.FindControl("lbltotallineswhs");
            Label lblwhole_incharge = (Label)e.Row.FindControl("lblwhole_incharge");
            Label lblwhole_outcharge = (Label)e.Row.FindControl("lblwhole_outcharge");
            Label lblwhole_incharge_inr = (Label)e.Row.FindControl("lblwhole_incharge_inr");
            HtmlTableCell whole_in = (HtmlTableCell)e.Row.FindControl("whole_in");
            if (Convert.ToDecimal(lblwhole_incharge_inr.Text) > 0)
            {
                whole_in.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblwhole_incharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[18].BackColor = Color.Green;
                //e.Row.Cells[18].ForeColor = Color.White;  
            }
            else
            {
                whole_in.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblwhole_incharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[18].BackColor = Color.Red;
                //e.Row.Cells[18].ForeColor = Color.White;  
            }
            Label lblwhole_outcharge_inr = (Label)e.Row.FindControl("lblwhole_outcharge_inr");
            HtmlTableCell whole_out = (HtmlTableCell)e.Row.FindControl("whole_out");
            if (Convert.ToDecimal(lblwhole_outcharge_inr.Text) > 0)
            {
                whole_out.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblwhole_outcharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[19].BackColor = Color.Green;
                //e.Row.Cells[19].ForeColor = Color.White;  
            }
            else
            {
                whole_out.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblwhole_outcharge_inr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[19].BackColor = Color.Red;
                //e.Row.Cells[19].ForeColor = Color.White;  
            }

            //Total
            Label lbltot_outchargefx = (Label)e.Row.FindControl("lbltot_outchargefx");
            Label lbltot_outchargeINR = (Label)e.Row.FindControl("lbltot_outchargeINR");


            //Revenue
            Label lblrevinvoiceamount = (Label)e.Row.FindControl("lblrevinvoiceamount");
            HtmlTableCell revamt = (HtmlTableCell)e.Row.FindControl("revamt");
            if (Convert.ToDecimal(lblrevinvoiceamount.Text) > 0)
            {
                revamt.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[22].BackColor = Color.Green;
                //e.Row.Cells[22].ForeColor = Color.White; 
            }
            else
            {
                revamt.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[22].BackColor = Color.Red;
                //e.Row.Cells[22].ForeColor = Color.White; 
            }
            Label lblrevinvoiceamountinr = (Label)e.Row.FindControl("lblrevinvoiceamountinr");

            Label lbltotalbilling = (Label)e.Row.FindControl("lbltotalbilling");
            HtmlTableCell revtotbill = (HtmlTableCell)e.Row.FindControl("revtotbill");
            if (Convert.ToDecimal(lbltotalbilling.Text) > 0)
            {
                revtotbill.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lbltotalbilling.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[24].BackColor = Color.Green;
                //e.Row.Cells[24].ForeColor = Color.White;
            }
            else
            {
                revtotbill.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lbltotalbilling.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[24].BackColor = Color.Red;
                //e.Row.Cells[24].ForeColor = Color.White;
            }
            Label lbltotalbillinginr = (Label)e.Row.FindControl("lbltotalbillinginr");


            Label lblgrossrevinr = (Label)e.Row.FindControl("lblgrossrevinr");
            HtmlTableCell revgross = (HtmlTableCell)e.Row.FindControl("revgross");
            if (Convert.ToDecimal(lblgrossrevinr.Text) > 0)
            {
                revgross.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[26].BackColor = Color.Green;
                //e.Row.Cells[26].ForeColor = Color.White;
            }
            else
            {   
                revgross.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                //e.Row.Cells[26].BackColor = Color.Red;
                //e.Row.Cells[26].ForeColor = Color.White;
            }

            Label lblcreditnote = (Label)e.Row.FindControl("lblcreditnote");
            Label lblcreditnoteinr = (Label)e.Row.FindControl("lblcreditnoteinr");
            
            #region Calculation
            invoiceamount += Convert.ToDecimal(lblinvoiceamount.Text);

            invoiceamountinr += Convert.ToDecimal(lblinvoiceamountinr.Text);
            totallines += Convert.ToInt32(lbltotallines.Text);

            totalcdramt += Convert.ToDecimal(lblcdramount.Text);

            cdramountinr += Convert.ToDecimal(lblcdramountallinr.Text);
            gap += Convert.ToDecimal(lblgap.Text);

            ret_incharge += Convert.ToDecimal(lblret_incharge.Text);
            ret_outcharge += Convert.ToDecimal(lblret_outcharge.Text);
            ret_inchargeINR += Convert.ToDecimal(lblret_incharge_inr.Text);
            ret_outchargeINR += Convert.ToDecimal(lblret_outcharge_inr.Text);

            totallineswhs += Convert.ToInt32(lbltotallineswhs.Text);
            whole_incharge += Convert.ToDecimal(lblwhole_incharge.Text);
            whole_outcharge += Convert.ToDecimal(lblwhole_outcharge.Text);
            whole_inchargeINR += Convert.ToDecimal(lblwhole_incharge_inr.Text);
            whole_outchargeINR += Convert.ToDecimal(lblwhole_outcharge_inr.Text);


            tot_outchargefx += Convert.ToDecimal(lbltot_outchargefx.Text);
            tot_outchargeINR += Convert.ToDecimal(lbltot_outchargeINR.Text);



            revinvoiceamt += Convert.ToDecimal(lblrevinvoiceamount.Text);
            revinvoiceamountinr += Convert.ToDecimal(lblrevinvoiceamountinr.Text);

            totbillingamt += Convert.ToDecimal(lbltotalbilling.Text);
            totalbillinginr += Convert.ToDecimal(lbltotalbillinginr.Text);
            // grossrevFX += Convert.ToDecimal(lblgrossrevfx.Text);
            grossrevINR += Convert.ToDecimal(lblgrossrevinr.Text);

            if (lblcreditnote.Text != "") {
                totalcramount += Convert.ToDecimal(lblcreditnote.Text);
            }
            if (lblcreditnoteinr.Text != "") {
                totalcramountinr += Convert.ToDecimal(lblcreditnoteinr.Text);
            } 

            #endregion

        }
        #endregion
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            #region Footer Section
           
                // HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramtfooter");
                // cell.Visible = false;

                Label lblgrandtot = (Label)e.Row.FindControl("lblgrandtot");
                Label lblinvoiceamountot = (Label)e.Row.FindControl("lblinvoiceamountot");
                Label lbllinestot = (Label)e.Row.FindControl("lbllinestot");


                Label lblinvoiceamouninrtot = (Label)e.Row.FindControl("lblinvoiceamouninrtot");
                Label lblcdramounttot = (Label)e.Row.FindControl("lblcdramounttot");
                Label lblcdramountinrtot = (Label)e.Row.FindControl("lblcdramountinrtot");

                Label lblgaptot = (Label)e.Row.FindControl("lblgaptot");
                // Retailer
                Label lblret_inchargetot = (Label)e.Row.FindControl("lblret_inchargetot");
                Label lblret_outchargetot = (Label)e.Row.FindControl("lblret_outchargetot");
                Label lblret_incharge_inrtot = (Label)e.Row.FindControl("lblret_incharge_inrtot");
                Label lblret_outcharge_inrtot = (Label)e.Row.FindControl("lblret_outcharge_inrtot");

                //wholesaler

                Label lbllineswhstot = (Label)e.Row.FindControl("lbllineswhstot");
                Label lblwhole_inchargetot = (Label)e.Row.FindControl("lblwhole_inchargetot");
                Label lblwhole_outchargetot = (Label)e.Row.FindControl("lblwhole_outchargetot");
                Label lblwhole_incharge_inrtot = (Label)e.Row.FindControl("lblwhole_incharge_inrtot");
                Label lblwhole_outcharge_inrtot = (Label)e.Row.FindControl("lblwhole_outcharge_inrtot");

                //Total
                Label lbltot_outchargefxtot = (Label)e.Row.FindControl("lbltot_outchargefxtot");
                Label lbltot_outchargeINRtot = (Label)e.Row.FindControl("lbltot_outchargeINRtot");


                //Invoice
                Label lblrevinvamount = (Label)e.Row.FindControl("lblrevinvamount");
                Label lblrevinvamountinr = (Label)e.Row.FindControl("lblrevinvamountinr");

                Label lbltotalbilltot = (Label)e.Row.FindControl("lbltotalbilltot");
                Label lbltotalbillinrtot = (Label)e.Row.FindControl("lbltotalbillinrtot");

                // Label lblgrossrevfxtot = (Label)e.Item.FindControl("lblgrossrevfxtot");
                Label lblgrossrevINRtot = (Label)e.Row.FindControl("lblgrossrevINRtot");

                Label lblgrosscreditnote = (Label)e.Row.FindControl("lblgrosscreditnote");
                Label lblgrosscreditnoteinr = (Label)e.Row.FindControl("lblgrosscreditnoteinr");

                Label lblgrossPer = (Label)e.Row.FindControl("lblgrossPer");
                

            //Rights to G Sir - 385, Bade Sir - 149, Jatin - 365 , Shams-368
                if ((Convert.ToInt32(Session["UserID"]) == 385) || (Convert.ToInt32(Session["UserID"]) == 368) || (Convert.ToInt32(Session["UserID"]) == 149) || (Convert.ToInt32(Session["UserID"]) == 365))
                {

                    lblinvoiceamountot.Text = invoiceamount.ToString();
                    lblinvoiceamouninrtot.Text = invoiceamountinr.ToString();
                    lbllinestot.Text = totallines.ToString();
                    lblcdramounttot.Text = totalcdramt.ToString();
                    lblcdramountinrtot.Text = cdramountinr.ToString();
                    lblgaptot.Text = gap.ToString();

                    lblret_inchargetot.Text = ret_incharge.ToString();
                    lblret_outchargetot.Text = ret_outcharge.ToString();
                    lblret_incharge_inrtot.Text = ret_inchargeINR.ToString();
                    lblret_outcharge_inrtot.Text = ret_outchargeINR.ToString();

                    lbllineswhstot.Text = totallineswhs.ToString();
                    lblwhole_inchargetot.Text = whole_incharge.ToString();
                    lblwhole_outchargetot.Text = whole_outcharge.ToString();
                    lblwhole_incharge_inrtot.Text = whole_inchargeINR.ToString();
                    lblwhole_outcharge_inrtot.Text = whole_outchargeINR.ToString();


                    lbltot_outchargefxtot.Text = tot_outchargefx.ToString();
                    lbltot_outchargeINRtot.Text = tot_outchargeINR.ToString();



                    lblrevinvamount.Text = revinvoiceamt.ToString();
                    lblrevinvamountinr.Text = revinvoiceamountinr.ToString();
                    lbltotalbilltot.Text = totbillingamt.ToString();
                    lbltotalbillinrtot.Text = totalbillinginr.ToString();
                    //   lblgrossrevfxtot.Text = grossrevFX.ToString();
                    lblgrossrevINRtot.Text = grossrevINR.ToString();
                    lblgrosscreditnote.Text = totalcramount.ToString();
                    lblgrosscreditnoteinr.Text = totalcramountinr.ToString();

                    if (totalbillinginr > 0) {
                        lblgrossPer.Text = Math.Round((grossrevINR / totalbillinginr) * 100, 0).ToString() + " %";
                    }

                    

                }
                else
                {
                    lblgrandtot.Visible = false;
                    lblinvoiceamountot.Visible = false;
                    lbllinestot.Visible = false;
                    lblinvoiceamouninrtot.Visible = false;
                    lblcdramounttot.Visible = false;
                    lblcdramountinrtot.Visible = false;
                    lblgaptot.Visible = false;

                    lblret_inchargetot.Visible = false;
                    lblret_outchargetot.Visible = false;
                    lblret_incharge_inrtot.Visible = false;
                    lblret_outcharge_inrtot.Visible = false;

                    lbllineswhstot.Visible = false;
                    lblwhole_inchargetot.Visible = false;
                    lblwhole_outchargetot.Visible = false;
                    lblwhole_incharge_inrtot.Visible = false;
                    lblwhole_outcharge_inrtot.Visible = false;


                    lbltot_outchargefxtot.Visible = false;
                    lbltot_outchargeINRtot.Visible = false;



                    lblrevinvamount.Visible = false;
                    lblrevinvamountinr.Visible = false;
                    lbltotalbilltot.Visible = false;
                    lbltotalbillinrtot.Visible = false;
                    //   lblgrossrevfxtot.Text = grossrevFX.ToString();
                    lblgrossrevINRtot.Visible = false;
                    lblgrosscreditnote.Visible = false;
                    lblgrosscreditnoteinr.Visible = false;
                    lblgrossPer.Visible = false;
                }

            
            #endregion
        }
    }
    protected void grdinvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string from = string.Empty;
        string to = string.Empty;
        // DateTime abc;
        GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        //int index = Convert.ToInt32(e.CommandArgument.ToString());
        Label lblfrommmonth = (Label)gvRow.FindControl("lblbillmonth22");
        from = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");
        to = Convert.ToDateTime(lblfrommmonth.Text).ToString("yyyy-MM-dd");

        if (e.CommandName == "groupname")
        {
           
            string groupid = e.CommandArgument.ToString();
            string url = "CDR_invoicerpt_sub1.aspx?groupid=" + groupid + "&fromdate=" + from + "&todate=" + to;
            Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=300,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=yes,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
        }
        else if (e.CommandName == "activeline")
        {
            lnkblackberry.Text = string.Empty;
            lnkdata.Text = string.Empty;
            LinkButton lnkprovider = (LinkButton)gvRow.FindControl("lnkprovider");
            Label lblbillingmonth = (Label)gvRow.FindControl("lblbillingmonth");
            DataSet ds_service = new DataSet();
            DateTime dt_time = new DateTime();
            string todate = string.Empty;
            dt_time = Convert.ToDateTime(from);
            dt_time = dt_time.AddMonths(1);
            dt_time = dt_time.AddDays(-1);

            todate = Convert.ToDateTime(dt_time).ToString("yyyy-MM-dd");
            obj = new invoicermaster();
            ds_service = obj.GetServiceinfo(Convert.ToInt32(lnkprovider.CommandArgument), 1, 0, from, todate);
            if (ds_service.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_service.Tables[0].Rows)
                {
                    if (dr["service"].ToString() == "Data Service")
                    {
                        lnkdata.Text = dr["total"].ToString();
                        lnkdata.CommandArgument = lnkprovider.CommandArgument; //ds_service.Tables[0].Rows[0]["serviceid"].ToString();
                    }
                    else
                    {
                        lnkblackberry.Text = dr["total"].ToString();
                        lnkblackberry.CommandArgument = lnkprovider.CommandArgument;// ds_service.Tables[0].Rows[0]["serviceid"].ToString();
                    }

                    tblservice.Visible = true;
                    lnkblackberry.Visible = true;
                    lbldat2_2.Text = from;
                    lnkdata.Visible = true;
                    pnlBranch.Visible = true;
                    Popup(true);
                    lblHeader.Text = string.Empty;
                }
                lbldivprovider.Text = lnkprovider.Text;
                lbldate.Text = lblbillingmonth.Text;
                if (lnkblackberry.Text == string.Empty)
                    lnkblackberry.Text = "0";
                if (lnkdata.Text == string.Empty)
                    lnkdata.Text = "0";
            }
            else
            {
                tblservice.Visible = false;
                lblHeader.Text = "No Record Found";
                pnlBranch.Visible = true;
                Popup(true);

            }
        }
    }
    protected void grdinvoice_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.Text = "baba";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Retailer";
        //    HeaderCell.ColumnSpan = 5;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Wholesaler";
        //    HeaderCell.ColumnSpan = 5;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Total";
        //    HeaderCell.ColumnSpan = 2;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "Revenue Lookup";
        //    HeaderCell.ColumnSpan = 5;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    grdinvoice.Controls[0].Controls.AddAt(0, HeaderGridRow);

 

        //}
    }


}