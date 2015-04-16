<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmSalesReportDateWise.aspx.cs" Inherits="Sales_frmSalesReportDateWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
    <div style="width: 100%; padding-top: 5px;" align="center">
        <b>
            <asp:Label ID="lblMonth" runat="server"></asp:Label></b>
        <table width="99%" cellpadding="0" cellspacing="1px">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" style="border: 1px solid Black">
                        <tr>
                            <td>
                                From Date <span style="color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox><span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgStartDate" /></span>
                                <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txtFromDate"
                                    Format="yyyy-MM-dd" PopupButtonID="imgStartDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txtFromDate"
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                To Date<span style="color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgEndDate" /></span>
                                <asp:CalendarExtender ID="clnEndDate" runat="server" TargetControlID="txtToDate"
                                    Format="yyyy-MM-dd" PopupButtonID="imgEndDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="reqtxtEndDate" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter To Date" ControlToValidate="txtToDate" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                             <td>
                                 <asp:DropDownList ID="ddlSearch" runat="server">
                                     <asp:ListItem>ByOrderDate</asp:ListItem>
                                     <asp:ListItem>ByDeliveryDate</asp:ListItem>
                                     <asp:ListItem>ByActualDeliveryDate</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSerach" runat="server" Text="Search" OnClick="btnSerach_Click"
                                    ValidationGroup="Report" />
                                <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Range is not valid!!!"
                                    ValidationGroup="Report" ForeColor="Red" ControlToValidate="txtToDate" ControlToCompare="txtFromDate"
                                    Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <b>
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div align="center" style="width: 100%" align="center">
            <div class="box" style="width: 250px; float: left; margin: 0 20px">
                <h2>
                    Region &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total</h2>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:Repeater ID="rptr1" runat="server" OnItemDataBound="rptr1_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellpadding="0px" cellspacing="15px" width="100%" style="border: 1px solid Black">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 50%; border-right-color: Black;">
                                            <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("zone") %>' Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="width: 50%">
                                            <asp:Label ID="lblRegionCount" runat="server" Text='<%#Eval("ZoneCount") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                    <%--<td>
                                     <asp:Label ID="lblItemCount" runat="server" Text="Total" Font-Bold="true" ForeColor="Green"></asp:Label>
                                    </td>--%>
                                        <td>
                                            <asp:Label ID="lblZoneTotal" runat="server" Text='<%#Eval("ZoneCount") %>' Font-Bold="true"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
            <%----------------------------%>
            <div class="box" style="width: 250px; float: left; margin: 0 20px">
                <h2>
                    Product &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total</h2>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:Repeater ID="rptr6" runat="server" OnItemDataBound="rptr6_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellpadding="0px" cellspacing="15px" width="100%" style="border: 1px solid Black">
                                        <%--<tr>
                                            <td colspan="2">
                                                <b>BB/Data Cards & USA Pre</b>
                                            </td>
                                        </tr>--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 50%; border-right-color: Black;">
                                            <asp:Label ID="lblpackage" runat="server" Font-Bold="true" Text='<%#Eval("packagetypename") %>'></asp:Label>
                                        </td>
                                        <td style="width: 50%">
                                            <asp:Label ID="lbl" runat="server" Text='<%#Eval("Count1") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>

                                    <td>
                                    
                                        <asp:Label ID="lblItemCount" runat="server" Text="GrandTotal" Font-Bold="true" ForeColor="Black"></asp:Label>
                                    </td>
                                        <td>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Count1") %>' Font-Bold="true"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="box" style="width: 350px; float: left; margin: 0 20px">
                <h2>
                    Zone &nbsp;&nbsp; Product&nbsp;&nbsp; &nbsp;&nbsp; Total</h2>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:Repeater ID="rptr7" runat="server" onitemdatabound="rptr7_ItemDataBound">
                                <HeaderTemplate>
                                    <table cellpadding="0px" cellspacing="15px" width="100%" style="border: 1px solid Black">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="width: 50%; border-right-color: Black;">
                                            <asp:Label ID="lblzone" runat="server" Text='<%#Eval("zone") %>' Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="width: 50%">
                                            <asp:Label ID="lblproduct" runat="server" Text='<%#Eval("packagetypename") %>'></asp:Label>
                                        </td>
                                        <td style="width: 50%">
                                            <asp:Label ID="lblcount" runat="server" Text='<%#Eval("count1") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                <tr>
                                <td>
                                <asp:Label ID="lblItemCount" runat="server" Text="GrandTotal" Font-Bold="true" ForeColor="Black"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>

                                <asp:Label ID="lblzoneTotal" runat="server" Text='<%#Eval("count1") %>' Font-Bold="true" ForeColor="Black"></asp:Label>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                
                                </td>
                                </tr>

                                
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
