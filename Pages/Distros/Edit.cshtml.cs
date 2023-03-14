using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimsASP.NET_Core_Distroboot.Data;
using DimsASP.NET_Core_Distroboot.Models;

namespace DimsASP.NET_Core_Distroboot.Pages.Distros
{
    public class EditModel : PageModel
    {
        private readonly DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext _context;

        public EditModel(DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Distro Distro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distro == null)
            {
                return NotFound();
            }

            var distro =  await _context.Distro.FirstOrDefaultAsync(m => m.ID == id);
            if (distro == null)
            {
                return NotFound();
            }
            Distro = distro;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Distro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistroExists(Distro.ID))
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

        private bool DistroExists(int id)
        {
          return (_context.Distro?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
