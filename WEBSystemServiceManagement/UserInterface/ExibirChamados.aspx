<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibirChamados.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.ExibirChamados" %>

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
                    <a href="./" runat="server" class="navbar-brand">Pesquisar</a>
            </div>                                
        </div>
    </div>
 </div>
<!--FIM DO CABEÇALHO-->

<form id="TelaForm" runat="server">
<div class="BodyContent">
    <!--INÍCIO DO MENU LATERAL-->
<div class="Menu-Left-Bar">
            <a href="./ExibirChamados" runat="server" class="MenuLink">Exibir Solicitações</a>
            <a href="./CriarNovoChamado" runat="server" class="MenuLink">Criar Nova Solicitação</a>
            <a href="./" runat="server" class="MenuLink">Relatórios</a>
            <a href="./" runat="server" class="MenuLink">Pesquisar Solicitações</a>
            <a href="./" runat="server" class="MenuLink">Admin</a>
            <a href="../" runat="server" class="MenuLink">Sair</a>
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


                    <asp:GridView ID="GridChamados" runat="server" OnSelectedIndexChanged="EditSelectChamado" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1000px">
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
                        <asp:commandfield selecttext="Editar Chamado" showselectbutton="True"  ControlStyle-ForeColor="Blue" HeaderText="Alterar Chamado" />
                        </columns>
                                              
                    </asp:GridView>
        

</div>
   
</div>
</form>
</body>
</html>
