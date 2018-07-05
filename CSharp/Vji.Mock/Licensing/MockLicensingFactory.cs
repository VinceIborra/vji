using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Licensing;

namespace Vji.Mock.Licensing {
    public interface MockLicensingFactory {

        License NewMockLicense();
    }
}
