<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Admin" %>

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
<form id="AdminForm" runat="server">
    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL-->
        <div class="Menu-Left-Bar">
            <asp:LinkButton ID="EmpresaBtn" runat="server" OnClick="ExibirEmpresa" >Empresas</asp:LinkButton>
            <asp:LinkButton ID="ClienteBtn" runat="server" OnClick="ExibirCliente">Clientes</asp:LinkButton>
            <asp:LinkButton ID="CategoriaBtn" runat="server" OnClick="ExibirCategoria">Categorias</asp:LinkButton>
            <a href="./" runat="server" class="MenuLink">Categorias</a>
            <a href="./" runat="server" class="MenuLink">Grupos de Suporte</a>
            <a href="./" runat="server" class="MenuLink">Analista de Suporte</a>
            <a href="./" runat="server" class="MenuLink">Usuários do Sistema</a>
            <a href="./ExibirChamados" runat="server" class="MenuLink">Voltar</a>
            <a href="../" runat="server" class="MenuLink">Sair</a>
                
        </div>
        <!--FIM DO MENU LATERAL-->
        <div class="BodyContent-Center">

            
                <asp:GridView ID="GridEmpresa" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>

                <asp:GridView ID="GridCliente" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>

                <asp:GridView ID="GridCategoria" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>

                <asp:GridView ID="GridGrupoSuporte" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>

                <asp:GridView ID="GridAnalistaSuporte" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridUsuarios" runat="server">
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                        <asp:CommandField SelectText="Excluir" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Excluir" />
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
