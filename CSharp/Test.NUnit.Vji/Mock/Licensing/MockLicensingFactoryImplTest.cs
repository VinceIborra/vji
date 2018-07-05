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
    public class MockLicensingFactoryImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = new MockLicensingFactoryImpl();
        }

        [Test]
        public void TestNewMockLicense() {
            License license = MockLicensingFactory.NewMockLicense();
            Assert.IsNotNull(license);
            Assert.IsInstanceOf(typeof(MockLicenseImpl), license);
        }

    }
}