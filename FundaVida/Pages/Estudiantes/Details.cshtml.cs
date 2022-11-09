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
    public class DetailsModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public DetailsModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

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
    }
}
