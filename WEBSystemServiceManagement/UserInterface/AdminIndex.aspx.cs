using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_authenticated"] != null)
            {
                if (Convert.ToInt32(Session["user_id_permisson"]) == 1 || Convert.ToInt32(Session["user_id_permisson"]) == 4)
                {
                    Session.Timeout = 20;

                } else { throw new Exception("Permissões insuficientes"); }
            } else { Response.Redirect("~/UserInterface/SessionExpired", true); }

        }
        public void ExibirEmpresa(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            #region Visibilidade_das_Grids
                        GridEmpresa.Visible = true;
                        GridCliente.Visible = false;
                        GridCategoria.Visible = false;
                        GridGrupoSuporte.Visible = false;
                        GridUsuarios.Visible = false;
            #endregion



            GridEmpresa.DataSource = adminController.ExibirEmpresa();
            GridEmpresa.DataBind();
        }
        public void ExibirCliente(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();

            #region Visibilidade_das_Grids
            GridEmpresa.Visible = false;
            GridCliente.Visible = true;
            GridCategoria.Visible = false;
            GridGrupoSuporte.Visible = false;
            GridUsuarios.Visible = false;
            #endregion

            GridCliente.Visible = true;
            GridCliente.DataSource = adminController.ExibirCliente();
            GridCliente.DataBind();

        }
        public void ExibirCategoria(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();

            #region Visibilidade_das_Grids
            GridEmpresa.Visible = false;
            GridCliente.Visible = false;
            GridCategoria.Visible = true;
            GridGrupoSuporte.Visible = false;
            GridUsuarios.Visible = false;
            #endregion

            GridCategoria.DataSource = adminController.ExibirCategoria();
            GridCategoria.DataBind();
        }
        public void ExibirGrupoUsuario(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();

            #region Visibilidade_das_Grids
            GridEmpresa.Visible = false;
            GridCliente.Visible = false;
            GridCategoria.Visible = false;
            GridGrupoSuporte.Visible = true;
            GridUsuarios.Visible = false;
            #endregion

            GridCliente.Visible = false;
            GridGrupoSuporte.DataSource = adminController.ExibirGrupoSuporte();
            GridGrupoSuporte.DataBind();

        }
        public void ExibirUsuarios(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();

            #region Visibilidade_das_Grids
            GridEmpresa.Visible = false;
            GridCliente.Visible = false;
            GridCategoria.Visible = false;
            GridGrupoSuporte.Visible = false;
            GridUsuarios.Visible = true;
            #endregion

            GridCliente.Visible = false;
            GridUsuarios.DataSource = adminController.ExibirUsuarios();
            GridUsuarios.DataBind();

        }

        public void EditarEmpresa(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            string nome = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            Session["edit"] = nome;

            Response.Redirect("~/UserInterface/EmpresaAdmin", true);
        }

        public void EditarCliente(object sender, EventArgs e)
        {
            GridViewRow gr = GridCliente.SelectedRow;
            string nome = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            Session["edit"] = nome;

            Response.Redirect("~/UserInterface/ClienteAdmin", true);
        }

        public void EditarCategoria(object sender, EventArgs e)
        {
            GridViewRow gr = GridCategoria.SelectedRow;
            string nome = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            Session["edit"] = nome;

            Response.Redirect("~/UserInterface/CategoriaAdmin", true);
        }

        public void EditarGrupoUsuario(object sender, EventArgs e)
        {
            GridViewRow gr = GridGrupoSuporte.SelectedRow;
            string nome = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            Session["edit"] = nome;

            Response.Redirect("~/UserInterface/GrupoUsuarioAdmin", true);
        }

        public void EditarUsuarios(object sender, EventArgs e)
        {
            GridViewRow gr = GridUsuarios.SelectedRow;
            string nome = HttpUtility.HtmlDecode(gr.Cells[1].Text);
            Session["edit"] = nome;

            Response.Redirect("~/UserInterface/UsuariosAdmin", true);
        }


    }
}