using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class AdminController
    {
        public DataTable ExibirEmpresa(){
            Repository db = new Repository();
            String query = @"SELECT EMPRESA_CLIENTE AS 'EMPRESA', CNPJ_EMPRESA_CLIENTE AS 'CNPJ', ENDERECO_EMPRESA AS 'Endereço', 
                            CIDADE_EMPRESA AS 'Cidade', ESTADO_EMPRESA AS 'Estado'
                            FROM EMPRESA_CLIENTE";
            DataTable dt = db.RetornaTabela(query);

            return dt;
            }
        public DataTable ExibirCliente()
        {
            Repository db = new Repository();
            String query = @"SELECT CLI.NOME_CLIENTE AS 'Nome do Cliente', CLI.CIDADE_CLIENTE AS 'Cidade', CLI.TELEFONE_CLIENTE AS 'Telefone', CLI.EMAIL_CLIENTE AS 'E-mail',
                            EC.EMPRESA_CLIENTE AS 'Empresa'
                            FROM CLIENTE CLI
                            JOIN EMPRESA_CLIENTE EC ON EC.ID_EMPRESA_CLIENTE = CLI.ID_EMPRESA_CLIENTE";
            DataTable dt = db.RetornaTabela(query);

            return dt;
        }
        public DataTable ExibirCategoria()
        {
            Repository db = new Repository();
            String query = @"SELECT CATEGORIA AS 'Categoria', ALVO_SLA AS 'SLA de Resolução (hora)' FROM CATEGORIA_CHAMADO";
            DataTable dt = db.RetornaTabela(query);

            return dt;
        }

    }
}