<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LordCardShop.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="messageLbl" runat="server" Text=" " ForeColor="Red"></asp:Label><br />
            <div>
                <asp:Label ID="usernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="usernameTb" runat="server"></asp:TextBox><br />
            </div>
            <div>
                <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="passwordTb" runat="server"></asp:TextBox><br /><br />
            </div>
            <div>
                <asp:CheckBox ID="rememberCb" runat="server" Text="Remember Me"/><br /><br />
            </div>
           <%-- <div>
                <asp:LinkButton ID="asGuestLBtn" runat="server" OnClick="asGuestLBtn_Click">Login as guest</asp:LinkButton>
            </div>--%>
            <div>
                <asp:Label ID="registerLbl" runat="server" Text="Don't have an account?"></asp:Label>
                <a href="Register.aspx">Register here</a><br />
            </div>
            <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
        </div>
    </form>
</body>
</html>
