using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estoque.Models
{
    public class CelularModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Informe o Imei")]
        public string Imei { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Antigocolab { get; set; }

        public string Atualcolab { get; set; }

        public string Dtacompra { get; set; }

        public string Status { get; set; }

        public string Estado { get; set; }

        public string Obs { get; set; }
    }
}