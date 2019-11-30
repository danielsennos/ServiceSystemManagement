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
                if (Session["user_authenticated"] != null)
                {
                    if (Convert.ToInt32(Session["user_id_permisson"]) == 0 || Convert.ToInt32(Session["user_id_permisson"]) == 1 || Convert.ToInt32(Session["user_id_permisson"]) == 4)
                    {
                        AdminModel.GrupoUsuario pModel = new AdminModel.GrupoUsuario();
                        AdminController adminController = new AdminController();
                        Repository SQLConnect = new Repository();


                        if (Session["edit"] != null)
                        {
                            string nome = (Session["edit"]).ToString();
                            pModel = adminController.ExibirGrupoUsuario(nome);
                            Session["edit"] = null;
                        }
                        else
                        {

                            pModel = new AdminModel.GrupoUsuario();
                        }

                        idgrupo.Value = pModel.idGrupo;
                        NomeGrupoInput.Text = pModel.NomeGrupo;
                        Status.Value = pModel.StatusGrupo;

                        Session.Timeout = 20;

                    }
                    else { throw new Exception("Permissões insuficientes"); }
                }
                else { Response.Redirect("~/UserInterface/SessionExpired", true); }
                
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

             Session["edit"] = pModel.NomeGrupo;


            Response.Redirect("~/UserInterface/GrupoUsuarioAdmin", true);

        }
    }
}