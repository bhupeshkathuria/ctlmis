<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmSaleBillingLeadReport.aspx.cs" Inherits="MISReport_frmSaleBillingLeadReport" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                height: 350,
                freezesize: 4
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="overflow-y: auto !important">
        <%--<asp:ScriptManager ID="df" runat="server">
        </asp:ScriptManager>--%>
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
                <div style="width: 100%; padding: 0px 0px 0px 0px;">
                    <table width="100%" cellpadding="5px" cellspacing="0">
                        <tr>
                            <td class="Header_text" align="left">
                                &nbsp;&nbsp;Sale Billing Report CST/SME
                            </td>
                            <td class="Header_text" align="right">
                                <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 50px">
                                <table cellpadding="3px" cellspacing="1px" width="100%">
                                    <tr>
                                        <td>
                                            <strong>From Year</strong>
                                        </td>
                                        <td align="left" style="height: 15px; color: Green">
                                            <asp:DropDownList ID="ddlFromYear" Width="70px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <strong>To Year</strong>
                                        </td>
                                        <td align="left" style="height: 15px; color: Green">
                                            <asp:DropDownList ID="ddlToYear" Width="70px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Report For:
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdovalue" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Both</asp:ListItem>
                                                <asp:ListItem Value="2">SME</asp:ListItem>
                                                <asp:ListItem Value="2">CST</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rbaffiliate" Text="Affiliate" runat="server" GroupName="lead"
                                                Checked="true" />
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rbacct" Text="Account Manager Wise" runat="server" GroupName="lead" />
                                        </td>
                                        <%--<td>
                                            Branch
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlBranch" runat="server" Height="200px" Width="150px" EmptyMessage="Select Branch"
                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                AllowCustomText="true" AutoCompleteSeparator=";">
                                            </telerik:RadComboBox>
                                        </td>
                                         <td>
                                        Category:</td>

                                        <td>
                                        <telerik:RadComboBox ID="ddlCategory" runat="server" Height="200px" Width="180px"
                                                EmptyMessage="Select Category" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                MarkFirstMatch="true" AllowCustomText="true" AutoCompleteSeparator=";" 
                                                AutoPostBack="True" onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                                            </telerik:RadComboBox>
                                        </td>

                                        <td>
                                            Manager:
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlManager" runat="server" Height="200px" Width="180px"
                                                EmptyMessage="Select Manager" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                MarkFirstMatch="true" AllowCustomText="true" AutoCompleteSeparator=";">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdovalue" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Top</asp:ListItem>
                                                <asp:ListItem Value="2">Bottom</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlvalue" runat="server">
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                <asp:ListItem Value="25">25</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdosalebill" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Sale</asp:ListItem>
                                                <asp:ListItem Value="2">Billing</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>--%>
                                        <td align="left" style="font-weight: normal;" colspan="4">
                                            <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
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
                                            Apr Prepaid
                                        </td>
                                        <td align="center">
                                            May Sale
                                        </td>
                                        <td align="center">
                                            May Billing
                                        </td>
                                        <td align="center">
                                            May Prepaid
                                        </td>
                                        <td align="center">
                                            Jun Sale
                                        </td>
                                        <td align="center">
                                            Jun Billing
                                        </td>
                                        <td align="center">
                                            Jun Prepaid
                                        </td>
                                        <td align="center">
                                            Jul Sale
                                        </td>
                                        <td align="center">
                                            Jul Billing
                                        </td>
                                        <td align="center">
                                            Jul Prepaid
                                        </td>
                                        <td align="center">
                                            Aug Sale
                                        </td>
                                        <td align="center">
                                            Aug Billing
                                        </td>
                                        <td align="center">
                                            Aug Prepaid
                                        </td>
                                        <td align="center">
                                            Sep Sale
                                        </td>
                                        <td align="center">
                                            Sep Billing
                                        </td>
                                        <td align="center">
                                            Sep Prepaid
                                        </td>
                                        <td align="center">
                                            Oct Sale
                                        </td>
                                        <td align="center">
                                            Oct Billing
                                        </td>
                                        <td align="center">
                                            Oct Prepaid
                                        </td>
                                        <td align="center">
                                            Nov Sale
                                        </td>
                                        <td align="center">
                                            Nov Billing
                                        </td>
                                        <td align="center">
                                            Nov Prepaid
                                        </td>
                                        <td align="center">
                                            Dec Sale
                                        </td>
                                        <td align="center">
                                            Dec Billing
                                        </td>
                                        <td align="center">
                                            Dec Prepaid
                                        </td>
                                        <td align="center">
                                            Jan Sale
                                        </td>
                                        <td align="center">
                                            Jan Billing
                                        </td>
                                        <td align="center">
                                            Jan Prepaid
                                        </td>
                                        <td align="center">
                                            Feb Sale
                                        </td>
                                        <td align="center">
                                            Feb Billing
                                        </td>
                                        <td align="center">
                                            Feb Prepaid
                                        </td>
                                        <td align="center">
                                            Mar Sale
                                        </td>
                                        <td align="center">
                                            Mar Billing
                                        </td>
                                        <td align="center">
                                            Mar Prepaid
                                        </td>
                                        <td align="center">
                                            Sale Grand Total
                                        </td>
                                        <td align="center">
                                            Revenue Grand Total
                                        </td>
                                        <td align="center">
                                            Prepaid Grand Total
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
                                <td align="right">
                                    <asp:Label ID="lblaprilbilling" runat="server" Text='<%#Eval("aprbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblaprPrepaid" runat="server" Text='<%#Eval("aprprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmaysale" runat="server" Text='<%#Eval("maysale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmaybilling" runat="server" Text='<%#Eval("maybilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmayprepaid" runat="server" Text='<%#Eval("mayprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljunesale" runat="server" Text='<%#Eval("junsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljunebilling" runat="server" Text='<%#Eval("junbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljuneprepaid" runat="server" Text='<%#Eval("junprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljulysale" runat="server" Text='<%#Eval("julsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljulybilling" runat="server" Text='<%#Eval("julbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljulyprepaid" runat="server" Text='<%#Eval("julprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblaugsale" runat="server" Text='<%#Eval("augsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblaugbilling" runat="server" Text='<%#Eval("augbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblaugprepaid" runat="server" Text='<%#Eval("augprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblseptsale" runat="server" Text='<%#Eval("sepsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblseptbilling" runat="server" Text='<%#Eval("sepbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblseptprepaid" runat="server" Text='<%#Eval("sepprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbloctsale" runat="server" Text='<%#Eval("octsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbloctbilling" runat="server" Text='<%#Eval("octbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbloctprepaid" runat="server" Text='<%#Eval("octprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblnovsale" runat="server" Text='<%#Eval("novsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblnovbilling" runat="server" Text='<%#Eval("novbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblnovprepaid" runat="server" Text='<%#Eval("novprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbldecsale" runat="server" Text='<%#Eval("decsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbldecbilling" runat="server" Text='<%#Eval("decbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbldecprepaid" runat="server" Text='<%#Eval("decprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljansale" runat="server" Text='<%#Eval("jansale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljanbilling" runat="server" Text='<%#Eval("janbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbljanprepaid" runat="server" Text='<%#Eval("janprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfebsale" runat="server" Text='<%#Eval("febsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfebbilling" runat="server" Text='<%#Eval("febbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfebprepaid" runat="server" Text='<%#Eval("febprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmarsale" runat="server" Text='<%#Eval("marsale") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmarbilling" runat="server" Text='<%#Eval("marbilling") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblmarprepaid" runat="server" Text='<%#Eval("marprepaid") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblsaletotal" runat="server" Text='<%#Eval("saletotal") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblbillingtotal" runat="server" Text='<%#Eval("billingtotal") %>' />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblprepaidtotal" runat="server" Text='<%#Eval("prepaidtotal") %>' />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
