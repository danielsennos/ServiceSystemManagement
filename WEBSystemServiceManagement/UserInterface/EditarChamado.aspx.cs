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
            string numChamado = null;

            if (cookie != null)
               {
                numChamado = cookie.Value;
                mChamado = chamadoController.EditarChamado(numChamado);
            }
            else
            {
                numChamado = NumChamado.Text;
                numChamado = "1";
                mChamado = chamadoController.EditarChamado(numChamado);
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

            #region Controle Fluxo de Status
            if (StatusEdit.Text == "Aberto")
            {
                AbertoChange.ForeColor = Color.Red;
                AbertoChange.Visible = true;
                AbertoChange.Enabled = false;
                AbertoChange.Text = "Aberto";
                AndamentoChange.ForeColor = Color.Blue;
                AndamentoChange.Visible = true;
                AndamentoChange.Enabled = true;
                PendenteChange.ForeColor = Color.Blue;
                PendenteChange.Visible = true;
                PendenteChange.Enabled = true;
                ConcluidoChange.ForeColor = Color.Blue;
                ConcluidoChange.Visible = false;
                ConcluidoChange.Enabled = false;
                CanceladoChange.ForeColor = Color.Blue;
                CanceladoChange.Visible = true;
                CanceladoChange.Enabled = true;
            }
            else if (StatusEdit.Text == "Em Andamento")
            {
                AbertoChange.ForeColor = Color.Blue;
                AbertoChange.Visible = false;
                AbertoChange.Enabled = false;
                AbertoChange.Text = "Aberto";
                AndamentoChange.ForeColor = Color.Red;
                AndamentoChange.Visible = true;
                AndamentoChange.Enabled = true;
                PendenteChange.ForeColor = Color.Blue;
                PendenteChange.Visible = true;
                PendenteChange.Enabled = true;
                ConcluidoChange.ForeColor = Color.Blue;
                ConcluidoChange.Visible = true;
                ConcluidoChange.Enabled = true;
                CanceladoChange.ForeColor = Color.Blue;
                CanceladoChange.Visible = true;
                CanceladoChange.Enabled = true;
            }
            else if (StatusEdit.Text == "Pendente")
            {
                AbertoChange.ForeColor = Color.Blue;
                AbertoChange.Visible = false;
                AbertoChange.Enabled = false;
                AbertoChange.Text = "Aberto";
                AndamentoChange.ForeColor = Color.Blue;
                AndamentoChange.Visible = true;
                AndamentoChange.Enabled = true;
                PendenteChange.ForeColor = Color.Red;
                PendenteChange.Visible = true;
                PendenteChange.Enabled = false;
                ConcluidoChange.ForeColor = Color.Blue;
                ConcluidoChange.Visible = false;
                ConcluidoChange.Enabled = false;
                CanceladoChange.ForeColor = Color.Blue;
                CanceladoChange.Visible = true;
                CanceladoChange.Enabled = true;
            }
            else if (StatusEdit.Text == "Concluído")
            {
                AbertoChange.ForeColor = Color.Blue;
                AbertoChange.Visible = true;
                AbertoChange.Enabled = true;
                AbertoChange.Text = "Reabrir";
                AndamentoChange.ForeColor = Color.Blue;
                AndamentoChange.Visible = false;
                AndamentoChange.Enabled = false;
                PendenteChange.ForeColor = Color.Blue;
                PendenteChange.Visible = false;
                PendenteChange.Enabled = false;
                ConcluidoChange.ForeColor = Color.Red;
                ConcluidoChange.Visible = true;
                ConcluidoChange.Enabled = false;
                CanceladoChange.ForeColor = Color.Blue;
                CanceladoChange.Visible = false;
                CanceladoChange.Enabled = false;
            }
            else if (StatusEdit.Text == "Cancelado")
            {
                AbertoChange.ForeColor = Color.Blue;
                AbertoChange.Visible = false;
                AbertoChange.Enabled = false;
                AbertoChange.Text = "Aberto";
                AndamentoChange.ForeColor = Color.Blue;
                AndamentoChange.Visible = false;
                AndamentoChange.Enabled = false;
                PendenteChange.ForeColor = Color.Blue;
                PendenteChange.Visible = false;
                PendenteChange.Enabled = false;
                ConcluidoChange.ForeColor = Color.Blue;
                ConcluidoChange.Visible = false;
                ConcluidoChange.Enabled = false;
                CanceladoChange.ForeColor = Color.Red;
                CanceladoChange.Visible = true;
                CanceladoChange.Enabled = false;
                CanceladoChange.Text = "Cancelado";
            }
            #endregion

            
        }

        public void StatusAbertoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            mChamado.num_chamado = NumChamado.Text;
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Aberto' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);

            String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'Aberto','" + DateTime.Now + "');";
            db.Inserir(queryNota);

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.num_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }

        public void StatusEmAndamentoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            mChamado.num_chamado = NumChamado.Text;
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Em Andamento' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);

            String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'Em Andamento','" + DateTime.Now + "');";
            db.Inserir(queryNota);

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.num_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }
        public void StatusPendenteChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            mChamado.num_chamado = NumChamado.Text;
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Pendente' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);

            String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'Pendente','" + DateTime.Now + "');";
            db.Inserir(queryNota);

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.num_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }
        public void StatusConcluidoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            mChamado.num_chamado = NumChamado.Text;
            String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Concluído' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
            db.AtualizaStatus(query);

            String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'Concluído - " + AnotacaoEdit.InnerText  +"','" + DateTime.Now + "');";
            db.Inserir(queryNota);

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.num_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }
        public void StatusCanceladoChange(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();

            //if (AnotacaoEdit.InnerText == "" || AnotacaoEdit.InnerText.Count() < 10)
            //{
                
            //    HttpCookie cookie = new HttpCookie("nomeCookie");
            //    cookie.Expires = DateTime.Now.AddMinutes(1);
            //    cookie.Value = NumChamado.Text;
            //    Response.Cookies.Add(cookie);
            //    Page_Load(sender, e);
            //}
            //else
            //{
                mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
                mChamado.num_chamado = NumChamado.Text;
                String query = "UPDATE CHAMADOS SET STATUS_CHAMADO = 'Cancelado' WHERE ID_CHAMADO =" + mChamado.id_chamado + ";";
                db.AtualizaStatus(query);

                String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'Solicitação Cancelada - Motivo:" + AnotacaoEdit.InnerText + ",'" + DateTime.Now + "');";
                db.Inserir(queryNota);

                HttpCookie cookie = new HttpCookie("nomeCookie");
                cookie.Expires = DateTime.Now.AddMinutes(1);
                cookie.Value = (mChamado.num_chamado).ToString();
                Response.Cookies.Add(cookie);
                Page_Load(sender, e);
            //}
        }
        public void InsereAnotacao(object sender, EventArgs e)
        {
            Repository db = new Repository();
            ChamadoModel mChamado = new ChamadoModel();
            mChamado.anotacao = AnotacaoEdit.InnerText;
            mChamado.id_chamado = Convert.ToInt32(ID_Chamado.Text);
            mChamado.num_chamado = NumChamado.Text;
            String query = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES(" + mChamado.id_chamado + ",'"
                + mChamado.anotacao + "','" + DateTime.Now + "');";
            db.Inserir(query);

            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = (mChamado.num_chamado).ToString();
            Response.Cookies.Add(cookie);
            Page_Load(sender, e);
        }
    }
}