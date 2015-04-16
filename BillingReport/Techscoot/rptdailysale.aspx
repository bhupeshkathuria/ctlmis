<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"CodeFile="rptdailysale.aspx.cs"Inherits="Techscoot_rptdailysale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .record-search
        {
            width: 70%;
            height: auto;
            font-family: 'Proxima Nova' , 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            color: #666;
            line-height: 26px;
        }
        .record-search input
        {
            width: 120px;
            height: 20px !important;
            border: 1px solid #999;
            background: #f8f8f8;
            color: #999;
            padding: 2px 5px;
        }
        .report-date input
        {
            width: 120px;
            height: 18px !important;
            border: 1px solid #999;
            background: #f8f8f8;
            color: #999;
            padding: 2px 5px;
        }
        .g-btn input[type="submit"]
        {
            font: normal 11px Verdana;
            color: #6c6c6c;
            padding: 1px 2px 3px 2px;
            border: 1px solid #d3d3d3;
            border-radius: 4px;
            background: url(../images/patt.jpg) repeat;
        }
        .record-search .g-btn1
        {
            width: 60px !important;
            height: 20px !important;
            float: left;
            background: #ccc;
            margin: 5px 0;
            cursor: pointer;
        }
        .record-result
        {
            width: 98%;
            height: auto;
            font-family: 'Proxima Nova' , 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            color: #666;
            margin: 15px 0 0 0;
        }
        .record-result table
        {
            color: #666;
            border-collapse: collapse;
        }
        .record-result th
        {
            border: none;
            color: #fff;
            border-collapse: collapse;
            background: #017DC3;
            height: 25px;
            line-height: 25px;
            padding: 0 5px;
        }
        .record-result td
        {
            border: 1px solid #B8B6B6;
            border-collapse: collapse;
            color: #666;
            height: 22px;
            padding: 2px 5px;
            font-size: 13px;
        }
        .force-right
        {
            text-align: right !important;
        }
        .force-right-spn
        {
            float: right !important;
        }
        .force-left
        {
            text-align: left !important;
        }
    </style>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="60%">
        <tr>
            <td>
                From Date:
            </td>
            <td class="report-date">
                <%--     <asp:TextBox ID="txtfromdate" runat="server" Width="150px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate">
                            </asp:CalendarExtender>--%>
                <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox><span>
                    <img alt="Calender" src="../Images/calender_icon.jpg" id="img1" /></span>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                    Format="yyyy-MM-dd" PopupButtonID="img1">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Report"
                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txtfromdate"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
            <td>
                To Date:
            </td>
            <td class="report-date">
                <asp:TextBox ID="txttodate" runat="server"></asp:TextBox><span>
                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgto" /></span>
                <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txttodate"
                    Format="yyyy-MM-dd" PopupButtonID="imgto">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txttodate"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                <%--<asp:TextBox ID="txttodate" runat="server" Width="150px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate">
                            </asp:CalendarExtender>--%>
            </td>
            <td class="g-btn">
                <%-- <asp:LinkButton ID="lnksearch" runat="server" CssClass="submit-lead" OnClick="lnksearch_Click">Search</asp:LinkButton>--%>
                <asp:Button ID="lnksearch" Width="50px" runat="server" Text="Search" ValidationGroup="Report"
                    OnClick="lnksearch_Click" />
                <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Range is not valid!!!"
                    ValidationGroup="Report" ForeColor="Red" ControlToValidate="txttodate" ControlToCompare="txtfromdate"
                    Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
            </td>
            <td class="g-btn">
                <asp:Button ID="btnExport" Width="50px" runat="server" Text="Export" Visible="false"
                    OnClick="btnExport_Click" />
                <%--  <asp:LinkButton ID="btnExport" runat="server" CssClass="table-area" Visible="false"
                                OnClick="btnExport_Click">Export</asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="UdpMain">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UdpMain" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="30%">
                        <asp:GridView ID="grdtechscootsale" runat="server" CssClass="record-result" AutoGenerateColumns="False"
                            Width="60%" EmptyDataText="No Record" OnRowCommand="grdtechscootsale_RowCommand"
                            ShowFooter="True" OnRowDataBound="grdtechscootsale_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblcreatedon" runat="server" Text='<%#Eval("createdon") %>'></asp:LinkButton>
                                        <asp:Label ID="lbldatehide" runat="server" Text='<%#Eval("hidedate") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotorder" runat="server" Text="Total"></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="99.99" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl99" runat="server" Text='<%#Eval("99") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotal99" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="149.99" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl149" runat="server" Text='<%#Eval("149") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotal149" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="199.99" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl199" runat="server" Text='<%#Eval("199") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotal199" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="299.99" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl299" runat="server" Text='<%#Eval("299") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotal299" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Sale" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltotalSale" runat="server" Text='<%#Eval("TotalSale") %>'></asp:Label>
                                        <asp:Label ID="lblfromdate" runat="server" Text='<%#Eval("_fromdate") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbltodate" runat="server" Text='<%#Eval("_todate") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblgrosssale" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EPN(USD)" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpayEpn" runat="server" Text='<%#Eval("payEpn") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotalepn" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Techscoot(USD)" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPayTechscoot" runat="server" Text='<%#Eval("PayTechscoot") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotaltechscoot" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Spend" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBingsale" runat="server" Text='<%#Eval("Bingsale") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotalBingsale" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                   <%-- <td>--%>
                       <%-- <div>
                            <asp:Literal ID="lt" runat="server"></asp:Literal>
                        </div>--%>
                       <%-- <div id="chart_div" style="width: 900px; height: 500px;">
                        </div>--%>
                        <%--<asp:Panel ID="panel" runat="server" Visible="False">
                            <br />
                            <table cellpadding="2" cellspacing="0" align="left" width="50%" border="0">
                                <tr>
                                    <td align="right">
                                        <asp:Image ID="imgMsg2" runat="server" Height="36px" Width="36px" />
                                    </td>
                                    <td align="left" style="height: 36px; vertical-align: top; padding-top: 7px;">
                                        <asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>--%>
                   <%-- </td>--%>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="grdcard" runat="server" CssClass="record-result" AutoGenerateColumns="False"
                            Width="100%" EmptyDataText="No Record" ShowFooter="True" OnRowDataBound="grdcard_RowDataBound"
                            OnPageIndexChanging="grdcard_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="lblViewPo" Text="View" runat="server" CommandArgument='<%# Eval("filename") %>'
                                            OnClick="lblViewPo_Click"></asp:LinkButton>--%>
                                        <a target="_blank" href='<%# GetUrl(Eval("filename")) %>'>View</a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OrderID" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblorder" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotorder" runat="server" Text="Total"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time Of Sale" HeaderStyle-Width="170px" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcreatedon" runat="server" Text='<%#Eval("createdon") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Agent" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfirstname" runat="server" Text='<%#Eval("firstname") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Card No" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcardno" runat="server" Text='<%#Eval("cardno") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NameOnCard" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnameoncard" runat="server" Text='<%#Eval("nameoncard") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CardType" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcardtype" runat="server" Text='<%#Eval("cardtype") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PhoneNo" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcustphoneno" runat="server" Text='<%#Eval("custphoneno") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcustemailid" runat="server" Text='<%#Eval("custemailid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpaymentstaus" runat="server" Text='<%#Eval("paymentstaus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>' CssClass="force-right-spn"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Label ID="lbltotal" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Payment Gateway">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpaymentmethod" runat="server" Text='<%#Eval("paymentmethod") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldocstatus" runat="server" Text='<%#Eval("docstatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
