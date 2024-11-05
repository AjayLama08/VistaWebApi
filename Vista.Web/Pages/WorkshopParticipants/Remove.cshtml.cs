using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vista.Web.Data;
using Vista.Web.Data.Vista.Web.Data;

namespace Vista.Web.Pages.WorkshopParticipants
{
    public class RemoveModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;

        public RemoveModel(Vista.Web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkshopStaff WorkshopStaff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? workshopId,int? staffId)
        {
            if (workshopId == null || staffId == null)
            {
                return NotFound();
            }

            var workshopstaff = await _context.WorkshopStaff
                .Include(w => w.Staff)
                .Include(w => w.Workshop)
                .FirstOrDefaultAsync(m => m.WorkshopId == workshopId && m.StaffId == staffId);

            if (workshopstaff == null)
            {
                return NotFound();
            }
            else
            {
                WorkshopStaff = workshopstaff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? workshopId, int? staffId)
        {
            if (workshopId == null || staffId == null)
            {
                return NotFound();
            }

            var workshopstaff = await _context.WorkshopStaff.FirstOrDefaultAsync(m => m.WorkshopId == workshopId && m.StaffId == staffId);
            if (workshopstaff != null)
            {
                WorkshopStaff = workshopstaff;
                _context.WorkshopStaff.Remove(WorkshopStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
