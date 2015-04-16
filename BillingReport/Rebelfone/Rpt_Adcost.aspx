<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Rpt_Adcost.aspx.cs" Inherits="Rebelfone_Rpt_Adcost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%">
       <div align="center">
        <div align="center" style="border: 1px solid #000; width: 650px">
                    <table align="center">
                        <tr>
                            <td align="right">
                               From Year:
                               
                               <asp:DropDownList ID="drpFrom" runat="server">
                                    <asp:ListItem Selected="True">2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem>2013 </asp:ListItem>
                                    <asp:ListItem >2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                               To Year:
                               
                               <asp:DropDownList ID="drpTo" runat="server">
                                    <asp:ListItem >2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem >2013 </asp:ListItem>
                                    <asp:ListItem Selected="True">2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" 
            Width="950px" Height="400px" ToolPanelView="None" />
         
            </div>
    </div>
</asp:Content>
