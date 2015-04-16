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
using System.Drawing;
using Clay.Common.Bll;
public partial class CDR_invoicerpt_sub1 : System.Web.UI.Page
{
    DataSet dsReport = new DataSet();
    invoicecontract obj = new invoicecontract();
    Clay.Common.Bll.Country objcnt;
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
                if (!string.IsNullOrEmpty(Request.QueryString["calltypeid"].ToString()))
                {
                    bindContract(Convert.ToInt32(Request.QueryString["calltypeid"]), Request.QueryString["fromdate"].ToString(), Request.QueryString["todate"].ToString(), Convert.ToInt32(Request.QueryString["countryid"]), Convert.ToInt32(Request.QueryString["providerid"]));
                    lblcalltype.Text = Request.QueryString["calltypename"].ToString();
                    lblcountry.Text = Request.QueryString["countryname"].ToString();
                    lblprovider.Text = Request.QueryString["providername"].ToString();
                }
                //loadCountryDDL();
                // LoadProviderByCountry();
                // loadYear();

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void bindContract(int calltypeid, string fromdate, string todate, int countryid, int providerid)
    {
        try
        {

            dsReport = obj.GetcontractCDRsubreport(calltypeid, fromdate, todate,countryid,providerid);
            DataTable dtreport = new DataTable();
            dtreport = dsReport.Tables[0].Clone();
            bool _exist = false;
           
            if (dsReport.Tables[0].Rows.Count > 0)
            {
                grdcontract.DataSource = dsReport;
                grdcontract.DataBind();
                // pnlgrossary.Visible = false;

            }
            else
            {
                grdcontract.DataSource = null;
                grdcontract.DataBind();
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
        

    }

    #region Varibles
    decimal cdrcost = 0;
    decimal calltyperate = 0;
    decimal differnece = 0;   
    
    #endregion

    
   
    protected void grdcontract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcdrcost = (Label)e.Row.FindControl("lblcdrcost");
                Label lblcalltyperate = (Label)e.Row.FindControl("lblcalltyperate");
                Label lbldiffernece = (Label)e.Row.FindControl("lbldiffernece");

                
                if (!string.IsNullOrEmpty(lblcdrcost.Text))
                    cdrcost += Convert.ToDecimal(lblcdrcost.Text);
                else
                    cdrcost += 0;

                if (!string.IsNullOrEmpty(lblcalltyperate.Text))
                    calltyperate += Convert.ToDecimal(lblcalltyperate.Text);
                else
                    calltyperate += 0;

                if (!string.IsNullOrEmpty(lbldiffernece.Text))
                    differnece += Convert.ToDecimal(lbldiffernece.Text);
                else
                    differnece += 0;

                if (!string.IsNullOrEmpty(lbldiffernece.Text))
                {
                    if (Convert.ToDecimal(lbldiffernece.Text) > 0)
                    {
                        e.Row.Cells[6].BackColor = Color.Green;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                    else
                    {
                        e.Row.Cells[6].BackColor = Color.Red;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbltotcdrcost = (Label)e.Row.FindControl("lbltotcdrcost");
                Label lbltotcalltyperate = (Label)e.Row.FindControl("lbltotcalltyperate");
                Label lbltotdiffernece = (Label)e.Row.FindControl("lbltotdiffernece");


                lbltotcdrcost.Text = cdrcost.ToString();
                lbltotcalltyperate.Text = calltyperate.ToString();
                lbltotdiffernece.Text = differnece.ToString();
               
            }
        }
        catch (Exception ex)
        {

        }
    }
}