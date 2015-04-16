<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesReportMonthly.aspx.cs"
    Inherits="Sales_SalesReportMonthly" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../Resource/StyleSheet.css" />
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
                                From Date<span style="color: Red">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textfield3"></asp:TextBox><span>
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
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="textfield3"></asp:TextBox>
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
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                <asp:ValidationSummary ID="valSum" ShowMessageBox="true" ShowSummary="false" HeaderText="You must enter values in the following fields:"
                                    runat="server" ValidationGroup="Report" ForeColor="Red" />
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
                        CssClass="form_table">
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
