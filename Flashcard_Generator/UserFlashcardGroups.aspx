<%@ Page Title="My flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFlashcardGroups.aspx.cs" Inherits="Flashcard_Generator.UserFlashcardGroups" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
    <h2>My flashcards</h2>

        <div class="flashcard-group-container">
            English/Japanese:
            <br />
            <asp:Button runat="server" ID="btnFlashcardGroup1" CssClass="btn-flashcard-group" Text="ADJECTIVES" OnClick="btnFlashcardGroup_Click"/>

            <br />
            <br />
            <br />

        </div>

    </div>

    <asp:PlaceHolder runat="server" id="categoryGroups">


    </asp:PlaceHolder>

</asp:Content>







