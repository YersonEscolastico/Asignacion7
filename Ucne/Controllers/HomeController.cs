using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ucne.Models;
using Microsoft.Extensions.Options;

namespace Universidad.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<GlobalSettings> _gSettings;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IOptions<PersonalSettings> _personalSettings;
        public HomeController(IOptions<GlobalSettings> gSettings,
            IOptions<AppSettings> appSettings, IOptions<PersonalSettings> personalSettings)
        {
            _gSettings = gSettings;
            _appSettings = appSettings;
            _personalSettings = personalSettings;
        }

        public IActionResult Index()
        {
            ViewBag.NombreCompania = _gSettings.Value.NombreCompania;
            return View();
        }

        public IActionResult Privacy()
        {
            _gSettings.Value.DireccionCompania = "Calle Salcedo Esquina Duvergé";
            _gSettings.Value.NombreCompania = "MonoSoft 2020";
            return View();
        }

        public IActionResult AdminLTE()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
