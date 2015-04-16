<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptSaleBillMonthWisePopUP.aspx.cs"
    Inherits="MISReport_rptSaleBillMonthWisePopUP" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Month Wise Report </title>
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
                height: 200,
                freezesize: 1
            });

            $('#GridView2').gridviewScroll({
                width: 1300,
                height: 200,
                freezesize: 1
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
                        &nbsp;&nbsp;Sale Billing Report Month Wise
                    </td>
                    <td class="Header_text" align="right">
                        <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
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
                            <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                <td align="center">
                                    Year
                                </td>
                                <td align="center">
                                    Apr Sale
                                </td>
                                <td align="center">
                                    Apr Billing
                                </td>

                                <td align="center">
                                    Apr Sales Force
                                </td>

                                <td align="center">
                                    May Sale
                                </td>
                                <td align="center">
                                    May Billing
                                </td>
                                <td align="center">
                                    May Sales Force
                                </td>
                                <td align="center">
                                    Jun Sale
                                </td>
                                <td align="center">
                                    Jun Billing
                                </td>
                                <td align="center">
                                    Jun Sales Force
                                </td>
                                <td align="center">
                                    Jul Sale
                                </td>
                                <td align="center">
                                    Jul Billing
                                </td>
                                <td align="center">
                                    Jul Sales Force
                                </td>
                                <td align="center">
                                    Aug Sale
                                </td>
                                <td align="center">
                                    Aug Billing
                                </td>
                                <td align="center">
                                    Aug Sales Force
                                </td>
                                <td align="center">
                                    Sep Sale
                                </td>
                                <td align="center">
                                    Sep Billing
                                </td>
                                <td align="center">
                                    Sep Sales Force
                                </td>
                                <td align="center">
                                    Oct Sale
                                </td>
                                <td align="center">
                                    Oct Billing
                                </td>
                                <td align="center">
                                    Oct Sales Force
                                </td>
                                <td align="center">
                                    Nov Sale
                                </td>
                                <td align="center">
                                    Nov Billing
                                </td>
                                <td align="center">
                                    Nov Sales Force
                                </td>
                                <td align="center">
                                    Dec Sale
                                </td>
                                <td align="center">
                                    Dec Billing
                                </td>
                                <td align="center">
                                    Dec Sales Force
                                </td>
                                <td align="center">
                                    Jan Sale
                                </td>
                                <td align="center">
                                    Jan Billing
                                </td>
                                <td align="center">
                                    Jan Sales Force
                                </td>
                                <td align="center">
                                    Feb Sale
                                </td>
                                <td align="center">
                                    Feb Billing
                                </td>
                                <td align="center">
                                    Feb Sales Force
                                </td>
                                <td align="center">
                                    Mar Sale
                                </td>
                                <td align="center">
                                    Mar Billing
                                </td>
                                <td align="center">
                                    Mar Sales Force
                                </td>
                                <td align="center">
                                    Sale Grand Total
                                </td>
                                <td align="center">
                                    Revenue Grand Total
                                </td>
                                <td align="center">
                                    Total Sales Force
                                </td>
                                <td align="center">
                                    ARPU
                                </td>
                                <td></td>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="GridviewScrollItem">
                        <td align="left">
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromto") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblaprSalesForce" runat="server" Text='<%#Eval("aprSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblmaySalesForce" runat="server" Text='<%#Eval("maySalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljunSalesForce" runat="server" Text='<%#Eval("junSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljulSalesForce" runat="server" Text='<%#Eval("julSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsale") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblaugSalesForce" runat="server" Text='<%#Eval("augSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblsepSalesForce" runat="server" Text='<%#Eval("sepSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbloctSalesForce" runat="server" Text='<%#Eval("octSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblnovSalesForce" runat="server" Text='<%#Eval("novSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbldecSalesForce" runat="server" Text='<%#Eval("decSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbljanSalesForce" runat="server" Text='<%#Eval("janSalesForce") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblfebSalesForce" runat="server" Text='<%#Eval("febSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsale") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbilling") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblmarSalesForce" runat="server" Text='<%#Eval("marSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotal") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotal") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lbltotalSalesForce" runat="server" Text='<%#Eval("totalSalesForce") %>' />
                        </td>

                        <td align="right">
                            <asp:Label ID="lblARPUTotal" runat="server" Text='<%#Eval("arpusalebilling") %>' />
                        </td>
                        <td align="center">
                            <asp:Image ID="imgShowGrowth" Width="16px" Height="16px" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr style="background-color: Gray; color: White;" class="GridviewScrollItem">
                        <td align="left">
                            <strong>Grand Total:</strong>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaprilsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaprilbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaprsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmaysaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmaybillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblmaysalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljunesaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljunebillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljunsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljulysaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljulybillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljulsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaugsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaugbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaugsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblseptsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblseptbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblsepsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbloctsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbloctbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbloctsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblnovsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblnovbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblnovsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbldecsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbldecbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                         <td align="right" >
                            <asp:Label ID="lbldecsaleseforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljansaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljanbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljansalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblfebsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblfebbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblfebsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmarsaletotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmarbillingtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmarsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblsalegrandtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblbillinggrandtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblgrandsalesforcetotal" runat="server" Font-Bold="true" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblarpugrandtotal" runat="server" Font-Bold="true" />
                        </td>
                        <td></td>
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
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="1" id="GridView2" cellpadding="1px" cellspacing="1px" style="border-collapse: collapse;">
                        <tbody>
                             <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                <td align="center">
                                    Year
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
                            </tr>
                                
                </HeaderTemplate>
                <ItemTemplate>
                     <tr class="GridviewScrollItem">
                        <td align="left">
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearfromtoper") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaprilsale" runat="server" Text='<%#Eval("aprsaleper") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbillingper") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysaleper") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybillingper") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsaleper") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbillingper") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsaleper") %>' />
                        </td>
                        <td align="right" >
                            <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbillingper") %>' />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsaleper") %>' />
                        </td>
                        <td align="right" >
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
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
