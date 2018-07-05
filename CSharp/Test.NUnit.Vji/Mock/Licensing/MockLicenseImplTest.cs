using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;
using Vji.Licensing;

namespace Vji.Mock.Licensing {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class MockLicenseImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }
        private MockLicenseImpl MockLicenseImpl { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = new MockLicensingFactoryImpl();
            License license = MockLicensingFactory.NewMockLicense();
            MockLicenseImpl = (MockLicenseImpl)license;

        }

        [Test]
        public void TestObtain() {
            Assert.IsFalse(MockLicenseImpl.Obtained);
            MockLicenseImpl.Obtain();
            Assert.IsTrue(MockLicenseImpl.Obtained);
        }

        [Test]
        public void TestRelease() {
            Assert.IsFalse(MockLicenseImpl.Obtained);
            MockLicenseImpl.Obtain();
            Assert.IsTrue(MockLicenseImpl.Obtained);
            MockLicenseImpl.Release();
            Assert.IsFalse(MockLicenseImpl.Obtained);
        }

    }
}