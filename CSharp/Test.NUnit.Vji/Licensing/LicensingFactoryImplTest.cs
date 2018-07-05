using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;
using Vji.Licensing;
using Vji.Conditions;
using Vji.Mock.Licensing;

namespace Vji.Licensing {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class LicensingFactoryImplTest : NUnitStdTestCaseImpl {

        private MockLicensingFactory MockLicensingFactory { set; get; }
        private LicensingFactory LicensingFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            MockLicensingFactory = (MockLicensingFactory) Ctx.GetObject("MockLicensingFactory");
            LicensingFactory = (LicensingFactory) Ctx.GetObject("LicensingFactory");
        }

        [Test]
        public void TestNewCompositeLicense() {
            IList<License> subLicenses = new List<License>();
            License subLicense1 = MockLicensingFactory.NewMockLicense();
            License subLicense2 = MockLicensingFactory.NewMockLicense();
            subLicenses.Add(subLicense1);
            subLicenses.Add(subLicense2);
            License license = LicensingFactory.NewCompositeLicense(subLicenses);
            Assert.IsNotNull(license);
            Assert.IsInstanceOf(typeof(CompositeLicenseImpl), license);
            CompositeLicenseImpl compositeLicenseImpl = (CompositeLicenseImpl) license;
            Assert.AreEqual(subLicenses, compositeLicenseImpl.SubLicenses);
        }

        [Test]
        public void TestNewLicensedCondition() {
            License license = MockLicensingFactory.NewMockLicense();
            Condition condition = LicensingFactory.NewLicensedCondition(license);
            Assert.IsNotNull(condition);
            Assert.IsInstanceOf(typeof(LicensedConditionImpl), condition);
            LicensedConditionImpl conditionImpl = (LicensedConditionImpl) condition;
            Assert.AreEqual(license, conditionImpl.License);
        }

    }
}