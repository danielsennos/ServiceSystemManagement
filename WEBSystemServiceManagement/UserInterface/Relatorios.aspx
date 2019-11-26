<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Relatorios" %>
<link href="../Content/bootstrap.css" rel="stylesheet" />

<head>
<title>SSM Software</title>
</head>

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
                    <a href="./Pesquisar" runat="server" class="navbar-brand">Pesquisar</a>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DO CABEÇALHO-->


    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL DE RELATÓRIOS-->
        <div class="Menu-Left-Bar">
            <a href="./" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Chamados por Cliente</a>
            <a href="./" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Tempo Médio de Atendimento</a>
            <a href="./" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Chamados Abertos no Mês</a>
            <a href="./" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Categorias mais solicitadas</a>
            <a href="./ExibirChamados" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Voltar</a>
        </div>

        
        <!--FIM DO MENU LATERAL DE RELATÓRIOS -->

        <div class="BodyContent-Center">
            <form id="RelatorioForm" runat="server">
                <asp:GridView ID="GridRelatorio" runat="server">
                        
                    </asp:GridView>
            </form>           

            </div>

</div>
    </body>
</html>
