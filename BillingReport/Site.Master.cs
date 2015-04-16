using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Summary description for Site
/// </summary>
public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            Response.Redirect("~/default.aspx");
        }
        string type = (Session["billingrpttype"].ToString());

        if (type == "2")
        {
            header1.InnerHtml = "Welcome to Rebelfone report";
        }
        else if (type == "1")
        {
            header1.InnerHtml = "Welcome to Clay Billing report";
        }

        else if (type == "3")
        {
            header1.InnerHtml = "Welcome to Piccell Billing report";
        }
        ShowMyMenu(type);
    }
    private void ShowMyMenu(string ReportId)
    {
        RadMenu radMenu1 = (RadMenu)FindControl("RadMenu1");

        foreach (RadMenuItem mymenu in radMenu1.Items)
        {

            if (ReportId == "1")
            {

                if (mymenu.Text == "Rebelfone")
                {
                    mymenu.Visible = false;
                }
                if (mymenu.Text == "Piccell")
                {
                    mymenu.Visible = false;
                }
                if (mymenu.Text == "Finance")
                {
                    mymenu.Visible = false;
                }
                if (mymenu.Text == "Digital Marketing")
                {
                    mymenu.Visible = false;
                }
            }
            else if (ReportId == "2")
            {
                if (mymenu.Text == "Rebelfone" || mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;

                }
                else
                {
                    mymenu.Visible = false;
                }
                //if (mymenu.Text == "Home" || mymenu.Text == "DashBoard" || mymenu.Text == "Report" || mymenu.Text == "MIS Report" || mymenu.Text == "Sales Report" || mymenu.Text == "Erp Reports" || mymenu.Text == "Approval" || mymenu.Text == "Collection" || mymenu.Text == "Prepaid Reports" || mymenu.Text == "Settings")
                //{
                //    mymenu.Visible = false;
                //    logo.ImageUrl = "http://www.rebelfone.com/images/logo.jpg";
                //}
            }
            else if (ReportId == "3")
            {
                if (mymenu.Text == "Piccell" || mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;

                }
                else
                {
                    mymenu.Visible = false;
                }

            }
            else if (ReportId == "4")
            {
                if (mymenu.Text == "Finance" || mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;

                }
                else
                {
                    mymenu.Visible = false;
                }

            }
            else if (ReportId == "5")
            {
                if (mymenu.Text == "Digital Marketing" || mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;

                }
                else
                {
                    mymenu.Visible = false;
                }
            }
            else if (ReportId == "1,2")
            {
                if (mymenu.Text == "Piccell")
                {
                    mymenu.Visible = false;

                }
                else if (mymenu.Text == "Finance")
                {
                    mymenu.Visible = false;
                }
                else if (mymenu.Text == "Digital Marketing")
                {
                    mymenu.Visible = false;
                }
                else
                {
                    mymenu.Visible = true;
                }
            }
            else if (ReportId == "1,3")
            {
                if (mymenu.Text == "Rebelfone")
                {
                    mymenu.Visible = false;

                }
                else if (mymenu.Text == "Finance")
                {
                    mymenu.Visible = false;
                }
                else if (mymenu.Text == "Digital Marketing")
                {
                    mymenu.Visible = false;
                }
                else
                {
                    mymenu.Visible = true;
                }
            }
            else if (ReportId == "1,4")
            {
                if (mymenu.Text == "Rebelfone")
                {
                    mymenu.Visible = false;

                }
                else if (mymenu.Text == "Piccell")
                {
                    mymenu.Visible = false;
                }
                else if (mymenu.Text == "Digital Marketing")
                {
                    mymenu.Visible = false;
                }
                else
                {
                    mymenu.Visible = true;
                }
            }
            else if (ReportId == "2,3")
            {
                if (mymenu.Text == "Rebelfone" || mymenu.Text == "Piccell" || mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;

                }
                else
                {
                    mymenu.Visible = false;
                }
            }
            else if (ReportId == "1,2,3,4,5")
            {
                mymenu.Visible = true;
            }
            else
            {
                if (mymenu.Text == "Logout")
                {
                    mymenu.Visible = true;
                }
                else
                {
                    mymenu.Visible = false;
                }
            }
            //if (mymenu.Text == "Piccell")
            //{
            //    if (Convert.ToInt32(Session["UserID"]) == 385)
            //    {
            //        mymenu.Visible = true;
            //    }
            //    else
            //    {
            //        mymenu.Visible = false;
            //    }
            //}

        }
    }
}