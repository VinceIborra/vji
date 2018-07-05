using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Licensing;

namespace Vji.Mock.Licensing {
    public class MockLicenseImpl : LicenseImpl, License {

        public override void Obtain() {
            Obtained = true;
        }

        public override void Release() {
            Obtained = false;
        }

    }
}
