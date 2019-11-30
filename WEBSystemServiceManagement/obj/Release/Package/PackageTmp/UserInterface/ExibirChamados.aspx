<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibirChamados.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.ExibirChamados" %>

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
                    <a href="~/" runat="server" class="navbar-brand">Sair</a>
                    
            </div>                                
        </div>
    </div>
 </div>
<!--FIM DO CABEÇALHO-->

<form id="TelaForm" runat="server">
<div class="BodyContent">

        
    <!--INÍCIO DO MENU LATERAL-->
    
<div class="Menu-Left-Bar">              
            <a href="./ExibirChamados" runat="server" class="list-group-item list-group-item-action bg-light">Exibir Solicitações</a>
            <a href="./CriarNovoChamado" runat="server" class="list-group-item list-group-item-action bg-light">Criar Nova Solicitação</a>
            <a href="./Relatorios" runat="server" class="list-group-item list-group-item-action bg-light">Relatórios</a>
            <a href="./Pesquisar" runat="server" class="list-group-item list-group-item-action bg-light">Pesquisar Solicitações</a>
            <a href="./AdminIndex" runat="server" class="list-group-item list-group-item-action bg-light" id="AdminBtn">Admin</a>

</div>
<!--FIM DO MENU LATERAL-->

    <div class="BodyContent-Center ">

<div class="Container-Filtros">
    
<b>Filtros Rápidos:</b>

    <asp:LinkButton ID="AbertoLink" runat="server" OnClick="ExibeChamadosAbertos" >Aberto</asp:LinkButton>
    <asp:LinkButton ID="MyGroupLink" runat="server"  >Designados ao Meu Grupo</asp:LinkButton>
    <asp:LinkButton ID="ToMeLink" runat="server"  >Designados a Mim</asp:LinkButton>
    <asp:LinkButton ID="PendentesLink" runat="server" OnClick="ExibeChamadosPendentes" >Pendentes</asp:LinkButton>
    <asp:LinkButton ID="EmAndamentoLink" runat="server" OnClick="ExibeChamadosEmAndamento">Em andamento</asp:LinkButton>
    <asp:LinkButton ID="CanceladosLink" runat="server"  OnClick="ExibeChamadosCancelados">Cancelados</asp:LinkButton>
    <asp:LinkButton ID="ConcluidosLink" runat="server"  OnClick="ExibeChamadosConcluidos">Concluídos</asp:LinkButton>


 </div>
        <br />

        
                    <asp:GridView ID="GridChamados" runat="server" OnSelectedIndexChanged="EditSelectChamado" Width="1000px" CssClass="mGrid" horizontalalign="center" HeaderStyle-HorizontalAlign="Center">
                        <columns>
                        <asp:commandfield selecttext="Editar" showselectbutton="True"  ControlStyle-ForeColor="Blue" HeaderText="Alterar Chamado" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                            </asp:commandfield>
                        </columns>                                              
                    </asp:GridView>
        
</div>
   
</div>
</form>
</body>
</html>
