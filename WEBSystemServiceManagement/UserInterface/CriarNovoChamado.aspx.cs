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

            if (Categoria.Items.Count == 0)
            {
                String query = @"SELECT CATEGORIA FROM CATEGORIA_CHAMADO;";
                var ListaCategoria = SQLConnect.CarregaCategorias(query);
                foreach (var item in ListaCategoria)
                {
                    Categoria.Items.Add(item.ToString());
                    
                }
            }
            if (GrupoDesignado.Items.Count == 0)
            {
                String query = @"SELECT GRUPO_SUP_NOME FROM GRUPO_SUPORTE;";
                var ListaCategoria = SQLConnect.CarregaGruposSuporte(query);
                foreach (var item in ListaCategoria)
                {
                    GrupoDesignado.Items.Add(item.ToString());
                }
            }            
            if (Cliente.Items.Count == 0)
            {
                String query = @"SELECT EMPRESA_CLIENTE FROM EMPRESA_CLIENTE;";
                var ListaCategoria = SQLConnect.CarregaCliente(query);
                foreach (var item in ListaCategoria)
                {
                    Cliente.Items.Add(item.ToString());
                }
            }
            /*{
                ChamadoModel mChamado = new ChamadoModel();
                mChamado.cliente = (Cliente.SelectedItem.ToString());
                String query = @"SELECT NOME_CLIENTE FROM CLIENTE CLI
                                JOIN EMPRESA_CLIENTE EC ON EC.ID_EMPRESA_CLIENTE = CLI.ID_EMPRESA_CLIENTE
                                WHERE EC.EMPRESA_CLIENTE ='"
                                + mChamado.cliente + "';";
                var ListaCategoria = SQLConnect.CarregaRequisitante(query);
                foreach (var item in ListaCategoria)
                {
                    Requisitante.Items.Add(item.ToString());
                }
            }*/

        }

        protected void SalvarChamado(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();

            mChamado.tipo_chamado = TipoSolicitacao.Value.ToString();
            mChamado.cliente = (Cliente.SelectedItem.ToString()); 
            //mChamado.requisitante = (Requisitante.SelectedItem.ToString());
            mChamado.categoria = (Categoria.SelectedItem.ToString());
            mChamado.resumo_chamado = Resumo.Value;
            mChamado.urgencia = Urgencia.Value;
            mChamado.grupo_designado = (GrupoDesignado.SelectedItem.ToString());


           ChamadoController ChamadoController = new ChamadoController();
           var NewNumChamado = ChamadoController.SalvarChamado(mChamado);

            //EditarChamado EditCham = new EditarChamado();
            //mChamado = EditCham.EditChamado(NewNumChamado);

           // EditarChamado editarChamado = new EditarChamado();
            //editarChamado.Page_Load(mChamado);
           HttpCookie cookie = new HttpCookie("nomeCookie");            
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = NewNumChamado;
            Response.Cookies.Add(cookie);
           
            Response.Redirect("~/UserInterface/EditarChamado", true);

            Response.Redirect("~", true);

        }
        protected void CarregaRequisitante(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();

                mChamado.cliente = (Cliente.SelectedItem.ToString());
                String query = @"SELECT NOME_CLIENTE FROM CLIENTE CLI
                                JOIN EMPRESA_CLIENTE EC ON EC.ID_EMPRESA_CLIENTE = CLI.ID_EMPRESA_CLIENTE
                                WHERE EC.EMPRESA_CLIENTE ="
                                + mChamado.cliente + "';";
                var ListaCategoria = SQLConnect.CarregaRequisitante(query);
                foreach (var item in ListaCategoria)
                {
                    Requisitante.Items.Add(item.ToString());
                }
            
        }
        protected void ExibeChamadosLoad(object sender, EventArgs e)
        {
            ChamadoModel pModel = new ChamadoModel();
            Response.Redirect("~/UserInterface/ExibirChamados", true);
        }


    }
}