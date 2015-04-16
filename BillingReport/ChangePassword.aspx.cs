using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClayBillingLibrary;
using System.IO;
using System.Security.Cryptography;
using System.Text;
public partial class ChangePassword : System.Web.UI.Page
{
    ClayBillingLibrary.UserClass.UserLogin objUser = new ClayBillingLibrary.UserClass.UserLogin();
    int userId = 0;
    private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
    private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
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

        if (userId == 0)
        {
            Response.Redirect("Logout.aspx");
        }
        else
        {
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        
        int userId = Convert.ToInt32(Session["UserId"]);
        string oldpassword = Encrypt(txtOldPwd.Text.Trim());
        string newpassword = Encrypt(txtnewpwd.Text.Trim());
        int valchk = 0;
        
        valchk= objUser.CheckPassword(userId, oldpassword);
        if (valchk == 1)
        {
            int val = 0;
            val= objUser.ChangePassword(userId, newpassword);
            if (val == 1)
            {
                lblMsg.Text = "Password Changed Successfully";
                return;
            }
            else
            {
                lblMsg.Text = "Error Changing Password";
                return;
            }
        }
        else
        {
            lblMsg.Text = "Old Password Not Correct";
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
}