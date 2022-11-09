using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Data;
using FundaVida.Models;

namespace FundaVida.Pages.Grupos
{
    public class DetailsModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public DetailsModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

      public Grupo Grupo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Grupos == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupos.FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupo == null)
            {
                return NotFound();
            }
            else 
            {
                Grupo = grupo;
            }
            return Page();
        }
    }
}
