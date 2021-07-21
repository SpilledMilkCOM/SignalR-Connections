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

        public IActionResult Clear() {

            // Kind of cheating so I don't have to call the endpoint.

            _licenses.Clear();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id) {

            var license = _licenses.Construct(id);

            _licenses.Remove(license);

            return RedirectToAction("Index");
        }

        public IActionResult Get() {

            // Kind of cheating so I don't have to call the endpoint.

            _licenses.Get();

            return RedirectToAction("Index");
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
