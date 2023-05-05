using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PessoasContatosAPI.Data;
using PessoasContatosAPI.Models;

namespace PessoasContatosAPI.Pages
{
    public class EditModel : PageModel
    {
        private readonly PessoasContatosAPI.Data.PessoasContatosContext _context;

        public EditModel(PessoasContatosAPI.Data.PessoasContatosContext context)
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

            var pessoa =  await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            Pessoa = pessoa;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(Pessoa.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PessoaExists(int id)
        {
          return (_context.Pessoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
