<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSalesReporBranchManagerWise.aspx.cs" Inherits="Sales_frmSalesReporBranchManagerWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gdvSalesbranch" runat="server" AutoGenerateColumns="false" CssClass="record-result" Style=" margin-top:28px;" >
        <Columns>
        
                            <asp:BoundField DataField="employeename" HeaderText="AccountManager" ControlStyle-CssClass="force-left"   />
                            <asp:BoundField DataField="TotalRAF" HeaderText="TotalRAF" ItemStyle-HorizontalAlign="Right"  />
                            <asp:BoundField DataField="Pending-Sale" HeaderText="Pend.-Sale" ItemStyle-HorizontalAlign="Right"  />
                            <asp:BoundField DataField="Pending-Inventory" HeaderText="Pend.-Inventory" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Operation" HeaderText="Pend.-Operation" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Pending-Delivery" HeaderText="Pend.-Delivery" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Accept/Partial Accept" HeaderText="Accept" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Closed" HeaderText="Closed" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="DocumentUploaded" HeaderText="Doc-Uploaded" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="DocumentNotUploaded" HeaderText="Doc-NotUploaded" ItemStyle-HorizontalAlign="Right" />
           </Columns>
        </asp:GridView>
    
    </div>
    <div>
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
