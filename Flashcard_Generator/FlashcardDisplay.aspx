<%@ Page Title="Display of Flashcards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardDisplay.aspx.cs" Inherits="Flashcard_Generator.FlashcardDisplay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>FLASHCARDS CREATED SO FAR:</h3>

        <asp:GridView ID="FlashcardGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Question" HeaderText="Question" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
                <asp:BoundField DataField="Question" HeaderText="Question" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
                <asp:BoundField DataField="Question" HeaderText="Question" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
                <asp:BoundField DataField="Question" HeaderText="Question" />
                <asp:BoundField DataField="Answer" HeaderText="Answer" />
            </Columns>
        </asp:GridView>


        <asp:Table ID="FlashcardTable" runat="server" CssClass="table table-striped">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>select</asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell>Group</asp:TableHeaderCell>
                <asp:TableHeaderCell>Focus english</asp:TableHeaderCell>
                <asp:TableHeaderCell>translation</asp:TableHeaderCell>
                <asp:TableHeaderCell>tips</asp:TableHeaderCell>
                <asp:TableHeaderCell>focus</asp:TableHeaderCell>
                <asp:TableHeaderCell>phrase</asp:TableHeaderCell>
                <asp:TableHeaderCell>simplification</asp:TableHeaderCell>
                
                <asp:TableHeaderCell>edit</asp:TableHeaderCell>
                <asp:TableHeaderCell>delete</asp:TableHeaderCell>
                

            </asp:TableHeaderRow>
            <asp:TableRow>

                <asp:TableCell><asp:CheckBox ID="selectBox" runat="server"/></asp:TableCell>
                <asp:TableCell>just</asp:TableCell>
                <asp:TableCell>a example</asp:TableCell>
                <asp:TableCell>of how i want </asp:TableCell>
                <asp:TableCell>it to be</asp:TableCell>
                <asp:TableCell>i hope it</asp:TableCell>
                <asp:TableCell>works because</asp:TableCell>
                <asp:TableCell>this is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool projectthis is a cool project</asp:TableCell>
                <asp:TableCell>pencil</asp:TableCell>

                <asp:TableCell>
                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Assets/Icons/edit.png" />
                </asp:TableCell>

                <asp:TableCell>
                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Assets/Icons/bin.png" />
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>

    
    </div>
</asp:Content>