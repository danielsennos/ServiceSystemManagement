using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class ExibirChamados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Aberto";

            
            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);
            GridChamados.DataBind();
           
        }
        protected void ExibeChamadosAbertos(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Aberto";

            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);            
            GridChamados.DataBind();
        }

        protected void ExibeChamadosPendentes(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Pendente";

            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);            
            GridChamados.DataBind();
        }

        protected void ExibeChamadosEmAndamento(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Em Andamento";

            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);
            GridChamados.DataBind();
        }
        protected void ExibeChamadosConcluidos(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Concluído";

            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);
            GridChamados.DataBind();
        }
        protected void ExibeChamadosCancelados(object sender, EventArgs e)
        {
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel mChamado = new ChamadoModel();
            String StatusChamado = "Cancelado";

            GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);
            GridChamados.DataBind();
        }
        public void EditSelectChamado(object sender, EventArgs e)
        {
            GridViewRow gr = GridChamados.SelectedRow;
            var numChamadoSelected = (gr.Cells[1].Text).Substring(4,7);            
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = numChamadoSelected;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/EditarChamado", true);

        }

    }
}