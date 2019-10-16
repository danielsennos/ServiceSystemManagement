using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class ChamadoController
    {
        public string SalvarChamado(ChamadoModel mChamado)
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

           String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES((SELECT ID_CHAMADO FROM (SELECT ID_CHAMADO FROM CHAMADOS WHERE NUM_CHAMADO =" + NewNumChamado + ") AS TEMP),'Aberto','" + DateTime.Now + "');";
           db.Inserir(queryNota);


            return NewNumChamado;           
        }

        public void ExibirChamadosAbertos()
        {
            Repository db = new Repository();
            string query = "SELECT * FROM CHAMADOS WHERE STATUS_CHAMADO = 'ABERTO';";
            db.ExibeChamados(query);
        }
        public ChamadoModel EditarChamado(string NumChamado)
        {
            Repository db = new Repository();
            ChamadoModel pModel = new ChamadoModel();            

            string SqlIdChamado = @"SELECT ID_CHAMADO FROM CHAMADOS WHERE NUM_CHAMADO =" + NumChamado + ";";
            pModel.id_chamado = Convert.ToInt32(db.Consultar(SqlIdChamado));

            string SqlChamado = @"SELECT CS.ID_CHAMADO, CS.TIPO_CHAMADO, CS.NUM_CHAMADO, CS.STATUS_CHAMADO, CC.CATEGORIA, CLI.NOME_CLIENTE, EMCLI.EMPRESA_CLIENTE, CS.URGENCIA, CS.DATA_ABERTURA, 
            CS.DATA_ALVO_RESOLUCAO, CS.DATA_CONCLUSAO, CS.RESUMO_CHAMADO
            FROM CHAMADOS CS
            LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
            LEFT JOIN EMPRESA_CLIENTE EMCLI ON EMCLI.ID_EMPRESA_CLIENTE = CS.ID_EMPRESA_CLIENTE
            LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA
            WHERE CS.ID_CHAMADO = " + pModel.id_chamado + ";";
            pModel = db.EditChamados(SqlChamado);

            return pModel;
        }

        public DataTable RetornaAnotacoes(int IdChamado)
        {
            Repository db = new Repository();

            string SqlNotasChamado = "SELECT DATA_NOTA as Data, NOTA as Anotação FROM NOTAS_CHAMADOS WHERE ID_CHAMADO =" + IdChamado + ";";

            DataTable AnotacoesDt = db.RetornaNotasChamado(SqlNotasChamado);

            return AnotacoesDt;
        }





        }
}