<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Rpt_SaleComparission.aspx.cs" Inherits="Rebelfone_Rpt_SaleComparission" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div style="z-index: 100; position: absolute; top: 40%; left: 40%;">
                <img alt="" src="../Images/loading.gif" style="width: 100px; height: 98px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<div align="center" style="border: 1px solid #000;padding-bottom:5px;padding-top:5px" >


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
    </asp:UpdatePanel>
</asp:Content>

