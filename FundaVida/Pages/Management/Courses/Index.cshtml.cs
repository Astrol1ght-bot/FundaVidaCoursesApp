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
    public class IndexModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public IndexModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses
                .Include(c => c.Modality)
                .Include(c => c.Professor).ToListAsync();
            }
        }
    }
}
