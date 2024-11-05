using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vista.Web.Data;

namespace Vista.Web.Pages.Workshops
{
    public class CreateModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;

        public CreateModel(Vista.Web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Workshop Workshop { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workshops.Add(Workshop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
