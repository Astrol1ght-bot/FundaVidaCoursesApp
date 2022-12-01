using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Enrolls
{
    public class DetailsModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public DetailsModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

      public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
            }
            return Page();
        }
    }
}
