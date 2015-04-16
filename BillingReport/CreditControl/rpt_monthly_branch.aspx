<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rpt_monthly_branch.aspx.cs" Inherits="CreditControl_rpt_monthly_branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="updt1">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updt1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imgexport" />
        </Triggers>
        <ContentTemplate>
            <div>
                <div>
                    <table min-width="100%" cellpadding="5px" cellspacing="0">
                        <tr>
                            <td class="Header_text" colspan="3" align="left" style="width: 300px">
                                &nbsp;&nbsp;Invoice / Credit Report /Monthly Branch wise
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset style="width: 600px;">
                                    <legend><b>Search Criteria</b></legend>
                                    <table>
                                        <tr>
                                            <td>
                                                Month:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMonth1bymonth" runat="server" Width="150px">
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
                                            <td>
                                                Year:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlyear" runat="server" Width="150px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnsubmit" runat="server" Text="Search" OnClick="btnsubmit_Click" />
                                            </td>
                                            <td id="trexcel" runat="server" visible="false">
                                                <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                                                    OnClick="imgexport_Click" />:Export into Excel
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 15px">
                                                <asp:Label ID="lblmess" runat="server" ForeColor="red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr id="trAdjucement" runat="server" visible="false">
                            <td class="Header_text" colspan="3" align="left" >
                                <fieldset style="width: 600px;">
                                    <legend>Adjustment Summary :</legend>
                                    <table cellpadding="0px" cellspacing="1px" border="0px" width="800px">
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
                                             <td>
                                            <b>Current Month Billing</b>
                                        </td>
                                        <td>
                                            <b>Previous Month Billing</b>
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
                                             <td>
                                            <b>
                                                <asp:Label ID="lblcurrentmonthBilling" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblPreviousmonthBilling" runat="server"></asp:Label></b>
                                        </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%" colspan="3">
                                <div id="divReport" visible="false" style="width: 850px; overflow: auto; overflow-x: scroll;
                                    overflow-y: hidden;" runat="server">
                                    <asp:GridView ID="grdrept" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                        OnRowDataBound="grdrept_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("branch") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblbrnch" runat="server" Font-Bold="true" Text="Grand Total"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                <FooterStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl1st" runat="server" Text='<%#Eval("1") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal1" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2st" runat="server" Text='<%#Eval("2") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal2" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="3Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl3st" runat="server" Text='<%#Eval("3") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal3" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="4Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl4st" runat="server" Text='<%#Eval("4") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal4" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="5Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl5st" runat="server" Text='<%#Eval("5") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal5" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="6Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl6st" runat="server" Text='<%#Eval("6") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal6" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="7Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl7st" runat="server" Text='<%#Eval("7") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal7" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="8Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl8st" runat="server" Text='<%#Eval("8") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal8" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="9Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl9st" runat="server" Text='<%#Eval("9") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal9" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="10Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl10st" runat="server" Text='<%#Eval("10") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal10" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="11Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl11st" runat="server" Text='<%#Eval("11") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal11" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="12Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl12st" runat="server" Text='<%#Eval("12") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal12" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="13Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl13st" runat="server" Text='<%#Eval("13") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal13" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="14Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl14st" runat="server" Text='<%#Eval("14") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal14" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="15Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl15st" runat="server" Text='<%#Eval("15") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal15" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="16Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl16st" runat="server" Text='<%#Eval("16") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal16" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="17Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl17st" runat="server" Text='<%#Eval("17") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal17" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="18Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl18st" runat="server" Text='<%#Eval("18") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal18" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="19Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl19st" runat="server" Text='<%#Eval("19") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal19" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="20Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl20st" runat="server" Text='<%#Eval("20") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal20" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="21Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl21st" runat="server" Text='<%#Eval("21") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal21" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="22Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl22st" runat="server" Text='<%#Eval("22") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal22" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="23Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl23st" runat="server" Text='<%#Eval("23") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal23" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="24Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl24st" runat="server" Text='<%#Eval("24") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal24" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="25Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl25st" runat="server" Text='<%#Eval("25") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal25" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="26Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl26st" runat="server" Text='<%#Eval("26") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal26" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="27Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl27st" runat="server" Text='<%#Eval("27") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal27" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="28Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl28st" runat="server" Text='<%#Eval("28") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal28" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="29Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl29st" runat="server" Text='<%#Eval("29") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal29" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="30Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl30st" runat="server" Text='<%#Eval("30") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal30" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="31Day" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl31st" runat="server" Text='<%#Eval("31") %>' Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lbltotal31" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total" HeaderStyle-HorizontalAlign="Right" HeaderStyle-BackColor="maroon"
                                                HeaderStyle-ForeColor="white">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotal" runat="server" Font-Bold="true" Text='<%#Eval("total") %>'
                                                        Width="75px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="true"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
