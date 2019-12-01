using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class ExibirDetalhesChamado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();
            ChamadoController chamadoController = new ChamadoController();


            if (Session["edit"] != null)
            {
                string numChamado = (Session["edit"]).ToString();
                mChamado = chamadoController.EditarChamado(numChamado);
                Session["edit"] = null;
            }
            else
            {
                throw new Exception("O servidor demorou a reponder. Verifique sua conexão e tente novamente.");

                
            }

            if (mChamado.tipo_chamado == "REQ") { TipoSolicitacaoEdit.Text = "Solicitação"; } else { TipoSolicitacaoEdit.Text = "Erro/Falha"; }
            NumChamadoEdit.Text = mChamado.tipo_chamado + mChamado.num_chamado.PadLeft((8 - mChamado.num_chamado.Count()), '0');
            ClienteEdit.Text = mChamado.cliente;
            RequisitanteEdit.Text = mChamado.requisitante;
            CategoriaEdit.Text = mChamado.categoria;
            UrgenciaEdit.Text = mChamado.urgencia;
            GrupoDesignadoEdit.Text = mChamado.grupo_designado;
            DesignadoEdit.Text = mChamado.designado;
            ResumoEdit.InnerText = mChamado.resumo_chamado;
            StatusEdit.Text = mChamado.status_chamado;
            ID_Chamado.Text = (mChamado.id_chamado).ToString();
            NumChamado.Text = mChamado.num_chamado;

            GridAnotacoes.DataSource = chamadoController.RetornaAnotacoes(mChamado.id_chamado);
            GridAnotacoes.DataBind();
        }
    }
}