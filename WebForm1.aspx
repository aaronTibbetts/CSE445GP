<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Text Editor</title>
</head>
<body style="height: 547px">
    <form id="form1" runat="server">
    <h1>Text Editor</h1>
    This is a text editor. You can upload a text file and do a few functions on that text file. 
        For every function, you will need to make sure that the file that is uploade is a text file.
        <p>
            &nbsp;</p>
        <p>
            Click on Login to sign in<asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" style="margin-left: 0px" Text="Login" />
        </p>
        <p>
&nbsp;</p>
        <p>
            <asp:Button ID="StaffButton" runat="server" OnClick="StaffButton_Click" Text="Staff" />
        </p>
        <p>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableHeaderCell>Application and Components Summary</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>Members Contribution Percentage: Aaron = x% Azjae = x%</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                <asp:TableHeaderCell>Aaron| aspx page and server controls| The public default page that links everything together | GUI desgin and C#</asp:TableHeaderCell>
                    </asp:TableRow>
            </asp:Table>
        </p>
    </form>
</body>
</html>
