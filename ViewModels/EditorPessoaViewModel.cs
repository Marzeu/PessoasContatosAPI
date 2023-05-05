using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace PessoasContatosAPI.ViewModels
{
    public class EditorPessoaViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }  
    }
}
