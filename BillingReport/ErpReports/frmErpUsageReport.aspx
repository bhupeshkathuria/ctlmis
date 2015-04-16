<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmErpUsageReport.aspx.cs" Inherits="ErpReports_frmErpUsageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        function Editpayment(link, id,fromdate,todate) {
            $(link).colorbox({ iframe: true, width: "68%", height: "75%", href: "frmLoginDetails.aspx?userId=" + id + "&from=" + fromdate + "&to=" + todate });
            // $.colorbox({ iframe: true, width: "68%", height: "75%", href: "frmPODetails.aspx?Id=" + id });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding-top: 5px;" align="center">
        <b>
            <asp:Label ID="lblMonth" runat="server"></asp:Label></b>
        <table width="99%" cellpadding="0" cellspacing="1px">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" style="border: 1px solid Black">
                        <tr>
                            <td>
                                From Date<span style="color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox><span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgStartDate" /></span>
                                <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txtFromDate"
                                    Format="yyyy-MM-dd" PopupButtonID="imgStartDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txtFromDate"
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                To Date<span style="color: Red">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgEndDate" /></span>
                                <asp:CalendarExtender ID="clnEndDate" runat="server" TargetControlID="txtToDate"
                                    Format="yyyy-MM-dd" PopupButtonID="imgEndDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="reqtxtEndDate" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter To Date" ControlToValidate="txtToDate" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="btnSerach" runat="server" Text="Search" OnClick="btnSerach_Click"
                                    ValidationGroup="Report" />
                                <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Range is not valid!!!"
                                    ValidationGroup="Report" ForeColor="Red" ControlToValidate="txtToDate" ControlToCompare="txtFromDate"
                                    Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnl1" runat="server" Width="100%">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <b>
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td align="center">
                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                    <asp:GridView ID="grdview1" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                        HeaderStyle-Wrap="true" AllowPaging="true" HeaderStyle-ForeColor="ActiveCaption"
                                        RowStyle-Font-Names="Arial" PageSize="20" 
                                        onpageindexchanging="grdview1_PageIndexChanging" Width="760px">
                                        <Columns>
                                            <%--<asp:BoundField DataField="employeename" HeaderText="Employee Name" />--%>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkemployee" runat="server" Font-Underline="false" Text='<%#Eval("employeename") %>' 
                                                        onmouseover='<%#"Editpayment(this,&#39;"+Eval("userid").ToString()+ "&#39;,&#39;"+Eval("firstlogin").ToString()+ "&#39;,&#39;"+Eval("lastlogout").ToString()+ "&#39;)" %>'></asp:LinkButton>
                                                    <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>' Visible="false" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="firstlogin" HeaderText="First Login" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField DataField="lastlogout" HeaderText="Last Logout" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField DataField="TotalTime" HeaderText="Total Time(hh:mm:ss)" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <RowStyle CssClass="text_box" />
                                        <PagerSettings Position="Top" Mode="Numeric" />
                                        <PagerStyle Width="200px" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
                    <Triggers  >
                    <asp:AsyncPostBackTrigger EventName="PageIndexChanging" ControlID="grdview1" />
                    </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
