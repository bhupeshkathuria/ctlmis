<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="HighestCorporateSale.aspx.cs" Inherits="MISReport_HighestCorporate" %>

<%@ Register Src="~/MISReport/HighestCorporateSale.ascx" TagName="HCC2" TagPrefix="uc12" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Highest Corporate Report
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset style="width: 98%">
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
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
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlYear" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlMonthTo" runat="server">
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
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlYear2" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlTop" runat="server">
                                <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                <asp:ListItem Text="200" Value="200"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="mainPnl" runat="server" visible="false">
                <td colspan="2">
                    <table cellspacing="0px" cellpadding="0px" width="900px">
                        <tr>
                            <td style="width: 450px; border: none; text-decoration: underline;" align="left">
                                <b>Sale Report</b>
                            </td>
                            <%--<td style="width: 450px; border: none; text-decoration: underline; text-align: left;"
                                align="left">
                                <b>Billing Report</b>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellspacing="0px" cellpadding="0px" width="900px">
                        <tr>
                            <td style="width: 450px; border: none;" valign="top">
                                <asp:Label ID="lblsell" runat="server" ForeColor="Red" Text="No Data Available" Font-Bold="true"
                                    Visible="false"></asp:Label>
                                <telerik:RadToolTipManager ID="RadToolTipManager1" Modal="true" OffsetY="-1" HideEvent="LeaveToolTip"
                                    Width="900" Height="360" runat="server" OnAjaxUpdate="OnAjaxUpdate" AutoTooltipify="true"
                                    RelativeTo="Element" Position="MiddleRight">
                                </telerik:RadToolTipManager>
                                <telerik:RadGrid ID="RadGrid1New" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                                    AllowPaging="false" AllowSorting="false" Width="600px" Visible="false" OnItemDataBound="RadGrid1New_ItemDataBound">
                                    <MasterTableView ShowFooter="True" CommandItemDisplay="None" DataKeyNames="FalconFACLedgerID">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="SrNo">
                                                <ItemTemplate>
                                                    <%#Container.DataSetIndex + 1 %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="LedgerName" HeaderText="Customer" FooterText="Grand Total"
                                                UniqueName="LedgerName" HeaderStyle-Width="300px" />
                                            <%--<telerik:GridBoundColumn DataField="salecount" HeaderText="Sale Count" HeaderStyle-Width="100px"
                                                UniqueName="salecount" />--%>
                                            <telerik:GridTemplateColumn HeaderText="Sale Count" UniqueName="details" HeaderStyle-Width="150px"
                                             ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHeader" runat="server"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:HyperLink ID="hpSellCount" runat="server" Text='<%# Eval("salecount") %>' NavigateUrl="#"></asp:HyperLink>--%>
                                                    <asp:HyperLink ID="hpSellCount" Text='<% #(Eval("salecount")) %>' runat="server" Target="_blank"
                                            NavigateUrl='<%# String.Format("highestCorporateCountryBranchWise.aspx?customerID={0}&lyear={1}&lmonth={2}&LedgerName={3}", Eval("FalconFACLedgerID"), Eval("lyear"), Eval("lmonth"),Eval("LedgerName")) %>'
                                            onclick="window.open (tshis.href, 'true', 'height=670,width=1300,scrollbars=yes,status=yes'); return false;"></asp:HyperLink>
                                           
                                          

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Sale Count" UniqueName="details" HeaderStyle-Width="150px"
                                             ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" >
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHeader2" runat="server"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                <asp:HyperLink ID="hpSellCount2" Text='<% #(Eval("salecount2")) %>' runat="server" Target="_blank"
                                            NavigateUrl='<%# String.Format("highestCorporateCountryBranchWise.aspx?customerID={0}&lyear={1}&lmonth={2}&LedgerName={3}", Eval("FalconFACLedgerID"), Eval("lyear2"), Eval("lmonth2"),Eval("LedgerName")) %>'
                                            onclick="window.open (tshis.href, 'popupwindow', 'toolbar=no,location=no,height=500,width=700, 
                                         directories=no, status=no, menubar=no, scrollbars=yes, resizable=0, copyhistory=no,fullscreen=no'); return false;"></asp:HyperLink>
                                                    <%--<asp:HyperLink ID="hpSellCount2" runat="server" Text='<%# Eval("salecount2") %>' NavigateUrl="#"></asp:HyperLink>--%>
                                                </ItemTemplate>
                                                <FooterTemplate >
                                                    <asp:Label ID="lblTotal2" runat="server"></asp:Label>
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
        </table>
    </div>
</asp:Content>
