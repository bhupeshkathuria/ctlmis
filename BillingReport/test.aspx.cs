using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string script = "$(document).ready(function () { $('[id*=Submit]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        //databind();
    }
    public void databind()
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection conn = new SqlConnection(strcon);
        conn.Open();
        string str = "select * from emp1 WHERE CITY='" + location.SelectedItem.Value.ToString() + "' ";
        SqlCommand cmd = new SqlCommand(str, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        gv.DataSource = dt;
        gv.DataBind();


    }
    
}