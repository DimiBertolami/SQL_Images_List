using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DimsASP.NET_Core_Distroboot.Data;
using DimsASP.NET_Core_Distroboot.Models;

namespace DimsASP.NET_Core_Distroboot.Pages.Distros
{
    public class CreateModel : PageModel
    {
        private readonly DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext _context;

        public CreateModel(DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Distro Distro { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Distro == null || Distro == null)
            {
                return Page();
            }

            _context.Distro.Add(Distro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
