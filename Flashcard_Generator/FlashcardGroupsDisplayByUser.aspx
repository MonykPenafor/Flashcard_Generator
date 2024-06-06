<%@ Page Title="My flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplayByUser.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplayByUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
        <h2>MY FLASHCARDS</h2>

        <asp:Repeater runat="server" ID="rptrFlashcardsByLanguageCombination">
            <HeaderTemplate>
                <div>
                    
            </HeaderTemplate>

            <ItemTemplate>
                <div><h3><%#Container.DataItem %></h3></div>
                
            </ItemTemplate>

            <FooterTemplate></div></FooterTemplate>
        </asp:Repeater>

    </div>

</asp:Content>







