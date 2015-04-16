<%@ Page Title="Sale report" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="salesReport.aspx.cs" Inherits="PiccellReports_salesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <iframe src="https://my.piccellwireless.com/BillingSales/SalesReport.aspx" height="800px" 
        width="100%" frameborder="0"></iframe>
</asp:Content>

