<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmdsrdashboard.aspx.cs" Inherits="frmdsrdashboard" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--   http://chart.apis.google.com/chart--%>
    <script type="text/javascript" src="https://www.google.com/jsapi "></script>
    <%--<script type="text/javascript" language="JavaScript" src="JS/FusionCharts.js"></script>--%>
    <script type="text/javascript" language="JavaScript">

        function myJS(myVar) {
            window.alert(myVar);

        }
        function JSFunctionValidate() {
            if (document.getElementById('<%=ddlYear.ClientID%>').selectedIndex == 0) {
                alert("Please select year!!");
                return false;
            }
            if (document.getElementById('<%=ddlMonth.ClientID%>').selectedIndex == 0) {
                alert("Please select month!!");
                return false;
            }
            return true;
        }

        function printSelection() {

            var content = document.getElementById("test2").innerHTML
            alert(content);
            var pwin = window.open('', 'print_content');

            pwin.document.open();
            pwin.document.write('<html><body onload="window.print()">' + content + '</body></html>');
            pwin.document.close();

            setTimeout(function () { pwin.close(); }, 1000);

        }
      
    </script>
    <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlYear" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlMonth" runat="server">
                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February " Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            Branch&nbsp;&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlBranch" Width="150px" runat="server">
                            </asp:DropDownList>
                            <%--<telerik:RadComboBox ID="ddlBranch" runat="server" Height="200px" Width="150px" EmptyMessage="Select Branch"
                                    HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                    AllowCustomText="true" AutoCompleteSeparator=";">
                                </telerik:RadComboBox>--%>
                        </div>
                        <div style="float: left">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return JSFunctionValidate()"
                                OnClick="btnSearch_Click" />
                            <asp:Button ID="btnexport" runat="server" OnClientClick="javascript:printSelection();return false"
                                Visible="false" Text="ExportToPDF" />
                            <%-- <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:printSelection();return false" runat="server" Visible="false">ExportToExcel</asp:LinkButton>--%>
                            <asp:Label ID="lbltotaldsr" runat="server"></asp:Label>
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    <div id="test2" class="slideoutdiv">
        <table width="100%" cellpadding="0" cellspacing="0" border="1">
            <tr id="tr" runat="server" visible="false">
                <td align="center">
                    <b>Total Meeting In OLD Account:<asp:Label ID="lblold" runat="server"></asp:Label></b>
                </td>
                <td align="center">
                    <b>Total Meeting In NEW Account:<asp:Label ID="lbltotalnew" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:Literal ID="ltold" runat="server"></asp:Literal>
                    </div>
                    <div id="chart_divold">
                    </div>
                </td>
                <td>
                    <div>
                        <asp:Literal ID="ltnew" runat="server"></asp:Literal>
                    </div>
                    <div id="chart_divnew">
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" class="text" align="center">
                    <asp:Literal ID="FCLiteral3" runat="server" Visible="false"></asp:Literal>
                </td>
                <td valign="top" class="text" align="center">
                    <asp:Literal ID="FCLiteral4" runat="server" Visible="false"></asp:Literal>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false">
                <td align="center">
                    <b>Total Meeting In FollowUp OLD Account:<asp:Label ID="lblTotalFolOld" runat="server"></asp:Label></b>
                </td>
                <td align="center">
                    <b>Total Meeting In FollowUp NEW Account:<asp:Label ID="lblTotalFolNew" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:Literal ID="ltFolOld" runat="server"></asp:Literal>
                    </div>
                    <div id="chart_DivFolOld">
                    </div>
                </td>
                <td>
                    <div>
                        <asp:Literal ID="ltFolNew" runat="server"></asp:Literal>
                    </div>
                    <div id="chart_DivFolNew">
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" class="text" align="center">
                    <asp:Literal ID="FCLiteral5" runat="server" Visible="false"></asp:Literal>
                </td>
                <td valign="top" class="text" align="center">
                    <asp:Literal ID="FCLiteral6" runat="server" Visible="false"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
    <%--</div>--%>
</asp:Content>
