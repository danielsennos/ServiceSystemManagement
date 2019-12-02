using System;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class ClienteAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                if (Session["user_authenticated"] != null)
                {
                    if (Convert.ToInt32(Session["user_id_permisson"]) == 0 || Convert.ToInt32(Session["user_id_permisson"]) == 3)
                    {
                        AdminModel.Cliente pModel = new AdminModel.Cliente();
                        AdminController adminController = new AdminController();
                        Repository SQLConnect = new Repository();

                        if (Session["edit"] != null)
                        {
                            string nome = (Session["edit"]).ToString();
                            pModel = adminController.ExibirCliente(nome);
                            Session["edit"] = null;


                            if (EstadosList.Items.Count == 0 || CidadeList.Items.Count == 0 || EmpresaList.Items.Count == 0)
                            {
                                String queryEstado = @"SELECT NOME FROM ESTADO";
                                var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
                                foreach (var item in ListaEstado)
                                {
                                    EstadosList.Items.Add(item.ToString());
                                }
                                String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + pModel.EstadoCliente + "') AS TEMP) ";
                                var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
                                foreach (var item in ListaCidade)
                                {
                                    CidadeList.Items.Add(item.ToString());
                                }
                                String query = @"SELECT EMPRESA_NOME FROM EMPRESAS;";
                                var ListaCliente = SQLConnect.CarregaEmpresa(query);
                                foreach (var item in ListaCliente)
                                {
                                    EmpresaList.Items.Add(item.ToString());
                                }

                            }
                        }
                        else
                        {
                            pModel = new AdminModel.Cliente();

                            if (EstadosList.Items.Count == 0 || CidadeList.Items.Count == 0 || EmpresaList.Items.Count == 0)
                            {
                                String queryEstado = @"SELECT NOME FROM ESTADO";
                                var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
                                foreach (var item in ListaEstado)
                                {
                                    EstadosList.Items.Add(item.ToString());
                                }
                                String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + EstadosList.SelectedValue + "') AS TEMP) ";
                                var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
                                foreach (var item in ListaCidade)
                                {
                                    CidadeList.Items.Add(item.ToString());
                                }
                                String query = @"SELECT EMPRESA_NOME FROM EMPRESAS;";
                                var ListaCliente = SQLConnect.CarregaEmpresa(query);
                                foreach (var item in ListaCliente)
                                {
                                    EmpresaList.Items.Add(item.ToString());
                                }

                            }
                        }


                        idcliente.Value = pModel.IdCliente;
                        NomeClienteInput.Text = pModel.NomeCliente;
                        TelefoneInput.Text = pModel.TelefoneCliente;
                        EmailInput.Text = pModel.EmailCliente;
                        EmpresaList.Text = pModel.EmpresaCliente;
                        EstadosList.Text = pModel.EstadoCliente;
                        CidadeList.Text = pModel.CidadeCliente;
                        Status.Value = pModel.StatusCliente;

                        Session.Timeout = 20;
                    }
                    else { Response.Write("<script>alert('Permissões insificientes...')</script>"); }


                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }

            }

        }

        protected void CarregaItens(object sender, EventArgs e)
        {
            Repository SQLConnect = new Repository();


            string EstadoNome = EstadosList.SelectedItem.Value.ToString();

            String queryEstado = @"SELECT NOME FROM ESTADO";
            var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
            EstadosList.Items.Clear();
            foreach (var item in ListaEstado)
            {
                EstadosList.Items.Add(item.ToString());
            }
            EstadosList.SelectedItem.Text = EstadoNome;

            String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + EstadoNome + "') AS TEMP) ";
            var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
            CidadeList.Items.Clear();
            foreach (var item in ListaCidade)
            {
                CidadeList.Items.Add(item.ToString());
            }
        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }

        protected void AtualizaCliente(object sender, EventArgs e)
        {
            AdminModel.Cliente pModel = new AdminModel.Cliente();
            AdminController adminController = new AdminController();

            pModel.IdCliente = idcliente.Value;
            pModel.NomeCliente = NomeClienteInput.Text;
            pModel.TelefoneCliente = TelefoneInput.Text;
            pModel.EmailCliente = EmailInput.Text;
            pModel.EmpresaCliente = EmpresaList.Text;
            pModel.EstadoCliente = EstadosList.Text;
            pModel.CidadeCliente = CidadeList.Text;
            pModel.StatusCliente = Status.Value;
            if (pModel.IdCliente != "")
            {
                adminController.EditarCliente(pModel); Response.Write("<script>alert('Dados Atualizados')</script>");
            }
            else { adminController.IncluirCliente(pModel); Response.Write("<script>alert('Dados Cadastrados')</script>"); }


            Session["edit"] = pModel.NomeCliente;


            Response.Redirect("~/UserInterface/ClienteAdmin", true);

        }
    }
}