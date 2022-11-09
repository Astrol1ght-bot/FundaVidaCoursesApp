﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FundaVida.Data;
using FundaVida.Models;

namespace FundaVida.Pages.Estudiantes
{
    public class IndexModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public IndexModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiante { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Estudiantes != null)
            {
                Estudiante = await _context.Estudiantes.ToListAsync();
            }
        }
    }
}
