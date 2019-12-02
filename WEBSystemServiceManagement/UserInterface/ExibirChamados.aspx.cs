﻿using System;
using System.Web;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class ExibirChamados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (Session["user_authenticated"] != null)
                {
                    if (Session["user_authenticated"].ToString() == "true")
                    {

                        Session.Timeout = 20;

                        ChamadoController chamadoController = new ChamadoController();
                        ChamadoModel mChamado = new ChamadoModel();
                        String StatusChamado = "Aberto";


                        GridChamados.DataSource = chamadoController.ExibirChamados(StatusChamado);
                        GridChamados.DataBind();
                    }
                    else { Response.Redirect("~/UserInterface/SessionExpired", true); }
                }
                else
                {
                    Response.Redirect("~/UserInterface/SessionExpired", true);
                }


            }

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
            var numChamadoSelected = (HttpUtility.HtmlDecode(gr.Cells[1].Text)).Substring(4, 7);

            Session["edit"] = numChamadoSelected;

            Response.Redirect("~/UserInterface/EditarChamado", true);

        }

    }
}