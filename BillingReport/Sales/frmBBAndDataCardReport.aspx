<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmBBAndDataCardReport.aspx.cs" Inherits="Sales_frmBBAndDataCardReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    <!--[if IE]><![if gte IE 6]><![endif]-->
    <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
    <table width="99%" cellpadding="0" cellspacing="1px">
        <tr>
            <td align="center">
                <table cellpadding="10" cellspacing="0" style="border: 1px solid Black">
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
                        <td align="center">
                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="false"
                        AllowPaging="True" AllowSorting="true" PageSize="10" HeaderStyle-Wrap="false"
                        >
                        <Columns>
                            <asp:BoundField DataField="orderid" HeaderText="Order ID" />
                            <asp:BoundField DataField="orderdate" HeaderText="Raf Date" />
                            <asp:BoundField DataField="orderstatus" HeaderText="Status" />
                            <asp:BoundField DataField="customername" HeaderText="Customer" />
                            <asp:BoundField DataField="contactpersonname" HeaderText="Co-Ordinator" />
                            <asp:BoundField DataField="serviceusername" HeaderText="User Name" />
                            <asp:BoundField DataField="travellingcountryname" HeaderText="Country" />
                            <asp:BoundField DataField="mobileno" HeaderText="Mobile No." />
                            <asp:BoundField DataField="imeino" HeaderText="Handset Imeino" />
                            <asp:BoundField DataField="handsetmodel" HeaderText="Handset Model" />
                            <asp:BoundField DataField="model" HeaderText="Datacard Model" />
                            <asp:BoundField DataField="datacardimeino" HeaderText="Datacard Imeino" />
                            <asp:BoundField DataField="accmanager" HeaderText="Account Manager" />
                            <asp:BoundField DataField="branchname" HeaderText="Branch" />
                            <asp:BoundField DataField="departmentname" HeaderText="Department" />
                            <asp:BoundField DataField="zone" HeaderText="Region" />
                        </Columns>
                        <HeaderStyle  HorizontalAlign="Center" />
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
