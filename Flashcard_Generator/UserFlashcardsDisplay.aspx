<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFlashcardsDisplay.aspx.cs" Inherits="Flashcard_Generator.UserFlashcardsDisplay" %>

<%@ Register TagPrefix="monyk" TagName="FlashcardRow" Src="~/TableRow.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>FLASHCARDS CREATED SO FAR:</h3>
        <h4 id="selectedFC"><%=Request.QueryString["source"]%> / <%=Request.QueryString["target"]%> - <%=Request.QueryString["category"] %></h4>

        <asp:Repeater runat="server" ID="rptrFlashcardList">
            <HeaderTemplate>
                <table width="100%">
                    <tr class="flashcad-table-row">
                        <th class="flashcad-table-row-cell">Vocabulary / Translation</th>
                        <th class="flashcad-table-row-cell">Usage / Pronunciation / Translation</th>
                        <th class="flashcad-table-row-cell">Tips</th>
                        <th class="flashcad-table-row-cell">Level</th>
                        <th class="flashcad-table-row-cell"></th>
                        <th class="flashcad-table-row-cell"></th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr class="flashcad-table-row" visible="false">
                    <monyk:FlashcardRow runat="server" Visible="true" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <tr class="flashcad-table-row" style="background-color: #b8cfff2e">
                    <monyk:FlashcardRow runat="server" Visible="true" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </AlternatingItemTemplate>

            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>

    </div>


    <!-- Modal Structure -->
    <div id="editModal" class="modal">
        <div class="modal-content">
            <span><button type="button" class="close" onclick="closeModal()">&times;</button></span>

            <h2>Edit Flashcard</h2>
            <p id="fcidModal"></p>

            <label for="wtarget">Vocabulary:</label>
            <input type="text" id="wtarget" name="wtarget" />

            <label for="wsource">Vocabulary Translation:</label>
            <input type="text" id="wsource" name="wsource" />

            <label for="etarget">Usage:</label>
            <input type="text" id="etarget" name="etarget" />

            <label for="pron">Pronunciation:</label>
            <input type="text" id="pron" name="pron" />

            <label for="esource">Usage Translation:</label>
            <input type="text" id="esource" name="esource" />

            <label for="tips">Tips:</label>
            <input type="text" id="tips" name="tips" />

            <label for="level">Level:</label>
            <input type="text" id="level" name="level" />

            <button class="btn btn-success">Save</button>

        </div>
    </div>

</asp:Content>
