using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Conditions;

namespace Vji.Licensing {
    public interface LicensingFactory {

        License NewCompositeLicense(IList<License> subLicenses);

        Condition NewLicensedCondition(License license);
    }
}
