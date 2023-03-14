using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DimsASP.NET_Core_Distroboot.Data;
using DimsASP.NET_Core_Distroboot.Models;

namespace DimsASP.NET_Core_Distroboot.Pages.Distros
{
    public class DetailsModel : PageModel
    {
        private readonly DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext _context;

        public DetailsModel(DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext context)
        {
            _context = context;
        }

      public Distro Distro { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distro == null)
            {
                return NotFound();
            }

            var distro = await _context.Distro.FirstOrDefaultAsync(m => m.ID == id);
            if (distro == null)
            {
                return NotFound();
            }
            else 
            {
                Distro = distro;
            }
            return Page();
        }
    }
}
