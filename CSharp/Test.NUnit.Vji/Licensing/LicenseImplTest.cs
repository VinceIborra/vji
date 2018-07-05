using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;
using Vji.Mock.Licensing;

namespace Vji.Licensing {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class LicenseImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = (MockLicensingFactory) Ctx.GetObject("MockLicensingFactory");
        }

        [Test]
        public void TestRunUnder() {
            License license = MockLicensingFactory.NewMockLicense();
            Assert.IsFalse(license.Obtained);
            license.RunUnder(() => {
                Assert.IsTrue(license.Obtained);
            });
            Assert.IsFalse(license.Obtained);
        }

    }
}