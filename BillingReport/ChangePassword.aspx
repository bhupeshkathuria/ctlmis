<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <script language="JavaScript" type="text/javascript">
      function valid() {
          if (document.getElementById('<%=txtOldPwd.ClientID %>').value == "") {
              alert("Old Password is required!");
              document.getElementById("<%=txtOldPwd.ClientID %>").focus();
              return false;
          }

          if (document.getElementById('<%=txtnewpwd.ClientID %>').value == "") {
              alert("New Password is required!");
              document.getElementById("<%=txtnewpwd.ClientID %>").focus();
              return false;
          }

          if (document.getElementById('<%=txtconfirmpwd.ClientID %>').value == "") {
              alert("Confirm Password is required!");
              document.getElementById("<%=txtconfirmpwd.ClientID %>").focus();
              return false;
          }

          var newpwd = "";
          var confirmpwd = "";

          newpwd = document.getElementById('<%=txtnewpwd.ClientID %>').value;
          confirmpwd = document.getElementById('<%=txtconfirmpwd.ClientID %>').value;

          if (newpwd == confirmpwd) {
          }
          else {
              alert("Confirm Password does not match!");
              return false;
          }
          return confirm("Do you want to change password!");
      }

     
     </script>


    <div align="center" style="padding-top:10px;">
        <table cellpadding="3" cellspacing="0" width="50%"   style="border:2px Solid #EBEBEB;" >
            <tr>
                <td colspan="2" style="vertical-align:middle;font-size:11px; font-weight:bold; height:30px; text-align:center; background-color:#EBEBEB;">
                        Change Password
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    &nbsp;Old Password
                </td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtOldPwd" runat="server" Width="200px" TextMode="Password"  Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    &nbsp;New Password
                </td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtnewpwd" runat="server" Width="200px" TextMode="Password" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    &nbsp;Confirm Password
                </td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtconfirmpwd" runat="server" Width="200px" TextMode="Password" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="font-family:Verdana; font-size:11px; font-weight:bold; color:Red; font-variant:normal;">
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td  align="left">
                    <asp:Button  ID="btnChangePassword" runat="server" Text="Change Password"  
                        Width="125px" Height="30px" onclick="btnChangePassword_Click"  OnClientClick="return valid();" />
                </td>
            </tr>
        </table> 
    </div>

</asp:Content>

