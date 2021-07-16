using LicenseService.Interfaces;
using LicenseService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LicenseService.Controllers {
    public class HomeController : Controller {

        private readonly ILicenses _licenses = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILicenses licenses, ILogger<HomeController> logger) {
            _licenses = licenses;
            _logger = logger;
        }

        public IActionResult Index() {

            var viewModel = new IndexViewModel {
                Licenses = _licenses
            };

            return View(viewModel);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
