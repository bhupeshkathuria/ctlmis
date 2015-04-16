using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    
    ClayBillingLibrary.UserClass.UserLogin objUserLogin = new ClayBillingLibrary.UserClass.UserLogin();
    DataSet dsUserDetails = new DataSet();
    private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
    private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Web.HttpBrowserCapabilities browse = Request.Browser;
        //Response.Write("Browser Name : " + browse.Browser);
        //Response.Write("Version : " + browse.Version);
        //Response.Write("Type : " + browse.Type);
        if (!Page.IsPostBack)
        {
            lblErrMsg.Text = "";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        objUserLogin.UesrName = txtUsername.Text.Trim();
        objUserLogin.UserPassword = Encrypt(txtPassword.Text.Trim());
        dsUserDetails = objUserLogin.LoginvalidOrInvalid();

        if (dsUserDetails.Tables[0].Rows.Count > 0)
        {
            if (dsUserDetails.Tables[0].Rows[0]["isbillingreportallow"].ToString() == "1")
            {
                Session["UserId"] = dsUserDetails.Tables[0].Rows[0]["userid"].ToString();
                Session["useremployeeid"] = dsUserDetails.Tables[0].Rows[0]["useremployeeid"].ToString();
                Session["reporttype"] = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["reporttype"]);
                Session["billingrpttype"] =dsUserDetails.Tables[0].Rows[0]["billingrpttype"].ToString();

                //fetch & fill  module 
                CurrentSession.clayuser = objUserLogin;
                Response.Redirect("MainPage.aspx");
                return;
            }
            else
            {
                lblErrMsg.Text = "You are not authorized to view this panel !";
                return;
            }
        }
        else
        {
            lblErrMsg.Text = "user name or password invalid!";
            return;
        }
    }


    private static string Encrypt(string Password)
    {
        if (string.IsNullOrEmpty(Password))
            return string.Empty;
        byte[] Value = Encoding.UTF8.GetBytes(Password);
        SymmetricAlgorithm mCSP = new RijndaelManaged();
        mCSP.Key = _key; mCSP.IV = _initVector;
        using (ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                {
                    cs.Write(Value, 0, Value.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    private static string Decrypt(string Value)
    {
        SymmetricAlgorithm mCSP;
        ICryptoTransform ct = null;
        MemoryStream ms = null;
        CryptoStream cs = null;
        byte[] byt; byte[] _result;
        mCSP = new RijndaelManaged();
        try
        {
            mCSP.Key = _key;
            mCSP.IV = _initVector;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            byt = Convert.FromBase64String(Value);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            _result = ms.ToArray();
        }
        catch
        {
            _result = null;
        }
        finally
        {
            if (ct != null)
                ct.Dispose();
            if (ms != null)
                ms.Dispose();
            if (cs != null)
                cs.Dispose();
        }
        return ASCIIEncoding.UTF8.GetString(_result);
    }
}