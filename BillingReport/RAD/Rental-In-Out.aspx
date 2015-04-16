<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"CodeFile="Rental-In-Out.aspx.cs"Inherits="Rental_In_Out" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        body
        {
            overflow: auto !important;
        }
        .style1
        {
            height: 18px;
        }
        
        .ajax__calendar
        {
            width: 220px !important;
            height: auto;
        }
        .ajax__calendar_container
        {
            padding: 4px;
            position: absolute;
            cursor: default;
            width: 250px;
            font-size: 11px;
            text-align: center;
            font-family: tahoma,verdana,helvetica;
        }
        .ajax__calendar_body
        {
            height: 139px;
            width: 220px !important;
            position: relative;
            overflow: hidden;
            margin: auto;
        }
        .ajax__calendar_days, .ajax__calendar_months, .ajax__calendar_years
        {
            top: 0px;
            left: 0px;
            height: 139px;
            width: 170px;
            position: absolute;
            text-align: center;
            margin: auto;
        }
        .ajax__calendar_container TABLE
        {
            font-size: 11px;
        }
        .ajax__calendar_header
        {
            height: 20px;
            width: 100%;
        }
        .ajax__calendar_prev
        {
            cursor: pointer;
            width: 15px;
            height: 15px;
            float: left;
            background-repeat: no-repeat;
            background-position: 50% 50%;
            background-image: url(WebResource.axd?d=R2_NzACyuyjg_96YAcso_XY7m58_8iEvVtHBs40UHPFZnB3S7aFLcxsAkIGbzn2G38odYCBcWPHCgwruhkJfpRmGlAAS5Nl_DrFHkP0v5Uu4UdMUzJ5d9EZzI2CeS3ELspn9RW41rGnKF53HDtiXiUKcjOMLWp4VklKS1__32lI1&t=634644038320000000);
        }
        .ajax__calendar_next
        {
            cursor: pointer;
            width: 15px;
            height: 15px;
            float: right;
            background-repeat: no-repeat;
            background-position: 50% 50%;
            background-image: url(WebResource.axd?d=EXxZJDEXVbTudUzE-E2Ue4_Dn9W-DwMPV9eBigcfl-Y9OQ7NTQwVdDytVJIp1bhlpuAL8jVtVLWioTI3h5I3fpSj3ADYME65jOMpy5g6miBMgmJ9t5-pXJaEn4g5w1Cf6OkKeTvB6CQp7DbzODOCg0vwFsdzhdxnTNKR6nJud3c1&t=634644038320000000);
        }
        .ajax__calendar_title
        {
            cursor: pointer;
            font-weight: bold;
        }
        .ajax__calendar_footer
        {
            height: 15px;
        }
        .ajax__calendar_today
        {
            cursor: pointer;
            padding-top: 3px;
        }
        .ajax__calendar_dayname
        {
            height: 17px;
            width: 17px;
            text-align: right;
            padding: 0 2px;
        }
        .ajax__calendar_day
        {
            height: 17px;
            width: 18px;
            text-align: right;
            padding: 0 2px;
            cursor: pointer;
        }
        .ajax__calendar_month
        {
            height: 44px;
            width: 40px;
            text-align: center;
            cursor: pointer;
            overflow: hidden;
        }
        .ajax__calendar_year
        {
            height: 44px;
            width: 40px;
            text-align: center;
            cursor: pointer;
            overflow: hidden;
        }
        
        .ajax__calendar .ajax__calendar_container
        {
            border: 1px solid #646464;
            background-color: #ffffff;
            color: #000000;
            width: 220px;
        }
        .ajax__calendar .ajax__calendar_footer
        {
            border-top: 1px solid #f5f5f5;
        }
        .ajax__calendar .ajax__calendar_dayname
        {
            border-bottom: 1px solid #f5f5f5;
        }
        .ajax__calendar .ajax__calendar_day
        {
            border: 1px solid #ffffff;
        }
        .ajax__calendar .ajax__calendar_month
        {
            border: 1px solid #ffffff;
        }
        .ajax__calendar .ajax__calendar_year
        {
            border: 1px solid #ffffff;
        }
        
        .ajax__calendar .ajax__calendar_active .ajax__calendar_day
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_active .ajax__calendar_month
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_active .ajax__calendar_year
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_other .ajax__calendar_day
        {
            background-color: #ffffff;
            border-color: #ffffff;
            color: #646464;
        }
        .ajax__calendar .ajax__calendar_other .ajax__calendar_year
        {
            background-color: #ffffff;
            border-color: #ffffff;
            color: #646464;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_day
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_month
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_year
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_title
        {
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_today
        {
            color: #0066cc;
        }
        .ajax__calendar .ajax__calendar_footer
        {
            border-top: 1px solid #f5f5f5;
            width: 220px;
        }
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0px" width="100%">
        <tr>
            <td>
                <table cellpadding="0" align="left" cellspacing="0" width="50%" class="table-area">
                    <tr>
                        <td>
                            <h1>
                                <b>Rental In Out</b></h1>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" align="left" cellspacing="0" width="50%" class="table-area">
                    <tr>
                        <td colspan="4" class="style1">
                            <b>Head Section</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Networks:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlnetworks" Width="150px" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Billing Month:
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
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" Width="50px" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="middle">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" align="left" cellspacing="0" class="table-area">
                    <tr>
                        <td>
                            <div>
                                <asp:Repeater ID="RentalRepeater" runat="server" 
                                    OnItemDataBound="RentalRepeater_ItemDataBound" 
                                    onitemcommand="RentalRepeater_ItemCommand">
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
                                                <asp:LinkButton ID="lnkprovider" runat="server" Text='<%#Eval("Network") %>' CommandArgument='<%#Eval("providerid") %>'
                                                    CommandName="groupname">
                                                </asp:LinkButton>
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
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
