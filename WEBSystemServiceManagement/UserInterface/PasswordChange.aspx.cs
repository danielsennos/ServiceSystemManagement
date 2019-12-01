using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AtualizarSenha(object sender, EventArgs e)
        {
            if (Password1.Value != Password2.Value) { Response.Write("<script>alert('Senhas digitadas não conferem. As senhas devem ser iguais.')</script>"); }
            if (Password1.Value.Length < 6 || Password2.Value.Length < 6) { Response.Write("<script>alert('As senhas devem possuir no mínimo 6 caracteres.')</script>"); }


        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }
    }
}