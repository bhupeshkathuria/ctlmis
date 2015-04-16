<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLoginDetails.aspx.cs"
    Inherits="ErpReports_frmLoginDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top: 25px">
        <table cellpadding="0px" cellspacing="0px" width="100%">
            <tr>
                <td>
                    <asp:GridView ID="grdLoginDetails" runat="server" Width="830px" AutoGenerateColumns="false"
                        ShowFooter="true" AlternatingRowStyle-BackColor="#f5f5f5" HeaderStyle-BackColor="#b9b9b9"
                        HeaderStyle-ForeColor="White" OnRowDataBound="grdLoginDetails_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrno" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                                    <%--<asp:Label ID="lblGrand" runat="server" Text="Total Time"></asp:Label>--%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Login">
                                <ItemTemplate>
                                    <asp:Label ID="lbllogin" runat="server" Text='<%#Eval("login")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Logout">
                                <ItemTemplate>
                                    <asp:Label ID="lbllogout" runat="server" Text='<%#Eval("logout")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalTime" runat="server" Text='<%#Eval("TotalTime")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterTemplate>
                                    <%--<asp:Label ID="lblgrndtotal" runat="server"></asp:Label>--%>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="IP Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblipaddress" runat="server" Text='<%#Eval("ipaddress")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
