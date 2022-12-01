using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundaVida.Pages.Management
{
    public class IndexModel : PageModel
    {
        public PageResult OnGet()
        {
            return Page();
        }
    }
}
