using System;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["user_authenticated"] != null)
                {
                    Session.Timeout = 20;
                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }
            }
        }

        public void Chamado_por_Empresa(object sender, EventArgs e)
        {
            Repository db = new Repository();
            string ConsultaRelatorio = @"SELECT EM.EMPRESA_NOME AS 'Empresa', COUNT(*) as 'Quantidade' FROM CHAMADOS CS
                                            JOIN EMPRESAS EM ON EM.ID_EMPRESA = CS.ID_EMPRESA
                                            WHERE DATA_ABERTURA LIKE '___" + MesAno.Value + "%'" +
                                            "GROUP BY CS.ID_CLIENTE, CS.STATUS_CHAMADO";
            GridRelatorio.DataSource = db.ExibeRelatorios(ConsultaRelatorio);
            GridRelatorio.DataBind();

        }

        public void Tempo_Médio_de_Atendimento(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Em implantação...')</script>");

        }
        public void Chamados_Abertos_no_Mês(object sender, EventArgs e)
        {
            Repository db = new Repository();
            string ConsultaRelatorio = @"SELECT CONCAT(CS.TIPO_CHAMADO, CS.NUM_CHAMADO) as 'Número do Chamado', CS.STATUS_CHAMADO as 'Status',
                                        CC.CATEGORIA as 'Categoria', EMCLI.EMPRESA_NOME as 'Cliente', CS.URGENCIA as 'Urgência',
                                        CS.DATA_ABERTURA as 'Data Abertura', CS.DATA_ALVO_RESOLUCAO as 'Data Alvo para Resolução'
                                        FROM CHAMADOS CS
                                        LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
                                        LEFT JOIN EMPRESAS EMCLI ON EMCLI.ID_EMPRESA = CS.ID_EMPRESA
                                        LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA
                                        WHERE DATA_ABERTURA LIKE '___" + MesAno.Value + "%'" +
                                        "ORDER BY CS.ID_CHAMADO";
            GridRelatorio.DataSource = db.ExibeRelatorios(ConsultaRelatorio);
            GridRelatorio.DataBind();

        }
        public void Categorias_mais_solicitadas(object sender, EventArgs e)
        {
            Repository db = new Repository();
            string ConsultaRelatorio = @"SELECT CC.CATEGORIA AS 'Categoria', COUNT(*) AS 'Quantidade' FROM CHAMADOS CS
                                        JOIN CATEGORIA_CHAMADO CC ON CC.ID_CATEGORIA = CS.ID_CATEGORIA
                                        WHERE DATA_ABERTURA LIKE '___" + MesAno.Value + "%' " +
                                        "GROUP BY CS.ID_CATEGORIA " +
                                        "ORDER BY Quantidade DESC";

            GridRelatorio.DataSource = db.ExibeRelatorios(ConsultaRelatorio);
            GridRelatorio.DataBind();

        }
    }
}