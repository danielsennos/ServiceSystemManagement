using System;
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
                        Repository db = new Repository();
                        ChamadoController chamadoController = new ChamadoController();
                        ChamadoModel mChamado = new ChamadoModel();
                        String SQL = @"SELECT CONCAT(CS.TIPO_CHAMADO, CS.NUM_CHAMADO) as 'Número do Chamado', CS.STATUS_CHAMADO as 'Status',
                            CC.CATEGORIA as 'Categoria', EMCLI.EMPRESA_NOME as 'Cliente', CS.URGENCIA as 'Urgência',
                            CS.DATA_ABERTURA as 'Data Abertura', CS.DATA_ALVO_RESOLUCAO as 'Data Alvo para Resolução'
                            FROM CHAMADOS CS
                            LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
                            LEFT JOIN EMPRESAS EMCLI ON EMCLI.ID_EMPRESA = CS.ID_EMPRESA
                            LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA
                            WHERE CS.STATUS_CHAMADO = 'Aberto' OR CS.STATUS_CHAMADO = 'Em Andamento' OR CS.STATUS_CHAMADO='Pendente';";


                        GridChamados.DataSource = db.ExibeChamados(SQL);
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