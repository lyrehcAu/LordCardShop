<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LordCardShop.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            <asp:Label ID="messageLbl" runat="server" Text=" " ForeColor="Red"></asp:Label><br />
            <div>
                <div>
                    <asp:Label ID="userNameLbl" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="usernameTb" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="emailTb" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="passwordTb" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label ID="confirmLbl" runat="server" Text="Confirmation Password"></asp:Label>
                    <asp:TextBox ID="confirmTb" runat="server"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label ID="DobLbl" runat="server" Text="Date of Birth"></asp:Label>
                    <asp:TextBox ID="DobTb" runat="server" TextMode="Date"></asp:TextBox><br />
                </div>
                <div>
                    <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
                    <asp:DropDownList ID="genderDdl" runat="server">
                        <asp:ListItem Text=" "></asp:ListItem>
                        <asp:ListItem Text="Male"></asp:ListItem>
                        <asp:ListItem Text="Female"></asp:ListItem>
                    </asp:DropDownList><br /><br />
                </div>
            </div>
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
        </div>
    </form>
</body>
</html>
