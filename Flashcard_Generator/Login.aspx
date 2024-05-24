<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Flashcard_Generator.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">


        <h3>LOGIN TO SEE YOUR FLASHCARDS</h3>

        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"/>

        <div class="form-group login-form">
            <label for="txtUser">Username or Email:</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" maxlength="10"></asp:TextBox>

            <label for="txtPassword" >Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>



        
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-center" OnClick="btnLogin_Click"/>



<%--        <asp:Button ID="btnGenerator" runat="server" Text="Generator" CssClass="btn btn-primary btn-center" OnClick="goToGenerator" />--%>

    </div>

</asp:Content>