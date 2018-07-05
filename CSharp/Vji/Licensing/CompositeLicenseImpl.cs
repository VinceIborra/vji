using System;
using System.Collections.Generic;
using System.Text;

namespace Vji.Licensing {
    public class CompositeLicenseImpl : LicenseImpl, License {

        public IList<License> SubLicenses { set; get; }

        public override void Obtain() {
            foreach(License license in SubLicenses) {
                license.Obtain();
            }
            Obtained = true;
        }

        public override void Release() {
            foreach(License license in SubLicenses) {
                license.Release();
            }
            Obtained = false;
        }
    }
}
