<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CollectionReport.aspx.cs" Inherits="CreditControl_CollectionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 435px;
        }
        #IFrame1
        {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=ddlYear.ClientID%>').selectedIndex == 0) {
                alert("Please select year!!");
                return false;
            }
            if (document.getElementById('<%=ddlMonth.ClientID%>').selectedIndex == 0) {
                alert("Please select month!!");
                return false;
            }
            return true;
        }


        function callreport(month, year, mevel) {
            window.open("CollectionReport.aspx?month=" + month + "&year=" + year + "&level=" + mevel, '_self', false);
            document.getElementById('<%=IFrame1.ClientID %>').style.display = "block";
        }
        function calldailyreport(from, todate, mlevel) {

            document.getElementById('<%=IFrame1.ClientID %>').style.display = "block";
            document.getElementById('<%=IFrame1.ClientID %>').src = "Dailyrptifram.aspx?from=" + from + "&todate=" + todate;



        }

        function calldayreportbypaymentmode(branch, mode, month, year, branchname) {

            document.getElementById('<%=IFrame1.ClientID %>').style.display = "block";
            document.getElementById('<%=IFrame1.ClientID %>').src = "DayWiseReportIframe.aspx?month=" + month + "&year=" + year + "&branchid=" + branch + "&mode=" + mode + "&branchname=" + branchname;



        }
        
    </script>
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td colspan="2" width="60%">
                            <fieldset>
                                <legend>Search</legend>
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
                                <div style="float: left">
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
                                    &nbsp;&nbsp;&nbsp;Report Name:&nbsp;</div>
                                <div style="float: left">
                                    <asp:DropDownList ID="ddlreport" runat="server">
                                        <asp:ListItem Value="1">Selelct Report</asp:ListItem>
                                        <asp:ListItem Value="2">Daily Collection</asp:ListItem>
                                        <asp:ListItem Value="3">Source Wise</asp:ListItem>
                                        <%-- <asp:ListItem Value="4">DashBoard</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                                    &nbsp;&nbsp;&nbsp;
                                </div>
                                <div style="float: left">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return JSFunctionValidate()"
                                        OnClick="btnSearch_Click" />
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                    <tr id="trarjsted" runat="server" visible="false">
                        <td colspan="2">
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
                                                <asp:Label ID="lblcurrentmonthBilling1" runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b>
                                                <asp:Label ID="lblPreviousmonthBilling1" runat="server"></asp:Label></b>
                                        </td>                                      
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                     <tr id="trbilling" runat="server" visible="false">
                        <td colspan="2">
                            <fieldset>
                                <legend>Billing Summary :</legend>
                                <table cellpadding="0px" cellspacing="1px" border="0px" width="300px">
                                    <tr>
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
                        <td valign="top" align="left" style="padding-left: 30px; border: 1;">
                            <asp:GridView ID="grdcollection" runat="server" AllowSorting="true" OnRowCommand="grdcollection_RowCommand"
                                OnRowDataBound="grdcollection_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None" OnSorting="grdcollection_Sorting" ShowFooter="True">
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
                        <td valign="top" align="left">
                            <iframe id="IFrame1" runat="server" src="" width="600Px" height="400" style="display: none;">
                            </iframe>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
