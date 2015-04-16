<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Alert.aspx.cs" Inherits="Alert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 291px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        function abc() {
            var getLength = 0;
//            alert('hi');
            if (document.getElementById('<%=txtemail.ClientID %>').value == "") {
                alert("Email Id Is requird !");
                return false;
            }

            if (document.getElementById('<%=txtemail.ClientID %>').value != "") {

                var getEmailIds = document.getElementById('<%=txtemail.ClientID %>').value;

                var getEmailIdsArray = getEmailIds.split(',');
                getLength = getEmailIdsArray.length;

                if (getLength == 0) {
                    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=txtemail.ClientID %>').value)) {

                    }
                    else {
                        alert('Enter valid Email!');
                        document.getElementById('<%=txtemail.ClientID %>').focus();
                        return false;
                    }
                }
                else {
                   

                    for (var i = 0; i < getEmailIdsArray.length; i++) {

                        var getValue = getEmailIdsArray[i];
                        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(getValue)) {

                        }
                        else {
                            alert('Enter valid Email!' + getValue);
                            return false;
                        }
                    }
                }

               
            }
        }



        function validateEmail(field) {
                       var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,5}$/;                       
            return (regex.test(field)) ? true : false;
        }
        function validateMultipleEmailsCommaSeparated(emailcntl, seperator) {
            var value = emailcntl.value;
          
            if (value != '') {
                var result = value.split(seperator);
                for (var i = 0; i < result.length; i++) {
                    if (result[i] != '') {
                        if (!validateEmail(result[i])) {
                            emailcntl.focus();
                            alert('Please check, `' + result[i] + '` email addresses not valid!');
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        function echeck(str) {

            var at = "@";
            var dot = ".";
            var lat = str.indexOf(at);
            var lstr = str.length;
            var ldot = str.indexOf(dot);
            if (str.indexOf(at) == -1) {
                alert("Invalid E-mail ID");
                return false;
            }

            if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                alert("Invalid E-mail ID:" + str + "");
                return false;
            }

            if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                alert("Invalid E-mail ID:" + str + "");
                return false;
            }

            if (str.indexOf(at, (lat + 1)) != -1) {
                alert("Invalid E-mail ID:" + str + "");
                return false;
            }

            if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                alert("Invalid E-mail ID:" + str + "");
                return false;
            }

            if (str.indexOf(dot, (lat + 2)) == -1) {
                alert("Invalid E-mail ID:" + str + "");
                return false;
            }

            if (str.indexOf(" ") != -1) {
                alert("Invalid E-mail ID");
                return false;
            }

            return true;
        }

        function LTrim(value) {

            var re = /\s*((\S+\s*)*)/;
            return value.replace(re, "$1");

        }

        // Removes ending whitespaces
        function RTrim(value) {

            var re = /((\s*\S+)*)\s*/;
            return value.replace(re, "$1");

        }

        // Removes leading and ending whitespaces
        function trim(value) {

            return LTrim(RTrim(value));

        }

        function checkMailIds(id, id2) {
            debugger;
            var cnt = 0;
            var mailids = id.value;
            var str = mailids.split(",");

            for (var i = 0; i < str.length; i++) {
                var obk = str[i];
                var obk = trim(obk);
                //alert(obk);
                if (echeck(obk) == false) {

                    id2.disabled = true;
                    return false;

                }
                else {

                    cnt = parseInt(cnt) + 1;
                    if (cnt == str.length) {

                        id2.disabled = false;
                        return true;
                    }

                    //return true;
                }



            }

        }

        function chktxt() {

            var txtemail = document.getElementById('< %=txtemail% >');
            if (txtemail.value == "") {
                alert("Enter Emailid");
                return false;
            }
            else {
                return true;
            }
        }
        function fnValidateEmail(EmailId) {
            var EmailRegExp = "\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            var regex = new RegExp(EmailRegExp);

            if (EmailId.match(regex))
                return true;
            else
                return false;
        }

        function fnValidation() {
            var val = document.getElementById("txtemail").value;
            var newtext = val.split("\n");
            for (var i = 0; i < newtext.length; i++) {
                var validEmail = fnValidateEmail(newtext[i])
                if (!validEmail) {
                    alert("The list contains some Invalid Email ID.");
                    return false;
                }
            }

            alert("All Email Address is Valid.");


        } 
    </script>
   
    <asp:UpdatePanel id="updt1"  runat="server" >
        <ContentTemplate>
            <div style="width: 100%; padding: 0px 0px 0px 0px" >
             

        <table width="100%" cellpadding="5px" cellspacing="0" align="center">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Alert
                    
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td style="padding-left:150px">
                    <b>Select Report Name: </b>
                    <asp:DropDownList ID="ddllstType" runat="server" Width="150px" AutoPostBack="true"
                        RepeatDirection="Horizontal" OnSelectedIndexChanged="ddllstType_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Report</asp:ListItem>
                        <asp:ListItem Value="1">Sales</asp:ListItem>
                        <asp:ListItem Value="2">Billing</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tralert" runat="server" visible="false">
                <td colspan="2" style="padding-left:150px">
                    <fieldset style="width: 50%">
                        <legend>Trigger option</legend>
                        <table cellpadding="0" cellspacing="5" border="0" width="100%">
                            <tr>
                                <td colspan="2" align="left" style="padding-left:25%" >
                                    <asp:RadioButtonList AutoPostBack="true" ID="rdobtn" runat="server" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rdobtn_SelectedIndexChanged">
                                        <asp:ListItem Text="Everyday" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="Weekdays" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">
                                    WeekDay :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlweekdays" runat="server" Width="150px">
                                        <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Tuesday " Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Sunday" Value="7"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Time:
                                </td>
                                <td class="style1">
                                    <asp:DropDownList ID="ddltime" runat="server" Width="150px">
                                        <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="09:00" Value="09:00"></asp:ListItem>
                                        <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                        <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                        <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                        <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                        <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                                        <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                                        <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                                        <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                                        <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                                        <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                                        <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                                        <asp:ListItem Text="21:00" Value="21:00"></asp:ListItem>
                                        <asp:ListItem Text="22:00" Value="22:00"></asp:ListItem>
                                        <asp:ListItem Text="23:00" Value="23:00"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email:
                                </td>
                                <td >
                                    <asp:TextBox ID="txtemail" 
                                          runat="server" 
                                        Width="270px" TextMode="MultiLine" Height="58px"></asp:TextBox>
                                        <span style="color:Red"><b>*</b> Emails id separated by ","</span>
                                    <br />
                                    <%--onblur="validateMultipleEmailsCommaSeparated(this,';');" <asp:.RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                   ErrorMessage="Invalid Email Format" ControlToValidate="txtemail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnsubmit"  Text="Submit" runat="server" OnClientClick="return abc()" OnClick="btnsubmit_Click"/>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="2" align="center">
                             <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                            </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="center">
                   
                </td>
            </tr>
        </table>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
