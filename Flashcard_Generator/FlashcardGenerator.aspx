
<%@ Page Title="Flashcard Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGenerator.aspx.cs" Inherits="Flashcard_Generator.FlashcardGenerator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>HOW TO CREATE THE FLASHCARDS:</h3>

        <p>- FILL THE BOXES LIKE IN THE EXAMPLE... </p>

        <div class="form-group">
            <label for="txtUser">USERNAME:</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control">paola</asp:TextBox>

            <label for="txtSourceLanguage">SOURCE LANGUAGE:</label>
            <asp:TextBox ID="txtSourceLanguage" runat="server" CssClass="form-control" maxlength="30"></asp:TextBox>

            <label for="txtTargetLanguage">TARGET LANGUAGE:</label>
            <asp:TextBox ID="TextIdiom2" runat="server" CssClass="form-control" maxlength="30"></asp:TextBox>

            <label for="txtCategory">FLASHCARD SET TITLE:</label>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" maxlength="30"></asp:TextBox>
        </div>



        <div class="form-group label-memo">
            <label for="txtVocabularySource" class="flashcard-label">FOCUS (ENGLISH):</label>
            <asp:TextBox ID="txtVocabularySource" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" maxlength="50"></asp:TextBox>
        </div>        
        
        <div class="form-group label-memo">
            <label for="txtVocabularyTarget" class="flashcard-label">FOCUS (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtVocabularyTarget" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine"  maxlength="50"></asp:TextBox>
        </div>     

        <div class="form-group label-memo">
            <label for="txtTranslation" class="flashcard-label">WORD/PHRASE (ENGLSIH):</label>
            <asp:TextBox ID="txtTranslation" runat="server" CssClass="flashcard-textBox mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine"></asp:TextBox>
        </div>       

        <div class="form-group label-memo">
            <label for="txtWordOrPhrase" class="flashcard-label">WORD/PHRASE (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtWordOrPhrase" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine"></asp:TextBox>
        </div>   

        <div class="form-group label-memo">
            <label for="txtSimplified" class="flashcard-label">PRONUNCIATION / SIMPLIFICATION:</label>
            <asp:TextBox ID="txtSimplified" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine"></asp:TextBox>
        </div>       

        <div class="form-group label-memo">
            <label for="txtTip" class="flashcard-label">TIPS:</label>
            <asp:TextBox ID="txtTip" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine"></asp:TextBox>
        </div>   



        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="btnCreateFlashcards_Click" />
    
    </div>
</asp:Content>