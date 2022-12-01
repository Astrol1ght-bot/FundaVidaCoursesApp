using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using FundaVida.Pages.Management.Courses;

namespace FundaVida.Pages.Courses
{
    public class CreateModel : ModalityNamePageModel
    {
        private readonly FundavidadbContext _context;
        

        public CreateModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateModalityList(_context);
            PopulateProfessorList(_context);

            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                // Select IDs if TryUpdateModelAsync fails.
                PopulateModalityList(_context, selectedModality: Course.ModalityId);
                PopulateProfessorList(_context, selectedProfessor: Course.ProfessorId);
                return Page();
            }


            byte[] pic = null;
            if (Course.ImageFile != null)
            {
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


            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
