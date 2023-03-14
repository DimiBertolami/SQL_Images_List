using Microsoft.AspNetCore.Mvc;

namespace DimsASP.NET_Core_Distroboot.Models
{
    public class Distro
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public Double? Size { get; set; }

        public Distro(int iD, string name, string url)
        {
            ID = iD;
            Name = name;
            Url = url;
        }

        //https://localhost:7227/Distros/Details?id=96
    }
}
