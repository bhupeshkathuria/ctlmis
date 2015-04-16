using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clay.Sale.Bll;
using System.Data;
using dal;
using System.Text;

public partial class ErpReports_frmapproval1 : System.Web.UI.Page
{
    #region User Defined Fields

    double totalpovaue = 0;
    int _requisitionId = 0;
    int _viewedbyuserrank = 0;
    int _requestedby = 0;
    string reqno = string.Empty;
    string CreateByMailId = string.Empty;
    string HierarchyUserMailId;
    string FinalCreateRequisitionMailId;

    SalesSummaryReport objSales = new SalesSummaryReport();
    DataSet ds = new DataSet();
    DataSet dsRank = new DataSet();
    DataSet dsComment = new DataSet();

    #endregion

    #region User Defined Methods

    private void BindData(string myreqno)
    {
        try
        {

            ds = objSales.GetRequistionDetails(myreqno);
            if (ds.Tables["POMaster"].Rows.Count > 0)
            {
                lblReqNo.Text = myreqno;
                lblPoNumber.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["purchaseorderid"]);
                lblPoId.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["poid"]);
                DateTime mydt = Convert.ToDateTime(ds.Tables["POMaster"].Rows[0]["orderdate"]);
                lblPODate.Text = mydt.ToString("dd-MM-yyyy");
                lblSuppierName.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["suppliername"]);
                lblContactPersonName.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["contactpersonname"]);
                lblAddress.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["address"]);
                lblsupplierid.Text = Convert.ToString(ds.Tables["POMaster"].Rows[0]["supplierid"]);
            }
            if (ds.Tables["POFiles"].Rows.Count > 0)
            {
                lblbillfilename.Text = Convert.ToString(ds.Tables["POFiles"].Rows[0]["billfilename"]);
                lblmailfilename.Text = Convert.ToString(ds.Tables["POFiles"].Rows[0]["mailfilename"]);
            }
            if (ds.Tables["PODetails"].Rows.Count > 0)
            {
                grdPODetails.DataSource = ds.Tables["PODetails"];
                grdPODetails.DataBind();

            }
            if (ds.Tables["RequisitionDetails"].Rows.Count > 0)
            {

                DateTime mydt = Convert.ToDateTime(ds.Tables["RequisitionDetails"].Rows[0]["createdon"]);

                lblReqDte.Text = mydt.ToString("dd-MM-yyyy");

                lblReqBy.Text = Convert.ToString(ds.Tables["RequisitionDetails"].Rows[0]["employeename"]);

                _requestedby = Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["requestorid"]);

                lblPOComment.Text = Convert.ToString(ds.Tables["RequisitionDetails"].Rows[0]["comment"]);

                lblRequestorId.Text = Convert.ToString(ds.Tables["RequisitionDetails"].Rows[0]["requestorid"]);

                lblRequisitionId.Text = Convert.ToString(ds.Tables["RequisitionDetails"].Rows[0]["requisitionid"]);

                if (Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["approvalrank"]) == Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["viewedbyuserrank"]))
                {
                    pnlPO.Visible = false;
                }
                else
                {
                    pnlPO.Visible = true;
                }

            }

            lblTotalAmt.Text = totalpovaue.ToString("#########.##");

            dsRank = objSales.CheckApproverOrNot(Convert.ToInt32(Session["useremployeeid"]), 2, Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["departmentid"].ToString()), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["branchid"].ToString()));
            if (dsRank.Tables[0].Rows.Count > 0)
            {
                if (dsRank.Tables[0].Rows[0]["count1"].ToString() != "0")
                {
                    _viewedbyuserrank = Convert.ToInt32(dsRank.Tables[0].Rows[0]["hierarchyrank"].ToString());
                    lblViewedbyUserRank.Text = dsRank.Tables[0].Rows[0]["hierarchyrank"].ToString();
                }
                else
                {
                    pnlPO.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    void MailSendOnAprrovedOrRejected(string RequisitionNo, string FinalMailId, string CreateByName, string CommentsStatus, string EmployeeName, string RequisitionType, string CommentbyApprover, string CommentByRequestor)
    {
        string MailSubject = RequisitionType + " " + RequisitionNo + " has been " + CommentsStatus + " by " + EmployeeName;

        if (FinalMailId != "")
        {

            //Create Message for Mail
            string message = "<table cellpadding='0px' cellspacing='3px' width='700px' border='1'><tr><td colspan='2' align ='center' bgcolor='#b8c9f9'>";

            message += "<span style='font-family:Verdana;font-size:13px;text-align:justify'><b> Comments By " + EmployeeName + "</b></span>  </td></tr><tr><td colspan='2' align ='left'><span style='font-family:Verdana;font-size:13px;text-align:justify'>" + CommentbyApprover + "</span></td> </tr>";


            message += "<tr><td colspan='2' align ='center' bgcolor='#b8c9f9'><span style='font-family:Verdana;font-size:13px;text-align:justify;vertical-align:top'rowspan='3'><b>Requisition Details </b></span></td> </tr> <tr><td width='35%'><span style='font-family:Verdana;font-size:13px;text-align:justify'> <b> Requisition Created By :  </b></span></td> <td width='65%'> <span style='font-family:Verdana;font-size:13px;text-align:justify'> " + CreateByName + "</span></td> </tr> <tr><td width='35%'> <span style='font-family:Verdana;font-size:13px;text-align:justify'><b> Approval Process Name :  </b></span></td> <td width='65%'><span style='font-family:Verdana;font-size:13px;text-align:justify'> " + RequisitionType + " </span></td> </tr>  <tr><td width='35%'> <span style='font-family:Verdana;font-size:13px;text-align:justify'> <b> Description  :  </b> </span></td> <td width='65%'> <span style='font-family:Verdana;font-size:13px;text-align:justify'> " + CommentByRequestor + " </span>";

            message += "</td></tr></table> <br/><span style='font-family:Verdana;font-size:10px;text-align:justify' >Please don't print this e-mail unlessrequired.<br /> This message (including any attachment(s) hereto) is confidential may also be privileged. It is intended solely for the addressee. If you are not the intended recipient you are hereby notified that any disclosure, copying, distribution or taking any action in reliance on the contents of this information is strictly prohibited and may be unlawful. If you have received this message in error you are requested to delete it from your system and to contact the sender by replying to this message immediately.Clay Telecom is not liable for the improper transmission of this message nor for any damage sustained as a result of this message. In case you do not wish to receive further emails from this account kindly inform at admin@clay.co.in</span></td></tr></table>";

            //Mail send by static function created under Helper Class    

            SendMail(message, FinalMailId, MailSubject);
        }
    }

    public static void SendMail(string ErrorMessage, string EMailId, string Subject)
    {
        System.Web.Mail.MailMessage msg1 = new System.Web.Mail.MailMessage();

        msg1.From = "info@clay.co.in";
        msg1.Bcc = EMailId;
        msg1.Subject = Subject;

        msg1.Body = ErrorMessage.ToString();

        msg1.BodyFormat = System.Web.Mail.MailFormat.Html;
        msg1.Priority = System.Web.Mail.MailPriority.High;
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2);
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 465);
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout", 25);
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "info@clay.co.in"); //set your username here
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "#$Inf012");//set your password here
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/EnableDCOM", "Y");
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/EnableRemoteConnect", "Y");
        msg1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

        //System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
        System.Web.Mail.SmtpMail.Send(msg1);

    }

    private void BindPO(string SupplierId)
    {
        try
        {
            DataSet dsPO = new DataSet();

            dsPO = objSales.GetLastThreeMonthsPO(Convert.ToInt32(SupplierId));

            if (dsPO.Tables[0].Rows.Count > 0)
            {
                dgPO.DataSource = dsPO.Tables[0];
                dgPO.DataBind();
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private void BindComment(int _requisitionId)
    {
        dsComment = objSales.GetRequisitionComment(_requisitionId);
        if (dsComment.Tables[0].Rows.Count > 0)
        {
            dgcomment.DataSource = dsComment.Tables[0];
            dgcomment.DataBind();
        }
        else
        {
            dgcomment.DataSource = null;
            dgcomment.DataBind();
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                reqno = Convert.ToString(Request.QueryString["reqno"]);
                _requisitionId = Convert.ToInt32(Request.QueryString["requisitionid"]);
                BindData(reqno);
                BindPO(lblsupplierid.Text.ToString());
                BindComment(_requisitionId);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    protected void grdPODetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSrno = e.Row.FindControl("lblSrno") as Label;
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            //e.Row.Cells[0].Text = Convert.ToString(sno);

            lblSrno.Text = Convert.ToString(sno);

            Label myprice = (Label)(e.Row.Cells[7].FindControl("lblTotalPrice"));
            double temprice = Convert.ToDouble(myprice.Text);
            totalpovaue = totalpovaue + temprice;
        }
    }

    protected void cmdApproved_Click(object sender, EventArgs e)
    {
        try
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrequisitionid", DbType.Int32, Convert.ToInt32(lblRequisitionId.Text), ParameterDirection.Input);
                objSpParameters.Add("lstatus", DbType.Int32, 3, ParameterDirection.Input);
                objSpParameters.Add("lviewedbyrank", DbType.Int32, Convert.ToInt32(lblViewedbyUserRank.Text), ParameterDirection.Input);
                objSpParameters.Add("ccomment", DbType.String, txtComments.Text.Trim(), ParameterDirection.Input);
                objSpParameters.Add("lmodifiedby", DbType.Int32, Convert.ToInt32(Session["UserId"]), ParameterDirection.Input);
                objSpParameters.Add("clastipaddress", DbType.String, Request.ServerVariables["REMOTE_ADDR"], ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                object value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_requisitionstatus_update", objSpParameters);

            }

            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpoid", DbType.Int32, Convert.ToInt32(lblPoId.Text), ParameterDirection.Input);
                objSpParameters.Add("lstatus", DbType.Int32, 1, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_purchaseorder_update", objSpParameters);

            }

            int userRank = Convert.ToInt32(objSales.GetUserRankFromRequisitionHierarchy(2, Convert.ToInt32(Session["useremployeeid"]), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["branchid"].ToString()), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["departmentid"].ToString())));

            DataSet dsCreateByUserDetails = new DataSet();

            dsCreateByUserDetails = objSales.GetEmployeeByUser(lblRequestorId.Text);
            if (dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() != "")
            {
                CreateByMailId = dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() + ",";
            }
            string CreateByUserName = dsCreateByUserDetails.Tables[0].Rows[0]["employeename"].ToString();

            //********Start : get mail id who Approed or Reject Requisition
            DataSet dsEmployeeDetails = new DataSet();
            dsEmployeeDetails = objSales.GetEmployeeByUser(Session["useremployeeid"].ToString());
            string EmployeeName = dsEmployeeDetails.Tables[0].Rows[0]["employeename"].ToString();

            //Next Hierarchy user 

            DataSet dsHierarchyUserMailId = new DataSet();

            dsHierarchyUserMailId = objSales.GetHierarchyUserMailId(userRank, 2, Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["branchid"].ToString()), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["departmentid"].ToString()));

            if (dsHierarchyUserMailId.Tables[0].Rows.Count > 0)
            {
                HierarchyUserMailId = "";

                for (int i = 0; i < dsHierarchyUserMailId.Tables[0].Rows.Count; i++)
                {
                    if (dsHierarchyUserMailId.Tables[0].Rows[i]["email"].ToString() != "")
                    {
                        HierarchyUserMailId += dsHierarchyUserMailId.Tables[0].Rows[i]["email"].ToString();

                        HierarchyUserMailId += ",";
                    }
                }
            }

            ////Code to update next approver id//////////////////

            if (dsHierarchyUserMailId.Tables[0].Rows.Count > 0)
            {
                using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
                {
                    SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                    objSpParameters.Add("lrequisitionid", DbType.Int32, _requisitionId, ParameterDirection.Input);
                    objSpParameters.Add("lnextapproverid", DbType.Int32, Convert.ToInt32(dsHierarchyUserMailId.Tables[0].Rows[0]["approverid"].ToString()), ParameterDirection.Input);
                    objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                    int value4 = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_requisition_nextapproverid_update", objSpParameters);

                }
            }

            //////////////////////////////////////////////////////

            FinalCreateRequisitionMailId = CreateByMailId + HierarchyUserMailId;

            this.MailSendOnAprrovedOrRejected(lblReqNo.Text, FinalCreateRequisitionMailId, CreateByUserName, "Approved", EmployeeName, "PO Approval", txtComments.Text.Trim(), lblPOComment.Text);

           // UpdateProg1.Visible = false;
            txtComments.Text = "";


        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void cmdReject_Click(object sender, EventArgs e)
    {
        try
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrequisitionid", DbType.Int32, Convert.ToInt32(lblRequisitionId.Text), ParameterDirection.Input);
                objSpParameters.Add("lstatus", DbType.Int32, 4, ParameterDirection.Input);
                objSpParameters.Add("lviewedbyrank", DbType.Int32, Convert.ToInt32(lblViewedbyUserRank.Text), ParameterDirection.Input);
                objSpParameters.Add("ccomment", DbType.String, txtComments.Text.Trim(), ParameterDirection.Input);
                objSpParameters.Add("lmodifiedby", DbType.Int32, Convert.ToInt32(Session["UserId"]), ParameterDirection.Input);
                objSpParameters.Add("clastipaddress", DbType.String, Request.ServerVariables["REMOTE_ADDR"], ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                object value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_requisitionstatus_update", objSpParameters);

            }

            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lpoid", DbType.Int32, Convert.ToInt32(lblPoId.Text), ParameterDirection.Input);
                objSpParameters.Add("lstatus", DbType.Int32, 2, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_purchaseorder_update", objSpParameters);

            }

            int userRank = Convert.ToInt32(objSales.GetUserRankFromRequisitionHierarchy(2, Convert.ToInt32(Session["useremployeeid"]), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["branchid"].ToString()), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["departmentid"].ToString())));

            DataSet dsCreateByUserDetails = new DataSet();

            dsCreateByUserDetails = objSales.GetEmployeeByUser(lblRequestorId.Text);
            if (dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() != "")
            {
                CreateByMailId = dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() + ",";
            }
            string CreateByUserName = dsCreateByUserDetails.Tables[0].Rows[0]["employeename"].ToString();

            //********Start : get mail id who Approed or Reject Requisition
            DataSet dsEmployeeDetails = new DataSet();
            dsEmployeeDetails = objSales.GetEmployeeByUser(Session["useremployeeid"].ToString());
            string EmployeeName = dsEmployeeDetails.Tables[0].Rows[0]["employeename"].ToString();

            //Next Hierarchy user 

            DataSet dsHierarchyUserMailId = new DataSet();

            dsHierarchyUserMailId = objSales.GetHierarchyUserMailId(userRank, 2, Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["branchid"].ToString()), Convert.ToInt32(ds.Tables["RequisitionDetails"].Rows[0]["departmentid"].ToString()));

            if (dsHierarchyUserMailId.Tables[0].Rows.Count > 0)
            {
                HierarchyUserMailId = "";

                for (int i = 0; i < dsHierarchyUserMailId.Tables[0].Rows.Count; i++)
                {
                    if (dsHierarchyUserMailId.Tables[0].Rows[i]["email"].ToString() != "")
                    {
                        HierarchyUserMailId += dsHierarchyUserMailId.Tables[0].Rows[i]["email"].ToString();

                        HierarchyUserMailId += ",";
                    }
                }
            }

            FinalCreateRequisitionMailId = CreateByMailId + HierarchyUserMailId;

            this.MailSendOnAprrovedOrRejected(lblReqNo.Text, FinalCreateRequisitionMailId, CreateByUserName, "Reject", EmployeeName, "PO Approval", txtComments.Text.Trim(), lblPOComment.Text);

            //UpdateProg1.Visible = false;
            txtComments.Text = "";

        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }

    protected void cmdSentToRequestor_Click(object sender, EventArgs e)
    {
        try
        {
            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("lrequisitionid", DbType.Int32, Convert.ToInt32(lblRequisitionId.Text), ParameterDirection.Input);
                objSpParameters.Add("lrequisitionstatusid", DbType.Int32, 1, ParameterDirection.Input);
                objSpParameters.Add("ccomment", DbType.String, txtComments.Text.Trim(), ParameterDirection.Input);
                objSpParameters.Add("lcreatedby", DbType.Int32, Convert.ToInt32(Session["UserId"]), ParameterDirection.Input);
                objSpParameters.Add("cipaddress", DbType.String, Request.ServerVariables["REMOTE_ADDR"], ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                object value = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_requisitioncomment_insert", objSpParameters);
            }


            /////////////////////Code to update commentstatus/////////////////


            using (CommandExecutor objCommandExecutor = new CommandExecutor("dbconnection"))
            {
                SpParameters objSpParameters = new SpParameters(RdbmsType.MySql);
                objSpParameters.Add("ltype", DbType.Int32, 1, ParameterDirection.Input);
                objSpParameters.Add("lstatus", DbType.Int32, 1, ParameterDirection.Input);
                objSpParameters.Add("lrequisitionid", DbType.Int32, Convert.ToInt32(lblRequisitionId.Text), ParameterDirection.Input);
                objSpParameters.Add("lcommentstatus", DbType.Int32, 1, ParameterDirection.Input);
                objSpParameters.Add("rcode", DbType.Int32, 0, ParameterDirection.Output);
                int value2 = objCommandExecutor.ExecuteDBQuery(CommandType.StoredProcedure, "sproc_requisition_commentstatus_update", objSpParameters);

            }



            //////////////////////////////////////////////////////////////////





            DataSet dsCreateByUserDetails = new DataSet();

            dsCreateByUserDetails = objSales.GetEmployeeByUser(lblRequestorId.Text);
            if (dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() != "")
            {
                CreateByMailId = dsCreateByUserDetails.Tables[0].Rows[0]["email"].ToString() + ",";
            }
            string CreateByUserName = dsCreateByUserDetails.Tables[0].Rows[0]["employeename"].ToString();

            //********Start : get mail id who Approed or Reject Requisition
            DataSet dsEmployeeDetails = new DataSet();
            dsEmployeeDetails = objSales.GetEmployeeByUser(Session["useremployeeid"].ToString());
            string EmployeeName = dsEmployeeDetails.Tables[0].Rows[0]["employeename"].ToString();

            FinalCreateRequisitionMailId = CreateByMailId;

            this.MailSendOnAprrovedOrRejected(lblReqNo.Text, FinalCreateRequisitionMailId, CreateByUserName, "Comment", EmployeeName, "PO Approval", txtComments.Text.Trim(), lblPOComment.Text);
            //UpdateProg1.Visible = false;
            txtComments.Text = "";

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void dgPO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblyear = (Label)(e.Row.Cells[0].FindControl("lblYear"));
            Label lblmonth = (Label)(e.Row.Cells[0].FindControl("lblmonth"));
           
            //string hlink = "javascript:PO('" + lblsupplierid.Text + "','" + lblmonth.Text +  "','" + lblyear.Text + "')";
            //e.Row.Cells[3].Text = "<a href=" + hlink + ">View</a>";
        }
    }

    protected void dgcomment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSrno2 = e.Row.FindControl("lblSrno2") as Label;
            
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            //e.Row.Cells[0].Text = Convert.ToString(sno);
            lblSrno2.Text= Convert.ToString(sno);


        }
    }

    protected bool SetVisibility(object Desc, int length)
    {
        return Desc.ToString().Length > length;
    }

    protected void ReadMoreLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        GridViewRow row = button.NamingContainer as GridViewRow;
        Label descLabel = row.FindControl("lblcomment") as Label;
        button.Text = (button.Text == "Read More") ? "Hide" : "Read More";
        string temp = descLabel.Text;
        descLabel.Text = descLabel.ToolTip;
        descLabel.ToolTip = temp;
    }

    public static string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
            return strDesc.ToString().Substring(0, length) + "...";// + ("Read More");
        else return strDesc.ToString();
    }

    protected void lnkviewfile_Click(object sender, EventArgs e)
    {
        string _url = "../Download.aspx?fname=" + lblbillfilename.Text + "&poid=" + lblPoId.Text;

        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.open(\"" + _url + "\");", true);
    }
    protected void lnkviewmail_Click(object sender, EventArgs e)
    {
        string _url = "../Download.aspx?fname=" + lblmailfilename.Text + "&poid=" + lblPoId.Text;

        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.open(\"" + _url + "\");", true);
    }

    protected void imbback_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmapproval0.aspx?back=1");
    }

    protected void lblViewPo_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label lblyear = (Label)(gv.FindControl("lblYear"));
        Label lblmonth = (Label)(gv.FindControl("lblmonth"));

       // link.Attributes.Add("onclick", "javascript:return PO('" + lblsupplierid.Text + "','" + lblmonth.Text.Trim() + "','" + lblyear.Text.Trim() + "');return false;");

        string url = "frmPO.aspx?id=" + lblsupplierid.Text + "&monthname=" + lblmonth.Text.Trim() + "&yearname=" + lblyear.Text.Trim();

        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");

    }
}