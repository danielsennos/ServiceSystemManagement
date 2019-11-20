<%@ Page Title="Personalizar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrcamentoForm.aspx.cs" Inherits="WEBSystemServiceManagement.OrcamentoForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Personalize sua ferramenta de gestão de serviços de TI.</h3>
    <h4>Envie suas informações para nós que entraremos em contato.</h4><br />

    Qual seu nome?
    <br />
    <input id="RequerenteInput" type="text" runat="server" /><br />
    Nome da Organização:
    <br />
    <input id="OrganizacaoInput" type="text" runat="server" /><br />
    Telefone para contato:<br />
    <input id="TelefoneInput" type="text" runat="server" /><br />
    E-mail:<br />
    <input id="EmailInput" type="text" runat="server" /><br />
    Conte-nos brevemente sobre sua necessidade ou<br />
    em que poderíamos personalizar nossa ferramente para você:<br />
    <textarea id="ResumoInput" runat="server"></textarea><br />
    <asp:Button ID="SalvarBtn" runat="server" Text="Enviar" OnClick="EnviarFormulario" />


    



    <br />
    <br />
    <h4>Caso prefira,
        <br />
        entre em contato com a gente!</h4>
        <address>
        <abbr title="Telefone">Telefone:</abbr>
        (21) 3200-0880
    </address>

    <address>
        <strong>Nosso E-mail:</strong>   <a href="mailto:rdcscomercial@gmail.com">rdcscomercial@gmail.com</a>
    </address>

    <br />
    <h3>Ajuda e Suporte</h3>
    <address>
        RDCS Systems<br />
        Rua XV de Novembro 158 Sala 1204, Niterói - RJ<br />
        <abbr title="Telefone">Telefone:</abbr>
        (21) 3200-0880
    </address>

    <address>
        <strong>Nosso Suporte:</strong>   <a href="mailto:ssmoperacao@gmail.com">ssmoperacao@gmail.com</a>
    </address>

</asp:Content>
