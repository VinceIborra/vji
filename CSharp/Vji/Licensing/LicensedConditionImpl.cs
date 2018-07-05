using System;
using Vji.Conditions;

namespace Vji.Licensing {
    public class LicensedConditionImpl : ConditionClass, Condition {

        public License License { set; get; }

        public override void Setup() {
            License.Obtain();
        }

        public override void Teardown() {
            License.Release();
        }
    }
}
