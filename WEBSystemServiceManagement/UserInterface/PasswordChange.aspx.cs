using System;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["user_authenticated"] != null & Session["user_name"] != null)
                {

                    iduser.Value = Session["user_id"].ToString();
                    Session.Timeout = 20;

                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }
            }
        }

        protected void AtualizarSenha(object sender, EventArgs e)
        {


            if (Password1.Value.Length < 6)
            {
                Response.Write("<script>alert('A senha deve possuir no mínimo 6 caracteres.')</script>");
            }
            else if (Password1.Value != Password2.Value) { Response.Write("<script>alert('Senhas digitadas não conferem. As senhas devem ser iguais.')</script>"); }
            else
            {
                LoginController loginController = new LoginController();
                LoginModel pModel = new LoginModel();

                pModel.Password = Password1.Value;
                pModel.idUser = iduser.Value;
                loginController.AlterarSenha(pModel);

                Response.Write("<script>alert('Senha alterada')</script>");

            }

        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }
    }
}