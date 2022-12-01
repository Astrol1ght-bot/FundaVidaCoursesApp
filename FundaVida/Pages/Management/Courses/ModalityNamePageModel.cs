using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FundaVida.Pages.Management.Courses
{
    public class ModalityNamePageModel : PageModel
    {
        public SelectList ModalitySL { get; set; }
        public SelectList ProfessorSL { get; set; }

        public void PopulateModalityList(Entity.Data.FundavidadbContext _context,
            object selectedModality = null)
        {
            var modalitiesQuery = from d in _context.Modalities
                                  orderby d.Name
                                  select d;

            ModalitySL = new SelectList(modalitiesQuery.AsNoTracking(),
                "ModalityId", "Name", selectedModality);

        }

        public void PopulateProfessorList(Entity.Data.FundavidadbContext _context,
            object selectedProfessor = null)
        {
            var professorQuery = from d in _context.Professors
                                 orderby d.LastName
                                 select d;

            ProfessorSL = new SelectList(professorQuery.AsNoTracking(),
                "ProfessorId", "FullName", selectedProfessor);

        }

    }
}
