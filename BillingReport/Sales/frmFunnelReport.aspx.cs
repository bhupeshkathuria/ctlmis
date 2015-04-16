using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using System.Text;

public partial class Sales_frmFunnelReport : System.Web.UI.Page
{
    #region User Defined Fields

    Clay.Sale.Bll.SalesSummaryReport objSalesSummaryReport = new SalesSummaryReport();

    DataSet dsSaleCategory = new DataSet();

    DataSet dsBranch = new DataSet();

    DataSet dsEmployee = new DataSet();

    DataSet dsFunnel = new DataSet();

    static string assignedEmplId = string.Empty;

    StringBuilder strEmplId = new StringBuilder();

    int Achievement = 0;

    int Target = 0;

    #endregion

    #region User Defined Method

    private void LoadData(string _accountManagerId, string _year, string _fromMonth, string _toMonth)
    {
        DataSet dsData = new DataSet();

        dsData = objSalesSummaryReport.GetTargetVsAchivementReport(_accountManagerId, _year, _fromMonth, _toMonth);
        if (dsData.Tables.Count > 0)
        {
            if (dsData.Tables[0].Rows.Count > 0)
            {
                lblMsg.Text = string.Empty;
                grdFunnel.DataSource = dsData.Tables[0];
                grdFunnel.DataBind();
            }
            else
            {
                lblMsg.Text = "No Record found";
                grdFunnel.DataSource = dsData.Tables[0];
                grdFunnel.DataBind();
            }
        }
        else
        {
            lblMsg.Text = "No Record found";
            grdFunnel.DataSource = dsData.Tables[0];
            grdFunnel.DataBind();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            SortedList<string, string> sortedYear = new SortedList<string, string>();
            sortedYear.Add("", "Select");
            sortedYear.Add("2009", "2009");
            sortedYear.Add("2010", "2010");
            sortedYear.Add("2011", "2011");
            sortedYear.Add("2012", "2012");
            sortedYear.Add("2013", "2013");
            sortedYear.Add("2014", "2014");
            sortedYear.Add("2015", "2015");
            sortedYear.Add("2016", "2016");
            sortedYear.Add("2017", "2017");
            sortedYear.Add("2018", "2018");
            sortedYear.Add("2019", "2019");
            sortedYear.Add("2020", "2020");
            ddlYear.DataSource = sortedYear;
            ddlYear.DataValueField = "Key";
            ddlYear.DataTextField = "value";
            ddlYear.DataBind();

            SortedList<string, string> sortedMonth = new SortedList<string, string>();
            sortedMonth.Add("", "Select");
            sortedMonth.Add("01", "January");
            sortedMonth.Add("02", "Febraury");
            sortedMonth.Add("03", "March");
            sortedMonth.Add("04", "April");
            sortedMonth.Add("05", "May");
            sortedMonth.Add("06", "June");
            sortedMonth.Add("07", "July");
            sortedMonth.Add("08", "August");
            sortedMonth.Add("09", "September");
            sortedMonth.Add("10", "October");
            sortedMonth.Add("11", "Novemver");
            sortedMonth.Add("12", "December");
            ddlFromMonth.DataSource = sortedMonth;
            ddlFromMonth.DataValueField = "Key";
            ddlFromMonth.DataTextField = "value";
            ddlFromMonth.DataBind();

            ddlToMonth.DataSource = sortedMonth;
            ddlToMonth.DataValueField = "Key";
            ddlToMonth.DataTextField = "value";
            ddlToMonth.DataBind();

            dsSaleCategory = objSalesSummaryReport.GetSaleCategory(0);

            if (dsSaleCategory.Tables[0].Rows.Count > 0)
            {
                ddlSaleCategory.DataSource = dsSaleCategory.Tables[0];
                ddlSaleCategory.DataValueField = "salescategoryid";
                ddlSaleCategory.DataTextField = "salecategoryname";
                ddlSaleCategory.DataBind();
                ddlSaleCategory.Items.Insert(0, "Select");
            }

            dsBranch = objSalesSummaryReport.GetBranch();

            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                ddlBranch.DataSource = dsBranch.Tables[0];
                ddlBranch.DataValueField = "branchid";
                ddlBranch.DataTextField = "branchname";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "Select");
            }

