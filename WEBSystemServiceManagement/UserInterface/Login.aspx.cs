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

        public void SenhaRecover(object sender, EventArgs e)
        {

        }

        public void Acessar(object sender, EventArgs e)
        {
            LoginModel pModel = new LoginModel();
            LoginController LoginControl = new LoginController();
            bool access;

            pModel.LoginName = LoginUser.Value;
            pModel.password = SenhaLogin.Value;

            if (pModel.LoginName == "")
            {
                throw new Exception("Favor digitar o usuário.");
            } else if (pModel.password == "")
            {
                throw new Exception("Favor digitar a senha.");
            }
            else
            {
              access = LoginControl.GrantAccess(pModel);
            }

            if(access == true)
            {
                Response.Redirect("~/UserInterface/ExibirChamados", true);
            }
            else
            {
                throw new Exception("Senha inválida");
            }
        }



        
        
             //String InsertSql = "INSERT INTO CHAMADOS VALUES('" + chamados.Num_Chamado + "','" + chamados.Cliente + "','" + chamados.Categoria + "','" + chamados.Solicitante + "')";
            //SQLConnect.Inserir();


        
    }
}