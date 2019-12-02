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

        public class GrupoUsuario
        {
            public string idGrupo { get; set; }
            public string NomeGrupo { get; set; }
            public string StatusGrupo { get; set; }
        }

        public class Usuario
        {
            public string idUsuario { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public string NomeUsuario { get; set; }
            public string StatusUsuario { get; set; }
            public string idGrupo { get; set; }
            public string Grupo { get; set; }
            public string idEmpresa { get; set; }
            public string Empresa { get; set; }
            public string idPermissao { get; set; }
            public string Permissao { get; set; }
            public string EmailUsuario { get; set; }
        }


    }
}