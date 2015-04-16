using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
/// <summary>
/// Summary description for Site
/// </summary>
public partial class SiteMaster : System.Web.UI.MasterPage
{
    ClayBillingLibrary.UserClass.UserLogin objuser = new ClayBillingLibrary.UserClass.UserLogin();
    #region Function for adding top menu items
    /// <summary>
    /// Adds the top/parent menu items for the menu
    /// </summary>
    /// <param name="menuData"></param>
    private void AddTopMenuItems()
    {
        try
        {
            //if (CurrentSession.SeletedModule != null)
            //{
            NavigationMenu.Items.Clear();
            var menus = CurrentSession.clayuser.Menus.Where(m => m.ModuleId == CurrentSession.SeletedModule.ModuleId);
                foreach (var menu in menus.Where(m => m.ParentId == 0))
                {
                    MenuItem newMenuItem = new MenuItem(menu.MenuText.ToString(), menu.MenuId.ToString());

                    AddChildMenuItems(newMenuItem, menus);
                    NavigationMenu.Items.Add(newMenuItem);
                }
            //}

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            //view = null;
        }
    }
    #endregion

    #region Function for adding child menu items from database
    /// <summary>
    /// This code is used to recursively add child menu items by filtering by ParentID
    /// </summary>
    /// <param name="menuData"></param>
    /// <param name="parentMenuItem"></param>
    private void AddChildMenuItems(MenuItem node, IEnumerable<ClayBillingLibrary.UserClass.Menu> menus)
    {
        try
        {
            foreach (var menu in menus.Where(m => m.ParentId == int.Parse(node.Value)))
            {
                MenuItem childMenuItem = new MenuItem(menu.MenuText.ToString(), menu.MenuId.ToString(), string.Empty, menu.Url.ToString());
                AddChildMenuItems(childMenuItem, menus);
                node.ChildItems.Add(childMenuItem);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            // view = null;
        }
    }
    #endregion

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
        DataTable dt = new DataTable();
        DropDownList ddl = new DropDownList();
        ddl.DataSource = CurrentSession.clayuser.Modules;
        foreach (ListItem li in ddl.Items)
        {
            // if (li.Value == textBox1.text)
            CurrentSession.SeletedModule = new ClayBillingLibrary.UserClass.Module { ModuleId =Convert.ToInt32(li.Value), ModuleName = li.Text.ToString() };
            AddTopMenuItems();
        }
        //ShowMyMenu(type);
       
        
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
            else if (ReportId == "1,2,3,4")
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