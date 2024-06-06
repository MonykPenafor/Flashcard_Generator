<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardsDisplay" %>

<%@ Register TagPrefix="monyk" TagName="Flashcard" Src="~/TableRow.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>FLASHCARDS CREATED SO FAR:</h3>

        <asp:Repeater runat="server" ID="rptrFlashcardList">
            <HeaderTemplate>
                <table width="100%">
                    <tr class="flashcad-table-row">
                        <th class="flashcad-table-row-cell">Vocabulary / Translation</th>
                        <th class="flashcad-table-row-cell">Usage / Pronunciation / Translation</th>
                        <th class="flashcad-table-row-cell">Tips</th>
                        <th class="flashcad-table-row-cell">Proficiency</th>
                        <th class="flashcad-table-row-cell">User</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr class="flashcad-table-row">
                    <monyk:Flashcard runat="server" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <tr class="flashcad-table-row" style="background-color: #b8cfff2e">
                    <monyk:Flashcard runat="server" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </AlternatingItemTemplate>

            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>

        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-center"/>
    </div>
</asp:Content>
