<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllBranchBillingMonthAndDayWise.aspx.cs" Inherits="Report_AllBranchBillingYearWise" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Branch Billing Month And Day Wise</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
  <div style="width: 100%;">
        <div align="left">
            <div align="left" style="margin: 5 0 0 0;">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UdpChart1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                      <asp:Panel ID="panelChart1" runat="server" Visible="false">
                                        <asp:Panel ID="Panel1" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true"
                                            Style="position: absolute; top: 20px; left: 20px; background-color: #F8EBD8;
                                            padding: 3px; white-space: nowrap;">
                                            <table width="30px" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rbtRupeesmonth" runat="server" GroupName="ValueFormat" Checked="true"
                                                            AutoPostBack="true" BackColor="#F8EBD8" BorderStyle="None" 
                                                            oncheckedchanged="rbtRupeesmonth_CheckedChanged"  />
                                                        <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbtnpersentagemonth" runat="server" GroupName="ValueFormat"
                                                            Checked="false" AutoPostBack="true" BackColor="#F8EBD8" BorderStyle="None" 
                                                            oncheckedchanged="rbtnpersentagemonth_CheckedChanged"  />
                                                        &#37;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                     
                                        <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                            <tr>
                                                <td style="text-align: left; vertical-align: top">
                                                    <asp:Chart ID="ChartMonth" runat="server" Palette="BrightPastel" BackColor="#F3DFC1"
                                                        Height="400px" Width="620px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                                        BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" onclick="ChartMonth_Click">
                                                        <Titles>
                                                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 10.25pt, style=Bold" ShadowOffset="0"
                                                                Text="All Branch (Month Wise) Contribution"   ForeColor="26, 59, 105">
                                                            </asp:Title>
                                                        </Titles>
                                                        <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                                        <Series>
                                                            <asp:Series YValueType="String" XValueType="Double" IsValueShownAsLabel="true" IsVisibleInLegend="true"
                                                                IsXValueIndexed="false" ChartArea="ChartAreaMonth" Name="SeriesMonth" ChartType="Bar" 
                                                                CustomProperties="DrawingStyle=Cylinder"
                                                                BorderColor="180, 26, 59, 105" LabelFormat="{0:n2}"
                                                                Color="220, 65, 140, 240" >
                                                            </asp:Series>
                                                        </Series>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartAreaMonth" BorderColor="64, 64, 64, 64"  BorderDashStyle="Solid" BackSecondaryColor="White" 
								                               BackColor="OldLace" ShadowColor="Transparent" >
                                                                <axisy2 Enabled="False"></axisy2>
							                                        <axisx2 Enabled="False"></axisx2>
							                                        <area3dstyle Rotation="15"  Perspective="15" Inclination="15" IsRightAngleAxes="False"  IsClustered="False" />
							                                        <Position Auto="true" />
							                                        <InnerPlotPosition Auto="true" />
							                                        <axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
								                                        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold"   />
								                                        <MajorGrid LineColor="64, 64, 64, 64"  />		
							                                        </axisy>
							                                        <axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
								                                        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold" />
								                                        <MajorGrid LineColor="64, 64, 64, 64" />
							                                        </axisx>
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                  
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>

                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="PanelChart2" runat="server" Visible="false">
                                           <asp:Panel ID="PanelMonthName" runat="server" BorderWidth="1" BorderStyle="Outset"
                                            Visible="false" Style="position: absolute; top: 20px; left: 1020px; background-color: #F5F7FB;
                                            padding: 3px; white-space: nowrap;">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" style="font-family: Verdana; font-size: 11px; font-style: normal;
                                                        font-weight: bold;">
                                                        <asp:Label ID="lblMonthName" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="InputPane2" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true"
                                            Style="position: absolute; top: 20px; left: 645px; background-color: #F5F7FB;
                                            padding: 1px; white-space: nowrap;">
                                            <table width="25px" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rbtrupees" runat="server" GroupName="Value" Checked="true" AutoPostBack="true"
                                                            BackColor="#F5F7FB" BorderStyle="None" 
                                                            oncheckedchanged="rbtrupees_CheckedChanged" />
                                                        <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbtPercentage" runat="server" GroupName="Value" Checked="false"
                                                            AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" 
                                                            oncheckedchanged="rbtPercentage_CheckedChanged" />
                                                        &#37;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Chart ID="Chart1" runat="server" Width="555px" Height="300px" BorderColor="181, 64, 1"
                                            Palette="BrightPastel" BorderDashStyle="Solid" 
                                            BackGradientStyle="TopBottom" BackColor="#D3DFF0"
                                            BorderWidth="2"  >
                                            <Titles>
                                                <asp:Title ShadowColor="32, 0, 0, 0" Alignment="MiddleCenter" Font="Trebuchet MS, 14.25pt, style=Bold"
                                                    ShadowOffset="0" Text="All Branch (Day Wise) Contribution" ForeColor="26, 59, 105">
                                                </asp:Title>
                                            </Titles>
                                            <BorderSkin SkinStyle="Emboss" />
                                            <Series>
                                                <asp:Series Name="Series1" YValueType="String" XValueType="Double" LabelFormat="{0:n2}"
                                                    IsValueShownAsLabel="true" ChartArea="ChartArea1" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder"
                                                    BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                    BackSecondaryColor="Transparent" BorderWidth="0" BackColor="Transparent" ShadowColor="Transparent">
                                                    <AxisY2 Enabled="False">
                                                    </AxisY2>
                                                    <AxisX2 Enabled="False">
                                                    </AxisX2>
                                                    <Area3DStyle Rotation="15" Perspective="15" Inclination="15" IsRightAngleAxes="False"
                                                        IsClustered="False" />
                                                    <Position Auto="true" />
                                                    <InnerPlotPosition Auto="true" />
                                                    <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                                        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisY>
                                                    <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
                                                        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                  <asp:AsyncPostBackTrigger ControlID="ChartMonth" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
