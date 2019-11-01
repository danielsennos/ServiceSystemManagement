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
            GridEmpresa.DataSource = adminController.ExibirEmpresa();
            GridEmpresa.DataBind();
        }
        public void ExibirCliente(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            GridCliente.DataSource = adminController.ExibirCliente();
            GridCliente.DataBind();

        }
        public void ExibirCategoria(object sender, EventArgs e)
        {
            AdminController adminController = new AdminController();
            GridCliente.DataSource = adminController.ExibirCategoria();
            GridCliente.DataBind();

        }
    }
}