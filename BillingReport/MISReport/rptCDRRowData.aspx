<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rptCDRRowData.aspx.cs" Inherits="MISReport_rptCDRRowData" %>

<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../JS/MultipleSelectionDDLCSS.css" />--%>
    <script type="text/javascript" src="../JS/MultipleSelectionDDLJS.js"></script>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
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
                freezesize: 3
            });

            $('#GridView2').gridviewScroll({
                width: 1300,
                height: 200,
                freezesize: 3
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="updatePnl"
        style="width: 100%;">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 15%; left: 45%; text-align: center;">
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
                            &nbsp;&nbsp;CDR Data
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="3px" cellspacing="1px">
                                <tr>
                                    <td>
                                        <b>Year</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlFromYear" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <b>Month</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlFromMonth" runat="server" Width="150px">
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
                                    <td>
                                        <b>Comparison To Year</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlYearTo" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <b>Comparison To Month</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlMonthTo" runat="server" Width="150px">
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
                                        <b>Provider</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlProvider" runat="server" Width="150px" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlProvider_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <b>Call Type</b>
                                    </td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlCallType" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="font-weight: normal;">
                                        <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="4">
                                        <div>
                                            <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="MultiSelectDDL"
                                                PopupControlID="PanelPopUp" PopupPosition="bottom" OffsetX="6" PopDelay="25"
                                                HoverCssClass="popupHover">
                                            </cc1:HoverMenuExtender>
                                            <asp:DropDownList ID="MultiSelectDDL" TabIndex="0" CssClass="ddlMenu regularText"
                                                runat="server">
                                                <asp:ListItem Value="all">All</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hf_checkBoxValue" runat="server" />
                                            <asp:HiddenField ID="hf_checkBoxText" runat="server" />
                                            <asp:HiddenField ID="hf_checkBoxSelIndex" runat="server" />
                                            <asp:Panel ID="PanelPopUp" CssClass="popupMenu" runat="server">
                                                <cc2:CheckBoxListExCtrl ID="CheckBoxListExCtrl1" CssClass="regularText" runat="server">
                                                </cc2:CheckBoxListExCtrl>
                                            </asp:Panel>
                                        </div>
                                        <div id="ie6SelectTooltip" style="display: none; position: absolute; padding: 1px;
                                            border: 1px solid #333333; background-color: #fffedf; font-size: smaller;">
                                        </div>
                                    </td>
                                </tr>--%>
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
            <div>
                <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound">
                    <HeaderTemplate>
                        <table border="1" id="GridView1" cellpadding="1px" cellspacing="1px" style="border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                    <td align="center">
                                        Year-Month
                                    </td>
                                    <td align="center">
                                        Provider
                                    </td>
                                    <td align="center">
                                        Call Type
                                    </td>
                                    <td align="center">
                                        1
                                    </td>
                                    <td align="center">
                                        2
                                    </td>
                                    <td align="center">
                                        3
                                    </td>
                                    <td align="center">
                                        4
                                    </td>
                                    <td align="center">
                                        5
                                    </td>
                                    <td align="center">
                                        6
                                    </td>
                                    <td align="center">
                                        7
                                    </td>
                                    <td align="center">
                                        8
                                    </td>
                                    <td align="center">
                                        9
                                    </td>
                                    <td align="center">
                                        10
                                    </td>
                                    <td align="center">
                                        11
                                    </td>
                                    <td align="center">
                                        12
                                    </td>
                                    <td align="center">
                                        13
                                    </td>
                                    <td align="center">
                                        14
                                    </td>
                                    <td align="center">
                                        15
                                    </td>
                                    <td align="center">
                                        16
                                    </td>
                                    <td align="center">
                                        17
                                    </td>
                                    <td align="center">
                                        18
                                    </td>
                                    <td align="center">
                                        19
                                    </td>
                                    <td align="center">
                                        20
                                    </td>
                                    <td align="center">
                                        21
                                    </td>
                                    <td align="center">
                                        22
                                    </td>
                                    <td align="center">
                                        23
                                    </td>
                                    <td align="center">
                                        24
                                    </td>
                                    <td align="center">
                                        25
                                    </td>
                                    <td align="center">
                                        26
                                    </td>
                                    <td align="center">
                                        27
                                    </td>
                                    <td align="center">
                                        28
                                    </td>
                                    <td align="center">
                                        29
                                    </td>
                                    <td align="center">
                                        30
                                    </td>
                                    <td align="center">
                                        31
                                    </td>
                                    <td align="center">
                                        Total
                                    </td>
                                    <td align="center">
                                        Billing Total
                                    </td>
                                    <td align="center">
                                        Difference
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="drow" runat="server" class="GridviewScrollItem">
                            <td align="left">
                                <asp:Label ID="lblYearMonth" runat="server" Text='<%#Eval("CallDate") %>' />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblprovider" runat="server" Text='<%#Eval("Provider") %>' />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcalltype" runat="server" Text='<%#Eval("calltypename") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls1" runat="server" Text='<%#Eval("s1") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls2" runat="server" Text='<%#Eval("s2") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls3" runat="server" Text='<%#Eval("s3") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls4" runat="server" Text='<%#Eval("s4") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls5" runat="server" Text='<%#Eval("s5") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls6" runat="server" Text='<%#Eval("s6") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls7" runat="server" Text='<%#Eval("s7") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls8" runat="server" Text='<%#Eval("s8") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls9" runat="server" Text='<%#Eval("s9") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls10" runat="server" Text='<%#Eval("s10") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls11" runat="server" Text='<%#Eval("s11") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls12" runat="server" Text='<%#Eval("s12") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls13" runat="server" Text='<%#Eval("s13") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls14" runat="server" Text='<%#Eval("s14") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls15" runat="server" Text='<%#Eval("s15") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls16" runat="server" Text='<%#Eval("s16") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls17" runat="server" Text='<%#Eval("s17") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls18" runat="server" Text='<%#Eval("s18") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls19" runat="server" Text='<%#Eval("s19") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls20" runat="server" Text='<%#Eval("s20") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls21" runat="server" Text='<%#Eval("s21") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls22" runat="server" Text='<%#Eval("s22") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls23" runat="server" Text='<%#Eval("s23") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls24" runat="server" Text='<%#Eval("s24") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls25" runat="server" Text='<%#Eval("s25") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls26" runat="server" Text='<%#Eval("s26") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls27" runat="server" Text='<%#Eval("s27") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls28" runat="server" Text='<%#Eval("s28") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls29" runat="server" Text='<%#Eval("s29") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls30" runat="server" Text='<%#Eval("s30") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls31" runat="server" Text='<%#Eval("s31") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbltotal" runat="server" Text='<%#Eval("stotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("stotalbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDifference" runat="server" Text='<%#Eval("sdifference") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr id="drow" runat="server" class="GridviewScrollItem">
                            <td align="left">
                                <asp:Label ID="lblYearMonthfooter" runat="server" Text="" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblproviderfooter" runat="server" Text="" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcalltypefooter" runat="server" Text="Total"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls1footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls2footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls3footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls4footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls5footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls6footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls7footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls8footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls9footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls10footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls11footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls12footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls13footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls14footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls15footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls16footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls17footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls18footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls19footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls20footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls21footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls22footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls23footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls24footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls25footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls26footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls27footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls28footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls29footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls30footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls31footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbltotalfooter" runat="server"  />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotalfooter" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDifferencefooter" runat="server" />
                            </td>
                        </tr>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label ID="lbltop" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </div>
            <div>
                <asp:Repeater ID="rptSecond" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
                    <HeaderTemplate>
                        <table border="1" id="GridView2" cellpadding="1px" cellspacing="1px" style="border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: Gray; color: White;" class="GridviewScrollHeader">
                                    <td align="center">
                                        Year-Month
                                    </td>
                                    <td align="center">
                                        Provider
                                    </td>
                                    <td align="center">
                                        Call Type
                                    </td>
                                    <td align="center">
                                        1
                                    </td>
                                    <td align="center">
                                        2
                                    </td>
                                    <td align="center">
                                        3
                                    </td>
                                    <td align="center">
                                        4
                                    </td>
                                    <td align="center">
                                        5
                                    </td>
                                    <td align="center">
                                        6
                                    </td>
                                    <td align="center">
                                        7
                                    </td>
                                    <td align="center">
                                        8
                                    </td>
                                    <td align="center">
                                        9
                                    </td>
                                    <td align="center">
                                        10
                                    </td>
                                    <td align="center">
                                        11
                                    </td>
                                    <td align="center">
                                        12
                                    </td>
                                    <td align="center">
                                        13
                                    </td>
                                    <td align="center">
                                        14
                                    </td>
                                    <td align="center">
                                        15
                                    </td>
                                    <td align="center">
                                        16
                                    </td>
                                    <td align="center">
                                        17
                                    </td>
                                    <td align="center">
                                        18
                                    </td>
                                    <td align="center">
                                        19
                                    </td>
                                    <td align="center">
                                        20
                                    </td>
                                    <td align="center">
                                        21
                                    </td>
                                    <td align="center">
                                        22
                                    </td>
                                    <td align="center">
                                        23
                                    </td>
                                    <td align="center">
                                        24
                                    </td>
                                    <td align="center">
                                        25
                                    </td>
                                    <td align="center">
                                        26
                                    </td>
                                    <td align="center">
                                        27
                                    </td>
                                    <td align="center">
                                        28
                                    </td>
                                    <td align="center">
                                        29
                                    </td>
                                    <td align="center">
                                        30
                                    </td>
                                    <td align="center">
                                        31
                                    </td>
                                    <td align="center">
                                        Total
                                    </td>
                                    <td align="center">
                                        Billing Total
                                    </td>
                                    <td align="center">
                                        Difference
                                    </td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="drow" runat="server" class="GridviewScrollItem">
                            <td align="left">
                                <asp:Label ID="lblYearMonth" runat="server" Text='<%#Eval("CallDate") %>' />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblprovider" runat="server" Text='<%#Eval("Provider") %>' />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcalltype" runat="server" Text='<%#Eval("calltypename") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls1" runat="server" Text='<%#Eval("s1") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls2" runat="server" Text='<%#Eval("s2") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls3" runat="server" Text='<%#Eval("s3") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls4" runat="server" Text='<%#Eval("s4") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls5" runat="server" Text='<%#Eval("s5") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls6" runat="server" Text='<%#Eval("s6") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls7" runat="server" Text='<%#Eval("s7") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls8" runat="server" Text='<%#Eval("s8") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls9" runat="server" Text='<%#Eval("s9") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls10" runat="server" Text='<%#Eval("s10") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls11" runat="server" Text='<%#Eval("s11") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls12" runat="server" Text='<%#Eval("s12") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls13" runat="server" Text='<%#Eval("s13") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls14" runat="server" Text='<%#Eval("s14") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls15" runat="server" Text='<%#Eval("s15") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls16" runat="server" Text='<%#Eval("s16") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls17" runat="server" Text='<%#Eval("s17") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls18" runat="server" Text='<%#Eval("s18") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls19" runat="server" Text='<%#Eval("s19") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls20" runat="server" Text='<%#Eval("s20") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls21" runat="server" Text='<%#Eval("s21") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls22" runat="server" Text='<%#Eval("s22") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls23" runat="server" Text='<%#Eval("s23") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls24" runat="server" Text='<%#Eval("s24") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls25" runat="server" Text='<%#Eval("s25") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls26" runat="server" Text='<%#Eval("s26") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls27" runat="server" Text='<%#Eval("s27") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls28" runat="server" Text='<%#Eval("s28") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls29" runat="server" Text='<%#Eval("s29") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls30" runat="server" Text='<%#Eval("s30") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls31" runat="server" Text='<%#Eval("s31") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbltotal" runat="server" Text='<%#Eval("stotal") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("stotalbilling") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDifference" runat="server" Text='<%#Eval("sdifference") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                       <tr id="drow" runat="server" class="GridviewScrollItem">
                            <td align="left">
                                <asp:Label ID="lblYearMonthfooter" runat="server" Text="" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblproviderfooter" runat="server" Text="" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcalltypefooter" runat="server" Text="Total"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls1footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls2footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls3footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls4footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls5footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls6footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls7footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls8footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls9footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls10footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls11footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls12footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls13footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls14footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls15footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls16footer" runat="server" />
                            </td>
                            <td align="right">
                               <asp:Label ID="lbls17footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls18footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls19footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls20footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls21footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls22footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls23footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls24footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls25footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls26footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls27footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls28footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls29footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls30footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbls31footer" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lbltotalfooter" runat="server"  />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblbillingtotalfooter" runat="server" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDifferencefooter" runat="server" />
                            </td>
                        </tr> </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label ID="lblSecond" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
