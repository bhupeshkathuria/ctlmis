<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesDashboard.aspx.cs" Inherits="Sales_SalesDashboard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div style="width: 100%;">
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <b><asp:Label ID="lblMonth" runat="server"></asp:Label></b>
        
       
        <table cellpadding="0" cellspacing="0" style="border: 1px solid Black; width: 100%;">
            <tr>
                <td>
                    Select Year:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    Select Month:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        OnClick="btnSearch_Click"/>
                </td>
            </tr>
        </table>
               

          <br />

         <table cellpadding="1" cellspacing="0" width="100%" border="1">
            <tr>
                <td align="center" style="width:50%">
                    <asp:Repeater ID="rptr1" runat="server" OnItemDataBound="rptr1_ItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0px" border="1" cellspacing="3px" width="100%" style="border: 1px solid Black">
                                <tr>
                                    <td>
                                        <b>Region</b>
                                    </td>
                                    <td>
                                        <b>Total</b>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 50%; border-right-color: Black;">
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("zone") %>'></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblRegionCount" runat="server" Text='<%#Eval("ZoneCount") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblZoneTotal" runat="server" Text='<%#Eval("ZoneCount") %>' Font-Bold="true"
                                        ForeColor="Black"></asp:Label>
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>

                <td align="center" style="width:50%; vertical-align:top;">
                    <asp:Repeater ID="rptr2" runat="server" OnItemDataBound="rptr2_ItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="3px" cellspacing="0" width="100%" style="border: 1px solid Black">
                                <tr>
                                    <td>
                                        <b>Branch</b>
                                    </td>
                                    <td>
                                        <b>Total</b>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 50%; border-right-color: Black;">
                                    <asp:Label ID="lblBanch" runat="server" Text='<%#Eval("branchname") %>'></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblBranchCount" runat="server" Text='<%#Eval("BranchCount") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblBranchTotal" runat="server" Text='<%#Eval("BranchCount") %>'></asp:Label></b>
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>

                
            </tr>

            <tr>
                <td style="vertical-align: top; width:50%;">
                    <asp:Repeater ID="rptr3" runat="server" OnItemDataBound="rptr3_ItemDataBound">
                        <HeaderTemplate>
                            <table cellpadding="0px" cellspacing="15px" width="60%" style="border: 1px solid Black">
                                <tr>
                                    <td>
                                        <b>Status</b>
                                    </td>
                                    <td>
                                        <b>Total</b>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 50%; border-right-color: Black;">
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("orderstatus") %>'></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblRAFStatusCount" runat="server" Text='<%#Eval("RafStatusCount") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRAFTotal" runat="server" Text='<%#Eval("RafStatusCount") %>'></asp:Label>
                                </td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>

         </table>
    </div>
    </form>
</body>
</html>
