<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Flashcard_Generator.Login1" %>

<div class="d-flex flex-column justify-content-center align-items-center">

    <h4>LOGIN TO SEE YOUR FLASHCARDS</h4>

    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message" />

    <div class="form-group login-form">
        <label for="txtUser">Username or Email:</label>
        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" MaxLength="80"></asp:TextBox>

        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
    </div><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
</div>
