using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public DetailsModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Modality)
                .Include(c => c.Professor)
                .FirstOrDefaultAsync(c => c.CourseId == id);
                

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }
    }
}
