using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FundaVida.Data;
using FundaVida.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace FundaVida.Pages.Cursos
{
    public class CreateModel : PageModel
    {
        private readonly FundavidadbContext _context;

        public CreateModel(FundavidadbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Curso Curso { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Curso.ImageFile != null)
            {
                byte[] pic = null;

                using (Stream fs = Curso.ImageFile.OpenReadStream())
                {
                    using (var memorystream = new MemoryStream())
                    {
                        fs.CopyTo(memorystream);
                        pic = memorystream.ToArray();
                    }
                }

                Curso.CursoImagen = pic;
            }


            _context.Cursos.Add(Curso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
