using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WEBSystemServiceManagement
{
    public partial class EditarChamado : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();
            ChamadoController chamadoController = new ChamadoController();

            HttpCookie cookie;   
            cookie = Request.Cookies["nomeCookie"];
            if (cookie != null)
            {
                string numChamado = cookie.Value;
                mChamado = chamadoController.EditarChamado(numChamado);
            }
            else
            {                
                var numChamado = "1";
                mChamado = chamadoController.EditarChamado(numChamado);

                //Response.Redirect("~/UserInterface/ExibirChamados", true);
            } 
            if(mChamado.tipo_chamado == "REQ"){ TipoSolicitacaoEdit.Text = "Solicitação"; } else { TipoSolicitacaoEdit.Text = "Erro/Falha"; }
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

        }

        public void SatusAbertoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Aberto' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);
            AbertoChange.ForeColor = Color.Red;

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.id_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }
        public void SatusEmAndamentoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Em Andamento' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);
            

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.id_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }

    }
}