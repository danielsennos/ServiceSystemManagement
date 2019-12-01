using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement
{
    public partial class Login : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Acessar(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();
            LoginModel pModel = new LoginModel();
            pModel.LoginName = LoginName.Value;
            pModel.Password = LoginPassword.Value;
            bool AcessGranted = loginController.GrantAccess(pModel);
            if(AcessGranted == false)
            {
                Session["user_authenticated"] = "false";
                Response.Write("<script>alert('Dados incorretos')</script>");
            } else
            {
                _ = Session.IsNewSession;
                Session["user_authenticated"] = "true";
                Session["user_name"] = loginController.ConsultarNomeUser(pModel);
                Session["user_id"] = loginController.ConsultarIdUser(pModel);
                Session["user_login"] = pModel.LoginName;
                Session["user_id_permisson"] = loginController.ConsultarPermissao(pModel);

                Response.Redirect("~/UserInterface/ExibirChamados", true);
            }

        }
        public void EsqueciMinhaSenha(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();
            LoginModel pModel = new LoginModel();
            Repository db = new Repository();

            if (LoginName.Value == "")
            {                
                Response.Write("<script>alert('Digite o Login para envio da senha')</script>");
                            
            }
            else
            {

                pModel.LoginName = LoginName.Value;
                pModel.NomeUsuario = db.Consultar("SELECT NOME_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';");
                if (pModel.NomeUsuario == "" || pModel.NomeUsuario == null)
                {
                    Response.Write("<script>alert('Usuário inexistente')</script>");
                }
                else
                {
                    pModel.EmailUsuario = db.Consultar("SELECT EMAIL_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "'");
                    pModel.Password = db.Consultar("SELECT SENHA FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "'");

                    if (pModel.EmailUsuario == "" || pModel.EmailUsuario == null)
                    {
                        Response.Write("<script>alert('E-mail não cadastrado, procure o adminstrador do sistema')</script>");
                    }
                    else { loginController.EsqueciMinhaSenha(pModel); }
                    
                }
            }
        }




    }
}