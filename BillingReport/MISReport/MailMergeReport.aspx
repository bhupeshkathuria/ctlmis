<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailMergeReport.aspx.cs"
    Inherits="User_CRM_MailMergeReport" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../../resources/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GVTrip" runat="server" Width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="customertype" HeaderText="Wholesale/Retail" />
                <asp:BoundField DataField="invoicecreatedfor" HeaderText="Usage/Lost/Damage" />
                <asp:BoundField DataField="customername" HeaderText="Name" />
                <asp:BoundField DataField="serviceusername" HeaderText="Service User" />
                <asp:BoundField DataField="address1" HeaderText="Address 1" />
                <asp:BoundField DataField="address2" HeaderText="Address 2" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:BoundField DataField="statename" HeaderText="State" />
                <asp:BoundField DataField="countryname" HeaderText="Country" />
                <asp:BoundField DataField="su_contactno1" HeaderText="Contact No 1" />
                <asp:BoundField DataField="su_contactno2" HeaderText="Contact No 2" />
                <asp:BoundField DataField="su_email" HeaderText="Email Address" />
                <asp:BoundField DataField="branchname" HeaderText="Branch" />
                <asp:BoundField DataField="invoicingmonth" HeaderText="Invoice Month" />
                <asp:BoundField DataField="orderid" HeaderText="Order ID" />
                <asp:BoundField DataField="mobileno" HeaderText="Mobile No" />
                <asp:BoundField DataField="fromdate" HeaderText="From Date" />
                <asp:BoundField DataField="todate" HeaderText="End Date" />
                <asp:BoundField DataField="invoicedate" HeaderText="Invoice Date" />
                <asp:BoundField DataField="duedate" HeaderText="Due Date" />
                <asp:BoundField DataField="invoicenumber" HeaderText="Invoice Number" />
                <asp:BoundField DataField="travellingcountryname" HeaderText="Travelling Country" />
                <asp:BoundField DataField="amountcalls" HeaderText="Amount Calls(Local Currency)" />
                <asp:BoundField DataField="amountrentalinr" HeaderText="Rental (INR)" />
                <asp:BoundField DataField="amountrentalcdr" HeaderText="Rental (Local Currency) " />
                <asp:BoundField DataField="amountRentalTotal" HeaderText="Rental Total(INR)" />
                <asp:BoundField DataField="couponcost" HeaderText="Coupon Cost (Local Currency)" />
                <asp:BoundField DataField="couponcostinr" HeaderText="Coupon Cost (INR)" />
                <asp:BoundField DataField="amountservicecharge" HeaderText="Service Charge(Local Currency)" />
                <asp:BoundField DataField="amountservicechargeinr" HeaderText="Service Charge(INR)" />
                <asp:BoundField DataField="totalservicecharge" HeaderText="Service Charge Total (INR)" />
                <asp:BoundField DataField="amountmincommitment" HeaderText="Min. commitment(INR)" />
                <asp:BoundField DataField="amountothercharge" HeaderText="Other Charge(INR)" />
                <asp:BoundField DataField="servicetaxinr" HeaderText="Service Tax(INR)" />
                <asp:BoundField DataField="amountinr" HeaderText="Amount Total(INR)" />
                <asp:BoundField DataField="fxinr" HeaderText="Conversion Rate" />
                <asp:BoundField DataField="currencycode" HeaderText="Currency" />
                <asp:BoundField DataField="accmanager" HeaderText="Account Manager" />
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
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
        </telerik:RadFormDecorator>
        <div style="width: 100%; height: 100%">
            <div style="width: 100%; padding: 0px 0px 0px 0px">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" align="left">
                            &nbsp;&nbsp;CRM / Reports / Mail Merge Report
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table cellpadding="5px" cellspacing="0">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Country:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlCountry" runat="server" Height="200px" Width="150px"
                                                        EmptyMessage="-Select-" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";"
                                                        TabIndex="1">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Year:</b>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlYear" runat="server" Height="200px" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Month:</b>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMonth" runat="server" Height="200px" Width="150px">
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
                                        <table>
                                            <tr>
                                                <td style="width: 100px;">
                                                    <b>Package:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlPackage" runat="server" Height="200px" Width="150px"
                                                        EmptyMessage="-Select-" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";"
                                                        TabIndex="2">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Final/Not Final:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlFinalNotFinal" runat="server" Height="200px" Width="150px"
                                                        EmptyMessage="-Select-" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";"
                                                        TabIndex="2">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Raf No:</b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRafNo" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Mobile No:</b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMobil" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Invoice No:</b>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Retail/WholeSale:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlCustomerType" runat="server" Height="200px" Width="150px"
                                                        EmptyMessage="-Select-" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>Rental/Usage:</b>
                                                </td>
                                                <td>
                                                    <telerik:RadComboBox ID="ddlRentalUsage" runat="server" Height="200px" Width="150px"
                                                        EmptyMessage="-Select-" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";"
                                                        TabIndex="2">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>From Date</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdpMinDate" runat="server" Width="140px" AutoPostBack="false"
                                                        DateInput-EmptyMessage="MinDate" ShowPopupOnFocus="true" DateInput-DateFormat="dd/MM/yyyy"
                                                        MinDate="01/01/1000" MaxDate="01/01/3000">
                                                        <Calendar ID="Calendar1" runat="server">
                                                            <SpecialDays>
                                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                                            </SpecialDays>
                                                        </Calendar>
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px;">
                                                    <b>To Date</b>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="rdpMaxDate" runat="server" Width="140px" AutoPostBack="false"
                                                        DateInput-EmptyMessage="MaxDate" MinDate="01/01/1000" ShowPopupOnFocus="true"
                                                        DateInput-DateFormat="dd/MM/yyyy" MaxDate="01/01/3000">
                                                        <Calendar ID="Calendar2" runat="server">
                                                            <SpecialDays>
                                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                                            </SpecialDays>
                                                        </Calendar>
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:Button ID="btnAddField" ValidationGroup="abc" runat="server" Text="Search Invoice"
                                                        OnClick="btnAddField_Click" Visible="true" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button1" Visible="false" runat="server" Font-Size="11px" OnClick="Button1_Click"
                                                        Text="Export Invoice" Width="100px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInvoice" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="Center">
                            <asp:Label ID="lblErr" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            <asp:Label ID="lblPackage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="RadGrid1" AllowPaging="True" runat="server" ShowFooter="True"
                                AutoGenerateColumns="false" AllowSorting="True" PageSize="10" GridLines="None"
                                CellPadding="0" AllowMultiRowSelection="false" OnItemDataBound="RadGrid1_ItemDataBound"
                                OnPageIndexChanged="RadGrid1_PageIndexChanged" OnSortCommand="RadGrid1_SortCommand"
                                AllowAutomaticDeletes="True" OnPageSizeChanged="RadGrid1_PageSizeChanged">
                                <MasterTableView ShowFooter="True" CommandItemDisplay="None">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="S.No." UniqueName="Sno" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="lblSno"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="invoicingid" DataField="invoicingid" HeaderText="invoicingid"
                                            AllowFiltering="false" HeaderStyle-Width="200px" Visible="false" />
                                        <telerik:GridBoundColumn UniqueName="customertype" DataField="customertype" HeaderText="WholeSale/Retail"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="invoicecreatedfor" DataField="invoicecreatedfor"
                                            HeaderText="Usage/Lost/Damage" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="customername" DataField="customername" HeaderText="Name"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="freezestatus" DataField="freezestatus" HeaderText="Status"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="usagestatus" DataField="usagestatus" HeaderText="Usage/Rental"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="serviceusername" DataField="serviceusername"
                                            HeaderText="Service User" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="address1" DataField="address1" HeaderText="Address"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="city" DataField="city" HeaderText="City" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="statename" DataField="statename" HeaderText="State"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="countryname" DataField="countryname" HeaderText="Country"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="travellingcountryname" DataField="travellingcountryname"
                                            HeaderText="Travelling Country" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="su_contactno1" DataField="su_contactno1" HeaderText="Contact No"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="su_email" DataField="su_email" HeaderText="Email Address"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="branchname" DataField="branchname" HeaderText="Branch"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="invoicingmonth" DataFormatString="{0:MMM-yyyy}"
                                            DataField="invoicingmonth" HeaderText="Invoicing Month" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="accmanager" DataField="accmanager" HeaderText="A/c Manager"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="currencycode" DataField="currencycode" HeaderText="Currency"
                                            AllowFiltering="true" />
                                        <telerik:GridTemplateColumn HeaderText="Invoice No" AllowFiltering="true" UniqueName="invoicenumber">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/User/Invoice/New_Invoice/View.aspx?print=no&invoiceID=" + DataBinder.Eval(Container.DataItem,"invoiceid") %>'
                                                    Target="_blank" Text='<% #Eval("invoicenumber") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="orderid" DataField="orderid" HeaderText="Order No."
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="mobileno" DataField="mobileno" HeaderText="Mobile_No"
                                            AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="fromdate" DataFormatString="{0:dd-MMM-yyyy}"
                                            DataField="fromdate" HeaderText="Invoice start date" AllowFiltering="false" />
                                        <telerik:GridBoundColumn UniqueName="todate" DataFormatString="{0:dd-MMM-yyyy}" DataField="todate"
                                            HeaderText="Invoice end date" AllowFiltering="false" />
                                        <telerik:GridBoundColumn UniqueName="invoicedate" DataFormatString="{0:dd-MMM-yyyy}"
                                            DataField="invoicedate" HeaderText="Invoice Date" AllowFiltering="false" />
                                        <telerik:GridTemplateColumn HeaderText="Due Date" AllowFiltering="true" UniqueName="duedate">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/User/Invoice/UpdateInvoiceDate.aspx?invoiceID=" + DataBinder.Eval(Container.DataItem,"invoiceid") %>'
                                                    onclick="window.open (this.href, 'popupwindow', 'toolbar=no,width=450,height=400, location=no,left=280,top=200, directories=no, status=no, menubar=no, scrollbars=yes, resizable=0, copyhistory=no,fullscreen=no'); return false;"
                                                    Text='<% #Eval("newduedate") %>'></asp:HyperLink>
                                                <asp:Label ID="lblDuedate" runat="server" Visible="false" Text='<% #Eval("newduedate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Amount Calls(Local Currency)"
                                            UniqueName="amountcalls">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountcalls"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rental (INR)" UniqueName="amountrentalinr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountrentalinr"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rental (Local Currency)"
                                            UniqueName="amountrentalcdr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount2ss" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountrentalcdr"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Rental Total (INR)"
                                            UniqueName="amountRentalTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamoddunt2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountRentalTotal"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Coupon Cost(Local Currency)"
                                            UniqueName="couponcost">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcpncost2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("couponcost"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Coupon Cost (INR)"
                                            UniqueName="couponcostinr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcpncost" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("couponcostinr"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Service Charge(Local Currency)"
                                            UniqueName="amountservicecharge">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount33" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountservicecharge"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Service Charge(INR)"
                                            UniqueName="amountservicechargeinr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamounddt33" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountservicechargeinr"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Service Charge Total (INR)"
                                            UniqueName="amountservicechargetotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamoddsunt33" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalservicecharge"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Min. Commitment(INR)"
                                            UniqueName="amountmincommitment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount34" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountmincommitment"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--  <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Amount (Total)" UniqueName="amounttotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount3" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amounttotal"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Other Charge(INR)"
                                            UniqueName="amountothercharge">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamou4nt3" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountothercharge"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Amount Total (INR)"
                                            UniqueName="amountinr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamount4" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("amountinr"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="fxinr" DataField="fxinr" HeaderText="Conversion Rate"
                                            AllowFiltering="false" />
                                        <telerik:GridBoundColumn UniqueName="cancelstatus2" DataField="cancelstatus2" HeaderText="Status" />
                                        <telerik:GridTemplateColumn HeaderText="Print" AllowFiltering="false" UniqueName="detail"
                                            HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hpPrint" runat="server" NavigateUrl='<%# "~/User/Invoice/New_Invoice/View.aspx?print=yes&invoiceID=" + DataBinder.Eval(Container.DataItem,"invoiceid") %>'
                                                    Target="_blank" Text="Print"></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Raf Details" AllowFiltering="false" UniqueName="detail"
                                            HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl='<%# "~/User/Invoice/New_Invoice/RafDetail.aspx?orderid=" + DataBinder.Eval(Container.DataItem,"orderid") %>'
                                                    onclick="window.open (this.href, 'popupwindow', 'toolbar=no,width=800,height=540, location=no,left=280,top=200, directories=no, status=no, menubar=no, scrollbars=yes, resizable=0, copyhistory=no,fullscreen=no'); return false;"
                                                    Text='<% #Eval("packagename") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings>
                                    <Selecting AllowRowSelect="true" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
