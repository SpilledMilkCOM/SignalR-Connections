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

        private readonly ILicenses _licenses = null;
        private readonly ILogger<HomeController> _logger;

        public LicenseController(ILicenses licenses, ILogger<HomeController> logger) {
            _licenses = licenses;
            _logger = logger;
        }

        // GET: api/<LicenseController>
        [HttpGet]
        public IEnumerable<string> Get() {

            // For now just return some sort of token

            var license = _licenses.Get();

            return new string[] { license.Key };
        }

        // GET api/<LicenseController>/<Guid>
        [HttpGet("{id}")]
        public string Get(string id) {

            var license = _licenses.Construct(id);

            return _licenses.IsValid(license).ToString();
        }

        // POST api/<LicenseController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<LicenseController>/<Guid>
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value) {
        }

        [HttpDelete("clear")]
        public void Clear() {
            _licenses.Clear();
        }

        // DELETE api/<LicenseController>/<Guid>
        [HttpDelete("{id}")]
        public void Delete(string id) {
        }
    }
}