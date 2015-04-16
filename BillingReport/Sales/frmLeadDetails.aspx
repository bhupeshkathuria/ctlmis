<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmLeadDetails.aspx.cs" Inherits="Sales_frmLeadDetails" %>

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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 50%">
                <%--<asp:GridView ID="grdlead" runat="server" Width="100%" ShowFooter="True" CellPadding="4"
                    UseAccessibleHeaderText="true"  ForeColor="#333333" GridLines="None" HorizontalAlign="Right"
                    >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>--%>
                <asp:GridView ID="grdlead" runat="server" Width="100%" AutoGenerateColumns="false"
                    AllowSorting="true" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                    RowStyle-Font-Names="Arial" onrowdatabound="grdlead_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="Year" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"  />
                        <asp:BoundField HeaderText="MonthName" DataField="MonthName" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                        <asp:BoundField HeaderText="LeadSource" DataField="LeadSource" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"/>
                        <asp:BoundField HeaderText="SaleConfirmed" DataField="SaleConfirmed" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"/>
                        <asp:BoundField HeaderText="CardSold" DataField="CardSold" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"/>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle CssClass="text_box" />
                    <EditRowStyle />
                    <PagerSettings Position="Top" />
                    <FooterStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
