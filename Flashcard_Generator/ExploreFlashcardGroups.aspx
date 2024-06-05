<%@ Page Title="Explore flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExploreFlashcardGroups.aspx.cs" Inherits="Flashcard_Generator.ExploreFlashcardGroups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">

    <h2>Explore flashcards</h2>

        <div class="flashcard-group-container">
            English/Japanese:
            <br />
            <asp:Button runat="server" ID="btnFlashcardGroup" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <asp:Button runat="server" ID="Button1" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <asp:Button runat="server" ID="Button2" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <asp:Button runat="server" ID="Button3" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <asp:Button runat="server" ID="Button4" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <asp:Button runat="server" ID="Button5" CssClass="btn-flashcard-group" Text="ADJECTIVES" />

            <br />
            <br />
            <br />

        </div>

    </div>

</asp:Content>
