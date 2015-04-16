﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmDashboard.aspx.cs" Inherits="frmDashboard" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <table width="100%">
        <tr>
            <td width="50%">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" DisplayStatusbar="False" 
                    EnableDrillDown="False" GroupTreeStyle-BorderStyle="None" 
                    GroupTreeStyle-ShowLines="False" HasDrilldownTabs="False" Height="50px" 
                    Width="350px" />
            </td>           
        </tr>
    </table>
</div>
</asp:Content>
