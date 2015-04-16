<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DailyReport.aspx.cs" Inherits="CreditControl_DailyReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="updt1">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
   <asp:UpdatePanel id="updt1"  runat="server" >
   <Triggers>
   <asp:PostBackTrigger ControlID="imgexport" />
   </Triggers>
        <ContentTemplate>
<div>
            <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
          <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
        </telerik:RadFormDecorator>--%>

            <div style="width: 100%; padding: 0px 0px 0px 0px;font:11px verdana;"">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" colspan="3" align="left" style="width: 244px">
                            &nbsp;&nbsp;Invoice / Credit Report /
                        </td>
                    </tr>
                    <tr>
                    <td style="width: 987px">
                     <fieldset style="width:500px;">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="80px">
                                  <b>  From Date: </b>
                                </td>
                                <td Width="110px">
                                    <asp:TextBox ID="txtfromdate" runat="server" Width="100px">
                                    </asp:TextBox>
                                </td>
                                <td><asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                        Format="yyyy-MM-dd" TargetControlID="txtfromdate">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/CreditControl/cal.gif" AlternateText="Click to show calendar"
                                        Width="18" Height="18" ImageAlign="TextTop" />
                                </td>
                                <td width="70px">
                                   <b> To Date: </b>
                                </td>
                                <td Width="110px">
                                    <asp:TextBox ID="txttodate" runat="server" Width="100px">
                                    </asp:TextBox>
                                </td>
                                <td><asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton3"
                                        Format="yyyy-MM-dd" TargetControlID="txttodate">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/CreditControl/cal.gif" AlternateText="Click to show calendar"
                                        Width="18" Height="18" ImageAlign="TextTop" />
                                </td>
                                <td><asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnAddField_Click" />
                                </td>
                                <td><asp:ImageButton ID="imgexport" Visible="false" runat="server" ImageUrl="~/CreditControl/xls-icon.gif" OnClick="imgexport_Click" />
                                </td>
                            </tr>
                        </table>
                        </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CompareValidator ID="cvtxtStartDate" runat="server" ControlToCompare="txtfromdate"
                                CultureInvariantValues="true" Display="Dynamic" EnableClientScript="true" ControlToValidate="txttodate"
                                ErrorMessage="Start date must be earlier than End date" Type="Date" SetFocusOnError="true"
                                Operator="GreaterThanEqual" Text="Start date must be earlier than End date"></asp:CompareValidator>
                                <asp:Label ID="lblInvoice" runat="server" ForeColor="red"></asp:Label>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <%--<tr>
                                    <td style="width: 244px">
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
                                    <td style="width: 239px">
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
                                    <td>
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:Button ID="btnAddField" ValidationGroup="abc" runat="server" Text="Search Invoice"
                                                        OnClick="btnAddField_Click" Visible="true" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button1" Visible="false" runat="server" Font-Size="11px" 
                                                        Text="Export Invoice" Width="100px" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                   </tr>--%>

                   <tr id="trAdjucement" runat="server" visible="false">
                        <td class="Header_text" colspan="3" align="left">
                            <fieldset>
                                <legend>Adjustment Summary :</legend>
                                <table cellpadding="0px" cellspacing="1px" border="0px" width="800px">
                                    <tr>
                                        <td>
                                            <b>Total Collection</b>
                                        </td>
                                        <td>
                                            <b>Adjusted Amount</b>
                                        </td>
                                        <td>
                                            <b>Un-adjusted Amount</b>
                                        </td>
                                         <td>
                                            <b>Current Month Billing</b>
                                        </td>
                                        <td>
                                            <b>Previous Month Billing</b>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbltotalcollection" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbltotalarjusted" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblunarjsustedamt" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblcurrentmonthBilling" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblPreviousmonthBilling" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 397px" colspan="3">
                            <asp:GridView ID="GridView1" Width="700px" ShowFooter="True" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Branch" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltext" runat="server" Text="Grand Total" Font-Bold="true"/>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="By Cheque" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCheque" runat="server" Text='<%#Eval("ByCheque") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCheque" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="By Cash" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCash" runat="server" Text='<%#Eval("ByCash") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCash" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="By Credit Card" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCreditCard" runat="server" Text='<%#Eval("ByCreditCard") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalcredit" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="By Bank" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByBank" runat="server" Text='<%#Eval("ByBank") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalbank" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="By Online" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByOnline" runat="server" Text='<%#Eval("ByOnline") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalonline" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Other" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblother" runat="server" Text='<%#Eval("Other") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalother" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

