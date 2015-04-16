<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmSalesReportAccountManagerWise.aspx.cs" Inherits="Sales_frmSalesReportAccountManagerWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />--%>
    <!--[if IE]><![if gte IE 6]><![endif]-->
    <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        glow.ready(function () {
            new glow.widgets.Sortable(
					'#content .grid_5, #content .grid_6',
					{
					    draggableOptions: {
					        handle: 'h2'
					    }
					}
				);
        });
    </script>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Report"
                                ForeColor="Red" ErrorMessage="Required Field !" ControlToValidate="ddlYear" InitialValue="Select"
                                SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Select Month:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSearch" runat="server" ValidationGroup="Report">
                                <asp:ListItem>ByOrderDate</asp:ListItem>
                                <asp:ListItem>ByDeliveryDate</asp:ListItem>
                                <asp:ListItem>ByActualDeliveryDate</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                ForeColor="Red" ErrorMessage="Required Field !" ControlToValidate="ddlMonth"
                                InitialValue="ByOrderDate" SetFocusOnError="true">***</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sale Category:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSaleCategory" runat="server" ValidationGroup="Report" AutoPostBack="true"
                                Width="135px" OnSelectedIndexChanged="ddlSaleCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Select Employee:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEmployee" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSerach" runat="server" Text="Search" OnClick="btnSerach_Click"
                                ValidationGroup="Report" />
                        </td>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
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
                                    AllowSorting="true" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                                    OnPageIndexChanging="grdview1_PageIndexChanging" RowStyle-Font-Names="Arial"
                                    OnRowDataBound="grdview1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="Region" DataField="zone" />
                                        <asp:BoundField HeaderText="Account Manager" DataField="employeename" />
                                        <asp:BoundField HeaderText="Branch" DataField="branchname" />
                                        <asp:BoundField HeaderText="Total" DataField="total" />
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
