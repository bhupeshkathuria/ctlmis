using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary.UserClass;
public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("~/Default.aspx");
        //new UserLogin().LogOut(Convert.ToInt32(Session["logid"]));

        //Session.Abandon();

        //Response.Redirect("~/Default.aspx");
    }
}