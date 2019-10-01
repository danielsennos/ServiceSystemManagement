using MySql.Data.MySqlClient;
using System;
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
        string PATH = "SERVER=den1.mysql4.gear.host;DATABASE=dbssm; UID=dbssm;PASSWORD=Pm6Qup1~_5c8";

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



        public void Categorias(String SQLQuery)
        {
            SQLQuery = @"SELECT CATEGORIA FROM CATEGORIA_CHAMADO;";

            using (var conn = new MySqlConnection("SERVER=den1.mysql4.gear.host;DATABASE=dbssm; UID=dbssm;PASSWORD=Pm6Qup1~_5c8")) { 
            // conexao = new MySqlConnection(PATH);
            // conexao.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(SQLQuery, conn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            foreach(DataRow linha in dataset.Tables[0].Rows)
                {

                }


        }

        }

       
    } 

}