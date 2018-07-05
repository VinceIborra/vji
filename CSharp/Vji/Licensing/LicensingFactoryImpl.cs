using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Conditions;

namespace Vji.Licensing {
    public class LicensingFactoryImpl : LicensingFactory {


        public License NewCompositeLicense(IList<License> subLicenses) {
            IList<License> list = new List<License>();
            CompositeLicenseImpl compositeLicense = new CompositeLicenseImpl();
            compositeLicense.SubLicenses = subLicenses;
            return compositeLicense;
        }

        public Condition NewLicensedCondition(License license) {
            LicensedConditionImpl condition = new LicensedConditionImpl();
            condition.License = license;
            return condition;
        }
    }
}
