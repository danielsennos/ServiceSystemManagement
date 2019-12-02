<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEBSystemServiceManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Sistema de Gerenciamento de Serviços</h2>
        <p>Ferramenta para a gestão dos Serviços de TI. Crie, Controle e Exiba os serviços de TI em tempo real.</p>
        <p><a href="/UserInterface/Login" class="btn btn-primary btn-lg">Acesse Já! &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h4>Sistema de Gerenciamento de Serviços</h4>
            <p>
                Um sistema criado para que você tenha controle total dos seus serviços de TI. <br />
                <img src="Content/service.png" style="height:100px; width:300px; position:center; padding-left: 50px;"/>
            </p>
            <p>
                <a class="btn btn-default" href="/AboutSSM">Saiba Mais &roplus;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h4>Solicite Sua Avaliação</h4>
            <p>
                Um sistema customizado para atender às necessidades de seu negócio.<br />
                <img src="Content/avalia.PNG" style="height:100px; width:300px; position:center; padding-left: 50px;"/>
            </p>
            <p>
                <a class="btn btn-default" href="/OrcamentoForm">Solicite Já! &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h4>Sobre Nós</h4>
            <p>
                Desenvolvodores que buscam levar a baixo custo ferramentas capazes de ajudar e melhoro o seu negócio.<br />
                <img src="Content/equipe.jpg" style="height:100px; width:300px; position:center; padding-left: 50px;"/>
            </p>
            <p>
                <a class="btn btn-default" href="/About">Saiba Mais &roplus;</a>
            </p>
        </div>
    </div>

</asp:Content>
