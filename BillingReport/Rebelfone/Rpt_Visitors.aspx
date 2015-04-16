<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Rpt_Visitors.aspx.cs" Inherits="Rebelfone_Rpt_Visitors" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<%--<%@ Register Namespace="Telerik.QuickStart" TagPrefix="qsf" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi "></script>

   
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div style="z-index: 100; position: absolute; top: 40%; left: 45%;">
                <img alt="" src="../Images/loading.gif" style="width: 100px; height: 98px" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
          <%--  <div align="center" style="border: 1px solid #000;  padding-bottom: 5px; padding-top: 5px""  >
        <table align="center">
            <tr>
                <td>
                    <asp:Button ID="btnVisitor" runat="server" Text="No Of Visitors" 
                        onclick="btnVisitor_Click" />
                </td>
                <td>
                    <asp:Button ID="btnAdCost" runat="server" Text="Advertise Cost" 
                        onclick="btnAdCost_Click" />
                </td>
            </tr>
        </table>
    </div>--%>
    <div align="center">
     <div align="center" style="border: 1px solid #000; width: 650px">
                    <table align="center">
                        <tr>
                            <td align="right">
                               From Year:
                               
                               <asp:DropDownList ID="drpFrom" runat="server">
                                    <asp:ListItem Selected="True">2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem>2013 </asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                               To Year:
                               
                               <asp:DropDownList ID="drpTo" runat="server">
                                    <asp:ListItem >2009 </asp:ListItem>
                                    <asp:ListItem>2010 </asp:ListItem>
                                    <asp:ListItem>2011 </asp:ListItem>
                                    <asp:ListItem >2012</asp:ListItem>
                                    <asp:ListItem>2013 </asp:ListItem>
                                    <asp:ListItem  Selected="True">2014</asp:ListItem>
                                    <asp:ListItem>2015 </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
         <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" 
            Width="950px" Height="400px" ToolPanelView="None" />
            </div>
     
           <%-- <div style="width: 100%; padding-top:10px;padding-bottom:10px" >
                <div style="width: 65%; float: left;">
                    <telerik:RadChart ID="RadChart1" runat="server" OnItemDataBound="RadChart1_ItemDataBound"
                        Skin="Vista" Height="1100px" Width="850px" Visible=false>
                        <ChartTitle TextBlock-Text="Number Of Visitors" TextBlock-Appearance-Dimensions-Height="20px">
                        </ChartTitle>
                        <Legend Visible="true"></Legend>
                    </telerik:RadChart>
                    <telerik:RadChart ID="RadChart2" runat="server" OnItemDataBound="RadChart2_ItemDataBound"
                        Skin="Vista" Height="1100px" Width="850px" Visible=false>
                        <ChartTitle TextBlock-Text="Advertisement Cost" TextBlock-Appearance-Dimensions-Height="20px">
                        </ChartTitle>
                        <Legend Visible="true"></Legend>
                    </telerik:RadChart>
                    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Skin="Telerik"
                        Width="20px">
                    </telerik:RadToolTipManager>
                </div>
                <div style="width: 30%; float: left;padding-top:10px;padding-bottom:10px"">
                    <asp:GridView ID="gvVisitors" runat="server" AutoGenerateColumns="false" 
                        onrowdatabound="gvVisitors_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Year" HeaderText="Year" />
                            <asp:BoundField DataField="Month" HeaderText="Month" />
                            <asp:TemplateField HeaderText="No Of Visitors">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" ReadOnly="true" Text='<%# Eval("mycount", "{0:F}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
             
            </div>
      </ContentTemplate>
      <Triggers>
      <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
      <asp:PostBackTrigger ControlID="btnVisitor" />
      <asp:PostBackTrigger ControlID="btnAdCost" />

      </Triggers>
    </asp:UpdatePanel>--%>
  
</asp:Content>
