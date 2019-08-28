using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Models
{
    public class UsuarioLoginViewModel
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "Favor preencher o Campo Usuário.")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Favor preencher o Campo Senha.")]
        public string Senha { get; set; }
    }
}