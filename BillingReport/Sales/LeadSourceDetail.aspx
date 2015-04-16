<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LeadSourceDetail.aspx.cs" Inherits="Sales_LeadSourceDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .record-search
        {
            width: 70%;
            height: auto;
            font-family: 'Proxima Nova' , 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            color: #666;
            line-height: 26px;
        }
        .record-search input
        {
            width: 120px;
            height: 20px !important;
            border: 1px solid #999;
            background: #f8f8f8;
            color: #999;
            padding: 2px 5px;
        }
        .report-date input
        {
            width: 120px;
            height: 18px !important;
            border: 1px solid #999;
            background: #f8f8f8;
            color: #999;
            padding: 2px 5px;
        }
        .g-btn input[type="submit"]
        {
            font: normal 11px Verdana;
            color: #6c6c6c;
            padding: 1px 2px 3px 2px;
            border: 1px solid #d3d3d3;
            border-radius: 4px;
            background: url(../images/patt.jpg) repeat;
        }
        .record-search .g-btn1
        {
            width: 60px !important;
            height: 20px !important;
            float: left;
            background: #ccc;
            margin: 5px 0;
            cursor: pointer;
        }
        .record-result
        {
            width: 98%;
            height: auto;
            font-family: 'Proxima Nova' , 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            color: #666;
            margin: 15px 0 0 0;
        }
        .record-result table
        {
            color: #666;
            border-collapse: collapse;
        }
        .record-result th
        {
            border: none;
            color: #fff;
            border-collapse: collapse;
            background: #017DC3;
            height: 25px;
            line-height: 25px;
            padding: 0 5px;
        }
        .record-result td
        {
            border: 1px solid #B8B6B6;
            border-collapse: collapse;
            color: #666;
            height: 22px;
            padding: 2px 5px;
            font-size: 13px;
        }
        .force-right
        {
            text-align: right !important;
        }
        .force-right-spn
        {
            float: right !important;
        }
        .force-left
        {
            text-align: left !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        &nbsp;
        <table cellpadding="0" cellspacing="0" border="0" width="75%">
            <tr>
                <td>
                    <fieldset>
                        <legend>Searching criteria</legend>
                        <table cellpadding="0" cellspacing="0" border="0" width="90%">
                            <tr>
                                <td>
                                    From Date:
                                </td>
                                <td class="report-date">
                                    <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox><span>
                                        <img alt="Calender" src="../Images/calender_icon.jpg" id="img1" /></span>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                        Format="yyyy-MM-dd" PopupButtonID="img1">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Report"
                                        ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txtfromdate"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    To Date:
                                </td>
                                <td class="report-date">
                                    <asp:TextBox ID="txttodate" runat="server"></asp:TextBox><span>
                                        <img alt="Calender" src="../Images/calender_icon.jpg" id="imgto" /></span>
                                    <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txttodate"
                                        Format="yyyy-MM-dd" PopupButtonID="imgto">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                        ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txttodate"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <%--<asp:TextBox ID="txttodate" runat="server" Width="150px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate">
                            </asp:CalendarExtender>--%>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbaffiliate" Text="Affiliate" runat="server" GroupName="lead" Checked="true" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbcst" Text="ERP Customer" runat="server" GroupName="lead"/>
                                </td>
                                <td class="g-btn">
                                    <%-- <asp:LinkButton ID="lnksearch" runat="server" CssClass="submit-lead" OnClick="lnksearch_Click">Search</asp:LinkButton>--%>
                                    <asp:Button ID="lnksearch" Width="50px" runat="server" Text="Search" ValidationGroup="Report"
                                        OnClick="lnksearch_Click" />
                                    <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Range is not valid!!!"
                                        ValidationGroup="Report" ForeColor="Red" ControlToValidate="txttodate" ControlToCompare="txtfromdate"
                                        Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Total Leads:</b>
                                </td>
                                <td colspan="4">
                                    <asp:Label ID="lbltotallead" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnllead" runat="server" Visible="false">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Lead Source MIS</legend>
                            <asp:Label ID="lbllead" runat="server"></asp:Label>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Lead Source Combine</legend>
                            <asp:Label ID="lbllead2" runat="server"></asp:Label>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Affiliated Partners</legend>
                            <asp:Label ID="lblaffiliated" runat="server"></asp:Label>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <fieldset id="txt1" runat="server">
                            <legend>All Lead Partners</legend>
                            <asp:Label ID="lblalllead" runat="server"></asp:Label>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlcst" runat="server" Visible="false">
            <tr>
                <td>
                    <fieldset id="Fieldset1" runat="server">
                        <legend>CST Lead Status</legend>
                        <asp:Label ID="lblcstleads" runat="server"></asp:Label>
                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
    </div>
</asp:Content>
