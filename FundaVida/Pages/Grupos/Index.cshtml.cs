using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Entity.Data;
using FundaVida.Entity;

namespace FundaVida.Pages.Grupos
{
    public class IndexModel : PageModel
    {
        private readonly FundavidadbContext _context;

        public IndexModel(FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Grupo> Grupo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Grupos != null)
            {
                Grupo = await _context.Grupos.ToListAsync();
            }
        }
    }
}
