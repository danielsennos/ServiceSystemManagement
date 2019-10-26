<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Relatorios" %>
<link href="../Content/bootstrap.css" rel="stylesheet" />

<html>
    <body>
        <!--INICIO DO CABEÇALHO CONTENDO OS LINKS DE ACESSO RÁPIDO-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-collapse collapse">
                <div class="navbar-nav">
                    <a href="./ExibirChamados" runat="server" class="navbar-brand">Painel</a>
                    <a href="./CriarNovoChamado" runat="server" class="navbar-brand">Nova Solicitação</a>
                    <a href="./Relatorios" runat="server" class="navbar-brand">Relatórios</a>
                    <a href="./" runat="server" class="navbar-brand">Pesquisar</a>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DO CABEÇALHO-->


    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL-->
        <div class="Menu-Left-Bar">
            <a href="./" runat="server" class="MenuLink">Relatório 1</a>
            <a href="./" runat="server" class="MenuLink">Relatório 2</a>
            <a href="./" runat="server" class="MenuLink">Relatório 3</a>
            <a href="./" runat="server" class="MenuLink">Relatório 4</a>
            <a href="./ExibirChamados" runat="server" class="MenuLink">Voltar</a>
            <a href="../" runat="server" class="MenuLink">Sair</a>
        </div>
        </div>

        <div class="BodyContent-Center">
            <form id="RelatorioForm" runat="server">
                <asp:GridView ID="GridRelatorio" runat="server">
                        
                    </asp:GridView>
            </form>           

            </div>
    </body>
</html>
