﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibirChamados.aspx.cs" Inherits="WEBSystemServiceManagement.ExibirChamados" %>

<link href="../Content/bootstrap.css" rel="stylesheet" />

<html>

<body>
<!--INICIO DO CABEÇALHO CONTENDO OS LINKS DE ACESSO RÁPIDO-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-collapse collapse">
                <div class="navbar-nav">
                    <a href="~/UserInterface/ExibirChamados" runat="server" class="navbar-brand">Painel</a>
                    <a href="~/UserInterface/CriarNovoChamado" runat="server" class="navbar-brand">Nova Solicitação</a>
                    <a href="./" runat="server" class="navbar-brand">Relatórios</a>
                    <a href="./" runat="server" class="navbar-brand">Pesquisar</a>
            </div>                                
        </div>
    </div>
 </div>
<!--FIM DO CABEÇALHO-->


<div class="BodyContent">
    <!--INÍCIO DO MENU LATERAL-->
<div class="Menu-Left-Bar">
        <a href="~/UserInterface/ExibirChamados" runat="server" class="MenuLink">Exibir Solicitações</a>
        <a href="~/UserInterface/CriarNovoChamado" runat="server" class="MenuLink">Criar Nova Solicitação</a>
        <a href="./" runat="server" class="MenuLink">Pesquisar Solicitações</a>
        <a href="./" runat="server" class="MenuLink">Consultar Clientes</a>
        <a href="./" runat="server" class="MenuLink">Relatórios</a>
        <a href="./" runat="server" class="MenuLink">Admin</a>
        <a href="./" runat="server" class="MenuLink">Sair</a>
</div>
<!--FIM DO MENU LATERAL-->

    <div class="BodyContent-Center ">

<div class="Container-Filtros">
<b>Filtros Rápidos:</b>

    <a onclick="" runat="server">Abertos</a>
    <a onclick="" runat="server">Designados ao Meu Grupo</a>
    <a onclick="" runat="server">Designados a Mim</a>
    <a onclick="" runat="server">Pendentes</a>
    <a onclick="" runat="server">Em andamento</a>
    <a onclick="" runat="server">Cancelados</a>
    <a onclick="" runat="server">Encerrados</a>

 </div>




    </div>
   
</div>
</body>
</html>