<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPODetails.aspx.cs" Inherits="ErpReports_frmPODetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <link href="~/Css/Main.css" rel="stylesheet" type="text/css" />--%>
    <link href="~/Css/style.css" rel="stylesheet" type="text/css" />
    <%--<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top: 25px">
        <table cellpadding="0px" cellspacing="0px" width="100%">
            <tr>
                <td>
                    <asp:GridView ID="grdPODetails" runat="server" Width="830px" AutoGenerateColumns="false" ShowFooter="true"
                        OnRowDataBound="grdPODetails_RowDataBound" AlternatingRowStyle-BackColor="#f5f5f5" HeaderStyle-BackColor="#b9b9b9" HeaderStyle-ForeColor="White"> 
                        
                        <Columns>
                            <asp:TemplateField HeaderText="SrNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrno" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left"/>
                                <HeaderStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                                <asp:Label ID="lblGrand" runat="server" Text="Grand Total"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("itemname")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Left"/>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("quantity")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("unitprice")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VAT">
                                <ItemTemplate>
                                    <asp:Label ID="lblVAT" runat="server" Text='<%#Eval("vat")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service Tax">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTax" runat="server" Text='<%#Eval("servicetax")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterTemplate>
                                <asp:Label ID="lblgrndtotal" runat="server"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
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
