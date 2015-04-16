using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clay.Sale.Bll;
using System.Net;
using System.IO;

public partial class ErpReports_frmapproval0 : System.Web.UI.Page
{
  static int myempcode = 0;

    //int reqtype = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //myempcode = Convert.ToInt16(Session["useremployeeid"]);
            //reqtype = Convert.ToInt16(Request.QueryString["reqtype"].ToString());
            ddlApprovalType.SelectedIndex = 0;
            RadioButtonList1.Items[0].Selected = true;
            //BindGrid(2, "New");
        }
        myempcode = Convert.ToInt16(Session["useremployeeid"]);
        if (Request.QueryString["back"] == "1")
        {
            ddlApprovalType.SelectedIndex = 1;
            //BindGrid(2, "New");
            if(RadioButtonList1.Items[0].Selected==true)
            {
            RadioButtonList1.Items[0].Selected = true;
            BindGrid(2, "New");
            }
            else
            {
            RadioButtonList1.Items[1].Selected = true;
            BindGrid(2, "Approved");
            }
        }
    }

    private void BindGrid(int reqtype, string status)
    {
        try
        {
            grdRequest.DataSource = null;
            SalesSummaryReport objSale = new SalesSummaryReport();
            DataSet ds = new DataSet();            
            ds = objSale.GetApprovalRequest(myempcode, reqtype, status);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdRequest.DataSource = ds.Tables[0];
                grdRequest.DataBind();
            }
            else
            {
                grdRequest.DataSource = ds.Tables[0];
                grdRequest.DataBind();
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _requisitionTypeId = 0;
        if (ddlApprovalType.SelectedIndex > 0)
        {
            _requisitionTypeId = Convert.ToInt32(ddlApprovalType.SelectedValue);
            if (RadioButtonList1.Items[0].Selected == true)
            {
                BindGrid(_requisitionTypeId, "New");
            }
            if (RadioButtonList1.Items[1].Selected == true)
            {
                BindGrid(_requisitionTypeId, "Approved");
            }
        }
    }

    protected void grdRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int sno = e.Row.RowIndex;
            sno = sno + 1;
            e.Row.Cells[1].Text = Convert.ToString(sno);
            
           
            Label lblReqNo = (Label)e.Row.FindControl("lblReqNo");

            Label lblRequisitionid = (Label)e.Row.FindControl("lblRequisitionid");

            Label lblbillfilename = (Label)e.Row.FindControl("lblbillfilename");

            Label MailFileName = (Label)e.Row.FindControl("lblmailfilename");

            Label POID = (Label)e.Row.FindControl("lblpoid");

            //string hlink = "javascript:calldetails('" + lblReqNo.Text + "','" + lblRequisitionid.Text + "')";            
            //e.Row.Cells[9].Text = "<a href=" + hlink + ">View</a>";

            //string hlink2 = "javascript:calldetails2('" + lblbillfilename.Text + "','" + POID.Text + "')";
            //e.Row.Cells[8].Text = "<a href=" + hlink2 + ">View</a>";

            //string hlink3 = "javascript:calldetails2('" + MailFileName.Text + "','" + POID.Text + "')";
            //e.Row.Cells[9].Text = "<a href=" + hlink3 + ">View</a>";




        }
    }

    protected void ddlApprovalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _requisitionTypeId = 0;
        if (ddlApprovalType.SelectedIndex > 0)
        {
            _requisitionTypeId = Convert.ToInt32(ddlApprovalType.SelectedValue);
            if (RadioButtonList1.Items[0].Selected == true)
            {
                BindGrid(_requisitionTypeId, "New");
            }
            if (RadioButtonList1.Items[1].Selected == true)
            {
                BindGrid(_requisitionTypeId, "Approved");
            }
        }
        else
        {
            BindGrid(0, "New");
        }
    }

    protected void lblViewMail_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label RequisitionID = (Label)gv.FindControl("lblRequisitionid");
        Label MailFileName = (Label)gv.FindControl("lblmailfilename");
        Label POID = (Label)gv.FindControl("lblpoid");
        //string filename = "c:\\test.txt";
        string ftpServerIP = "203.122.57.227";
        string ftpUserID = "erp";
        string ftpPassword = "erp@123";
        //string filePath = "C:\\FTP";

        if (MailFileName.Text.Trim().Length > 0)
        {

            FileInfo fileInf = new FileInfo(MailFileName.Text.Trim());

            string filePath = @"C:\POMail" + "\\" + @"PODOCBILL" + "\\" + POID.Text.Trim().ToString();

            if (Directory.Exists(filePath))
            {
                System.IO.Directory.Delete(filePath, true);
            }
            System.IO.Directory.CreateDirectory(filePath);

            string uri = "ftp://" + ftpServerIP + "/erpdocs/POBILL" + "/" + POID.Text.Trim() + "/" + MailFileName.Text.Trim();

            FtpWebRequest reqFTP;



            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + MailFileName.Text.Trim(), FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/erpdocs/POBILL" + "/" + POID.Text.Trim() + "/" + MailFileName.Text.Trim()));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();

                System.IO.FileInfo file = new System.IO.FileInfo(filePath + "\\" + MailFileName.Text.Trim().ToString());
                if (file.Exists)  //set appropriate headers  
                {
                    System.Diagnostics.Process.Start(filePath + "/" + MailFileName.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message;
            }
        }
        else
        {
            Response.Write("File Doesn't Exist.");
        }

    }

    protected void lblViewBill_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label RequisitionID = (Label)gv.FindControl("lblRequisitionid");
        Label lblbillfilename = (Label)gv.FindControl("lblbillfilename");
        Label lblPOID111 = (Label)gv.FindControl("lblpoid");

        if (lblbillfilename.Text.Trim().Length > 0)
        {
            try
            {
                string url = "../Download.aspx?fname=" + lblbillfilename.Text.Trim() + "&poid=" + lblPOID111.Text.Trim();
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>openNewWin('" + url + "')</script>");
            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message;
            }
        }
        else
        {
            
        }
    }

    protected void lblView_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label lblReqNo = (Label)gv.FindControl("lblReqNo");
        Label lblRequisitionid = (Label)gv.FindControl("lblRequisitionid");
        //Session["customerid"] = CustomerID.Text;
        Response.Redirect("frmapproval1.aspx?reqno=" + lblReqNo.Text + "&requisitionid=" + lblRequisitionid.Text);
    }
    protected void lnkreqno_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)(link.Parent.Parent);
        Label lblReqNo = (Label)gv.FindControl("lblReqNo");
        Label lblRequisitionid = (Label)gv.FindControl("lblRequisitionid");
        //Session["customerid"] = CustomerID.Text;
        Response.Redirect("frmapproval1.aspx?reqno=" + lblReqNo.Text + "&requisitionid=" + lblRequisitionid.Text);
    }
}