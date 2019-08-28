using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estoque.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cta365 { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public string Gestor { get; set; }
        public string Dtaadm { get; set; }
        public string Dtadem { get; set; }
        public string Statad { get; set; }
        public string Statjira { get; set; }
        public string Statconflu { get; set; }
        public string Statslack { get; set; }
        public string Door { get; set; }
        public string Ponto { get; set; }
        public string Status { get; set; }
    }
}