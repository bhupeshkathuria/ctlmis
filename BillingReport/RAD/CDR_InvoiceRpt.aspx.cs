using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

using System.IO;
using System.Web.UI.HtmlControls;
using Clay.RAD;
public partial class CDR_InvoiceReport : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicermaster obj = new invoicermaster();
    provider objProvider;
    //Country objcnt;
    //Provider objProvider;
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
                billingMonthfrom = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                billingMonthto = ddlyear.SelectedValue + "-" + ddlmonth.SelectedValue + "-01";
                //if (ddlmonth.SelectedValue == "1")
                //{
                //    month = 12;
                //    billingMonth = ddlyear.SelectedValue + "-" + month + "-01";
                //}
                //else
                //{
                //    month =Convert.ToInt32(ddlmonth.SelectedValue);
                //    month = month - 1;
                //    billingMonth = ddlyear.SelectedValue + "-" + month + "-01";
                //}
            }
            else
            {
                billingMonthfrom = DateTime.Now.Year.ToString() + "-04" + "-01";
                billingMonthto = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            }
        }
        catch { }

        try
        {

            dsReport = obj.GetInvoiceCDRInvoicerpt9(providerid, countryID, billingMonthfrom, billingMonthto);
            DataTable dtreport = new DataTable();
            dtreport = dsReport.Tables[0].Clone();
            bool _exist = false;
            string _existval = string.Empty;
            string _newval = string.Empty;
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {
               // foreach (DataRow dr in dsReport.Tables[0].Rows)
               // {
               //     _newval = dr["Network"].ToString();
               //     _newmonth = dr["BillingMonth"].ToString();
               //     if (_existval == _newval)
               //     {
               //         dr["Network"] = string.Empty;
               //     }
               //     else
               //     {

               //     }                   
               //     _existval = _newval;               
                   
               //     dsReport.Tables[0].AcceptChanges();
               //}
                

            }
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                RAFRepeater.DataSource = dsReport.Tables[0];
                RAFRepeater.DataBind();
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
        if(RAFRepeater.Items.Count>0)
        {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter str = new StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);
        //  RAFRepeater.AllowPaging = false;
        //BindVehicleGrid();
        RAFRepeater.RenderControl(HtmlTextWriter);
        Response.Write(str.ToString());
        Response.End();
        }

    }

    #region Varibles
    decimal invoiceamount = 0;
    decimal totalcdramt = 0;
    decimal gap = 0;

    decimal ret_incharge = 0;
    decimal ret_outcharge = 0;
    decimal ret_inchargeINR = 0;
    decimal ret_outchargeINR = 0;

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
    #endregion

    protected void RAFRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        try
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell tdgrossrevheader = (HtmlTableCell)e.Item.FindControl("tdgrossrevheader");
                if (Convert.ToInt32(Session["UserID"]) == 385)
                {
                    
                    tdgrossrevheader.Visible = true;
                }
                else
                {
                    tdgrossrevheader.Visible = false;
                }
            }
            #region Item Section
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramt");
               // cell.Visible = false;
                Label lblinvoiceamount = (Label)e.Item.FindControl("lblinvoiceamount");

                Label lblinvoiceamountinr = (Label)e.Item.FindControl("lblinvoiceamountinr");

                Label lblcdramount = (Label)e.Item.FindControl("lblcdramount");
                Label lblcdramountallinr = (Label)e.Item.FindControl("lblcdramountallinr");
                Label lblgap = (Label)e.Item.FindControl("lblgap");
                HtmlTableCell tdlblgap = (HtmlTableCell)e.Item.FindControl("tdlblgap");
                if (Convert.ToDecimal(lblgap.Text) > 0)
                {
                    

                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                   
                    //lblgap.BackColor = System.Drawing.Color.Green;
                    lblgap.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                   // lblgap.BackColor = System.Drawing.Color.Red;
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
                
               // Label lblgrossrevfx = (Label)e.Item.FindControl("lblgrossrevfx");
                //if (Convert.ToDecimal(lblgrossrevfx.Text) > 0)
                //{
                //    lblgrossrevfx.BackColor = System.Drawing.Color.Green;
                //}
                //else
                //{
                //    lblgrossrevfx.BackColor = System.Drawing.Color.Red;
                //}
                Label lblgrossrevinr = (Label)e.Item.FindControl("lblgrossrevinr");
                HtmlTableCell tdlblgrossrevinr = (HtmlTableCell)e.Item.FindControl("tdlblgrossrevinr");
                if (Convert.ToDecimal(lblgrossrevinr.Text) > 0)
                {
                    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                    //lblgrossrevinr.BackColor = System.Drawing.Color.Green;
                    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                    //lblgrossrevinr.BackColor = System.Drawing.Color.Red;
                    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                }
                if (Convert.ToInt32(Session["UserID"]) == 385)
                {

                    tdlblgrossrevinr.Visible = true;
                }
                else
                {
                    tdlblgrossrevinr.Visible = false;
                }
                #region Calculation
                invoiceamount += Convert.ToDecimal(lblinvoiceamount.Text);

                invoiceamountinr += Convert.ToDecimal(lblinvoiceamountinr.Text);

                totalcdramt += Convert.ToDecimal(lblcdramount.Text);

                cdramountinr += Convert.ToDecimal(lblcdramountallinr.Text);
                gap += Convert.ToDecimal(lblgap.Text);

                ret_incharge += Convert.ToDecimal(lblret_incharge.Text);
                ret_outcharge += Convert.ToDecimal(lblret_outcharge.Text);
                ret_inchargeINR += Convert.ToDecimal(lblret_incharge_inr.Text);
                ret_outchargeINR += Convert.ToDecimal(lblret_outcharge_inr.Text);


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

                #endregion
            }
            #endregion

            #region Footer Section
            if (e.Item.ItemType == ListItemType.Footer)
            {
               // HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramtfooter");
               // cell.Visible = false;
                Label lblinvoiceamountot = (Label)e.Item.FindControl("lblinvoiceamountot");

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
                

                lblinvoiceamountot.Text = invoiceamount.ToString();
                lblinvoiceamouninrtot.Text = invoiceamountinr.ToString();
                lblcdramounttot.Text = totalcdramt.ToString();
                lblcdramountinrtot.Text = cdramountinr.ToString();
                lblgaptot.Text = gap.ToString();

                lblret_inchargetot.Text = ret_incharge.ToString();
                lblret_outchargetot.Text = ret_outcharge.ToString();
                lblret_incharge_inrtot.Text = ret_inchargeINR.ToString();
                lblret_outcharge_inrtot.Text = ret_outchargeINR.ToString();


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

                HtmlTableCell tdlblgrossrevINRtot = (HtmlTableCell)e.Item.FindControl("tdlblgrossrevINRtot");
                if (Convert.ToInt32(Session["UserID"]) == 385)
                {

                    tdlblgrossrevINRtot.Visible = true;
                }
                else
                {
                    tdlblgrossrevINRtot.Visible = false;
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
        string groupid = e.CommandArgument.ToString() ;
		string url = "CDR_invoicerpt_sub1.aspx?groupid=" + groupid + "&fromdate=" + from + "&todate=" + to;
        Response.Write("<script language='javascript'> window.open('" + url + "', 'window','HEIGHT=300,WIDTH=900,top=50,left=50,toolbar=yes,scrollbars=no,resizable=nolocation=0,directories=0,status=1,menubar=0,copyhistory=0');</script>");
      //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success",
                               //     "DI('" + groupid.ToString() + "','" + from.ToString() + "','" + to.ToString() + "');", true);
    }
}