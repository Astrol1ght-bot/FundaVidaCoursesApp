using FundaVida.Entity.Data;
using FundaVida.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundaVida.Pages
{
    public class EnrollStudentModel : PageModel
    {
        private readonly FundavidadbContext _context;

        public EnrollStudentModel(FundavidadbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        
        public void OnGet()
        {
        }
    }
}
