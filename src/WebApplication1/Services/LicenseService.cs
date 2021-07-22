using SM.Common.REST;
using SM.Serialization;
using WebApplication1.Interfaces;

namespace WebApplication1.Services {
    public class LicenseService : RestClient, ILicenseService {

        private const string ENDPOINT_METHOD_PREFIX = "/api/license";

        // TODO: For now this just returns keys/tokens, but COULD return a license object.

        private readonly ISerializationUtility _serializationUtility;

        public LicenseService(ISerializationUtility serializationUtility) {
            BaseAddress = "https://hexlicenseservice.azurewebsites.net";

            _serializationUtility = serializationUtility;
        }

        public string GetLicense() {

            string result = null;

            // TODO: Look at API to see why returning a string is returning an array.

            EndpointMethod = ENDPOINT_METHOD_PREFIX;

            var jsonData = Get();
            var keyArray = _serializationUtility.Deserialize<string[]>(jsonData);


            if (keyArray.Length > 0) {
                result = keyArray[0];
            }

            return result;
        }

        public bool IsValidLicense(string licenseId) {

            EndpointMethod = $"{ENDPOINT_METHOD_PREFIX}/{licenseId}";
            
            return Get() == "True";
        }

        public void ReturnLicense(string licenseId) {

            EndpointMethod = $"{ENDPOINT_METHOD_PREFIX}/";

            Delete(licenseId);
        }
    }
}