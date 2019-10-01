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
                <div class="ColumFixedLeft">
                    Número da Solicitação:
                <input id="num_chamado" class="InputDefault" runat="server" type="text" readonly />

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
              <textarea id="Resumo" cols="40" runat="server" rows="10" style="border-radius: 5px"></textarea>

                    Urgência:
               <select id="Urgencia" name="Urgencia" runat="server" class="InputDefault">
                   <option value="Baixa">Baixa</option>
                   <option value="Média">Média</option>
                   <option value="Alta">Alta</option>
                   <option value="Crítica">Crítica</option>
               </select>

                    Grupo Designado:
              <input id="GrupoDesignado" class="InputDefault" runat="server" type="text" />

                    Designado:
              <input id="Designado" class="InputDefault" runat="server" type="text" />
                
                  Anotações de Trabalho:
              <input id="Anotacoes" class="InputDefault" runat="server" type="text" />
                                 
                    
                    <asp:Button ID="Salvar" runat="server" Text="Salvar" OnClick="SalvarChamado" />

                    <br/>
                    teste de load:
                    <asp:DropDownList ID="categoriateste" runat="server" OnLoad="CarregaCategoria"></asp:DropDownList>
                    </div>
                    
                    </form>

        </div>
    </div>
</body>
</html>
