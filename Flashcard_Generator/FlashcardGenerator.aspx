
<%@ Page Title="Flashcard Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGenerator.aspx.cs" Inherits="Flashcard_Generator.FlashcardGenerator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>HOW TO CREATE THE FLASHCARDS:</h3>

        <p>- FILL THE BOXES LIKE IN THE EXAMPLE... </p>

        <div class="form-group">

            <label for="txtSourceLanguage">SOURCE LANGUAGE:</label>
            <asp:RequiredFieldValidator ID="rfvSourceLanguage" runat="server" ControlToValidate="txtSourceLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtSourceLanguage" runat="server" CssClass="form-control" maxlength="30" placeholder="English"></asp:TextBox>
            
            <label for="txtTargetLanguage">TARGET LANGUAGE:</label>
            <asp:RequiredFieldValidator ID="rfvTargetLanguage" runat="server" ControlToValidate="txtTargetLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtTargetLanguage" runat="server" CssClass="form-control" maxlength="30" placeholder="Japanese"></asp:TextBox>
            
            <label for="txtCategory">FLASHCARD SET TITLE:</label>
            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategory" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" maxlength="30" placeholder="Verbs"></asp:TextBox>

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
            TextMode="MultiLine" placeholder='"to eat", "to drink", "to watch", "to write", "to read", "to run", "to talk", "to listen", "to stand", "to sleep"'></asp:TextBox>
        </div>        
        
        <div class="form-group label-memo">
            <label for="txtVocabularyTarget" class="flashcard-label">FOCUS (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtVocabularyTarget" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" placeholder='"食べる", "飲む", "見る", "書く", "読む", "走る", "話す", "聞く", "立つ", "寝る"'></asp:TextBox>
        </div>     

        <div class="form-group label-memo">
            <label for="txtTranslation" class="flashcard-label">WORD/PHRASE (ENGLSIH):</label>
            <asp:TextBox ID="txtTranslation" runat="server" CssClass="flashcard-textBox mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" placeholder='"I eat an apple", "He drinks coffee", "She watches a movie", "I write a letter", "He reads a book", "She runs every morning", "I talk with my friends", "He listens to music", "I stand up immediately", "She goes to sleep early"'></asp:TextBox>
        </div>       

        <div class="form-group label-memo">
            <label for="txtWordOrPhrase" class="flashcard-label">WORD/PHRASE (LANGUAGE STUDYING):</label>
            <asp:TextBox ID="txtWordOrPhrase" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" placeholder='"私はりんごを食べる", "彼はコーヒーを飲む", "彼女は映画を見る", "私は手紙を書く", "彼は本を読む", "彼女は毎朝走る", "私は友達と話す", "彼は音楽を聞く", "私はすぐに立つ", "彼女は早く寝る"'></asp:TextBox>
        </div>   

        <div class="form-group label-memo">
            <label for="txtSimplified" class="flashcard-label">PRONUNCIATION / SIMPLIFICATION:</label>
            <asp:TextBox ID="txtSimplified" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" placeholder='"わたしはりんごをたべる", "かれはコーヒーをのむ", "かのじょはえいがをみる", "わたしはてがみをかく", "かれはほんをよむ", "かのじょはまいあさはしる", "わたしはともだちとはなす", "かれはおんがくをきく", "わたしはすぐにたつ", "かのじょははやくねる"'></asp:TextBox>
        </div>       

        <div class="form-group label-memo">
            <label for="txtTip" class="flashcard-label">TIPS:</label>
            <asp:TextBox ID="txtTip" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox" 
            TextMode="MultiLine" placeholder='"食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences.", "飲む: Remember to use the correct context; can also mean to take (medicine).", "見る: Can be used for watching, seeing, or looking. Usage depends on context.", "書く: Often combined with nouns to specify what is being written, e.g., 手紙を書く."...'></asp:TextBox>
        </div>   

        
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"/>



        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="btnCreateFlashcards_Click" />
    
    </div>
</asp:Content>