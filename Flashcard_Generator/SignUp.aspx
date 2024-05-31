﻿<%@ Page Title="SignUp Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Flashcard_Generator.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">


        <h3>SIGN UP TO CREATE YOUR FLASHCARDS</h3>

        <p>You can download and print the public flashcards even if not loged</p>

        
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"/>

        <div class="form-group login-form">
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" maxlength="20"></asp:TextBox>

            <label for="txtEmail" >Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" maxlength="80"></asp:TextBox>

            <label for="txtPassword" >Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" maxlength="20"></asp:TextBox>
        </div>



        
        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-primary btn-center" OnClick="btnSignUp_Click"/>




    </div>

</asp:Content>