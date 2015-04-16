<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Rpt_Sim_CountryWise.aspx.cs" Inherits="Rebelfone_Rpt_Sim_CountryWise" %>

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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center" style="border: 1px solid #000; padding-bottom: 5px; padding-top: 5px">
                <div align="center" style="border: 1px solid #000; width: 850px">
                    <table align="center">
                        <tr>
                            <td align="right">
                                &nbsp; Select Month: Month:&nbsp;
                                <asp:DropDownList ID="drpMonth" runat="server">
                                    <asp:ListItem Text="Jan" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="Sep" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
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
                                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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
                                    <asp:ListItem>2014</asp:ListItem>
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
                                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                                    Width="950px" Height="400px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="btnSubmit" />
         <asp:PostBackTrigger ControlID="btmYearWise" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
