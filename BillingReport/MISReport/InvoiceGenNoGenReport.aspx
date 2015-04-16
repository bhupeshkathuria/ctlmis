<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="InvoiceGenNoGenReport.aspx.cs" Inherits="MISReport_InvoiceGenNoGenReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 <link type="text/css" rel="stylesheet" href="../Resource/StyleSheet.css" />
    <style type="text/css">
        .bigModuleBottom td{padding:0}
        div.RadToolBar_Vista { float: none !important; } /* make the toolbar span automatically */
        div.RadToolBar_Vista .rtbOuter { border: 0; } /* remove unnecessary border */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="GVTrip" runat="server" Width="100%" AutoGenerateColumns="False"
        ShowFooter="True" PagerSettings-Position="Top" AllowPaging="True" PageSize="15"
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <Columns>
            <asp:BoundField DataField="orderid" HeaderText="Order ID" />
            <asp:BoundField DataField="orderstatus" HeaderText="Status" />
            <asp:BoundField DataField="rafdate" HeaderText="Raf Date" />
            <asp:BoundField DataField="customername" HeaderText="customername" />
            <asp:BoundField DataField="contactpersonname" HeaderText="contactpersonname" />
            <asp:BoundField DataField="serviceusername" HeaderText="serviceusername" />
            <asp:BoundField DataField="cpcontactno" HeaderText="cpcontactno" />
            <asp:BoundField DataField="address" HeaderText="address" />
            <asp:BoundField DataField="travellingcountryname" HeaderText="travellingcountryname" />
            <asp:BoundField DataField="simcardno" HeaderText="simcardno" />
            <asp:BoundField DataField="mobileno" HeaderText="mobileno" />
            <asp:BoundField DataField="handsetimeino" HeaderText="handsetimeino" />
            <asp:BoundField DataField="handsetmodel" HeaderText="handsetmodel" />
            <asp:BoundField DataField="datacardmodel" HeaderText="datacardmodel" />
            <asp:BoundField DataField="datacardimeino" HeaderText="datacardimeino" />
            <asp:BoundField DataField="deliverydate" HeaderText="deliverydate" />
            <asp:BoundField DataField="expectedretundate" HeaderText="expectedretundate" />
            <asp:BoundField DataField="accmanager" HeaderText="accmanager" />
            <asp:BoundField DataField="branchname" HeaderText="branchname" />
            <asp:BoundField DataField="departmentname" HeaderText="departmentname" />
            <asp:BoundField DataField="totalinvoice" HeaderText="totalinvoice" />
            <asp:BoundField DataField="totalamount" HeaderText="totalamount" />
        </Columns>
        <RowStyle CssClass="griditem" HorizontalAlign="center" />
        <FooterStyle CssClass="gridhd" />
        <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle CssClass="gridhd" HorizontalAlign="Left" />
        <EditRowStyle />
        <AlternatingRowStyle CssClass="griditemalt" />
        <PagerSettings Position="Top" />
    </asp:GridView>
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
                    &nbsp;&nbsp;CRM/Reports/Invoice Report
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                Country Name
                            </td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddlCountry" runat="server">
                                </asp:DropDownList>
                            </td>
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
                                <asp:Button ID="Button1" runat="server" Font-Size="11px" OnClick="Button1_Click"
                                    Text="Export Invoice" Width="100px" />
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
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="10" GridLines="None"
                        CellPadding="0" AllowMultiRowSelection="false" OnItemDataBound="RadGrid1_ItemDataBound"
                        OnPageIndexChanged="RadGrid1_PageIndexChanged" OnSortCommand="RadGrid1_SortCommand"
                        AllowAutomaticDeletes="True" OnPageSizeChanged="RadGrid1_PageSizeChanged" OnItemCommand="RadGrid1_ItemCommand">
                        <HeaderContextMenu EnableAutoScroll="True">
                        </HeaderContextMenu>
                        <MasterTableView AllowFilteringByColumn="True" DataKeyNames="orderid">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="S.No." UniqueName="Sno">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Visible="true" ID="lblSno"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="orderid" DataField="orderid" HeaderText="Raf No"
                                    AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <%--  <telerik:GridBoundColumn UniqueName="orderstatus" DataField="orderstatus" HeaderText="Order Status"
                                        AllowFiltering="False">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn UniqueName="rafdate" DataFormatString="{0:dd-MMM-yyyy}"
                                    DataField="rafdate" HeaderText="Raf Date" AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="True" UniqueName="customername" DataField="customername"
                                    HeaderText="Customer Name">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <%-- <telerik:GridBoundColumn UniqueName="contactpersonname" DataField="contactpersonname"
                                        HeaderText="Contact Person">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="serviceusername" DataField="serviceusername"
                                        HeaderText="Service User">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="cpcontactno" DataField="cpcontactno" HeaderText="Contact No">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="address" DataField="address" HeaderText="Address">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn UniqueName="travellingcountryname" DataField="travellingcountryname"
                                    HeaderText="Country">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <%-- <telerik:GridBoundColumn UniqueName="simcardno" DataField="simcardno" HeaderText="Sim Card No">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="mobileno" DataField="mobileno" HeaderText="Mobile No">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="handsetimeino" DataField="handsetimeino" HeaderText="handsetimeino">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="handsetmodel" DataField="handsetmodel" HeaderText="handsetmodel">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="datacardmodel" DataField="datacardmodel" HeaderText="datacardmodel">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="datacardimeino" DataField="datacardimeino" HeaderText="datacardimeino">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn UniqueName="accmanager" DataField="accmanager" HeaderText="accmanager">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="branchname" DataField="branchname" HeaderText="branchname">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="departmentname" DataField="departmentname" HeaderText="departmentname">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="deliverydate" DataFormatString="{0:dd-MMM-yyyy}"
                                    DataField="deliverydate" HeaderText="Departure Date" AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="expectedretundate" DataFormatString="{0:dd-MMM-yyyy}"
                                    DataField="expectedretundate" HeaderText="Expected Return Date" AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="totalinvoice" DataField="totalinvoice" HeaderText="Total Invoice">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Amount" UniqueName="totalamount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("totalamount"))) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px" />
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
