<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LiveStatus.aspx.cs" Inherits="MISReport_LiveStatus" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" rel="stylesheet" href="../Resource/StyleSheet.css" />
    <style type="text/css">
        .bigModuleBottom td
        {
            padding: 0;
        }
        div.RadToolBar_Vista
        {
            float: none !important;
        }
        /* make the toolbar span automatically */
        div.RadToolBar_Vista .rtbOuter
        {
            border: 0;
        }
        /* remove unnecessary border */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>--%>
    <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
    </telerik:RadFormDecorator>
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;CRM/Reports/Live Status
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Year
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
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Month
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
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Font-Size="11px" OnClick="Button2_Click"
                                    Text="Search Data" Width="100px" />
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadAjaxManager ID="RadAjaxManager1" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
                        runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="75px"
                        Width="75px" Transparency="5">
                        <img style="border: 0; margin-top: 150px;" alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading4.gif") %>' />
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadGrid ID="RadGrid1" AllowPaging="True" runat="server" ShowFooter="True"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="100" GridLines="None"
                        CellPadding="0" AllowMultiRowSelection="false" OnItemDataBound="RadGrid1_ItemDataBound"
                        OnPageIndexChanged="RadGrid1_PageIndexChanged" OnSortCommand="RadGrid1_SortCommand"
                        AllowAutomaticDeletes="True" OnPageSizeChanged="RadGrid1_PageSizeChanged" OnItemCommand="RadGrid1_ItemCommand">
                        <HeaderContextMenu EnableAutoScroll="True">
                        </HeaderContextMenu>
                        <MasterTableView AllowFilteringByColumn="True">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="S.No." UniqueName="Sno">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblSno"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="countryname" DataField="countryname" HeaderText="Country"
                                    AllowFiltering="False">
                                    <HeaderStyle Width="80px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="provider_name" DataField="provider_name" HeaderText="Provider"
                                    AllowFiltering="False">
                                    <HeaderStyle Width="80px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Import" UniqueName="Import">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblImport"></asp:Label>
                                        <asp:Image ID="imgImport" Height="20px" Width="20px" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Charge" UniqueName="Charge">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblCharge"></asp:Label>
                                        <asp:Image ID="imgCharge" Height="20px" Width="20px" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Discount" UniqueName="Discount">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblDiscount"></asp:Label>
                                        <asp:Image ID="imgDiscount" Height="20px" Width="20px" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Unbilled" UniqueName="Unbilled">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblUnbilled"></asp:Label>
                                        <asp:Image ID="imgUnbilled" Height="20px" Width="20px" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Invoice" UniqueName="Invoice">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblInvoice"></asp:Label>
                                        <asp:Image ID="imgInvoice" Height="20px" Width="20px" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="err" runat="server" ForeColor="red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
