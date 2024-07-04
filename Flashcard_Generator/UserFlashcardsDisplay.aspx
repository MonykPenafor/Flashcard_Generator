<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFlashcardsDisplay.aspx.cs" Inherits="Flashcard_Generator.UserFlashcardsDisplay" %>

<%@ Register TagPrefix="monyk" TagName="FlashcardRow" Src="~/TableRow.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="display:grid">

        <div id="toast"></div>

        <div class="row" style="align-items:center;">
            <div class="col-10">
                <h2 id="selectedFC" class="mon"><%=Request.QueryString["source"]%> / <%=Request.QueryString["target"]%>: <%=Request.QueryString["category"] %></h2>
            </div>
            <div class="col-2">
                <button type="button" runat="server" onserverclick="GeneratePDF" class="btn btn-dark">PDF </button>
            </div>
        </div>
        <br />
        <asp:Repeater runat="server" ID="rptrFlashcardList">
            <HeaderTemplate>
                <table width="100%">
                    <tr class="flashcad-table-row">
                        <th class="flashcad-table-row-cell">Vocabulary / Translation</th>
                        <th class="flashcad-table-row-cell">Usage / Pronunciation / Translation</th>
                        <th class="flashcad-table-row-cell">Tips</th>
                        <th class="flashcad-table-row-cell">Level</th>
                        <th class="flashcad-table-row-cell">Public</th>
                        <th class="flashcad-table-row-cell"></th>
                        <th class="flashcad-table-row-cell"></th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr class="flashcad-table-row" visible="true" id="<%# Eval("Id")%>">
                    <monyk:FlashcardRow runat="server" Visible="true" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <tr class="flashcad-table-row" visible="true" style="background-color: #b8cfff2e" id="<%# Eval("Id")%>">
                    <monyk:FlashcardRow runat="server" Visible="true" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </AlternatingItemTemplate>

            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>

        <br />

        <span style="justify-self: right"> <button class="btn-word" style="font-size:20px; color: blue" 
        onclick="deleteAllFlashcards('<%=HttpUtility.JavaScriptStringEncode(Request.QueryString["source"]) %>','<%=HttpUtility.JavaScriptStringEncode(Request.QueryString["target"])%>','<%=HttpUtility.JavaScriptStringEncode(Request.QueryString["category"]).Replace("\"", "&quot;")%>')">Delete Group Of Flashcards</button></span>

    </div>


    <!-- Modal Structure -->
    <div id="editModal" class="modal form">
        <div class="modal-content">
            <span>
                <button type="button" class="close" onclick="closeModal()">&times;</button></span>

            <h2>Edit Flashcard</h2>
            <p id="fcidModal"></p>

            <div class="row">
                <div class="col">
                    <label for="wtarget">Vocabulary:</label>
                    <input type="text" id="wtarget" name="wtarget" class="edit-1-row" required />
                </div>

                <div class="col">
                    <label for="wsource">Vocabulary Translation:</label>
                    <input type="text" id="wsource" name="wsource" class="edit-1-row" required />
                </div>

                <div class="col">
                    <label for="level">Level:</label>
                    <select id="level" name="level" class="edit-1-row">
                        <option value="--">--</option>
                        <option value="A1">A1</option>
                        <option value="A2">A2</option>
                        <option value="B1">B1</option>
                        <option value="B2">B2</option>
                        <option value="C1">C1</option>
                        <option value="C2">C2</option>
                    </select>
                </div>

                <div class="col">
                    <label for="isPublic">Visibility:</label>
                    <select id="isPublic" name="isPublic" class="edit-1-row">
                        <option value="true">Public</option>
                        <option value="false">Private</option>
                    </select>

                </div>
            </div>

            <label for="etarget">Usage:</label>
            <input type="text" id="etarget" name="etarget" required />

            <label for="pron">Pronunciation:</label>
            <input type="text" id="pron" name="pron" required />

            <label for="esource">Usage Translation:</label>
            <input type="text" id="esource" name="esource" required />

            <label for="tips">Tips:</label>
            <input type="text" id="tips" name="tips" required />

            <br />
            <br />

            <button class="btn btn-success btn-sm" type="button" onclick="saveChanges()">Save</button>

        </div>
    </div>

</asp:Content>
