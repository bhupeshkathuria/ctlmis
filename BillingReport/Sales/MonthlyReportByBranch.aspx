<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MonthlyReportByBranch.aspx.cs" Inherits="CreditControl_MonthlyReportByBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script language="javascript" type="text/javascript">
        function openNewWin(url) {

            var w = 1050;
            var h = 500;
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);

            var x = window.open(url, 'mynewwin', 'menubar=0,resizable=no,scrollbars=yes, maximize=no,width=' + w + ', height=' + h + ', top=' + top + ', left=' + left + ',toolbar=0');
            x.focus();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
            <table width="100%" cellpadding="5px" cellspacing="0">
                <tr>
                    <td class="Header_text" colspan="3" align="left" style="width: 244px">
                        &nbsp;&nbsp;Invoice / Credit Report /
                    </td>
                </tr>
                <tr>
                    <td style="width: 987px">
                        <fieldset style="width: 400px;">
                            <table width="400" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        Financial Year:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlyear2byyear" runat="server" Width="150px">
                                            <asp:ListItem Text="Select Financial Year" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="2009-2010" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2010-2011" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="2011-2012" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="2012-2013" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="2013-2014" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="2014-2015" Value="6"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"/>
                                    </td>
                                    <td id="tdexcel" runat="server" visible="false">
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                                            OnClick="imgexport_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInvoice" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 100%;">
                        <div style="width: 1000px; overflow: auto; overflow-x: scroll; overflow-y: hidden;">
                            <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound"
                                OnItemCommand="RAFRepeater_ItemCommand">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table-area">
                                        <tbody>
                                            <tr>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    LeadSource.
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    April
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    May
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    June
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    July
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    Aug
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    September
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    October
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    November
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    December
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    Jan
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    Feb
                                                </th>
                                                <th colspan="3" align="center" style="background-color: #ccc;">
                                                    March
                                                </th>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Total Lead</strong>
                                                </td>
                                                <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;
                                                    background-color: Maroon; color: White;">
                                                    <strong>Sale Conf.</strong>
                                                </td>
                                                <td align="right" style="background-color: Maroon; color: White;">
                                                    <strong>Card Sold</strong>
                                                </td>
                                            </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="left" colspan="3">
                                            <asp:Label ID="lblbrnchname" runat="server" Text='<%#Eval("LeadSource") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaprilbill" runat="server" Text='<%#Eval("aprilbill") %>' />
                                        </td>
                                        <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:LinkButton ID="lblaprilcoll" runat="server" CommandName="April" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("aprilcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaprilper" runat="server" Text='<%#Eval("aprilper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmaybill" runat="server" Text='<%#Eval("maybill") %>' />
                                        </td>
                                        <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:LinkButton ID="lblmaycoll" runat="server" CommandName="May" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("maycoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmayper" runat="server" Text='<%#Eval("mayper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljunebill" runat="server" Text='<%#Eval("junebill") %>' />
                                        </td>
                                        <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:LinkButton ID="lbljunecoll" runat="server" CommandName="June" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("junecoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljuneper" runat="server" Text='<%#Eval("juneper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljulybill" runat="server" Text='<%#Eval("julybill") %>' />
                                        </td>
                                        <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:LinkButton ID="lbljulycoll" runat="server" CommandName="July" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("julycoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljulyper" runat="server" Text='<%#Eval("julyper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaugbill" runat="server" Text='<%#Eval("augbill") %>' />
                                        </td>
                                        <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:LinkButton ID="lblaugcoll" runat="server" CommandName="August" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("augcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaugper" runat="server" Text='<%#Eval("augper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblseptbill" runat="server" Text='<%#Eval("septbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lblseptcoll" runat="server" CommandName="September" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("septcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblseptper" runat="server" Text='<%#Eval("septper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbloctbill" runat="server" Text='<%#Eval("octbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbloctcoll" runat="server" CommandName="October" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("octcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbloctper" runat="server" Text='<%#Eval("octper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblnovbill" runat="server" Text='<%#Eval("novbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lblnovcoll" runat="server" CommandName="November" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("novcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblnovper" runat="server" Text='<%#Eval("novper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbldecbill" runat="server" Text='<%#Eval("decbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbldeccoll" runat="server" CommandName="December" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("deccoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbldecper" runat="server" Text='<%#Eval("decper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljanbill" runat="server" Text='<%#Eval("janbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbljancoll" runat="server" CommandName="January" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("jancoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljanper" runat="server" Text='<%#Eval("janper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblfebbill" runat="server" Text='<%#Eval("febbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lblfebcoll" runat="server" CommandName="February" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("febcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblfebper" runat="server" Text='<%#Eval("febper") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmarbill" runat="server" Text='<%#Eval("marbill") %>' />
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lblmarcoll" runat="server" CommandName="March" CommandArgument='<%#Eval("LeadSource") %>'
                                                Text='<%#Eval("marcoll") %>'></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmarper" runat="server" Text='<%#Eval("marper") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td align="left" colspan="3">
                                            <strong>Grand Total:</strong>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaprilbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <%--<td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">--%>
                                         <td align="right">
                                            <%--<asp:Label ID="lblaprilcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblaprilcolltotal" runat="server" Font-Bold="true" CommandName="April"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaprilpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmaybilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblmaycolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblmaycolltotal" runat="server" Font-Bold="true" CommandName="May"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmaypertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljunebilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lbljunecolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lbljunecolltotal" runat="server" Font-Bold="true" CommandName="June"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljunepertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljulybilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lbljulycolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lbljulycolltotal" runat="server" Font-Bold="true" CommandName="July"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljulypertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaugbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblaugcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblaugcolltotal" runat="server" Font-Bold="true" CommandName="August"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblaugpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblseptbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblseptcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblseptcolltotal" runat="server" Font-Bold="true" CommandName="September"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblseptpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbloctbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lbloctcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lbloctcolltotal" runat="server" Font-Bold="true" CommandName="October"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbloctpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblnovbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblnovcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblnovcolltotal" runat="server" Font-Bold="true" CommandName="November"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblnovpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbldecbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lbldeccolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lbldeccolltotal" runat="server" Font-Bold="true" CommandName="December"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbldecpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljanbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lbljancolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lbljancolltotal" runat="server" Font-Bold="true" CommandName="January"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lbljanpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblfebbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblfebcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblfebcolltotal" runat="server" Font-Bold="true" CommandName="February"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblfebpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmarbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="right">
                                            <%--<asp:Label ID="lblmarcolltotal" runat="server" Font-Bold="true" />--%>
                                            <asp:LinkButton ID="lblmarcolltotal" runat="server" Font-Bold="true" CommandName="March"></asp:LinkButton>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmarpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                    </tr>
                                    </tbody> </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
