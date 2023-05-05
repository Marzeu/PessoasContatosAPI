using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Data;

namespace PessoasContatosAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PessoasContatosContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PessoasContatosContext>>()))
            {
                if (context == null || context.Pessoa == null)
                {
                    throw new ArgumentNullException("Null PessoasContext");
                }

                if (context.Pessoa.Any())
                {
                    return;
                }

                context.Pessoa.AddRange(
                    new Pessoa
                    {
                        Nome = "Marzeu",
                        Contatos = new List<Contato>()
                        {
                            new Contato {
                            Valor = "marzeu@gmail.com",
                            Tipo = ContatosCategory.Email,
                            },
                            new Contato {
                            Valor = "048998765412",
                            Tipo = ContatosCategory.Telefone,
                            },
                            new Contato {
                            Valor = "048998765412",
                            Tipo = ContatosCategory.Whatsapp,
                            }
                        }
                    },

                        new Pessoa
                        {
                            Nome = "André",
                            Contatos = new List<Contato>()
                        {
                            new Contato {
                            Valor = "andre@gmail.com",
                            Tipo = ContatosCategory.Email,
                            },
                            new Contato {
                            Valor = "048912345678",
                            Tipo = ContatosCategory.Telefone,
                            },
                            new Contato {
                            Valor = "048912345678",
                            Tipo = ContatosCategory.Whatsapp,
                            }
                        }
                        },

                        new Pessoa
                        {
                            Nome = "Arthur",
                            Contatos = new List<Contato>()
                        {
                            new Contato {
                            Valor = "arthur@gmail.com",
                            Tipo = ContatosCategory.Email,
                            },
                            new Contato {
                            Valor = "048991239874",
                            Tipo = ContatosCategory.Telefone,
                            },
                            new Contato {
                            Valor = "048991239874",
                            Tipo = ContatosCategory.Whatsapp,
                            }
                        }
                        },

                        new Pessoa
                        {
                            Nome = "Anderson",
                            Contatos = new List<Contato>()
                        {
                            new Contato {
                            Valor = "anderson@gmail.com",
                            Tipo = ContatosCategory.Email,
                            },
                            new Contato {
                            Valor = "048998765555",
                            Tipo = ContatosCategory.Telefone,
                            },
                            new Contato {
                            Valor = "048998765555",
                            Tipo = ContatosCategory.Whatsapp,
                            }
                        }
                        }
                );
                context.SaveChanges();
            }
        }
    }
}
