using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vista.Web.Data;
using Vista.Web.Services;

namespace Vista.Web.Pages.Workshops
{
    public class CreateModel : PageModel
    {
        private readonly Vista.Web.Data.WorkshopsContext _context;
        private readonly CategoryService _categoryService;

        // Empty SelectListItem List for category drop down
        public List<SelectListItem> CategoryItems { get; set; } = [];

        public CreateModel(Vista.Web.Data.WorkshopsContext context, CategoryService categoryservice)
        {
            _context = context;
            _categoryService = categoryservice;
        }

        public async Task<IActionResult> OnGet()
        {
            // Populate category drop down using service class
            CategoryItems = await _categoryService.GetCategorySelectListAsync();
            return Page();
        }

        [BindProperty]
        public Workshop Workshop { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Populate category drop down using service class to redisplay input form
                CategoryItems = await _categoryService.GetCategorySelectListAsync();
                return Page();
            }

            _context.Workshops.Add(Workshop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
