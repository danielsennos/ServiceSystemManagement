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
                throw new Exception("Dados incorretos.");
            } else
            {
                _ = Session.IsNewSession;
                Session["user_authenticated"] = "true";
                Session["user_name"] = pModel.NomeUsuario;
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
            
            if(LoginName.Value == "")
            {
                throw new Exception("Digite o Login para envio da senha");
            }

            pModel.LoginName = LoginName.Value;
            pModel.NomeUsuario = db.Consultar("SELECT NOME_USUARIO FROM USUARIOS WHERE LOGIN = '" + pModel.LoginName + "';");
            if (pModel.NomeUsuario == "" || pModel.NomeUsuario == null)
            {
                throw new Exception("Usuário inexistente.");
            }
            else
            {                
                loginController.EsqueciMinhaSenha(pModel);
            }
        }




    }
}