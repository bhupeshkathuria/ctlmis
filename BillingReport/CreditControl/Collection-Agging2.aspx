<%@ Page Title="Collection Ageing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Collection-Agging2.aspx.cs" Inherits="User_CreditControl_Collection_Agging2"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script>


        function callreport(branchid, brname, monthid, yearid, mevel) {
            window.open("Collection-Agging2.aspx?branchid=" + branchid + "&name=" + brname + "&month=" + monthid + "&year=" + yearid + "&level=" + mevel, '_self', false);


        }
        function callreportcustomer(branchid, custid, monthid, yearid, mevel) {
            window.open("Collection-Agging2.aspx?branchid=" + branchid + "&custid=" + custid + "&month=" + monthid + "&year=" + yearid + "&level=" + mevel, '_self', false);


        }
    </script>
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
            <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="Header_text" colspan="3" align="left" style="width: 300px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Collection - By Ageing </legend>
                                <div style="float: left">
                                    &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                                <div style="float: left">
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                    </asp:DropDownList>
                                    <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                                    &nbsp;&nbsp;&nbsp;
                                </div>
                                <div style="float: left">
                                    &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                                <div style="float: left; height: 24px;">
                                    <asp:DropDownList ID="ddlMonth" runat="server">
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
                                    <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                                    &nbsp;&nbsp;&nbsp;
                                </div>
                                <div style="float: left">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return JSFunctionValidate()"
                                        OnClick="btnSearch_Click" />
                                    <asp:Label ID="lblmess" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                    <tr id="trAdjucement" runat="server" visible="false">
                        <td class="Header_text" colspan="3" align="left" >
                            <fieldset>
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
                    <tr id="trexport" runat="server" visible="false">
                        <td style="padding-left: 20px">
                            <b>Export Excel </b>
                            <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif"
                                OnClick="imgexport_Click" />
                        </td>
                    </tr>
                    <tr id="trbrname" runat="server" visible="false">
                        <td style="padding-left: 20px">
                            <table>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblbr" runat="server"></asp:Label></b>
                                    </td>
                                    <td>
                                        <b>
                                            <asp:Label ID="lblbranchname" ForeColor="Red" runat="server"></asp:Label></b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 20px">
                            <%--<asp:GridView ID="grdagging" Width="500px" ShowFooter="True" runat="server" 
                                AutoGenerateColumns="false" onrowdatabound="grdagging_RowDataBound"
                                >
                               <Columns>
                                    <asp:TemplateField HeaderText="Branch" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbrName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltext" runat="server" Text="Grand Total" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <FooterStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="0-60" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutstanding1" runat="server" Text='<%#Eval("Outstanding1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOutstanding1" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="60-90" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutstanding2" runat="server" Text='<%#Eval("Outstanding2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOutstanding2" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="90-180" HeaderStyle-BackColor="maroon"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutstanding3" runat="server" Text='<%#Eval("Outstanding3") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOutstanding3" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="180 Above" HeaderStyle-BackColor="maroon" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutstanding4" runat="server" Text='<%#Eval("Outstanding4") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalOutstanding4" runat="server" Font-Bold="true" />
                                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                  
                                   
                                </Columns>
                            </asp:GridView>--%>
                            <asp:GridView ID="grdagging_2" runat="server" AllowSorting="true" CellPadding="4"
                                ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdagging_2_PageIndexChanging"
                                OnRowDataBound="grdagging_2_RowDataBound" OnSorting="grdagging_2_Sorting" ShowFooter="True"
                                Width="850px">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
