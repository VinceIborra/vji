using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Log4net;
using Vji.Std.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class AssemblyResolverImplTest {

        Log4netFactory Log4netFactory { set; get; }
        BootstrapperFactory BootstrapperFactory { set; get; }
        LoggerSetter LoggerSetter { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter = log4netFactory.NewLoggerSetter();
        }

        [Test]
        public void TestBootstrap() {
            AssemblyResolver bootstrapper = BootstrapperFactory.NewAssemblyResolver(LoggerSetter);
            LoggerSetter.SetLoggers();
            Assert.IsFalse(bootstrapper.IsDone);
            bootstrapper.Bootstrap();
            Assert.IsTrue(bootstrapper.IsDone);
        }
   }
}