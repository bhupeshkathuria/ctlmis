<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form::Billing Report</title>
    <link type="text/css" href="Css/style.css" rel="Stylesheet" />
     <script src="JS/jquery.min.js" type="text/javascript"></script>
        <script type="text/javascript">
        $(document).ready(function() {
            $("#ImageButton1").click(function(){
            
                if($("#<%=txtUsername.ClientID %>").val()== "" )
                {
                    alert("User Name is required!");
                    $("input[id$='txtUsername']").focus();
                    return false;
                }
                if($("#<%=txtPassword.ClientID %>").val()== "" )
                {
                    alert("User Password is required!");
                    $("input[id$='txtPassword']").focus();
                    return false;
                }
                var userid=$("#<%=txtUsername.ClientID %>").val();
                var userpwd=$("#<%=txtPassword.ClientID %>").val();
                
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
          <div class="login_container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <img src="images/bg_login_top.gif" alt="" width="373" height="8" />
       </td>
    </tr>
    
    <tr>
        <td valign="top" class="login_container_bg">
            <div class="login_logo">
                <img src="images/logo.jpg" width="105" height="60" border="0" />
            </div>
	        <div align="center" class="login_area">
	            <table width="350" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="23%" height="35" align="left" valign="middle" class="verdana12bold_white">Username:</td>
                        <td width="60%" align="left" valign="middle">
                            <asp:TextBox ID="txtUsername" runat="server" class="login_area_textbox" Width="200px" size="32"></asp:TextBox>
                        </td>
                        <td width="17%">&nbsp;</td>
                    </tr>
                    
                     <tr>
                        <td height="35" align="left" valign="middle" class="verdana12bold_white">Password:</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px" class="login_area_textbox" size="32"></asp:TextBox>
                        </td>
                          <td align="left" style="padding-left:7px;"> 
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_login.gif" 
                                  onclick="ImageButton1_Click"  />
                        </td>
                     </tr>
                </table>
            </div>
	    </td>
    </tr>
    
    <tr>
      <td><img src="images/bg_login_btm.gif" alt="" width="373" height="17" /></td>
    </tr>
    
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblErrMsg" runat="server" CssClass="lblmsgfont"  ></asp:Label>
        </td>
    </tr>
    
  </table>
</div>
    </div>
    </form>
</body>
</html>
