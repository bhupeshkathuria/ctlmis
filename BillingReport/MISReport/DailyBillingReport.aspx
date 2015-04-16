﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DailyBillingReport.aspx.cs" Inherits="MISReport_DailyBillingReport" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Daily Billing Report
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3px" cellspacing="1px" width="70%">
                        <tr>
                            <td>
                                From Year
                            </td>
                            <td align="center" style="height: 15px; color: Green">
                                <asp:DropDownList ID="ddlFromYear" Width="70px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                From Month
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFromMonth" Width="70px" runat="server">
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
                            <%-- <td>
                                With Service Tax
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlServiceTaxYesNo" Width="50px" runat="server">
                                    <asp:ListItem Selected="True" Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:DropDownList>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                To Year
                            </td>
                            <td align="center" style="height: 15px; color: Green">
                                <asp:DropDownList ID="ddlToYear" Width="70px" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                To Month
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToMonth" Width="70px" runat="server">
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
                                Select Date
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="rdpDate" runat="server" Width="140px" AutoPostBack="false"
                                    DateInput-EmptyMessage="Select Date" ShowPopupOnFocus="true" DateInput-DateFormat="dd/MM/yyyy"
                                    MinDate="01/01/1000" MaxDate="01/01/3000">
                                    <Calendar ID="Calendar1" runat="server">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Retail/Wholesale
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRetailWholesale" Width="100px" runat="server">
                                    <asp:ListItem Selected="True" Text="Both" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Retail" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Wholesale" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="font-weight: normal;" colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0px" cellpadding="0px" width="1400px">
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server" ForeColor="Red" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 800px; border: none;" align="left">
                                <asp:Label ID="lblRetail" runat="server" ForeColor="Green" Font-Bold="true">
                                </asp:Label>
                            </td>
                             <td style="width: 400px; border: none;" align="left">
                                <asp:Label ID="lblWholesale" runat="server"  ForeColor="Green" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:900px; border: none;" valign="top">
                                <telerik:RadGrid ID="RadGrid1New" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                                    AllowPaging="false" AllowSorting="false" Width="800px" Visible="false" OnItemDataBound="RadGrid1New_ItemDataBound" >
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="SrNo">
                                                <ItemTemplate>
                                                    <%#Container.DataSetIndex + 1 %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="countryname" HeaderText="Country" UniqueName="CountryName"
                                                FooterText="Grand Total" />
                                            
                                            <telerik:GridTemplateColumn HeaderText="Revenue Amount" UniqueName="totalAmount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalAmount"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalAmount"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Service Tax" UniqueName="totalAmount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalServiceTaxAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalServiceTax"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalServiceTaxAmount"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>


                                             


                                            <telerik:GridTemplateColumn HeaderText="Credit Note" UniqueName="totalAmount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalCreditNoteAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalCreditAmount"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalCreditNoteAmount"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Total Amount" UniqueName="totalAmount" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalFinalAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalFinalAmount"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalFinalAmount"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Total Invoice" UniqueName="totalInvoice" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalInvoice" runat="server" Text='<% #(Eval("totalInvoice")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalInvoice"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="ARPU" UniqueName="arpu" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblARPU" runat="server" Text='<% #(Eval("arpu")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalARPU"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Revenue Amount(ATB)" UniqueName="totalAmountATB" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmountATB" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalAmountATB"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalAmountATB"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Service Tax(ATB)" UniqueName="totalAmountATB" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalServiceTaxAmountATB" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalServiceTaxATB"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalServiceTaxAmountATB"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>


                                            <telerik:GridTemplateColumn HeaderText="Invoice(ATB)" UniqueName="CountATB" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountATB" runat="server" Text='<% #(Eval("countATB")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalCountATB"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                            <td style="width: 500px; border: none;" valign="top">
                                <telerik:RadGrid ID="RadGridWholesale" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                                    AllowPaging="false" AllowSorting="false" Width="400px" Visible="false" OnItemDataBound="RadGridWholesale_ItemDataBound">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="SrNo">
                                                <ItemTemplate>
                                                    <%#Container.DataSetIndex + 1 %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="countryname" HeaderText="Country" UniqueName="CountryName"
                                                FooterText="Grand Total" />
                                            <telerik:GridTemplateColumn HeaderText="Total Invoice" UniqueName="totalInvoice">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalInvoice" runat="server" Text='<% #(Eval("totalInvoice")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalInvoice"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Total Amount" UniqueName="totalAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("totalAmount"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalAmount"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="ARPU" UniqueName="arpu">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblARPU" runat="server" Text='<% #(Eval("arpu")) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label runat="Server" ID="lblGrandTotalARPU"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div align="left" style="width: 1350px">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <asp:Label ID="lblreport" runat="server"></asp:Label>
                </td>

                <td align="left">
                    <asp:Label ID="lblReportWholesale" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
