<%@ Page Language="C#" MasterPageFile="~/Site.master" Title="Sales Dashboard" AutoEventWireup="true"
    CodeFile="frmLeadSource.aspx.cs" Inherits="Sales_frmLeadSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <div>
        <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    </div>
    <div style="width: 100%; padding-top: 5px;">
      
        <b>
            <asp:Label ID="lblMonth" runat="server"></asp:Label></b>
        <table cellpadding="3" cellspacing="0" style="border: 1px solid #999; width: 55%;">
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
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <br />
        <div align="center" style="width: 100%; text-align: left;">
            <asp:RadioButton ID="rbLS" runat="server" Text="Affiliated Partnes" AutoPostBack="True"
                Checked="True" OnCheckedChanged="rbLS_CheckedChanged" />
            <asp:RadioButton ID="rbAll" runat="server" Text="All Lead Partners" AutoPostBack="True"
                OnCheckedChanged="rbAll_CheckedChanged" />
            <div align="center" style="width: 100%; text-align: center;">
                <table width="100%">
                    <tr>
                        <td colspan="2" style="vertical-align: top">
                        </td>
                        <td colspan="2" style="vertical-align: top; border:1px;" align="left">
                            <asp:GridView ID="gvleadsource" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                                ShowHeaderWhenEmpty="True" CellPadding="3"   CaptionAlign="Top" ShowFooter="True"
                                AllowSorting="True" OnRowDataBound="gvleadsource_RowDataBound" 
                                 GridLines="Horizontal"
                                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="#333" />
                                <Columns>
                                   
                                    <asp:TemplateField HeaderText="Source" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSource" runat="server" Text='<%#Eval("ccenquirysource") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total</FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prospects(A)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblProspects" runat="server" Text='<%#Eval("Prospects") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalProspects" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FollowUp(B)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblFollowUp" runat="server" Text='<%#Eval("FollowUp") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalFollowUp" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Confirm(C)"  ControlStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesConfirm" runat="server" Text='<%#Eval("SalesConfirm") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSalesConfirm" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ControlStyle Width="100px"></ControlStyle>
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LeadCount(A+B+C)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSumall" runat="server" Text='<%#Eval("SumAll") %>' Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalSumall" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Aff.Amt (E)" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblaffAmt" runat="server" Text='<%#Eval("amt") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalaffAmt" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HighPricing" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblPricing" runat="server" Text='<%#Eval("HighPricing") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPricing" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CardSold" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostSold" runat="server" Text='<%#Eval("CardSold") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCostSold" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmt" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                        <ItemStyle  HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C" />
                                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
