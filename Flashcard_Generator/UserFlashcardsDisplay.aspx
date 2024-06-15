﻿<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserFlashcardsDisplay.aspx.cs" Inherits="Flashcard_Generator.UserFlashcardsDisplay" %>

<%@ Register TagPrefix="monyk" TagName="Flashcard" Src="~/TableRow.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>FLASHCARDS CREATED SO FAR:</h3>
       <h4><%=Request.QueryString["source"]%> / <%=Request.QueryString["target"]%> - <%=Request.QueryString["category"] %></h4>
       
       <asp:UpdatePanel runat="server" ID="updPanel" UpdateMode="Conditional">
    <ContentTemplate>
       
       
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
                        <th class="flashcad-table-row-cell"></th>
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

         </ContentTemplate>
</asp:UpdatePanel>




        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-center" />
    </div>

    <!-- Modal Structure -->
    <div id="editModal" class="modal">
        <div class="modal-content">

            <span><button class="close" onclick="closeModal()">&times;</button></span>
            <h2>Edit Flashcard</h2>
            <p id="fcid"></p>
            
            <button class="btn btn-success">Save</button>
        </div>
    </div>


</asp:Content>
