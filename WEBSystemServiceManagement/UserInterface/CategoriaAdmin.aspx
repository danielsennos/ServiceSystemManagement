<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoriaAdmin.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.CategoriaAdmin" %>
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
                    <a href="./Pesquisar" runat="server" class="navbar-brand">Pesquisar</a>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DO CABEÇALHO-->
    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL-->
        <div class="Menu-Left-Bar">

            <a href="./AdminIndex" runat="server" class="MenuLink">Voltar</a>
            <a href="../" runat="server" class="MenuLink">Sair</a>

        </div>
        <!--FIM DO MENU LATERAL-->
        <div class="BodyContent-Center">

            <form id="CategoriaForm" runat="server">
                <input type="text" id="idcategoria" runat="server" visible="false" readonly /><br />
                <b>Categoria:</b><br />
                <asp:TextBox ID="NomeCategoriaInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>SLA de Resolução:</b><br />
                <asp:TextBox ID="SLAInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>Status:</b><br />
                <select id="Status" name="Status" runat="server" class="InputDefault">
                    <option value="A">Ativada</option>
                    <option value="D">Inativa</option>
                </select>
                <br /><br />
                <asp:Button ID="SalvartBtn" runat="server" Text="Salvar" OnClick="AtualizaCategoria" />
                <asp:Button ID="CancelarBtn" runat="server" Text="Cancelar" OnClick="Cancelar" />



            </form>

        </div>
    </div>
</body>
</html>