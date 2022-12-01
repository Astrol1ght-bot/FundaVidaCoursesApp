using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Professors
{
    public class IndexModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public IndexModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Professor> Professor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Professors != null)
            {
                Professor = await _context.Professors.ToListAsync();
            }
        }
    }
}
