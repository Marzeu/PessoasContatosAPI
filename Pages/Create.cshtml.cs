using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PessoasContatosAPI.Data;
using PessoasContatosAPI.Models;

namespace PessoasContatosAPI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PessoasContatosAPI.Data.PessoasContatosContext _context;

        public CreateModel(PessoasContatosAPI.Data.PessoasContatosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Pessoa == null || Pessoa == null)
            {
                return Page();
            }

            _context.Pessoa.Add(Pessoa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
