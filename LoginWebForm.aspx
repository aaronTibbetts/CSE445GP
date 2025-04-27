<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWebForm.aspx.cs" Inherits="WebApplication1.LoginWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <h1>This is the login page</h1>


    <form id="form1" runat="server">
    Enter Username:<asp:TextBox ID="UsernameTxtBx" runat="server"></asp:TextBox>
&nbsp;<p>
            &nbsp;</p>
        Enter Password:<asp:TextBox ID="PasswordTxtBx" runat="server"></asp:TextBox>
&nbsp;<p>
            <asp:Button ID="LoginBttn" runat="server" OnClick="LoginBttn_Click" Text="Login" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
        Don't have an account? Click here to make one:<asp:Button ID="CreateAccount" runat="server" Text="Create" OnClick="CreateAccount_Click" />
&nbsp;<div>
        </div>
    </form>
</body>
</html>
