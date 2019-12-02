using System;
using System.Web;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Pesquisar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_authenticated"] != null)
            {
                Session.Timeout = 20;
            }
            else { Response.Redirect("~/UserInterface/SessionExpired", true); }

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

            Session["edit"] = numChamadoSelected;

            Response.Redirect("~/UserInterface/ExibirDetalhesChamado", true);
        }
    }
}