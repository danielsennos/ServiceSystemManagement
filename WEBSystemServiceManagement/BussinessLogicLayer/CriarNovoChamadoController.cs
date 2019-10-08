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

            Repository db = new Repository();



            //String selectMaxNumChamado = "SELECT MAX(NUM_CHAMADO) FROM CHAMADOS;";
            //Int16 MaxNumChamado = Convert.ToInt16(db.Consultar(selectMaxNumChamado));
            //string NextNumChamado = (MaxNumChamado + 1).ToString("D8");
            String selectDataAlvo = @"SELECT LIMITE_EXECUCAO FROM ALVO_SLA AL
                                    JOIN CATEGORIA_CHAMADO CC ON CC.ID_CATEGORIA = AL.ID_CATEGORIA
                                    JOIN EMPRESA_CLIENTE EC ON EC.ID_EMPRESA_CLIENTE = AL.ID_EMPRESA_CLIENTE
                                    WHERE EC.EMPRESA_CLIENTE =" + mChamado.cliente
                                    + "' AND CC.CATEGORIA ='"
                                    + mChamado.categoria +"';";
            Int16 AlvoSLA = Convert.ToInt16(db.Consultar(selectDataAlvo));




            String query = @"INSERT INTO SSM_CHAMADOS (TIPO_CHAMADO,
                                                      NUM_CHAMADO, 
                                                      ID_CLIENTE,  
                                                      ID_CATEGORIA, 
                                                      URGENCIA,         
                                                      DATA_CHAMADO,
                                                       DATA_ALVO_SLA) VALUES ('"
                                      + mChamado.tipo_chamado + "',"
                                      + "(SELECT NUM FROM(SELECT MAX(NUM_CHAMADO) +1 AS NUM FROM chamados) AS TEMP))" + ","
                                      + "(SELECT ID_CLIENTE FROM WHERE NOME_CLIENTE =" + mChamado.cliente + "),'"
                                      + "(SELECT ID_CTAGEORIA FROM FROM CATEGORIA_CHAMADO WHERE CATEGORIA ='" + mChamado.categoria + "'),'"
                                      + mChamado.urgencia + "',"
                                      + "SYSDATE()"
                                      + DateTime.Now.AddHours(AlvoSLA);          

            //db.Inserir(query);

        }


    }
}