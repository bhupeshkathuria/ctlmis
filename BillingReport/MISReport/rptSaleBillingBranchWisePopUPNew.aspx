<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptSaleBillingBranchWisePopUPNew.aspx.cs"
    Inherits="MISReport_rptSaleBillingBranchWise" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type='text/css'>
        .dvContent
        {
            width: 95%;
            height: 100%;
            overflow: scroll;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="df" runat="server">
        </asp:ScriptManager>
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
                                &nbsp;&nbsp;Sale Billing Report Branch Wise
                            </td>
                            <td class="Header_text" align="right">
                                <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                <table cellpadding="0px" cellspacing="0px" width="100%">
                <tr>
                <td valign="top">
                <asp:Repeater ID="RepeaterNew" runat="server">
                        <HeaderTemplate>
                            <table border="1" cellpadding="1px" cellspacing="1px" width="300px" style="height: auto">
                                <tbody>
                                    <tr style="background-color: Gray; color: White;">
                                        <th align="center">
                                            Year
                                        </th>
                                        <th align="center">
                                            Zone
                                        </th>
                                        <th align="center">
                                            Branch
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="height:15px;">
                                        </td>
                                        <td style="height:15px;">
                                        </td>
                                        <td style="height:15px;">
                                        </td>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="drow" runat="server">
                                <td align="left">
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblZone" runat="server" Text='<%#Eval("Zone") %>' />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("branchname") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td valign="top">
                <div class="dvContent">
                    <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                        <HeaderTemplate>
                            <table border="1" cellpadding="1px" cellspacing="1px" width="200%" style="height: auto">
                                <tbody>
                                    <tr style="background-color: Gray; color: White;">
                                       <%-- <th align="center">
                                            Year
                                        </th>
                                        <th align="center">
                                            Zone
                                        </th>
                                        <th align="center">
                                            Branch
                                        </th>--%>
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
                                       <%-- <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>--%>
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
                            <tr id="drow" runat="server">
                               <%-- <td align="left">
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblZone" runat="server" Text='<%#Eval("Zone") %>' />
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("branchname") %>' />
                                </td>--%>
                                <td align="right">
                                    <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsale") %>' />
                                     <asp:Label Visible="false" ID="lblZone" runat="server" Text='<%#Eval("Zone") %>' />
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
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                </td>
                </tr>
                </table>
                    
                </div>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
