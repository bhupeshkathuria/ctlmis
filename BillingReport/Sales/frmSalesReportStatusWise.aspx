<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmSalesReportStatusWise.aspx.cs" Inherits="Sales_frmSalesReportStatusWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <script src="../JS/glow/1.7.0/core/core.js" type="text/javascript"></script>
    <script src="../JS/glow/1.7.0/widgets/widgets.js" type="text/javascript"></script>
    <link href="../JS/glow/1.7.0/widgets/widgets.css" type="text/css" rel="stylesheet" />
     <script src="../JS/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../JS/jquery.colorbox.js" type="text/javascript"></script>
    <link href="../Css/pop_up.css" rel="stylesheet" type="text/css" />
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            //Examples of how to assign the ColorBox event to elements
            //        $(".iframe").colorbox({iframe:true, width: "auto", height: "auto"});
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
        function RafStatus(link, id) {
            $(link).colorbox({ iframe: true, width: "71%", height: "650px", href: "../Sales/frmSalesReporBranchManagerWise.aspx?branchid=" + id });
        }
       
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <table width="99%" cellpadding="0" cellspacing="1px">
        <tr>
            <td align="center">
                <table  cellpadding="10" cellspacing="0" style="border: 1px solid Black">
                    <tr>
                        <td>
                            Select Year:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Select Month:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Report" Width="135px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSerach" runat="server" Text="Search" OnClick="btnSerach_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="70%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                <asp:GridView ID="gdvSalesStatus" runat="server" AutoGenerateColumns="false" CssClass="record-result"  
                                    onrowcommand="gdvSalesStatus_RowCommand">
                                <Columns>
                                 <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Left" ControlStyle-Font-Bold="true" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBranchid" Text='<%#Eval("branchid") %>' runat="server" Visible="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                   <%-- <asp:BoundField DataField="Branchid" HeaderText="Branchid" Visible="false" />--%>
                                <asp:TemplateField HeaderText="Branch" ControlStyle-CssClass="force-left">
                                        <ItemTemplate>
                                          <asp:LinkButton ID="lnkBranchname" Text='<%#Eval("branchname") %>' runat="server" OnClientClick='<%#"RafStatus(this,&#39;" + Eval("branchid").ToString() + "&#39;)"%>' Font-Size="Small" />
                                            <%--<asp:HyperLink ID="lnkBranchname" runat="server" NavigateUrl='<%# string.Format("frmSalesReporBranchManagerWise.aspx?branchid={0}",
                                                        HttpUtility.UrlEncode(Eval("branchid").ToString())) %>'
                                                                        Text='<%# Eval("branchname") %>'  Target="_blank" ForeColor="Red"></asp:HyperLink>--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                             <asp:BoundField DataField="TotalRAF" HeaderText="TotalRAF" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Sale" HeaderText="Pend.-Sale" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Inventory" HeaderText="Pend.-Inventory"  ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Operation" HeaderText="Pend.-Operation" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Delivery" HeaderText="Pend.-Delivery" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Accept/Partial Accept" HeaderText="Accept" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Closed" HeaderText="Closed" ItemStyle-HorizontalAlign="Right"/>
                            <asp:BoundField DataField="DocumentUploaded" HeaderText="Doc-Uploaded" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="DocumentNotUploaded" HeaderText="Doc-NotUploaded" ItemStyle-HorizontalAlign="Right"/>
                                </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

