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

            String query = @"INSER INTO SSM_CHAMADOS (NUM_CHAMADO, ID_CLIENTE, ID_CATEGORIA, URGENCIA, DATA_CHAMADO  ) VALUES
                                    " + mChamado.num_chamado + "," + mChamado.id_cliente + "," + mChamado.id_categoria + "," + mChamado.urgencia
                                    +"SYSDATE";
            


            DBConnect db = new DBConnect();
            db.Inserir(query);

        }
    }
}