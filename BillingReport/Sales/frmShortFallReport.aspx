<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmShortFallReport.aspx.cs" Inherits="Sales_frmShortFallReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<%--    <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />--%>
    <!--[if IE]><![if gte IE 6]><![endif]-->
    <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
     <table width="99%" cellpadding="0" cellspacing="1px">
        <tr>
            <td align="center">
                <table  cellpadding="10" cellspacing="0" style="border: 1px solid Black">
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
                            <asp:Button ID="btnSerach" runat="server" Text="Search" OnClick="btnSerach_Click" />
                            <%--<asp:ValidationSummary ID="valSum" ShowMessageBox="true" ShowSummary="false" HeaderText="You must enter values in the following fields:"
                                    runat="server" ValidationGroup="Report" ForeColor="Red" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="70%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="false"
                                    AllowSorting="true" HeaderStyle-Wrap="false"  OnRowDataBound="grdview1_RowDataBound"
                                    ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption" RowStyle-Font-Names="Arial" FooterStyle-ForeColor="ActiveCaption" FooterStyle-Font-Bold="true" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Account Manager" DataField="employeename" />
                                        <asp:BoundField HeaderText="Target" DataField="target" />
                                        <asp:BoundField HeaderText="Achievement till date" DataField="EmployeeCount" />
                                        <asp:TemplateField HeaderText="% of Achievement">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAverage" runat="server"></asp:Label>
                                                <asp:Label ID="lblCount" runat="server" Visible="false" Text='<%#Eval("EmployeeCount") %>'></asp:Label>
                                                <asp:Label ID="lblTarget" runat="server" Visible="false" Text='<%#Eval("target") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Achieved per day (Average)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCurrentAchievement" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. To be Achieved per day (Average)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAchieved" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:Image ID="imgup" runat="server" ImageUrl="~/Images/up.png" Visible="false" />
                                        <asp:Image ID="imgdown" runat="server" ImageUrl="~/Images/down.png" Visible="false" />
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
