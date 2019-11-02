using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSystemServiceManagement
{
    public class CategoriaChamados
    {
        public String CategoriaS { get; set; }
        public List<Categorias> CategoriaList { get; set; }
    }

    public class Categorias
    {
        public String Categoria { get; set; }
    }
}