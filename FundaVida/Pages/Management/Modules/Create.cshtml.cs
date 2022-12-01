using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Modules
{
    public class CreateModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public CreateModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Modules.Add(Module);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
