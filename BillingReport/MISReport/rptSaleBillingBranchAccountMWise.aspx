﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptSaleBillingBranchAccountMWise.aspx.cs" Inherits="MISReport_rptSaleCategoryMonthBranchWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Branch Wise Report </title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="gridviewScroll.min.js"></script>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function pageLoad() {
            document.body.style.overflow = "hidden";

            $('#GridView1').gridviewScroll({
                width: 1300,
                height: 600,
                freezesize: 4
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="df" runat="server">
        </asp:ScriptManager>
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
            <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                <HeaderTemplate>
                   <table border="1" id="GridView1" cellpadding="1px" cellspacing="1px" style="border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: Gray; color:White;" class="GridviewScrollHeader">
                                <td align="center">
                                    Year
                                </td>
                               <td align="center">
                                    Sale Category
                                </td>
                                <td align="center">
                                    Branch
                                </td>
                                <td align="center">
                                    Account Manager
                                </td>
                                <td align="center">
                                    Apr Sale
                                </td>
                                <td align="center">
                                    Apr Billing
                                </td>
                                <td align="center">
                                    May Sale
                                </td>
                                <td align="center">
                                    May Billing
                                </td>
                                <td align="center">
                                    Jun Sale
                                </td>
                                <td align="center">
                                    Jun Billing
                                </td>
                                <td align="center">
                                    Jul Sale
                                </td>
                                <td align="center">
                                    Jul Billing
                                </td>
                                <td align="center">
                                    Aug Sale
                                </td>
                                <td align="center">
                                    Aug Billing
                                </td>
                                <td align="center">
                                    Sep Sale
                                </td>
                                <td align="center">
                                    Sep Billing
                                </td>
                                <td align="center">
                                    Oct Sale
                                </td>
                                <td align="center">
                                    Oct Billing
                                </td>
                                <td align="center">
                                    Nov Sale
                                </td>
                                <td align="center">
                                    Nov Billing
                                </td>
                                <td align="center">
                                    Dec Sale
                                </td>
                                <td align="center">
                                    Dec Billing
                                </td>
                                <td align="center">
                                    Jan Sale
                                </td>
                                <td align="center">
                                    Jan Billing
                                </td>
                                <td align="center">
                                    Feb Sale
                                </td>
                                <td align="center">
                                    Feb Billing
                                </td>
                                <td align="center">
                                    Mar Sale
                                </td>
                                <td align="center">
                                    Mar Billing
                                </td>
                                <td align="center">
                                    Sale Grand Total
                                </td>
                                <td align="center">
                                    Revenue Grand Total
                                </td>
                                <td align="center">
                                    ARPU
                                </td>
                               <%-- <td></td>--%>
                            </tr>
                           
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="drow" runat="server" class="GridviewScrollItem">
                        <td align="left">
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                        </td>
                         <td align="left">
                            <asp:Label ID="lblSaleCategory" runat="server" Text='<%#Eval("salecategoryname") %>' />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("branchname") %>' />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblAccountManager" runat="server" Text='<%#Eval("employeename") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbilling") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybilling") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbilling") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbilling") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsale") %>' />
                        </td>
                        <td align="right" >
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
                       <%-- <td align="center">
                            <asp:Image ID="imgShowGrowth" Width="16px" Height="16px" runat="server" />
                        </td>--%>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>

