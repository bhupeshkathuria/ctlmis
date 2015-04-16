<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MonthlyReportByBranch.aspx.cs" Inherits="CreditControl_MonthlyReportByBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
            <div style="width: 100%; padding: 0px 0px 0px 0px; font:11px verdana;">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" colspan="3" align="left" style="width: 244px">
                            &nbsp;&nbsp;Invoice / Credit Report /
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 987px">
                        <fieldset style="width:400px;">
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
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                    </td>
                                    <td id="tdexcel" runat="server" visible="false">
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                                            OnClick="imgexport_Click"  />
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
                        <td colspan="3" style=" width:100%;">
                        <div style=" width:1000px;overflow:auto; overflow-x:scroll;overflow-y:hidden;">
                            <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                                <HeaderTemplate>
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table-area">
                                        <tbody>
                                            <tr>
                                                <th colspan="3" align="center" style="background-color:#ccc;" >
                                                    Branch Name.
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    April.
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    May
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    June
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    July
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    Aug
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    September
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    October
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    November
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    December
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    Jan
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    Feb
                                                </th>
                                                <th colspan="3" align="center" style="background-color:#ccc;">
                                                    March
                                                </th>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                </td>
                                                <td align="Right" style="background-color:Maroon;color:White;" >
                                                    <strong>Billing</strong></td>
                                                <td align="Right"  style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td align="Right" style="background-color:Maroon;color:White;" >
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td   align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td   align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td   align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>Billing</strong></td>
                                                <td  align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;background-color:Maroon;color:White;">
                                                    <strong>Collection</strong></td>
                                                <td  align="Right" style="background-color:Maroon;color:White;">
                                                    <strong>%</strong></td>
                                            </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="left" colspan="3" >
                                            <asp:Label ID="lblbrnchname" runat="server" Text='<%#Eval("branch") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaprilbill" runat="server" Text='<%#Eval("aprilbill") %>' />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lblaprilcoll" runat="server" Text='<%#Eval("aprilcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaprilper" runat="server" Text='<%#Eval("aprilper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmaybill" runat="server" Text='<%#Eval("maybill") %>' />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lblmaycoll" runat="server" Text='<%#Eval("maycoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmayper" runat="server" Text='<%#Eval("mayper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljunebill" runat="server" Text='<%#Eval("junebill") %>' />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lbljunecoll" runat="server" Text='<%#Eval("junecoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljuneper" runat="server" Text='<%#Eval("juneper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljulybill" runat="server" Text='<%#Eval("julybill") %>' />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lbljulycoll" runat="server" Text='<%#Eval("julycoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljulyper" runat="server" Text='<%#Eval("julyper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaugbill" runat="server" Text='<%#Eval("augbill") %>' />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lblaugcoll" runat="server" Text='<%#Eval("augcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaugper" runat="server" Text='<%#Eval("augper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptbill" runat="server" Text='<%#Eval("septbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptcoll" runat="server" Text='<%#Eval("septcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptper" runat="server" Text='<%#Eval("septper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctbill" runat="server" Text='<%#Eval("octbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctcoll" runat="server" Text='<%#Eval("octcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctper" runat="server" Text='<%#Eval("octper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovbill" runat="server" Text='<%#Eval("novbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovcoll" runat="server" Text='<%#Eval("novcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovper" runat="server" Text='<%#Eval("novper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldecbill" runat="server" Text='<%#Eval("decbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldeccoll" runat="server" Text='<%#Eval("deccoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldecper" runat="server" Text='<%#Eval("decper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljanbill" runat="server" Text='<%#Eval("janbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljancoll" runat="server" Text='<%#Eval("jancoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljanper" runat="server" Text='<%#Eval("janper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebbill" runat="server" Text='<%#Eval("febbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebcoll" runat="server" Text='<%#Eval("febcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebper" runat="server" Text='<%#Eval("febper") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmarbill" runat="server" Text='<%#Eval("marbill") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmarcoll" runat="server" Text='<%#Eval("marcoll") %>' />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmarper" runat="server" Text='<%#Eval("marper") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td align="left" colspan="3">
                                            <strong>Grand Total:</strong>
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaprilbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                            <asp:Label ID="lblaprilcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaprilpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmaybilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmaycolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmaypertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljunebilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljunecolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljunepertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljulybilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljulycolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljulypertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaugbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaugcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblaugpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblseptpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbloctpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblnovpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldecbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldeccolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbldecpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljanbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljancolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lbljanpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblfebpertotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmarbilltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
                                            <asp:Label ID="lblmarcolltotal" runat="server" Font-Bold="true" />
                                        </td>
                                        <td align="Right">
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

