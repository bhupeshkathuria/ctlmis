<%@ Page Language="C#" AutoEventWireup="true" CodeFile="highestCorporateCountryBranchWise.aspx.cs"
    Inherits="MISReport_highestCorporateCountryBranchWise" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="gridviewScroll.min.js"></script>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function pageLoad() {
            document.body.style.overflow = "hidden";

            $('#GridView5').gridviewScroll({
                width: 290 ,
                height: 500

            });

            $('#GridView6').gridviewScroll({
                width: 520,
                height: 500
                

            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="df" runat="server">
        </asp:ScriptManager>
        <div style="width: 100%; padding: 0px 0px 0px 0px">
            <table width="100%" cellpadding="5px" cellspacing="0">
                <tr>
                    <td class="Header_text" align="left">
                        &nbsp;&nbsp; Highest Corporate Sale
                    </td>
                    <td class="Header_text" align="right">
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table cellspacing="0px" cellpadding="0px" style="margin-bottom: 55px;">
            <tr>
                <td align="left" style="padding-left: 50px" colspan="3">
                    <strong>Customer :</strong>
                    <asp:Label ID="lblCustomerName" ForeColor="Gray" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-left: 50px">
                    <strong>Country Wise</strong>
                </td>
                <td>
                </td>
                <td align="left">
                    <strong>Branch Wise</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td style="border: none; padding-left: 50px; " valign="top">
                    <asp:Repeater ID="RadGrid1New" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <table border="1" id="GridView5"  cellpadding="1px" cellspacing="1px"
                                style="border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                        <td align="center" style="width:125px">
                                            Country
                                        </td>
                                        <td align="center" style="width:50px">
                                            Sale
                                        </td>
                                        <td align="center" style="width:75px">
                                            Billing
                                        </td>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="drow" runat="server" class="GridviewScrollItem">
                                <td align="left" style="width:125px">
                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("countryname") %>' />
                                </td>
                                <td align="right" style="width:50px">
                                    <asp:Label ID="lblSaleCount" runat="server" Text='<%#Eval("salecount") %>' />
                                </td>
                                <td align="right" style="width:75px">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("totalamount") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-color: Gray; color: White;">
                                <td align="left" style="width:125px">
                                    <strong>Grand Total:</strong>
                                </td>
                                <td align="right" style="width:50px">
                                    <asp:Label ID="lblSaleCountGrand" runat="server" Font-Bold="true" />
                                </td>
                                <td align="right" style="width:75px">
                                    <asp:Label ID="lblTotalAmountGrand" runat="server" Font-Bold="true" />
                                </td>
                            </tr>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                </td>
                <td style="border: none; padding-left: 50px">
                </td>
                 <td style="border: none;  " valign="top" align="left">
                    <asp:Repeater ID="GridView1" runat="server" OnItemDataBound="GridView1_ItemDataBound">
                        <HeaderTemplate>
                            <table border="1" id="GridView6"  cellpadding="1px" cellspacing="1px"
                                style="border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                        <td align="center" style="width:215px">
                                            Account Manager
                                        </td>
                                        <td align="center" style="width:115px">
                                            Branch
                                        </td>
                                        <td align="center" style="width:50px">
                                            Sale
                                        </td>
                                        <td align="center" style="width:95px">
                                            Billing
                                        </td>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="drow" runat="server" class="GridviewScrollItem">
                                <td align="left" style="width:215px">
                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("employeename") %>' />
                                </td>
                                 <td align="left" style="width:115px">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("branchname") %>' />
                                </td>
                                <td align="right" style="width:50px">
                                    <asp:Label ID="lblSaleCount" runat="server" Text='<%#Eval("salecount") %>' />
                                </td>
                                <td align="right" style="width:95px">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("totalamount") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr style="background-color: Gray; color: White;">
                                <td align="left" style="width:215px">
                                </td>
                                <td align="left" style="width:115px">
                                    <strong>Grand Total:</strong>
                                </td>
                                <td align="right" style="width:50px">
                                    <asp:Label ID="lblSaleCountGrandTotal" runat="server" Font-Bold="true" />
                                </td>
                                <td align="right" style="width:95px">
                                    <asp:Label ID="lblTotalAmountGrand" runat="server" Font-Bold="true" />
                                </td>
                            </tr>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                
                   <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                        Width="400px" OnRowDataBound="GridView1_RowDataBound" CellPadding="3" HeaderStyle-ForeColor="White"
                        CellSpacing="3" ShowFooter="true" HeaderStyle-BackColor="Gray" FooterStyle-BackColor="Gray"
                        FooterStyle-ForeColor="White">
                        <Columns>
                            <asp:TemplateField HeaderText="Account Manager" HeaderStyle-HorizontalAlign="Left"
                                FooterStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="lblaccountmanager" runat="server" Text='<% #(Eval("employeename")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="lblbranchname" runat="server" Text='<% #(Eval("branchname")) %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label runat="Server" ID="lbl3" Text="Grand Total"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Sale" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="lblSaleCount" runat="server" Text='<% #(Eval("salecount")) %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label runat="Server" ID="lblSaleCountGrandTotal"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Bill Amount" HeaderStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<% #(Eval("totalamount")) %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label runat="Server" ID="lblTotalAmountGrand"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
