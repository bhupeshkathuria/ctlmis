<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CDR_Contractrpt.aspx.cs" Inherits="CDR_Contractrpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style>
.table-area{ width:780px; height:auto; margin:15px auto;}
.table-area table{ width:100%; height:auto; border:1px solid #e6e6e6; text-align:left; line-height:18px;border-collapse:collapse;}
.table-area th{ background:url(../images/rpt1.jpg) repeat-x; color:#666; font:bold 11px Verdana; height:20px;}
.table-area td{ background:#fbfbfb; height:20px; padding-left:10px; border:1px solid #e1e1e1; border-collapse:collapse; font:normal 11px Verdana; color:#6c6c6c; padding:0px 0 0px 5px;}
.table-area td input{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; }
.table-area td textarea{ font:normal 11px Verdana; color:#6c6c6c; height:60px !important; width:250px; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; margin:5px 0 }
.table-area td select{ font:normal 11px Verdana; color:#6c6c6c; height:24px !important; padding:2px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px 0 0 4px; background:url(../images/patt.jpg) repeat; }

.table-area td input[type="checkbox"]{ font:normal 11px Verdana; color:#6c6c6c; height:15px !important; width:15px; border:1px solid #d3d3d3; margin-top:10px;}
.table-area .g-btn{ width:60px !important; height:24px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area table a{ font:normal 11px Verdana; text-decoration:none; color:#FF0000;}
.table-area table a:hover{ font:normal 11px Verdana; text-decoration:underline; color:#FF0000;}
.table-area td table{ border:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">
        <asp:HiddenField ID="hdfcountry" runat="server" />
        <asp:HiddenField ID="hdfprovider" runat="server" />
        <asp:HiddenField ID="hdfcountryname" runat="server" />
        <asp:HiddenField ID="hdfprovidername" runat="server" />
        <table cellpadding="0" cellspacing="0" border="0px" width="1000px" align="center">
           <%-- <tr>
                <td>
                    <table cellpadding="0" align="center" cellspacing="0" width="50%" class="table-area">
                        <tr>
                            <td>
                                <h1>
                                    <b>Report</b></h1>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <table cellpadding="0" align="Center" cellspacing="0" width="70%" class="table-area">
                        <tr>
                            <td colspan="4" class="style1">
                                <b>Head Section</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Country:<span class="redtext">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcountry" runat="server" Width="150px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Networks:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlnetworks" Width="150px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Billing Month:
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
                            <td>
                            Selection Type:
                                
                            </td>
                            <td>
                            <asp:DropDownList ID="ddltype" Width="150px" runat="server">
                            <asp:ListItem Value=0>Both</asp:ListItem>
                            <asp:ListItem Value=1>Retail</asp:ListItem>
                            <asp:ListItem Value=2>Whs</asp:ListItem>
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        <td></td>
                        <td><asp:Button ID="btnSearch" Width="50px" runat="server" Text="Search" 
                                    onclick="btnSearch_Click" /></td>
                        <td><asp:Button ID="btnExport" Width="50px" runat="server" Text="Export" Visible="false" /></td>
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
                    <table cellpadding="0" align="center" cellspacing="0"  border="0" width="880px"  class="table-area">
                        <tr>
                            <td >
                            <%--<div id="tableHeader">style="table-layout: fixed; border:solid 1px black"
            </div>--%>
                            <asp:GridView ID="grdcontract" runat="server" AutoGenerateColumns="false" 
                                    ShowFooter="true" onrowdatabound="grdcontract_RowDataBound" 
                                    onrowcommand="grdcontract_RowCommand" AllowSorting="True"  Width="100%"
                                    onsorting="grdcontract_Sorting">
                                <Columns>
                                <asp:TemplateField HeaderText="Billing Month" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcdrdate" runat="server" Text='<%#Eval("cdrdate") %>'></asp:Label>
                                            
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CallType" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkcalltypename" runat="server" 
                                                Text='<%#Eval("calltypename") %>' CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ></asp:LinkButton>
                                            <%--<asp:Label ID="lblcalltypename" runat="server" Text='<%#Eval("calltypename") %>'></asp:Label>--%>
                                            <asp:Label ID="lblcalltypeid" runat="server" Text='<%#Eval("lcalltype") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotal" runat="server" Text ="Grand Total"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="IN Mintues" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblobillableunits" runat="server" Text='<%#Eval("obillable_units") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotobillableunits" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Right"/>
                                         <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Out Mintues" HeaderStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbillable_units" runat="server" Text='<%#Eval("billable_units") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotunits" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Right"/>
                                         <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Duration(sec)" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblduration" runat="server" Text='<%#Eval("duration") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotduration" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                         <ItemStyle HorizontalAlign="Right"/>
                                          <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CDR Cost" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprovidercost" runat="server" Text='<%#Eval("providercost") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotprovidercost" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contract Rate" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                           <asp:Label ID="lblcalltyperate" runat="server" Text='<%#Eval("calltyperate") %>'></asp:Label>
                                       
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotcalltyperate" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                         <ItemStyle HorizontalAlign="Right" />
                                          <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contract Amt" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                           <asp:Label ID="lblcontractamount" runat="server" Text='<%#Eval("contractamount") %>' ></asp:Label>
                                       
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotcontractamount" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                         <ItemStyle HorizontalAlign="Right"/>
                                          <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Difference" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDifference" runat="server" Text='<%#Eval("differnece") %>' ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        <asp:Label ID="lbltotDifference" runat="server"></asp:Label>
                                        </FooterTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                         <ItemStyle HorizontalAlign="Right"/>
                                         <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contribution(%)" HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContribution" runat="server"  Text='<%#Eval("contribution") %>'></asp:Label>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    </asp:TemplateField>
                                   
                                </Columns>
                               
                            </asp:GridView>
                              
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

