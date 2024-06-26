<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Study.aspx.cs" Inherits="Flashcard_Generator.Study" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">


        <div class="card text-white bg-dark" style="max-width: 28rem;">
            <div class="card-header">

                <div class="row">
                    <div class="col-2">
                        <h5>--</h5>
                    </div>
                    <div class="col-8">
                        <h4>target language</h4>
                    </div>
                    <div class="col-2">
                        <h5>level</h5>
                    </div>
                </div>

            </div>
            <div class="card-body">

                <h3 class="card-title">word target</h3>
                <h1 class="card-text">sentence example</h1>
                <p class="card-text">pronunciation</p>
            </div>
        </div>

        <br />
        <br />

        <div class="card text-white bg-dark" style="max-width: 28rem;">
            <div class="card-header">

                <div class="row">
                    <div class="col-2">
                        <h5>--</h5>
                    </div>
                    <div class="col-8">
                        <h4>source language</h4>
                    </div>
                    <div class="col-2">
                        <h5>level</h5>
                    </div>
                </div>

            </div>
            <div class="card-body">

                <h3 class="card-title">source word</h3>
                <h1 class="card-text">sentence tranlation</h1>
                <p class="card-text">tips</p>
            </div>
        </div>

    </div>
</asp:Content>
