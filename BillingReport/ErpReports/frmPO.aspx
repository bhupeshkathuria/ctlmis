<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmPO.aspx.cs" Inherits="ErpReports_frmPO" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
   <script src="../JS/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.colorbox.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function () {
         //Examples of how to assign the ColorBox event to elements
         //$(".iframe").colorbox({iframe:true, width: "auto", height: "auto"});
         $(".request").colorbox({ inline: true, width: "auto" });

         $(".callbacks").colorbox({
             onOpen: function () { alert('onOpen: colorbox is about to open'); },
             onLoad: function () { alert('onLoad: colorbox has started to load the targeted content'); },
             onComplete: function () { alert('onComplete: colorbox has displayed the loaded content'); },
             onCleanup: function () { alert('onCleanup: colorbox has begun the close process'); },
             onClosed: function () { alert('onClosed: colorbox has completely closed'); }
         });

         //Example of preserving a JavaScript event for inline calls.
         $("#click").click(function () {
             $('#click').css({ "background-color": "#f00", "color": "#fff", "cursor": "inherit" }).text("Open this window again and this message will still be here.");
             return false;
         });


     });

//     function bindreports() {
//         $(".Cust_Info").colorbox({ iframe: true, width: "80%", height: "600px", href: "Reports/CustomerInformation.aspx" });
//         $(".Reg_Card").colorbox({ iframe: true, width: "80%", height: "600px", href: "Reports/RegistrationCard.aspx" });
//         $(".Inv_Slip").colorbox({ iframe: true, width: "80%", height: "600px", href: "Reports/Invoice_Slip.aspx" });
     //     }
     function Editpayment(link, id) {
         $(link).colorbox({ iframe: true, width: "68%", height: "75%", href: "frmPODetails.aspx?Id=" + id });
        // $.colorbox({ iframe: true, width: "68%", height: "75%", href: "frmPODetails.aspx?Id=" + id });
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<%--<script type="text/javascript">
    function dd() {
        window.open('Default.aspx', 'PopUp', 'statusbar=0,titlebar=0,toolbar=0,location=0,menubar=0,resizable=0,scrollbars=0,height=400,width=427,left=0,top=0');
    }
    </script>--%>
    <table cellpadding="3px" cellspacing="3px" width="100%" style="padding-top:25px">
        <tr>
            <td align="center">
                <asp:GridView ID="dgPO" runat="server" AutoGenerateColumns="false" CellSpacing="5"
                    OnRowDataBound="dgPO_RowDataBound" Style="margin-left: 0px" Width="778px"
                     AlternatingRowStyle-BackColor="#f5f5f5" HeaderStyle-BackColor="#b9b9b9" HeaderStyle-ForeColor="White">
                    
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>
                                <asp:Label ID="lblSrno" runat="server"></asp:Label>
                                <asp:Label ID="lblpoid" runat="server" Text='<%#Eval("poid")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PO NO.">
                            <ItemTemplate>
                                <asp:Label ID="lblPONO" runat="server" Text='<%#Eval("purchaseorderid")%>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Supplier Name">
                            <ItemTemplate>
                                <asp:Label ID="lblsuppliername" runat="server" Text='<%#Eval("busrelname")%>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manager">
                            <ItemTemplate>
                                <asp:Label ID="lblManager" runat="server" Text='<%#Eval("employeename")%>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("branchname")%>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Purchase Date">
                            <ItemTemplate>
                                <asp:Label ID="lblPurchaseDate" runat="server" Text='<%#Eval("orderdate")%>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Left"/>
                             <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("Total")%>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle  HorizontalAlign="Center"/>
                                 <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblViewPo" Text="View" runat="server" onmouseover='<%#"Editpayment(this,&#39;"+Eval("poid").ToString()+"&#39;)" %>'></asp:LinkButton>
                            </ItemTemplate>
                             <ItemStyle  HorizontalAlign="Center"/>
                             <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
