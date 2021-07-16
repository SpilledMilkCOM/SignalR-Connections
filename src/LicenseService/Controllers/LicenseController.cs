    using LicenseService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicenseService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase {

        private readonly ILicense _licensePrototype = null;
        private readonly ILicenses _licenses = null;
        private readonly ILogger<HomeController> _logger;

        public LicenseController(ILicense license, ILicenses licenses, ILogger<HomeController> logger) {
            _licensePrototype = license;
            _licenses = licenses;
            _logger = logger;
        }

        // GET: api/<LicenseController>
        [HttpGet]
        public IEnumerable<string> Get() {

            // For now just return some sort of token

            var license = _licensePrototype.Clone();

            _licenses.Add(license);

            return new string[] { license.Key };
        }

        // GET api/<LicenseController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<LicenseController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<LicenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<LicenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
