using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Enrolls
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
        ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
