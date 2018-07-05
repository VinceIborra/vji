using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;
using Vji.Mvc;
using Vji.Spring.Mvc;

namespace Vji.Spring.Mvc {

    [TestFixture]
    [BootstrapLog4net]
    [BootstrapSpring]
    public class SpringViewResolverImplTest : NUnitStdTestCaseImpl {

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
        }

        [Test]
        public void TestResolve() {
            ViewResolver viewResolver = (ViewResolver) Ctx.GetObject("SpringViewResolver");
            Assert.IsInstanceOf(typeof(SpringViewResolverImpl), viewResolver);
            View view = viewResolver.Resolve("MockView");
            Assert.That(view, Is.Not.Null);
            Assert.That(view, Is.InstanceOf(typeof(SafeViewImpl)));
        }

    }
}