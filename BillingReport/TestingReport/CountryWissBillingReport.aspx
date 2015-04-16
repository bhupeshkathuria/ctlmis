<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CountryWissBillingReport.aspx.cs"
    Inherits="Report_CountryWissBillingReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/Main.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding-top: 0px;">
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
                                    <asp:Panel ID="PanelCharT1" runat="server" Visible="false">
                                        <asp:Panel ID="InputPanel" runat="server" BorderWidth="0" BorderStyle="None" Visible="true"
                                            Style="position: absolute; top: 20px; left: 460px; background-color: #F3DFC1;
                                            padding: 3px; white-space: nowrap;">
                                            <asp:DropDownList ID="drpTopValue" runat="server" Width="80" AutoPostBack="true"
                                                BackColor="#F3DFC1" OnSelectedIndexChanged="drpTopValue_SelectedIndexChanged">
                                                <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Top 15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="Top 20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </asp:Panel>
                                        <asp:Panel ID="InputPane2" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true"
                                            Style="position: absolute; top: 20px; left: 20px; background-color: #F8EBD8;
                                            padding: 1px; white-space: nowrap;">
                                            <table width="25px" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButton ID="rbtrupees" runat="server" GroupName="Value" Checked="true" AutoPostBack="true"
                                                            BackColor="#F8EBD8" BorderStyle="None" OnCheckedChanged="rbtrupees_CheckedChanged" />
                                                        <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="rbtPercentage" runat="server" GroupName="Value" Checked="false"
                                                            AutoPostBack="true" BackColor="#F8EBD8" BorderStyle="None" OnCheckedChanged="rbtPercentage_CheckedChanged" />
                                                        &#37;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Chart ID="Chart1" runat="server" Width="562px" Height="200px" BorderColor="181, 64, 1"
                                            Palette="BrightPastel" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                            BorderWidth="2" BackColor="#F3DFC1" OnClick="Chart1_Click">
                                            <Titles>
                                                <asp:Title ShadowColor="32, 0, 0, 0" Alignment="MiddleCenter" Font="Trebuchet MS, 14.25pt, style=Bold"
                                                    ShadowOffset="0" Text="Country (year Wise) Contribution" ForeColor="26, 59, 105">
                                                </asp:Title>
                                            </Titles>
                                            <BorderSkin SkinStyle="Emboss" />
                                            <Series>
                                                <asp:Series Name="Series1" YValueType="String" XValueType="Double" LabelFormat="{0:n2}"
                                                    IsValueShownAsLabel="true" ChartArea="ChartArea1" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder"
                                                    BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
                                                </asp:Series>
                                                <asp:Series Name="Series2" YValueType="String" XValueType="Double" LabelFormat="{0:n2}"
                                                    IsValueShownAsLabel="true" ChartArea="ChartArea1" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder"
                                                    BorderColor="180, 26, 59, 105" Color="Coral">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                    BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
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
                            </asp:UpdatePanel>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                             <td>
                                                <asp:Panel ID="panelChart2" runat="server" Visible="false">
                                                    <asp:Panel ID="Panel1" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true"
                                                        Style="position: absolute; top: 20px; left: 590px; background-color: #F5F7FB;
                                                        padding: 3px; white-space: nowrap;">
                                                        <table width="30px" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="rbtRupeesmonth" runat="server" GroupName="ValueFormat" Checked="true"
                                                                        AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" OnCheckedChanged="rbtRupeesmonth_CheckedChanged" />
                                                                    <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rbtnpersentagemonth" runat="server" GroupName="ValueFormat"
                                                                        Checked="false" AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" OnCheckedChanged="rbtnpersentagemonth_CheckedChanged" />
                                                                    &#37;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="PanelCountryName" runat="server" BorderWidth="1" BorderStyle="Outset"
                                                        Visible="false" Style="position: absolute; top: 20px; left: 1060px; background-color: #F5F7FB;
                                                        padding: 3px; white-space: nowrap;">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="right" style="font-family: Verdana; font-size: 11px; font-style: normal;
                                                                    font-weight: bold;">
                                                                    <asp:Label ID="lblCountryName" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                                        <tr>
                                                            <td style="text-align: left; vertical-align: top">
                                                                <asp:Chart ID="ChartMonth" runat="server" Palette="BrightPastel" BackColor="#F3DFC1"
                                                                    Height="400px" Width="650px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                                                    BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False">
                                                                    <Titles>
                                                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 10.25pt, style=Bold" ShadowOffset="0"
                                                                            Text="Country (Month Wise) Contribution" ForeColor="26, 59, 105">
                                                                        </asp:Title>
                                                                    </Titles>
                                                                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                                                    <Series>
                                                                        <asp:Series YValueType="String" XValueType="Double" IsValueShownAsLabel="true" IsVisibleInLegend="true"
                                                                            IsXValueIndexed="false" ChartArea="ChartAreaMonth" Name="SeriesMonth" ChartType="Bar"
                                                                            CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" LabelFormat="{0:n2}"
                                                                            Color="220, 65, 140, 240">
                                                                        </asp:Series>
                                                                        <asp:Series YValueType="String" XValueType="Double" IsValueShownAsLabel="true" IsVisibleInLegend="true"
                                                                            IsXValueIndexed="false" ChartArea="ChartAreaMonth" Name="SeriesMonthServicesTax"
                                                                            ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105"
                                                                            LabelFormat="{0:n2}" Color="Coral">
                                                                        </asp:Series>
                                                                    </Series>
                                                                    <ChartAreas>
                                                                        <asp:ChartArea Name="ChartAreaMonth" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                                            BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
                                                                            <AxisY2 Enabled="False">
                                                                            </AxisY2>
                                                                            <AxisX2 Enabled="False">
                                                                            </AxisX2>
                                                                            <Area3DStyle Rotation="15" Perspective="15" Inclination="15" IsRightAngleAxes="False"
                                                                                IsClustered="False" />
                                                                            <Position Auto="true" />
                                                                            <InnerPlotPosition Auto="true" />
                                                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
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
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Panel ID="panelChart2LastYear" runat="server" Visible="false">
                                                    <asp:Panel ID="PanelLastYear" runat="server" BorderWidth="1" BorderStyle="Outset"
                                                        Visible="true" Style="position: absolute; top: 20px; left: 1300px; background-color: #F5F7FB;
                                                        padding: 3px; white-space: nowrap;">
                                                        <table width="30px" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="rbtRupeesmonthLastYear" runat="server" GroupName="ValueFormatLastYear"
                                                                        Checked="true" AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" OnCheckedChanged="rbtRupeesmonthLastYear_CheckedChanged" />
                                                                    <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rbtnpersentagemonthLastYear" runat="server" GroupName="ValueFormatLastYear"
                                                                        Checked="false" AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" OnCheckedChanged="rbtnpersentagemonthLastYear_CheckedChanged" />
                                                                    &#37;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="PanelCountryNameLastYear" runat="server" BorderWidth="1" BorderStyle="Outset"
                                                        Visible="false" Style="position: absolute; top: 20px; left: 1700px; background-color: #F5F7FB;
                                                        padding: 3px; white-space: nowrap;">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="right" style="font-family: Verdana; font-size: 11px; font-style: normal;
                                                                    font-weight: bold;">
                                                                    <asp:Label ID="lblCountryNameLastYear" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="text-align: left; vertical-align: top">
                                                                <asp:Chart ID="ChartMonthLastYear" runat="server" Palette="BrightPastel" BackColor="#F3DFC1"
                                                                    Height="400px" Width="650px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                                                    BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False">
                                                                    <Titles>
                                                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 10.25pt, style=Bold" ShadowOffset="0"
                                                                            Text="Country (Last Year Month Wise) Contribution" ForeColor="26, 59, 105">
                                                                        </asp:Title>
                                                                    </Titles>
                                                                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                                                    <Series>
                                                                        <asp:Series YValueType="String" XValueType="Double" IsValueShownAsLabel="true" IsVisibleInLegend="true"
                                                                            IsXValueIndexed="false" ChartArea="ChartAreaMonthLastYear" Name="SeriesMonthLastYear"
                                                                            ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105"
                                                                            LabelFormat="{0:n2}" Color="220, 65, 140, 240">
                                                                        </asp:Series>
                                                                        <asp:Series YValueType="String" XValueType="Double" IsValueShownAsLabel="true" IsVisibleInLegend="true"
                                                                            IsXValueIndexed="false" ChartArea="ChartAreaMonthLastYear" Name="SeriesMonthServicesTaxLastYear"
                                                                            ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105"
                                                                            LabelFormat="{0:n2}" Color="Coral">
                                                                        </asp:Series>
                                                                    </Series>
                                                                    <ChartAreas>
                                                                        <asp:ChartArea Name="ChartAreaMonthLastYear" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                                            BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
                                                                            <AxisY2 Enabled="False">
                                                                            </AxisY2>
                                                                            <AxisX2 Enabled="False">
                                                                            </AxisX2>
                                                                            <Area3DStyle Rotation="15" Perspective="15" Inclination="15" IsRightAngleAxes="False"
                                                                                IsClustered="False" />
                                                                            <Position Auto="true" />
                                                                            <InnerPlotPosition Auto="true" />
                                                                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
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
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <%--============================================================--%>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Chart1" />
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
