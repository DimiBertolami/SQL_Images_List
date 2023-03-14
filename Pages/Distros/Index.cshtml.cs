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
    public class IndexModel : PageModel
    {
        private readonly DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext _context;

        public IndexModel(DimsASP.NET_Core_Distroboot.Data.DimsASPNET_Core_DistrobootContext context)
        {
            _context = context;
        }

        public IList<Distro> Distro { get;set; } = default;

        [HttpGet("/Details?{id}", Name = "Distro_List")]
        public IActionResult getDistro(string id, IActionResult v)
        {
            return v; //ControllerContext; // .MyDisplayRouteInfo(id);
        }

        public async Task OnGetAsync(string searchString)
        {
            var distros = from d in _context.Distro
                         select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                distros = distros.Where(s => s.Name.Contains(searchString));
            }
            Distro = await _context.Distro.ToListAsync();
        }
    }
}
