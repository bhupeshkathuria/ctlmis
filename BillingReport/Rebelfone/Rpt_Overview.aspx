<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Rpt_Overview.aspx.cs" Inherits="Rebelfone_Rpt_Overview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div style="z-index: 100; position: absolute; top: 40%; left: 40%;">
                <img alt="" src="../Images/loading.gif" style="width: 100px; height: 98px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div align="center" style="border: 1px solid #000; padding-bottom: 5px; padding-top: 5px">
                <div align="center" style="border: 1px solid #000; width: 95%">
                    <table align="center">
                        <tr>
                            <td align="right">
                                &nbsp; Select : Month:&nbsp;
                                <asp:DropDownList ID="drpMonth" runat="server">
                                    <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                    <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;Year:<asp:DropDownList ID="drpYear" runat="server">
                                    <asp:ListItem>2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem >2013 </asp:ListItem>
                                    <asp:ListItem  Selected="True">2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Daily Sale" OnClick="btnSubmit_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                From Year
                            </td>
                            <td>
                                <asp:DropDownList ID="drpYearCompare1" runat="server">
                                    <asp:ListItem>2009 </asp:ListItem>
                                    <asp:ListItem Selected="True">2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem>2013 </asp:ListItem>
                                    <asp:ListItem >2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>To Year
                            </td>
                            <td>
                             <asp:DropDownList ID="drpYearCompare2" runat="server">
                                    <asp:ListItem>2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem>2013 </asp:ListItem>
                                    <asp:ListItem  Selected="True">2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            <asp:Button ID="btmYearWise" runat="server" Text="Sale Compare" 
                                    onclick="btmYearWise_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Width="950px" Height="400px" ToolPanelView="None"  />
                               
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />--%>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:PostBackTrigger ControlID="btmYearWise" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
