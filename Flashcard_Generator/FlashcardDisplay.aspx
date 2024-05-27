<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardDisplay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>FLASHCARDS CREATED SO FAR:</h3>



        <asp:Table ID="FlashcardTable" runat="server" CssClass="table table-striped">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell>Languages</asp:TableHeaderCell>
                <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                <asp:TableHeaderCell>Vocabulary / Translation</asp:TableHeaderCell>
                <asp:TableHeaderCell>Usage / Pronunciation / Translation</asp:TableHeaderCell>
                <asp:TableHeaderCell>Tips</asp:TableHeaderCell>
                <asp:TableHeaderCell>Level</asp:TableHeaderCell>
                <asp:TableHeaderCell>Visibility</asp:TableHeaderCell>
                <asp:TableHeaderCell>Created at</asp:TableHeaderCell>
                <asp:TableHeaderCell>   an edit logo </asp:TableHeaderCell>
                

            </asp:TableHeaderRow>
 
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox4" runat="server"/></asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>Public</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox5" runat="server"/></asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>Public</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox6" runat="server"/></asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>Public</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox7" runat="server"/></asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>Public</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="CheckBox8" runat="server"/></asp:TableCell>
                <asp:TableCell> japanese<br/>english </asp:TableCell>
                <asp:TableCell>verbs</asp:TableCell>
                <asp:TableCell>食べる<br/>to eat </asp:TableCell>
                <asp:TableCell>私はりんごを食べる<br/>わたしはりんごをたべる<br/>I eat an apple</asp:TableCell>
                <asp:TableCell>食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.</asp:TableCell>
                <asp:TableCell>A2</asp:TableCell>
                <asp:TableCell>Public</asp:TableCell>
                <asp:TableCell>2023</asp:TableCell>
                <asp:TableCell><asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Assets/Icons/edit.png" CssClass="edit edit-button"/></asp:TableCell>

            </asp:TableRow>
        </asp:Table>

        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Assets/Icons/bin.png" CssClass="edit edit-button"/>



    
    </div>
</asp:Content>