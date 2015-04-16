using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClayBillingLibrary.UserClass;
//using SalesReport;

/// <summary>
/// Summary description for CurrentSession
/// </summary>
public static class CurrentSession
{
    public static UserDetail UserDetail
    {
        get
        {
            if (HttpContext.Current.Session["UserDetail"] != null)
                return (UserDetail)HttpContext.Current.Session["UserDetail"];
            else
                return new UserDetail();
        }
        set { HttpContext.Current.Session["UserDetail"] = value; }
    }
    public static UserLogin clayuser
    {
        get
        {
            if (HttpContext.Current.Session["ERPUser"] != null)
                return (UserLogin)HttpContext.Current.Session["ERPUser"];
            else
                return new UserLogin();
        }
        set { HttpContext.Current.Session["ERPUser"] = value; }
    }



    public static int Login_Id
    {
        get
        {
            if (HttpContext.Current.Session["Login_Id"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["Login_Id"]);
            else

                return 0;
               
        }

        set
        {
            HttpContext.Current.Session["Login_Id"] = value;
        }
    }

    public static string Login_name
    {
        get
        {
            if (HttpContext.Current.Session["Login_namee"] != null)
                return Convert.ToString(HttpContext.Current.Session["Login_namee"]);
            else

                return string.Empty;

        }

        set
        {
            HttpContext.Current.Session["Login_namee"] = value;
        }
    }


    public static string UserFullname
    {
        get
        {
            if (HttpContext.Current.Session["UserFullname"] != null)
                return Convert.ToString(HttpContext.Current.Session["UserFullname"]);
            else

                return string.Empty;

        }

        set
        {
            HttpContext.Current.Session["Login_namee"] = value;
        }
    }
    public static Module SeletedModule
    {
        get
        {
            if (HttpContext.Current.Session["SeletedModule"] != null)
                return (Module)HttpContext.Current.Session["SeletedModule"];
            else
                return null;
        }
        set { HttpContext.Current.Session["SeletedModule"] = value; }
    }

    public static Module LastSeletedModule
    {
        get
        {
            if (HttpContext.Current.Session["LastSeletedModule"] != null)
                return (Module)HttpContext.Current.Session["LastSeletedModule"];
            else
                return null;
        }
        set { HttpContext.Current.Session["LastSeletedModule"] = value; }
    }
   
}