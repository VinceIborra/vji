using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Log4net;
using Spring.Context;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class SpringBootstrapperImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
        }

        [Test]
        public void TestBootstrap() {
            SpringBootstrapper bootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
            LoggerSetter.Bootstrap();
            Assert.IsFalse(bootstrapper.IsDone);
            bootstrapper.Bootstrap();
            Assert.IsTrue(bootstrapper.IsDone);
            Assert.IsNotNull(bootstrapper.Ctx);
        }
   }
}