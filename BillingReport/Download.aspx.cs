using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pdfPath = string.Empty;
        string localpdfPath = string.Empty;
        string _filename=string.Empty;
        string _poid = string.Empty;
        string ftpServerIP = "ctmydbindea.claytelecom.com";
        string ftpUserID = "docupload";
        string ftpPassword = "DuWzZEcX";
        try
        {
            var u = Request.Url;
            if (u.Query.Contains("%20"))
            {
                var ub = new UriBuilder(u);
                Console.WriteLine(ub.Query);
                string query = ub.Query;
                //note bug in Query property - it includes ? in get and expects it not to be there on set
                ub.Query = ub.Query.Replace("%20", "+").Substring(1);
                Response.StatusCode = 301;
                Response.RedirectLocation = ub.Uri.AbsoluteUri;
                Response.End();
            }
            if (Request.QueryString["fname"] != null)
            {
                _filename = Request.QueryString["fname"];
            }
            if (Request.QueryString["poid"] != null)
            {
                _poid = Request.QueryString["poid"];
            }
            string filePath = Server.MapPath("PODOCS");
            if (Directory.Exists(filePath))
            {
                System.IO.Directory.Delete(filePath, true);
            }
            System.IO.Directory.CreateDirectory(filePath);

            string uri = "ftp://" + ftpServerIP + "/erpdocs/POBILL" + "/" + _poid + "/" + _filename;

            //string uri = "http://apps.claytelecom.com/BillingReport/Download.aspx?fname=Hriday-1260001.pdf&poid=1382";

            FtpWebRequest reqFTP;

            FileStream outputStream = new FileStream(filePath + "/" + _filename, FileMode.Create);
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/erpdocs/POBILL" + "/" + _poid + "/" + _filename));
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

            string myfilepath = Server.MapPath("~/PODOCS/" + _filename);
            System.IO.FileInfo file = new System.IO.FileInfo(myfilepath);

            WebClient client = new WebClient();
            Byte[] buffer2 = client.DownloadData(myfilepath);
            Response.AddHeader("content-length", buffer2.Length.ToString());
            //Response.AddHeader("Content-Disposition", "inline;filename=" + myfilepath + ".msg");
            Response.BinaryWrite(buffer2);
            //Response.Write(buffer2);
            
            switch (file.Extension.ToLower())
            {
                    
                case ".pdf":
                        Response.ContentType = "application/pdf";
                    break;
                case ".doc":
                    Response.ContentType = "application/msword";                    
                    break;
                case ".docx":
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".htm":
                    Response.ContentType = "application/HTML";
                    break;
                    case ".msg":
                    Response.ContentType = "application/vnd.ms-outlook";
                    
                    break;
            }
        }
        catch (Exception ex)
        {
            div1.Visible = true;
        }
    }
}