<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="frmapproval1.aspx.cs"
    Inherits="ErpReports_frmapproval1" Title="PO Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" language="javascript">
        function PO(supplierid, _monthname, _yearname) {

            //window.open("frmPO.aspx?id=" + n);
            window.open("frmPO.aspx?id=" + supplierid + "&monthname=" + _monthname + "&yearname=" + _yearname);
        }

        

    </script>
    <script language="javascript" type="text/javascript">
        function openNewWin(url) {

            var w = 1050;
            var h = 500;
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);

            var x = window.open(url, 'mynewwin', 'menubar=0,resizable=no,scrollbars=yes, maximize=no,width=' + w + ', height=' + h + ', top=' + top + ', left=' + left + ',toolbar=0');
            x.focus();
        }

    </script>
    <script language="javascript">
        function calldetails2(_fname, _poid) {
            window.open("../Download.aspx?fname=" + _fname + "&poid=" + _poid);
        }
    </script>
    <style type="text/css">
        .FixedWidth
        {
            overflow: hidden;
            width: 100px;
        }
    </style>
    <style type="text/css">
        .data-tabl
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        .data-tabl th
        {
            font: bold 12px Verdana, Geneva, sans-serif;
            text-align: left;
            color: #000;
            line-height: 26px;
            background-color: #d7d7ef;
            padding: 0 3px 0 3px;
            border: none;
        }
        .data-tabl td
        {
            font: normal 12px Verdana, Geneva, sans-serif;
            text-align: left;
            color: #666;
            line-height: 20px;
            background-color: #f5f5f5;
            padding: 0 3px 0 3px;
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        .style1
        {
            height: 68px;
        }
    </style>
    <div>
        <table cellpadding="0px" cellspacing="0px" width="100%">
            <tr>
                <td colspan="2">
                    <asp:ImageButton ID="imbback" runat="server" ImageUrl="~/Images/back.png" OnClick="imbback_Click" />
                </td>
            </tr>
            <tr>
                <td class="style10">
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
                            <div id="reqdetails" runat="server" style="padding-top: 20px">
                                <table style="width: 857px; padding-top: 25px" class="data-tabl">
                                    <tr>
                                        <td style="width: 20%">
                                            <b>Requisition No:</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblReqNo" runat="server" Text="--"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <b>Requisition Date :</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblReqDte" runat="server" Text="--"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%">
                                            <b>Requested By :</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblReqBy" runat="server" Text="--"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <b>Requestor Comment:</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblPOComment" runat="server" Text="--"></asp:Label>
                                            <asp:Label ID="lblRequisitionId" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblRequestorId" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblViewedbyUserRank" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div id="pomaster" runat="server">
                                <table style="width: 857px" class="data-tabl">
                                    <tr>
                                        <td style="width: 20%">
                                            <b>PO Number :</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblPoNumber" runat="server" Text="--"></asp:Label>
                                            <asp:Label ID="lblPoId" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <b>PO Date :</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblPODate" runat="server" Text="--"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%">
                                            <b>Supplier Name :</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblSuppierName" runat="server" Text="--"></asp:Label>
                                            <asp:Label ID="lblsupplierid" runat="server" Text="--" Visible="false"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <b>Contact Person:</b>
                                        </td>
                                        <td style="width: 30%">
                                            <asp:Label ID="lblContactPersonName" runat="server" Text="--"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%">
                                            <b>Suppler Address :</b>
                                        </td>
                                        <td colspan="3" style="width: 80%">
                                            <asp:Label ID="lblAddress" runat="server" Text="--"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div id="podetails" runat="server">
                                <asp:GridView ID="grdPODetails" runat="server" Width="857px" AutoGenerateColumns="false"
                                    OnRowDataBound="grdPODetails_RowDataBound" AlternatingRowStyle-BackColor="#f5f5f5"
                                    HeaderStyle-BackColor="#b9b9b9" HeaderStyle-ForeColor="White">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SrNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrno" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("itemid")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("itemname")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("quantity")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("unitprice")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VAT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVAT" runat="server" Text='<%#Eval("vat")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Service Tax">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSTax" runat="server" Text='<%#Eval("servicetax")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <div>
                                <table style="width: 80%">
                                    <tr>
                                        <td style="width: 30%">
                                            Total Amount :
                                        </td>
                                        <td class="style9">
                                            <asp:Label ID="lblTotalAmt" runat="server" Text="--"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%">
                                            Comments:
                                        </td>
                                        <td class="style9">
                                            <table>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:TextBox ID="txtComments" runat="server" Height="89px" TextMode="MultiLine" Width="230px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComments"
                                                            ErrorMessage="Please enter Comment." ValidationGroup="val">*</asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
                                                            TargetControlID="RequiredFieldValidator3">
                                                        </ajaxToolkit:ValidatorCalloutExtender>
                                                    </td>
                                                    <td style="vertical-align: top; padding-left: 20px">
                                                        <asp:GridView ID="dgcomment" runat="server" AutoGenerateColumns="false" Width="520px"
                                                            AlternatingRowStyle-BackColor="#f5f5f5" OnRowDataBound="dgcomment_RowDataBound"
                                                            HeaderStyle-BackColor="#b9b9b9" HeaderStyle-ForeColor="White">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SrNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSrno2" runat="server" EnableViewState="true"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Comment ON">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcommenton" runat="server" Text='<%#Eval("createdon2")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Comment By">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcommentby" runat="server" Text='<%#Eval("commentedby")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Comment">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcomment" runat="server" Text='<%# Limit(Eval("comments"),40) %>'
                                                                            ToolTip='<%# Eval("comments") %>'></asp:Label>
                                                                        <asp:LinkButton ID="ReadMoreLinkButton" runat="server" Text="Read More" Visible='<%# SetVisibility(Eval("comments"), 40) %>'
                                                                            OnClick="ReadMoreLinkButton_Click">
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Requisition Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblrequisitionstatus" runat="server" Text='<%#Eval("requisitionstatus")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlPO" runat="server" Visible="false">
                                                <table cellpadding="0" cellspacing="0" style="padding-left: 220px">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="cmdApproved" runat="server" Text="Approved" OnClick="cmdApproved_Click"
                                                                ValidationGroup="val" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="cmdReject" runat="server" Text="Reject" OnClick="cmdReject_Click"
                                                                ValidationGroup="val" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="cmdSentToRequestor" runat="server" Text="Query Reply/Add Comment"
                                                                OnClick="cmdSentToRequestor_Click" ValidationGroup="val" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="vertical-align: top; padding-left: 25px">
                    <table>
                        <tr>
                            <td>
                                <b>Last Three Months PO's Amount</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgPO" runat="server" AutoGenerateColumns="false" OnRowDataBound="dgPO_RowDataBound"
                                    Height="117px" Width="286px" AlternatingRowStyle-BackColor="#f5f5f5" HeaderStyle-BackColor="#b9b9b9"
                                    HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="WhiteSmoke"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("YearName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Month">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmonth" runat="server" Text='<%#Eval("MonthName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalamount" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblViewPo" Text="View" runat="server" OnClick="lblViewPo_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#B9B9B9" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Document Attached</legend>
                                    <%--<table width="100%">
                                        <tr>
                                            <td style="width: 30%">--%>
                                    View Bill:
                                    <%--</td>
                                            <td>--%>
                                    <asp:LinkButton ID="lnkviewfile" runat="server" Text="View" OnClick="lnkviewfile_Click"></asp:LinkButton>
                                    <asp:Label ID="lblbillfilename" runat="server" Visible="false"></asp:Label><br />
                                    <br />
                                    <%--</td>
                                        </tr>--%>
                                    <%--<tr>
                                            <td style="width: 30%">--%>
                                    View Mail:
                                    <%-- </td>
                                            <td>--%>
                                    <asp:LinkButton ID="lnkviewmail" runat="server" Text="View" OnClick="lnkviewmail_Click"></asp:LinkButton>
                                    <asp:Label ID="lblmailfilename" runat="server" Visible="false"></asp:Label>
                                    <%--</td>
                                        </tr>
                                    </table>--%>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style9
        {
            width: 79%;
        }
        .style10
        {
            width: 63%;
        }
    </style>
</asp:Content>
