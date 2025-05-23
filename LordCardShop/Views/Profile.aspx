<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LordCardShop.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>User Profile</h2>
            <asp:Label ID="messageLbl" runat="server" Text=" " ForeColor="Red"></asp:Label><br />
            <div>
                <asp:Label ID="usernameLbl" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="usernameTb" runat="server"></asp:TextBox><br />
            </div>
            <div>
                <asp:Label ID="emailLbl" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="emailTb" runat="server" TextMode="Email"></asp:TextBox><br />
            </div>
            <div>
                <asp:Label ID="genderLbl" runat="server" Text="Gender:"></asp:Label>
                <asp:DropDownList ID="genderDdl" runat="server">
                    <asp:ListItem Text=" "></asp:ListItem>
                    <asp:ListItem Text="Male"></asp:ListItem>
                    <asp:ListItem Text="Female"></asp:ListItem>
                </asp:DropDownList><br />
            </div>
            <div>
                <asp:Label ID="dobLbl" runat="server" Text="Date of Birth:"></asp:Label>
                <asp:TextBox ID="dobTb" runat="server" TextMode="Date"></asp:TextBox><br /><br />
            </div>
            <h3>Change Password</h3>
            <div>
                <asp:Label ID="oldPasswordLbl" runat="server" Text="Old Password:"></asp:Label>
                <asp:TextBox ID="oldPasswordTb" runat="server" TextMode="Password"></asp:TextBox><br />
            </div>
            <div>
                <asp:Label ID="newPasswordLbl" runat="server" Text="New Password:"></asp:Label>
                <asp:TextBox ID="newPasswordTb" runat="server" TextMode="Password"></asp:TextBox><br />
            </div>
            <div>
                <asp:Label ID="confirmPasswordLbl" runat="server" Text="Confirm Password:"></asp:Label>
                <asp:TextBox ID="confirmPasswordTb" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            </div>
            <asp:Button ID="updateBtn" runat="server" Text="Update Profile" OnClick="updateBtn_Click"/>
    </div>
</asp:Content>
