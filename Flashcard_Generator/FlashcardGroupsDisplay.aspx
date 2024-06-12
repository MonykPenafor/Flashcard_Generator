<%@ Page Title="Groups of Flashcards" EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplay" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
        <h4>EXPLORE FLASHCARDS FROM OTHER USERS</h4>

        <asp:Repeater runat="server" ID="rptrFlashcardsByLanguageCombination">
            <HeaderTemplate>
                <div>
            </HeaderTemplate>

            <ItemTemplate>
                <div>
                    <h3><%# Eval("SourceLanguage") %> / <%# Eval("TargetLanguage") %></h3>

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
                <br />
            </ItemTemplate>

            <FooterTemplate></div></FooterTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
