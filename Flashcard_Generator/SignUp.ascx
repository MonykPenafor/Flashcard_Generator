<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUp.ascx.cs" Inherits="Flashcard_Generator.SignUp1" %>

<div class="d-flex flex-column justify-content-center align-items-center">

    <h4>SIGN UP TO CREATE YOUR FLASHCARDS</h4>

    <p>You can download and print the public flashcards even if not loged</p>

    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message" />

    <div class="form-group login-form">
        <label for="txtUsername">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>

        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="80"></asp:TextBox>

        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
    </div><br />

    <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignUp_Click" />

</div>
