using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Report_MainPageForBranchWiseSalesOrder : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            loadYear();
        }
        if (userId == 0)
        {
            Response.Redirect("../Logout.aspx");
        }
        else
        {
        }
    }
    private void loadYear()
    {
        //Load Years
        DataRow drYear;
        DataSet dsYear = new DataSet();
        DataTable dtYears = new DataTable();
        dsYear.Tables.Add(dtYears);

        DataColumn SNoColumn1 = new DataColumn();
        SNoColumn1.ColumnName = "yearVal";
        dsYear.Tables[0].Columns.Add(SNoColumn1);

        DataColumn SNoColumn2 = new DataColumn();
        SNoColumn2.ColumnName = "yearTxt";
        dsYear.Tables[0].Columns.Add(SNoColumn2);

        drYear = dsYear.Tables[0].NewRow();
        drYear["yearVal"] = "Select Financial Year";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            if (DateTime.Now.Year == i)
            {
                if ((DateTime.Now.Month > 3))
                {
                    int temp = i + 1;
                    drYear = dsYear.Tables[0].NewRow();
                    drYear["yearVal"] = i + "-" + temp;
                    drYear["yearTxt"] = i;
                    dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
                }
            }
            else
            {
                int temp = i + 1;
                drYear = dsYear.Tables[0].NewRow();
                drYear["yearVal"] = i + "-" + temp;
                drYear["yearTxt"] = i;
                dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
            }

        }

        drpFyear.DataSource = dsYear.Tables[0];
        drpFyear.DataTextField = "yearVal";
        drpFyear.DataValueField = "yearTxt";
        drpFyear.DataBind();
        drpFyear.SelectedIndex = 0;
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

            if (drpMonth.SelectedIndex == 0)
            {
                Session["Month"] = "0";
            }
            else
            {
                Session["Month"] = drpMonth.SelectedValue;
            }

            
            RadWindowCountryWise.NavigateUrl = "~/Report/DisplayBranchWiseSalesOfCountry.aspx";
            //RadWindowSegmentBranchWise.NavigateUrl = "~/Report/BranchWiseSalesOrder.aspx";
        }
    }
}