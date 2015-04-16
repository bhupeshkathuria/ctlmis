using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_PLReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        try
        {
            string fromdt = txtFromDt.Text;
            string todt = txtToDt.Text;
            string finid = string.Empty;
            FinanceDataAccess objData = new FinanceDataAccess();
            objData.Fromdt = fromdt;
            objData.Todt = todt;
            finid = objData.getFinYear(fromdt, todt);
            DataTable dt = objData.GetPlData(fromdt,todt,finid);           
            grdPL.DataSource = dt;
            grdPL.DataBind();           
        }
        
        catch (Exception ex)
        {
            
            throw ex;
        }

    }
    protected void grdPL_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string act = string.Empty;
            string ledgerid = string.Empty;
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                Label lblAct = (Label)e.Row.Cells[0].FindControl("lblAccount");
                act = lblAct.Text;

                if ((act != "INCOME") && (act != "EXPENSE") && (act != "  Total Sales Accounts") && (act != "  Total Indirect Incomes") && (act != "Total INCOME") && (act != "  Total Indirect Expenses") && (act != "    Total Purchase") && (act != "Total EXPENSE") && (act != "Total Loss : "))
                {
                    HiddenField hdf1 = (HiddenField)e.Row.Cells[0].FindControl("lblPAID");
                    ledgerid = hdf1.Value;

                    //string hlink = "javascript:calldetails(" + Convert.ToChar(39) + ledgerid + Convert.ToChar(39) + "," + Convert.ToChar(39) + act + Convert.ToChar(39) + "," + Convert.ToChar(39) + txtFromDt.Text + Convert.ToChar(39) + "," + Convert.ToChar(39) +  txtToDt.Text + Convert.ToChar(39) + ")";
                    //e.Row.Cells[0].Text = "<A HREF=javascript:calldetails('" + ledgerid + "',&#39;" + act + "&#39;,'" + txtFromDt.Text + "','" + txtToDt.Text + "')>" + act + "</a>";
                    e.Row.Cells[0].Text = "<A HREF='javascript:void(0)' onclick='calldetails(&#39;" + ledgerid + "&#39;,&#39;" + act + "&#39;,&#39;" + txtFromDt.Text + "&#39;,&#39;" + txtToDt.Text + "&#39;)'>" + act + "</a>";
                }

                if ((act == "INCOME") || (act=="EXPENSE"))
                {
                    e.Row.Font.Size = 12;
                    e.Row.Font.Bold = true;
                }
                if ((act == "  Total Sales Accounts") || (act=="  Total Indirect Incomes") || (act=="Total INCOME") || (act=="  Total Indirect Expenses") || (act=="    Total Purchase") || (act=="Total EXPENSE") || (act=="Total Loss : "))
                {
                    e.Row.Font.Size = 10;
                    e.Row.Font.Bold = true;
                }
            }
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        

    }
}