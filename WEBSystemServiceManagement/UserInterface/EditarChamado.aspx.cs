using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement
{
    public partial class EditarChamado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string x = "teste";
            testeinput.Value = x;
        }
        public void EditChamado(String numChamado)
        {
            if (String.IsNullOrWhiteSpace(numChamado)) numChamado = "";
            ChamadoController chamadoController = new ChamadoController();
            ChamadoModel pModel = new ChamadoModel();

            List<ChamadoModel> ListaChamado = chamadoController.EditarChamado(numChamado);




        }
    }
}