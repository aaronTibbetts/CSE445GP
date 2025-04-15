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
            &nbsp;</p>
        <p>
            &nbsp;</p>
        Don't have an account? Click here to make one:<asp:Button ID="CreateAccount" runat="server" Text="Create" />
&nbsp;<div>
        </div>
    </form>
</body>
</html>
