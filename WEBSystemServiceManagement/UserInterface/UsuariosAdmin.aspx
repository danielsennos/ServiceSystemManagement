<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.UsuariosAdmin" %>

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

            <form id="UsuariosForm" runat="server">
                <input type="text" id="idusuario" runat="server" visible="false" readonly /><br />
                <b>Nome:</b><br />
                <asp:TextBox ID="NomeUsuarioInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>Login:</b><br />
                <asp:TextBox ID="LoginUsuarioInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>E-mail:</b><br />
                <asp:TextBox ID="EmailUusarioInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>Empresa:</b><br />
                <asp:DropDownList ID="EmpresaList" class="InputDefault" runat="server"></asp:DropDownList><br />
                <b>Grupo:</b><br />
                <asp:DropDownList ID="GrupoList" class="InputDefault" runat="server"></asp:DropDownList><br />        
                <b>Tipo de Permissão:</b><br />
                <asp:DropDownList ID="PermissaoList" class="InputDefault" runat="server"></asp:DropDownList><br />
                
                <b>Status:</b><br />
                <select id="Status" name="Status" runat="server" class="InputDefault">
                    <option value="A">Ativada</option>
                    <option value="D">Inativa</option>
                </select>
                <br /><br />
                <asp:Button ID="SalvartBtn" runat="server" Text="Salvar" OnClick="AtualizaUsuario" />
                <asp:Button ID="CancelarBtn" runat="server" Text="Cancelar" OnClick="Cancelar" />



            </form>

        </div>
    </div>
</body>
</html>