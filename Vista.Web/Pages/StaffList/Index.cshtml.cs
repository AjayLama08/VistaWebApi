﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vista.web.Data;

namespace Vista.Web.Pages.StaffList
{
    public class IndexModel : PageModel
    {
        private readonly Vista.web.Data.WorkshopsContext _context;

        public IndexModel(Vista.web.Data.WorkshopsContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }
    }
}