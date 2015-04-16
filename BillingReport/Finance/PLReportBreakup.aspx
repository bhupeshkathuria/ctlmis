<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PLReportBreakup.aspx.cs" Inherits="Finance_PLReportBreakup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
    <b>PL Breakup Details :</b><br /><br />
    <b>Account :</b> <asp:Label ID="lblAccount" runat="server"></asp:Label>
    &nbsp;&nbsp;
    <b>From Date :</b> <asp:Label ID="lblFromDT" runat="server"></asp:Label>
    &nbsp;&nbsp;
    <b>To Date :</b> <asp:Label ID="lblToDate" runat="server"></asp:Label>
</div>
<br />
<div>
    <asp:GridView ID="grdVoucher" runat="server" AutoGenerateColumns="false" 
        Width="1001px"  >
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
             <asp:TemplateField HeaderText="Voucher Date" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Left">                
                <ItemTemplate>
                    <asp:Label ID="lblDocDate" runat="server" Text='<%# Eval("DOC_DATE").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Voucher ID" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Left">                
                <ItemTemplate>
                    <asp:Label ID="lblVoucherID" runat="server" Text='<%# Eval("POSTVCH_ID").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="POST ID" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPostID" runat="server" Text='<%# Eval("POST_ID").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dr" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblDRAmt" runat="server" Text='<%# Eval("DR_AMT").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cr" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="120px">
                <ItemTemplate>
                                    
                    <asp:Label ID="lblCRAmt" runat="server" Text='<%# Eval("CR_AMT","{0:N2}").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PartyName">
                <ItemTemplate>
                    <asp:Label ID="lblParty" runat="server" Text='<%# Eval("PA_Name").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("VCH_Remark").ToString()%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>

