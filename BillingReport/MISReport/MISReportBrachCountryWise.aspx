<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MISReportBrachCountryWise.aspx.cs" Inherits="MISReport_MISReportBrachCountryWise" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 
    <table cellpadding="0px" cellspacing="0px" width="100%">
        <tr>
            <td class="Header_text" align="left">
                &nbsp;&nbsp; CRM / Reports / Mis Report
            </td>
        </tr>
    </table>
    <div style="width: 100%">
        <fieldset style="width: 30%;">
            <legend>Show Report</legend>
            <div style="float: left">
                Financial Year &nbsp;&nbsp;
            </div>
            <div style="float: left">
                <asp:DropDownList ID="ddlYear" Width="150px" runat="server">
                </asp:DropDownList>
                &nbsp;
            </div>
            <div style="float: left">
                <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
            </div>
        </fieldset>
    </div>
    <br />
    <div align="center" style="width:100%">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center" style="height: 15px; color: Green">
                    <asp:Label ID="err" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="font-weight: normal;">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 15px">
                    <asp:Label ID="lblreport" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblcnt" runat="server" Font-Bold="True" Visible="False"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 15px">
                    <asp:Label ID="lblBranchReport" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
