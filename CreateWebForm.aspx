<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateWebForm.aspx.cs" Inherits="WebApplication1.CreateWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CreateAccount</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Create Account</h1>
            <p>Username:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </p>
            <p>Password:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="CreateBttn" runat="server" OnClick="CreateBttn_Click" Text="Create" />
            </p>
        </div>
    </form>
</body>
</html>
