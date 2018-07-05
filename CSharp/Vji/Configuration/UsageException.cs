using System;

namespace Vji.Configuration {
    public class UsageException : Exception {

        public string Usage { set; get; }

        public UsageException(string message)
            : base(message) {
        }
    }
}
