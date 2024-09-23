<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ContactUsProject.ContactUs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
</head>
<body>
    <form id="contactForm" runat="server">
        <div>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" />
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" />
        </div>
        <div>
            <label for="txtSubject">Subject:</label>
            <asp:TextBox ID="txtSubject" runat="server" />
        </div>
        <div>
            <label for="txtMessage">Message:</label>
            <asp:TextBox ID="txtMessage" TextMode="MultiLine" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="SendEmail" />
        </div>
    </form>
</body>
</html>
