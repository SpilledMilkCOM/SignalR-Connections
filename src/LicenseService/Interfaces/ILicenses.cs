using System.Collections.Generic;

namespace LicenseService.Interfaces {

    public interface ILicenses : IEnumerable<ILicense> {
        void Add(ILicense license);

        bool Any();

        void Clear();

        ILicense Construct(string id);

        /// <summary>
        /// Create a license key, add it to the internal list, and return it.
        /// </summary>
        /// <returns></returns>
        ILicense Get();

        /// <summary>
        /// Verify that the supplied license is valid.
        /// </summary>
        /// <param name="license">License to validate</param>
        /// <returns>Whether or not the license is valid.</returns>
        bool IsValid(ILicense license);

        void Remove(ILicense license);
    }
}