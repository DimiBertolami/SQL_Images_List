using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DimsASP.NET_Core_Distroboot.Models;

namespace DimsASP.NET_Core_Distroboot.Data
{
    public class DimsASPNET_Core_DistrobootContext : DbContext
    {
        public DimsASPNET_Core_DistrobootContext (DbContextOptions<DimsASPNET_Core_DistrobootContext> options)
            : base(options)
        {
        }

        public DbSet<DimsASP.NET_Core_Distroboot.Models.Distro> Distro { get; set; } = default!;
    }
}
