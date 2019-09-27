<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEBSystemServiceManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
               <div>
                   <b>
                   <br />
                   <br />
                   Bem Vindo ao Sistem Service Management<br />
                   <br />
                   <br />
                   <br />
                   Login:</b>
                   <input id="LoginUser" runat="server" type="text" />
                   <b>
                   <br />
                   <br />
                   Senha:</b>
                   <input id="SenhaLogin" name="SenhaLogin" runat="server" type="password" /><br />
                   <br />
&nbsp;<asp:Button ID="AcessarBtn" runat="server" Text="Acessar" OnClick="Acessar" />
                   <br />
                   <br />
                   <asp:Button ID="PassResetBtn" runat="server" Text="'Esqueci a Senha'" OnClick="SenhaRecover" />
        </div>
    </form>
</body>
</html>
