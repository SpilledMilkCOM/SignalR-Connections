using LicenseService.Hubs;
using LicenseService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SM.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicenseService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase {

        private IHubContext<LicenseHub> _licenseHub;
        private readonly ILicenses _licenses = null;
        private readonly ILogger<HomeController> _logger;
        private readonly ISerializationUtility _serializationUtility;

        public LicenseController(ILicenses licenses, ILogger<HomeController> logger, IHubContext<LicenseHub> licenseHub, ISerializationUtility serializationUtility) {
            _licenseHub = licenseHub;
            _licenses = licenses;
            _logger = logger;
            _serializationUtility = serializationUtility;
        }

        // GET: api/<LicenseController>
        [HttpGet]
        public IEnumerable<string> Get() {

            // For now just return some sort of token

            var license = _licenses.Get();

            RefreshAllClients();

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
            throw new NotImplementedException("PUT has not been implemented.");
        }

        [HttpDelete("clear")]
        public void Clear() {
            _licenses.Clear();

            RefreshAllClients();
        }

        // DELETE api/<LicenseController>/<Guid>
        [HttpDelete("{id}")]
        public void Delete(string id) {

            var license = _licenses.Construct(id);

            _licenses.Remove(license);

            RefreshAllClients();
        }

        //----==== PRIVATE ====--------------------------------------------------------------------------------

        private async void RefreshAllClients() {

            var json = _serializationUtility.Serialize(_licenses.ToList());

            await _licenseHub.Clients.All.SendAsync("ReceiveMessage", json);
        }
    }
}