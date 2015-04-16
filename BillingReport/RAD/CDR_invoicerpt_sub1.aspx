<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CDR_invoicerpt_sub1.aspx.cs" Inherits="CDR_invoicerpt_sub1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Revenue Audit</title>
    <link href="../Css/Main.css" rel="stylesheet" type="text/css" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
<%--    <script src="JS/jquery.min.js" type="text/javascript"></script>
    <script src="JS/site.js" type="text/javascript"></script>
    <link href="Css/pop_up.css" rel="stylesheet" type="text/css" />--%>
</head>
<body>
    <form id="form1" runat="server">
   <div align="center">
        <%--<asp:UpdatePanel ID="UpdatePanelMain" runat="server">
                <ContentTemplate>--%>
        <%--<asp:UpdateProgress ID="upbar1" runat="server" AssociatedUpdatePanelID="UpdatePanelMain">
            <ProgressTemplate>
                <div id="mydiv">
                   <img alt="" src="Images/indicator.gif" /><span style="font-weight: bold; font-size: 15px">&nbsp;Processing&nbsp;please&nbsp;wait
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <table cellpadding="0" cellspacing="0" border="0px" width="100%" align="center">
            <tr>
                <td style="width: 700px;">
                    <table>
                        
                        <tr>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <table>
                            <tr>
                            <td valign="top">
                               <%-- <div style="width: 1350px; overflow: auto; float: left; overflow-x: scroll; overflow-y: hidden;">--%>
                                    <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                                        <HeaderTemplate>
                                            <table border="1" cellpadding="0" cellspacing="0" class="table-area">
                                                <thead>
                                                    <tr id="thead">
                                                        <th align="center" style="width: 150px; text-align: center">
                                                        </th>
                                                        <th align="center" style="width: 150px; text-align: center">
                                                        </th>
                                                        <th align="center" style="width: 150px; text-align: center">
                                                        </th>
                                                       

                                                        <th colspan="5" align="center">
                                                        </th>
                                                        <th colspan="4" align="center">
                                                            Retailer
                                                        </th>
                                                        <th colspan="4" align="center">
                                                            Wholesaler
                                                        </th>
                                                        <th colspan="2" align="center">
                                                            Total
                                                        </th>
                                                      <%--  <th colspan="5" align="center">
                                                            Revenue Lookup
                                                        </th>--%>
                                                    </tr>
                                                    <tr>
                                                    <td style="width: 150px; text-align: center">
                                                            <strong>Invoicing Month[A]</strong>
                                                        </td>
                                                         <td style="width: 150px; text-align: center">
                                                            <strong>Provider[B]</strong>
                                                        </td>
                                                       <td style="width: 150px; text-align: center">
                                                            <strong>Country[C]</strong>
                                                        </td>
                                                        
                                                       
                                                        <td>
                                                            <strong>Invoice Amount(FX)[D]</strong>
                                                        </td>
                                                         <td>
                                                            <strong>Invoice Amount(INR)[E]</strong>
                                                        </td>
                                                        <td id="tdcdramtheader" runat="server">
                                                            <strong>CDR Amount(FX)[F]</strong>
                                                        </td>
                                                        <td >
                                                            <strong>CDR Amount(INR)[G]</strong>
                                                        </td>
                                                        <td>
                                                            <strong>FX Rate[H]</strong>
                                                        </td>
                                                        <%--<td>
                                                            <strong>GAP[E-G]</strong>
                                                        </td>--%>
                                                        <%--Retailer--%>
                                                        <td align="Right">
                                                            <strong>In Charge (FX)[I]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Out Charge (FX)[J]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>In Charge INR   [K]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Out Charge INR [L]</strong>
                                                        </td>
                                                        <%--Wholesaler--%>
                                                        <td align="Right">
                                                            <strong>In Charge (FX)[M]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Out Charge (FX)[N]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>In Charge INR [O]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Out Charge INR [P]</strong>
                                                        </td>
                                                        <%--Total--%>
                                                        <td style="width: 150px; align="Left">
                                                            <strong>Total Out (FX) [J + N]</strong>
                                                        </td>
                                                        <td style="width: 150px; align="Left">
                                                            <strong>Total Out (INR) [L + P]</strong>
                                                        </td>
                                                        <%--Invoice--%>
                                                        <%--<td align="Right">
                                                            <strong>Invoice Amount (FX)[Q]</strong>
                                                        </td>
                                                         <td align="Right">
                                                            <strong>Invoice Amount (INR)[R]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Total Billing (FX)[S]</strong>
                                                        </td>
                                                        <td align="Right">
                                                            <strong>Total Billing (INR)[T]</strong>
                                                        </td>
                                                        
                                                        <td align="Left">
                                                            <strong>Gross Rev (INR)[T-R]</strong>
                                                        </td>--%>
                                                     
                                                    </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                            <td>
                                                    <asp:Label ID="lblbillingmonth" runat="server" Text='<%#Eval("BillingMonth") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnetwork" runat="server" Text='<%#Eval("Network") %>' />
                                                </td>
                                                <td style="width: 120px; text-align: center">
                                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("countryname") %>' />
                                                </td>
                                                
                                                <td align="Right">
                                                    <asp:Label ID="lblinvoiceamount" runat="server" Text='<%#Eval("invoiceamount") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                </td>
                                                <td id="tdcdramt" runat="server" align="Right">
                                                    <asp:Label ID="lblcdramount" runat="server" Text='<%#Eval("cdrtotalamount") %>' />
                                                </td>
                                                <td  align="Right">
                                                    <asp:Label ID="lblcdramountallinr" runat="server" Text='<%#Eval("cdramountallinr") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblfxr" runat="server" Text='<%#Eval("fxr") %>' />
                                                </td>
                                                <%--<td id="tdlblgap" runat="server" align="Right">
                                                    <asp:Label ID="lblgap" runat="server" Text='<%#Eval("gap") %>' />
                                                </td>--%>
                                                <%--<td ><asp:Label ID="lblcdrcurrency" runat="server" Text='<%#Eval("currency") %>' /></td>--%>
                                                <%--Retailer--%>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_incharge" runat="server" Text='<%#Eval("ret_incharge") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_outcharge" runat="server" Text='<%#Eval("ret_outcharge") %>' />
                                                </td>
                                                <td id ="tdlblret_incharge_inr" runat="server" align="Right">
                                                    <asp:Label ID="lblret_incharge_inr" runat="server" Text='<%#Eval("ret_incharge_inr") %>' />
                                                </td>
                                                <td id ="tdlblret_outcharge_inr" runat="server" align="Right">
                                                    <asp:Label ID="lblret_outcharge_inr" runat="server" Text='<%#Eval("ret_outchargeinr") %>' />
                                                </td>
                                                <%--Wholesaler--%>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_incharge" runat="server" Text='<%#Eval("whole_incharge") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_outcharge" runat="server" Text='<%#Eval("whole_outcharge") %>' />
                                                </td>
                                                <td id ="tdlblwhole_incharge_inr" runat="server" align="Right">
                                                    <asp:Label ID="lblwhole_incharge_inr" runat="server" Text='<%#Eval("whole_inchargeINR") %>' />
                                                </td>
                                                <td id ="tdlblwhole_outcharge_inr" runat="server"  align="Right">
                                                    <asp:Label ID="lblwhole_outcharge_inr" runat="server" Text='<%#Eval("whole_outchargeINR") %>' />
                                                </td>
                                                <%--Total--%>
                                                <td align="Right">
                                                    <asp:Label ID="lbltot_outchargefx" runat="server" Text='<%#Eval("totaloutfx") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lbltot_outchargeINR" runat="server" Text='<%#Eval("totaloutinr") %>' />
                                                </td>
                                                <%--Revenue--%>
                                                <%--<td id ="tdlblrevinvoiceamount" runat="server" align="Right">
                                                    <asp:Label ID="lblrevinvoiceamount" runat="server" Text='<%#Eval("revinvoiceamount") %>' />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblrevinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                </td>
                                                <td id ="tdlbltotalbilling" runat="server" align="Right">
                                                    <asp:Label ID="lbltotalbilling" runat="server" Text='<%#Eval("totalbilling") %>' />
                                                </td>
                                                 <td align="Right">
                                                    <asp:Label ID="lbltotalbillinginr" runat="server" Text='<%#Eval("totalbillinginr") %>' />
                                                </td>
                                               
                                                <td id ="tdlblgrossrevinr" runat="server" align="Right">
                                                    <asp:Label ID="lblgrossrevinr" runat="server" Text='<%#Eval("grosrevinr") %>' />
                                                </td>--%>
                                              
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <%--Retailer--%>
                                                <%--Wholesaler--%>
                                                <%--Total--%>
                                                <%--Invoice--%>
                                                <td colspan="3" align="center">
                                                    <asp:Label ID="lblgrandtot" runat="server" Text="Grand Total" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblinvoiceamountot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblinvoiceamouninrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td id="tdcdramtfooter" runat="server"  align="Right">
                                                    <asp:Label ID="lblcdramounttot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblcdramountinrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblfxtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <%--<td align="Right">
                                                    <asp:Label ID="lblgaptot" runat="server" Font-Bold="true" />
                                                </td>--%>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_inchargetot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_outchargetot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_incharge_inrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblret_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_inchargetot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_outchargetot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_incharge_inrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblwhole_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lbltot_outchargefxtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lbltot_outchargeINRtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <%--<td align="Right">
                                                    <asp:Label ID="lblrevinvamount" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lblrevinvamountinr" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lbltotalbilltot" runat="server" Font-Bold="true" />
                                                </td>
                                                <td align="Right">
                                                    <asp:Label ID="lbltotalbillinrtot" runat="server" Font-Bold="true" />
                                                </td>
                                               
                                                <td align="Right">
                                                    <asp:Label ID="lblgrossrevINRtot" runat="server" Font-Bold="true" />
                                                </td>--%>
                                                
                                            </tr>
                                            </thead> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                <%--</div>--%>
                                </td>
                                <td>
                                
                                                            
                       
                                </td>
                                </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                   
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>--%>
        <%--  <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>--%>
        <%-- </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>
