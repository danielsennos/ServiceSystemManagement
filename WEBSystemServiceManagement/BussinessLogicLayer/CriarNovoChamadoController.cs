using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class CriarNovoChamadoController
    {
        public void SalvarChamado(ChamadoModel mChamado)
        {
            String InsertChamado = @"INSER INTO SSM_CHAMADOS (NUM_CHAMADO, ID_CLIENTE ) VALUES
                                    " +mChamado.num_chamado+ "," +mChamado.id_cliente;
            //RUAN JSLWJDOLJDOWJWOWJOOWJOW


            DBConnect db = new DBConnect();
            db.Inserir(InsertChamado);

        }
    }
}