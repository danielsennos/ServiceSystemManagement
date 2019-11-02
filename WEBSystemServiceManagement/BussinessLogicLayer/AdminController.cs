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
            String query = @"SELECT EMPRESA_NOME AS 'EMPRESA', CNPJ_EMPRESA AS 'CNPJ', ENDERECO_EMPRESA AS 'Endereço', 
                            CIDADE_EMPRESA AS 'Cidade', ESTADO_EMPRESA AS 'Estado'
                            FROM EMPRESAS";
            DataTable dt = db.RetornaTabela(query);

            return dt;
            }
        public DataTable ExibirCliente()
        {
            Repository db = new Repository();
            String query = @"SELECT CLI.NOME_CLIENTE AS 'Nome do Cliente', CLI.CIDADE_CLIENTE AS 'Cidade', CLI.TELEFONE_CLIENTE AS 'Telefone', CLI.EMAIL_CLIENTE AS 'E-mail',
                            EC.EMPRESA_NOME AS 'Empresa'
                            FROM CLIENTE CLI
                            JOIN EMPRESAS EC ON EC.ID_EMPRESA = CLI.ID_EMPRESA";
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

        public DataTable ExibirGrupoSuporte()
        {
            Repository db = new Repository();
            String query = @"SELECT GRUPO_SUP_NOME AS 'Grupo de Suporte' FROM GRUPO_USUARIO";
            DataTable dt = db.RetornaTabela(query);

            return dt;
        }
        public DataTable ExibirUsuarios()
        {
            Repository db = new Repository();
            String query = @"SELECT US.NOME_USUARIO AS 'Nome', US.STATUS_USUARIO AS 'Status',US.EMAIL_USUARIO, GS.GRUPO_SUP_NOME, CLI.EMPRESA_NOME AS 'Empresa',
                            PU.NOME_PERMISSAO AS 'Tipo de Permissão'
                            FROM USUARIOS US
                            LEFT JOIN GRUPO_USUARIO GS ON US.ID_GRUPO_SUP = GS.ID_GRUPO_SUP
                            LEFT JOIN EMPRESAS CLI ON US.ID_EMPRESA = CLI.ID_EMPRESA
                            LEFT JOIN PERMISSOES_USUARIOS PU ON PU.ID_PERMISSAO = US.ID_PERMISSAO ";
            DataTable dt = db.RetornaTabela(query);

            return dt;
        }

        public AdminModel.Empresa ExibirEmpresa(string nome) 
        {
            Repository db = new Repository();
            AdminModel.Empresa pModel = new AdminModel.Empresa();
            
            string Sql = @"SELECT * FROM EMPRESAS WHERE EMPRESA_NOME ='" + nome + "';";
            pModel = db.EditEmpresa(Sql);

            return pModel;
        }

        public void EditarEmpresa( AdminModel.Empresa pModel)
        {
            Repository db = new Repository();

            String SQL = @"UPDATE EMPRESAS SET 
                                            EMPRESA_NOME ='" +pModel.NomeEmpresa + "'," +
                                            "CNPJ_EMPRESA = '" + pModel.CNPJEmpresa + "'," +
                                            "CIDADE_EMPRESA = '" + pModel.CidadeEmpresa + "'," +
                                            "ESTADO_EMPRESA = '" + pModel.EstadoEmpresa + "'," +
                                            "STATUS_EMPRESA = '" + pModel.StatusEmpresa + "'" +
                                            " WHERE ID_EMPRESA = " + pModel.IdEmpresa;
            db.Update(SQL);
        }
        public void IncluirEmpresa(AdminModel.Empresa pModel)
        {
            Repository db = new Repository();

            String SQLConsultarMaxId = "SELECT MAX(ID_EMPRESA) FROM EMPRESAS";
            var MaxId  = Convert.ToInt32(db.Consultar(SQLConsultarMaxId)) + 1;

            String SQL = @"INSERT INTO EMPRESAS VALUES ( " +
                                                    MaxId + ",'" +
                                                    pModel.NomeEmpresa + "','" +
                                                    pModel.CNPJEmpresa + "','" +
                                                    pModel.EnderecoEmpresa + "','" +
                                                    pModel.CidadeEmpresa + "','" +
                                                    pModel.EstadoEmpresa + "','" +
                                                    pModel.StatusEmpresa + "')";
            
            db.Inserir(SQL);
        }

    }
}