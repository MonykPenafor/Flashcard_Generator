
<%@ Page Title="Flashcard Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGenerator.aspx.cs" Inherits="Flashcard_Generator.FlashcardGenerator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>HOW TO CREATE THE FLASHCARDS:</h3>

        <p>- FILL THE BOXES LIKE IN THE EXAMPLE... </p>



        <div class="form-group">
            <label for="txtUsername">USERNAME:</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtIdiom" >IDIOM:</label>
            <asp:TextBox ID="txtIdiom" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtIdiom" >IDIOM TARGET:</label>
            <asp:TextBox ID="TextIdiom2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtCategory">FLASHCARD SET TITLE:</label>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        


<%--        <%var memos_ids = new string[] {"txtVocabularyMyLanguag","txtTranslatio","txtTi","txtVocLanguageLearnin","txtWordOrPhras","txtSimplifie"};
            var labels = new string[] {"FOCUS (ENGLISH):","WORD/PHRASE (ENGLSIH):","TIPS:","FOCUS (LANGUAGE STUDYING):","WORD/PHRASE (LANGUAGE STUDYING):","PRONUNCIATION/SIMPLIFICATION:"};
            

                string divTemplate = @"<div class='form-group label-memo'> <label for='{0}' class='flashcard-label'>{1}</label>
                <asp:TextBox ID='{0}' runat='server' CssClass='flashcard-textBox paola penafor monyk form-control multiline-textbox' TextMode='MultiLine'></asp:TextBox>
                </div>";

            foreach (string memoId in memos_ids)
            {
                int index = Array.IndexOf(memos_ids, memoId);
                string div = string.Format(divTemplate, memoId, labels[index]);

                // Adicione a div gerada ao HTML (ex: usando Response.Write)
                Response.Write(div);
            }
          %>--%>



        <div class="form-group label-memo">
            <label for="txtVocabularyMyLanguage" class="flashcard-label">FOCUS (ENGLISH):</label>
            <asp:TextBox ID="txtVocabularyMyLanguage" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group label-memo">
            <label for="txtTranslation" class="flashcard-label">WORD/PHRASE (ENGLSIH):</label>
            <asp:TextBox ID="txtTranslation" runat="server" CssClass="flashcard-textBox mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        

        <div class="form-group label-memo">
            <label for="txtTip" class="flashcard-label">TIPS:</label>
            <asp:TextBox ID="txtTip" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group label-memo">
            <label for="txtVocLanguageLearning" class="flashcard-label">FOCUS (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtVocLanguageLearning" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        

        <div class="form-group label-memo">
            <label for="txtWordOrPhrase" class="flashcard-label">WORD/PHRASE (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtWordOrPhrase" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        
        
        <div class="form-group label-memo">
            <label for="txtSimplified" class="flashcard-label">PRONUNCIATION / SIMPLIFICATION:</label>
            <asp:TextBox ID="txtSimplified" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" TextMode="MultiLine"></asp:TextBox>
        </div>        



        <asp:Button ID="Button1" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="CreateFlashcards" />
    
    </div>
</asp:Content>