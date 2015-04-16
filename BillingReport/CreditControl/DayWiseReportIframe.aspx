<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DayWiseReportIframe.aspx.cs" Inherits="CreditControl_DayWiseReportIframe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sct" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="">
        <ProgressTemplate>
            <div align="center" style="position: absolute; top: 50%; left: 40%; text-align: center;
                z-index: 100002 !important">
                <img src="../Images/Loader.gif" style="vertical-align: middle" alt="" />
                Processing ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <div style="width: 100%; padding: 0px 0px 0px 0px;font:11px verdana;"">
                <table width="100%" cellpadding="5px" cellspacing="0">
                  <tr>
             <%--  <td colspan="2">--%>
                   <%-- Export To Excel:   <asp:ImageButton ID="imgexport" runat="server" ImageUrl="~/CreditControl/xls-icon.gif" OnClick="imgexport_Click" />--%>
                   <%-- </td>
                    </tr>--%>
                   <tr>
                   <td colspan="2">
                   
                   </td>
                   </tr>
                    <tr>
                    
                    <td valign="top" width="40%">
                    <fieldset style="width:250px">
                    <legend> <b><asp:Label ID="lblbname" runat="server"></asp:Label></b> &nbsp;&nbsp; &nbsp;  
                    </legend>
                    <asp:GridView ID="grddaywiserpt" runat="server" CellPadding="4" ForeColor="#333333" style="width:245px"
                            GridLines="None" AutoGenerateColumns="false" 
                            onrowcommand="grddaywiserpt_RowCommand" 
                            onrowdatabound="grddaywiserpt_RowDataBound" ShowFooter="true">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        <Columns>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                        <asp:Label ID="lbldate" Text='<%#Eval("AmountDate") %>' runat="server"></asp:Label>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Label ID="lbltotamttext" runat="server" Text="Grand Total"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                        <asp:Label ID="lblamt" Text='<%#Eval("cheque_amt") %>' runat="server"></asp:Label>
                        
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Label ID="lbltotamt" runat="server"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detail"  HeaderStyle-HorizontalAlign="Right">
                        
                        <ItemTemplate>
                        <asp:Label ID="lblmode" runat="server" Text='<%#Eval("paymentmodeid") %>' Visible="false"></asp:Label>
                        <asp:Label ID="lblbranchid" runat="server" Text='<%#Eval("branchid") %>' Visible="false"></asp:Label>
                        <asp:LinkButton ID="lnkvew" runat="server" Text="View" CommandArgument='<%#Eval("insertdatetime") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </fieldset>
                    </td>
                   
                    <td valign="top" align="left" style="padding-top:15px">
                    <%--<fieldset >
                    <legend><b><asp:Label ID="lbldate" runat="server"></asp:Label></b></legend>--%>
                      <asp:gridview id="grddetail"  runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AutoGenerateColumns="false"  ShowFooter="true"
                            onrowdatabound="grddetail_RowDataBound">
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <EditRowStyle BackColor="#999999" />
                          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#E9E7E2" />
                          <SortedAscendingHeaderStyle BackColor="#506C8C" />
                          <SortedDescendingCellStyle BackColor="#FFFDF8" />
                          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                          <Columns>
                              <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
                              <ItemTemplate>
                                <asp:Label ID="lblchequedate" runat="server" Text='<%#Eval("ChequeDate") %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left" />
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left">
                              <ItemTemplate>
                                <asp:Label ID="lblbankname" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left" />
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="ChequeNo" HeaderStyle-HorizontalAlign="Right">
                              <ItemTemplate>
                                <asp:Label ID="lblChequeNo" runat="server" Text='<%#Eval("ChequeNo") %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Right" />
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="Amount Date" HeaderStyle-HorizontalAlign="Left">
                              <ItemTemplate>
                                <asp:Label ID="lblamountDate" runat="server" Text='<%#Eval("AmountDate") %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                              <asp:Label ID="lbltotamttext" runat="server" Text="Grand Total"></asp:Label>
                              </FooterTemplate>
                              <FooterStyle HorizontalAlign="Right" />
                              </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Right">
                              <ItemTemplate>
                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                              </ItemTemplate>
                              <FooterTemplate>
                              <asp:Label ID="lbltotamt" runat="server"></asp:Label>
                              </FooterTemplate>
                              <FooterStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" />
                              </asp:TemplateField>
                          </Columns>
                      </asp:gridview>
                    <%--</fieldset>--%>
                    </td>
                    </tr>
                    
                                     </table>
                    </div>
   </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
