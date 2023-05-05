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
    public class DetailsModel : PageModel
    {
        private readonly PessoasContatosAPI.Data.PessoasContatosContext _context;

        public DetailsModel(PessoasContatosAPI.Data.PessoasContatosContext context)
        {
            _context = context;
        }

      public Pessoa Pessoa { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else 
            {
                Pessoa = pessoa;
            }
            return Page();
        }
    }
}
