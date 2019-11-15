using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class EmpresaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
         {
            AdminModel.Empresa pModel = new AdminModel.Empresa();
            AdminController adminController = new AdminController();
            Repository SQLConnect = new Repository();


            if (Session.Count > 0)
            {
                string nome = (Session["edit"]).ToString();
                pModel = adminController.ExibirEmpresa(nome);
                Session.Clear();
                    if (EstadosList.Items.Count == 0 || CidadeList.Items.Count == 0)
                    {

                        String queryEstado = @"SELECT NOME FROM ESTADO";
                        var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
                        foreach (var item in ListaEstado)
                        {
                            EstadosList.Items.Add(item.ToString());
                        }

                        String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + pModel.EstadoEmpresa + "') AS TEMP) ";
                        var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
                        foreach (var item in ListaCidade)
                        {
                            CidadeList.Items.Add(item.ToString());
                        }
                    }
                }
            else
            {
                    pModel = new AdminModel.Empresa();
                    if (EstadosList.Items.Count == 0 || CidadeList.Items.Count == 0)
                    {

                        String queryEstado = @"SELECT NOME FROM ESTADO";
                        var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
                        foreach (var item in ListaEstado)
                        {
                            EstadosList.Items.Add(item.ToString());
                        }

                        String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + EstadosList.SelectedValue + "') AS TEMP) ";
                        var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
                        foreach (var item in ListaCidade)
                        {
                            CidadeList.Items.Add(item.ToString());
                        }
                    }
                }

            
              

                idempresa.Value = pModel.IdEmpresa;
                NomeEmpresaInput.Text = pModel.NomeEmpresa;
                CNPJEmpresaInput.Text = pModel.CNPJEmpresa;
                EnderecoInput.Text = pModel.EnderecoEmpresa;                
                EstadosList.Text = pModel.EstadoEmpresa;                
                Status.Value = pModel.StatusEmpresa;
                CidadeList.Text = pModel.CidadeEmpresa;
            }
            
        }
        protected void CarregaItens(object sender, EventArgs e)
        {
            Repository SQLConnect = new Repository();


            string EstadoNome = EstadosList.SelectedItem.Value.ToString();

            String queryEstado = @"SELECT NOME FROM ESTADO";
            var ListaEstado = SQLConnect.CarregaCidadeEstados(queryEstado);
            EstadosList.Items.Clear();
            foreach (var item in ListaEstado)
            {
                EstadosList.Items.Add(item.ToString());
            }
            EstadosList.SelectedItem.Text = EstadoNome;

            String queryCidade = @"SELECT NOME FROM CIDADE WHERE ESTADO = 
                                    (SELECT ID FROM(SELECT ID AS ID FROM ESTADO WHERE NOME = '" + EstadoNome + "') AS TEMP) ";
            var ListaCidade = SQLConnect.CarregaCidadeEstados(queryCidade);
            CidadeList.Items.Clear();
            foreach (var item in ListaCidade)
            {
                CidadeList.Items.Add(item.ToString());
            }
        }

        protected void AtualizaEmrpesa(object sender, EventArgs e)
        {
            AdminModel.Empresa pModel = new AdminModel.Empresa();
            AdminController adminController = new AdminController();

            pModel.IdEmpresa = idempresa.Value;
            pModel.NomeEmpresa = NomeEmpresaInput.Text;
            pModel.CNPJEmpresa = CNPJEmpresaInput.Text;
            pModel.EnderecoEmpresa = EnderecoInput.Text;
            pModel.EstadoEmpresa = EstadosList.SelectedValue.ToString();
            pModel.CidadeEmpresa = CidadeList.SelectedValue.ToString();
            pModel.StatusEmpresa = Status.Value;

            if(pModel.IdEmpresa != "") {adminController.EditarEmpresa(pModel); } else { adminController.IncluirEmpresa(pModel); }


            Session.Clear();
            Session["edit"] =  pModel.NomeEmpresa;

            Response.Redirect("~/UserInterface/EmpresaAdmin", true);

        }

        protected void Cancelar(object sender, EventArgs e)
        {
           
            Response.Redirect("~/UserInterface/AdminIndex", true);

        }
    }
}