<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dailyrptifram.aspx.cs" Inherits="CreditControl_Dailyrptifram"  EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="UdpMain">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UdpMain" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imgexport" />
        </Triggers>
        <ContentTemplate>
    <div>
    <asp:HiddenField id ="hdadjuctmentamt" runat="server" />
    <div>
            <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
          <telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
        </telerik:RadFormDecorator>--%>

            <div style="width: 100%; padding: 0px 0px 0px 0px;font:11px verdana;"">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <%--<tr>
                        <td class="Header_text" colspan="3" align="left" style="width: 244px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>--%>
                    <tr>
               <td style="width: 987px">
                    
                    <%-- <fieldset style="width:500px;">--%>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr id="tr" runat="server">
                                <td width="80px">
                                  <b>  From Date: </b>
                                </td>
                                <td Width="110px">
                                    <asp:TextBox ID="txtfromdate" runat="server" Width="100px" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td><asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                        Format="yyyy-MM-dd" TargetControlID="txtfromdate" Enabled="false">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/CreditControl/cal.gif" AlternateText="Click to show calendar"
                                        Width="18" Height="18" ImageAlign="TextTop" Enabled="false"/>
                                </td>
                                <td width="70px">
                                   <b> To Date: </b>
                                </td>
                                <td Width="110px">
                                    <asp:TextBox ID="txttodate" runat="server" Width="100px" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td><asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton3"
                                        Format="yyyy-MM-dd" TargetControlID="txttodate" Enabled="false">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton runat="Server" ID="ImageButton3" ImageUrl="~/CreditControl/cal.gif" AlternateText="Click to show calendar"
                                        Width="18" Height="18" ImageAlign="TextTop" Enabled="false"/>
                                </td>
                                <td><asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnAddField_Click" Visible="false"/>
                                </td>
                                <td>
                                Export To Excel:   <asp:ImageButton ID="imgexport" Visible="false" runat="server" ImageUrl="~/CreditControl/xls-icon.gif" OnClick="imgexport_Click" />
                                </td>
                            </tr>
                         
                        </table>
                       <%-- </fieldset>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CompareValidator ID="cvtxtStartDate" runat="server" ControlToCompare="txtfromdate"
                                CultureInvariantValues="true" Display="Dynamic" EnableClientScript="true" ControlToValidate="txttodate"
                                ErrorMessage="Start date must be earlier than End date" Type="Date" SetFocusOnError="true"
                                Operator="GreaterThanEqual" Text="Start date must be earlier than End date"></asp:CompareValidator>
                                <asp:Label ID="lblInvoice" runat="server" ForeColor="red"></asp:Label>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    
                     <tr id="trAdjucement" runat="server" visible="false">
                        <td class="Header_text" colspan="3" align="left" style="width: 300px">
                            <fieldset>
                                <legend>Adjustment Summary :</legend>
                                <table cellpadding="0px" cellspacing="1px" border="0px" width="500px">
                                    <tr>
                                        <td>
                                            <b>Total Collection</b>
                                        </td>
                                        <td>
                                            <b>Adjusted Amount</b>
                                        </td>
                                        <td>
                                            <b>Un-adjusted Amount</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbltotalcollection" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lbltotalarjusted" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblunarjsustedamt" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>


                    <tr>
                        <td style="width: 397px" colspan="3" valign="top">
                            <asp:GridView ID="GridView1" Width="700px"  runat="server" 
                                AutoGenerateColumns="true" OnRowDataBound="GridView1_RowDataBound" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" ShowFooter="true"
                                onsorting="GridView1_Sorting">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <%--<Columns>
                                    <asp:TemplateField HeaderText="Branch"  HeaderStyle-ForeColor="white" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltext" runat="server" Text="Grand Total" Font-Bold="true"/>
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque"  HeaderStyle-ForeColor="white" SortExpression="ByCheque">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCheque" runat="server" Text='<%#Eval("ByCheque") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCheque" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cash"  HeaderStyle-ForeColor="white" SortExpression="ByCash">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCash" runat="server" Text='<%#Eval("ByCash") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalCash" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Card"  HeaderStyle-ForeColor="white"  SortExpression="ByCreditCard">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByCreditCard" runat="server" Text='<%#Eval("ByCreditCard") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalcredit" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank"  HeaderStyle-ForeColor="white"  SortExpression="ByBank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByBank" runat="server" Text='<%#Eval("ByBank") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalbank" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Online"  HeaderStyle-ForeColor="white"  SortExpression="ByOnline">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByOnline" runat="server" Text='<%#Eval("ByOnline") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalonline" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total"  HeaderStyle-ForeColor="white" SortExpression="Total">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true"/>
                                        </FooterTemplate>
                                         <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>--%>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

     </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
