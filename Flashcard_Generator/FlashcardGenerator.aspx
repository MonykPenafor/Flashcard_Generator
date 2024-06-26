<%@ Page Title="Flashcard Generator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlashcardGenerator.aspx.cs" Inherits="Flashcard_Generator.FlashcardGenerator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h3>HOW TO CREATE THE FLASHCARDS:</h3>

        <p>- FILL THE BOXES LIKE IN THE EXAMPLE... </p>

        <div class="form-group">

            <div class="row">

                <div class="col">
                    <label for="txtSourceLanguage">SOURCE LANGUAGE:</label>
                    <asp:RequiredFieldValidator ID="rfvSourceLanguage" runat="server" ControlToValidate="txtSourceLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
                    <asp:TextBox ID="txtSourceLanguage" runat="server" CssClass="form-control" MaxLength="30" placeholder="English"></asp:TextBox>
                </div>

                <div class="col">
                    <label for="txtTargetLanguage">TARGET LANGUAGE:</label>
                    <asp:RequiredFieldValidator ID="rfvTargetLanguage" runat="server" ControlToValidate="txtTargetLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
                    <asp:TextBox ID="txtTargetLanguage" runat="server" CssClass="form-control" MaxLength="30" placeholder="Japanese"></asp:TextBox>
                </div>
            </div>

            <br />

            <div class="row">

                <div class="col-6">
                    <label for="txtCategory">FLASHCARD GROUP TITLE: </label>
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategory" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" MaxLength="30" placeholder="Verbs"></asp:TextBox>
                </div>

                <div class="col-3">
                    <label for="ddlLanguageProficiency">LEVEL: </label>
                    <asp:DropDownList ID="ddlLanguageProficiency" runat="server" CssClass="form-control">
                        <asp:ListItem Value="--">--</asp:ListItem>
                        <asp:ListItem Value="A1">A1</asp:ListItem>
                        <asp:ListItem Value="A2">A2</asp:ListItem>
                        <asp:ListItem Value="B1">B1</asp:ListItem>
                        <asp:ListItem Value="B2">B2</asp:ListItem>
                        <asp:ListItem Value="C1">C1</asp:ListItem>
                        <asp:ListItem Value="C2">C2</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-3">
                    <label for="ddlPrivacySetting">PRIVACY SETTING: </label>
                    <asp:DropDownList ID="ddlPrivacySetting" runat="server" CssClass="form-control">
                        <asp:ListItem Value="true">Public</asp:ListItem>
                        <asp:ListItem Value="false">Private</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <br />

        <div class="form-group label-memo">
            <label for="txtVocabularyTarget" class="flashcard-label">VOCABULARY:</label>
            <asp:RequiredFieldValidator ID="rfvVocabularyTarget" runat="server" ControlToValidate="txtVocabularyTarget" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtVocabularyTarget" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"食べる"; "飲む"; "見る"'></asp:TextBox>
        </div>

        <div class="form-group label-memo">
            <label for="txtVocabularySource" class="flashcard-label">VOCABULARY TRANSLATION:</label>
            <asp:RequiredFieldValidator ID="rfvVocabularySource" runat="server" ControlToValidate="txtVocabularySource" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtVocabularySource" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"to eat"; "to drink"; "to watch"'></asp:TextBox>
        </div>

        <div class="form-group label-memo">
            <label for="txtWordOrPhrase" class="flashcard-label">EXAMPLE SENTENCE:</label>
            <asp:RequiredFieldValidator ID="rfvWordOrPhrase" runat="server" ControlToValidate="txtWordOrPhrase" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtWordOrPhrase" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"私はりんごを食べる"; "彼はコーヒーを飲む"; "彼女は映画を見る"'></asp:TextBox>
        </div>

        <div class="form-group label-memo">
            <label for="txtSimplified" class="flashcard-label">PRONUNCIATION / SIMPLIFICATION:</label>
            <asp:RequiredFieldValidator ID="rfvSimplified" runat="server" ControlToValidate="txtSimplified" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtSimplified" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"わたしはりんごをたべる"; "かれはコーヒーをのむ"; "かのじょはえいがをみる"'></asp:TextBox>
        </div>

        <div class="form-group label-memo">
            <label for="txtTranslation" class="flashcard-label">EXAMPLE SENTENCE TRANSLATION:</label>
            <asp:RequiredFieldValidator ID="rfvTranslation" runat="server" ControlToValidate="txtTranslation" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtTranslation" runat="server" CssClass="flashcard-textBox mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"I eat an apple"; "He drinks coffee"; "She watches a movie"'></asp:TextBox>
        </div>

        <div class="form-group label-memo">
            <label for="txtTip" class="flashcard-label">TIPS:</label>
            <asp:RequiredFieldValidator ID="rfvTip" runat="server" ControlToValidate="txtTip" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtTip" runat="server" CssClass="flashcard-textBox  mymemo big-textBox form-control multiline-textbox"
                TextMode="MultiLine" placeholder='"食べる: Often used in everyday conversation, pay attention to particles like を when forming sentences."; "飲む: Remember to use the correct context; can also mean to take (medicine)."; "見る: Can be used for watching, seeing, or looking. Usage depends on context."'></asp:TextBox>
        </div>

        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message" />

        <br />

        <asp:Button ID="btnCreateFlashcards" runat="server" Text="CREATE" CssClass="btn btn-danger btn-center" OnClick="btnCreateFlashcards_Click" />

    </div>
</asp:Content>
