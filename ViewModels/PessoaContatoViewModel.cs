using PessoasContatosAPI.Models;

namespace PessoasContatosAPI.ViewModels
{
    public class PessoaContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}
