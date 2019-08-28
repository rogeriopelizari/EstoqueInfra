using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Estoque.Models
{
    public class LinhaModel
    {
        public int Id { get; set; }

        public string Simcard { get; set; }

        public int Numero { get; set; }

        public string Operadora { get; set; }

        public string Antcolab { get; set; }

        public string Atualcolab { get; set; }

        public string Status { get; set; }

        public string Obs { get; set; }
    }
}