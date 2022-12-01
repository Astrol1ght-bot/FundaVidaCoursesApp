using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Professors
{
    public class EditModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public EditModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Professor Professor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Professors == null)
            {
                return NotFound();
            }

            var professor =  await _context.Professors.FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }
            Professor = professor;
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

            _context.Attach(Professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(Professor.ProfessorId))
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

        private bool ProfessorExists(int id)
        {
          return _context.Professors.Any(e => e.ProfessorId == id);
        }
    }
}
