
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
            <asp:RequiredFieldValidator ID="rfvSourceLanguage" runat="server" ControlToValidate="txtSourceLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />

            <label for="txtTargetLanguage">TARGET LANGUAGE:</label>
            <asp:TextBox ID="txtTargetLanguage" runat="server" CssClass="form-control" maxlength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTargetLanguage" runat="server" ControlToValidate="txtTargetLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />

            <label for="txtCategory">FLASHCARD SET TITLE:</label>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" maxlength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategory" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />

            <label for="ddlLanguageProficiency">Language Proficiency:</label>
            <asp:DropDownList ID="ddlLanguageProficiency" runat="server" CssClass="form-control">
                <asp:ListItem Value="--">--</asp:ListItem>
                <asp:ListItem Value="A1">A1</asp:ListItem>
                <asp:ListItem Value="A2">A2</asp:ListItem>
                <asp:ListItem Value="B1">B1</asp:ListItem>
                <asp:ListItem Value="B2">B2</asp:ListItem>
                <asp:ListItem Value="C1">C1</asp:ListItem>
                <asp:ListItem Value="C2">C2</asp:ListItem>
            </asp:DropDownList>

            <label for="ddlPrivacySetting">Privacy Setting: </label>
            <asp:DropDownList ID="ddlPrivacySetting" runat="server" CssClass="form-control">
                <asp:ListItem Value="true">Public</asp:ListItem>
                <asp:ListItem Value="false">Private</asp:ListItem>
            </asp:DropDownList>

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

        
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"/>



        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="btnCreateFlashcards_Click" />
    
    </div>
</asp:Content>