<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="RptManagerwise.aspx.cs" Inherits="User_CRM_RafList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
            <table width="100%" cellpadding="5px" cellspacing="0">
                <tr>
                    <td class="Header_text" align="left">
                        &nbsp;&nbsp;MISReport / Report
                    </td>
                    <td class="Header_text" align="right">
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <fieldset style="width: 98%">
                            <legend>Search</legend>
                            <div style="float: left">
                                Manager&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            <div style="float: left">
                                <%--<asp:DropDownList ID="ddlManager" Width="150px" runat="server" >
                                </asp:DropDownList>--%>
                                <telerik:RadComboBox ID="ddlManager" runat="server" Height="200px" Width="180px"
                                    EmptyMessage="Select Manager" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                    MarkFirstMatch="true" AllowCustomText="true" AutoCompleteSeparator=";">
                                </telerik:RadComboBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <div style="float: left">
                                Branch&nbsp;&nbsp;</div>
                            <div style="float: left">
                                <%--<asp:DropDownList ID="ddlBranch" Width="150px" runat="server" >
                                </asp:DropDownList>--%>
                                <telerik:RadComboBox ID="ddlBranch" runat="server" Height="200px" Width="150px" EmptyMessage="Select Branch"
                                    HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                    AllowCustomText="true" AutoCompleteSeparator=";">
                                </telerik:RadComboBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <div style="float: left">
                                &nbsp;&nbsp;&nbsp;Year.&nbsp;</div>
                            <div style="float: left">
                            <asp:DropDownList ID="ddlYear" runat="server">
                                                </asp:DropDownList>
                               <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                                &nbsp;&nbsp;&nbsp;
                            </div>
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
                               <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                                &nbsp;&nbsp;&nbsp;
                            </div>
                            <div style="float: left">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </fieldset>
                    </td>
                </tr>
                 <tr>
                    <td align="center">
                        <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px">
                        <asp:Label ID="err" Text="Please select at least one criteria" runat="server" ForeColor="red"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <telerik:RadAjaxManager ID="RadAjaxManager1" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
                            runat="server">
                            <AjaxSettings>
                                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadToolTipManager1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="btnSearch">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="RadToolTipManager1" />
                                        <telerik:AjaxUpdatedControl ControlID="err" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                            </AjaxSettings>
                        </telerik:RadAjaxManager>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="16px"
                            Width="75px" Transparency="5">
                            <img style="border: 0; margin-top: 150px;" alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading4.gif") %>' />
                        </telerik:RadAjaxLoadingPanel>
                        <telerik:RadToolTipManager ID="RadToolTipManager1" OffsetY="-1" HideEvent="ManualClose"
                            Width="700" Height="440" runat="server" OnAjaxUpdate="OnAjaxUpdate" AutoTooltipify="false"
                            RelativeTo="Element" Position="MiddleRight" Animation="FlyIn" ManualClose="true" Modal="true" Overlay="true" >
                        </telerik:RadToolTipManager>
                        &nbsp;
                        <telerik:RadGrid ID="RadGrid1" AllowPaging="True" runat="server" ShowFooter="True" Width="600px"
                            AutoGenerateColumns="False" PageSize="15" AllowSorting="True" GridLines="None"
                            CellPadding="0" OnItemDataBound="RadGrid1_ItemDataBound" OnPageIndexChanged="RadGrid1_PageIndexChanged"
                            OnSortCommand="RadGrid1_SortCommand" OnPageSizeChanged="RadGrid1_PageSizeChanged">
                            <HeaderContextMenu EnableAutoScroll="True">
                            </HeaderContextMenu>
                            <MasterTableView>
                                <Columns>
                                   
                                    <telerik:GridBoundColumn DataField="employeename" HeaderText="Name" UniqueName="column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn  DataField="totorder" HeaderText="Total Orders" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                        />
                                    <telerik:GridBoundColumn UniqueName="Amount" DataField="countInvoice" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#####0.00}" HeaderText="Total Amount" EmptyDataText="00.00"/>
                                </Columns>
                                <RowIndicatorColumn Visible="True">
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <ClientSettings>
                            <Resizing AllowRowResize="True" EnableRealTimeResize="True"></Resizing>
                             <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="370px" />
                            </ClientSettings>
                        </telerik:RadGrid></td>
                </tr>
            </table>
        </div>

</asp:Content>


