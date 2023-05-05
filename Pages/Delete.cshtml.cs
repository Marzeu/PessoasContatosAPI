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
    public class DeleteModel : PageModel
    {
        private readonly PessoasContatosAPI.Data.PessoasContatosContext _context;

        public DeleteModel(PessoasContatosAPI.Data.PessoasContatosContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pessoa == null)
            {
                return NotFound();
            }
            var pessoa = await _context.Pessoa.FindAsync(id);

            if (pessoa != null)
            {
                Pessoa = pessoa;
                _context.Pessoa.Remove(Pessoa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
