using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      

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
        public void ExibirGrupoSuporte(object sender, EventArgs e)
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
            GridGrupoSuporte.Visible = true;
            GridUsuarios.Visible = false;
            #endregion

            GridCliente.Visible = false;
            GridGrupoSuporte.DataSource = adminController.ExibirUsuarios();
            GridGrupoSuporte.DataBind();

        }

        public void EditarEmpresa(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            var nome = gr.Cells[1].Text;
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = nome;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/EmpresaAdmin", true);
        }

        public void EditarCliente(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            var nome = gr.Cells[1].Text;
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = nome;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/ClienteAdmin", true);
        }

        public void EditarCategoria(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            var nome = gr.Cells[1].Text;
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = nome;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/CategoriaAdmin", true);
        }

        public void EditarGrupoSuporte(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            var nome = gr.Cells[1].Text;
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = nome;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/SuporteAdmin", true);
        }

        public void EditarUsuarios(object sender, EventArgs e)
        {
            GridViewRow gr = GridEmpresa.SelectedRow;
            var nome = gr.Cells[1].Text;
            HttpCookie cookie = new HttpCookie("nomeCookie");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie.Value = nome;
            Response.Cookies.Add(cookie);

            Response.Redirect("~/UserInterface/UsuarioAdmin", true);
        }

    }
}