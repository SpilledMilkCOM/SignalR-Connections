using LicenseService.Interfaces;
using System;

namespace LicenseService.Models {
    public class License : ILicense {
        private Guid _token = Guid.Empty;

        public string Key {
            get { return _token.ToString(); }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("The property cannot be null or empty.", nameof(Key));
                }

                _token = new Guid(value);
            }
        }

        public string Value => _token.ToString();

        public License() {
            _token = Guid.NewGuid();
        }

        public License(string token) {

            if (string.IsNullOrEmpty(token)) {
                throw new ArgumentException("The argument cannot be null or empty.", nameof(token));
            }

            _token = new Guid(token);
        }

        public ILicense Clone() {
            return new License();
        }
    }
}