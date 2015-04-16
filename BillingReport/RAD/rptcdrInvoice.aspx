<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rptcdrInvoice.aspx.cs" Inherits="Techscoot_rptdailysale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>


.record-search{width:70%; height:auto; font-family:'Proxima Nova', 'Helvetica Neue', Helvetica, Arial, sans-serif; color:#666; line-height:26px}
.record-search input{ width:120px; height:20px !important; border:1px solid #999; background:#f8f8f8; color:#999; padding:2px 5px}
.report-date input{ width:120px; height:18px !important; border:1px solid #999; background:#f8f8f8; color:#999; padding:2px 5px}
.g-btn input[type="submit"]{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat;}
.record-search .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.record-result{width:98%; height:auto; font-family:'Proxima Nova', 'Helvetica Neue', Helvetica, Arial, sans-serif; color:#666; margin:15px 0 0 0}
.record-result table{ color:#666; border-collapse:collapse}
.record-result th{ border:none; color:#fff; border-collapse:collapse; background:#b9b9b9; height:25px; line-height:25px; padding:0 5px}
.record-result td{ border:1px solid #B8B6B6; border-collapse:collapse; color:#666; height:22px; padding:2px 5px; font-size:13px}
.force-right{ text-align:right !important}
.force-right-spn{ float:right !important} 
.force-left{ text-align:left !important} 


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="70%">
                    <tr>
                     <td>
                        Provider:
                        </td>
                        <td class="tbl-grd">
                        <asp:DropDownList ID="ddlnetworks" Width="150px" runat="server">
                                            </asp:DropDownList>
                        </td>
                        <td>
                            From Date:
                        </td>
                        <td class="report-date">
                       <%--     <asp:TextBox ID="txtfromdate" runat="server" Width="150px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate">
                            </asp:CalendarExtender>--%>
                            <asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox><span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="img1" /></span>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="yyyy-MM-dd" PopupButtonID="img1">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txtfromdate"
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            To Date:
                        </td>
                        <td class="report-date">
                         <asp:TextBox ID="txttodate" runat="server"></asp:TextBox><span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgto" /></span>
                                <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txttodate"
                                    Format="yyyy-MM-dd" PopupButtonID="imgto">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="reqtxtStartDate" runat="server" ValidationGroup="Report"
                                    ForeColor="Red" ErrorMessage="Enter From Date" ControlToValidate="txttodate"
                                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                            <%--<asp:TextBox ID="txttodate" runat="server" Width="150px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate">
                            </asp:CalendarExtender>--%>
                        </td>
                        <td class="g-btn">
                           <%-- <asp:LinkButton ID="lnksearch" runat="server" CssClass="submit-lead" OnClick="lnksearch_Click">Search</asp:LinkButton>--%>
                            <asp:Button ID="lnksearch" Width="50px" runat="server" Text="Search" ValidationGroup="Report" OnClick="lnksearch_Click" />
                             <asp:CompareValidator ID="cmptxtEndDate" runat="server" SetFocusOnError="true" ErrorMessage="Date Range is not valid!!!"
                                    ValidationGroup="Report" ForeColor="Red" ControlToValidate="txttodate" ControlToCompare="txtfromdate"
                                    Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                        </td>
                       
                        <td class="g-btn">
                           <asp:Button ID="btnExport" Width="50px" runat="server" Text="Export" Visible="false"   OnClick="btnExport_Click" />
                          <%--  <asp:LinkButton ID="btnExport" runat="server" CssClass="table-area" Visible="false"
                                OnClick="btnExport_Click">Export</asp:LinkButton>--%>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="center">
                            <asp:GridView ID="grdcard" runat="server" CssClass="record-result" AutoGenerateColumns="False"
                                Width="100%" EmptyDataText="No Record" ShowFooter="True" 
                                OnRowDataBound="grdcard_RowDataBound" 
                                onpageindexchanging="grdcard_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Group" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgroupname" runat="server" Text='<%#Eval("groupname") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                        <FooterStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
                                   <%-- <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreatedon" runat="server" Text='<%#Eval("createdon") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="Provider" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprovider_name" runat="server" Text='<%#Eval("provider_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("countryname") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="CDRExpectedDay" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblactualUploadCDRDay" runat="server" Text='<%#Eval("actualUploadCDRDay") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CDRReceive" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcdrstatus" runat="server" Text='<%#Eval("cdrstatus") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="CDRDate" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="force-left" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblcdrdate" runat="server" Text='<%#Eval("cdrdate") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <%--<FooterTemplate>
                                            <asp:Label ID="lbltotal" Font-Bold="true" runat="server" CssClass="force-right-spn"></asp:Label>  CssClass="force-right-spn"
                                        </FooterTemplate>--%>
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="InvoiceReceive" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvoiceReceiveStatus" runat="server" Text='<%#Eval("invoiceReceiveStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="InvoiceRecieveDate" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvoiceRecieveDate" runat="server" Text='<%#Eval("invoiceRecieveDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="InvoiceUploadDate" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="force-left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvoiceUplodedDate" runat="server" Text='<%#Eval("invoiceUplodedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
</asp:Content>

