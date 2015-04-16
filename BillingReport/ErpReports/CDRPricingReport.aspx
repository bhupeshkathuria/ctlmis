<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CDRPricingReport.aspx.cs" Inherits="ErpReports_CDRPricingReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type="text/javascript">
        function ValidInvoiceDetails() {
            if (document.getElementById('<%=drpCountry.ClientID %>').value == "Select Country" || document.getElementById('<%=drpCountry.ClientID %>').value == "0") {
                alert("Please select Country !");
                return false;
            }

            if (document.getElementById('<%=drpYear.ClientID %>').value == "Select Year" || document.getElementById('<%=drpYear.ClientID %>').value == "0") {
                alert("Please select Year !");
                return false;
            }

            if (document.getElementById('<%=drpMonth.ClientID %>').value == "Select Month" || document.getElementById('<%=drpMonth.ClientID %>').value == "0") {
                alert("Please select Month !");
                return false;
            }
        }
</script>

    <div style="width:100%; padding-top:2px;" align="center">
    <table cellpadding="3" cellspacing="0"  style="border:1px Solid #B6B7BC">
        <tr>
            <td colspan="8" align="center" style="border-bottom:1px Solid #B6B7BC">
                <strong>CDR Pricing Details </strong>
            </td>
        </tr>
        <tr>
            <td>Select Country :</td>
            <td >
                <asp:ObjectDataSource ID="OdsBindCountry" runat="server" TypeName="ClayBillingLibrary.ErpReports.HigestInvoiceLab" SelectMethod="GetCountry">
                </asp:ObjectDataSource>
                <asp:DropDownList ID="drpCountry" runat="server" CssClass="drop" AutoPostBack="false">
                    <asp:ListItem Text="Select Country" Selected="True" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>Select Year :</td>
            <td >
                <asp:DropDownList ID="drpYear" runat="server" CssClass="drop">
                </asp:DropDownList>
            </td>
            <td>Select Month :</td>
            <td >
                <asp:DropDownList ID="drpMonth" runat="server" CssClass="drop">
                    <asp:ListItem Text="Select Month" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Value="1" Text="January"></asp:ListItem>
                    <asp:ListItem Value="2" Text="February"></asp:ListItem>
                    <asp:ListItem Value="3" Text="March"></asp:ListItem>
                    <asp:ListItem Value="4" Text="April"></asp:ListItem>
                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                    <asp:ListItem Value="6" Text="June"></asp:ListItem>
                    <asp:ListItem Value="7" Text="July"></asp:ListItem>
                    <asp:ListItem Value="8" Text="August"></asp:ListItem>
                    <asp:ListItem Value="9" Text="September"></asp:ListItem>
                    <asp:ListItem Value="10" Text="October"></asp:ListItem>
                    <asp:ListItem Value="11" Text="November"></asp:ListItem>
                    <asp:ListItem Value="12" Text="December"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button  ID="btnSubmit" runat="server" Text="Show Report" Height="25px"
                 CssClass="textbtn" onclick="btnSubmit_Click" OnClientClick="return ValidInvoiceDetails();"  />
            </td>
             
        </tr>
        <tr>
            <td colspan="7" align="center" style="font-size:11px; font-family:Verdana; font-weight:bold; color:Red;" >
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
             </td>
        </tr>
    </table>
</div>


<br />

<div align="center" style="width:100%;">
    <asp:ObjectDataSource ID="OdsBindCDrPricing" runat="server" TypeName="ClayBillingLibrary.ErpReports.HigestInvoiceLab" 
    SelectMethod="GetCRDPricingDetails" onselecting="OdsBindCDrPricing_Selecting" >
        <SelectParameters>
            <asp:Parameter Name="CountryId" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Year" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="Month" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <telerik:RadGrid ID="RadGridCDrPricingDetails" runat="server"  
        AllowPaging="false" AllowSorting="true" AutoGenerateColumns="false"
        AlternatingItemStyle-CssClass="RadGridItenFont" 
        HeaderStyle-CssClass="RadGridHeaderFont" Width="60%" FooterStyle-CssClass="RadGridHeaderFont"
        ItemStyle-CssClass="RadGridItenFont" 
        onitemdatabound="RadGridCDrPricingDetails_ItemDataBound">
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="true"  />
        </ClientSettings>
        <MasterTableView CommandItemDisplay="Top" ShowFooter="true">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="SrNo"> 
                    <ItemTemplate>
                        <%#Container.DataSetIndex +1 %>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
               <%-- <telerik:GridBoundColumn DataField="countryname" HeaderText="Country"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="yearval" HeaderText="Year"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="monthval" HeaderText="Month"></telerik:GridBoundColumn>--%>

                <telerik:GridBoundColumn DataField="calltypename" HeaderText="Call Type"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn HeaderText="Units">
                    <ItemTemplate>
                        <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("billable_units")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Label ID="lblFooterUnit" runat="server" ></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                </telerik:GridTemplateColumn>
                  <telerik:GridTemplateColumn HeaderText="Incoming Rate">
                    <ItemTemplate>
                        <asp:Label ID="lblIncommingRate" runat="server" Text='<%#Eval("inc_ciost")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Label ID="lblFooterIncomingRate" runat="server" ></asp:Label>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Outgoing Rate">
                    <ItemTemplate>
                        <asp:Label ID="lblOutGoingRate" runat="server" Text='<%#Eval("output_cost")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Right" />
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Label ID="lblFooterOutGoingrate" runat="server" ></asp:Label>
                    </FooterTemplate>
                </telerik:GridTemplateColumn>
               
            </Columns>
            <CommandItemTemplate>
                <div align="center" style="width:100%; font-family:Verdana; font-size:11px;">
                <table cellpadding="3" cellspacing="0" width="100%" style="height:30px" border="0">
                    <tr>
                        <td style="width:40%;font-family:Verdana; font-size:11px; font-weight:bold;">
                            <asp:Label ID="lblCountryName" runat="server" ></asp:Label>
                        </td>
                        <td style="width:20%;" class="RadGridHeaderFont" align="center">
                            CDR Pricing Details
                            
                        </td>
                        <td style="width:40%;font-family:Verdana; font-size:11px; font-weight:bold;" align="right">
                            <asp:Label ID="lblYearMonthname" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                </div>
            </CommandItemTemplate>
        </MasterTableView>
        

    </telerik:RadGrid>
</div>


</asp:Content>

