using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class ClienteAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CarregaItens(object sender, EventArgs e)
        {
            Repository SQLConnect = new Repository();


            string EstadoNome = EstadosList.SelectedItem.Value.ToString();

            String queryEstado = @"SELECT NOME FROM ESTADO";
            var ListaEstado = SQLConnect.CarregaCidades(queryEstado);
            EstadosList.Items.Clear();
            foreach (var item in ListaEstado)
            {
                EstadosList.Items.Add(item.ToString());
            }
            EstadosList.SelectedItem.Text = EstadoNome;

            String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + EstadoNome + "') AS TEMP) ";
            var ListaCidade = SQLConnect.CarregaCidades(queryCidade);
            CidadeList.Items.Clear();
            foreach (var item in ListaCidade)
            {
                CidadeList.Items.Add(item.ToString());
            }
        }

        protected void Cancelar(object sender, EventArgs e)
        {

            Response.Redirect("~/UserInterface/AdminIndex", true);

        }
    }
}