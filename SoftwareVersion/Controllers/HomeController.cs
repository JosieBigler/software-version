using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareVersion.Model;
using SoftwareVersion.Models;
using SoftwareVersion.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(HomeViewModel model)
        {
            if (model.Softwares is null)
            {
                model.Softwares = new List<Software>();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VersionInput(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Version = model.Version ?? "0";
                model.Softwares = SoftwareManager.GetAllSoftware().Where(x => Logic.Version.GreaterThan(x.Version, model.Version)).ToList();
                return View("Index", model);

            }

            model.Softwares = new List<Software>();
            return View("Index", model);
        }
    }
}
