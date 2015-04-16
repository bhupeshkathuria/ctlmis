<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rptSaleCategoryYearWise.aspx.cs" Inherits="MISReport_rptSaleBillingHeadBySaleCategory" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/confirm.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
    <script src="../_assets/js/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="../_assets/js/jquery.simplemodal-1.1.1.js" type="text/javascript"></script>
    <script src="../_assets/js/jquery.contextMenu.js" type="text/javascript"></script>
    <style type="text/css">
        a
        {
            color: #000 !important;
            text-decoration: none;
        }
        a:hover
        {
            color: #333;
            text-decoration: none;
        }
        
        .customerRow
        {
        }
        .gvhide
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var CustomerID = null;
        var CustomerID2 = null;
        var czone = null;

        $(document).ready(function () {
            $(".openmenu2").contextMenu({ menu: 'myMenu2', leftButton: true }, function (action, el, pos) { contextMenuWork2(action, el.parent("tr"), pos); });
        });


        function contextMenuWork2(action, el, pos) {
            var rowindex = (el[0].rowIndex * 1 - 1);

            CustomerID2 = $("#MainContent_RadGrid1Zone_lblYear_" + rowindex).html();
            czone = $("#MainContent_RadGrid1Zone_lblzone_" + rowindex).html();

            if (CustomerID2 == null) {

                CustomerID2 = $("#MainContent_RadGrid1Zone_lblFromToYear").html();
            }

            if (czone == null) {

                czone = "";
            }

            switch (action) {
                case "monthwise":
                    {
                        var msg = "rptSaleCategoryMonthWise.aspx?yearfromto=" + CustomerID2 + "&zonename=" + czone;
                        window.open(msg,'MessageWindow1', 'height=670,width=1300,scrollbars=yes,status=yes');

                        break;
                    }
                case "branchwise":
                    {
                        var msg = "rptSaleCategoryBranchAccountMWise.aspx?yearfromto=" + CustomerID2 + "&zonename=" + czone;

                        window.open(msg, true, 'height=670,width=1300,scrollbars=yes,status=yes');
                        break;
                    }

            }
        }

        function pageLoad() {
            $(".openmenu2").contextMenu({ menu: 'myMenu2', leftButton: true }, function (action, el, pos) { contextMenuWork2(action, el.parent("tr"), pos); });
        }

        
    
        

      

        
    </script>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="updatePnl"
        style="width: 100%;">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 45%; left: 45%; text-align: center;">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatePnl" runat="server">
        <ContentTemplate>
            <div style="width: 100%; padding: 0px 0px 0px 0px">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" align="left">
                            &nbsp;&nbsp;Sale Billing Report by Sale Category Year Wise
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 50px">
                            <table cellpadding="3px" cellspacing="1px" width="350px">
                                <tr>
                                    <td>
                                        <strong>From Year</strong>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlFromYear" Width="70px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>To Year</strong>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlToYear" Width="70px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="font-weight: normal;" colspan="4">
                                        <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <table cellspacing="0px" cellpadding="0px" style="margin-bottom: 55px;">
                <tr>
                    <td>
                        <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true">
                        </asp:Label>
                    </td>
                </tr>
              <%--  <tr>
                    <td style="height: 20px" align="center">
                        <asp:Label ID="lblReportHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px" align="center">
                        <asp:Label ID="lblzoneHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 800px; border: none; padding-left: 50px">
                        <asp:GridView ID="RadGrid1Zone" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                            Width="800px" OnRowDataBound="RadGrid1Zone_RowDataBound" CellPadding="3" CellSpacing="3"
                            ShowFooter="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Gray">
                            <Columns>
                                <asp:TemplateField HeaderText="Year" HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYear" runat="server" Text='<% #(Eval("cyear")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblFromToYear"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sale Category" HeaderStyle-HorizontalAlign="Left"
                                    FooterStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                                    FooterText="Grand Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblzone" runat="server" Text='<% #(Eval("salecategoryname")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sale Total" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaleCount" runat="server" Text='<% #(Eval("lsaletotal")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblSaleCountGrandTotal"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revenue Total" FooterStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevenueTotal" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("lrevenuetotal"))) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblRevenueGrandTotal"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Head Count" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHeadCount" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToDouble(Eval("headcountTotal"))) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblHeadCountTotal"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sale(Prod.Per Head)" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSaleProdPerHead" runat="server"></asp:Label>
                                    </ItemTemplate>
                                       <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblSaleProdPerHeadTotal"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Billing(Prod.Per Head)" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBillingProdPerHead" runat="server"></asp:Label>
                                    </ItemTemplate>
                                       <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblBillingProdPerHeadTotal"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <%--   <asp:TemplateField HeaderText="Percentage" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="As Per Billing Amount" FooterStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsPerBillingAmount" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Image ID="imgShowGrowth" Width="16px" Height="16px" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                        <ul id="myMenu2" class="contextMenu">
                            <li class="monthwise"><a href="#monthwise">Month Wise</a></li>
                            <li class="branchwise"><a href="#branchwise">Branch Wise</a></li>
                        </ul>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
