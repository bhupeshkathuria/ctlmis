<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SalesDashboardNew.aspx.cs" Inherits="Sales_SalesDashboardNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
    <script src="../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="mask">
    </div>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="440px" Width="800px"
        Style="z-index: 111; background-color: White; position: absolute; left: 20%;
        top: 40%; border: outset 2px gray; padding: 5px; display: none">
        <asp:Label ID="lblHeader" Font-Bold="true" runat="server"></asp:Label>
        <input type="image" src="../Images/close-x.png" class="btnClose" value="Cancel" style="position: absolute;
            top: -10px; right: 10px;" />
        <br />
        <asp:Panel ID="pnlBranch" runat="server" Style="height: 420px; padding: 0; width: 100%;
            font-size: 12px;" Visible="true" ScrollBars="Auto">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                GridLines="None" OnRowDataBound="GridView2_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Reseller" HeaderText="Reseller" />
                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                    <asp:BoundField DataField="monthname" HeaderText="Month" />
                    <asp:BoundField DataField="noofsales" HeaderText="No. Of Sales">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ActivationAmount" HeaderText="Activation Amount">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RechargeAmount" HeaderText="Recharge Amount">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle Font-Bold="True" />
            </asp:GridView>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%"
                GridLines="None" OnRowDataBound="GridView3_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Reseller" HeaderText="Reseller" />
                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                    <asp:BoundField DataField="monthname" HeaderText="Month" />
                    <asp:BoundField DataField="OnlineAmount" HeaderText="Online Amount">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ManualAmount" HeaderText="Manual Amount">
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle Font-Bold="True" />
            </asp:GridView>
        </asp:Panel>
        <br />
    </asp:Panel>
    <div>
        <title>Sales Dashboard</title>
        <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    </div>
    <div style="width: 100%; padding-top: 5px;">
        <asp:Label ID="lblMsg" Visible="false" runat="server" ForeColor="Red"></asp:Label>
        <b>
            <asp:Label ID="lblMonth" runat="server"></asp:Label></b>
        <table cellpadding="3" cellspacing="0" style="border: 1px solid #999; width: 80%;">
            <tr>
                <td>
                    Select Year:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    Select Month:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsearch" runat="server" ValidationGroup="Report" Width="135px">
                        <asp:ListItem>ByOrderDate</asp:ListItem>
                        <asp:ListItem>ByDeliveryDate</asp:ListItem>
                        <asp:ListItem>ByActualDeliveryDate</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="chksalesbranch" runat="server" AutoPostBack="False" Visible="false"
                        Text=" BranchSales" OnCheckedChanged="chksalesbranch_CheckedChanged" />
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Last Year Same Month Count:</b>
                </td>
                <td>
                    <asp:Label ID="lbllastyearcount" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td align="right">
                    <b>Current Day Sale Count:</b>
                </td>
                <td align="left">
                    <asp:Label ID="lblcurrentdaycount" runat="server"></asp:Label>
                </td>
                <td>
                    <b>Last Year Current Day Sale Count:</b>
                </td>
                <td align="left">
                    <asp:Label ID="lbllastyearday" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <div align="center" style="width: 100%; text-align: center;">
        </div>
        <div align="center" style="width: 100%; text-align: center;">
            <table width="100%">
                <tr>
                    <td style="vertical-align: top;">
                        <asp:GridView ID="gvRegionSales" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="200px" CaptionAlign="Top"
                            OnRowDataBound="gvRegionSales_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Region">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("zone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegionCount" runat="server" Text='<%#Eval("ZoneCount") %>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblRegionTotalCount" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="200px" CaptionAlign="Top"
                            OnRowDataBound="gvProduct_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("packagetypename") %>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductCount" runat="server" Text='<%#Eval("Count1") %>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblProductTotalCount" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:GridView ID="gvStatus" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="200px" CaptionAlign="Top"
                            OnRowDataBound="gvStatus_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("orderstatus") %>' ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusTotal" runat="server" Text='<%#Eval("RafStatusCount") %>'
                                            ForeColor="Black"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblStatusTotalCount" runat="server" Font-Bold="true" ForeColor="Black"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top" rowspan="2">
                        <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="200px" CaptionAlign="Top"
                            OnRowDataBound="gvBranch_RowDataBound" ShowFooter="True" AllowSorting="True"
                            OnSorting="gvBranch_Sorting">
                            <Columns>
                                <asp:TemplateField HeaderText="Branch" SortExpression="branchname">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("branchname") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sale" SortExpression="BranchCount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchCount" runat="server" Text='<%#Eval("BranchCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblBranchTotalCount" runat="server" Font-Bold="true"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery" SortExpression="BranchCount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchDeliveryCount" runat="server" Text='<%#Eval("delBranchCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblBranchDeliveryTotalCount" runat="server" Font-Bold="true"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    <td style="vertical-align: top">
                        <%--<asp:GridView ID="gvLastThreeMonth" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="200px" CaptionAlign="Top"
                            OnRowDataBound="gvLastThreeMonth_RowDataBound" ShowFooter="True" Visible="false">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Last Three Month Sales">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastThreeMonth" runat="server" Text='<%#Eval("MonthName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastThreeMonthCount" runat="server" Text='<%#Eval("MonthCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblLastThreeMonthTotalCount" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>--%>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <%--<asp:GridView ID="grdthreeyearsale" Width="250px" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Data Found !" GridLines="None" 
                            ShowHeaderWhenEmpty="True" CellPadding="4"
                            CaptionAlign="Top" ShowFooter="True" 
                            OnRowDataBound="grdthreeyearsale_RowDataBound1" 
                            onselectedindexchanged="grdthreeyearsale_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Month">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthName" runat="server" Text='<%#Eval("month") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2013">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl1" runat="server" Text='<%#Eval("2012-2013") %>'></asp:Label>
                                    </ItemTemplate>
                                     
                                    <FooterTemplate>
                                        <asp:Label ID="lblfoter1" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField >
                                <ItemTemplate>
                                        <asp:Label ID="lblds1" runat="server" Text='<%#Eval("TodaySales1") %>'  ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2014">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl2" runat="server" Text='<%#Eval("2013-2014") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblfoter2" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField >
                                <ItemTemplate>
                                        <asp:Label ID="lblds2" runat="server" Text='<%#Eval("TodaySales2") %>' ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="2015">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl3" runat="server" Text='<%#Eval("2014-2015") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblfoter3" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField >
                                <ItemTemplate>
                                        <asp:Label ID="lblds3" runat="server" Text='<%#Eval("TodaySales3") %>'  ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>--%>
                        <asp:GridView ID="grdthreeyearsale" Width="250px" runat="server" AutoGenerateColumns="true"
                            EmptyDataText="No Data Found !" GridLines="None" 
                            ShowHeaderWhenEmpty="True" CellPadding="4"
                            CaptionAlign="Top" ShowFooter="True" 
                            ondatabound="grdthreeyearsale_DataBound" 
                            onrowdatabound="grdthreeyearsale_RowDataBound">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    <td colspan="4" valign="top">
                        <asp:GridView ID="gvPrepaidSales" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CaptionAlign="Top" OnRowCommand="gvPrepaidSales_RowCommand" OnRowDataBound="gvPrepaidSales_RowDataBound"
                            ShowFooter="True" Width="500px">
                            <Columns>
                                <asp:BoundField DataField="bustypename" HeaderText="Business Type" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left" />
                                <asp:TemplateField HeaderText="No. of Sales" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbSales" runat="server" CommandArgument='<%# Bind("bustypeid") %>'
                                            CommandName="Sales" Text='<%# Bind("NoofSales") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ActivationAmount" HeaderText="Activation Amount" HeaderStyle-HorizontalAlign="Right">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Recharge Amount" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbRecharge" runat="server" CommandArgument='<%# Bind("bustypeid") %>'
                                            CommandName="Recharge" Text='<%# Bind("[RechargeAmount]") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top">
                    </td>
                    <td colspan="2" style="vertical-align: top" align="Left">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top">
                    </td>
                    <td colspan="2" style="vertical-align: top" align="right">
                        <asp:GridView ID="gvDailySales" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found !"
                            GridLines="None" ShowHeaderWhenEmpty="True" CellPadding="4" Width="350px" CaptionAlign="Top"
                            OnRowDataBound="gvDailySales_RowDataBound" ShowFooter="True" AllowSorting="True"
                            OnSorting="gvDailySales_Sorting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Daily Sales" SortExpression="orderdate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("orderdate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total</FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Online" SortExpression="Online">
                                    <ItemTemplate>
                                        <asp:Label ID="lblonline" runat="server" Text='<%#Eval("online") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalonline" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offline" SortExpression="offline">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloffline" runat="server" Text='<%#Eval("offline") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotaloffline" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total" SortExpression="offline">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateCount" runat="server" Text='<%#Eval("ZoneCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblDateTotalCount" runat="server"></asp:Label>
                                    </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
