<%@ Page Title="Groups of Flashcards" EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplay" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">

        <h2 class="mon">EXPLORE FLASHCARDS</h2>

        <asp:Repeater runat="server" ID="rptrFlashcardsByLanguageCombination">
            <HeaderTemplate>
                <div>
            </HeaderTemplate>

            <ItemTemplate>
                <div>
                    <h3 class="mon"><%# Eval("SourceLanguage") %> / <%# Eval("TargetLanguage") %></h3>

                    <asp:Repeater runat="server" ID="rptrFlashcardsByCategory" DataSource='<%# Eval("Categories") %>' OnItemDataBound="rptrFlashcardsByCategory_ItemDataBound">
                        <HeaderTemplate>
                            <div class="flashcard-group-container">
                        </HeaderTemplate>

                        <ItemTemplate>
                            <asp:LinkButton runat="server" class="btn-flashcard-group" ID="btnFlashcardGroup" OnClick="btnFlashcardsDisplay_Click"><%# Container.DataItem %></asp:LinkButton>
                        </ItemTemplate>

                        <FooterTemplate></div></FooterTemplate>
                    </asp:Repeater>
                </div>
                <br />
            </ItemTemplate>

            <FooterTemplate></div></FooterTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
