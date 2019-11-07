﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteAdmin.aspx.cs" Inherits="WEBSystemServiceManagement.UserInterface.ClienteAdmin" %>
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

            <form id="EmpresaForm" runat="server">
                <input type="text" id="idcliente" runat="server" visible="false" readonly /><br />
                <b>Nome:</b><br />
                <asp:TextBox ID="NomeClienteInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>Telefone:</b><br />
                <asp:TextBox ID="TelefoneInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>E-mail:</b><br />
                <asp:TextBox ID="EmailInput" runat="server" class="InputDefault"></asp:TextBox><br />
                <b>Empresa:</b><br />
                <asp:DropDownList ID="EmpresaList" class="InputDefault" runat="server"></asp:DropDownList><br />
                <b>Estado:</b><br />
                <asp:DropDownList ID="EstadosList" class="InputDefault" AutoPostBack="true" OnSelectedIndexChanged="CarregaItens" runat="server"></asp:DropDownList><br />
                <b>Cidade:</b><br />
                <asp:DropDownList ID="CidadeList" class="InputDefault" runat="server"></asp:DropDownList><br />
                <b>Status:</b><br />
                <select id="Status" name="Status" runat="server" class="InputDefault">
                    <option value="A">Ativada</option>
                    <option value="B">Inativa</option>
                </select>
                <br /><br />
                <asp:Button ID="SalvartBtn" runat="server" Text="Salvar" OnClick="AtualizaCliente" />
                <asp:Button ID="CancelarBtn" runat="server" Text="Cancelar" OnClick="Cancelar" />



            </form>

        </div>
    </div>
</body>
</html>