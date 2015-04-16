<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"CodeFile="CDR_InvoiceRpt.aspx.cs"Inherits="CDR_InvoiceReport"  EnableEventValidation="false"%>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function fixHeader() {

            //get the id of table used in repeater control
            var t = document.getElementById("table12");
            var thead = t.getElementsByTagName("thead")[0];
            var t1 = t.cloneNode(false);
            t1.appendChild(thead);
            tableHeader.appendChild(t1)
        }</script>
    <style type="text/css">
        #progress
        {
            z-index: 500;
            position: absolute;
            color: White;
            top: 50%;
            left: 50%;
        }
        #blur
        {
            height: 100%;
            width: 100%;
            background-color: #666666;
            moz-opacity: 0.5;
            khtml-opacity: .5;
            opacity: 0.5;
            filter: alpha(opacity=50);
            z-index: 120;
            position: fixed;
            top: 0;
            left: 0;
        }
    </style>
      <script src="JS/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery.colorbox.js" type="text/javascript"></script>
    <%--   <link href="../css/colour.css" rel="stylesheet" type="text/css" />--%>
    <link href="Css/pop_up.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
                                   $(document).ready(function () {
                                       //Examples of how to assign the ColorBox event to elements
                                       //        $(".iframe").colorbox({iframe:true, width: "auto", height: "auto"});
                                       $(".request").colorbox({ inline: true, width: "auto" });

                                       $(".callbacks").colorbox({
                                           onOpen: function () { alert('onOpen: colorbox is about to open'); },
                                           onLoad: function () { alert('onLoad: colorbox has started to load the targeted content'); },
                                           onComplete: function () { alert('onComplete: colorbox has displayed the loaded content'); },
                                           onCleanup: function () { alert('onCleanup: colorbox has begun the close process'); },
                                           onClosed: function () { alert('onClosed: colorbox has completely closed'); }
                                       });

                                     

                                       //Example of preserving a JavaScript event for inline calls.
                                       $("#click").click(function () {
                                           $('#click').css({ "background-color": "#f00", "color": "#fff", "cursor": "inherit" }).text("Open this window again and this message will still be here.");
                                           return false;
                                       });


                                   });



                                   //        function Salesorder(link, id) {
                                   //            $(link).colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 1 });
                                   //        }
                                   function Salesorder(id) {
                                       $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 1 });
                                   }
                                   function package(id) {
                                       $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 2 });

                                   }
                                   function TermCont(id) {
                                       $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 3 });

                                   }
                                   function DI(id,fromdate,todate) {
                                       $().colorbox({ iframe: true, width: "78%", height: "55%", href: "CDR_invoicerpt_sub1.aspx?groupid=" + id + "&fromdate=" + fromdate + "&todate=" + todate });

                                   }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
                            <td width="70%">
                                <table cellpadding="0" align="Left" cellspacing="0" width="50%" class="table-area">
                                    <tr>
                                        <td colspan="4" class="style1">
                                            <b>Head Section</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td>
                                            Country:<span class="redtext">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlcountry" runat="server" Width="150px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td>
                                            Networks:<span class="redtext">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlnetworks" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                         <td>
                                            Billing Month:<span class="redtext">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlyear" runat="server" Width="70px">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlmonth" runat="server" Width="75px">
                                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="February " Value="2"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                       <td></td>
                                       <td></td>
                                        <td>
                                            <asp:Button ID="btnSearch" Width="50px" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" Width="50px" runat="server" Text="Export" 
                                                OnClick="btnExport_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
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
                                <div style="width: 1350px; overflow: auto; float: left; overflow-x: scroll; overflow-y: hidden;">
                                    <asp:Repeater ID="RAFRepeater" runat="server" 
                                        OnItemDataBound="RAFRepeater_ItemDataBound" 
                                        onitemcommand="RAFRepeater_ItemCommand">
                                        <HeaderTemplate>
                                            <table border="1" cellpadding="0" cellspacing="0" class="table-area">
                                                <thead>
                                                    <tr id="thead">
                                                        <th align="center" style="width: 150px; text-align: center">
                                                        </th>
                                                        <th align="center" style="width: 150px; text-align: center">
                                                        </th>
                                                       

                                                        <th colspan="6" align="center">
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
                                                        <th colspan="5" align="center">
                                                            Revenue Lookup
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                    <td style="width: 150px; text-align: center">
                                                            <strong>Invoicing Month[A]</strong>
                                                        </td>
                                                         <td style="width: 150px; text-align: center">
                                                            <strong>Provider[B]</strong>
                                                        </td>
                                                        <%--<td style="width: 150px; text-align: center">
                                                            <strong>Country[A]</strong>
                                                        </td>--%>
                                                        
                                                       
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
                                                        <td>
                                                            <strong>GAP[E-G]</strong>
                                                        </td>
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
                                                        <td align="Right">
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
                                                        <%--<td align="Right">
                                                            <strong>Gross Rev(FX)</strong>
                                                        </td>--%>
                                                        <td id="tdgrossrevheader" runat="server"  align="Left" visible="false">
                                                            <strong>Gross Rev (INR)[T-R]</strong>
                                                        </td>
                                                     
                                                    </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                            <td>
                                                    <asp:Label ID="lblbillingmonth" runat="server" Text='<%#Eval("BillingMonth") %>' />
                                                    <asp:Label ID="lblbillmonth22" runat="server" Visible="false" Text='<%#Eval("billmon") %>' />
                                                </td>
                                                <td>
                                                    <%--<asp:Label ID="lblnetwork" runat="server" Text='<%#Eval("Network") %>' />--%>
                                                    <asp:LinkButton ID="lnkprovider" runat="server" Text='<%#Eval("Network") %>' CommandArgument='<%#Eval("providerid") %>'></asp:LinkButton>
                                                </td>
                                                <%--<td style="width: 120px; text-align: center">
                                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("countryname") %>' />
                                                </td>--%>
                                                
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
                                                <td id="tdlblgap" runat="server" align="Right">
                                                    <asp:Label ID="lblgap" runat="server" Text='<%#Eval("gap") %>' />
                                                </td>
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
                                                <td id ="tdlblrevinvoiceamount" runat="server" align="Right">
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
                                                <%--<td align="Right">
                                                    <asp:Label ID="lblgrossrevfx" runat="server" Text='<%#Eval("grossrevfx") %>' />
                                                </td>--%>
                                                <td id ="tdlblgrossrevinr" runat="server" visible="false" align="Right">
                                                    <asp:Label ID="lblgrossrevinr" runat="server" Text='<%#Eval("grosrevinr") %>' />
                                                </td>
                                                <%-- <td align="Right" style="background-color:#C5BE97;"><asp:Label ID="lblproloss" runat="server" Text='<%#Eval("proloss") %>' /></td>--%>
                                                <%--<td><asp:Label ID="Label22" runat="server" Text='<%#Eval("currency") %>' /></td>
                                        <td><asp:Label ID="Label23" runat="server" Text='<%#Eval("currency") %>' /></td>
                                        <td><asp:Label ID="Label24" runat="server" Text='<%#Eval("currency") %>' /></td>--%>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <%--Retailer--%>
                                                <%--Wholesaler--%>
                                                <%--Total--%>
                                                <%--Invoice--%>
                                                <td colspan="2" align="center">
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
                                                <td align="Right">
                                                    <asp:Label ID="lblgaptot" runat="server" Font-Bold="true" />
                                                </td>
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
                                                <td align="Right">
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
                                               <%-- <td align="Right">
                                                    <asp:Label ID="lblgrossrevfxtot" runat="server" Font-Bold="true" />
                                                </td>--%>
                                                <td id ="tdlblgrossrevINRtot" runat="server" align="Right" visible="false">
                                                    <asp:Label ID="lblgrossrevINRtot" runat="server" Font-Bold="true" />
                                                </td>
                                                <%--<td align="Right"><asp:Label ID="lblfixedtot" runat="server" Font-Bold="true" /></td>
                                        <td align="Right"><asp:Label ID="lblinvoiceAmounttot" runat="server" Font-Bold="true" /></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td align="Right"><asp:Label ID="lblTotalINRtot" runat="server"  Font-Bold="true"/></td>
                                        <td align="Right"><asp:Label ID="lblprolosstot" runat="server"  Font-Bold="true"/></td>--%>
                                            </tr>
                                            </thead> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
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
</asp:Content>
