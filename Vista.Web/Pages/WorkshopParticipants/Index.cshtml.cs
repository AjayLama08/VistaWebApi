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
    public class IndexModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;

        public IndexModel(Vista.Web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        public IList<WorkshopStaff> WorkshopStaff { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            var workshopsContext = _context.WorkshopStaff.AsQueryable();
            if (id != null)
            {
                workshopsContext = workshopsContext.Where(ws => ws.WorkshopId == id);
            }
            workshopsContext = workshopsContext
            .Include(w => w.Staff)
            .Include(w => w.Workshop);
            WorkshopStaff = await workshopsContext.ToListAsync();
        }
    }
}
