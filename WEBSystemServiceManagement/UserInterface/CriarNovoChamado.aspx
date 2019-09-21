<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarNovoChamado.aspx.cs" Inherits="WEBSystemServiceManagement.CriarNovoChamado" %>

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
        <div class="BodyContent-Center">
            <form id="FormCriarNovo" runat="server">
                Número da Solicitação:
                <input id="NumSolicitacao" class="InputDefault" runat="server" type="text" readonly />

                Anotações de Trabalho:
                <input id="Text1" class="InputDefault" runat="server" type="text" />

                <br />
                Cliente:
            <input id="Cliente" class="InputDefault" runat="server" type="text" />

                <br />
                Requisitante:
                <input id="Requisitante" class="InputDefault" runat="server" type="text" />

                <br />
                Categoria:
              <input id="Categoria" class="InputDefault" runat="server" type="text" />

                <br />
                Resumo:
              <textarea id="Resumo" cols="40" rows="10" style="border-radius: 5px"></textarea>

                Urgência:
              <input id="Urgência" class="InputDefault" runat="server" type="text" />





            </form>
        </div>
</body>
</html>
