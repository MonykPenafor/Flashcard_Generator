<%@ Page Title="My flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFlashcardGroups.aspx.cs" Inherits="Flashcard_Generator.UserFlashcardGroups" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
        <h2>MY FLASHCARDS</h2>

        <div class="flashcard-group-container">
            <asp:PlaceHolder runat="server" ID="categoryGroups"></asp:PlaceHolder>
        </div>
    </div>

</asp:Content>







