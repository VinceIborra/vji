using System;

namespace Vji.Licensing {

    public abstract class LicenseImpl : License {

        public bool Obtained { protected set; get; }

        public LicenseImpl() {
            Obtained = false;
        }

        public abstract void Obtain();

        public abstract void Release();

        public void RunUnder(Action code) {
            try {
                Obtain();
                code();
            }
            finally {
                Release();
            }
        }

    }
}
