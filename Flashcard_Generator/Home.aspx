<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Flashcard_Generator.Home" %>

<%@ Register TagPrefix="reg" TagName="LoginPanel" Src="~/Login.ascx" %>
<%@ Register TagPrefix="reg" TagName="SignUpPanel" Src="~/SignUp.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col"></div>

        <div class="col panel-register">
            <asp:Panel runat="server" ID="pnlLogin" Visible="true" CssClass="d-flex flex-column justify-content-center align-items-center">
                <reg:LoginPanel runat="server" ID="LoginPanel"></reg:LoginPanel>
                <p>Don't have an account? <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-word" OnClick="btnRegister_Click" /></p>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlSignUp" Visible="false" CssClass="d-flex flex-column justify-content-center align-items-center">
                <reg:SignUpPanel runat="server" ID="SignUpPanel"></reg:SignUpPanel>
                <p>Already have an account? <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-word" OnClick="btnLogin_Click" /></p>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
