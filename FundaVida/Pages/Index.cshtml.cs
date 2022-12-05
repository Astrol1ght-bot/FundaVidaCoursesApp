using FundaVida.Entity.Data;
using FundaVida.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FundaVida.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FundavidadbContext _context;

        public IndexModel(FundavidadbContext context)
        {
            _context = context;

        }

        public IList<Course> CourseList { get; set; } = default!;
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            if (_context.Courses != null)
            {
                CourseList = await _context.Courses
                .Include(c => c.Modality)
                .Include(c => c.Professor).ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(Student == null)
            {
                return NotFound();
            }

            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);

            Course Course = default!;

            if (course != null)
            {
                Course = course;

                Console.WriteLine("Hola");

                //await _context.SaveChangesAsync();
            }

            return Page();
        }
    }

}