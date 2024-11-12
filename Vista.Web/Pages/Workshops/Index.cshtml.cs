using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vista.Web.Data;
using Vista.Web.Services;
using Vista.Web.ViewModels;

namespace Vista.Web.Pages.Workshops
{
    public class IndexModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;
        private readonly CategoryService _categoryService;

        // Empty SelectListItem List for category drop down
        public List<SelectListItem> CategoryItems { get; set; } = [];

        //Page model constructor with database context and category service passes in via DI (dependency injection)
        public IndexModel(Vista.Web.Data.WorkshopsContext context, CategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public IList<WorkshopVM> Workshop { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Get list of Categories from service
            var catList = await _categoryService.GetCategoryItemsAsync();

            // Get workshops from data base via EF
            var workshops = await _context.Workshops.ToListAsync();

            // Convert data model to view model with category name
            // This de-couples the UI from the database
            Workshop = workshops.Select(w => new WorkshopVM
            {
                WorkshopId = w.WorkshopId,
                Name = w.Name,
                DateAndTime = w.DateAndTime,
                BookingRef = w.BookingRef,
                CategoryCode = w.CategoryCode,
                CategoryName = catList.FirstOrDefault(c => c.CategoryCode == w.CategoryCode)?
                                    .CategoryName ?? w.CategoryCode
            })
            .ToList();
        }
    }
}
