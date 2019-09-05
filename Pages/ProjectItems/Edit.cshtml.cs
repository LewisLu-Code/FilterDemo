using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilterDemo.Data;
using FilterDemo.Models;

namespace FilterDemo.Pages.ProjectItems
{
    public class EditModel : PageModel
    {
        private readonly FilterDemo.Data.ManagementContext _context;

        public EditModel(FilterDemo.Data.ManagementContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectItemExists(ProjectItem.ProjectID))
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

        private bool ProjectItemExists(int id)
        {
            return _context.ProjectItems.Any(e => e.ProjectID == id);
        }
    }
}
