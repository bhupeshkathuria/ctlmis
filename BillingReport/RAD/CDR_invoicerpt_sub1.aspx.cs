using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Clay.RAD;
using System.IO;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

public partial class CDR_invoicerpt_sub1 : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicermaster obj = new invoicermaster();
    
   
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

    public DataTable GetBusTypeMonthlySale(int Year, short Month)
    {
        string connectionString = @"server=119.9.95.40\SQLEXPRESS;uid=sa;pwd=f@LC0N#S@!25@(;Initial Catalog=Clay.Prepaid;Timeout=600;";


        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("getBusTypeMonthlySale", new SqlConnection(connectionString));
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@year", Year));
        cmd.Parameters.Add(new SqlParameter("@month", Month));
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        return dt;

    }
    protected void bindInvoiceRevenue(int groupproviderid, string fromdate, string todate)
    {
        int countryID = 0;
        int providerid = 0;
        string billingMonthfrom = string.Empty;
        string billingMonthto = string.Empty;
        //int month = 0;


        try
        {

            dsReport = obj.GetInvoiceCDRInvoicerptsubreport_2new(groupproviderid, fromdate, todate);
            DataTable dtreport = new DataTable();
            dtreport = dsReport.Tables[0].Clone();
            bool _exist = false;
            //string _existval = string.Empty;
            //string _newval = string.Empty;
            //string _newmonth = string.Empty;
            //string _existmonth = string.Empty;
            //string _neinv = string.Empty;
            //string _existinv = string.Empty;
            //string _newinvamt = string.Empty;
            //string _existinvamt = string.Empty;
            //if (dsReport.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dsReport.Tables[0].Rows)
            //    {
            //        _newval = dr["Network"].ToString();
            //        _newmonth = dr["BillingMonth"].ToString();
            //        _neinv = dr["invoiceamount"].ToString();
            //        _newinvamt = dr["invoiceamountinr"].ToString();
            //        if (_existval == _newval)
            //        {
            //            dr["Network"] = string.Empty;
            //        }
            //        else
            //        {

            //        }
            //        if (_existmonth == _newmonth)
            //        {
            //            dr["BillingMonth"] = string.Empty;
            //        }
            //        else
            //        {

            //        }

            //        if (_existinv == _neinv)
            //        {
            //            dr["invoiceamount"] = 0.00;
            //           // dr["invoiceamount"] =Convert.ToDouble(dr["invoiceamount"].ToString().Replace(_neinv, " "));
            //        }
            //        else
            //        {

            //        }

            //        if (_existinvamt == _newinvamt)
            //        {
            //            dr["invoiceamountinr"] = string.Empty;
            //        }
            //        else
            //        {

            //        }
            //        _existval = _newval;
            //        _existmonth = _newmonth;
            //        _existinv = _neinv;
            //        _existinvamt = _newinvamt;

            //        dsReport.Tables[0].AcceptChanges();
            //    }


            //}
            #region Prepaid
            DataTable dtprepaid = new DataTable();
            int month = 0;
            int year = 0;
            month = Convert.ToInt32(Convert.ToDateTime(fromdate).Month);
            year = Convert.ToInt32(Convert.ToDateTime(fromdate).Year);
            DataSet ds_grppro = new DataSet();
            decimal _amountinr = 0;
            decimal _grosrefinr = 0;
            decimal invamount = 0;
            decimal invfx = 0;
            decimal totalrechargeamt = 0;
            int i = 0;
            dtprepaid = GetBusTypeMonthlySale(year, Convert.ToInt16(month));
            MySqlConnection mycon = new MySqlConnection(@"server=ctmydbindea.claytelecom.com;user id=billing;Password=U7jchYdB;database=InvoiceRevenue;default command timeout=3200;pooling=true");
            System.Threading.Thread.Sleep(100);
            if (mycon.State == ConnectionState.Closed)
                mycon.Open();
            if (dtprepaid != null || dtprepaid.Rows.Count > 0)
            {
                foreach (DataRow dr in dtprepaid.Rows) {
                    ds_grppro.Reset();
                    MySqlCommand mycmd = new MySqlCommand("sp_select_invoice_prepaid", mycon);
                    mycmd.CommandType = CommandType.StoredProcedure;
                    mycmd.Parameters.Add(new MySqlParameter("lprepaidid", Convert.ToInt32(dr["bustypeid"])));
                    mycmd.Parameters.Add(new MySqlParameter("dfromdate", fromdate));
                    mycmd.Parameters.Add(new MySqlParameter("ctodate", fromdate));
                    MySqlDataAdapter adppro = new MySqlDataAdapter(mycmd);
                    adppro.Fill(ds_grppro);

                    if (dr["bustypeid"].ToString() == "10") {
                        string x = dr["bustypeid"].ToString();
                    }
                    totalrechargeamt = (Convert.ToDecimal(dr["ActivationAmount"]) + Convert.ToDecimal(dr["RechargeAmount"]));

                    if (ds_grppro.Tables[1].Rows.Count > 0) {
                        _amountinr = (Convert.ToDecimal(ds_grppro.Tables[1].Rows[0]["totalamount"]) * (Convert.ToDecimal(ds_grppro.Tables[1].Rows[0]["fxinr"])));
                        invamount = Convert.ToDecimal(ds_grppro.Tables[1].Rows[0]["totalamount"]);
                        invfx = Convert.ToDecimal(ds_grppro.Tables[1].Rows[0]["fxinr"]);
                    } else {
                        _amountinr = 0;
                        invamount = 0;
                        invfx = 0;
                    }
                    _grosrefinr = (totalrechargeamt - _amountinr);
                    //if (Convert.ToInt32(ds_grppro.Tables[0].Rows[i]["networkcountryid"]) != 0) { //commented by Shams
                    if (ds_grppro.Tables[0].Rows.Count > 0) {
                        if (Convert.ToInt32(ds_grppro.Tables[0].Rows[0]["networkcountryid"]) != 0) {
                            //if (Convert.ToInt32(ds_grppro.Tables[0].Rows[i]["networkcountryid"]) == groupproviderid) { //commented by shams
                            if (Convert.ToInt32(ds_grppro.Tables[0].Rows[0]["networkcountryid"]) == groupproviderid) {
                                DataRow row = dsReport.Tables[0].NewRow();

                                //row["Network"] = ds_grppro.Tables[0].Rows[i]["groupname"].ToString(); //commented by shams
                                row["Network"] = ds_grppro.Tables[0].Rows[0]["groupname"].ToString();
                                row["invoiceamount"] = Convert.ToDouble(invamount);
                                row["invoiceamountinr"] = Convert.ToDouble(_amountinr);
                                row["cdrtotalamount"] = Convert.ToDouble(0);
                                row["cdramountallinr"] = Convert.ToDouble(0);
                                row["fxr"] = Convert.ToDouble(invfx);

                                row["ret_incharge"] = Convert.ToDouble(0);
                                row["ret_outcharge"] = Convert.ToDouble(0);
                                row["ret_incharge_inr"] = Convert.ToDouble(0);
                                row["ret_outchargeinr"] = Convert.ToDouble(totalrechargeamt);

                                row["whole_incharge"] = Convert.ToDouble(0);
                                row["whole_outcharge"] = Convert.ToDouble(0);
                                row["whole_inchargeINR"] = Convert.ToDouble(0);
                                row["whole_outchargeINR"] = Convert.ToDouble(0);

                                row["totaloutfx"] = Convert.ToDouble(0);
                                row["totaloutinr"] = Convert.ToDouble(totalrechargeamt);
                                dsReport.Tables[0].Rows.Add(row);
                                dsReport.Tables[0].AcceptChanges();
                            }
                        }
                    }
                    totalrechargeamt = 0;
                }
            }
            #endregion

            dsReport.Tables[0].AcceptChanges();
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
            string _existval = string.Empty;
            string _newval = string.Empty;
            string _newmonth = string.Empty;
            string _existmonth = string.Empty;
            string _neinv = string.Empty;
            string _existinv = string.Empty;
            string _newinvamt = string.Empty;
            string _existinvamt = string.Empty;
            foreach (RepeaterItem item in RAFRepeater.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblbillingmonth = (Label)item.FindControl("lblbillingmonth");
                    Label lblnetwork = (Label)item.FindControl("lblnetwork");
                    Label lblinvoiceamount = (Label)item.FindControl("lblinvoiceamount");
                    Label lblinvoiceamountinr = (Label)item.FindControl("lblinvoiceamountinr");

                    _newval = lblnetwork.Text;
                    _newmonth = lblbillingmonth.Text;
                    _neinv = lblinvoiceamount.Text;
                    _newinvamt = lblinvoiceamountinr.Text;
                    if (_existval == _newval)
                    {
                        lblnetwork.Text = string.Empty;
                    }
                    else
                    {

                    }
                    if (_existmonth == _newmonth)
                    {
                        lblbillingmonth.Text = string.Empty;
                    }
                    else
                    {

                    }

                    if (_existinv == _neinv)
                    {
                        lblinvoiceamount.Text =string.Empty;
                        // dr["invoiceamount"] =Convert.ToDouble(dr["invoiceamount"].ToString().Replace(_neinv, " "));
                    }
                    else
                    {

                    }

                    if (_existinvamt == _newinvamt)
                    {
                        lblinvoiceamountinr.Text = string.Empty;
                    }
                    else
                    {

                    }
                    _existval = _newval;
                    _existmonth = _newmonth;
                    _existinv = _neinv;
                    _existinvamt = _newinvamt;
                    //Do something with your checkbox...
                    //checkBox.Checked = true;
                }
            }
            


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (RAFRepeater.Items.Count > 0)
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
            //if (e.Item.ItemType == ListItemType.Header)
            //{
            //    HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramtheader");
            //    cell.Visible = false;
            //}
            #region Item Section
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramt");
                // cell.Visible = false;
              //  Label lblinvoiceamount = (Label)e.Item.FindControl("lblinvoiceamount");

             //   Label lblinvoiceamountinr = (Label)e.Item.FindControl("lblinvoiceamountinr");

                Label lblcdramount = (Label)e.Item.FindControl("lblcdramount");
                Label lblcdramountallinr = (Label)e.Item.FindControl("lblcdramountallinr");
                //Label lblgap = (Label)e.Item.FindControl("lblgap");
                //HtmlTableCell tdlblgap = (HtmlTableCell)e.Item.FindControl("tdlblgap");
                //if (Convert.ToDecimal(lblgap.Text) > 0)
                //{


                //    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");

                //    //lblgap.BackColor = System.Drawing.Color.Green;
                //    lblgap.ForeColor = System.Drawing.Color.White;
                //}
                //else
                //{
                //    tdlblgap.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                //    // lblgap.BackColor = System.Drawing.Color.Red;
                //    lblgap.ForeColor = System.Drawing.Color.White;
                //}

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
                //Label lblrevinvoiceamount = (Label)e.Item.FindControl("lblrevinvoiceamount");
                //HtmlTableCell tdlblrevinvoiceamount = (HtmlTableCell)e.Item.FindControl("tdlblrevinvoiceamount");
                //if (Convert.ToDecimal(lblrevinvoiceamount.Text) > 0)
                //{
                //    tdlblrevinvoiceamount.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                //    //lblrevinvoiceamount.BackColor = System.Drawing.Color.Green;
                //    lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                //}
                //else
                //{
                //    tdlblrevinvoiceamount.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                //    //lblrevinvoiceamount.BackColor = System.Drawing.Color.Red;
                //    lblrevinvoiceamount.ForeColor = System.Drawing.Color.White;
                //}
                //Label lblrevinvoiceamountinr = (Label)e.Item.FindControl("lblrevinvoiceamountinr");

                //Label lbltotalbilling = (Label)e.Item.FindControl("lbltotalbilling");
                //HtmlTableCell tdlbltotalbilling = (HtmlTableCell)e.Item.FindControl("tdlbltotalbilling");
                //if (Convert.ToDecimal(lbltotalbilling.Text) > 0)
                //{
                //    tdlbltotalbilling.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                //    // lbltotalbilling.BackColor = System.Drawing.Color.Green;
                //    lbltotalbilling.ForeColor = System.Drawing.Color.White;
                //}
                //else
                //{
                //    tdlbltotalbilling.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                //    // lbltotalbilling.BackColor = System.Drawing.Color.Red;
                //    lbltotalbilling.ForeColor = System.Drawing.Color.White;
                //}
                //Label lbltotalbillinginr = (Label)e.Item.FindControl("lbltotalbillinginr");

               
                //Label lblgrossrevinr = (Label)e.Item.FindControl("lblgrossrevinr");
                //HtmlTableCell tdlblgrossrevinr = (HtmlTableCell)e.Item.FindControl("tdlblgrossrevinr");
                //if (Convert.ToDecimal(lblgrossrevinr.Text) > 0)
                //{
                //    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Green");
                //    //lblgrossrevinr.BackColor = System.Drawing.Color.Green;
                //    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                //}
                //else
                //{
                //    tdlblgrossrevinr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Red");
                //    //lblgrossrevinr.BackColor = System.Drawing.Color.Red;
                //    lblgrossrevinr.ForeColor = System.Drawing.Color.White;
                //}

                #region Calculation
              //  invoiceamount += Convert.ToDecimal(lblinvoiceamount.Text);

              //  invoiceamountinr += Convert.ToDecimal(lblinvoiceamountinr.Text);

                totalcdramt += Convert.ToDecimal(lblcdramount.Text);

                cdramountinr += Convert.ToDecimal(lblcdramountallinr.Text);
                //gap += Convert.ToDecimal(lblgap.Text);

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



               // revinvoiceamt += Convert.ToDecimal(lblrevinvoiceamount.Text);
               // revinvoiceamountinr += Convert.ToDecimal(lblrevinvoiceamountinr.Text);

              //  totbillingamt += Convert.ToDecimal(lbltotalbilling.Text);
             //   totalbillinginr += Convert.ToDecimal(lbltotalbillinginr.Text);
                // grossrevFX += Convert.ToDecimal(lblgrossrevfx.Text);
                //grossrevINR += Convert.ToDecimal(lblgrossrevinr.Text);

                #endregion
            }
            #endregion

            #region Footer Section
            if (e.Item.ItemType == ListItemType.Footer)
            {
                // HtmlTableCell cell = (HtmlTableCell)e.Item.FindControl("tdcdramtfooter");
                // cell.Visible = false;
             //   Label lblinvoiceamountot = (Label)e.Item.FindControl("lblinvoiceamountot");

             //   Label lblinvoiceamouninrtot = (Label)e.Item.FindControl("lblinvoiceamouninrtot");
                Label lblcdramounttot = (Label)e.Item.FindControl("lblcdramounttot");
                Label lblcdramountinrtot = (Label)e.Item.FindControl("lblcdramountinrtot");

                //Label lblgaptot = (Label)e.Item.FindControl("lblgaptot");
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
                //Label lblrevinvamount = (Label)e.Item.FindControl("lblrevinvamount");
                //Label lblrevinvamountinr = (Label)e.Item.FindControl("lblrevinvamountinr");

                //Label lbltotalbilltot = (Label)e.Item.FindControl("lbltotalbilltot");
                //Label lbltotalbillinrtot = (Label)e.Item.FindControl("lbltotalbillinrtot");

               
                //Label lblgrossrevINRtot = (Label)e.Item.FindControl("lblgrossrevINRtot");

               // lblinvoiceamountot.Text = invoiceamount.ToString();
               // lblinvoiceamouninrtot.Text = invoiceamountinr.ToString();
                lblcdramounttot.Text = totalcdramt.ToString();
                lblcdramountinrtot.Text = cdramountinr.ToString();
               // lblgaptot.Text = gap.ToString();

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



              //  lblrevinvamount.Text = revinvoiceamt.ToString();
              //  lblrevinvamountinr.Text = revinvoiceamountinr.ToString();
              //  lbltotalbilltot.Text = totbillingamt.ToString();
              //  lbltotalbillinrtot.Text = totalbillinginr.ToString();
                
             //   lblgrossrevINRtot.Text = grossrevINR.ToString();




            }
            #endregion
        }
        catch (Exception ex)
        {
            return;
        }
    }
}