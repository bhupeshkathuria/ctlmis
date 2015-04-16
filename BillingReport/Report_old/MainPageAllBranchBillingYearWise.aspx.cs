﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_AllBranchBillingYearWiseMainPage : System.Web.UI.Page
{
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userId = Convert.ToInt32(Session["UserId"]);
        }
        catch (Exception ex)
        {
            userId = 0;
        }

        if (userId == 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        else
        {
        }
    }

    protected void BinFyear()
    {
        int totalItems = drpFyear.Items.Count;
        
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpFyear.SelectedValue == "0")
        {
            lblMsg.Text = "Please select financial year !";
            return;
        }
        else
        {
            lblMsg.Text = "";
            Session["Fyear"] = drpFyear.SelectedItem.Text;
            RadWindowAllBranchBillingYearWise.NavigateUrl = "~/Report/AllBranchBillingMonthAndDayWise.aspx";
           // RadWindowAllBranchBillingMonthlyWise.NavigateUrl = "~/Report/AllBranchBillingMonthWise.aspx";
        }
    }
}