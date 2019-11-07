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
        public class Cliente
        {
            public string IdCliente { get; set; }
            public string NomeCliente { get; set; }
            public string CidadeCliente { get; set; }
            public string TelefoneCliente { get; set; }
            public string EmailCliente { get; set; }
            public string EmpresaCliente { get; set; }
            public string EstadoCliente { get; set; }
            public string StatusCliente { get; set; }

        }

        public class Categoria
        {
           public string idCategoria { get; set; }
            public string NomeCategoria { get; set; }
            public string SLACategoria { get; set; }
            public string StatusCategoria { get; set; }
        }
        
    }
}