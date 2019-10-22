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
    }
}