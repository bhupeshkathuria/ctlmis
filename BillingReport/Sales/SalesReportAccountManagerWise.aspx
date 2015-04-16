<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesReportAccountManagerWise.aspx.cs"
    Inherits="Sales_SalesReportAccountManagerWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="50%" cellpadding="0" cellspacing="0" style="border: 1px solid Black">
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
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                <%--<asp:ValidationSummary ID="valSum" ShowMessageBox="true" ShowSummary="false" HeaderText="You must enter values in the following fields:"
                                    runat="server" ValidationGroup="Report" ForeColor="Red" />--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="false"
                        AllowSorting="true" HeaderStyle-Wrap="false"
                        CssClass="form_table"  ShowFooter="True">
                        <Columns>
                            <asp:BoundField HeaderText="Region" DataField="zone" />
                            <asp:BoundField HeaderText="Branch" DataField="branchname" />
                            <asp:BoundField HeaderText="Account Manager" DataField="employeename" />
                            <asp:BoundField HeaderText="Total" DataField="total" />                           
                        </Columns>
                        <HeaderStyle CssClass="header_box" HorizontalAlign="Center" />
                        <RowStyle CssClass="text_box" />
                        <EditRowStyle />
                        <PagerSettings Position="Top" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
