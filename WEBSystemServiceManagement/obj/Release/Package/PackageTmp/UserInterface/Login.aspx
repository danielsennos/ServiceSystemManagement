<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEBSystemServiceManagement.Login" %>
<link href="../Content/bootstrap.css" rel="stylesheet" />
<head>
<title>Login - SSM Software</title>
</head>

<html>
    <body>
            <!--INICIO DO CABEÇALHO CONTENDO OS LINKS DE ACESSO RÁPIDO-->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-collapse collapse">
                <div class="navbar-nav">
                    <a href="../" runat="server" class="navbar-brand">Página Inicial</a>
                    <a href="~/Contact" runat="server" class="navbar-brand">Ajuda</a>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DO CABEÇALHO-->

        <div class="BodyContent-Center">
            <form id="LoginForm" runat="server">
            <b>Login:</b> <br />
            <input id="LoginName" class="InputDefault" runat="server" type="text" /><br />
            <b>Senha:</b><br />
            <input id="LoginPassword" class="InputDefault" runat="server" type="password" /><br /><br />
            <asp:Button ID="AcessarBtn" runat="server" Text="Acessar" OnClick="Acessar" />
            <asp:Button ID="EsqueciSenhaBtn" runat="server" Text="Esqueci Minha Senha" OnClick="EsqueciMinhaSenha" />
</form>
        </div>
    </body>
</html>
