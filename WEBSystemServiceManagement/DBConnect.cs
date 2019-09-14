using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class DBConnect
    {
        private MySqlConnection conexao;
        string PATH = "SERVER=localhost;DATABASE=dbssm; UID=root;PASSWORD=";        

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
            String Result;
           
                conexao = new MySqlConnection(PATH);
                conexao.Open();

                MySqlCommand comandos = new MySqlCommand(ConsultarSql, conexao);
                comandos.ExecuteNonQuery();

                MySqlDataReader dr;
                dr = comandos.ExecuteReader();
                dr.Read();
                Result = dr.GetString(0);


                conexao.Close(); 

            return Result;
        }
    } 

}