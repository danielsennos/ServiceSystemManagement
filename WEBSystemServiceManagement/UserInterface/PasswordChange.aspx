<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.PasswordChange" %>
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
    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL-->
<div class="Menu-Left-Bar">            

            <a href="./AdminIndex" runat="server" class="list-group-item list-group-item-action bg-light" id="AdminBtn">Voltar</a>

</div>
        <!--FIM DO MENU LATERAL-->
        <div class="BodyContent-Center">

            <form id="PassordChangeForm" runat="server">
                <input type="text" id="iduser" runat="server" visible="false" readonly /><br />
                <b>Nova Senha:</b><br />
                <input type="password" id="Password1" maxlength="15" 
                    runat="server" class="InputDefault"/><br />
                <b>Repetir Nova Senha:</b><br />
                <input type="password" id="Password2" maxlength="15" runat="server" class="InputDefault"/><br />
                <br /><br />
                <asp:Button ID="SalvartBtn" runat="server" Text="Alterar Minha Senha" OnClick="AtualizarSenha" />
                <asp:Button ID="CancelarBtn" runat="server" Text="Cancelar" OnClick="Cancelar" />



            </form>

        </div>
    </div>
</body>
</html>
