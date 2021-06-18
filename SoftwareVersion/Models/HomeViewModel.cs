using SoftwareVersion.Model;
using SoftwareVersion.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersion.Models
{
    public class HomeViewModel
    {
        //[RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,3})?%?$", ErrorMessage = "Invalid Version Entered, please only enters digits 0-9 and decimals")]
        [VersionValidation]
        public string Version { get; set; }
        public List<Software> Softwares { get; set; }
    }
}
