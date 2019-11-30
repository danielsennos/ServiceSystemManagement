<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarNovoChamado.aspx.cs" Inherits="WEBSystemServiceManagement.CriarNovoChamado" %>

<link href="../Content/bootstrap.css" rel="stylesheet" />
<head>
<title>SSM Software</title>
</head>
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


    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL-->
<div class="Menu-Left-Bar">            
            <a href="./ExibirChamados" runat="server" class="list-group-item list-group-item-action bg-light">Exibir Solicitações</a>
            <a href="./CriarNovoChamado" runat="server" class="list-group-item list-group-item-action bg-light">Criar Nova Solicitação</a>
            <a href="./Relatorios" runat="server" class="list-group-item list-group-item-action bg-light">Relatórios</a>
            <a href="./Pesquisar" runat="server" class="list-group-item list-group-item-action bg-light">Pesquisar Solicitações</a>

</div>
        <!--FIM DO MENU LATERAL-->
        <div class="BodyContent-Center">

            <form id="FormCriarNovo" runat="server">
                <div class="ColumFixedLeft">
                    Tipo da Solicitação:
                               <select id="TipoSolicitacao" name="TipoSolicitacao" runat="server" class="InputDefault">
                   <option value="REQ">Solicitação</option>
                   <option value="INC">Falha ou Erro</option>
               </select>

                    Cliente:
                    <asp:DropDownList ID="Cliente" class="InputDefault" runat="server" OnSelectedIndexChanged="CarregaRequisitantes" AutoPostBack="true" ></asp:DropDownList>

                    <br />
                    Requisitante:
                    <asp:DropDownList ID="Requisitante" class="InputDefault" runat="server"></asp:DropDownList>

                    <br />
                    Categoria:
              <asp:DropDownList ID="Categoria" class="InputDefault" runat="server"></asp:DropDownList>

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

                    <br />
                    Grupo Designado: <br />
               <asp:DropDownList ID="GrupoDesignado" class="InputDefault" runat="server" OnSelectedIndexChanged="CarregaDesignados" AutoPostBack="true"></asp:DropDownList>

                    <br />
                    Designado:<br />
                 <asp:DropDownList ID="Designado" class="InputDefault" runat="server"></asp:DropDownList>


                    <asp:Button ID="SalvarBtn" runat="server" Text="Salvar" OnClick="SalvarChamado" />
                    <asp:Button ID="CancelarBtn" runat="server" Text="Cancelar" OnClick="ExibeChamadosLoad"/>

                </div>

            </form>

        </div>
    </div>
</body>
</html>
