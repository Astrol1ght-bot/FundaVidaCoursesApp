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

namespace FundaVida.Pages.Management.Modules
{
    public class EditModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public EditModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Module Module { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var module =  await _context.Modules.FirstOrDefaultAsync(m => m.ModuleId == id);
            if (module == null)
            {
                return NotFound();
            }
            Module = module;
           ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
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

            _context.Attach(Module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(Module.ModuleId))
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

        private bool ModuleExists(int id)
        {
          return _context.Modules.Any(e => e.ModuleId == id);
        }
    }
}
