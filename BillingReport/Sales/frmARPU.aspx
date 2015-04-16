<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmARPU.aspx.cs" Inherits="Sales_frmARPU" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link rel="stylesheet" href="../Css/colour.css" type="text/css" media="screen" charset="utf-8" />
    <asp:UpdatePanel ID="updPnl1" runat=server>
        <ContentTemplate>
            <div style="width: 100%; padding-top: 5px;">
        <asp:Label ID="lblMsg" Visible="false" runat="server" ForeColor="Red"></asp:Label>
        <b>
            <asp:Label ID="lblMonth" runat="server"></asp:Label>
        
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="ddlYear" 
            ErrorMessage="Select Year" Operator="NotEqual" ValueToCompare="--" 
            Display="None"></asp:CompareValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" 
            ControlToValidate="ddlMonth" 
            ErrorMessage="Select Month" Operator="NotEqual" ValueToCompare="--" 
            Display="None"></asp:CompareValidator>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ShowSummary="False" />
        
        </b>
        <table cellpadding="3" cellspacing="0" style="border: 1px solid Black; width: 70%;">
            <tr>
                <td>
                    Select Year:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    Select Month:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
            </tr>            
            <tr>
                <td>
                    Select Criteria:<span style="color: Red"></span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRepType" runat="server" ValidationGroup="Report" Width="135px">
                    <asp:ListItem Text="--Select All--" Value=0></asp:ListItem>
                    <asp:ListItem Text="By Country" Value=1>By Country</asp:ListItem>
                    <asp:ListItem Text="By Branch" Value=2>By Branch</asp:ListItem>
                    <asp:ListItem Text="By Employee" Value=3></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="chkCompare" Text="Compare with" runat="server" 
                        oncheckedchanged="chkCompare_CheckedChanged" AutoPostBack=true/>
                    <asp:DropDownList ID="ddlCompMonth" runat="server" Width="135px" 
                        Enabled="False">
                    </asp:DropDownList>&nbsp;&nbsp;<asp:DropDownList ID="ddlCompYear" 
                        runat="server" Width="135px" Enabled="False">
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdFind" runat="server" Text="Search" OnClick="cmdFind_Click" />&nbsp;&nbsp;<asp:Button ID="cmdExport" runat="server" Text="Export to Excel" OnClick="cmdExport_Click" />
                </td>
            </tr>
            <%--<tr>
                <td>
                    Select Country:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td>
                    Select Branch:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBranch" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Select Employee:<span style="color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmployee" runat="server" ValidationGroup="Report" Width="135px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" visible="false"/>
                </td>
            </tr>--%>
        </table>
        <br />
        <br />
        <table cellpadding="3" cellspacing="0" style="border: 1px solid Black; width: 70%;">
            <tr>
                <td align="center">
                    <asp:GridView ID="grdview1" runat="server" Width="100%" AutoGenerateColumns="true"
                        AllowSorting="True" HeaderStyle-Wrap="false" ShowFooter="True" HeaderStyle-ForeColor="ActiveCaption"
                        RowStyle-Font-Names="Arial" FooterStyle-ForeColor="ActiveCaption" 
                        FooterStyle-Font-Bold="true" HorizontalAlign="Center" 
                        onrowdatabound="grdview1_RowDataBound" onsorting="grdview1_Sorting"
                         >
                        <%--<Columns>
                            <asp:BoundField HeaderText="Total Sale" DataField="totalsale1"  >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                            
                            <asp:TemplateField HeaderText="Total Billing">
                                <ItemTemplate>
                                <asp:Label ID="lblTotalBilling" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ARPU">
                                <ItemTemplate>
                                    <asp:Label ID="lblARPU" runat="server"></asp:Label>
                                    <asp:Label ID="lblsale" runat="server" Visible="false" Text='<%#Eval("totalsale1") %>'></asp:Label>
                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>                            
                        </Columns>--%>

                        <AlternatingRowStyle HorizontalAlign="Center" />
                        
                        <EditRowStyle HorizontalAlign="Center" />

<FooterStyle Font-Bold="True" ForeColor="ActiveCaption"></FooterStyle>

                        <HeaderStyle HorizontalAlign="Center" />
                        <PagerSettings Position="Top" />
                        <RowStyle CssClass="text_box" HorizontalAlign="Center" />
                        
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
