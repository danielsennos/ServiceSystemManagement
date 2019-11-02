using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class AdminModel
    {
        public class Empresa
        {
            public string IdEmpresa { get; set; }
            public string NomeEmpresa { get; set; }
            public string CNPJEmpresa { get; set; }
            public string EnderecoEmpresa { get; set; }
            public string CidadeEmpresa { get; set; }
            public string EstadoEmpresa { get; set; }
            public string StatusEmpresa { get; set; }

        }
        
    }
}