<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CountryWiseReport.aspx.cs" Inherits="Report_MainReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
    function validYear() {

        if (document.getElelmentById('drpFyear').value == "Select Financial Year" || document.getElelmentById('drpFyear').value == "0") {
            alert("Please Select Financial year!");
            return false;
        }
    }
</script>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

<%--<asp:UpdatePanel ID="UdpSearch" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
         <table cellpadding="3" cellspacing="0">
            <tr>
                <td>
                   Select Financial Year: 
                    <asp:DropDownList ID="drpFyear" runat="server" CssClass="drop">
                        <asp:ListItem Text="Select Financial Year" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Text="2009-2010" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2010-2011" Value="2"></asp:ListItem>
                        <asp:ListItem Text="2011-2012" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button  ID="btnSubmit" runat="server" Text="Submit" Height="25px"  
                        CssClass="textbtn" onclick="btnSubmit_Click" />
                </td>
                <td style="font-size:11px; font-family:Verdana; font-weight:bold; color:Red;" >
                    <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>


  <div align="left">
    <div align="left" style="margin:5 0 0 0;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="vertical-align:top;">
                    <asp:UpdatePanel ID="UdpChart1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            
                        <asp:Panel ID="PanelCharT1" runat="server" Visible="false">
                            <asp:Panel ID="InputPanel" runat="server" BorderWidth="0" BorderStyle="None" Visible="true" style="position: absolute; top: 140px; left:490px; 
                            background-color: #F3DFC1; padding: 3px; white-space:nowrap; ">
                            <asp:DropDownList ID="drpTopValue" runat="server" Width="80" 
                                AutoPostBack="true"  BackColor="#F3DFC1" 
                                onselectedindexchanged="drpTopValue_SelectedIndexChanged">
                                <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                                 <asp:ListItem Text="Top 15" Value="15"></asp:ListItem>
                                 <asp:ListItem Text="Top 20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            </asp:DropDownList>                                    
                        </asp:Panel>

                         <asp:Panel ID="InputPane2" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true" style="position: absolute; top: 140px; left:50px; background-color: #F8EBD8; padding: 1px; white-space:nowrap; ">
                            <table width="25px" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="rbtrupees" runat="server" GroupName="Value" 
                                            Checked="true"  AutoPostBack="true" BackColor="#F8EBD8" BorderStyle="None" 
                                            oncheckedchanged="rbtrupees_CheckedChanged"  />
                                        <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                            
                                    </td>                                       
                                    <td>
                                        <asp:RadioButton ID="rbtPercentage"  runat="server" GroupName="Value" 
                                            Checked="false"  AutoPostBack="true" BackColor="#F8EBD8" BorderStyle="None" 
                                            oncheckedchanged="rbtPercentage_CheckedChanged"  />
                                        &#37;
                                    </td>
                                </tr>
                            </table>
                         </asp:Panel>
                         <asp:Chart ID="Chart1" runat="server" Width="562px" Height="200px"  BorderColor="181, 64, 1" 
                            Palette="BrightPastel" BorderDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" 
                            onclick="Chart1_Click">
           
                         <titles>
			                <asp:Title  ShadowColor="32, 0, 0, 0" Alignment="MiddleCenter" Font="Trebuchet MS, 14.25pt, style=Bold" 
                                ShadowOffset="0" Text="Country (year Wise) Contribution" ForeColor="26, 59, 105">
			                </asp:Title>
		                </titles>
                       <%-- <legends>
			                <asp:Legend Enabled="true" LegendItemOrder="ReversedSeriesOrder"  ItemColumnSpacing="1" Alignment="Near"  
                            IsDockedInsideChartArea="true"   IsTextAutoFit="true" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
		                </legends>--%>
                        <BorderSkin  SkinStyle="Emboss" />
                            <Series>
                                <asp:Series Name="Series1" YValueType="String" XValueType="Double" LabelFormat="{0:n2}"
                                 IsValueShownAsLabel="true"  ChartArea="ChartArea1"
                                ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" >
                                </asp:Series>
                            </Series>
          
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"  BorderDashStyle="Solid" BackSecondaryColor="White" 
								       BackColor="OldLace" ShadowColor="Transparent"  >
                                        <axisy2 Enabled="False"></axisy2>
							                <axisx2 Enabled="False"></axisx2>
							                <area3dstyle Rotation="15"  Perspective="15" Inclination="15" IsRightAngleAxes="False"  IsClustered="False" />
							                <Position Auto="true" />
							                <InnerPlotPosition Auto="true" />
							                <axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
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
                        </asp:Panel> 
                          

                        </ContentTemplate>
                     </asp:UpdatePanel>
                    </td>


                    <td style="vertical-align:top;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                            <asp:Panel ID="panelChart2" runat="server" Visible="false">
                                <asp:Panel ID="Panel1" runat="server" BorderWidth="1" BorderStyle="Outset" Visible="true" style="position: absolute; 
                            top: 140px; left:600px; background-color: #F5F7FB; padding: 3px; white-space:nowrap; ">
                                <table width="30px" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtRupeesmonth" runat="server" GroupName="ValueFormat" Checked="true"  
                                            AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" 
                                                oncheckedchanged="rbtRupeesmonth_CheckedChanged" />
                                             <img src="../Images/Rupee.png" alt="Rs" width="8" height="10">
                                        </td>                                       
                                        <td>
                                            <asp:RadioButton ID="rbtnpersentagemonth" runat="server" GroupName="ValueFormat" 
                                            Checked="false"  AutoPostBack="true" BackColor="#F5F7FB" BorderStyle="None" 
                                                oncheckedchanged="rbtnpersentagemonth_CheckedChanged" />
                                              &#37;
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="PanelCountryName" runat="server"  BorderWidth="1" BorderStyle="Outset" Visible="false" style="position: absolute; 
                                    top: 140px; right:50px; background-color: #F5F7FB; padding: 3px; white-space:nowrap; ">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right" style="font-family:Verdana; font-size:11px; font-style:normal; font-weight:bold;">
                                                <asp:Label ID="lblCountryName" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                           <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">                                    
                                <tr>
                                    <td style="text-align:left;vertical-align:top">
                                        <asp:Chart id="ChartMonth" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="400px" Width="650px" 
                                        BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False">                                                                    
                                
                                        <titles>                                
								            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 10.25pt, style=Bold" ShadowOffset="0" 
                                            Text="Country (Month Wise) Contribution" ForeColor="26, 59, 105"></asp:Title>
							            </titles>
            							  <legends>
			                                    <asp:Legend Enabled="true" LegendItemOrder="ReversedSeriesOrder"  ItemColumnSpacing="1" Alignment="Near"  
                                                IsDockedInsideChartArea="true"   IsTextAutoFit="true" Name="Default" BackColor="Transparent" 
                                                Font="Trebuchet MS, 8.25pt, style=Bold"  ></asp:Legend>
		                                    </legends>
							        <borderskin SkinStyle="Emboss"></borderskin>
							        <series>
								        <asp:Series  YValueType="String" XValueType="Double"  IsValueShownAsLabel="true"  ChartArea="ChartAreaMonth" 
                                        Name="SeriesMonth" ChartType="Pyramid" CustomProperties="PyramidPointGap=0, FunnelMinPointHeight=20"   
                                        BorderColor="180, 26, 59, 105"  LabelFormat="{0:n2}"
                                        Color="220, 65, 140, 240" ></asp:Series>
							        </series>
        							    
							        <chartareas>							
								        <asp:ChartArea Name="ChartAreaMonth" BorderColor="64, 64, 64, 64"  BorderDashStyle="Solid" BackSecondaryColor="Transparent" 
								        BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
									        <axisy2 Enabled="False"></axisy2>
									        <axisx2 Enabled="False"></axisx2>
									        <area3dstyle Rotation="15"  Perspective="15" Inclination="15" IsRightAngleAxes="False"  IsClustered="False" />
									        <Position Auto="true" />
									        <InnerPlotPosition Auto="true" />
									        <axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold" Format="0.0, Million" />
										        <MajorGrid LineColor="64, 64, 64, 64"  />		
                																												
									        </axisy>
									        <axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="false">
										        <LabelStyle Font="Trebuchet MS, 7.25pt, style=Bold" />
										        <MajorGrid LineColor="64, 64, 64, 64" />
									        </axisx>
								        </asp:ChartArea>
							                </chartareas>
						            </asp:Chart>
                                </td>
                            </tr>
                        </table>
                            </asp:Panel>

                        
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="Chart1"/>
                        </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
    </div>
</div>

</asp:Content>

