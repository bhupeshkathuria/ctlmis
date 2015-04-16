<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sub_Rpt_RentalInOut.aspx.cs" Inherits="Sub_Rpt_RentalInOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Revenue Audit</title>
    <link href="Css/Main.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery.min.js" type="text/javascript"></script>
    <script src="JS/site.js" type="text/javascript"></script>
    <link href="Css/pop_up.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="gridviewScroll.min.js"></script>
    <link href="GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function pageLoad() {
            document.body.style.overflow = "hidden";

            $('#GridView1').gridviewScroll({
                width: 1230,
                height: 500,
                freezesize: 3
            });
        }

    </script>
    <style>
    .table-area{ width:780px; height:auto; margin:15px auto;}
.table-area table{ width:100%; height:auto; border:1px solid #e6e6e6; text-align:left; line-height:18px;border-collapse:collapse;}
.table-area th{ background:url(../images/rpt1.jpg) repeat-x; color:#666; font:bold 11px Verdana; height:20px;}
.table-area td{ background:#fbfbfb; height:20px; padding-left:10px; border:1px solid #e1e1e1; border-collapse:collapse; font:normal 11px Verdana; color:#6c6c6c; padding:0px 0 0px 5px;}
.table-area td input{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; }
.table-area td textarea{ font:normal 11px Verdana; color:#6c6c6c; height:60px !important; width:250px; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; margin:5px 0 }
.table-area td select{ font:normal 11px Verdana; color:#6c6c6c; height:24px !important; padding:2px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px 0 0 4px; background:url(../images/patt.jpg) repeat; }

.table-area td input[type="checkbox"]{ font:normal 11px Verdana; color:#6c6c6c; height:15px !important; width:15px; border:1px solid #d3d3d3; margin-top:10px;}
.table-area .g-btn{ width:60px !important; height:24px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area table a{ font:normal 11px Verdana; text-decoration:none; color:#FF0000;}
.table-area table a:hover{ font:normal 11px Verdana; text-decoration:underline; color:#FF0000;}
.table-area td table{ border:none;}
.tbl-grd { border:1px solid #ccc;}
.tbl-grd table{ border:1px solid #ccc;}
.tbl-grd th{ border:none; background:#ebebeb}
.tbl-grd td{ border:none; border-top:1px solid #ccc; background:#f3f3f3}
.redtext{color:#ff0000 !important;}
    </style>
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
        <table cellpadding="0" cellspacing="0" border="0px" width="100%" align="center" class="table-area">
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
                             
                                </td>
                                <td>
                                
                                       <asp:Repeater ID="RentalRepeater" runat="server" OnItemDataBound="RentalRepeater_ItemDataBound">
                                    <HeaderTemplate>
                                        <table border="1" id="GridView1" cellpadding="1px" cellspacing="1px" style="border-collapse: collapse;">
                                            <tbody>
                                                <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                                    <td align="center">
                                                        Invoicing Month
                                                    </td>
                                                    <td align="center">
                                                        Provider
                                                    </td>
                                                     <td align="center">
                                                        Country
                                                    </td>
                                                    <td align="right">
                                                        Inv.Amount
                                                    </td>
                                                    <td align="right">
                                                        Rental
                                                    </td>
                                                    <td align="right">
                                                        Vas Rental
                                                    </td>
                                                    <td align="right">
                                                        Total Rental
                                                    </td>
                                                    <td align="right">
                                                        Inv.FX
                                                    </td>
                                                    <td align="right">
                                                        Total Rental INR
                                                    </td>
                                                    <td align="right">
                                                        Retail Out INR
                                                    </td>
                                                    <td align="right">
                                                        Whs Out INR
                                                    </td>
                                                    <td align="right">
                                                        Retail Fx
                                                    </td>
                                                    <td align="right">
                                                        Total Out
                                                    </td>
                                                    <td align="right">
                                                        Difference
                                                    </td>
                                                </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr id="drow" runat="server" class="GridviewScrollItem">
                                            <td align="left">
                                                <asp:Label ID="lblbillingmonth" runat="server" Text='<%#Eval("BillingMonth") %>' />
                                                <asp:Label ID="lblbillmonth22" runat="server" Visible="false" Text='<%#Eval("billmon") %>' />
                                            </td>
                                            <td align="left">
                                                <%--<asp:LinkButton ID="lnkprovider" runat="server" Text='<%#Eval("Network") %>' CommandArgument='<%#Eval("providerid") %>'
                                                    CommandName="groupname">
                                                </asp:LinkButton>--%>
                                                <asp:Label ID="lblnetwork" runat="server" Text='<%#Eval("Network") %>' />
                                            </td>
                                             <td style="width: 120px; text-align: center">
                                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("countryname") %>' />
                                                </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvoiceamount" runat="server" Text='<%#Eval("invoiceamount") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvrental" runat="server" Text='<%#Eval("invoicerental") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvvasrental" runat="server" Text='<%#Eval("invoicevasrental") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvtotalrental" runat="server" Text='<%#Eval("totalinvRental") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvfx" runat="server" Text='<%#Eval("invfx") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblinvrentalinr" runat="server" Text='<%#Eval("invTotalRentalINR") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblretoutrentalinr" runat="server" Text='<%#Eval("ret_outchargeRental_inr") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblwhsoutrentalinr" runat="server" Text='<%#Eval("Whole_outchargeRentalinr") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblretailfx" runat="server" Text='<%#Eval("fx") %>' />
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lbltotaloutrentalinr" runat="server" Text='<%#Eval("TotalOutchargeRental") %>' />
                                            </td>
                                            <td id="tdlblgap" runat="server" align="right">
                                                <asp:Label ID="lbldifference" runat="server" Text='<%#Eval("Difference") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr>
                                            <td  align="center">
                                                <asp:Label ID="lblgrandtot" runat="server" Text="Grand Total" Font-Bold="true" />
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td align="Right">
                                                <asp:Label ID="lblinvoiceamounttot" runat="server" Font-Bold="true" />
                                            </td>
                                            <td align="Right">
                                                <asp:Label ID="lblinvrentaltot" runat="server" Font-Bold="true" />
                                            </td>
                                            <td align="Right">
                                                <asp:Label ID="lblinvvasrentaltot" runat="server" Font-Bold="true" />
                                            </td>
                                            <td  align="Right">
                                                <asp:Label ID="lblinvtotalrentaltot" runat="server" Font-Bold="true" />
                                            </td>
                                             <td align="Right">
                                                
                                            </td>
                                              <td  align="Right">
                                                <asp:Label ID="lblinvrentalinrtot" runat="server" Font-Bold="true" />
                                            </td>
                                            <td align="Right">
                                                <asp:Label ID="lblretoutrentalinrtot" runat="server" Font-Bold="true" />
                                            </td>
                                           
                                            <td align="Right">
                                                <asp:Label ID="lblwhsoutrentalinrtot" runat="server" Font-Bold="true" />
                                            </td>
                                             <td align="Right">
                                               
                                            </td>
                                             <td align="Right">
                                                <asp:Label ID="lbltotaloutrentalinrtot" runat="server" Font-Bold="true" />
                                            </td>
                                             <td align="Right">
                                               <%-- <asp:Label ID="lbldifferencetot" runat="server" Font-Bold="true" />--%>
                                            </td>
                                        </tr>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>                     
                       
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
