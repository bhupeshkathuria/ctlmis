<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmcountrywisebillingdashboardold.aspx.cs" Inherits="MISReport_frmcountrywisebillingdashboard" %>

<%@ Register Src="~/ucGoogleBarChart.ascx" TagName="ucGoogleBarChart" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%--<script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>
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

    </script>
    <script type="text/javascript" src="../Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {

            gridView1 = $('.grd-header').gridviewScroll({

                width: 1200,
                height: 400,
                headerrowcount: 1,
                barsize: 8,
                railsize: 16,
                freezesize: 1

            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi "></script>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>--%>
    <div style="width: 100%; padding: 0px 0px 0px 0px; font: 11px verdana;">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td colspan="2">
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
                            <asp:DropDownList ID="ddlreport" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlreport_SelectedIndexChanged">
                                <asp:ListItem Value="1">Sale</asp:ListItem>
                                <asp:ListItem Value="2">Billing</asp:ListItem>
                                <asp:ListItem Value="3">Arpu</asp:ListItem>
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
            <tr>
                <td>
                  
                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                    <div id="chart_div">
                    </div>
                   
                </td>
            </tr>
            <tr>
                <td valign="top" align="left" style="padding-left: 30px; border: 1;">
                    <asp:GridView ID="grdcountry" runat="server" AllowSorting="true" CssClass="grd-header"
                        OnSorting="grdcountry_Sorting" CellPadding="4" ForeColor="#333333" GridLines="None"
                        ShowFooter="True" onrowdatabound="grdcountry_RowDataBound">
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
                    <%-- </div>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <%--  <uc2:ucGoogleBarChart 
            ID="ucGoogleBarChart1" 
            runat="server" ChartSize="500x400" 
            ChartColor="0000ff" 
            ChartBarSizeSpacing="75,10,20" 
            ChartBGFill="c,lg,90,76A4FB,0.5,ffffff,0|bg,s,EFEFEF" 
            ChartOrientationVertical="true" 
            ChartShowData="true" 
            ChartGridViewID="grdcountry" />--%>
                </td>
            </tr>
            <tr>
                <td class="style1">
                </td>
            </tr>
        </table>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
