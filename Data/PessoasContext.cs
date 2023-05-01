using Microsoft.EntityFrameworkCore;

namespace PessoasContatosAPI.Data
{
    public class PessoasContext : DbContext
    {
        public PessoasContext(DbContextOptions<PessoasContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
