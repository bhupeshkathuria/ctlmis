<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="rptYearWiseSaleBilling.aspx.cs" Inherits="MISReport_rptYearWiseSaleBilling" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/confirm.css" rel="stylesheet" type="text/css" />
    <link href="../_assets/css/jquery.contextMenu.css" rel="stylesheet" type="text/css" />
    <script src="../_assets/js/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="../_assets/js/jquery.simplemodal-1.1.1.js" type="text/javascript"></script>
    <script src="../_assets/js/jquery.contextMenu.js" type="text/javascript"></script>
    <style type="text/css">
        a
        {
            color: #000 !important;
            text-decoration: none;
        }
        a:hover
        {
            color: #333;
            text-decoration: none;
        }
        
        .customerRow
        {
        }
        .gvhide
        {
            display: none;
        }
        
        div#scroll  
        {
            border: 1px solid #C0C0C0;
            background-color: #F0F0F0;            
            overflow: scroll; 
            position: relative;
            left: 39px;
            top: 813px;
        }
    </style>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="updatePnl"
        style="width: 100%;">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 45%; left: 45%; text-align: center;">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <%--<asp:UpdatePanel ID="updatePnl" runat="server">
        <ContentTemplate>--%>
            <div style="width: 100%; padding: 0px 0px 0px 0px">
                <table width="100%" cellpadding="5px" cellspacing="0">
                    <tr>
                        <td class="Header_text" align="left">
                            &nbsp;&nbsp;Sale Billing Report Branch & Country Wise
                        </td>
                        <td class="Header_text" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 50px">
                            <table cellpadding="3px" cellspacing="1px" width="900px">
                                <tr>
                                                              
                                    <td>
                                        <strong>Year</strong>
                                    </td>
                                    <td align="left" style="height: 35px; color: Green">
                                        <asp:DropDownList ID="ddlFromYear" Width="100px" runat="server">
                                        </asp:DropDownList>
                                    </td>


                                    <td>
                                        <strong>Compare&nbsp;Year</strong>
                                    </td>
                                    <td align="left" style="height: 35px; color: Green">
                                        <asp:DropDownList ID="ddlCompareYear" Width="100px" runat="server">
                                        </asp:DropDownList>
                                    </td>

                                    <td>
                                        <strong>Report&nbsp;Type</strong></td>
                                    <td align="left" style="height: 15px; color: Green">
                                        <asp:DropDownList ID="ddlReportType" Width="170px" runat="server">
                                            <asp:ListItem Value="1" Text="Branch Wise"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Country Wise"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <strong>
                                        Compare<asp:CheckBox ID="chkCompare" runat="server" />
                                        </strong>
                                    </td>   
                                    <td align="left" style="font-weight: normal;" colspan="5">
                                        <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnExportExcel" runat="server" Text="Export" 
                                            onclick="btnExportExcel_Click"  />

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                            <asp:GridView ID="grdBranchWise" runat="server" ShowFooter="true" 
                                HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Gray" 
                                FooterStyle-ForeColor="White" FooterStyle-BackColor="Gray" 
                                onrowcreated="grdBranchWise_RowCreated" 
                                onrowdatabound="grdBranchWise_RowDataBound"  >
                                <FooterStyle Font-Bold="true" />
                            </asp:GridView>                            
                            <br />
                            <asp:GridView ID="grdCountryWiseRow" runat="server" ShowFooter="true" 
                                HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Gray" 
                                FooterStyle-ForeColor="White" FooterStyle-BackColor="Gray" 
                                onrowdatabound="grdCountryWiseRow_RowDataBound" >
                                <FooterStyle Font-Bold="true" />
                            </asp:GridView>
                            <br />
                            <asp:GridView ID="grdCountryWiseUsa" runat="server" ShowFooter="true" 
                                HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Gray" 
                                FooterStyle-ForeColor="White" FooterStyle-BackColor="Gray" 
                                onrowdatabound="grdCountryWiseUsa_RowDataBound">
                                <FooterStyle Font-Bold="true" />
                            </asp:GridView>
                            <br />
                            <asp:GridView ID="grdCountryWiseUk" runat="server" ShowFooter="true" 
                            HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Gray" 
                            FooterStyle-ForeColor="White" FooterStyle-BackColor="Gray"
                                onrowdatabound="grdCountryWiseUk_RowDataBound" >
                                <FooterStyle Font-Bold="true" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <table cellspacing="0px" cellpadding="0px" style="margin-bottom: 55px;">
                <tr>
                    <td>
                        <asp:Label ID="err" runat="server" ForeColor="Red" Font-Bold="true">
                        </asp:Label>
                    </td>
                </tr>
                <%--  <tr>
                    <td style="height: 20px" align="center">
                        <asp:Label ID="lblReportHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 40px" align="center">
                        <asp:Label ID="lblzoneHeader" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td style="width: 800px; border: none; padding-left: 50px">
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
