using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity;

namespace FundaVida.Pages.Estudiantes
{
    public class IndexModel : PageModel
    {
        private readonly FundavidadbContext _context;

        public IndexModel(FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiante { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estudiantes != null)
            {
                Estudiante = await _context.Estudiantes.ToListAsync();
            }
        }
    }
}
