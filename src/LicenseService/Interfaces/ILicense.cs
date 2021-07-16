namespace LicenseService.Interfaces {

    public interface ILicense {

        string Key { get; set; }

        string Value { get; }

        // Could possibly add type, user and product info here (if needed)

        ILicense Clone();
    }
}