using LicenseService.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LicenseService.Models {

    // This is a STATIC list to contain the list of licenses retrieved.

    public class LicenseList : ILicenses {

        private readonly ILicense _licensePrototype = null;
        private readonly Dictionary<string, ILicense> _licenses = new Dictionary<string, ILicense>();

        public LicenseList(ILicense license) {
            _licensePrototype = license;
        }

        public void Add(ILicense license) {

            if (_licenses.ContainsKey(license.Key)) {
                throw new ArgumentException("The key already exists.", nameof(license));
            }

            _licenses.Add(license.Key, license);
        }

        public bool Any() {
            return _licenses.Any();
        }

        public void Clear() {
            _licenses.Clear();
        }

        public ILicense Construct(string id) {
            var license = _licensePrototype.Clone();

            license.Key = id;

            return license;
        }

        public ILicense Get() {
            var license = _licensePrototype.Clone();

            Add(license);

            return license;
        }

        public bool IsValid(ILicense license) {
            // TODO: Might implement operator==

            return _licenses.Any(item => item.Key == license.Key);
        }

        public IEnumerator<ILicense> GetEnumerator() {
            return _licenses.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _licenses.Values.GetEnumerator();
        }

        public void Remove(ILicense license) {
            _licenses.Remove(license.Key);
        }
    }
}