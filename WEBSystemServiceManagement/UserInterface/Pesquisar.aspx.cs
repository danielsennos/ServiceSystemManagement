﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Pesquisar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PesquisarAction(object sender, EventArgs e)
        {
            PesquisarController pesquisarController = new PesquisarController();

            string PalavraChave = PesquisarInput.Value;
            GridPesquisa.DataSource = pesquisarController.ProcurarPalavraChave(PalavraChave);
            GridPesquisa.DataBind();
        }

        protected void ExibirDetalhes(object sender, EventArgs e)
        {
            GridViewRow gr = GridPesquisa.SelectedRow;
            string numChamadoSelected = (HttpUtility.HtmlDecode(gr.Cells[1].Text)).Substring(4, 7);
            Session.Clear();
            Session["edit"] = numChamadoSelected;

            Response.Redirect("~/UserInterface/ExibirDetalhesChamado", true);
        }
    }
}