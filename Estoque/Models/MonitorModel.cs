using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estoque.Models
{
    public class MonitorModel
    {
        public int Id { get; set; }

        public string Patrimonio { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Nserie { get; set; }

        public string Status { get; set; }

        public string Estado { get; set; }

        public string Antcolab { get; set; }

        public string Atualcolab { get; set; }

        public string Dtacompra { get; set; }

        public string Obs { get; set; }
    }
}