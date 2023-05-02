namespace PessoasContatosAPI.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ContatosCategory Tipo { get; set; }
    }

    public enum ContatosCategory
    {
        Telefone = 0,
        Email = 1,
        Whatsapp = 2,
    }
}
