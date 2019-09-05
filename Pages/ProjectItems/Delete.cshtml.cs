using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilterDemo.Data;
using FilterDemo.Models;

namespace FilterDemo.Pages.ProjectItems
{
    public class DeleteModel : PageModel
    {
        private readonly FilterDemo.Data.ManagementContext _context;

        public DeleteModel(FilterDemo.Data.ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectItem ProjectItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectItem = await _context.ProjectItems.FirstOrDefaultAsync(m => m.ProjectID == id);

            if (ProjectItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectItem = await _context.ProjectItems.FindAsync(id);

            if (ProjectItem != null)
            {
                _context.ProjectItems.Remove(ProjectItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
