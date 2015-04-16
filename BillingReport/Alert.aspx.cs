using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Alert : System.Web.UI.Page
{
    Clay.Sale.Bll.SalesSummaryReport objsale_email = new Clay.Sale.Bll.SalesSummaryReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        // checkSession();
        // checkpageright();
    }

    void checkpageright()
    {
        Clay.Invoice.Bll.Page objPage = new Clay.Invoice.Bll.Page();
        DataSet dspageright = new DataSet();
        string page;
        int user;
        user = Convert.ToInt32(Session["UserID"]);
        page = System.IO.Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);
        objPage.PageName = page;
        objPage.UserId = user;
        dspageright = objPage.CheckPageRight();

        if (dspageright.Tables[0].Rows.Count == 0)
        {
            Response.Redirect("../invoice/Error500.aspx");
            return;
        }

    }

    void checkSession()
    {
        try
        {
            if (!(Convert.ToInt32(Session["UserID"]) > 0))
            {
                Response.Write("<script language='javascript'>window.open('../../LoginWebErp.aspx','_parent','');</script>");
            }

        }
        catch
        {
        }
    }
    protected void ddllstType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddllstType.SelectedItem.Text == "Select Report")
        {
            tralert.Visible = false;
            ddltime.SelectedIndex = 0;
            ddlweekdays.SelectedIndex = 0;
            txtemail.Text = "";
            lblmsg.Text = "";
        }
        else
        {
            tralert.Visible = true;
            lblmsg.Text = "";
            ddltime.SelectedIndex = 0;
            ddlweekdays.SelectedIndex = 0;
            txtemail.Text = "";
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        #region varibles
        string _rptname = string.Empty;
        int _everyday = 0;
        string _weekday = string.Empty;
        string _time = string.Empty;
        string _email = string.Empty;
        #endregion
        Boolean radiocheck = false;
        for (int i = 0; i <= rdobtn.Items.Count - 1; i++)
        {
            if (rdobtn.Items[i].Selected == true)
            {
                radiocheck = true;
                break;
            }
        }
        if (ddllstType.SelectedItem.Text == "Select Report")
        {
            lblmsg.Text = "Please select report name";
            return;
        }
        if (radiocheck == false && ddlweekdays.SelectedIndex == 0 && txtemail.Text == "" && ddltime.SelectedIndex == 0)
        {
            lblmsg.Text = "Please select above criteria";
            return;
        }
        else
        {
            if (rdobtn.SelectedItem.Value == "1")
            {
                _everyday = 1;
                _weekday = "Daily";
            }
            else
            {
                if (ddlweekdays.SelectedValue == "0")
                {
                    lblmsg.Text = "Please select any day";
                    return;
                }
                else
                {
                    _weekday = ddlweekdays.SelectedItem.Text;
                }
            }
            if (ddltime.SelectedItem.Value == "0")
            {
                lblmsg.Text = "Please select time";
                return;
            }
            else
            {
                _time = ddltime.SelectedItem.Value;
            }
            if (!string.IsNullOrEmpty(txtemail.Text.ToString()))
            {
                _email = txtemail.Text.Trim();
            }
            else
            {
                lblmsg.Text = "Please enter email";
                return;
            }
            _rptname = ddllstType.SelectedItem.Text.ToString();
            int result = objsale_email.Insertemailinfo(_rptname, _everyday, _weekday, _time, _email);
            if (result == 1)
            {
                lblmsg.Text = "Successfully inserted ";
                empty();
            }
        }
          
     
    }

    
    private void empty()
    {
        ddllstType.SelectedIndex = 0;
        ddltime.SelectedIndex = 0;
        ddlweekdays.SelectedIndex = 0;
        txtemail.Text = "";
    }
    protected void rdobtn_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (rdobtn.SelectedItem.Value == "1")
        {
            ddlweekdays.Enabled = false;
            ddlweekdays.SelectedIndex = 0;
            lblmsg.Text = "";
        }
        else
        {
            ddlweekdays.Enabled = true;
            lblmsg.Text = "";
        }
        
    }
}