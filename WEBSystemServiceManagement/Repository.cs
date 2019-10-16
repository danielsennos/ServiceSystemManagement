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
        //string PATH = "SERVER=localhost;DATABASE=dbssm; UID=root;PASSWORD=";
        string PATH = "SERVER=den1.mysql4.gear.host;DATABASE=dbssm; UID=dbssm;PASSWORD=Pm6Qup1~_5c7";

        #region MetodosGenericos
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
        #endregion


        public ArrayList CarregaCategorias(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
              {
                    lista.Add(row["categoria"].ToString());
              }
            }
            return lista;
        }
        public ArrayList CarregaGruposSuporte(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["grupo_sup_nome"].ToString());
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
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["nome_cliente"].ToString());
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
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["empresa_cliente"].ToString());
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

        public ArrayList ExibeChamados(String SQLQuery)
        {
            ArrayList lista = new ArrayList();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["tipo_chamado"].ToString());
                    lista.Add(row["num_chamado"].ToString());
                    lista.Add(row["urgencia"].ToString());

                }
            }
            return lista;
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
                    pModel.requisitante = row["EMPRESA_CLIENTE"].ToString();
                    pModel.cliente = row["NOME_CLIENTE"].ToString();
                    pModel.urgencia = row["URGENCIA"].ToString();
                    pModel.data_abertura = row["DATA_ABERTURA"].ToString();
                    pModel.data_alvo_resolucao = row["DATA_ALVO_RESOLUCAO"].ToString();
                    pModel.data_conclusao = row["DATA_CONCLUSAO"].ToString();
                    pModel.resumo_chamado = row["RESUMO_CHAMADO"].ToString();                    

                }
            }
            return pModel;
        }

        public DataTable RetornaNotasChamado(String SQLQuery)
        {
            //ArrayList lista = new ArrayList();
            //List<AnotacoesList> Lista = new List<AnotacoesList>();
            DataTable dt = new DataTable();

            using (var conn = new MySqlConnection(PATH))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);
                //DataSet dataset = new DataSet();
                //adapter.Fill(dataset);
                
                adapter.Fill(dt);

                //foreach (DataRow row in dt.Rows)
                //{
                //    AnotacoesList ListAnotacoes = new AnotacoesList();
                //    ListAnotacoes.data_anotacao = row["DATA_NOTA"].ToString();
                //    ListAnotacoes.anotacao = row["NOTA"].ToString();
                //    Lista.Add(ListAnotacoes);

                //}
            }
            //return Lista;
            return dt;
        }

        public void AtualizaStatus(string UpdateSQL)
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

    }

}