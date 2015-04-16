<%@ Page  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Title="Sale vs Revenue" CodeFile="salerevenue.aspx.cs" Inherits="PiccellReports_salerevenue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <iframe src="https://my.piccellwireless.com/BillingSales/salerevenuereport.aspx" height="100%" style="min-height:700px"
        width="100%" frameborder="0"></iframe>
</asp:Content>

