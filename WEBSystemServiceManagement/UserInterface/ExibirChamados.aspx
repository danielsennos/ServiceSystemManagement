<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibirChamados.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.ExibirChamados" %>

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
    <form id="LinksForm" runat="server">
<b>Filtros Rápidos:</b>
    <asp:LinkButton ID="AbertoLink" runat="server" OnClick="ExibeChamadosAbertos" >Aberto</asp:LinkButton>
    <asp:LinkButton ID="MyGroupLink" runat="server"  >Designados ao Meu Grupo</asp:LinkButton>
    <asp:LinkButton ID="ToMeLink" runat="server"  >Designados a Mim</asp:LinkButton>
    <asp:LinkButton ID="PendentesLink" runat="server" OnClick="ExibeChamadosPendentes" >Pendentes</asp:LinkButton>
    <asp:LinkButton ID="EmAndamentoLink" runat="server" >Em andamento</asp:LinkButton>
    <asp:LinkButton ID="CanceladosLink" runat="server"  >Cancelados</asp:LinkButton>
    <asp:LinkButton ID="EncerradosLink" runat="server"  >Encerrados</asp:LinkButton>
</form>
 </div>
        <br />
<form id="FormExibirChamados" runat="server">

                    <asp:GridView ID="GridChamados" runat="server">
                        
                    </asp:GridView>
</form>

</div>
   
</div>
</body>
</html>
