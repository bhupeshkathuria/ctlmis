<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Progress Bar Example In Asp.Net</title>
    <style type="text/css">
        body
        {
            margin: 0px auto;
            width: 100%;
            font-family: Calibri;
            font-size: 12px;
            text-align: center;
            text-transform: capitalize;
        }
        .popup
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .load
        {
            width: 100px;
            height: 100px;
            display: none;
            position: fixed;
            z-index: 999;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function Progress() {
            setTimeout(function () {
                var POPOUP = $('<div />');
                POPOUP.addClass("popup");
                $('body').append(POPOUP);
                var loading = $(".load");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            Progress();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButton ID="RadioButton1" runat="server" 
            />
        <h1>
            Progress Bar Example In Asp.Net</h1>
        <asp:DropDownList ID="location" runat="server">
            <asp:ListItem Value="DEL">Delhi</asp:ListItem>
            <asp:ListItem Value="GGN">Gurgaon</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server" />
        <br />
        <br />
        <asp:GridView ID="gv" runat="server" Width="100%">
        </asp:GridView>
        <div class="load">
            <img src="Images/Loader.gif" alt="" />
        </div>
    </div>
    </form>
</body>
</html>
