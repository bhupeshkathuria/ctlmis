<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="frmapproval0.aspx.cs" Inherits="ErpReports_frmapproval0" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript">
        function calldetails(reqno, requisitionid) {
            window.open("frmapproval1.aspx?reqno=" + reqno + "&requisitionid=" + requisitionid);
        }
    </script>
    <script language="javascript">
        function calldetails2(_fname, _poid) {
            window.open("../Download.aspx?fname=" + _fname + "&poid=" + _poid);
        }
    </script>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional"
            ChildrenAsTriggers="true">
            <ContentTemplate>
                <div style="text-align: center;">
                    <asp:UpdateProgress ID="UpdateProgressMain" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <center>
                                <div id="blur">
                                    &nbsp;</div>
                                <div style="position: absolute; z-index: 9999; vertical-align: middle; left: 465px;"
                                    id="progress">
                                    <img alt="" src="../Images/indicator.gif" /><span style="font-weight: bold; font-size: 15px">&nbsp;Processing&nbsp;please&nbsp;wait
                                        ........</span>
                                </div>
                            </center>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <table width="100%">
                    <%--<tr>
                        <td>
                            <strong>Request for Approval</strong>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td valign="bottom" class="style2">
                            Select Requisition Type:
                            <asp:DropDownList ID="ddlApprovalType" runat="server" AutoPostBack="true" Width="165px"
                                OnSelectedIndexChanged="ddlApprovalType_SelectedIndexChanged">
                                <asp:ListItem Text="Select Approval Type" Value="0"></asp:ListItem>
                                <%--<asp:ListItem Text="Price Approval" Value="1"></asp:ListItem>--%>
                                <asp:ListItem Text="PO Approval" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style2">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="Pending">Pending Application</asp:ListItem>
                                <asp:ListItem Value="Closed">Closed Application</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="grdRequest" runat="server" AutoGenerateColumns="False" Width="852px"
                                OnRowDataBound="grdRequest_RowDataBound" AlternatingRowStyle-BackColor="#f5f5f5"
                                HeaderStyle-BackColor="#b9b9b9" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="WhiteSmoke" />
                                <Columns>
                                    <asp:BoundField DataField="requisitionid" Visible="false" />
                                    <asp:TemplateField HeaderText="SNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSNo" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Requisition No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqNo" runat="server" Text='<%#Eval("requisitionnumber")%>' Visible="false"></asp:Label>
                                            <asp:LinkButton ID="lnkreqno" runat="server" Text='<%#Eval("requisitionnumber")%>'
                                                OnClick="lnkreqno_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Requisition Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqDate" runat="server" Text='<%#Eval("createdon")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PO No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpono" runat="server" Text='<%#Eval("ponumber")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Department" DataField="Department" />
                                    <asp:TemplateField HeaderText="Request By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqBy" runat="server" Text='<%#Eval("employeename")%>'></asp:Label>
                                            <asp:Label ID="lblRequisitionid" runat="server" Text='<%#Eval("requisitionid")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllaststatus" runat="server" Text='<%#Eval("laststatus")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Current Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcurrentstatus" runat="server" Text='<%#Eval("requisitionfinalstatus1")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Details" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblView" Text="View" runat="server" OnClick="lblView_Click" Visible="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="View Bill">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpoid" runat="server" Text='<%#Eval("poid")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblbillfilename" runat="server" Text='<%#Eval("billfilename")%>' Visible="false"></asp:Label>
                                            
                                            <asp:LinkButton ID="lblViewBill" Text="View" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Mail">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmailfilename" runat="server" Text='<%#Eval("mailfilename")%>' Visible="false"></asp:Label>
                                            
                                            <asp:LinkButton ID="lblViewMail" Text="View" runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <HeaderStyle BackColor="#B9B9B9" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
    </style>
</asp:Content>
