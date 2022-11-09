﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FundaVida.Data;
using FundaVida.Models;

namespace FundaVida.Pages.Grupos
{
    public class CreateModel : PageModel
    {
        private readonly FundaVida.Data.FundavidadbContext _context;

        public CreateModel(FundaVida.Data.FundavidadbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grupo Grupo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grupos.Add(Grupo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}