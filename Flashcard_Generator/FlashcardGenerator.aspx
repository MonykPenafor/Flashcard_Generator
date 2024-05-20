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
        
        <div>
            <label for="txtFocusEnglish" id="flashcard-label">FOCUS ENGLISH:</label>
            <asp:TextBox ID="txtFocusEnglish" runat="server" CssClass="flashcard-textBox paola penafor monyk" TextMode="MultiLine"></asp:TextBox>
        </div>

        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger" OnClick="CreateFlashcards" />
    
    </div>
</asp:Content>