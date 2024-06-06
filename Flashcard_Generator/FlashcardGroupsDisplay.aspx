<%@ Page Title="Groups of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
        <h4>EXPLORE FLASHCARDS FROM OTHER USERS</h4>

        <div class="flashcard-group-container">
            <asp:PlaceHolder runat="server" ID="categoryGroups"></asp:PlaceHolder>
        </div>
    </div>

</asp:Content>
