<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PLReport.aspx.cs" Inherits="Finance_PLReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<span><B>P/L Report</B></span>

<script type="text/javascript">
    function validdate() {
        var fromdt,todt;

        if (document.getElementById('<%=txtFromDt.ClientID%>').value == "") {
            alert("Please select from Date!");
            document.getElementById('<%=txtFromDt.ClientID%>').focus();
            return false;
        }
        else {
            fromdt = document.getElementById('<%=txtFromDt.ClientID%>').value
        }
        if (document.getElementById('<%=txtToDt.ClientID%>').value == "") {
            alert("Please select To Date!")
            document.getElementById('<%=txtToDt.ClientID%>').focus();
            return false;
        }
        else {
            todt = document.getElementById('<%=txtToDt.ClientID%>').value;
        }
        if (fromdt > todt) {
            alert("To Date can't be less than from date");
            return false;
        }
        return true;
    }
    function calldetails(ledgerid,ledgername,fromdt,todt) {
        window.open("PLReportBreakup.aspx?ledgerid=" + ledgerid + "&ledgername=" + ledgername + "&fromdt=" + fromdt + "&todt=" + todt,"_self");
    }
</script>
<div>
    From Date : <asp:TextBox ID="txtFromDt" runat="server"></asp:TextBox><span>
                                    <img alt="Calender" src="../Images/calender_icon.jpg" id="imgStartDate" /></span>
                                    <asp:CalendarExtender ID="clnStartDate" runat="server" TargetControlID="txtFromDt"
                                    Format="yyyy-MM-dd" PopupButtonID="imgStartDate">
                                </asp:CalendarExtender>
    To Date : <asp:TextBox ID="txtToDt" runat="server"></asp:TextBox>
     <img alt="Calender" src="../Images/calender_icon.jpg" id="imgEndDate" /></span>
                                    <asp:CalendarExtender ID="clnEndDate" runat="server" TargetControlID="txtToDt"
                                    Format="yyyy-MM-dd" PopupButtonID="imgEndDate">
                                </asp:CalendarExtender>
    <asp:Button ID="cmdSubmit" Text="Search" runat="server" OnClientClick="return validdate()"
        onclick="cmdSubmit_Click" />
</div>
<br />
<div>
    <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label> 
    <asp:GridView ID="grdPL" runat="server" AutoGenerateColumns="false" 
        Height="270px" Width="979px" onrowdatabound="grdPL_RowDataBound">
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    
    <Columns>        
        <asp:TemplateField HeaderText="Account">
            <ItemTemplate>
                <asp:Label ID="lblAccount" runat="server" Text='<%# Eval("Account").ToString()%>'></asp:Label>
                <asp:HiddenField ID="lblPAID" runat="server" Value='<%# Eval("PA_ID").ToString()%>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Balance" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
            <ItemTemplate>                
                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance","{0:N2}").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total","{0:N2}").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
</div>
</asp:Content>

