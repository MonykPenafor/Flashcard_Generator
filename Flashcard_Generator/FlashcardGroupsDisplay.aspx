<%@ Page Title="Groups of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGroupsDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardGroupsDisplay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="cntnrCategoryGroups">
        <h4>EXPLORE FLASHCARDS FROM OTHER USERS</h4>

        <asp:Repeater runat="server" ID="rptrFlashcardsByLanguageCombination">
            <HeaderTemplate>
                <div>
            </HeaderTemplate>

            <ItemTemplate>
                <div>
                    <h3><%# Eval("Languages") %></h3>

                    <asp:Repeater runat="server" ID="rptrFlashcardsByCategory" DataSource='<%# Eval("Categories") %>'>

                        <HeaderTemplate>
                            <div class="flashcard-group-container">
                        </HeaderTemplate>

                        <ItemTemplate>
                            <asp:Button runat="server" Text="<%# Container.DataItem %>" CssClass="btn-flashcard-group" />
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
