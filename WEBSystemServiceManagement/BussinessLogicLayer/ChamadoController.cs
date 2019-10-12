using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class ChamadoController
    {
        public void SalvarChamado(ChamadoModel mChamado)
        {
            Repository db = new Repository();

            String selectDataAlvo = @"SELECT LIMITE_EXECUCAO FROM ALVO_SLA AL
                                    JOIN CATEGORIA_CHAMADO CC ON CC.ID_CATEGORIA = AL.ID_CATEGORIA
                                    JOIN EMPRESA_CLIENTE EC ON EC.ID_EMPRESA_CLIENTE = AL.ID_EMPRESA_CLIENTE
                                    WHERE EC.EMPRESA_CLIENTE ='" + mChamado.cliente
                                    + "' AND CC.CATEGORIA ='"
                                    + mChamado.categoria +"';";
            Int16 AlvoSLA = Convert.ToInt16(db.Consultar(selectDataAlvo));




            String InsertSql = @"INSERT INTO CHAMADOS (TIPO_CHAMADO,
                                                      NUM_CHAMADO, 
                                                      ID_CLIENTE,  
                                                      ID_CATEGORIA, 
                                                      URGENCIA,         
                                                      DATA_ABERTURA,
                                                      DATA_ALVO_RESOLUCAO,
                                                      STATUS_CHAMADO) VALUES ('"
                                      + mChamado.tipo_chamado + "',"
                                      + "(SELECT NUM FROM(SELECT MAX(NUM_CHAMADO) +1 AS NUM FROM chamados) AS TEMP)" + ","
                                      + "(SELECT ID_CLIENTE FROM(SELECT ID_CLIENTE FROM CLIENTE WHERE NOME_CLIENTE ='" + mChamado.requisitante + "') AS TEMP),"
                                      + "(SELECT ID_CATEGORIA FROM(SELECT ID_CATEGORIA FROM CATEGORIA_CHAMADO WHERE CATEGORIA ='" + mChamado.categoria + "')AS TEMP),'"
                                      + mChamado.urgencia + "','"
                                      + (DateTime.Now) + "','"
                                      + DateTime.Now.AddHours(AlvoSLA) + "'," 
                                      + "'Aberto');";
            String ConsultarSql = "SELECT MAX(NUM_CHAMADO) FROM CHAMADOS;";

           var NewNumChamado =  db.InserirChamado(InsertSql, ConsultarSql);

            EditarChamado EditCham = new EditarChamado();
            EditCham.EditChamado(NewNumChamado);
            
        }

        public void ExibirChamadosAbertos()
        {
            Repository db = new Repository();
            string query = "SELECT * FROM CHAMADOS WHERE STATUS_CHAMADO = 'ABERTO';";
            db.ExibeChamados(query);
        }
       




    }
}