namespace PessoasContatosAPI.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}
