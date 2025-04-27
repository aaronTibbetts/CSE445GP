<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Staff Page Login</h1>
    <form id="form1" runat="server">
            Enter Username:<asp:TextBox ID="UsernameTxtBx" runat="server"></asp:TextBox>
&nbsp;<p>
                &nbsp;</p>
        Enter Password:<asp:TextBox ID="PasswordTxtBx" runat="server"></asp:TextBox>
&nbsp;<p>
            <asp:Button ID="LoginBttn" runat="server" OnClick="LoginBttn_Click" Text="Login" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create" />
        </p>
        <div>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
