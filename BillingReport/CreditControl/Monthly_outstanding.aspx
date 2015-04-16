<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"CodeFile="Monthly_outstanding.aspx.cs"Inherits="CreditControl_Monthly_outstanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   <%-- <asp:UpdatePanel ID="updt1" runat="server">
        <ContentTemplate>--%>
            <div>
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="Header_text" colspan="3" align="left" style="width: 300px">
                            &nbsp;&nbsp; <b>Monthly Outstanding</b>
                        </td>
                    </tr>
                    <tr id="trexport" runat="server" visible="false">
                        <td style="padding-left: 20px">
                            <b>Export Excel </b>
                            <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                                OnClick="imgexport_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 20px">
                            <asp:GridView ID="GridView1" Width="800px" ShowFooter="True" runat="server" AutoGenerateColumns="False"
                                OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltext" runat="server" Text="Grand Total" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <FooterStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Outstanding" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutstanding" runat="server" Text='<%#Eval("Outstanding") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOutstanding" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Credit Amount" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreditamount" runat="server" Text='<%#Eval("Creditamount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCreditamount" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Collected" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCollected" runat="server" Text='<%#Eval("Collected") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCollected" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Yesterday's coll." HeaderStyle-BackColor="maroon"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblYesterday_coll" runat="server" Text='<%#Eval("Yesterday_coll") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalYesterday_coll" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="%Till date" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTill_date" runat="server" Text='<%#Eval("Till_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTill_date" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pending" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPending" runat="server" Text='<%#Eval("Pending") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalPending" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="%Pending" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblper_Pending" runat="server" Text='<%#Eval("per_Pending") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalper_Pending" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
