using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vista.Web.Data;
using Vista.Web.Data.Vista.Web.Data;

namespace Vista.Web.Pages.WorkshopParticipants
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
        ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FirstName");
        ViewData["WorkshopId"] = new SelectList(_context.Workshops, "WorkshopId", "Name");
            return Page();
        }

        [BindProperty]
        public WorkshopStaff WorkshopStaff { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkshopStaff.Add(WorkshopStaff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
