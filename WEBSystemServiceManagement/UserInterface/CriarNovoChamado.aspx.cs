using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement
{
    public partial class CriarNovoChamado : System.Web.UI.Page
    {
        Repository SQLConnect = new Repository();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["user_authenticated"] != null)
                {
                    if (Convert.ToInt32(Session["user_id_permisson"]) == 0 || Convert.ToInt32(Session["user_id_permisson"]) == 1 || Convert.ToInt32(Session["user_id_permisson"]) == 3 || Convert.ToInt32(Session["user_id_permisson"]) == 4)
                    {
                        String queryCategoria = @"SELECT CATEGORIA FROM CATEGORIA_CHAMADO";
                        var ListaCategoria = SQLConnect.CarregaCategorias(queryCategoria);
                        foreach (var item in ListaCategoria)
                        {
                            Categoria.Items.Add(item.ToString());

                        }
                        String queryGrupo = @"SELECT GRUPO_NOME FROM GRUPO_USUARIO";
                        var ListaGrupo = SQLConnect.CarregaGrupoUsuario(queryGrupo);
                        foreach (var item in ListaGrupo)
                        {
                            GrupoDesignado.Items.Add(item.ToString());
                        }
                        String queryEmpresa = @"SELECT EMPRESA_NOME FROM EMPRESAS";
                        var ListaEmpresa = SQLConnect.CarregaEmpresa(queryEmpresa);
                        foreach (var item in ListaEmpresa)
                        {
                            Cliente.Items.Add(item.ToString());
                        }
                        String queryRequisitante = @"SELECT NOME_CLIENTE FROM CLIENTE WHERE ID_EMPRESA = (SELECT ID FROM (SELECT ID_EMPRESA AS ID FROM EMPRESAS WHERE EMPRESA_NOME ='" + Cliente.SelectedValue + "') AS TEMP)";
                        var ListaRequisitante = SQLConnect.CarregaCliente(queryRequisitante);
                        foreach (var item in ListaRequisitante)
                        {
                            Requisitante.Items.Add(item.ToString());
                        }
                        String queryDesignado = @"SELECT NOME_USUARIO FROM USUARIOS WHERE ID_GRUPO = (SELECT ID FROM (SELECT ID_GRUPO AS ID FROM GRUPO_USUARIO WHERE GRUPO_NOME = '" + GrupoDesignado.SelectedValue + "') AS TEMP);";
                        var ListaDesignado = SQLConnect.CarregaDesignado(queryDesignado);
                        foreach (var item in ListaDesignado)
                        {
                            Designado.Items.Add(item.ToString());
                        }
                        Session.Timeout = 20;
                    }
                    else
                    {
                        Response.Write("<script>alert('Permissões insificientes...')</script>");
                    }
                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }
            }

        }

        
        protected void CarregaRequisitantes(object sender, EventArgs e)
        {             

            Requisitante.Items.Clear();

            String queryRequisitante = @"SELECT NOME_CLIENTE FROM CLIENTE WHERE ID_EMPRESA = (SELECT ID FROM (SELECT ID_EMPRESA AS ID FROM EMPRESAS WHERE EMPRESA_NOME ='" + Cliente.SelectedValue + "') AS TEMP);";
            var ListaRequisitante = SQLConnect.CarregaCliente(queryRequisitante);
            foreach (var item in ListaRequisitante)
            {
                Requisitante.Items.Add(item.ToString());
            }
        }

        protected void CarregaDesignados(object sender, EventArgs e)
        {
            Designado.Items.Clear();

            String queryDesignado = @"SELECT NOME_USUARIO FROM USUARIOS WHERE ID_GRUPO = (SELECT ID FROM (SELECT ID_GRUPO AS ID FROM GRUPO_USUARIO WHERE GRUPO_NOME = '" + GrupoDesignado.SelectedValue + "') AS TEMP);";
            var ListaDesignado = SQLConnect.CarregaDesignado(queryDesignado);
            foreach (var item in ListaDesignado)
            {
                Designado.Items.Add(item.ToString());
            }
        }

            protected void SalvarChamado(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();

            mChamado.tipo_chamado = TipoSolicitacao.Value.ToString();
            mChamado.cliente = (Cliente.SelectedItem.ToString()); 
            mChamado.requisitante = (Requisitante.SelectedItem.ToString());
            mChamado.categoria = (Categoria.SelectedItem.ToString());
            mChamado.resumo_chamado = Resumo.Value;
            mChamado.urgencia = Urgencia.Value;
            mChamado.grupo_designado = GrupoDesignado.SelectedItem.ToString();
            mChamado.designado = Designado.SelectedItem.ToString();


           ChamadoController ChamadoController = new ChamadoController();
            var NewNumChamado = ChamadoController.SalvarChamado(mChamado);


            Response.Write("<script>alert('Solicitação: " + (mChamado.tipo_chamado+ NewNumChamado.PadLeft((8 - NewNumChamado.Count()), '0')) + "')</script>");

        }

        protected void ExibeChamadosLoad(object sender, EventArgs e)
        {
            ChamadoModel pModel = new ChamadoModel();
            Response.Redirect("~/UserInterface/ExibirChamados", true);
        }

    }
}