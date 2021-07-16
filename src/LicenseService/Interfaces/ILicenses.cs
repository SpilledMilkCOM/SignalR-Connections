using System.Collections.Generic;

namespace LicenseService.Interfaces {

    public interface ILicenses : IEnumerable<ILicense> {
        void Add(ILicense license);

        bool Any();

        void Remove(ILicense license);
    }
}