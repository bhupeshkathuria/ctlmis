<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NetworkWisePurchase.aspx.cs" Inherits="Finance_NetworkWisePurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
function validdate() {
    var fromyear, toyear;   

        if (document.getElementById('<%=ddlType.ClientID%>').value == "") {
            alert("Select Report Type !");
            document.getElementById('<%=ddlType.ClientID%>').focus();
            return false;
        }
        if (document.getElementById('<%=ddlNetwork.ClientID%>').value == 0) {
            alert("Select Network !");
            document.getElementById('<%=ddlNetwork.ClientID%>').focus();
            return false;
        }
        if (document.getElementById('<%=ddlfromyear.ClientID%>').value == 0) {
            alert("Please select from Year!");
            document.getElementById('<%=ddlfromyear.ClientID%>').focus();
            return false;
        }
        else {
            fromdt = document.getElementById('<%=ddlfromyear.ClientID%>').value
        }
        if (document.getElementById('<%=ddlToYear.ClientID%>').value == 0) {
            alert("Please select To Year!")
            document.getElementById('<%=ddlToYear.ClientID%>').focus();
            return false;
        }
        else {
            todt = document.getElementById('<%=ddlToYear.ClientID%>').value;
        }
        if (fromdt > todt) {
            alert("To Year can't be less than from Year");
            return false;
        }
        return true;
    }
 </script>
<div>

    Purchase/Payment - By Network : <br /><br />

    Type : <asp:DropDownList ID="ddlType" runat="server">
    <asp:ListItem Value="" Selected="True">----Select----</asp:ListItem>
    <asp:ListItem Value="0">Purchase</asp:ListItem>
    <asp:ListItem Value="1">Payment</asp:ListItem>
    </asp:DropDownList>
    Network : <asp:DropDownList ID="ddlNetwork" runat="server"></asp:DropDownList>&nbsp;&nbsp;
    From Year : <asp:DropDownList ID="ddlfromyear" runat="server"></asp:DropDownList>&nbsp;&nbsp;
    To Year : <asp:DropDownList ID="ddlToYear" runat="server"></asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="cmdSearch" Text="Search" runat="server" 
        onclick="cmdSearch_Click" OnClientClick="return validdate()"/>
</div>
<br />
<div>
    <asp:GridView ID="grdPurchase" runat="server" AutoGenerateColumns="false" 
        Width="1024px">
        <Columns>        
        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Left">
            
            <ItemTemplate>
                <asp:Label ID="lblYear" runat="server" Text='<%# Eval("TransYear").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Jan" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblJan" runat="server" Text='<%# Eval("Jan").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Feb" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblFeb" runat="server" Text='<%# Eval("Feb").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Mar" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblMar" runat="server" Text='<%# Eval("Mar").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Apr" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblApr" runat="server" Text='<%# Eval("Apr").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="May" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblMay" runat="server" Text='<%# Eval("May").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Jun" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblJun" runat="server" Text='<%# Eval("Jun").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Jul" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblJul" runat="server" Text='<%# Eval("Jul").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Aug" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblAug" runat="server" Text='<%# Eval("Aug").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Sep" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblSep" runat="server" Text='<%# Eval("Sep").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Oct" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblOct" runat="server" Text='<%# Eval("Oct").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Nov" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblNov" runat="server" Text='<%# Eval("Nov").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Dec" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblDec" runat="server" Text='<%# Eval("Dec").ToString()%>'></asp:Label>               
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
</div>
</asp:Content>

