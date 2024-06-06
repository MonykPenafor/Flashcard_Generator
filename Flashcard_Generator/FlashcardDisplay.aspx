<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardDisplay" %>

<%@ Register TagPrefix="monyk" TagName="Flashcard" Src="~/TableRow.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>FLASHCARDS CREATED SO FAR:</h3>

        <asp:Repeater runat="server" ID="rptrFlashcardList">

            <HeaderTemplate>
                <table width="100%">
                    <tr>
                        <th>User</th>
                        <th>Languages</th>
                        <th>Category</th>
                        <th>Vocabulary / Translation</th>
                        <th>Usage / Pronunciation / Translation</th>
                        <th>Tips</th>
                        <th>Level</th>
                        <th>editbtn</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <monyk:Flashcard runat="server" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <tr style="background-color: #ccc">
                    <monyk:Flashcard runat="server" FlashcardTableRow="<%#Container.DataItem %>" />
                </tr>
            </AlternatingItemTemplate>

            <FooterTemplate>
                </table>
   
            </FooterTemplate>

        </asp:Repeater>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-center" OnClick="btnDelete_Click" />


    </div>
</asp:Content>
