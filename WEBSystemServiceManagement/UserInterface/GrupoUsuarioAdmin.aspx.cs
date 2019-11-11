using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class GrupoUsuarioAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                AdminModel.GrupoUsuario pModel = new AdminModel.GrupoUsuario();
                AdminController adminController = new AdminController();
                Repository SQLConnect = new Repository();


                if (Session.Count > 0)
                {
                    string nome = (Session["edit"]).ToString();
                    pModel = adminController.ExibirGrupoUsuario(nome);
                    Session.Clear();
                }
                else
                {

                    pModel = new AdminModel.GrupoUsuario();
                }

                idgrupo.Value = pModel.idGrupo;
                NomeGrupoInput.Text = pModel.NomeGrupo;
                Status.Value = pModel.StatusGrupo;
            }

        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }

        protected void AtualizaGrupo(object sender, EventArgs e)
        {
            AdminModel.GrupoUsuario pModel = new AdminModel.GrupoUsuario();
            AdminController adminController = new AdminController();

            pModel.idGrupo = idgrupo.Value;
            pModel.NomeGrupo = NomeGrupoInput.Text;
            pModel.StatusGrupo = Status.Value;

            if (pModel.idGrupo != "") { adminController.EditarGrupoUsuario(pModel); } else { adminController.IncluirGrupoUsuario(pModel); }

            Session.Clear();
            Session["edit"] = pModel.NomeGrupo;


            Response.Redirect("~/UserInterface/GrupoUsuarioAdmin", true);

        }
    }
}