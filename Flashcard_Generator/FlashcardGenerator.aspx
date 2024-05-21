<%@ Page Title="Flashcard Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGenerator.aspx.cs" Inherits="Flashcard_Generator.FlashcardGenerator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>HOW TO CREATE THE FLASHCARDS:</h3>

        <p>- FILL THE BOXES LIKE IN THE EXAMPLE  </p>
        <p>- DON’T END THE LIST WITH A COMMA  </p>
        <p>- Put a set of double quotes " around each word in the list.  </p>
        <p> - Separate each word in the list by a comma.  </p>

        <asp:DropDownList ID="ddlDropdown" runat="server" CssClass="btn btn-primary">
            <asp:ListItem Text="Dropdown button" />
            <asp:ListItem Text="JAPANESE" />
            <asp:ListItem Text="THAI" />
            <asp:ListItem Text="MANDARIN" />
        </asp:DropDownList>

        <div class="form-group">
            <label for="txtTitle">FLASHCARD SET TITLE:</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        

        
        <div class="form-group">
            <label for="txtFocusEnglish" class="flashcard-label">FOCUS (ENGLISH):</label>
            <asp:TextBox ID="txtFocusEnglish" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group">
            <label for="tt1" class="flashcard-label">WORD/PHRASE (ENGLSIH):</label>
            <asp:TextBox ID="tt1" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        

        <div class="form-group">
            <label for="tt2" class="flashcard-label">TIPS:</label>
            <asp:TextBox ID="tt2" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group">
            <label for="tt3" class="flashcard-label">FOCUS (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="tt3" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        

        <div class="form-group">
            <label for="tt4" class="flashcard-label">WORD/PHRASE (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="tt4" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group">
            <label for="tt5" class="flashcard-label">PRONUNCIATION/SIMPLIFICATION:</label>
            <asp:TextBox ID="tt5" runat="server" CssClass="flashcard-textBox paola penafor monyk form-control" TextMode="MultiLine"></asp:TextBox>
        </div>        



        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="CreateFlashcards" />
    
    </div>
</asp:Content>