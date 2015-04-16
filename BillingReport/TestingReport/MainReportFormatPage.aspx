<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MainReportFormatPage.aspx.cs" Inherits="Report_MainReportFormatPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">
    function ValidYear() {
        if (document.getElementById('<%=drpFyear.ClientID %>').value == "Select Financial Year" || document.getElementById('<%=drpFyear.ClientID %>').value == "0") {
            alert("Please select financial year !");
            return false;
        }
    }
</script>

<div style="width:100%;">
    <table cellpadding="2" cellspacing="0">
        <tr>
            <td >
                    <asp:DropDownList ID="drpFyear" runat="server" CssClass="drop">
                        <%--<asp:ListItem Text="Select Financial Year" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Text="2009-2010" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2010-2011" Value="2"></asp:ListItem>
                        <asp:ListItem Text="2011-2012" Value="3"></asp:ListItem>
                        <asp:ListItem Text="2012-2013" Value="4"></asp:ListItem>
                         <asp:ListItem Text="2013-2014" Value="5"></asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            <td>
                <asp:DropDownList ID="drpMonth" runat="server" CssClass="drop">
                    <asp:ListItem Selected="True" Text="Select Month" Value="0"></asp:ListItem>
                     <asp:ListItem Value="1">Jan</asp:ListItem>
                     <asp:ListItem Value="2">Feb</asp:ListItem>
                     <asp:ListItem Value="3">Mar</asp:ListItem>
                     <asp:ListItem Value="4">Apr</asp:ListItem>
                     <asp:ListItem Value="5">May</asp:ListItem>
                     <asp:ListItem Value="6">Jun</asp:ListItem>
                     <asp:ListItem Value="7">Jul</asp:ListItem>
                     <asp:ListItem Value="8">Aug</asp:ListItem>
                     <asp:ListItem Value="9">Sep</asp:ListItem>
                     <asp:ListItem Value="10">Oct</asp:ListItem>
                     <asp:ListItem Value="11">Nov</asp:ListItem>
                     <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
               <asp:RadioButtonList ID="rbtnCustomerType" runat="server"  RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Text="Retail" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="Wholesale"></asp:ListItem>
               </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button  ID="btnSubmit" runat="server" Text="Show Report" Height="25px"  
                 CssClass="textbtn" onclick="btnSubmit_Click"  OnClientClick="return ValidYear()"/>
            </td>
             <td style="font-size:11px; font-family:Verdana; font-weight:bold; color:Red;" >
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
             </td>
        </tr>
    </table>
</div>


<asp:UpdatePanel ID="UdpWindow" runat="server">
    <ContentTemplate>
        <div  style="margin:0 0 0 0; padding:0 0 0 0; background-color:#ffffff;">
    <div id="divArea" style="width:100%; height:560px; border:0px solid black; "> 
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <telerik:RadWindow ID="RadWindowCountryWise"
                    VisibleOnPageLoad="true"
                    runat="server"
                    RestrictionZoneID="divArea"
                    Left="5px"
                    Top="0px"
                    Width="1220px"
                    Height="277px"
                    Title="Country Wise Contribution"
                    VisibleStatusbar="false"            
                    AutoSize="false" Behaviors="Maximize,Resize,Move"  >
                </telerik:RadWindow>
        </tr>

        <tr>
            <td>
                <telerik:RadWindow
                    ID="RadWindowSegmentBranchWise"
                    VisibleOnPageLoad="true"
                    runat="server"
                    RestrictionZoneID="divArea"
                    Left="5px"
                    Top="280px"
                    Width="1220px"
                    Height="277px"
                    Title="Branch Wise Contribution"
                    VisibleStatusbar="false"
                    AutoSize="false" Behaviors="Maximize,Resize,Move">            
            </telerik:RadWindow>
            </td>
        </tr>

    </table>

    </div>
</div>
    </ContentTemplate>
</asp:UpdatePanel>



</asp:Content>

