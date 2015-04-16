<%@ Page Title="TargetVsAchievement" Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="false" 
    AutoEventWireup="true" CodeFile="frmTarVsAch.aspx.cs" Inherits="CreditControl_frmTarVsAch"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
   <asp:PostBackTrigger ControlID="imgexport"/>
   </Triggers>
        <ContentTemplate>
    <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
         <table min-width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" colspan="3" align="left" style="width: 300px">
                    &nbsp;&nbsp; <b>TarVsAch</b>
                </td>
            </tr>
            <tr>
                <td  colspan="3">
                    <fieldset style="width: 600px;">
                        <legend><b>Search Criteria</b></legend>
                        <table width="100%">
                            <tr>
                                <td>
                                    Cc Executive:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlExecutive" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Year:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" Width="80px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    From Month:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFromMonth" runat="server" Width="80px">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sept</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    To Month:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlToMonth" runat="server" Width="80px">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sept</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                          <%--  <tr id="trTotalTargetAch" runat="server" visible="false">
                                <td>
                                    Total Target:
                                </td>
                                <td>
                                    <asp:Label ID="lbltarget" runat="server"></asp:Label>
                                </td>
                                <td>
                                    Total Achievement:
                                </td>
                                <td>
                                    <asp:Label ID="lblachivement" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                                        Text="Submit" />
                                </td>
                                <td runat="server" id="tdexporttoexcel" visible="false">
                                   <b>Export Excel </b>
                    <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                        OnClick="imgexport_Click" />
                        </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                          </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 20px" colspan="3">
                   <asp:GridView ID="GrdTarAchDetails" runat="server" AllowSorting="true" OnRowCommand="GrdTarAchDetails_RowCommand"
                                OnRowDataBound="GrdTarAchDetails_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None" OnSorting="GrdTarAchDetails_Sorting" ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                                <%-- <Columns>
                                <asp:TemplateField HeaderText="abc">
                                <FooterTemplate>
                                
                                </FooterTemplate>
                                </asp:TemplateField>
                                </Columns>--%>
                            </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
  </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
