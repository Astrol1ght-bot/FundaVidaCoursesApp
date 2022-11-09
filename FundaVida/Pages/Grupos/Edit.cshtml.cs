using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundaVida.Data;
using FundaVida.Models;

namespace FundaVida.Pages.Grupos
{
    public class EditModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public EditModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grupo Grupo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo =  await _context.Grupos.FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupo == null)
            {
                return NotFound();
            }
            Grupo = grupo;
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

            _context.Attach(Grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(Grupo.GrupoId))
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

        private bool GrupoExists(int id)
        {
          return _context.Grupos.Any(e => e.GrupoId == id);
        }
    }
}
