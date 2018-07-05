using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Licensing;

namespace Vji.Mock.Licensing {
    public class MockLicensingFactoryImpl : MockLicensingFactory {

        public License NewMockLicense() {
            MockLicenseImpl license = new MockLicenseImpl();
            return license;
        }
    }
}
