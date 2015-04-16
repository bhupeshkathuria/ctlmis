<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrafficControl.aspx.cs" Inherits="MISReport_TrafficControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link type="text/css" rel="stylesheet" href="../Resource/StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:GridView ID="GVTrip" runat="server" Visible="true" Width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="calltypename" HeaderText="CallType" />
                <asp:BoundField DataField="callcount" HeaderText="Total Calls" />
                <asp:BoundField DataField="noofunit" HeaderText="Unit" />
                <asp:BoundField DataField="filecost" HeaderText="File Cost" />
                <asp:BoundField DataField="clientcost" HeaderText="Client Cost" />
                <asp:BoundField DataField="discount" HeaderText="Discount" />
                <asp:BoundField DataField="clientcosttotal" HeaderText="Actual Cost" />
                <asp:BoundField DataField="zombiecost" HeaderText="Zombie Cost" />
                <asp:BoundField DataField="margin" HeaderText="Margin" />
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
        <div>
        </div>
        <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>--%>
        <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
        </telerik:RadFormDecorator>
        <div style="width: 100%; height: 100%">
            <div style="width: 100%; padding: 0px 0px 0px 0px">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" align="left">
                            &nbsp;&nbsp;CRM / Reports / Traffic Control
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="txt">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <fieldset style="width: 98%">
                                <legend>General Details</legend>
                                <table width="100%" cellpadding="10px" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Country <span class="red">*</span>
                                                    </td>
                                                    <td>
                                                        <telerik:RadComboBox ID="ddlCountry" runat="server" Height="200px" Width="150px"
                                                            EmptyMessage="Select Country" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                            MarkFirstMatch="true" AutoPostBack="true" AllowCustomText="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                                            AutoCompleteSeparator=";">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        Provider <span class="red">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanelProvider" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlProvider" AutoPostBack="True" ValidationGroup="CDR" runat="server"
                                                                    Width="150px" TabIndex="2" OnSelectedIndexChanged="ddlProvider_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Reseller <span class="red">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlReseller" ValidationGroup="CDR" runat="server" Width="150px"
                                                                    TabIndex="3">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlProvider" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        From Date
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
                                                    <td>
                                                        To Date
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
                                        <td colspan="5">
                                            <asp:Button ID="btnTrafficGenerate" runat="server" Text="Traffic Generate" Visible="true"
                                                OnClick="btnTrafficGenerate_Click" />
                                            <asp:Button ID="btnShowTraffic" runat="server" Text="Show Traffic" Visible="true"
                                                OnClick="btnShowTraffic_Click" />
                                            <asp:Button ID="btnExport" runat="server" Text="Export" Visible="true" OnClick="btnExport_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 12px" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblHeader" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 12px" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="RadGrid1" AllowPaging="False" runat="server" ShowFooter="False"
                                AutoGenerateColumns="false" AllowSorting="True" GridLines="None" CellPadding="0"
                                AllowMultiRowSelection="false" OnItemDataBound="RadGrid1_ItemDataBound" OnSortCommand="RadGrid1_SortCommand"
                                AllowAutomaticDeletes="True">
                                <MasterTableView ShowFooter="True" CommandItemDisplay="None">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="S.No." UniqueName="Sno" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="lblSno"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Call Type" UniqueName="calltype" HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="lblCallType"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--<telerik:GridBoundColumn UniqueName="calltypename" DataField="calltypename" HeaderText="Call Type"
                                            AllowFiltering="true" />--%>
                                        <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Right" UniqueName="callcount" DataField="callcount" HeaderStyle-Width="100px"
                                            HeaderText="Call Count" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="noofunit" DataField="noofunit"  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px"
                                            HeaderText="Unit" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="filecost" DataField="filecost" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="File Cost" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="clientcost" DataField="clientcost" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="Client Cost" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="discount" DataField="discount" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="Discount" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="clientcosttotal" HeaderStyle-Width="100px" DataField="clientcosttotal" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="Client Cost Final" AllowFiltering="true" />
                                        <telerik:GridBoundColumn UniqueName="zombiecost" HeaderStyle-Width="100px" DataField="zombiecost" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="Zombie Cost" AllowFiltering="true" />
                                        <telerik:GridTemplateColumn HeaderText="Margin(Percentage)" UniqueName="margin" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="lblMargin"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--  <telerik:GridTemplateColumn HeaderText="Date" UniqueName="date" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="lblDate"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        <%--<telerik:GridBoundColumn UniqueName="generateday" DataField="generateday" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date" AllowFiltering="true" />--%>
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
</asp:Content>

