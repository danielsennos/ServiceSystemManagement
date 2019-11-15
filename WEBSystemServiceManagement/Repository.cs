using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class Repository
    {

        private MySqlConnection conexao;
        private readonly string PATH = "SERVER=den1.mysql4.gear.host;DATABASE=dbssm; UID=dbssm;PASSWORD=Pm6Qup1~_5c7";

        #region MetodosUniversais
        public void Inserir(String InsertSql)
        {
            try
            {
                conexao = new MySqlConnection(PATH);
                conexao.Open();

                MySqlCommand comandos = new MySqlCommand(InsertSql, conexao);
                comandos.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comando SQL" + ex.Message);
            }
        }
        public string Consultar(String ConsultarSql)
        {
            String Result = null;

            conexao = new MySqlConnection(PATH);
            conexao.Open();

            MySqlCommand comandos = new MySqlCommand(ConsultarSql, conexao);
            comandos.ExecuteNonQuery();

            MySqlDataReader dr;
            dr = comandos.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                Result = dr.GetString(0);
            }


            conexao.Close();

            return Result;
        }
        public DataTable RetornaTabela(String SQLQuery)
        {
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                adapter.Fill(dt);

            }

            return dt;
        }

        public void Update(string UpdateSQL)
        {
            conexao = new MySqlConnection(PATH);
            MySqlTransaction trans = null;
            try
            {
                conexao.Open();
                trans = conexao.BeginTransaction();
                MySqlCommand comandos = new MySqlCommand();
                comandos = new MySqlCommand(UpdateSQL, conexao);
                comandos.ExecuteNonQuery();
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Erro de comando SQL" + ex.Message);
            }
            finally { conexao.Close(); }
        }
        #endregion


        public ArrayList CarregaCategorias(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["categoria"].ToString());
                }
            }
            return lista;
        }

        public ArrayList CarregaRequisitante(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["nome_cliente"].ToString());
                }
            }
            return lista;
        }
        public ArrayList CarregaEmpresa(String SQLQuery) 
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["empresa_nome"].ToString());
                }
            }
            return lista;
        }

        public ArrayList CarregaCliente(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["NOME_CLIENTE"].ToString());
                }
            }
            return lista;
        }
        public ArrayList CarregaDesignado(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["NOME_USUARIO"].ToString());
                }
            }
            return lista;
        }

        public ArrayList CarregaGrupoUsuario(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["GRUPO_NOME"].ToString());
                }
            }
            return lista;
        }

        public ArrayList CarregaPermissoes(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["NOME_PERMISSAO"].ToString());
                }
            }
            return lista;
        }

        public String InserirChamado(String InsertSql, String ConsultarSql)
        {
            conexao = new MySqlConnection(PATH);
            MySqlTransaction trans = null;
            String Result = null;
            try
            {
                conexao.Open();
                trans = conexao.BeginTransaction();
                MySqlCommand comandos = new MySqlCommand();
                comandos = new MySqlCommand(InsertSql, conexao);
                comandos.ExecuteNonQuery();
                comandos = new MySqlCommand(ConsultarSql, conexao);
                comandos.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = comandos.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Result = dr.GetString(0);
                }
                dr.Close();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception("Erro de comando SQL" + ex.Message);
            }
            finally { conexao.Close(); }


            return Result;
        }

        public DataTable ExibeChamados(String SQLQuery)
        {
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                adapter.Fill(dt);

            }

            return dt;
        }

        public ChamadoModel EditChamados(String SQLQuery)
        {
            ChamadoModel pModel = new ChamadoModel();


            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.id_chamado = Convert.ToInt32(row["ID_CHAMADO"]);
                    pModel.tipo_chamado = row["TIPO_CHAMADO"].ToString();
                    pModel.num_chamado = row["NUM_CHAMADO"].ToString();
                    pModel.status_chamado = row["STATUS_CHAMADO"].ToString();
                    pModel.categoria = row["CATEGORIA"].ToString();
                    pModel.requisitante = row["EMPRESA_NOME"].ToString();
                    pModel.cliente = row["NOME_CLIENTE"].ToString();
                    pModel.urgencia = row["URGENCIA"].ToString();
                    pModel.data_abertura = row["DATA_ABERTURA"].ToString();
                    pModel.data_alvo_resolucao = row["DATA_ALVO_RESOLUCAO"].ToString();
                    pModel.data_conclusao = row["DATA_CONCLUSAO"].ToString();
                    pModel.resumo_chamado = row["RESUMO_CHAMADO"].ToString();
                    pModel.designado = row["NOME_USUARIO"].ToString();
                    pModel.grupo_designado = row["GRUPO_NOME"].ToString();

                }
            }
            return pModel;
        }

        public DataTable RetornaNotasChamado(String SQLQuery)
        {
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                adapter.Fill(dt);
            }

            return dt;
        }



        public DataTable Procurar(String SQLQuery)
        {
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                adapter.Fill(dt);

            }

            return dt;
        }

        public AdminModel.Empresa ExibirEmpresa(String SQLQuery)
        {
            AdminModel.Empresa pModel = new AdminModel.Empresa();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.IdEmpresa = row["ID_EMPRESA"].ToString();
                    pModel.NomeEmpresa = row["EMPRESA_NOME"].ToString();
                    pModel.CNPJEmpresa = row["CNPJ_EMPRESA"].ToString();
                    pModel.CidadeEmpresa = row["CIDADE_EMPRESA"].ToString();
                    pModel.EstadoEmpresa = row["ESTADO_EMPRESA"].ToString();
                    pModel.EnderecoEmpresa = row["ENDERECO_EMPRESA"].ToString();
                    pModel.StatusEmpresa = row["STATUS_EMPRESA"].ToString();


                }
            }
            return pModel;
        }

        public AdminModel.Cliente ExibirCliente(String SQLQuery)
        {
            AdminModel.Cliente pModel = new AdminModel.Cliente();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.IdCliente = row["ID_CLIENTE"].ToString();
                    pModel.NomeCliente = row["NOME_CLIENTE"].ToString();
                    pModel.CidadeCliente = row["CIDADE_CLIENTE"].ToString();
                    pModel.EstadoCliente = row["ESTADO_CLIENTE"].ToString();
                    pModel.TelefoneCliente = row["TELEFONE_CLIENTE"].ToString();
                    pModel.EmailCliente = row["EMAIL_CLIENTE"].ToString();
                    pModel.EmpresaCliente = row["EMPRESA_NOME"].ToString();
                    pModel.StatusCliente = row["STATUS_CLIENTE"].ToString();

                }
            }
            return pModel;
        }

        public AdminModel.Categoria ExibirCategoria(String SQLQuery)
        {
            AdminModel.Categoria pModel = new AdminModel.Categoria();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.idCategoria = row["ID_CATEGORIA"].ToString();
                    pModel.NomeCategoria = row["CATEGORIA"].ToString();
                    pModel.SLACategoria = row["ALVO_SLA"].ToString();
                    pModel.StatusCategoria = row["STATUS_CATEGORIA"].ToString();


                }
            }
            return pModel;
        }

        public AdminModel.GrupoUsuario ExibirGrupoUsuario(String SQLQuery)
        {
            AdminModel.GrupoUsuario pModel = new AdminModel.GrupoUsuario();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.idGrupo = row["ID_GRUPO"].ToString();
                    pModel.NomeGrupo = row["GRUPO_NOME"].ToString();
                    pModel.StatusGrupo = row["STATUS_GRUPO"].ToString();

                }
            }
            return pModel;
        } //ExibirUsuario

        public AdminModel.Usuario ExibirUsuarios(String SQLQuery)
        {
            AdminModel.Usuario pModel = new AdminModel.Usuario();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    pModel.idUsuario = row["ID_USUARIO"].ToString();
                    pModel.Login = row["LOGIN"].ToString();
                    pModel.NomeUsuario = row["NOME_USUARIO"].ToString();
                    pModel.EmailUsuario = row["EMAIL_USUARIO"].ToString();
                    pModel.Grupo = row["GRUPO_NOME"].ToString();
                    pModel.Permissao = row["NOME_PERMISSAO"].ToString();
                    pModel.StatusUsuario = row["STATUS_USUARIO"].ToString();
                }
            }
            return pModel;
        }

        public ArrayList CarregaCidadeEstados(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["nome"].ToString());
                }
            }
            return lista;
        }

    }
}