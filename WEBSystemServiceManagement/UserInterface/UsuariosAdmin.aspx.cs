using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class UsuariosAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                if (Session["user_authenticated"] != null)
                {
                    if (Convert.ToInt32(Session["user_id_permisson"]) == 0 || Convert.ToInt32(Session["user_id_permisson"]) == 3)
                    {
                        AdminModel.Usuario pModel = new AdminModel.Usuario();
                        AdminController adminController = new AdminController();
                        Repository SQLConnect = new Repository();


                        if (Session["edit"] != null)
                        {
                            string nome = (Session["edit"]).ToString();
                            pModel = adminController.ExibirUsuario(nome);
                            Session["edit"] = null;
                        }
                        else
                        {

                            pModel = new AdminModel.Usuario();
                        }
                        #region CarregaItens
                        String queryEmpresa = @"SELECT EMPRESA_NOME FROM EMPRESAS";
                        var ListaEmpresa = SQLConnect.CarregaEmpresa(queryEmpresa);
                        foreach (var item in ListaEmpresa)
                        {
                            EmpresaList.Items.Add(item.ToString());
                        }
                        String queryGrupoUsuario = @"SELECT GRUPO_NOME FROM GRUPO_USUARIO";
                        var ListaGrupo = SQLConnect.CarregaGrupoUsuario(queryGrupoUsuario);
                        foreach (var item in ListaGrupo)
                        {
                            GrupoList.Items.Add(item.ToString());
                        }
                        String queryPermissao = @"SELECT NOME_PERMISSAO FROM PERMISSOES_USUARIOS";
                        var ListaPermissao = SQLConnect.CarregaPermissoes(queryPermissao);
                        foreach (var item in ListaPermissao)
                        {
                            PermissaoList.Items.Add(item.ToString());
                        }
                        #endregion

                        idusuario.Value = pModel.idUsuario;
                        NomeUsuarioInput.Text = pModel.NomeUsuario;
                        LoginUsuarioInput.Text = pModel.Login;
                        EmailUusarioInput.Text = pModel.EmailUsuario;
                        EmpresaList.Text = pModel.Empresa;
                        GrupoList.Text = pModel.Grupo;
                        PermissaoList.Text = pModel.Permissao;
                        Status.Value = pModel.StatusUsuario;

                        Session.Timeout = 20;

                    }
                    else { Response.Write("<script>alert('Permissões insificientes...')</script>"); }
                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }
                
            }

        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }

        protected void AtualizaUsuario(object sender, EventArgs e)
        {
            AdminModel.Usuario pModel = new AdminModel.Usuario();
            AdminController adminController = new AdminController();

            pModel.idUsuario = idusuario.Value;
            pModel.Login = LoginUsuarioInput.Text;
            pModel.NomeUsuario = NomeUsuarioInput.Text;
            pModel.EmailUsuario = EmailUusarioInput.Text;
            pModel.Empresa = EmpresaList.SelectedValue;
            pModel.Grupo = GrupoList.SelectedValue;
            pModel.Permissao = PermissaoList.SelectedValue;
            pModel.StatusUsuario = Status.Value;
            if (pModel.idUsuario != "") { adminController.EditarUsuario(pModel); Response.Write("<script>alert('Dados Atualizados')</script>");
            } else { adminController.IncluirUsuario(pModel); Response.Write("<script>alert('Sados Cadastrados')</script>"); }

            

        }
    }
}