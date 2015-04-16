<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmPrepaidSale.aspx.cs" Inherits="PrepaidSales_frmPrepaidSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        #mydiv
        {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: url(prepaidreport/transparent.png) repeat; /* for demonstration */
        }
        .ajax-loader
        {
            position: absolute;
            left: 45%;
            top: 40%;
            z-index: 200;
            margin-left: -32px; /* -1 * image width / 2 */
            margin-top: -32px; /* -1 * image height / 2 */
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div>
        
        <asp:UpdatePanel ID="upmain" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="text-align: right" width="200px">
                            Year
                        </td>
                        <td width="150px">
                            <asp:DropDownList ID="ddlYear" runat="server" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="130px">
                            Business Type
                        </td>
                        <td width="200px">
                            <asp:DropDownList ID="ddlBusType" runat="server" Width="180px" AutoPostBack="True">
                                <asp:ListItem Value="2">Global</asp:ListItem>
                                <asp:ListItem Value="3">USA</asp:ListItem>
                                <asp:ListItem Value="1">Germany</asp:ListItem>
                                <asp:ListItem Value="4">UK</asp:ListItem>
                                <asp:ListItem Value="7">USA MVNO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp; &nbsp;<asp:Button ID="BtnShow" runat="server" Text="Show" Width="116px" OnClick="BtnShow_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right; width: 330px" valign="top">
                            <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlMain" runat="server" GroupingText="Sales Report" Height="100%"
                                        Width="100%" Font-Size="10pt">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="500px"
                                            OnRowCommand="GridView1_RowCommand" 
                                            onrowdatabound="GridView1_RowDataBound" ShowFooter="True">
                                            <Columns>
                                                <asp:BoundField DataField="Monthname" HeaderText="Month" />
                                                <asp:TemplateField HeaderText="No. of Sales">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbSales" runat="server" CommandName="Sales" Text='<%# Bind("NoofSales") %>'
                                                            CommandArgument='<%# Bind("monthid") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ActivationAmount" HeaderText="Activation Amount">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Recharge Amount">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbRecharge" runat="server" CommandName="Recharge" Text='<%# Bind("[RechargeAmount]") %>' CommandArgument='<%# Bind("monthid") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle Font-Bold="True" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlBranch" runat="server" GroupingText="Branch Wise Sales" Style="height:auto; width:100%; font-size:12px;" Visible="False">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            Width="100%" onrowdatabound="GridView2_RowDataBound" ShowFooter="True" >
                                            <Columns>
                                                <asp:BoundField DataField="Reseller" HeaderText="Reseller" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                <asp:BoundField DataField="monthname" HeaderText="Month" />
                                                <asp:BoundField DataField="noofsales" HeaderText="No. Of Sales">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ActivationAmount" HeaderText="Activation Amount">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RechargeAmount" HeaderText="Recharge Amount">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Font-Bold="True" />
                                        </asp:GridView>
                                         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                            Width="100%" onrowdatabound="GridView3_RowDataBound" ShowFooter="True" >
                                            <Columns>
                                                <asp:BoundField DataField="Reseller" HeaderText="Reseller" />
                                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                <asp:BoundField DataField="monthname" HeaderText="Month" />                                               
                                                <asp:BoundField DataField="OnlineAmount" HeaderText="Online Amount">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ManualAmount" HeaderText="Manual Amount">
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                             <FooterStyle Font-Bold="True" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="upbar1" runat="server" AssociatedUpdatePanelID="upmain">
            <ProgressTemplate>
                <div id="mydiv">
                    <img src="loading.gif" width="100" height="100" class="ajax-loader" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

