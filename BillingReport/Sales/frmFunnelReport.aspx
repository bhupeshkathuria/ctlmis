<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmFunnelReport.aspx.cs" Inherits="Sales_frmFunnelReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="99%" cellpadding="0" cellspacing="1px">
        <tr>
            <td align="center">
                <table cellpadding="10" cellspacing="0" style="border: 1px solid Black">
                    <tr>
                        <td>
                            Select Year:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Report"
                                ForeColor="Red" ErrorMessage="Required Field !" ControlToValidate="ddlYear" InitialValue="Select"
                                SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            From Month:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFromMonth" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            To Month:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlToMonth" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Branch:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" 
                                ValidationGroup="Report" Width="135px" 
                                onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Sale Category:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSaleCategory" runat="server" ValidationGroup="Report" AutoPostBack="true"
                                Width="135px" OnSelectedIndexChanged="ddlSaleCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Select Employee:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEmployee" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSerach" runat="server" Text="Search" ValidationGroup="Report"
                                OnClick="btnSerach_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total Funnel:
                        </td>
                        <td>
                            <asp:Label ID="lblTotalFunnel" runat="server"></asp:Label>
                        </td>
                        <td>
                            Total Achievement:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:Label ID="lblTotalAchievement" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="70%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                <asp:GridView ID="grdFunnel" runat="server" Width="100%" AutoGenerateColumns="false"
                                    AllowSorting="true" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                                    RowStyle-Font-Names="Arial" OnRowDataBound="grdFunnel_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="Account Manager" DataField="AccountManager" />
                                        <asp:BoundField HeaderText="Branch" DataField="BranchName" />
                                        <asp:BoundField HeaderText="Customer" DataField="Customer" />
                                        <asp:BoundField HeaderText="BR Type" DataField="BRType" />
                                        <asp:BoundField HeaderText="CustomerType" DataField="CustomerType" />
                                        <asp:BoundField HeaderText="Month" DataField="Month" />
                                        <asp:BoundField HeaderText="Year" DataField="Year" />
                                        <asp:BoundField HeaderText="FunnelTarget" DataField="FunnelTarget" />
                                        <asp:BoundField HeaderText="Achievement" DataField="Achievement" />
                                        <asp:BoundField HeaderText="Achievement%" DataField="Achievement%" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltarget" runat="server" Text='<%#Eval("FunnelTarget") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblachievement" runat="server" Text='<%#Eval("Achievement") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <RowStyle CssClass="text_box" />
                                    <EditRowStyle />
                                    <PagerSettings Position="Top" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
