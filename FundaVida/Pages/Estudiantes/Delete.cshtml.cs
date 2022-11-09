using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Data;
using FundaVida.Models;

namespace FundaVida.Pages.Estudiantes
{
    public class DeleteModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public DeleteModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FirstOrDefaultAsync(m => m.EstudianteId == id);

            if (estudiante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudiante = estudiante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante != null)
            {
                Estudiante = estudiante;
                _context.Estudiantes.Remove(Estudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
