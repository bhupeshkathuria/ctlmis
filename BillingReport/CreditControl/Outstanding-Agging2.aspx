<%@ Page Title="Outstanding Ageing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Outstanding-Agging2.aspx.cs" Inherits="Outstanding_Agging2"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script>


        function callreport(branchid, brname, mevel) {
            window.open("Outstanding-Agging2.aspx?branchid=" + branchid + "&name=" + brname + "&level=" + mevel, '_self', false);
        }
       function callreportfirstlevel(branchid, mevel) {
            window.open("Outstanding-Agging2.aspx?branchid=" + branchid + "&level=" + mevel, '_self', false);

        }
        function callreportcustomer(branchid, custid, mevel) {
            window.open("Outstanding-Agging2.aspx?branchid=" + branchid + "&custid=" + custid + "&level=" + mevel, '_self', false);


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
     <asp:UpdatePanel ID="UdpMain"   runat="server">
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
                    <asp:GridView ID="grdagging_2" Width="900px" ShowFooter="True" runat="server" OnRowDataBound="grdagging_2_RowDataBound"
                        CellPadding="4" AllowSorting="true" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdagging_2_PageIndexChanging"
                        OnSorting="grdagging_2_Sorting">
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
