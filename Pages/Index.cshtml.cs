using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Data;
using PessoasContatosAPI.Models;

namespace PessoasContatosAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PessoasContatosAPI.Data.PessoasContatosContext _context;

        public IndexModel(PessoasContatosAPI.Data.PessoasContatosContext context)
        {
            _context = context;
        }

        public IList<Pessoa> Pessoa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pessoa != null)
            {
                Pessoa = await _context.Pessoa.ToListAsync();
            }
        }
    }
}
