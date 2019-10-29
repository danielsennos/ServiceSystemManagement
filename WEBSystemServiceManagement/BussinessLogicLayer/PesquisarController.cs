﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class PesquisarController
    {
        public DataTable ProcurarPalavraChave(string PalavraChave)
        {
            Repository db = new Repository();
            string SQL = @"SELECT CONCAT(CS.TIPO_CHAMADO, CS.NUM_CHAMADO) as 'Número do Chamado', CS.STATUS_CHAMADO as 'Status',
                            CC.CATEGORIA as 'Categoria', EMCLI.EMPRESA_CLIENTE as 'Cliente', CS.URGENCIA as 'Urgência', CS.RESUMO_CHAMADO as 'Resumo',
                            CS.DATA_ABERTURA as 'Data Abertura', CS.DATA_ALVO_RESOLUCAO as 'Data Alvo para Resolução', CS.DATA_CONCLUSAO AS ' Data de Conclusão'
                            FROM CHAMADOS CS
                            LEFT JOIN CLIENTE CLI ON CS.ID_CLIENTE = CLI.ID_CLIENTE
                            LEFT JOIN EMPRESA_CLIENTE EMCLI ON EMCLI.ID_EMPRESA_CLIENTE = CS.ID_EMPRESA_CLIENTE
                            LEFT JOIN CATEGORIA_CHAMADO CC ON CS.ID_CATEGORIA = CC.ID_CATEGORIA
                            WHERE CS.NUM_CHAMADO LIKE '%" + PalavraChave + "%' OR " +
                            "CS.RESUMO_CHAMADO LIKE '%" + PalavraChave + "%';";
            DataTable dt = db.Procurar(SQL);
            return dt;
        }
    }
}