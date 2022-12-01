using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Modules
{
    public class DeleteModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public DeleteModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var module = await _context.Modules.FirstOrDefaultAsync(m => m.ModuleId == id);

            if (module == null)
            {
                return NotFound();
            }
            else 
            {
                Module = module;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }
            var module = await _context.Modules.FindAsync(id);

            if (module != null)
            {
                Module = module;
                _context.Modules.Remove(Module);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
