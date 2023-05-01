namespace PessoasContatosAPI.Models
{
    public class Pessoas
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ContatosCategory Contatos { get; set;}

    }

    public enum ContatosCategory
    {
        Telefone = 0,
        Email = 1,
        Whatsapp = 2,
    }
}
