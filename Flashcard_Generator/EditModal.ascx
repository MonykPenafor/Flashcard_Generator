<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditModal.ascx.cs" Inherits="Flashcard_Generator.EditModal" %>



        <div class="modal-form-group">
            <label for="txtSourceLanguage" class="modal-label">SOURCE LANGUAGE:</label>
            <textbox></textbox>

            <input runat="server" id="idee"/>


        </div>    

   
<%--     <div class="modal-form">

        
        <div class="modal-form-group">
            <label for="txtTargetLanguage" class="modal-label">TARGET LANGUAGE:</label>
            <asp:RequiredFieldValidator ID="rfvTargetLanguage" runat="server" ControlToValidate="txtTargetLanguage" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtTargetLanguage" runat="server" CssClass="modal-form-control" MaxLength="30"></asp:TextBox>

        </div>
        <div class="modal-form-group">
            <label for="txtCategory" class="modal-label">FLASHCARD SET TITLE:</label>
            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategory" ErrorMessage="required" CssClass="text-danger" Display="Dynamic" />
            <asp:TextBox ID="txtCategory" runat="server" CssClass="modal-form-control" MaxLength="30"></asp:TextBox>

        </div>
        <div class="modal-form-group">
            <label for="ddlLanguageProficiency" class="modal-label">Language Proficiency:</label>
            <asp:DropDownList ID="ddlLanguageProficiency" runat="server" CssClass="modal-form-control">
                <asp:ListItem Value="--">--</asp:ListItem>
                <asp:ListItem Value="A1">A1</asp:ListItem>
                <asp:ListItem Value="A2">A2</asp:ListItem>
                <asp:ListItem Value="B1">B1</asp:ListItem>
                <asp:ListItem Value="B2">B2</asp:ListItem>
                <asp:ListItem Value="C1">C1</asp:ListItem>
                <asp:ListItem Value="C2">C2</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="modal-form-group">
            <label for="ddlPrivacySetting" class="modal-label">Privacy Setting: </label>
            <asp:DropDownList ID="ddlPrivacySetting" runat="server" CssClass="modal-form-control">
                <asp:ListItem Value="true">Public</asp:ListItem>
                <asp:ListItem Value="false">Private</asp:ListItem>
            </asp:DropDownList>
        </div>    </div>--%>

