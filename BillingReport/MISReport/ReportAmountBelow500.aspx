<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ReportAmountBelow500.aspx.cs" Inherits="MISReport_InvoiceGenNoGenReportNew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Low Invoice Report
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
                    <table cellpadding="0px" cellspacing="0px" width="120px">
                        <tr>
                            <td>
                                <strong>Total Invoice :</strong>
                            </td>
                            <td>
                                <asp:Label ID="lblTotalRaf" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label>
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
                        OnPageSizeChanged="RadGrid1_PageSizeChanged" 
                        >
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
                                <telerik:GridBoundColumn UniqueName="totalcount" DataField="totalcount" HeaderText="Total Invoice"
                                    AllowFiltering="False">
                                    <HeaderStyle Width="200px" />
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
                                 <telerik:GridBoundColumn UniqueName="orderid" AllowFiltering="true" DataField="orderid"
                                        HeaderText="Raf No">
                                        <HeaderStyle Width="200px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn AllowFiltering="True" UniqueName="customername" DataField="customername"
                                        HeaderText="Customer Name">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="travellingcountryname" DataField="travellingcountryname"
                                        HeaderText="Country">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="accmanager" DataField="accmanager" HeaderText="Account Manager">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="branchname" DataField="branchname" HeaderText="Branch">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="invoicenumber" DataField="invoicenumber" HeaderText="Invoice No">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="fromdate" DataFormatString="{0:dd-MMM-yyyy}"
                                        DataField="fromdate" HeaderText="Invoice start date" AllowFiltering="False">
                                        <HeaderStyle Width="200px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="todate" DataFormatString="{0:dd-MMM-yyyy}" DataField="todate"
                                        HeaderText="Invoice end date" AllowFiltering="False">
                                        <HeaderStyle Width="200px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="invoicedate" DataFormatString="{0:dd-MMM-yyyy}"
                                        DataField="invoicedate" HeaderText="Invoice Date" AllowFiltering="False">
                                        <HeaderStyle Width="200px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Amount" UniqueName="totalamount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("amountinr"))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="alreadygen" DataField="alreadygen" HeaderText="Already Generated">
                                        <HeaderStyle Width="150px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Total Invoice Amount"
                                        UniqueName="totalinvoiceamt">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount134" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("totalinvoiceamt"))) %>'></asp:Label>
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
        </table>
    </div>
</asp:Content>
