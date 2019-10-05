using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement
{
    public partial class CriarNovoChamado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Repository SQLConnect = new Repository();


            if (Categoria.Items.Count == 0)
            {
                String query = @"SELECT CATEGORIA FROM CATEGORIA_CHAMADO;";
                var ListaCategoria = SQLConnect.CarregaCategorias(query);
                foreach (var item in ListaCategoria)
                {
                    Categoria.Items.Add(item.ToString());
                }
            }
            if (GrupoDesignado.Items.Count == 0)
            {
                String query = @"SELECT GRUPO_NOME FROM GRUPO_SUPORTE;";
                var ListaCategoria = SQLConnect.CarregaGruposSuporte(query);
                foreach (var item in ListaCategoria)
                {
                    GrupoDesignado.Items.Add(item.ToString());
                }
            }
            if (Requisitante.Items.Count == 0)
            {
                String query = @"SELECT NOME_CLIENTE FROM CLIENTE;";
                var ListaCategoria = SQLConnect.CarregaRequisitante(query);
                foreach (var item in ListaCategoria)
                {
                    Requisitante.Items.Add(item.ToString());
                }
            }

        }

        protected void SalvarChamado(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();

            mChamado.num_chamado = num_chamado.Value;
            mChamado.cliente = Cliente.Value;
            mChamado.requisitante = (Requisitante.SelectedItem.ToString());
            mChamado.categoria = (Categoria.SelectedItem.ToString());
            mChamado.resumo_chamado = Resumo.Value;
            mChamado.urgencia = Urgencia.Value;
            mChamado.grupo_designado = (GrupoDesignado.SelectedItem.ToString());
            mChamado.anotacao = Anotacoes.Value;


            CriarNovoChamadoController ChamadoController = new CriarNovoChamadoController();
            ChamadoController.SalvarChamado(mChamado);



        }

        public void CarregaCategoria(object sender, EventArgs e)
        {/*
            
            Repository SQLConnect = new Repository();
            String query = @"SELECT CATEGORIA FROM CATEGORIA_CHAMADO;";
            Relatorios Rel = new Relatorios();
            
            var x = SQLConnect.Categorias(query);
            //Rel.ResultadoLista = SQLConnect.ResultList(query);

            

            foreach (var item in x)
            {
                categoriateste.Items.Add(item.ToString());
            }*/




        }


    }
}