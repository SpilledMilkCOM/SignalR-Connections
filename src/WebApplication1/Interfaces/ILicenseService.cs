namespace WebApplication1.Interfaces {

    public interface ILicenseService {

        string GetLicense();

        bool IsValidLicense(string licenseId);

        void ReturnLicense(string licenseId);
    }
}