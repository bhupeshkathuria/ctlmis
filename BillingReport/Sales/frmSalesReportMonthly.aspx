<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmSalesReportMonthly.aspx.cs" Inherits="Sales_frmSalesReportMonthly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<link rel="stylesheet" href="../Css/960.css" type="text/css" media="screen" charset="utf-8" />--%>
    <%--<link rel="stylesheet" href="../Css/template.css" type="text/css" media="screen"
        charset="utf-8" />--%>
    <%--<link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />--%>
    <!--[if IE]><![if gte IE 6]><![endif]-->
    <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
    <%--<script type="text/javascript">
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
    </script>--%>
    <%--<div class="box">--%>
    <table width="99%" cellpadding="0" cellspacing="1px">
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" style="border: 1px solid Black">
                    <tr>
                        <td>
                            From Date<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox><span>
                                <img alt="Calender" src="../Images/calender_icon.jpg" id="imgStartDate" /></span>
                            <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txtFromDate"
                                Format="dd-MMM-yyyy" PopupButtonID="imgStartDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                ForeColor="White" ErrorMessage="Enter From Date" ControlToValidate="txtFromDate"
                                SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmptxtStartDate" runat="server" SetFocusOnError="true"
                                ErrorMessage="Date Should Be in Proper Format" ValidationGroup="Report" ForeColor="White"
                                ControlToValidate="txtFromDate" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                        </td>
                        <td>
                            To Date<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                            <span>
                                <img alt="Calender" src="../Images/calender_icon.jpg" id="imgEndDate" /></span>
                            <asp:CalendarExtender ID="clnEndDate" runat="server" TargetControlID="txtToDate"
                                Format="dd-MMM-yyyy" PopupButtonID="imgEndDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="reqtxtEndDate" runat="server" ValidationGroup="Report"
                                ForeColor="White" ErrorMessage="Enter To Date" ControlToValidate="txtToDate"
                                SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Should Be in Proper Format"
                                ValidationGroup="Report" ForeColor="White" ControlToValidate="txtToDate" Operator="DataTypeCheck"
                                Type="Date">*</asp:CompareValidator>
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
            <td>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="pnl1" runat="server" Width="100%" >
                                <asp:GridView ID="grdview1" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                    HeaderStyle-Wrap="true" OnPageIndexChanging="grdview1_PageIndexChanging" AllowPaging="true" HeaderStyle-ForeColor="ActiveCaption" RowStyle-Font-Names="Arial" >
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
                                    <RowStyle CssClass="text_box"/>
                                    <PagerSettings Position="Top" Mode="Numeric" />
                                    <PagerStyle Width="200px" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%-- </div>--%>
</asp:Content>
