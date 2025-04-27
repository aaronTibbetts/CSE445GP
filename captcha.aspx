<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="captcha.aspx.cs" Inherits="WebApplication1.captcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="EntrBttn" runat="server" OnClick="EntrBttn_Click" Text="Enter" />
    </form>
</body>
</html>
