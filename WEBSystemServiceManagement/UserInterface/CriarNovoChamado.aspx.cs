﻿using System;
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

        }

        protected void SalvarChamado(object sender, EventArgs e)
        {
            ChamadoModel mChamado = new ChamadoModel();

            mChamado.num_chamado = num_chamado.Value;
            mChamado.cliente = Cliente.Value;
            mChamado.requisitante = Requisitante.Value;
            mChamado.categoria = Categoria.Value;
            mChamado.resumo_chamado = Resumo.Value;
            mChamado.urgencia = Urgencia.Value;
            mChamado.grupo_designado = GrupoDesignado.Value;
            mChamado.anotacao = Anotacoes.Value;

            
        }
    }
}