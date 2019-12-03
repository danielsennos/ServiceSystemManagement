<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.Relatorios" %>
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

 <form id="RelatorioForm" runat="server">
    <div class="BodyContent">
        <!--INÍCIO DO MENU LATERAL DE RELATÓRIOS-->
        <div class="Menu-Left-Bar">
            <asp:LinkButton ID="Relatorio1" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width: 215px; left: 10px;" OnClick="Chamado_por_Empresa">Chamado por Empresa</asp:LinkButton>
            <asp:LinkButton ID="Relatorio2" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width: 215px; left: 10px;" OnClick="Tempo_Médio_de_Atendimento">Tempo Médio de Atendimento</asp:LinkButton>
            <asp:LinkButton ID="Relatorio3" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width: 215px; left: 10px;" OnClick="Chamados_Abertos_no_Mês">Chamados Abertos no Mês</asp:LinkButton>
            <asp:LinkButton ID="Relatorio4" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width: 215px; left: 10px;" OnClick="Categorias_mais_solicitadas">Categorias mais Solicitadas</asp:LinkButton>
            
            <a href="./ExibirChamados" runat="server" class="list-group-item list-group-item-action bg-light" style="padding-left:0px; width:215px; margin-left:10px">Voltar</a>
        </div>

        
        <!--FIM DO MENU LATERAL DE RELATÓRIOS -->

        <div class="BodyContent-Center">
            <b>Mês base:</b>
           <select id="MesAno" name="MesAno" runat="server" class="InputDefault">
                   <option value="12/2019">12/2019</option>
                   <option value="11/2019">11/2019</option>
                   <option value="10/2019">10/2019</option>
               </select>


                <asp:GridView ID="GridRelatorio" runat="server" Width="1000px" CssClass="mGrid">
                    </asp:GridView>
                       

            </div>

</div>
     </form>
    </body>
</html>
