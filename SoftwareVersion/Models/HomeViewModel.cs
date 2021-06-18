using SoftwareVersion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersion.Models
{
    public class HomeViewModel
    {
        public string Version { get; set; }
        public List<Software> Softwares { get; set; }
    }
}