            ddlYear.SelectedValue = DateTime.Now.Year.ToString();

            if (DateTime.Now.Month > 9)
            {
                ddlFromMonth.SelectedValue = DateTime.Now.Month.ToString();

                ddlToMonth.SelectedValue = DateTime.Now.Month.ToString();
            }
            else
            {
                ddlFromMonth.SelectedValue = "0" + DateTime.Now.Month.ToString();

                ddlToMonth.SelectedValue = "0" + DateTime.Now.Month.ToString();
            }

            this.ddlSaleCategory_SelectedIndexChanged(sender, e);

        }
    }

    protected void btnSerach_Click(object sender, EventArgs e)
    {
        string _accountManagerId = string.Empty;

        string _year = string.Empty;

        string _fromMonth = string.Empty;

        string _toMonth = string.Empty;

        if (ddlEmployee.SelectedIndex > 0)
        {
            _accountManagerId = ddlEmployee.SelectedValue.ToString();
        }
        else
        {
            _accountManagerId = assignedEmplId;
        }


        _year = ddlYear.SelectedValue.ToString();

        _fromMonth = ddlFromMonth.SelectedValue.ToString();

        _toMonth = ddlToMonth.SelectedValue.ToString();


        this.LoadData(_accountManagerId, _year, _fromMonth, _toMonth);
    }

    protected void ddlSaleCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSaleCategory.SelectedIndex == 0)
        {
            dsEmployee = objSalesSummaryReport.GetAccountManagerSaleCategory(0);

            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = dsEmployee.Tables[0];
                ddlEmployee.DataValueField = "employeeid";
                ddlEmployee.DataTextField = "employeename";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select");

                foreach (DataRow DR in dsEmployee.Tables[0].Rows)
                {
                    assignedEmplId = DR["employeeid"].ToString();

                    strEmplId.Append(assignedEmplId);
                    strEmplId.Append(",");
                }
                assignedEmplId = strEmplId.ToString();
                assignedEmplId = assignedEmplId.TrimEnd(',');
            }
        }
        else
        {
            ddlBranch.SelectedIndex = 0;
            dsEmployee = objSalesSummaryReport.GetAccountManagerSaleCategory(Convert.ToInt32(ddlSaleCategory.SelectedValue));

            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = dsEmployee.Tables[0];
                ddlEmployee.DataValueField = "employeeid";
                ddlEmployee.DataTextField = "employeename";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select");

                foreach (DataRow DR in dsEmployee.Tables[0].Rows)
                {
                    assignedEmplId = DR["employeeid"].ToString();

                    strEmplId.Append(assignedEmplId);
                    strEmplId.Append(",");
                }
                assignedEmplId = strEmplId.ToString();
                assignedEmplId = assignedEmplId.TrimEnd(',');
            }
        }
    }

    protected void grdFunnel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblachievement = (Label)e.Row.FindControl("lblachievement");
            Label lbltarget = (Label)e.Row.FindControl("lbltarget");

            Achievement += Convert.ToInt32(lblachievement.Text);
            Target += Convert.ToInt32(lbltarget.Text);

            lblTotalFunnel.Text = Target.ToString();
            lblTotalAchievement.Text = Achievement.ToString();
        }
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedIndex > 0)
        {
            dsEmployee = objSalesSummaryReport.GetEmployeeByEmployeeId(0, 0, Convert.ToInt32(ddlBranch.SelectedValue), "");

            if (dsEmployee.Tables.Count > 0)
            {
                ddlEmployee.DataSource = dsEmployee.Tables[0];
                ddlEmployee.DataValueField = "employeeid";
                ddlEmployee.DataTextField = "employeename";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, "Select");

                foreach (DataRow DR in dsEmployee.Tables[0].Rows)
                {
                    assignedEmplId = DR["employeeid"].ToString();

                    strEmplId.Append(assignedEmplId);
                    strEmplId.Append(",");
                }
                assignedEmplId = strEmplId.ToString();
                assignedEmplId = assignedEmplId.TrimEnd(',');

            }
        }
        else
        {
            ddlEmployee.DataSource = null;
            assignedEmplId = "";
        }
    }
}