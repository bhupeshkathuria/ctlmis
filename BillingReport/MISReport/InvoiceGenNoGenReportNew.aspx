<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="InvoiceGenNoGenReportNew.aspx.cs" Inherits="MISReport_InvoiceGenNoGenReportNew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Invoice Not Generate Details
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="3px" cellspacing="3px" width="50%">
                        <tr>
                            <td>
                                <strong>Month :</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" runat="server">
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
                                <strong>Year :</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <strong>Criteria :</strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCriteria" runat="server">
                                    <asp:ListItem Text="Branch Wise" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Country Wise" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Account Manager Wise" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Company Wise" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="All Data" Value="5"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0px" cellspacing="0px" width="100px">
                        <tr>
                            <td>
                                <strong>Total Raf :</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblTotalRaf" Text="0" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="RadGrid1" Visible="false" AllowPaging="True" runat="server" ShowFooter="True"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="10" GridLines="None"
                        CellPadding="0" AllowMultiRowSelection="false" OnPageIndexChanged="RadGrid1_PageIndexChanged"
                        OnSortCommand="RadGrid1_SortCommand" AllowAutomaticDeletes="True" OnItemDataBound="RadGrid1_ItemDataBound"
                        OnPageSizeChanged="RadGrid1_PageSizeChanged">
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
                                <telerik:GridBoundColumn UniqueName="name" DataField="name" HeaderText="Name" AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="totalcount" DataField="totalcount" HeaderText="Total Raf"
                                    AllowFiltering="False"><HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>

                                                                <telerik:GridBoundColumn UniqueName="Rentals" DataField="Rentals" HeaderText="Rental Raf"
                                    AllowFiltering="False"><HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>

                                                                <telerik:GridBoundColumn UniqueName="RentalFree" DataField="RentalFree" HeaderText="Rental Free Raf"
                                    AllowFiltering="False"><HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="RadGrid2" Visible="false" AllowPaging="True" runat="server" ShowFooter="True"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="10" GridLines="None"
                        OnItemDataBound="RadGrid2_ItemDataBound" CellPadding="0" AllowMultiRowSelection="false"
                        OnPageIndexChanged="RadGrid2_PageIndexChanged" OnSortCommand="RadGrid2_SortCommand"
                        AllowAutomaticDeletes="True" OnPageSizeChanged="RadGrid2_PageSizeChanged">
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
                                <telerik:GridBoundColumn UniqueName="employeename" DataField="employeename" HeaderText="Account Manager"
                                    AllowFiltering="true">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="customername" DataField="customername" HeaderText="Customer Name"
                                    AllowFiltering="true">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="orderid" DataField="orderid" HeaderText="Raf No"
                                    AllowFiltering="true">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="rafdate" DataField="rafdate" HeaderText="Order Date">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="mobileno" DataField="mobileno" HeaderText="Mobile No"
                                    AllowFiltering="true">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="travellingcountryname" DataField="travellingcountryname"
                                    HeaderText="Country">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="branchname" DataField="branchname" HeaderText="branchname">
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
                                <telerik:GridBoundColumn UniqueName="returndate" DataFormatString="{0:dd-MMM-yyyy}"
                                    DataField="returndate" HeaderText="Actual Return Date" AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="packagename" DataField="packagename" HeaderText="Package">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="couponname" DataField="couponname" HeaderText="Coupon">
                                    <HeaderStyle Width="150px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
