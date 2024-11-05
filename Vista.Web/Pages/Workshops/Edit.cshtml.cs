using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vista.Web.Data;

namespace Vista.Web.Pages.Workshops
{
    public class EditModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;

        public EditModel(Vista.Web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workshop Workshop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop =  await _context.Workshops.FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshop == null)
            {
                return NotFound();
            }
            Workshop = workshop;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Workshop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(Workshop.WorkshopId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkshopExists(int id)
        {
            return _context.Workshops.Any(e => e.WorkshopId == id);
        }
    }
}
