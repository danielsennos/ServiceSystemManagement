using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class CategoriaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                if (Session["user_authenticated"] != null)
                {
                    if (Convert.ToInt32(Session["user_id_permisson"]) == 0 || Convert.ToInt32(Session["user_id_permisson"]) == 1 || Convert.ToInt32(Session["user_id_permisson"]) == 4)
                    {
                        AdminModel.Categoria pModel = new AdminModel.Categoria();
                        AdminController adminController = new AdminController();
                        Repository SQLConnect = new Repository();



                        if (Session["edit"] != null)
                        {
                            string nome = (Session["edit"]).ToString();
                            pModel = adminController.ExibirCategoria(nome);
                            Session["edit"] = null;


                        }
                        else
                        {
                            pModel = new AdminModel.Categoria();
                        }


                        idcategoria.Value = pModel.idCategoria;
                        NomeCategoriaInput.Text = pModel.NomeCategoria;
                        SLAInput.Value = pModel.SLACategoria;
                        Status.Value = pModel.StatusCategoria;

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
        protected void AtualizaCategoria(object sender, EventArgs e)
        {
            AdminModel.Categoria pModel = new AdminModel.Categoria();
            AdminController adminController = new AdminController();

            pModel.idCategoria = idcategoria.Value;
            pModel.NomeCategoria = NomeCategoriaInput.Text;
            pModel.SLACategoria = SLAInput.Value;
            pModel.StatusCategoria = Status.Value;

            if (pModel.idCategoria != "") { adminController.EditarCategoria(pModel); } else { adminController.IncluirCategoria(pModel); }
            
           Session["edit"] = pModel.NomeCategoria;          


            Response.Redirect("~/UserInterface/CategoriaAdmin", true);

        }


    }
}