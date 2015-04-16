using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Clay.RAD;
using System.Data;
public partial class Techscoot_rptdailysale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                LoadProviderByCountry();
               // getdailyrpt(DateTime.Now.AddDays(-2),DateTime.Now.AddDays(-2));
            }

            
        }
        catch (Exception ex)
        {
        }
    }
    private void LoadProviderByCountry()
    {
        provider objProvider;
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
   
    protected void lnksearch_Click(object sender, EventArgs e)
    {
        int _providerid = 0;
        if (ddlnetworks.SelectedIndex > 0)
        {
            _providerid = Convert.ToInt32(ddlnetworks.SelectedValue);
        }
        else
        {
            _providerid = 0;
        }
        invoicermaster objorder = new invoicermaster();
        DataSet dsorder = new DataSet();

        dsorder = objorder.GetCDRInvoiceEntrylist(txtfromdate.Text.Trim(),txttodate.Text.Trim(),_providerid);

        if (dsorder.Tables[0].Rows.Count > 0)
        {
            grdcard.DataSource = dsorder.Tables[0];
            grdcard.DataBind();
            btnExport.Visible = true;


        }
        else
        {
            grdcard.DataSource = null;
            grdcard.DataBind();
            btnExport.Visible = false;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (grdcard.Rows.Count > 0)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report_'" + DateTime.Now.ToString("hh:mm:ss tt") + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";
            StringWriter str = new StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(str);

            grdcard.RenderControl(HtmlTextWriter);
            Response.Write(str.ToString());
            Response.End();
        }

    }
    decimal _totalamt = 0;
    protected void grdcard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblamount = (Label)e.Row.FindControl("lblamount");
        //    _totalamt += Convert.ToDecimal(lblamount.Text);
        //}
        //else if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    Label lbltotal = (Label)e.Row.FindControl("lbltotal");
        //    lbltotal.Text = _totalamt.ToString();
        //}
    }
    protected void grdcard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdcard.PageIndex = e.NewPageIndex;
        lnksearch_Click(sender, e);
    }
}