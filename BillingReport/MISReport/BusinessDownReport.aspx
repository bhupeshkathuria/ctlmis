<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="BusinessDownReport.aspx.cs" Inherits="MISReport_BusinessDownReport" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; padding: 0px 0px 0px 0px">
        <table width="100%" cellpadding="5px" cellspacing="0">
            <tr>
                <td class="Header_text" align="left">
                    &nbsp;&nbsp;Financial Analysis Report
                </td>
                <td class="Header_text" align="right">
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Panel ID="trmanager" runat="server" Visible="true">
                        <table width="100%">
                            <tr>
                                <td style="height: 51px">
                                    <b>Select Criteria: </b>
                                    <asp:RadioButtonList ID="rdiobtnlst" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rdiobtnlst_SelectedIndexChanged">
                                        <asp:ListItem Value="1">By Month</asp:ListItem>
                                        <asp:ListItem Value="2">By Quarter</asp:ListItem>
                                        <asp:ListItem Value="3">By Semi Year</asp:ListItem>
                                        <asp:ListItem Value="4">By Year</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 51px">
                                    <b>Top: </b>
                                    <asp:DropDownList ID="ddlTop" runat="server">
                                        <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td>
                                    <b>Manager:</b>
                                    <telerik:RadComboBox ID="ddlManager" runat="server" Height="200px" Width="180px"
                                        EmptyMessage="Select Manager" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                        MarkFirstMatch="true" AllowCustomText="true" AutoCompleteSeparator=";">
                                    </telerik:RadComboBox>
                                   
                                </td>
                            </tr>--%>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trbymonth" runat="server" visible="false">
                <td colspan="2">
                    <fieldset style="width: 98%">
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlMonth1bymonth" runat="server">
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
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlYear1bymonth" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlMonth2bymonth" runat="server">
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
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlYear2bymonth" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                        </div>

                        
                        <div style="float: left">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr id="trbyquarter" runat="server" visible="false">
                <td colspan="2">
                    <fieldset style="width: 98%">
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlmonth1byquarter" runat="server">
                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Quarter1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Quarter2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Quarter3 " Value="3"></asp:ListItem>
                                <asp:ListItem Text="Quarter4" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear1byquarter" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlmonth2byquarter" runat="server">
                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Quarter1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Quarter2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Quarter3 " Value="3"></asp:ListItem>
                                <asp:ListItem Text="Quarter4" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear2byquarter" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            <asp:Button ID="btnseacrhbyquarter" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr id="trbysemiyear" runat="server" visible="false">
                <td colspan="2">
                    <fieldset style="width: 98%">
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlmonth1bysemi" runat="server">
                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Semi Year 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Semi Year 2" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear1bysemi" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Month&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlmonth2bysemi" runat="server">
                                <asp:ListItem Text="Select" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Semi Year 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Semi Year 2" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtCustomer" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp; Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear2bysemi" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr id="trbyyear" runat="server" visible="false">
                <td colspan="2">
                    <fieldset style="width: 98%">
                        <legend>Search</legend>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;Start Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear1byyear" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            &nbsp;&nbsp;&nbsp;End Year.&nbsp;</div>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlyear2byyear" runat="server">
                            </asp:DropDownList>
                            <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                            &nbsp;&nbsp;&nbsp;
                        </div>
                        <div style="float: left">
                            <asp:Button ID="Button3" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 400px; border: none;">
                    <telerik:RadGrid ID="RadGrid1New" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                        AllowPaging="false" AllowSorting="false" Width="350px" Visible="false" OnItemDataBound="RadGrid1New_ItemDataBound"
                        OnPageIndexChanged="RadGrid1New_PageIndexChanged" OnPageSizeChanged="RadGrid1New_PageSizeChanged"
                        OnSortCommand="RadGrid1New_SortCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="SrNo">
                                    <ItemTemplate>
                                        <%#Container.DataSetIndex + 1 %>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="customername" HeaderText="Customer" UniqueName="CustomerName"
                                    FooterText="Grand Total" />

                                <telerik:GridTemplateColumn HeaderText="Total Sale" UniqueName="salecount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsalecount" runat="server" Text='<% #(Eval("salecount")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblgrandtotalsalecount"></asp:Label>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderText="Low Sale Count" UniqueName="lowsalecount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbllowsalecount" runat="server" Text='<% #(Eval("lowsalecount")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblgrandtotallowsalecount"></asp:Label>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>

                                <%--<telerik:GridBoundColumn DataField="salecount" HeaderText="Total Sale" UniqueName="salecount">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="lowsalecount" HeaderText="Low Sale Count" UniqueName="lowsalecount">
                                </telerik:GridBoundColumn>


                                <telerik:GridTemplateColumn HeaderText="Amount" UniqueName="totalamount1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount1" runat="server" Text='<% #(Eval("lowsalecount")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label runat="Server" ID="lblgrandtotal" Text="D"></asp:Label>
                                        <asp:Label runat="Server" ID="lbltotal" Text="S"></asp:Label>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
