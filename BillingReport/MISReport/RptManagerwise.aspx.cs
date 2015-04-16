using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;
using System.Text;
//using System.Windows.Forms;

public partial class User_CRM_RafList : System.Web.UI.Page
{
    DataSet dsCRMPermission = null;
    DataSet dsEmployee = null;
    DataSet dsSearchBranch = null;
    DataSet dsSalesOrder = null;

    Clay.Common.Bll.Employee objEmployee = null;
    Clay.Invoice.Bll.Web objEmployeeSales = new Clay.Invoice.Bll.Web();
    //Clay.Administrator.Bll.CRMPermission objCrmPermission = null;
    Clay.Common.Bll.Branch objBranch = null;
    //Clay.SalesOrder.Bll.SalesOrder objSalesOrder = null;
    Clay.Invoice.Bll.Report Rpt = new Clay.Invoice.Bll.Report();
    Clay.Invoice.Bll.Web objSalesOrderWeb = null;

    //BindingSource bindingSourceSalesOrder = null;

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
        drYear["yearVal"] = "Select";
        drYear["yearTxt"] = 0;
        dsYear.Tables[0].Rows.InsertAt(drYear, 0);

        for (int i = 2010; i <= DateTime.Now.Year; i++)
        {
            drYear = dsYear.Tables[0].NewRow();
            drYear["yearVal"] = i;
            drYear["yearTxt"] = i;
            dsYear.Tables[0].Rows.InsertAt(drYear, i + 1 - 2010);
        }
        ddlYear.DataSource = dsYear.Tables[0];
        ddlYear.DataTextField = "yearVal";
        ddlYear.DataValueField = "yearTxt";
        ddlYear.DataBind();
        ddlYear.SelectedIndex = 0;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lnkWelcome.Text = Convert.ToString(Session["WelcomeLink"]);
            //lblWelcomeText.Text = Convert.ToString(Session["WelcomeText"]);
            LoadBusRelManagerTocbManager();
            LoadBranchTcbSearchBranch();
            //DataTable dt = new DataTable();
            //RadGrid1.DataSource = dt;
            //RadGrid1.DataBind();
            Session["dataset"] = null;
            loadYear();
          //  LoadManagerReport(0, 0, 0, 0, false);
        }
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

    void LoadBusRelManagerTocbManager()
    {
        dsEmployee = new DataSet();
        dsCRMPermission = new DataSet();
        objEmployee = new Clay.Common.Bll.Employee();
       // objCrmPermission = new Clay.Administrator.Bll.CRMPermission();
        string _emplId = string.Empty;
        string assignedEmplId = string.Empty;
        StringBuilder strEmplId = new StringBuilder();

        //if (Convert.ToInt32(Session["UserID"]) != 0)
        //{
        //    if (Convert.ToBoolean(Session["Administrator"]) == true)
        //    {
                dsEmployee = new DataSet();
                objEmployee = new Clay.Common.Bll.Employee();

                //dsEmployee = objEmployee.GetEmployeeByEmployeeId(0, 0, 0, "");
                //dsEmployee = objEmployeeSales.GetEmployeeSalesAndCre();
                dsEmployee = Rpt.GetEmployeeSalesAndCre();
                if (dsEmployee.Tables.Count > 0)
                {
                    DataRow dr;
                    //dr = dsEmployee.Tables[0].NewRow();
                    //dr["employeename"] = "Select Manager";
                    //dr["employeeid"] = "0";
                    //dsEmployee.Tables[0].Rows.InsertAt(dr, 0);
                    ddlManager.DataSource = dsEmployee.Tables[0];
                    ddlManager.DataTextField = "employeename";
                    ddlManager.DataValueField= "employeeid";
                    ddlManager.DataBind();
                }
            //}
            //else
            //{
            //    dsCRMPermission = objCrmPermission.GetAssignedByUserId(Convert.ToInt32(Session["UserID"]));
            //    if (dsCRMPermission.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow DR in dsCRMPermission.Tables[0].Rows)
            //        {
            //            _emplId = DR["assignedemployeeid"].ToString();

            //            strEmplId.Append(_emplId);
            //            strEmplId.Append(",");


            //        }
            //        assignedEmplId = strEmplId.ToString() + Convert.ToString(Session["EmployeeId"]);
            //    }
            //    if (assignedEmplId != "")
            //    {
            //        dsEmployee = objEmployee.GetEmployeeByUser(assignedEmplId);
            //    }
            //    else
            //    {
            //        dsEmployee = objEmployee.GetEmployeeByEmployeeId(Convert.ToInt32(Session["EmployeeId"]), 0, 0, "");
            //    }

            //    if (dsEmployee.Tables.Count > 0)
            //    {
            //        ddlManager.DataSource = dsEmployee.Tables[0];
            //        ddlManager.DataTextField = "employeename";
            //        ddlManager.DataValueField = "employeeid";
            //    }
            //}
        //}

    }

    void LoadBranchTcbSearchBranch()
    {
        dsSearchBranch = new DataSet();
        objBranch = new Clay.Common.Bll.Branch();
        dsSearchBranch = objBranch.GetBranch();

        if (dsSearchBranch.Tables.Count > 0)
        {
            DataRow dr;
            dr = dsSearchBranch.Tables[0].NewRow();
            dr["branchname"] = "Select Branch";
            dr["branchid"] = 0;
            dsSearchBranch.Tables[0].Rows.InsertAt(dr, 0);
            ddlBranch.DataSource = dsSearchBranch.Tables[0];
            ddlBranch.DataTextField = "branchname";
            ddlBranch.DataValueField = "branchid";
            ddlBranch.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {        
            RadGrid1.Visible = true;
            search(false);
               
       
    }

    private void search(bool fromSession)
    {
        int _branchId = 0;
        
        
        int _accountmanagerId = 0;

        int month = 0;
        int year = 0;

        if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex > 0))
        {
            month = Convert.ToInt32(ddlMonth.SelectedValue);
            year = Convert.ToInt32(ddlYear.SelectedValue);
        }
        else if ((ddlMonth.SelectedIndex <= 0) && (ddlYear.SelectedIndex <= 0))
        {
            month = 0;
        }
        else if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex <= 0))
        {
            lblmsg.Text = "Please Select Year Also";
            return;
        }
        else if (ddlYear.SelectedIndex > 0)
        {
            year = Convert.ToInt32(ddlYear.SelectedValue);
        }
       // _accountmanagerId = Convert.ToInt32(ddlManager.SelectedValue);
        if (ddlManager.SelectedValue.Trim().Length > 0)
        {
            _accountmanagerId = Convert.ToInt32(ddlManager.SelectedValue);
        }
        else
        {
            _accountmanagerId = Convert.ToInt32(0);
        }
        if (ddlBranch.SelectedValue.Trim().Length > 0)
        {
            _branchId = Convert.ToInt32(ddlBranch.SelectedValue.ToString());
        }
        else
        {
            _branchId = Convert.ToInt32(0);
        }

        this.LoadManagerReport(_branchId, _accountmanagerId, year, month, fromSession);
    }

    //void loadManagerReport()
    //{
    //    int month = 0;
    //    int year = 0;

    //    if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex > 0))
    //    {
    //        month = Convert.ToInt32(ddlMonth.SelectedValue);
    //        year = Convert.ToInt32(ddlYear.SelectedValue);
    //    }
    //    else if ((ddlMonth.SelectedIndex <= 0) && (ddlYear.SelectedIndex <= 0))
    //    {
    //    }
    //    else if ((ddlMonth.SelectedIndex > 0) && (ddlYear.SelectedIndex <= 0))
    //    {
    //        lblmsg.Text = "Please Select Year Also";
    //        return;
    //    }
    //    else if (ddlYear.SelectedIndex > 0)
    //    {
    //        year = Convert.ToInt32(ddlYear.SelectedValue);
    //    }

    //}
    void LoadManagerReport(int branchId, int ManagerId, int year, int month, bool fromSession)
    {
        dsSalesOrder = new DataSet();

        if (fromSession == false)
        {
            objSalesOrderWeb = new Clay.Invoice.Bll.Web();

            dsSalesOrder = Rpt.GetManagerlevelreport(branchId, ManagerId,year,month);

            if (dsSalesOrder.Tables[0].Rows.Count > 0)
            {
                RadGrid1.DataSource = dsSalesOrder.Tables[0];
                RadGrid1.DataBind();
                Session["dataset"] = dsSalesOrder;
            }
            else
            {
                RadGrid1.DataSource = dsSalesOrder.Tables[0];
                RadGrid1.DataBind();
               // RadGrid1.DataSource = null;
            }
        }
        else
        {
            //Session["dataset"] = null;

            dsSalesOrder = (DataSet) Session["dataset"];

            if (dsSalesOrder.Tables[0].Rows.Count > 0)
            {
                RadGrid1.DataSource = dsSalesOrder.Tables[0];
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = dsSalesOrder.Tables[0];
                RadGrid1.DataBind();
            }
        }
    }

    protected void RadGrid1_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        if ((e.NewPageIndex / RadGrid1.PageSize) > RadGrid1.PageCount)
        {
            search(true);
        }
        else
        {
            search(true);
        }
    }

    protected void RadGrid1_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
    {
        search(true);
    }

    protected void RadGrid1_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        search(true);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (item["Amount"].Text == "Null;")
                item["Amount"].Text = "0.00";
        }
        //if (e.Item is GridDataItem)
        //{
        //    GridDataItem item = (GridDataItem)e.Item;
        //    TableCell cell = item["Sno"];
        //    Label labelSNo = (Label)cell.FindControl("lblSno");
        //    labelSNo.Text = Convert.ToString((RadGrid1.CurrentPageIndex * RadGrid1.PageSize) + e.Item.ItemIndex + 1);

        //    TableCell cell2 = item["details"];
        //    Label MyBussAcc = (Label)cell2.FindControl("lblBussAcc");
        //    HyperLink targetHL = (HyperLink)cell2.FindControl("targetControl");
        //    targetHL.Text = MyBussAcc.Text;

        //    TableCell cell3 = item["status"];
        //    Label lblStatus1 = (Label)cell3.FindControl("lblinventory");
        //    Label lblStatus2 = (Label)cell3.FindControl("lbloperations");
        //    Label lblStatus3 = (Label)cell3.FindControl("lblcustomer");
        //    Label lblStatus4 = (Label)cell3.FindControl("lblactualstatus");

        //    string _isSendToInventory = Convert.ToString(lblStatus1.Text);
        //    string _isSendToOperation = Convert.ToString(lblStatus2.Text);
        //    string _isSendToCustomer = Convert.ToString(lblStatus3.Text);
        //    string _orderStatus = Convert.ToString(lblStatus4.Text);
        //    TableCell cell4 = item["orderstatus"];
        //    Label labelinventory = (Label)cell.FindControl("lblOrderstatus");



        //    if (_isSendToInventory == "True" && _orderStatus == "Pending")
        //    {
        //        labelinventory.Text = "Pending - Inventory";
        //    }

        //    if (_isSendToOperation == "True" && _orderStatus == "Pending")
        //    {
        //        labelinventory.Text = "Pending - Operation";
        //    }

        //    if (_isSendToCustomer == "True" && _orderStatus == "Pending")
        //    {
        //        labelinventory.Text = "Pending - Delivery";
        //    }

        //    if (_isSendToInventory == "False" && _isSendToOperation == "False"
        //        && _isSendToCustomer == "False" && _orderStatus == "Pending")
        //    {
        //        labelinventory.Text = "Pending - Sales";
        //    }

        //    if (_orderStatus == "Accept")
        //    {
        //        labelinventory.Text = "Accept";
        //    }
        //    else if (_orderStatus == "Reject")
        //    {
        //        labelinventory.Text = "Reject";
        //    }
        //    else if (_orderStatus == "Cancel")
        //    {
        //        labelinventory.Text = "Cancel";
        //    }
        //    else if (_orderStatus == "Closed")
        //    {
        //        labelinventory.Text = "Closed";
        //    }

        //    //if ((inventorystatus) == "True")
        //    //{
        //    //    if ((operationstatus) == "True")
        //    //    {
        //    //        if ((customerstatus) == "True")
        //    //        {
        //    //            labelinventory.Text = "Pending - Delivery"; 
        //    //            labelinventory.Text = Convert.ToString(lblStatus4.Text);
        //    //        }
        //    //        else
        //    //        {
        //    //            labelinventory.Text = "Pending - Operations";
        //    //            //labelinventory.Text = "Pending - Send To Customer";
        //    //        }
        //    //        //labelinventory.Text = "Pending - customer";
        //    //    }
        //    //    else
        //    //    {
        //    //        labelinventory.Text = "Pending - Inventory";
        //    //    }
        //    //   // labelinventory.Text = "Pending - Operations";
        //    //}
        //    //else
        //    //{
        //    //    labelinventory.Text = "Pending - Sales";
        //    //}







        //    //else if ((operationstatus) == "True")
        //    //{
        //    //    labelinventory.Text = "Pending - customer";
        //    //}
        //    //else if ((customerstatus) == "True")
        //    //{
        //    //    labelinventory.Text = "Pending - Delivery";
        //    //}
        //    //else
        //    //{
        //    //    labelinventory.Text = "Pending";
        //    //}


        //}

        //if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        //{
        //    Control target = e.Item.FindControl("targetControl");
        //    if (!Object.Equals(target, null))
        //    {
        //        if (!Object.Equals(this.RadToolTipManager1, null))
        //        {
        //            //Add the button (target) id to the tooltip manager
        //            this.RadToolTipManager1.TargetControls.Add(target.ClientID, (e.Item as GridDataItem).GetDataKeyValue("orderid").ToString(), true);
        //        }
        //    }
        //}
    }

    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        this.UpdateToolTip(args.Value, args.UpdatePanel);
    }
    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        Control ctrl = Page.LoadControl("RafDetails.ascx");
        panel.ContentTemplateContainer.Controls.Add(ctrl);
        //ASP.user_crm_rafdetails_ascx details = (ASP.user_crm_rafdetails_ascx)ctrl;
       // details.brID = Convert.ToInt32(elementID);
    }

}
