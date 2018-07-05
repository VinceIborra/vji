using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Std.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class LogBootstrapperImplTest {

        BootstrapperFactory BootstrapperFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            BootstrapperFactory = new BootstrapperFactoryImpl();
        }

        [Test]
        public void TestBootstrap() {
            LogBootstrapper bootstrapper = BootstrapperFactory.NewLogBootstrapper();
            Assert.IsFalse(bootstrapper.IsDone);
            bootstrapper.Bootstrap();
            Assert.IsTrue(bootstrapper.IsDone);
        }
   }
}