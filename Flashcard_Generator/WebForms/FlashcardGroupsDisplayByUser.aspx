<%@ Page Title="My flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplayByUser.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplayByUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">



        <div class="row" style="align-items: center;">
            <div class="col-10">
                <h2 class="mon">MY FLASHCARDS</h2>
            </div>
            <div class="col-2">
                <asp:ImageButton runat="server" CssClass="btn btn-add" OnClick="btnNewFlashcardGroup_Click" ImageUrl="~/Assets/Icons/add.png" AlternateText="New Flashcard Group" />
            </div>

        </div>

        <div id="toast"></div>

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

