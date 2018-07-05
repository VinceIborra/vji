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
    public class CompositeLicenseImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }
        private LicensingFactory LicensingFactory { set; get; }
        private License CompositeLicense { set; get; }
        private CompositeLicenseImpl CompositeLicenseImpl { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = (MockLicensingFactory) Ctx.GetObject("MockLicensingFactory");
            LicensingFactory = (LicensingFactory) Ctx.GetObject("LicensingFactory");
            License license1 = MockLicensingFactory.NewMockLicense();
            License license2 = MockLicensingFactory.NewMockLicense();
            IList<License> licenses = new List<License>();
            licenses.Add(license1);
            licenses.Add(license2);
            CompositeLicense = LicensingFactory.NewCompositeLicense(licenses);
            CompositeLicenseImpl = (CompositeLicenseImpl) CompositeLicense;
        }

        [Test]
        public void TestObtain() {

            Assert.IsFalse(CompositeLicense.Obtained);
            foreach(License license in CompositeLicenseImpl.SubLicenses) {
                Assert.IsFalse(license.Obtained);
            }

            CompositeLicense.Obtain();

            Assert.IsTrue(CompositeLicense.Obtained);
            foreach(License license in CompositeLicenseImpl.SubLicenses) {
                Assert.IsTrue(license.Obtained);
            }
        }

        [Test]
        public void TestRelease() {

            Assert.IsFalse(CompositeLicense.Obtained);
            foreach(License license in CompositeLicenseImpl.SubLicenses) {
                Assert.IsFalse(license.Obtained);
            }

            CompositeLicense.Obtain();

            Assert.IsTrue(CompositeLicense.Obtained);
            foreach(License license in CompositeLicenseImpl.SubLicenses) {
                Assert.IsTrue(license.Obtained);
            }

            CompositeLicense.Release();
            Assert.IsFalse(CompositeLicense.Obtained);
            foreach(License license in CompositeLicenseImpl.SubLicenses) {
                Assert.IsFalse(license.Obtained);
            }
        }

    }
}