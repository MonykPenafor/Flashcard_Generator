<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardDisplay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>FLASHCARDS CREATED SO FAR:</h3>



        <asp:Table ID="FlashcardTable" runat="server" CssClass="table table-striped">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell>User</asp:TableHeaderCell>
                <asp:TableHeaderCell>Languages</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                <asp:TableHeaderCell>Vocabulary / Translation</asp:TableHeaderCell>
                <asp:TableHeaderCell>Usage / Pronunciation / Translation</asp:TableHeaderCell>
                <asp:TableHeaderCell>Tips</asp:TableHeaderCell>
                <asp:TableHeaderCell>Level</asp:TableHeaderCell>
                <asp:TableHeaderCell>Created at</asp:TableHeaderCell>
                <asp:TableHeaderCell>Updated at</asp:TableHeaderCell>
                <asp:TableHeaderCell>editbtn</asp:TableHeaderCell>
            </asp:TableHeaderRow>


<%--
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox4" runat="server"/></asp:TableCell>
                <asp:TableCell>Paola</asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell>2024</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>--%>



        </asp:Table>


           
                
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-center" OnClick="btnDelete_Click"/>

    
    </div>
</asp:Content>