using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity.Models;

namespace FundaVida.Pages.Management.Modules
{
    public class IndexModel : PageModel
    {
        private readonly FundaVida.Entity.Data.FundavidadbContext _context;

        public IndexModel(FundaVida.Entity.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Module> Module { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Modules != null)
            {
                Module = await _context.Modules
                .Include(e => e.Course).ToListAsync();
            }
        }
    }
}
