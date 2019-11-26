<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarChamado.aspx.cs" Inherits="WEBSystemServiceManagement.EditarChamado" %>

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
            <form id="FormEditChamado" runat="server">
                <asp:TextBox ID="ID_Chamado" runat="server" class="InputDefault" Visible="false"></asp:TextBox>
                <asp:TextBox ID="NumChamado" runat="server" class="InputDefault" Visible="false"></asp:TextBox>
                <div class="ColumFixedLeft">
                    <b>Detalhes do Chamado:</b>
                    <br />
                  <br />
                    Tipo da Solicitação:<br />
                    <asp:TextBox ID="TipoSolicitacaoEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>
                    Número do Chamado:                    
                    <asp:TextBox ID="NumChamadoEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    Cliente:                    
                    <asp:TextBox ID="ClienteEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    <br />
                    Requisitante:
                     <asp:TextBox ID="RequisitanteEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    <br />
                    Categoria:
                 <asp:TextBox ID="CategoriaEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    Urgência:
                <asp:TextBox ID="UrgenciaEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    <br />
                    Grupo Designado:
                    <br />
                    <asp:TextBox ID="GrupoDesignadoEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    <br />
                    Designado:<br />
                    <asp:TextBox ID="DesignadoEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    Status:
                    <br />
                    <asp:TextBox ID="StatusEdit" runat="server" class="InputDefault" ReadOnly="true"></asp:TextBox>

                    Resumo:
              <textarea id="ResumoEdit" cols="40" runat="server" rows="10" style="border-radius: 5px" readonly></textarea>

                    <br />
                <asp:Button ID="SalvarEditBtn" runat="server" Text="Salvar" />
                <asp:Button ID="CancelarEditBtn" runat="server" Text="Cancelar" OnClick="Page_Load" />



                </div>
                <div class="ColumFixedRight">
                    <div class="Container-Filtros">
                        <b>Fluxo de Tabalho:</b>

                        <asp:LinkButton ID="AbertoChange" runat="server" OnClick="StatusAbertoChange" >Aberto</asp:LinkButton>
                        <asp:LinkButton ID="AndamentoChange" runat="server" OnClick="StatusEmAndamentoChange" >Em Andamento</asp:LinkButton>
                        <asp:LinkButton ID="PendenteChange" runat="server" OnClick="StatusPendenteChange">Pendente</asp:LinkButton>
                        <asp:LinkButton ID="ConcluidoChange" runat="server" OnClick="StatusConcluidoChange">Concluído</asp:LinkButton>
                        <asp:LinkButton ID="CanceladoChange" runat="server" OnClick="StatusCanceladoChange">Cancelar</asp:LinkButton>
                    </div>
                    <br />
                    <b>Anotações de Trabalho:</b>
                    <textarea id="AnotacaoEdit" cols="40" runat="server" rows="2" maxlength="180" style="border-radius: 5px"></textarea>
                    <asp:LinkButton ID="InserirNotaBtn" runat="server" OnClick="InsereAnotacao">Inserir Anotação</asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="GridAnotacoes" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
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
                        
                    </asp:GridView>
                </div>
               




            </form>
        </div>

    </div>


</body>
</html>
