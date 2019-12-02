using System;
using System.Data;
using System.Globalization;

namespace WEBSystemServiceManagement
{
    public class ChamadoController
    {
        public string SalvarChamado(ChamadoModel mChamado)
        {
            Repository db = new Repository();

            String selectDataAlvo = @"SELECT ALVO_SLA FROM CATEGORIA_CHAMADO WHERE CATEGORIA = '" +
                                    mChamado.categoria + "'";
            Int16 AlvoSLA = Convert.ToInt16(db.Consultar(selectDataAlvo));

            String InsertSql = @"INSERT INTO CHAMADOS (TIPO_CHAMADO,
                                                      NUM_CHAMADO, 
                                                      ID_CLIENTE,
                                                      ID_EMPRESA,  
                                                      ID_CATEGORIA, 
                                                      URGENCIA,         
                                                      DATA_ABERTURA,
                                                      DATA_ALVO_RESOLUCAO,
                                                      STATUS_CHAMADO,
                                                      RESUMO_CHAMADO,
                                                      ID_GRUPO,
                                                      ID_DESIGNADO) VALUES ('"
                                      + mChamado.tipo_chamado + "'," //TIPO_CHAMADO
                                      + "(SELECT NUM FROM(SELECT (COALESCE(MAX(NUM_CHAMADO),0) +1) AS NUM FROM chamados) AS T1)" + "," //NUM_CHAMADO
                                      + "(SELECT ID_CLIENTE FROM(SELECT ID_CLIENTE FROM CLIENTE WHERE NOME_CLIENTE ='" + mChamado.requisitante + "') AS T2)," //ID_CLIENTE
                                      + "(SELECT ID FROM (SELECT ID_EMPRESA AS ID FROM EMPRESAS WHERE EMPRESA_NOME = '" + mChamado.cliente + "') AS T3)," //ID_EMPRESA
                                      + "(SELECT ID_CATEGORIA FROM(SELECT ID_CATEGORIA FROM CATEGORIA_CHAMADO WHERE CATEGORIA ='" + mChamado.categoria + "')AS T4),'" //ID_CATEGORIA
                                      + mChamado.urgencia + "','" //URGENCIA
                                      + (DateTime.Now.ToString("dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"))) + "','" //DATA_ABERTURA
                                      + (DateTime.Now.AddHours(AlvoSLA)).ToString("dd/MM/yyyy HH:mm", new CultureInfo("pt-BR")) + "'," //DATA_ALVO_RESOLUCAO
                                      + "'Aberto','" //STATUS_CHAMADO
                                      + mChamado.resumo_chamado + "'," //RESUMO_CHAMADO
                                      + "(SELECT ID FROM(SELECT ID_GRUPO AS ID FROM GRUPO_USUARIO WHERE GRUPO_NOME = '" + mChamado.grupo_designado + "') AS T5),"  //ID_GRUPO
                                      + "(SELECT ID FROM(SELECT ID_USUARIO AS ID FROM USUARIOS WHERE NOME_USUARIO = '" + mChamado.designado + "') AS T6))";  //ID_DESIGANDO



            String ConsultarSql = "SELECT MAX(NUM_CHAMADO) FROM CHAMADOS;";

            var NewNumChamado = db.InserirChamado(InsertSql, ConsultarSql);

            String queryNota = @"INSERT INTO NOTAS_CHAMADOS(ID_CHAMADO, NOTA, DATA_NOTA) VALUES((SELECT ID_CHAMADO FROM (SELECT ID_CHAMADO FROM CHAMADOS WHERE NUM_CHAMADO =" + NewNumChamado + ") AS TEMP),'Aberto','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm", new CultureInfo("pt-BR")) + "');";
            db.Inserir(queryNota);


            return NewNumChamado;
        }

        public ChamadoModel EditarChamado(string NumChamado)
        {
            Repository db = new Repository();
            ChamadoModel pModel = new ChamadoModel();

            string SqlChamado = @"SELECT CS.ID_CHAMADO, CS.TIPO_CHAMADO, CS.NUM_CHAMADO, CS.STATUS_CHAMADO, CC.CATEGORIA, CLI.NOME_CLIENTE, EMCLI.EMPRESA_NOME, CS.URGENCIA, CS.DATA_ABERTURA, 
            CS.DATA_ALVO_RESOLUCAO, CS.DATA_CONCLUSAO, CS.RESUMO_CHAMADO, GU.GRUPO_NOME, US.NOME_USUARIO
            FROM CHAMADOS CS
            LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
            LEFT JOIN EMPRESAS EMCLI ON EMCLI.ID_EMPRESA = CS.ID_EMPRESA
            LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA 
			LEFT JOIN GRUPO_USUARIO GU ON GU.ID_GRUPO = CS.ID_GRUPO
            LEFT JOIN USUARIOS US ON US.ID_USUARIO = CS.ID_DESIGNADO
            WHERE CS.NUM_CHAMADO = " + NumChamado + ";";
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

        public DataTable ExibirChamados(String StatusChamado)
        {
            Repository db = new Repository();
            string query = @"SELECT CONCAT(CS.TIPO_CHAMADO, CS.NUM_CHAMADO) as 'Número do Chamado', CS.STATUS_CHAMADO as 'Status',
                            CC.CATEGORIA as 'Categoria', EMCLI.EMPRESA_NOME as 'Cliente', CS.URGENCIA as 'Urgência',
                            CS.DATA_ABERTURA as 'Data Abertura', CS.DATA_ALVO_RESOLUCAO as 'Data Alvo para Resolução'
                            FROM CHAMADOS CS
                            LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
                            LEFT JOIN EMPRESAS EMCLI ON EMCLI.ID_EMPRESA = CS.ID_EMPRESA
                            LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA
                            WHERE CS.STATUS_CHAMADO = '" + StatusChamado + "';";
            DataTable ChamadosDt = db.ExibeChamados(query);
            return ChamadosDt;

        }



    }
}