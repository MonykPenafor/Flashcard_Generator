﻿<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardsDisplay" %>
<%@ Register TagPrefix="monyk" TagName="Flashcard" Src="~/UserControls/TableRow2.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row" style="align-items:center;">
            <div class="col-10">
                <h2 id="selectedFC" class="mon"><%=Request.QueryString["source"]%> / <%=Request.QueryString["target"]%>: <%=Request.QueryString["category"] %></h2>
            </div>
            <div class="col-2">
                <button type="button" class="btn btn-dark" runat="server" onserverclick="GeneratePDF_Click">PDF</button></div>

        </div>
        <asp:Repeater runat="server" ID="rptrFlashcardList">
            <HeaderTemplate>
                <table width="100%">
                    <tr class="flashcad-table-row">
                        <th class="flashcad-table-row-cell">Vocabulary / Translation</th>
                        <th class="flashcad-table-row-cell">Usage / Pronunciation / Translation</th>
                        <th class="flashcad-table-row-cell">Tips</th>
                        <th class="flashcad-table-row-cell">Level</th>
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

    </div>
</asp:Content>
