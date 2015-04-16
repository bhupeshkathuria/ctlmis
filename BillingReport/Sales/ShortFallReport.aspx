<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShortFallReport.aspx.cs"
    Inherits="Sales_ShortFallReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 90px;
        }
        .style2
        {
            width: 4px;
        }
        .style3
        {
            width: 93px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        AllowPaging="True" AllowSorting="true" PageSize="10" HeaderStyle-Wrap="false"
                        CssClass="form_table" OnRowDataBound="grdview1_RowDataBound" 
                        ShowFooter="True">
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
