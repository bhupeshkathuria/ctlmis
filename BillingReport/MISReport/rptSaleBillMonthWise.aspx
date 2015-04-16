<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rptSaleBillMonthWise.aspx.cs" Inherits="MISReport_rptSaleBillMonthWise" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type='text/css'>
        .dvContent
        {
            width: 100%;
            height: 70%;
            
            overflow: scroll;
        }
    </style>
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
                            &nbsp;&nbsp;Sale Billing Report Month Wise
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="3px" cellspacing="1px" width="350px">
                                <tr>
                                    <td>
                                        From Year
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlFromYear" Width="70px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        To Year
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
            <table cellspacing="0px" cellpadding="0px">
                <tr>
                    <td>
                        <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px" align="center">
                        <asp:Label ID="lblReportHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border: none;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px" align="center">
                        <asp:Label ID="lblzoneHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="dvContent">
                <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                    <HeaderTemplate>
                        <table border="1" cellpadding="0px" cellspacing="0px" width="150%" style="height:auto">
                            <tbody>
                                <tr>
                                    <th colspan="2" align="center">
                                        Year
                                    </th>
                                    <th colspan="2" align="center">
                                        April
                                    </th>
                                    <th colspan="2" align="center">
                                        May
                                    </th>
                                    <th colspan="2" align="center">
                                        June
                                    </th>
                                    <th colspan="2" align="center">
                                        July
                                    </th>
                                    <th colspan="2" align="center">
                                        August
                                    </th>
                                    <th colspan="2" align="center">
                                        September
                                    </th>
                                    <th colspan="2" align="center">
                                        October
                                    </th>
                                    <th colspan="2" align="center">
                                        November
                                    </th>
                                    <th colspan="2" align="center">
                                        December
                                    </th>
                                    <th colspan="2" align="center">
                                        January
                                    </th>
                                    <th colspan="2" align="center">
                                        Febuary
                                    </th>
                                    <th colspan="2" align="center">
                                        March
                                    </th>
                                    <th colspan="3" align="center">
                                        Total
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale Grand Total</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Revenue Grand Total</strong>
                                    </td>
                                    <td align="right">
                                        <strong>ARPU</strong>
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblARPUTotal" runat="server" Text='<%#Eval("arpusalebilling") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: Gray">
                            <td align="left" colspan="2">
                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsale") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsale") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblARPUTotal" runat="server" Text='<%#Eval("arpusalebilling") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td align="left" colspan="2">
                                <strong>Grand Total:</strong>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaysaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaybillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunesaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunebillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulysaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulybillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljansaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljanbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarsaletotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarbillingtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsalegrandtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillinggrandtotal" runat="server" Font-Bold="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblarpugrandtotal" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <table>
            <tr>
                    <td style="height: 20px" align="center">
                        <asp:Label ID="Label1" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
             <div class="dvContent" style="">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table border="1" cellpadding="0px" cellspacing="0px" width="150%" style="height:auto">
                            <tbody>
                                <tr>
                                    <th colspan="2" align="center">
                                        Year
                                    </th>
                                    <th colspan="2" align="center">
                                        April
                                    </th>
                                    <th colspan="2" align="center">
                                        May
                                    </th>
                                    <th colspan="2" align="center">
                                        June
                                    </th>
                                    <th colspan="2" align="center">
                                        July
                                    </th>
                                    <th colspan="2" align="center">
                                        August
                                    </th>
                                    <th colspan="2" align="center">
                                        September
                                    </th>
                                    <th colspan="2" align="center">
                                        October
                                    </th>
                                    <th colspan="2" align="center">
                                        November
                                    </th>
                                    <th colspan="2" align="center">
                                        December
                                    </th>
                                    <th colspan="2" align="center">
                                        January
                                    </th>
                                    <th colspan="2" align="center">
                                        Febuary
                                    </th>
                                    <th colspan="2" align="center">
                                        March
                                    </th>
                                    <th colspan="3" align="center">
                                        Total
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Billing</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Sale Grand Total</strong>
                                    </td>
                                    <td align="right">
                                        <strong>Revenue Grand Total</strong>
                                    </td>
                                    <td align="right">
                                        <strong>ARPU</strong>
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromtoper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotalper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotalper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblARPUTotal" runat="server" Text='<%#Eval("arpusalebillingper") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: Gray">
                            
                            <td align="left" colspan="2">
                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromtoper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsaleper") %>' />
                            </td>
                            <td align="right" style="border-right: 1px solid #333; border-left: 1px solid #333;">
                                <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsaleper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbillingper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotalper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotalper") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblARPUTotal" runat="server" Text='<%#Eval("arpusalebillingper") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    
                </asp:Repeater>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
