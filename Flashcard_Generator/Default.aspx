<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Flashcard_Generator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Button ID="btnGenerator" runat="server" Text="Generator" CssClass="btn btn-primary btn-center" OnClick="goToGenerator" />

    </div>

</asp:Content>