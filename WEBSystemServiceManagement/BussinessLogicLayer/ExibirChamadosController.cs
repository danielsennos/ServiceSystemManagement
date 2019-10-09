using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class ExibirChamadosController
    {
        public void ExibirChamadosAbertos()
        {
            Repository db = new Repository();
            string query = "SELECT * FROM CHAMADOS WHERE STATUS_CHAMADO = 'ABERTO';";
            db.ExibeChamados(query);
        }
    }
}