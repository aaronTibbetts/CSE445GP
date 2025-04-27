<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemeberPage.aspx.cs" Inherits="WebApplication1.MemeberPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Member Page</h1>
    <form id="form1" runat="server">
        <div>
                <h1>Upload a Text File</h1>
</div>
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
<p>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</p>
<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="TopTenWords" />
<p>
    <asp:Label ID="Label2" runat="server"></asp:Label>
</p>
        <div>
            <asp:TextBox ID="rcvBox" runat="server" Width="400px" Height="400px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="rcvButton" runat="server" Text="Retrieve Message" OnClick="rcvButton_Click" />
        </div>

        <div>
            Target Word: <asp:TextBox ID="targetWord" runat="server"></asp:TextBox>
            Replacement Word: <asp:TextBox ID="replacementWord" runat="server"></asp:TextBox>
            <asp:Button ID="replaceButton" runat="server" Text="Replace" OnClick="replaceButton_Click" />
        </div>
       <div>
           Message To Send:
            <asp:TextBox ID="sendBox" runat="server"></asp:TextBox>
            <asp:Button ID="sendButton" runat="server" Text="Send Message" OnClick="sendButton_Click" />
       </div>
        
        <div>
            <asp:Button ID="clearButton" runat="server" Text="Clear" OnClick="clearButton_Click" />
        </div>
         <div class="form-group">
                <label for="txtInput">Enter Text:</label>
                <asp:TextBox ID="txtInput" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label for="ddlOperation">Select Operation:</label>
                <asp:DropDownList ID="ddlOperation" runat="server">
                    <asp:ListItem Text="Reverse Text" Value="ReverseText" Selected="True" />
                    <asp:ListItem Text="Reverse Words" Value="ReverseWords" />
                    <asp:ListItem Text="Reverse Word Order" Value="ReverseWordOrder" />
                    <asp:ListItem Text="Reverse Paragraphs" Value="ReverseParagraphs" />
                    <asp:ListItem Text="Create Palindrome" Value="CreatePalindrome" />
                </asp:DropDownList>
            </div>
            
            <asp:Button ID="btnProcess" runat="server" Text="Process Text" CssClass="button" OnClick="btnProcess_Click" />
            
            <div class="result" runat="server" id="divResult" visible="false">
                <h3>Result:</h3>
                <pre><asp:Label ID="lblResult" runat="server"></asp:Label></pre>
            </div>
    </form>
</body>
</html>
