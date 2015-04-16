<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CDR_contract_sub.aspx.cs" Inherits="CDR_invoicerpt_sub1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Revenue Audit</title>
   <%-- <link href="Css/Main.css" rel="stylesheet" type="text/css" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery.min.js" type="text/javascript"></script>
    <script src="JS/site.js" type="text/javascript"></script>
    <link href="Css/pop_up.css" rel="stylesheet" type="text/css" />--%>
    <style>
    .table-area{ width:780px; height:auto; margin:15px auto;}
.table-area table{ width:100%; height:auto; border:1px solid #e6e6e6; text-align:left; line-height:18px;border-collapse:collapse;}
.table-area th{ background:url(../images/rpt1.jpg) repeat-x; color:#666; font:bold 11px Verdana; height:20px;}
.table-area td{ background:#fbfbfb; height:20px; padding-left:10px; border:1px solid #e1e1e1; border-collapse:collapse; font:normal 11px Verdana; color:#6c6c6c; padding:0px 0 0px 5px;}
.table-area td input{ font:normal 11px Verdana; color:#6c6c6c; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; }
.table-area td textarea{ font:normal 11px Verdana; color:#6c6c6c; height:60px !important; width:250px; padding:1px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px; background:url(../images/patt.jpg) repeat; margin:5px 0 }
.table-area td select{ font:normal 11px Verdana; color:#6c6c6c; height:24px !important; padding:2px 2px 3px 2px; border:1px solid #d3d3d3;border-radius:4px 0 0 4px; background:url(../images/patt.jpg) repeat; }

.table-area td input[type="checkbox"]{ font:normal 11px Verdana; color:#6c6c6c; height:15px !important; width:15px; border:1px solid #d3d3d3; margin-top:10px;}
.table-area .g-btn{ width:60px !important; height:24px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area .g-btn1{ width:60px !important; height:20px !important; float:left; background:#ccc; margin:5px 0; cursor:pointer}
.table-area table a{ font:normal 11px Verdana; text-decoration:none; color:#FF0000;}
.table-area table a:hover{ font:normal 11px Verdana; text-decoration:underline; color:#FF0000;}
.table-area td table{ border:none;}
    </style>
    <style type="text/css">
    .f5-3{ background:#f5f5f5 !important}
    .f5-3 td{background:none}
    .eb-3{ background:#ebebeb !important}
    .eb-3 td{background:none}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div align="center">
     

        <table cellpadding="0" cellspacing="0" border="0px" width="100%" align="center" class="table-area">
            <tr>
                <td style="width: 700px;">
                    <table>
                        <tr>
                        <td>
                        <table>
                        <tr>
                       <td style="font-weight:bold;">
                       Call Type:
                       </td>                     
                        <td>
                        <asp:Label ID="lblcalltype" runat="server"></asp:Label>
                        </td>
                        <td style="font-weight:bold;">
                       Country:
                       </td>                     
                        <td>
                        <asp:Label ID="lblcountry" runat="server"></asp:Label>
                        </td>
                        <td style="font-weight:bold;">
                       Provider:
                       </td>                     
                        <td>
                        <asp:Label ID="lblprovider" runat="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <table>
                            <tr>
                            <td valign="top">
                               <%-- <div style="width: 1350px; overflow: auto; float: left; overflow-x: scroll; overflow-y: hidden;">--%>
                                        <asp:GridView ID="grdcontract" runat="server" AutoGenerateColumns="false" 
                                        ShowFooter="true" onrowdatabound="grdcontract_RowDataBound" AlternatingRowStyle-CssClass="eb-3"  
                                        >
                                    <Columns>
                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                            
                                            </ItemTemplate>

    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="calledno" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                      
                                                <asp:Label ID="lblcalledno" runat="server" Text='<%#Eval("calledno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text ="Grand Total" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>

    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CallDateTime" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcalldatetime" runat="server" Text='<%#Eval("calldatetime") %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                        

    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                            <ItemStyle HorizontalAlign="Left"/>
                                         
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblunit" runat="server" Text='<%#Eval("billableunit") %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                            <%--<FooterTemplate>
                                            <asp:Label ID="lbltotcdrcost" runat="server" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>--%>

    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                             <ItemStyle HorizontalAlign="Right"/>
                                              <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CDR Cost" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcdrcost" runat="server" Text='<%#Eval("providercost") %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lbltotcdrcost" runat="server" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>

    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                             <ItemStyle HorizontalAlign="Right"/>
                                              <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Provider Cost" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcalltyperate" runat="server" Text='<%#Eval("calltyperate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lbltotcalltyperate" runat="server" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Right"/>
                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DIfference" HeaderStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                               <asp:Label ID="lbldiffernece" runat="server" Text='<%#Eval("differnece") %>'></asp:Label>
                                       
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="lbltotdiffernece" runat="server" Font-Bold="true"></asp:Label>
                                            </FooterTemplate>

    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                             <ItemStyle HorizontalAlign="Right" />
                                              <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                  
                                   
                                    </Columns>
                               
                                </asp:GridView>
                                <%--</div>--%>

                                </td>
                                <td>
                                
                                                            
                       
                                </td>
                                </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                
            </tr>
        </table>
        <%--</ContentTemplate>--%>
        <%--  <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>--%>
        <%-- </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>
