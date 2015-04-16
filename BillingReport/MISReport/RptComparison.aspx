<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RptComparison.aspx.cs" Inherits="MISReport_RptComparison" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="updrpt" runat="server">
        <ContentTemplate>
            <div style="width: 100%; padding: 0px 0px 0px 0px">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" align="left">
                            &nbsp;&nbsp;Financial Analysis Report
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="tabl-headings">
                                        <b>Select Billing Type: </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="radiobtnlstType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="radiobtnlstType_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Sales</asp:ListItem>
                                            <asp:ListItem Value="2">Billing</asp:ListItem>
                                            <asp:ListItem Value="3">ARPU</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td class="tabl-headings">
                                                    <asp:Panel ID="trmanager" runat="server" Visible="false">
                                                        <b>Select Criteria: </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rdiobtnlst" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="rdiobtnlst_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">By Month</asp:ListItem>
                                                        <asp:ListItem Value="2">By Quarter</asp:ListItem>
                                                        <asp:ListItem Value="3">By Semi Year</asp:ListItem>
                                                        <asp:ListItem Value="4">By Year</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr id="trmangerdrop" runat="server">
                                                <td>
                                                    <b>Manager:</b>
                                                    <telerik:RadComboBox ID="ddlManager" runat="server" Height="200px" Width="180px"
                                                        EmptyMessage="Select Manager" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                        MarkFirstMatch="true" AllowCustomText="true" AutoCompleteSeparator=";">
                                                    </telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr id="trarpucountry" runat="server" visible="false">
                                                <td>
                                                    <asp:DropDownList ID="ddlRepType" runat="server" ValidationGroup="Report" AutoPostBack="true"
                                                        Width="135px" OnSelectedIndexChanged="ddlRepType_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select All--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="By Country" Value="1">By Country</asp:ListItem>
                                                        <asp:ListItem Text="By Branch" Value="2">By Branch</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                    <br />
                                                    <asp:DropDownList ID="ddlcommon" runat="server" Width="135px" Visible="false" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                       </asp:Panel>
                                    </td>
                                </tr>
                                <tr id="trbymonth" runat="server" visible="false">
                                    <td>
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
                                                <%-- <asp:TextBox ID="txtRafNo" runat="server" Width="100px"></asp:TextBox>--%>
                                                &nbsp;&nbsp;&nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr id="trbyquarter" runat="server" visible="false">
                                    <td>
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
                                    <td>
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
                                    <td>
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
                                                &nbsp;&nbsp;&nbsp;To Year.&nbsp;</div>
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
                                    <td align="left">
                                        <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                        <!--class="int-tbl"-->
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 49%">
                                                    <telerik:RadGrid ID="RadGrid1New" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                                                        AllowSorting="false" Visible="false" OnItemDataBound="RadGrid1New_ItemDataBound"
                                                        OnPageIndexChanged="RadGrid1New_PageIndexChanged" OnPageSizeChanged="RadGrid1New_PageSizeChanged"
                                                        OnSortCommand="RadGrid1New_SortCommand" PageSize="12">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="SrNo">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataSetIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="orddate1" HeaderText="Month" UniqueName="date1"
                                                                    DataFormatString="{0:MMMM-yyyy}" FooterText="Grand Total" />
                                                                <%--<telerik:GridBoundColumn DataField="Totalsale1" HeaderText="Totalsale" UniqueName="column1"
                                         Aggregate="Sum" >                                       
                                       
                                    </telerik:GridBoundColumn>--%>
                                                                <telerik:GridTemplateColumn HeaderText="Amount" UniqueName="totalamount1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("Totalsale1"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblgrandtotal"></asp:Label>
                                                                        <asp:Label runat="Server" ID="lbltotal"></asp:Label>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>

                                                                
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td valign="top" style="width: 49%;">
                                                    <telerik:RadGrid ID="RadGrid2" CellPadding="0" runat="server" AutoGenerateColumns="false"
                                                        ShowFooter="True" AllowSorting="false" Visible="false" OnPageIndexChanged="RadGrid2_PageIndexChanged"
                                                        OnPageSizeChanged="RadGrid2_PageSizeChanged" OnItemDataBound="RadGrid2_ItemDataBound"
                                                        OnSortCommand="RadGrid2_SortCommand" PageSize="12">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="SrNo">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataSetIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="orddate2" HeaderText="Month" UniqueName="date2"
                                                                    DataFormatString="{0:MMMM-yyyy}" FooterText="Grand Total" />
                                                               
                                                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Amount" UniqueName="totalamount2">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("Totalsale2"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lbltotal"></asp:Label>
                                                                        <asp:Label runat="Server" ID="lblgrandtotal"></asp:Label>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                              
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 49%">
                                                    <telerik:RadGrid ID="RadGridYear1" runat="seRver" AutoGenerateColumns="false" ShowFooter="True"
                                                        AllowSorting="false" Visible="false" OnItemDataBound="RadGridYear1_ItemDataBound"
                                                        OnPageIndexChanged="RadGridYear1_PageIndexChanged" OnPageSizeChanged="RadGridYear1_PageSizeChanged"
                                                        OnSortCommand="RadGridYear1_SortCommand" PageSize="12">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="SrNo">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataSetIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="orddate1" HeaderText="Month" UniqueName="date1"
                                                                    DataFormatString="{0:MMMM-yyyy}" FooterText="Grand Total" />
                                                                <%--<telerik:GridBoundColumn DataField="Totalsale1" HeaderText="Totalsale" UniqueName="column1"
                                         Aggregate="Sum" >                                       
                                       
                                    </telerik:GridBoundColumn>--%>
                                                                <telerik:GridTemplateColumn HeaderText="Amount" UniqueName="totalamount1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("Totalsale1"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblgrandtotal"></asp:Label>
                                                                        <asp:Label runat="Server" ID="lbltotal"></asp:Label>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>

                                                                <telerik:GridTemplateColumn HeaderText="ServiceTax" UniqueName="servicetax1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblservicetax1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("servicetax1"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblservicegrandtotal"></asp:Label>
                                                                       <%-- <asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="CreditNote" UniqueName="creditnote1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreditnote1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("creditnote1"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblcreditgrandtotal"></asp:Label>
                                                                       <%-- <asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                 <telerik:GridTemplateColumn HeaderText="NetAmount" UniqueName="netamount1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblnetamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("netamount1"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblnetamountgrandtotal"></asp:Label>
                                                                        <%--<asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td valign="top" style="width: 49%;">
                                                    <telerik:RadGrid ID="RadGridYear2" CellPadding="0" runat="server" AutoGenerateColumns="false"
                                                        ShowFooter="True" AllowSorting="false" Visible="false" OnPageIndexChanged="RadGridYear2_PageIndexChanged"
                                                        OnPageSizeChanged="RadGridYear2_PageSizeChanged" OnItemDataBound="RadGridYear2_ItemDataBound"
                                                        OnSortCommand="RadGridYear2_SortCommand" PageSize="12">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridTemplateColumn HeaderText="SrNo">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataSetIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="orddate2" HeaderText="Month" UniqueName="date2"
                                                                    DataFormatString="{0:MMMM-yyyy}" FooterText="Grand Total" />
                                                               
                                                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="Amount" UniqueName="totalamount2">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblamount1" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("Totalsale2"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lbltotal"></asp:Label>
                                                                        <asp:Label runat="Server" ID="lblgrandtotal"></asp:Label>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="ServiceTax" UniqueName="servicetax2">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblservicetax2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("servicetax2"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblservicegrandtotal2"></asp:Label>
                                                                       <%-- <asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="CreditNote" UniqueName="creditnote1">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreditnote2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("creditnote2"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                     <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblcreditgrandtotal2"></asp:Label>
                                                                       <%-- <asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                 <telerik:GridTemplateColumn HeaderText="NetAmount" UniqueName="netamount2">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblnetamount2" runat="server" Text='<% #ConvertToMoneyFormat(Convert.ToString(Eval("netamount2"))) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                   <FooterTemplate>
                                                                        <asp:Label runat="Server" ID="lblnetamountgrandtotal2"></asp:Label>
                                                                        <%--<asp:Label runat="Server" ID="lbltotal"></asp:Label>--%>
                                                                    </FooterTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <td>
                                    <!--class="int-tbl"*-->
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td style="width: 49%">
                                                <telerik:RadGrid ID="grdview1" runat="seRver" AutoGenerateColumns="true" ShowFooter="True"
                                                    AllowSorting="false" Visible="false" PageSize="12" OnItemDataBound="grdview1_ItemDataBound"
                                                   >
                                                </telerik:RadGrid>
                                                <%--<asp:GridView ID="grdview1" runat="server"  Width="300px" AutoGenerateColumns="true"
                        AllowSorting="True" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                        RowStyle-Font-Names="Arial" FooterStyle-ForeColor="ActiveCaption" FooterStyle-Font-Bold="true"
                        HorizontalAlign="Center" onrowdatabound="grdview1_RowDataBound">
                        <AlternatingRowStyle HorizontalAlign="Center" />
                        <EditRowStyle HorizontalAlign="Center" />
                        <FooterStyle Font-Bold="True" ForeColor="ActiveCaption"></FooterStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                        <PagerSettings Position="Top" />
                        <RowStyle CssClass="text_box" HorizontalAlign="Center" />
                    </asp:GridView>--%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td style="width: 49%">
                                                <telerik:RadGrid ID="GridView2" runat="seRver" AutoGenerateColumns="true" ShowFooter="True"
                                                    AllowSorting="false" Visible="false" PageSize="12" OnItemDataBound="GridView2_ItemDataBound">
                                                </telerik:RadGrid>
                                                <%-- <asp:GridView ID="GridView2" runat="server"  Width="300px" AutoGenerateColumns="true"
                        AllowSorting="True" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                        RowStyle-Font-Names="Arial" FooterStyle-ForeColor="ActiveCaption" FooterStyle-Font-Bold="true"
                        HorizontalAlign="Center" onrowdatabound="GridView2_RowDataBound">
                        <AlternatingRowStyle HorizontalAlign="Center" />
                        <EditRowStyle HorizontalAlign="Center" />
                        <FooterStyle Font-Bold="True" ForeColor="ActiveCaption"></FooterStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                        <PagerSettings Position="Top" />
                        <RowStyle CssClass="text_box" HorizontalAlign="Center" />
                    </asp:GridView>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
