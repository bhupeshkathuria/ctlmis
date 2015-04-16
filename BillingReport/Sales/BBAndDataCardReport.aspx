<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BBAndDataCardReport.aspx.cs"
    Inherits="Sales_BBAndDataCardReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 253px;
        }
        .style3
        {
            width: 275px;
        }
    </style>
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
                                <asp:DropDownList ID="ddlYear" Width="150px" runat="server">
                                    <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                                    <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                                    <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                Select Month:<span style="color: Red">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" Width="150px" runat="server">
                                    <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February " Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="false"
                        AllowPaging="True" AllowSorting="true" PageSize="10" HeaderStyle-Wrap="false"
                        CssClass="form_table">
                        <Columns>
                            <asp:TemplateField HeaderText="Month">
                                <HeaderTemplate>
                                    <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMonth2" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BB/data Cards & USA Pre.">
                                <HeaderTemplate>
                                    <asp:Label ID="lbl" runat="server" Text="BB/data Cards & USA Pre"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCount" runat="server"></asp:Label>
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
