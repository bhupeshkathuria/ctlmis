<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MISReportBrachCountryWiseGraph.aspx.cs"
    Inherits="User_CRM_MISReportBrachCountryWise" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellpadding="0px" cellspacing="0px" width="100%">
        <tr>
            <td class="Header_text" align="left">
                &nbsp;&nbsp; CRM / Reports / Mis Report
            </td>
            <td class="Header_text" align="right">
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 45px">
                <fieldset style="width: 79%">
                    <legend>Show Report</legend>
                    <div style="float: left">
                    </div>
                    <div style="float: left">
                    </div>
                    <div style="float: left">
                        <b>Financial Year </b>&nbsp;&nbsp;
                    </div>
                    <div style="float: left">
                        <asp:DropDownList ID="ddlYear" Width="150px" runat="server">
                        </asp:DropDownList>
                        &nbsp;
                        <telerik:RadComboBox ID="ddlCountry" runat="server" Height="200px" Width="150px"
                            EmptyMessage="Select Country" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                            MarkFirstMatch="true" AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";">
                        </telerik:RadComboBox>
                        &nbsp;
                        <telerik:RadComboBox ID="ddlBranch" runat="server" Height="200px" Width="150px" EmptyMessage="Select Branch"
                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                            AutoPostBack="false" AllowCustomText="true" AutoCompleteSeparator=";">
                        </telerik:RadComboBox>
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnExport" Visible="false" runat="server" Text="Export" OnClick="btnExport_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 15px; color: Green">
                <asp:Label ID="err" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="font-weight: normal;">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 15px">
                <asp:Label ID="lblreport" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblcnt" runat="server" Font-Bold="True" Visible="False"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 15px">
                <asp:Label ID="lblBranchReport" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div align="left">
        <table cellpadding="6px" cellspacing="6px" width="100%">
            <tr>
                <td align="center">
                    <telerik:RadChart ID="RadChart2" runat="server" Height="650px" Skin="Gradient" Visible="false">
                        <Series>
                            <telerik:ChartSeries Type="Line" DataYColumn="Amt" Name="Amount">
                                <Items>
                                </Items>
                                <Appearance>
                                    <FillStyle MainColor="199, 243, 178" SecondColor="17, 147, 7">
                                    </FillStyle>
                                    <TextAppearance TextProperties-Color="Black">
                                    </TextAppearance>
                                    <Border Color="Black" />
                                </Appearance>
                            </telerik:ChartSeries>
                        </Series>
                        <PlotArea>
                            <XAxis AutoScale="False" MaxValue="7" MinValue="0" Step="1">
                                <Appearance MajorTick-Color="Black">
                                    <MajorGridLines Color="Red" />
                                    <TextAppearance TextProperties-Color="Black">
                                    </TextAppearance>
                                    <LabelAppearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                    </LabelAppearance>
                                </Appearance>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                                <Items>
                                    <telerik:ChartAxisItem>
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="1">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="2">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="3">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="4">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="5">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="6">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="7">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                </Items>
                            </XAxis>
                            <YAxis>
                                <Appearance>
                                    <MajorGridLines Color="Black" />
                                </Appearance>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                            </YAxis>
                            <Appearance Dimensions-Margins="12%, 2%, 25%, 10%" Corners="Round, Round, Round, Round, 6">
                                <FillStyle MainColor="65, 201, 254" SecondColor="0, 107, 186">
                                </FillStyle>
                                <Border Color="94, 94, 93" />
                            </Appearance>
                            <YAxis2>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                            </YAxis2>
                        </PlotArea>
                        <Appearance>
                            <FillStyle MainColor="244, 244, 234" FillType="Gradient" SecondColor="167, 172, 137">
                            </FillStyle>
                            <Border Color="117, 117, 117" />
                        </Appearance>
                        <ChartTitle>
                            <Appearance Corners="Round, Round, Round, Round, 3" Dimensions-Margins="1%, 10px, 14px, 10%"
                                Position-AlignedPosition="TopRight">
                                <FillStyle MainColor="177, 183, 144">
                                </FillStyle>
                                <Border Color="64, 64, 64" />
                            </Appearance>
                            <TextBlock Text="Country Conversion Graph">
                                <Appearance TextProperties-Color="White" TextProperties-Font="Verdana, 14.25pt, style=Bold">
                                </Appearance>
                            </TextBlock>
                        </ChartTitle>
                        <Legend>
                            <Appearance Corners="Round, Round, Round, Round, 3" Dimensions-Margins="6%, 15%, 1px, 25%"
                                Overflow="Auto" Position-AlignedPosition="Top">
                                <Border Color="64, 64, 64" Visible="False" />
                                <FillStyle MainColor="177, 183, 144">
                                </FillStyle>
                            </Appearance>
                        </Legend>
                    </telerik:RadChart>
                </td>
            </tr>
        </table>
        <table cellpadding="6px" cellspacing="6px" width="100%">
            <tr>
                <td align="center">
                    <telerik:RadChart ID="RadChart1" runat="server" Height="650px" Skin="Gradient" Visible="false">
                        <Series>
                            <telerik:ChartSeries Type="Line" DataYColumn="Amt" Name="Amount">
                                <Items>
                                </Items>
                                <Appearance>
                                    <FillStyle MainColor="199, 243, 178" SecondColor="17, 147, 7">
                                    </FillStyle>
                                    <TextAppearance TextProperties-Color="Black">
                                    </TextAppearance>
                                    <Border Color="Black" />
                                </Appearance>
                            </telerik:ChartSeries>
                        </Series>
                        <PlotArea>
                            <XAxis AutoScale="False" MaxValue="7" MinValue="0" Step="1">
                                <Appearance MajorTick-Color="Black">
                                    <MajorGridLines Color="Red" />
                                    <TextAppearance TextProperties-Color="Black">
                                    </TextAppearance>
                                    <LabelAppearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                    </LabelAppearance>
                                </Appearance>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                                <Items>
                                    <telerik:ChartAxisItem>
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="1">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="2">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="3">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="4">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="5">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="6">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                    <telerik:ChartAxisItem Value="7">
                                        <Appearance Dimensions-Margins="0px, 1px, 1px, 1px">
                                        </Appearance>
                                    </telerik:ChartAxisItem>
                                </Items>
                            </XAxis>
                            <YAxis>
                                <Appearance>
                                    <MajorGridLines Color="Black" />
                                </Appearance>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                            </YAxis>
                            <Appearance Dimensions-Margins="12%, 2%, 25%, 10%" Corners="Round, Round, Round, Round, 6">
                                <FillStyle MainColor="65, 201, 254" SecondColor="0, 107, 186">
                                </FillStyle>
                                <Border Color="94, 94, 93" />
                            </Appearance>
                            <YAxis2>
                                <AxisLabel>
                                    <TextBlock>
                                        <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                        </Appearance>
                                    </TextBlock>
                                </AxisLabel>
                            </YAxis2>
                        </PlotArea>
                        <Appearance>
                            <FillStyle MainColor="244, 244, 234" FillType="Gradient" SecondColor="167, 172, 137">
                            </FillStyle>
                            <Border Color="117, 117, 117" />
                        </Appearance>
                        <ChartTitle>
                            <Appearance Corners="Round, Round, Round, Round, 3" Dimensions-Margins="1%, 10px, 14px, 10%"
                                Position-AlignedPosition="TopRight">
                                <FillStyle MainColor="177, 183, 144">
                                </FillStyle>
                                <Border Color="64, 64, 64" />
                            </Appearance>
                            <TextBlock Text="Branch Conversion Graph">
                                <Appearance TextProperties-Color="White" TextProperties-Font="Verdana, 14.25pt, style=Bold">
                                </Appearance>
                            </TextBlock>
                        </ChartTitle>
                        <Legend>
                            <Appearance Corners="Round, Round, Round, Round, 3" Dimensions-Margins="6%, 15%, 1px, 25%"
                                Overflow="Auto" Position-AlignedPosition="Top">
                                <Border Color="64, 64, 64" Visible="False" />
                                <FillStyle MainColor="177, 183, 144">
                                </FillStyle>
                            </Appearance>
                        </Legend>
                    </telerik:RadChart>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mis Report</title>
    <link href="../Resource/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
       
    </form>
</body>
</html>--%>
