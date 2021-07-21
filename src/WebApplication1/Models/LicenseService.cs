using SM.Common.REST;
using WebApplication1.Interfaces;

namespace WebApplication1.Models {
    public class LicenseService : RestClient, ILicenseService {

        // TODO: For now this just returns keys/tokens, but COULD return a license object.

        public LicenseService() {
            BaseAddress = "https://hexlicenseservice.azurewebsites.net/api/license";
        }

        public string GetLicense() {
            return Get();
        }

        public bool IsValidLicense(string licenseId) {

            EndpointMethod = $"/{licenseId}";

            return Get() == "true";
        }

        public void ReturnLicense(string licenseId) {

            EndpointMethod = "/";

            Delete(licenseId);
        }
    }
}