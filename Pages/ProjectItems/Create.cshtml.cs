using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FilterDemo.Data;
using FilterDemo.Models;

namespace FilterDemo.Pages.ProjectItems
{
    public class CreateModel : PageModel
    {
        private readonly FilterDemo.Data.ManagementContext _context;

        public CreateModel(FilterDemo.Data.ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProjectItem ProjectItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProjectItems.Add(ProjectItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}