<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Admin" %>
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
    <form id="AdminForm" runat="server">
        <div class="BodyContent">
            <!--INÍCIO DO MENU LATERAL-->
            <div class="Menu-Left-Bar">
                <asp:LinkButton ID="EmpresaBtn" runat="server" class="list-group-item list-group-item-action bg-light" OnClick="ExibirEmpresa">Empresas</asp:LinkButton>
                <asp:LinkButton ID="ClienteBtn" runat="server" class="list-group-item list-group-item-action bg-light" OnClick="ExibirCliente">Clientes</asp:LinkButton>
                <asp:LinkButton ID="CategoriaBtn" runat="server" class="list-group-item list-group-item-action bg-light" OnClick="ExibirCategoria">Categorias</asp:LinkButton>
                <asp:LinkButton ID="GrupoBtn" runat="server" class="list-group-item list-group-item-action bg-light" OnClick="ExibirGrupoUsuario">Grupos de Usuario</asp:LinkButton>
                <asp:LinkButton ID="UsuarioBtn" runat="server" class="list-group-item list-group-item-action bg-light" OnClick="ExibirUsuarios">Usuários do Sistema</asp:LinkButton>
                <a href="./PasswordChange" runat="server" class="list-group-item list-group-item-action bg-light">Alterar Minha Senha</a>

                <a href="./ExibirChamados" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left: 50px;">Voltar</a>

            </div>
            <!--FIM DO MENU LATERAL-->
            <div class="BodyContent-Center">
                <a href="./EmpresaAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirEmpresaBtn">Incluir Empresa</a>
                <a href="./ClienteAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirClienteBtn">Incluir Cliente</a>
                <a href="./CategoriaAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirCategoriaBtn">Incluir Categoria</a>
                <a href="./GrupoUsuarioAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirGrupoBtn">Incluir Grupos de Usuario</a>
                <a href="./UsuariosAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirUsuarioBtn">Incluir Usuário do Sistema</a>
                

                <asp:GridView ID="GridEmpresa" runat="server" OnSelectedIndexChanged="EditarEmpresa" Width="1000px" CssClass="mGrid">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                        </asp:CommandField>
                     </Columns>
                    
                </asp:GridView>

                <asp:GridView ID="GridCliente" runat="server" OnSelectedIndexChanged="EditarCliente" Width="1000px" CssClass="mGrid">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                        </asp:CommandField>
                         </Columns>
                </asp:GridView>

                <asp:GridView ID="GridCategoria" runat="server" OnSelectedIndexChanged="EditarCategoria" Width="1000px" CssClass="mGrid">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                        </asp:CommandField>
                      </Columns>
                </asp:GridView>

                <asp:GridView ID="GridGrupoSuporte" runat="server" OnSelectedIndexChanged="EditarGrupoUsuario" Width="1000px" CssClass="mGrid">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                        </asp:CommandField>
                     </Columns>
                </asp:GridView>               


                 <asp:GridView ID="GridUsuarios" runat="server" OnSelectedIndexChanged="EditarUsuarios" Width="1000px" CssClass="mGrid">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="" >
<ControlStyle ForeColor="Blue"></ControlStyle>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

</body>
</html>

<html>


<body>
</body>
</html>
