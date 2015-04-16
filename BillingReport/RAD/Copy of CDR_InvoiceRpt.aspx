<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Copy of CDR_InvoiceRpt.aspx.cs" Inherits="CDR_InvoiceReport" EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function fixHeader() {

            //get the id of table used in repeater control
            var t = document.getElementById("table12");
            var thead = t.getElementsByTagName("thead")[0];
            var t1 = t.cloneNode(false);
            t1.appendChild(thead);
            tableHeader.appendChild(t1)
        }</script>
    <style type="text/css">
        #progress
        {
            z-index: 500;
            position: absolute;
            color: White;
            top: 50%;
            left: 50%;
        }
        #blur
        {
            height: 100%;
            width: 100%;
            background-color: #666666;
            moz-opacity: 0.5;
            khtml-opacity: .5;
            opacity: 0.5;
            filter: alpha(opacity=50);
            z-index: 120;
            position: fixed;
            top: 0;
            left: 0;
        }
      td.locked, th.locked {
font-size: 14px;
font-weight: bold;
text-align: center;
background-color: navy;
color: white;
border-right: 1px solid silver;
position:relative;
cursor: default;
/*IE5+ only*/
left:expression((this.parentElement.parentElement.parentElement.parentElement.scrollLeft-2)+'px');
}
.table-area1{ min-width:100%; height:auto; margin:0px; float:none !important}
.table-area1 table{ width:100%; height:auto; border:1px solid #e6e6e6; text-align:left; line-height:18px;border-collapse:collapse;}
.table-area1 th{ background:url(../images/rpt1.jpg) repeat-x; color:#666; font:bold 11px Verdana; height:20px;}
.table-area1 td{ background:#fbfbfb; height:20px; padding-left:10px; min-width:100px; border:1px solid #ccc; border-collapse:collapse; font:normal 11px Verdana; color:#6c6c6c; padding:0px 0 0px 5px;}
.table-area1 td input{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; }
.table-area1 td textarea{ font:normal 11px Verdana; color:#6c6c6c; height:60px !important; width:250px; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; margin:5px 0 }
.table-area1 td select{ font:normal 11px Verdana; color:#6c6c6c; height:24px !important; padding:2px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px 0 0 4px; background:url(../images/patt.jpg) repeat; }

.table-area1 td input[type="checkbox"]{ font:normal 11px Verdana; color:#6c6c6c; height:15px !important; width:15px; border:1px solid #d3d3d3; margin-top:10px;}
.table-area1 .g-btn{ width:60px !important; height:24px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area1 .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area1 table a{ font:normal 11px Verdana; text-decoration:none; color:#FF0000;}
.table-area1 table a:hover{ font:normal 11px Verdana; text-decoration:underline; color:#FF0000;}
.table-area1 td table{ border:none;}

.table-area{ width:780px; height:auto; margin:15px auto;}
.table-area table{ width:100%; height:auto; border:1px solid #e6e6e6; text-align:left; line-height:18px;border-collapse:collapse;}
.table-area th{ background:url(../images/rpt1.jpg) repeat-x; color:#666; font:bold 11px Verdana; height:20px;}
.table-area td{ background:#fbfbfb; height:20px; min-width:100px; padding-left:10px; border:1px solid #e1e1e1; border-collapse:collapse; font:normal 11px Verdana; color:#6c6c6c; padding:0px 0 0px 5px;}
.table-area td input{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; }
.table-area td textarea{ font:normal 11px Verdana; color:#6c6c6c; height:60px !important; width:250px; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; margin:5px 0 }
.table-area td select{ font:normal 11px Verdana; color:#6c6c6c; height:24px !important; padding:2px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px 0 0 4px; background:url(../images/patt.jpg) repeat; }

.table-area td input[type="checkbox"]{ font:normal 11px Verdana; color:#6c6c6c; height:15px !important; width:15px; border:1px solid #d3d3d3; margin-top:10px;}
.table-area .g-btn{ width:60px !important; height:24px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area table a{ font:normal 11px Verdana; text-decoration:none; color:#FF0000;}
.table-area table a:hover{ font:normal 11px Verdana; text-decoration:underline; color:#FF0000;}
.table-area td table{ border:none;}
.tbl-grd { border:1px solid #ccc;}
.tbl-grd table{ border:1px solid #ccc;}
.tbl-grd th{ border:none; background:#ebebeb}
.tbl-grd td{ border:none; border-top:1px solid #ccc; background:#f3f3f3}
.redtext{color:#ff0000 !important;}
    </style>
    <script src="JS/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JS/jquery.colorbox.js" type="text/javascript"></script>
    <%--   <link href="../css/colour.css" rel="stylesheet" type="text/css" />--%>
    <link href="Css/pop_up.css" rel="stylesheet" type="text/css" />
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



        //        function Salesorder(link, id) {
        //            $(link).colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 1 });
        //        }
        function Salesorder(id) {
            $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 1 });
        }
        function package(id) {
            $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 2 });

        }
        function TermCont(id) {
            $().colorbox({ iframe: true, width: "68%", height: "75%", href: "../Reports/RPT_RafOrder.aspx?orderid=" + id + "&state=" + 3 });

        }
        function DI(id, fromdate, todate) {
            $().colorbox({ iframe: true, width: "78%", height: "55%", href: "CDR_invoicerpt_sub1.aspx?groupid=" + id + "&fromdate=" + fromdate + "&todate=" + todate });

        }
    </script>
    <style type="text/css">
        #mask
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });

        function ShowPopup2() {
            $('#mask').show();
            $('#<%=pnlpopup2.ClientID %>').show();
        }
        function HidePopup2() {
            $('#mask').hide();
            $('#<%=pnlpopup2.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });
    </script>
    <script type="text/javascript">
        var GridId = "<%=grdinvoice.ClientID %>";
        var ScrollHeight ="300";
        window.onload = function () {
            var grid = document.getElementById(GridId);
            var gridWidth = grid.offsetWidth;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            table.style.cssText = grid.style.cssText;
            table.style.width = gridWidth + "px";
            table.class = "table-area1";
            table.appendChild(document.createElement("tbody"));
            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];
            for (var i = 0; i < cells.length; i++) {
                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }
                cells[i].style.width = parseInt(width - 3) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
            }
            parentDiv.removeChild(grid);

            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
    </script>
    <script src="../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="mask">
    </div>
    <div align="center">
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="100px" Width="350px"
            Style="z-index: 111; background-color: White; position: absolute; left: 35%;
            top: 34%; border: outset 2px gray; padding: 5px; display: none">
            <asp:Label ID="lblHeader" Font-Bold="true" runat="server"></asp:Label>
            <input type="image" src="../Images/close-x.png" class="btnClose" value="Cancel" style="position: absolute;
                top; -10px; right: 10px;" />
            <br />
            <asp:Panel ID="pnlBranch" runat="server" Style="height: 250px; padding: 0; width: 100%;
                font-size: 12px;" Visible="False" ScrollBars="Auto">
                <table width="100%" id="tblservice" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="lbldivprovider" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lbldat2_2" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Data Service:
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkdata" runat="server" OnClick="lnkdata_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Balck Berry:
                        </td>
                        <td align="left">
                            <asp:LinkButton ID="lnkblackberry" runat="server" OnClick="lnkblackberry_Click"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="500px" Width="600px"
            Style="z-index: 111; background-color: White; position: absolute; left: 20%;
            top: 20%; border: outset 2px gray; padding: 5px; display: none">
            <asp:Label ID="lblheader2" Font-Bold="true" runat="server"></asp:Label>
            <input type="image" src="../Images/close-x.png" class="btnClose" value="Cancel" style="position: absolute;
                top; -10px; right: 10px;" />
            <br />
            <asp:Panel ID="pnlBranch2" runat="server" Style="height: 420px; padding: 0; width: 100%;
                font-size: 12px;" Visible="False" ScrollBars="Auto">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            Provider:
                        </td>
                        <td>
                            <asp:Label ID="lblprovidersdet" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            Date:
                        </td>
                        <td>
                            <asp:Label ID="lbldatesdet" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdservice" runat="server" AutoGenerateColumns="false" Width="100%"
                                GridLines="None" CssClass="table-area">
                                <Columns>
                                    <asp:TemplateField HeaderText="MobileNo" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobileno" runat="server" Text='<%#Eval("mobileno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SimNo" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsimno" runat="server" Text='<%#Eval("simcardno") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RAFNO" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblorderid" runat="server" Text='<%#Eval("orderid") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Coupon" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcouponname" runat="server" Text='<%#Eval("couponname") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service Activation" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblserdate" runat="server" Text='<%#Eval("_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <table cellpadding="0" cellspacing="0" border="0px" width="100%" align="center">
            <tr>
                <td style="width: 700px;">
                    <table>
                        <tr>
                            <td width="70%">
                                <table cellpadding="0" align="Left" cellspacing="0" width="50%" class="table-area">
                                    <tr>
                                        <td colspan="4" class="style1">
                                            <b>Head Section</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td>
                                            Country:<span class="redtext">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlcountry" runat="server" Width="150px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td>
                                            Networks:<%--<span class="redtext">*</span>--%>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlnetworks" Width="150px" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Billing Month:<%--<span class="redtext">*</span>--%>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlyear" runat="server" Width="70px">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlmonth" runat="server" Width="75px">
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
                                    </tr>
                                    <tr>
                                        <td>
                                            Report Criteria
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCriteria" runat="server">
                                                <asp:ListItem Text="By Invoicing Month" value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="By CDR Month" value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" Width="50px" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" Width="50px" runat="server" Text="Export" OnClick="btnExport_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <div id="div" runat="server" visible="false" style="width: 1200px; height:auto; overflow-x: scroll; overflow-y: hidden;">
                                                <asp:GridView ID="grdinvoice" runat="server" AutoGenerateColumns="false" CssClass="table-area1"
                                                    ShowFooter="true" OnRowDataBound="grdinvoice_RowDataBound" OnRowCommand="grdinvoice_RowCommand"
                                                    OnRowCreated="grdinvoice_RowCreated">
                                                   
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" class="table-area1">
                                                                    <tr>
                                                                        <td colspan="10" align="center">
                                                                           
                                                                        </td>
                                                                        <td colspan="6" align="center">
                                                                          <b>  Retail</b>
                                                                        </td>
                                                                        <td colspan="6" align="center">
                                                                           <b>   Wholesale</b>
                                                                        </td>
                                                                        <td colspan="2" align="center">
                                                                           <b>   Total</b>
                                                                        </td>
                                                                        <td colspan="6" align="center">
                                                                          <b>   Revenue Lookup</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Invoicing Month[A]
                                                                        </td>
                                                                        <td style="min-width:185px !important">
                                                                            Provider[B]
                                                                        </td>
                                                                        <td>
                                                                            Invoice Amount(FX)[C]
                                                                        </td>
                                                                        <td>
                                                                            Invoice Amount(INR)[D]
                                                                        </td>
                                                                        <td>
                                                                            CDR Amount(FX)[E]
                                                                        </td>
                                                                        <td>
                                                                            CDR Amount(INR)[F]
                                                                        </td>
                                                                        <td>
                                                                            FX Rate[G]
                                                                        </td>
                                                                        <td>
                                                                            GAP[D-F]
                                                                        </td>
                                                                        <td align="right">
                                                                            Total Lines
                                                                        </td>
                                                                        <td align="right">
                                                                            Active Lines
                                                                        </td>
                                                                        <%-- Retail--%>
                                                                        <td align="right" style="min-width:100px !important">
                                                                            No's of lines
                                                                        </td>
                                                                        <td>
                                                                            In Charge (FX)[I]
                                                                        </td>
                                                                        <td>
                                                                            Out Charge (FX)[J]
                                                                        </td>
                                                                        <td>
                                                                            In Charge INR [K]
                                                                        </td>
                                                                        <td>
                                                                            Out Charge INR [L]
                                                                        </td>
                                                                        <td align="right" style="min-width:100px !important">
                                                                            Retail (%)
                                                                        </td>
                                                                        <%-- Wholesale--%>
                                                                        <td align="right" style="min-width:100px !important">
                                                                            No's of lines
                                                                        </td>
                                                                        <td>
                                                                            In Charge (FX)[M]
                                                                        </td>
                                                                        <td>
                                                                            Out Charge (FX)[N]
                                                                        </td>
                                                                        <td>
                                                                            In Charge INR [O]
                                                                        </td>
                                                                        <td>
                                                                            Out Charge INR [P]
                                                                        </td>
                                                                        <td align="right" style="min-width:100px !important">
                                                                            Wholesale (%)
                                                                        </td>
                                                                        <%-- Total--%>
                                                                        <td>
                                                                            Total Out (FX) [J + N]
                                                                        </td>
                                                                        <td>
                                                                            Total Out (INR) [L + P]
                                                                        </td>
                                                                        <%-- Invoice--%>
                                                                        <td>
                                                                            Invoice Amount (FX)[Q]
                                                                        </td>
                                                                        <td>
                                                                            Invoice Amount (INR)[R]
                                                                        </td>
                                                                        <td>
                                                                            Total Billing (FX)[S]
                                                                        </td>
                                                                        <td>
                                                                            Total Billing (INR)[T]
                                                                        </td>
                                                                        <td>
                                                                            Credit Note
                                                                        </td>
                                                                        <td>
                                                                            Credit Note(INR)
                                                                        </td>
                                                                        <td>
                                                                            Gross Rev (INR)[T-R]
                                                                        </td>
                                                                        <td align="center" style="min-width:100px !important">
                                                                            Total (%)
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%" class="table-area1">
                                                                    <tr>
                                                                        <td id="tdpro" runat="server">
                                                                            <asp:Label ID="lblbillingmonth" runat="server" Text='<%#Eval("BillingMonth") %>' />
                                                                            <asp:Label ID="lblbillmonth22" runat="server" Visible="false" Text='<%#Eval("billmon") %>' />
                                                                        </td>
                                                                        <td style="min-width:180px !important">
                                                                            <asp:LinkButton ID="lnkprovider" runat="server" Text='<%#Eval("Network") %>' CommandArgument='<%#Eval("providerid") %>'
                                                                                CommandName="groupname">
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblinvoiceamount" runat="server" Text='<%#Eval("invoiceamount") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblcdramount" runat="server" Text='<%#Eval("cdrtotalamount") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblcdramountallinr" runat="server" Text='<%#Eval("cdramountallinr") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblfxr" runat="server" Text='<%#Eval("fxr") %>' />
                                                                        </td>
                                                                        <td id="tdgap" runat="server"  align="right">
                                                                            <asp:Label ID="lblgap" runat="server" Text='<%#Eval("gap") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltoatlline" runat="server" Text='<%#Eval("totalall_line") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:LinkButton ID="lnkactiveline" runat="server" Text='<%#Eval("totalactiveline") %>'
                                                                                CommandName="activeline"></asp:LinkButton>
                                                                        </td>
                                                                        <%--Retailer--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltotallines" runat="server" Text='<%#Eval("totallinesret") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_incharge" runat="server" Text='<%#Eval("ret_incharge") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_outcharge" runat="server" Text='<%#Eval("ret_outcharge") %>' />
                                                                        </td>
                                                                        <td id="ret_in" runat="server"  align="right">
                                                                            <asp:Label ID="lblret_incharge_inr" runat="server" Text='<%#Eval("ret_incharge_inr") %>' />
                                                                        </td>
                                                                        <td id="ret_out" runat="server"  align="right">
                                                                            <asp:Label ID="lblret_outcharge_inr" runat="server" Text='<%#Eval("ret_outchargeinr") %>' />
                                                                        </td>
                                                                        <td id="trretper" runat="server"  align="right">
                                                                            <asp:Label ID="lblretper" runat="server" Text='<%#Eval("ret_percentage") %>' />
                                                                        </td>
                                                                        <%--Wholesaler--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltotallineswhs" runat="server" Text='<%#Eval("totallineswhs") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_incharge" runat="server" Text='<%#Eval("whole_incharge") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_outcharge" runat="server" Text='<%#Eval("whole_outcharge") %>' />
                                                                        </td>
                                                                        <td id="whole_in" runat="server"  align="right">
                                                                            <asp:Label ID="lblwhole_incharge_inr" runat="server" Text='<%#Eval("whole_inchargeINR") %>' />
                                                                        </td>
                                                                        <td id="whole_out" runat="server"  align="right">
                                                                            <asp:Label ID="lblwhole_outcharge_inr" runat="server" Text='<%#Eval("whole_outchargeINR") %>' />
                                                                        </td>
                                                                        <td id="trwhsper" runat="server"  align="right">
                                                                            <asp:Label ID="lblwhsper" runat="server" Text='<%#Eval("whs_percentage") %>' />
                                                                        </td>
                                                                        <%--Total--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltot_outchargefx" runat="server" Text='<%#Eval("totaloutfx") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltot_outchargeINR" runat="server" Text='<%#Eval("totaloutinr") %>' />
                                                                        </td>
                                                                        <%--Invoice--%>
                                                                        <td id="revamt" runat="server"  align="right">
                                                                            <asp:Label ID="lblrevinvoiceamount" runat="server" Text='<%#Eval("revinvoiceamount") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblrevinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                                        </td>
                                                                        <td id="revtotbill" runat="server">
                                                                            <asp:Label ID="lbltotalbilling" runat="server" Text='<%#Eval("totalbilling") %>' />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltotalbillinginr" runat="server" Text='<%#Eval("totalbillinginr") %>' />
                                                                        </td>
                                                                        <td   id="creditnote" align="right">
                                                                            <asp:Label ID="lblcreditnote" runat="server" Text='<%#Eval("creditamount") %>' />
                                                                        </td>
                                                                        <td  id="creditnoteinr" align="right">
                                                                            <asp:Label ID="lblcreditnoteinr" runat="server" Text='<%#Eval("creditamountinr") %>' />
                                                                        </td>
                                                                        <td id="revgross" runat="server"  align="right">
                                                                            <asp:Label ID="lblgrossrevinr" runat="server" Text='<%#Eval("grosrevinr") %>' />
                                                                        </td>
                                                                        <td id="revtotalper" runat="server"  align="center">
                                                                            <asp:Label ID="lblrevper" runat="server" Text='<%#Eval("total_pecentage") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="min-width:180px !important" >
                                                                            <asp:Label ID="lblgrandtot" runat="server" Text="Grand Total" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblinvoiceamountot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblinvoiceamouninrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblcdramounttot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblcdramountinrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblfxtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblgaptot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                       
                                                                        <%--Retailer--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbllinestot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_inchargetot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_outchargetot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_incharge_inrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblret_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td></td>
                                                                        <%--Wholesaler--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbllineswhstot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_inchargetot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_outchargetot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_incharge_inrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblwhole_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                         <td></td>
                                                                        <%--Total--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltot_outchargefxtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltot_outchargeINRtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <%--Wholesaler--%>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblrevinvamount" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblrevinvamountinr" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltotalbilltot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lbltotalbillinrtot" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                         </td>
                                                                         <td  align="right">
                                                                            <asp:Label ID="lblgrosscreditnote" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblgrosscreditnoteinr" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                         
                                                                        <td  align="right">
                                                                            <asp:Label ID="lblgrossrevINRtot" runat="server" Font-Bold="true" />

                                                                        <td align="center">
                                                                            <asp:Label ID="lblgrossPer" runat="server" Font-Bold="true" />
                                                                        </td>
                                                                       
                                                                    </tr>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <%--Invoice--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div  style="width: 1100px; overflow: auto; float: left; overflow-x: scroll; overflow-y: hidden; display:none;">
                                                <asp:Repeater ID="RAFRepeater" runat="server" OnItemDataBound="RAFRepeater_ItemDataBound"
                                                    OnItemCommand="RAFRepeater_ItemCommand">
                                                    <HeaderTemplate>
                                                        <table border="1" cellpadding="0" cellspacing="0" class="table-area">
                                                            <thead>
                                                                <tr id="thead">
                                                                    <th align="center" style="width: 150px; text-align: center">
                                                                    </th>
                                                                    <th align="center" style="width: 150px; text-align: center">
                                                                    </th>
                                                                    <th colspan="8" align="center">
                                                                    </th>
                                                                    <th colspan="5" align="center">
                                                                        Retailer
                                                                    </th>
                                                                    <th colspan="5" align="center">
                                                                        Wholesaler
                                                                    </th>
                                                                    <th colspan="2" align="center">
                                                                        Total
                                                                    </th>
                                                                    <th colspan="5" align="center">
                                                                        Revenue Lookup
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px; text-align: center">
                                                                        <strong>Invoicing Month[A]</strong>
                                                                    </td>
                                                                    <td style="width: 150px; text-align: center">
                                                                        <strong>Provider[B]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>Invoice Amount(FX)[D]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>Invoice Amount(INR)[E]</strong>
                                                                    </td>
                                                                    <td id="tdcdramtheader" runat="server">
                                                                        <strong>CDR Amount(FX)[F]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>CDR Amount(INR)[G]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>FX Rate[H]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>GAP[E-G]</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>Total Lines</strong>
                                                                    </td>
                                                                    <td>
                                                                        <strong>Active Lines</strong>
                                                                    </td>
                                                                    <%--Retailer--%>
                                                                    <td align="Right">
                                                                        <strong>No's of lines</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>In Charge (FX)[I]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Out Charge (FX)[J]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>In Charge INR [K]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Out Charge INR [L]</strong>
                                                                    </td>
                                                                    <%--Wholesaler--%>
                                                                    <td align="Right">
                                                                        <strong>No's of lines</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>In Charge (FX)[M]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Out Charge (FX)[N]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>In Charge INR [O]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Out Charge INR [P]</strong>
                                                                    </td>
                                                                    <%--Total--%>
                                                                    <td style="width: 150px;" align="Left">
                                                                        <strong>Total Out (FX) [J + N]</strong>
                                                                    </td>
                                                                    <td style="width: 150px;" align="Left">
                                                                        <strong>Total Out (INR) [L + P]</strong>
                                                                    </td>
                                                                    <%--Invoice--%>
                                                                    <td align="Right">
                                                                        <strong>Invoice Amount (FX)[Q]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Invoice Amount (INR)[R]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Total Billing (FX)[S]</strong>
                                                                    </td>
                                                                    <td align="Right">
                                                                        <strong>Total Billing (INR)[T]</strong>
                                                                    </td>
                                                                    <%--<td align="Right">
                                                            <strong>Gross Rev(FX)</strong>
                                                        </td>--%>
                                                                    <td id="tdgrossrevheader" runat="server" align="Left">
                                                                        <strong>Gross Rev (INR)[T-R]</strong>
                                                                    </td>
                                                                </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblbillingmonth" runat="server" Text='<%#Eval("BillingMonth") %>' />
                                                                <asp:Label ID="lblbillmonth22" runat="server" Visible="false" Text='<%#Eval("billmon") %>' />
                                                            </td>
                                                            <td>
                                                                <%--<asp:Label ID="lblnetwork" runat="server" Text='<%#Eval("Network") %>' />--%>
                                                                <asp:LinkButton ID="lnkprovider" runat="server" Text='<%#Eval("Network") %>' CommandArgument='<%#Eval("providerid") %>'
                                                                    CommandName="groupname"></asp:LinkButton>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinvoiceamount" runat="server" Text='<%#Eval("invoiceamount") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                            </td>
                                                            <td id="tdcdramt" runat="server" align="Right">
                                                                <asp:Label ID="lblcdramount" runat="server" Text='<%#Eval("cdrtotalamount") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblcdramountallinr" runat="server" Text='<%#Eval("cdramountallinr") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblfxr" runat="server" Text='<%#Eval("fxr") %>' />
                                                            </td>
                                                            <td id="tdlblgap" runat="server" align="Right">
                                                                <asp:Label ID="lblgap" runat="server" Text='<%#Eval("gap") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltoatlline" runat="server" Text='<%#Eval("totalall_line") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkactiveline" runat="server" Text='<%#Eval("totalactiveline") %>'
                                                                    CommandName="activeline"></asp:LinkButton>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotallines" runat="server" Text='<%#Eval("totallinesret") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_incharge" runat="server" Text='<%#Eval("ret_incharge") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_outcharge" runat="server" Text='<%#Eval("ret_outcharge") %>' />
                                                            </td>
                                                            <td id="tdlblret_incharge_inr" runat="server" align="Right">
                                                                <asp:Label ID="lblret_incharge_inr" runat="server" Text='<%#Eval("ret_incharge_inr") %>' />
                                                            </td>
                                                            <td id="tdlblret_outcharge_inr" runat="server" align="Right">
                                                                <asp:Label ID="lblret_outcharge_inr" runat="server" Text='<%#Eval("ret_outchargeinr") %>' />
                                                            </td>
                                                            <%--Wholesaler--%>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotallineswhs" runat="server" Text='<%#Eval("totallineswhs") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_incharge" runat="server" Text='<%#Eval("whole_incharge") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_outcharge" runat="server" Text='<%#Eval("whole_outcharge") %>' />
                                                            </td>
                                                            <td id="tdlblwhole_incharge_inr" runat="server" align="Right">
                                                                <asp:Label ID="lblwhole_incharge_inr" runat="server" Text='<%#Eval("whole_inchargeINR") %>' />
                                                            </td>
                                                            <td id="tdlblwhole_outcharge_inr" runat="server" align="Right">
                                                                <asp:Label ID="lblwhole_outcharge_inr" runat="server" Text='<%#Eval("whole_outchargeINR") %>' />
                                                            </td>
                                                            <%--Total--%>
                                                            <td align="right">
                                                                <asp:Label ID="lbltot_outchargefx" runat="server" Text='<%#Eval("totaloutfx") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltot_outchargeINR" runat="server" Text='<%#Eval("totaloutinr") %>' />
                                                            </td>
                                                            <%--Revenue--%>
                                                            <td id="tdlblrevinvoiceamount" runat="server" align="Right">
                                                                <asp:Label ID="lblrevinvoiceamount" runat="server" Text='<%#Eval("revinvoiceamount") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblrevinvoiceamountinr" runat="server" Text='<%#Eval("invoiceamountinr") %>' />
                                                            </td>
                                                            <td id="tdlbltotalbilling" runat="server" align="Right">
                                                                <asp:Label ID="lbltotalbilling" runat="server" Text='<%#Eval("totalbilling") %>' />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotalbillinginr" runat="server" Text='<%#Eval("totalbillinginr") %>' />
                                                            </td>
                                                            <td id="tdlblgrossrevinr" runat="server" align="Right">
                                                                <asp:Label ID="lblgrossrevinr" runat="server" Text='<%#Eval("grosrevinr") %>' />
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:Label ID="lblgrandtot" runat="server" Text="Grand Total" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinvoiceamountot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinvoiceamouninrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td id="tdcdramtfooter" runat="server" align="Right">
                                                                <asp:Label ID="lblcdramounttot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblcdramountinrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblfxtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblgaptot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <%--<asp:Label ID="Label1" runat="server" Font-Bold="true" />--%>
                                                            </td> 
                                                            <td align="right">
                                                                <%--<asp:Label ID="Label1" runat="server" Font-Bold="true" />--%>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbllinestot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_inchargetot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_outchargetot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_incharge_inrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblret_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbllineswhstot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_inchargetot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_outchargetot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_incharge_inrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblwhole_outcharge_inrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltot_outchargefxtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltot_outchargeINRtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblrevinvamount" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblrevinvamountinr" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotalbilltot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotalbillinrtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                            <td id="tdlblgrossrevINRtot" runat="server" align="right">
                                                                <asp:Label ID="lblgrossrevINRtot" runat="server" Font-Bold="true" />
                                                            </td>
                                                        </tr>
                                                        </thead> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                           </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
