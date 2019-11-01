<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Pesquisar" %>

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
            <a href="./ExibirChamados" runat="server" class="MenuLink">Exibir Solicitações</a>
            <a href="./CriarNovoChamado" runat="server" class="MenuLink">Criar Nova Solicitação</a>
            <a href="./Relatorios" runat="server" class="MenuLink">Relatórios</a>
            <a href="./Pesquisar" runat="server" class="MenuLink">Pesquisar Solicitações</a>
            <a href="./Admin" runat="server" class="MenuLink">Admin</a>
            <a href="../" runat="server" class="MenuLink">Sair</a>
        </div>
        <!--FIM DO MENU LATERAL-->
        <div class="BodyContent-Center">
             <form id="PesquisaForm" runat="server">

                 <b>Palavra-Chave: </b>
                 <input id="PesquisarInput" class="InputDefault" runat="server" type="text"  />
                 <asp:Button ID="PesquisarBtn" runat="server" Text="Pesquisar" OnClick="PesquisarAction" />

                 <br />
                        <asp:GridView ID="GridPesquisa" runat="server" OnSelectedIndexChanged="ExibirDetalhes" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
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
                        <columns>
                        <asp:commandfield selecttext="Exibir Detalhes" showselectbutton="True"  ControlStyle-ForeColor="Blue" HeaderText="Detalhes do Chamado" />
                        </columns>
                                              
                    </asp:GridView>
            </form>   
            </div>
          </div>

</body>
</html>
