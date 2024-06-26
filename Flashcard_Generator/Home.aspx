<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Flashcard_Generator.Home" %>

<%@ Register TagPrefix="reg" TagName="LoginPanel" Src="~/Login.ascx" %>
<%@ Register TagPrefix="reg" TagName="SignUpPanel" Src="~/SignUp.ascx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="pnlLoginSignUp" Visible="true">
        <div class="row">

            <div class="col-8">
                <h2 class="mon">Create, customize, and study flashcards for any language</h2>
                <br />
                <h4 class="mon">Welcome to our Flashcard Generator! Our tool helps you create personalized flashcards to enhance your language learning. Whether you're a beginner or advanced learner, our flashcards make studying new vocabulary and phrases easy and effective.</h4>


                <img src="Assets/Icons/.png" />

            </div>

            <div class="col-4 container" style="align-self:center">
                <div class="panel-register">

                    <asp:Panel runat="server" ID="pnlLogin" Visible="true" CssClass="d-flex flex-column justify-content-center align-items-center">
                        <reg:LoginPanel runat="server" ID="LoginPanel"></reg:LoginPanel>
                        <p>
                            Don't have an account?
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-word" OnClick="btnRegister_Click" />

                            <%--<button type="button" onclick="switchPanel('<%= pnlLogin.ClientID %>','<%= pnlSignUp.ClientID %>')" class="btn-word">Register</button>--%>
                        </p>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlSignUp" Visible="false" CssClass="d-flex flex-column justify-content-center align-items-center">
                        <reg:SignUpPanel runat="server" ID="SignUpPanel"></reg:SignUpPanel>
                        <p>
                            Already have an account?
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-word" OnClick="btnLogin_Click" />
                            <%--<button type="button" onclick="switchPanel('<%= pnlLogin.ClientID %>','<%= pnlSignUp.ClientID %>')" class="btn-word">Login</button>--%>
                        </p>
                    </asp:Panel>

                </div>
            </div>

        </div>
    </asp:Panel>


    <asp:Panel runat="server" ID="pnlProfile" Visible="false">
        <div class="container">

            <h1>Profile Analysis</h1>
            <asp:Button runat="server" ID="btnLogOut" Text="Log Out" CssClass="btn-word" OnClick="btnLogOut_Click" />

        </div>
    </asp:Panel>


</asp:Content>
