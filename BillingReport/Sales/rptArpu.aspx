<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rptArpu.aspx.cs" Inherits="Sales_rptArpu" %>

<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=ddlYear.ClientID%>').selectedIndex == 0) {
                alert("Please select year!!");
                return false;

            }

            return true;
        }

    </script>
    <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../JS/MultipleSelectionDDLCSS.css" />
    <script type="text/javascript" src="../JS/MultipleSelectionDDLJS.js"></script>
    <asp:UpdatePanel ID="updPnl1" runat="server">
        <ContentTemplate>
            <div style="width: 100%; padding-top: 5px;">
                <asp:Label ID="lblMsg"  runat="server" ForeColor="Red"></asp:Label>
                <b>
                    <%--    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlYear"
                        ErrorMessage="Select Year" Operator="NotEqual" ValueToCompare="--" Display="None"></asp:CompareValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlMonth"
                        ErrorMessage="Select Month" Operator="NotEqual" ValueToCompare="--" Display="None"></asp:CompareValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />--%>
                </b>
                <table cellpadding="3" cellspacing="0" style="border: 1px solid Black; width: 70%;">
                    <tr>
                        <td>
                            Select Year:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
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
                                    <cc2:CheckBoxListExCtrl ID="CheckBoxListExCtrl1" CssClass="regularText" 
                                        runat="server" >
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
                                    </cc2:CheckBoxListExCtrl>
                                </asp:Panel>
                            </div>
                            <div id="ie6SelectTooltip" style="display: none; position: absolute; padding: 1px;
                                border: 1px solid #333333; background-color: #fffedf; font-size: smaller;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Select Criteria:<span style="color: Red"></span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRepType" runat="server" ValidationGroup="Report" AutoPostBack="true"
                                Width="135px" OnSelectedIndexChanged="ddlRepType_SelectedIndexChanged">
                                <asp:ListItem Text="--Select All--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="By Country" Value="1">By Country</asp:ListItem>
                                <asp:ListItem Text="By Branch" Value="2">By Branch</asp:ListItem>
                               <%-- <asp:ListItem Text="By Employee" Value="3"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <br />
                            
                           <%-- <asp:DropDownList ID="ddlcommon" runat="server" Width="135px" Visible="false">
                            </asp:DropDownList>--%>
                            <div style="width: 130px; height: 100px; padding: 2px; overflow: auto; border: 1px solid #ccc;" id="divitem" runat="server" visible="false">
                                <asp:CheckBoxList class="BodyTxt" ID="chkmultiple" runat="server" Visible="false">
                                    
                                </asp:CheckBoxList>
                            </div>
                        </td>
                        <td colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdFind" runat="server" Text="Search" OnClick="cmdFind_Click"
                                OnClientClick="return JSFunctionValidate()" />&nbsp;&nbsp;<asp:Button ID="cmdExport"
                                    runat="server" Text="Export to Excel" OnClick="cmdExport_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMonth" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table cellpadding="3" cellspacing="0" style="border: 1px solid Black; width: 70%;">
                    <tr>
                        <td align="center">
                            <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="true"
                                AllowSorting="True" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                                RowStyle-Font-Names="Arial" FooterStyle-ForeColor="ActiveCaption" FooterStyle-Font-Bold="true"
                                HorizontalAlign="Center" OnSorting="grdview1_Sorting">
                                <%--<Columns>
                            <asp:BoundField HeaderText="Total Sale" DataField="totalsale1"  >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                            
                            <asp:TemplateField HeaderText="Total Billing">
                                <ItemTemplate>
                                <asp:Label ID="lblTotalBilling" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ARPU">
                                <ItemTemplate>
                                    <asp:Label ID="lblARPU" runat="server"></asp:Label>
                                    <asp:Label ID="lblsale" runat="server" Visible="false" Text='<%#Eval("totalsale1") %>'></asp:Label>
                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>                            
                        </Columns>--%>
                                <AlternatingRowStyle HorizontalAlign="Center" />
                                <EditRowStyle HorizontalAlign="Center" />
                                <FooterStyle Font-Bold="True" ForeColor="ActiveCaption"></FooterStyle>
                                <HeaderStyle HorizontalAlign="Center" />
                                <PagerSettings Position="Top" />
                                <RowStyle CssClass="text_box" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
