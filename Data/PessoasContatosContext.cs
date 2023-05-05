using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Models;
using System.Reflection.Metadata;

namespace PessoasContatosAPI.Data
{
    public class PessoasContatosContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; } = default!;
        public DbSet<Contato> Contato { get; set; } = default!;

        public PessoasContatosContext(DbContextOptions<PessoasContatosContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Contatos)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.PessoaId)
                .HasPrincipalKey(e => e.Id);
        }        
    }
}
