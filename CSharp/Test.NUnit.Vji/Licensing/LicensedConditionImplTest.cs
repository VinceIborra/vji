using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.Conditions;
using Vji.NUnit.Std.Test;
using Vji.Mock.Licensing;

namespace Vji.Licensing {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class LicensedConditionImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }
        private LicensingFactory LicensingFactory { set; get; }
        private License License { set; get; }
        private Condition LicenseCondition { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = (MockLicensingFactory) Ctx.GetObject("MockLicensingFactory");
            LicensingFactory = (LicensingFactory) Ctx.GetObject("LicensingFactory");
            License = MockLicensingFactory.NewMockLicense();
            LicenseCondition = LicensingFactory.NewLicensedCondition(License);
        }

        [Test]
        public void TestSetup() {
            Assert.IsFalse(License.Obtained);
            LicenseCondition.Setup();
            Assert.IsTrue(License.Obtained);
        }

        [Test]
        public void TestTeardown() {
            Assert.IsFalse(License.Obtained);
            LicenseCondition.Setup();
            Assert.IsTrue(License.Obtained);
            LicenseCondition.Teardown();
            Assert.IsFalse(License.Obtained);
        }

    }
}