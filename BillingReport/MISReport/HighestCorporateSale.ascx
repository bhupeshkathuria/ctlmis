<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HighestCorporateSale.ascx.cs"
    Inherits="MISReport_HighestCorporateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div style="padding-top: 10px" class="exampleWrapper">
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1">
        <Tabs>
            <telerik:RadTab Text="General">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Height="518px"
        Width="596px" CssClass="multiPage">
        <telerik:RadPageView runat="server" Height="500px" ID="RadPageView3" CssClass="myPageView">
            <%--<telerik:RadAjaxManager ID="RadAjaxManager1" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
                runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadGrid1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="btnSearch">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>--%>
            <%--       <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="75px"
                Width="75px" Transparency="5">
                <img style="border: 0; margin-top: 150px;" alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading4.gif") %>' />
            </telerik:RadAjaxLoadingPanel>--%>
            <telerik:RadGrid ID="RadGrid1" AllowPaging="True" runat="server" ShowFooter="True"
                AutoGenerateColumns="false" AllowSorting="True" PageSize="20" PagerStyle-ShowPagerText="false"
                GridLines="None" CellPadding="0" AllowMultiRowSelection="false" OnPageIndexChanged="RadGrid1_PageIndexChanged"
                OnPageSizeChanged="RadGrid1_PageSizeChanged" OnItemDataBound="RadGrid1_ItemDataBound" OnSortCommand="RadGrid1_SortCommand">
                <MasterTableView ShowFooter="True">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="S.No." UniqueName="Sno" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <%#Container.DataSetIndex + 1 %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="countryname" DataField="countryname" HeaderText="Country"
                            AllowFiltering="true" FooterText="Grand Total" />
                        <%--<telerik:GridBoundColumn UniqueName="salecount" DataField="salecount" HeaderText="Total Sale"
                            AllowFiltering="true" />--%>
                        <telerik:GridTemplateColumn HeaderText="Total Sale" UniqueName="salecount">
                            <ItemTemplate>
                                <asp:Label ID="lblsalecount" runat="server" Text='<% #(Eval("salecount")) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label runat="Server" ID="lblgrandTotalSaleCount"></asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Total Bill Amount" UniqueName="lowsalecount">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalAmount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("totalamount"))) %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label runat="Server" ID="lblgrandTotalBillAmount"></asp:Label>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings>
                    <Selecting AllowRowSelect="false" />
                </ClientSettings>
            </telerik:RadGrid>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
