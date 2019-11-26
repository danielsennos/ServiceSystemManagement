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
                    <a href="./Logout" runat="server" class="navbar-brand">Sair</a>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DO CABEÇALHO-->
    <form id="AdminForm" runat="server">
        <div class="BodyContent">
            <!--INÍCIO DO MENU LATERAL-->
            <div class="Menu-Left-Bar">
                <asp:LinkButton ID="EmpresaBtn" runat="server" class="MenuLink" OnClick="ExibirEmpresa">Empresas</asp:LinkButton>
                <asp:LinkButton ID="ClienteBtn" runat="server" class="MenuLink" OnClick="ExibirCliente">Clientes</asp:LinkButton>
                <asp:LinkButton ID="CategoriaBtn" runat="server" class="MenuLink" OnClick="ExibirCategoria">Categorias</asp:LinkButton>
                <asp:LinkButton ID="GrupoBtn" runat="server" class="MenuLink" OnClick="ExibirGrupoUsuario">Grupos de Usuario</asp:LinkButton>
                <asp:LinkButton ID="UsuarioBtn" runat="server" class="MenuLink" OnClick="ExibirUsuarios">Usuários do Sistema</asp:LinkButton>

                <a href="./ExibirChamados" runat="server" class="MenuLink" style="padding-left: 30px;">Voltar</a>

            </div>
            <!--FIM DO MENU LATERAL-->
            <div class="BodyContent-Center">
                <a href="./EmpresaAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirEmpresaBtn">Incluir Empresa</a>
                <a href="./ClienteAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirClienteBtn">Incluir Cliente</a>
                <a href="./CategoriaAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirCategoriaBtn">Incluir Categoria</a>
                <a href="./GrupoUsuarioAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirGrupoBtn">Incluir Grupos de Usuario</a>
                <a href="./UsuariosAdmin" runat="server" class="MenuLink" style="padding-bottom: 30px;" id="IncluirUsuarioBtn">Incluir Usuário do Sistema</a>
                

                <asp:GridView ID="GridEmpresa" runat="server" CellPadding="4" OnSelectedIndexChanged="EditarEmpresa" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />                    
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                     </Columns>
                    
                </asp:GridView>

                <asp:GridView ID="GridCliente" runat="server" CellPadding="4" OnSelectedIndexChanged="EditarCliente" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                         </Columns>
                </asp:GridView>

                <asp:GridView ID="GridCategoria" runat="server" CellPadding="4" OnSelectedIndexChanged="EditarCategoria" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                      </Columns>
                </asp:GridView>

                <asp:GridView ID="GridGrupoSuporte" runat="server" CellPadding="4" OnSelectedIndexChanged="EditarGrupoUsuario" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
                     </Columns>
                </asp:GridView>               


                 <asp:GridView ID="GridUsuarios" runat="server" CellPadding="4" OnSelectedIndexChanged="EditarUsuarios" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                    <Columns>
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ControlStyle-ForeColor="Blue" HeaderText="Editar" />
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
