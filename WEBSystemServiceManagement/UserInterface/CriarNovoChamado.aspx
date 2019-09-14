<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarNovoChamado.aspx.cs" Inherits="WEBSystemServiceManagement.CriarNovoChamado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 152px;
        }
        #TextArea1 {
            width: 369px;
        }
        .auto-style1 {
            width: 391px;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            width: 133px;
        }
        .auto-style4 {
            width: 298px;
        }
        .auto-style5 {
            width: 391px;
            height: 29px;
        }
        .auto-style6 {
            height: 29px;
        }
        .auto-style7 {
            width: 299px;
            height: 213px;
        }
        .auto-style8 {
            width: 213px;
        }
    </style>
</head>
<body>

    <form id="CriarNovoChamadoForm" runat="server">    
        
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <b>Número da Solicitação:</b>
                </td>
                <td>
                    <b>Anotações de Trabalho:</b>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <input id="NumChamado" type="text" runat="server" class="auto-style4" disabled/></td>
                <td class="auto-style6">
                    <textarea id="TextArea1" class="auto-style2" name="S1"></textarea></td>
            </tr>
            <tr>
                <td class="auto-style1"><b>Cliente:</b></td>
                <td>
                    <input id="InserirAnotacaoBtn" runat="server" class="auto-style3" type="submit" value="Adicionar Anotação" /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="ClienteList" runat="server" Height="16px" Width="304px" OnSelectedIndexChanged="ClienteList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <b>Requisitante:</b></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="RequisitanteList" runat="server" Height="17px" Width="305px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                   <b>Categoria:</b></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="CategoriaList" runat="server" Height="16px" Width="306px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <b>Resumo:</b>  </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <textarea id="Resumo" class="auto-style7" name="Resumo" placeholder="Digite aqui o resumo da solicitação..."></textarea></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <b>Urgência:</b></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="UrgenciaList" runat="server" Height="16px" Width="302px">
                        <asp:ListItem>Baixo</asp:ListItem>
                        <asp:ListItem>Média</asp:ListItem>
                        <asp:ListItem>Alta</asp:ListItem>
                        <asp:ListItem>Crítica</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <b>Grupo Designado:</b></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="298px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <b>Designado:</b></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="17px" Width="290px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
        <p>
            <asp:Button ID="SalvarChamadoBtn" runat="server" Text="Salvar" Width="191px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="ResetBtn" class="auto-style8" type="reset" value="Cancelar" /></p>
        
    </form>
</body>
</html>
