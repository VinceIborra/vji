using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Log4net;
using Vji.Std.Bootstrap;
using Vji.Spring.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class SpringRunnerImplTest {

        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        private SpringBootstrapper SpringBootstrapper { set; get; }
        private CompositeBootstrapper Bootstrapper { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LogBootstrapper logBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = log4netFactory.NewLoggerSetter();
            SpringBootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
            IList<Bootstrapper> bootstrappers = new List<Bootstrapper>();
            bootstrappers.Add(logBootstrapper);
            bootstrappers.Add(LoggerSetter);
            bootstrappers.Add(SpringBootstrapper);
            Bootstrapper = BootstrapperFactory.NewCompositeBootstrapper(LoggerSetter, bootstrappers);
        }

        [Test]
        public void TestRun() {
            Runner runner = BootstrapperFactory.NewSpringRunner(LoggerSetter, SpringBootstrapper);
            Bootstrapper.Bootstrap();
            Assert.IsFalse(runner.IsDone);
            runner.Run();
            Assert.IsTrue(runner.IsDone);
        }
   }
}