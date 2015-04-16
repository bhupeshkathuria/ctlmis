<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmcountrywisebillingdashboard.aspx.cs" Inherits="MISReport_frmcountrywisebillingdashboard" %>

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
        function callreportcalltype(countryid, month,year,cntname, mevel) {
            window.open("frmcountrywisebillingdashboard.aspx?countryid=" + countryid + "&month=" + month + "&year=" + year + "&countryname=" + cntname + "&level=" + mevel, '_self', false);


        }
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
     <script type="text/javascript" language="JavaScript" src="../FusionCharts/FusionCharts.js"></script>
      <script type="text/javascript" language="JavaScript">

          function myJS(myVar) {
              window.alert(myVar);
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
                <asp:Panel ID="pnlsearch" runat="server">
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
                            <asp:DropDownList ID="ddlreport" runat="server"  OnSelectedIndexChanged="ddlreport_SelectedIndexChanged">
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
                    </asp:Panel>
                </td>
            </tr>
              <tr>
            <td>
            <asp:Label ID="lbllevel" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlCountryWise" runat="server" Visible="false">
                        <table width="100%" cellpadding="5px" cellspacing="0">
                            <tr>
                                <td>
                                   <fieldset>
                                   <legend>Graph</legend>
                                   <div id="div" runat="server"  style="width: 1200px; height:auto; overflow-x: scroll; overflow-y: hidden;">
                                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                                    </div>
                                    <div id="chart_div">
                                    </div>
                                   </fieldset>
                                   
                                    
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="left" style="padding-left: 30px; border: 1;">
                                  <fieldset>
                                  <legend>
                                  Summary
                                  </legend>
                                  <asp:GridView ID="grdcountry" runat="server" AllowSorting="true" CssClass="grd-header"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" OnSorting="grdcountry_Sorting">
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
                                  </fieldset>
                                    
                                    <%-- </div>--%>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
          
            <tr>
                <td class="style1">
                    <asp:Panel ID="pnlsalewise" runat="server" Visible="false">
                       <%-- <div id="picchart" runat="server">
                            <asp:Chart ID="WebChart1" runat="server">
                                <Titles>
                                    <asp:Title ShadowOffset="3" Name="Items" />
                                </Titles>
                                <Legends>
                                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                        LegendStyle="Row" />
                                </Legends>
                            </asp:Chart>
                        </div>--%>
                        <table>
                        <tr>
                        <td valign="top">
                        <fieldset>
                        <legend>
                        Summary
                        </legend>
                        <div>
                            <asp:GridView ID="grdPackage" runat="server"  CellPadding="4"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" 
                                AutoGenerateColumns="true" OnDataBound="grdPackage_DataBound1" 
                                onrowdatabound="grdPackage_RowDataBound">
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
                        </div>
                        </fieldset>
                        
                        </td>
                        <td valign="top">
                        <fieldset>
                     <legend>Graph</legend>   

                     <asp:Literal ID="lpservice" runat="server"></asp:Literal>
                                    <div id="divservice">
                                    </div>
                        </fieldset>
                        
                         
                        </td>
                        </tr>
                        </table>
                        
                        
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
