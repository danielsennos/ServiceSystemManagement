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
            <form id="LoginForm" runat="server" class="form-signin">
                <h4>SSM - Software</h4>
                <h5>Entrar no Sistema...</h5>
            <b>Usuário:</b> <br />
            <input id="LoginName" class="form-control" runat="server" type="text" /><br />
            <b>Senha:</b><br />
            <input id="LoginPassword" class="form-control" runat="server" type="password" /><br /><br />
            <asp:Button ID="AcessarBtn" runat="server" Text="Acessar" OnClick="Acessar" class="btn-signin"/>
            <asp:Button ID="EsqueciSenhaBtn" runat="server" Text="Recuperar senha" OnClick="EsqueciMinhaSenha" class="btn-forgotpassword"/>
</form>
        </div>
    </body>
</html>
