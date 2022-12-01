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
using FundaVida.Pages.Management.Courses;

namespace FundaVida.Pages.Courses
{
    public class EditModel : ModalityNamePageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public EditModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course =  await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            PopulateModalityList(_context);
            PopulateProfessorList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateModalityList(_context, selectedModality: Course.ModalityId);
                PopulateProfessorList(_context, selectedProfessor: Course.ProfessorId);
                return Page();
            }

            if (Course.ImageFile != null)
            {
                byte[] pic = null;

                using (Stream fs = Course.ImageFile.OpenReadStream())
                {
                    using (var memorystream = new MemoryStream())
                    {
                        fs.CopyTo(memorystream);
                        pic = memorystream.ToArray();
                    }
                }

                Course.ImageData = pic;
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.CourseId))
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

        private bool CourseExists(int id)
        {
          return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
