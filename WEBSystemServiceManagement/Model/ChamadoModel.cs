using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class ChamadoModel
    {
        public String tipo_chamado { get; set; }
        public string num_chamado { get; set; }
        public int id_cliente { get; set; }
        public string cliente { get; set; }
        public string requisitante { get; set; }
        public int id_categoria { get; set; }
        public string categoria { get; set; }
        public string urgencia { get; set; }
        public DateTime data_abertura { get; set; }
        public DateTime data_alvo_resolucao { get; set; }
        public string status_chamado { get; set; }
        public string resumo_chamado { get; set; }
        public int id_designado { get; set; }
        public int id_grupo_usuario { get; set; }
        public string grupo_designado { get; set; }
        public string anotacao { get; set; }
        public List<AnotacoesList> anotacoeslista {get; set;}


    }
    public class AnotacoesList
    {
        public DateTime data_anotacao { get; set; }
        public long anotacoes { get; set; }
    }
}