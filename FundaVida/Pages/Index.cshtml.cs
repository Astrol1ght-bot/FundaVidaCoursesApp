using FundaVida.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FundaVida.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.FundavidadbContext _context;

        public IndexModel(Data.FundavidadbContext context)
        {
            _context = context;

        }

        public IList<HorarioViewModel> HorarioList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if(_context.Horarios != null)
            {
                //Horario = await _context.Horarios.ToListAsync();
                HorarioList = await (from hr in _context.Horarios
                                     join curso in _context.Cursos on hr.CursoId equals curso.CursoId
                                     join grupo in _context.Grupos on hr.GrupoId equals grupo.GrupoId
                                     join vacante in _context.Vacantes on hr.VacanteId equals vacante.VacanteId
                                     join profesor in _context.Profesors on hr.ProfesorId equals profesor.ProfesorId

                                     select new HorarioViewModel
                                     {
                                         horarioId = hr.HorarioId,
                                         cursonombre = curso.CursoNombre,
                                         cursoimagen = curso.CursoImagen,
                                         horainicio = vacante.HoraInicio,
                                         horafin = vacante.HoraFin
                                     }


                                     ).ToListAsync();
            }

            return Page();
        }
    }

}