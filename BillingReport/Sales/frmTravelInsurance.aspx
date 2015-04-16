<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmTravelInsurance.aspx.cs" Inherits="Sales_frmTravelInsurance" %>

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
                    </tr>
                    <tr>
                        <td>
                            Total Amount:
                        </td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnSerach" runat="server" Text="Search" ValidationGroup="Report"
                                OnClick="btnSerach_Click" />
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
                                <asp:GridView ID="grdTravel" runat="server" Width="100%" AutoGenerateColumns="false"
                                    AllowSorting="true" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                                    RowStyle-Font-Names="Arial" OnRowDataBound="grdTravel_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="Month" DataField="Month" />                                        
                                        <asp:BoundField HeaderText="AccountManager" DataField="AccountManager" />
                                        <asp:BoundField HeaderText="Branch" DataField="Branch" />
                                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <RowStyle HorizontalAlign="Right" />
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
