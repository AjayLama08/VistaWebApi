using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vista.Web.Data;

namespace Vista.Web.Pages.Workshops
{
    public class DetailsModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;

        public DetailsModel(Vista.Web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        public Workshop Workshop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshops.FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshop == null)
            {
                return NotFound();
            }
            else
            {
                Workshop = workshop;
            }
            return Page();
        }
    }
}
