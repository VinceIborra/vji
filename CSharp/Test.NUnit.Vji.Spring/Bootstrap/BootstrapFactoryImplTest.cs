using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Log4net;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class MainFactoryClassTest {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        private LoggerSetterImpl LoggerSetterImpl { set; get; }
        private LogBootstrapper LogBootstrapper { set; get; }
        private SpringBootstrapper SpringBootstrapper { set; get; }
        private IList<Bootstrapper> Bootstrappers { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LogBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
            LoggerSetterImpl = (LoggerSetterImpl) LoggerSetter;
            SpringBootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
            Bootstrappers = new List<Bootstrapper>();
            Bootstrappers.Add(LogBootstrapper);
        }

        [Test]
        public void TestNewLogBootstrapper() {
            LogBootstrapper logBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            Assert.IsNotNull(logBootstrapper);
            Assert.IsInstanceOf(typeof(Bootstrapper), logBootstrapper);
            Assert.IsInstanceOf(typeof(LogBootstrapperImpl), logBootstrapper);
        }

        [Test]
        public void TestNewAssemblyResolver() {
            AssemblyResolver assemblyResolver = BootstrapperFactory.NewAssemblyResolver(LoggerSetter);
            Assert.IsNotNull(assemblyResolver);
            Assert.IsInstanceOf(typeof(Bootstrapper), assemblyResolver);
            Assert.IsInstanceOf(typeof(AssemblyResolverImpl), assemblyResolver);
            Assert.IsTrue(LoggerSetterImpl.LoggerRecipients.Contains(assemblyResolver));
        }

        [Test]
        public void TestNewSpringBootstrapper() {
            SpringBootstrapper springBootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
            Assert.IsNotNull(springBootstrapper);
            Assert.IsInstanceOf(typeof(Bootstrapper), springBootstrapper);
            Assert.IsInstanceOf(typeof(SpringBootstrapperImpl), springBootstrapper);
            Assert.IsTrue(LoggerSetterImpl.LoggerRecipients.Contains(springBootstrapper));
        }

        [Test]
        public void TestNewCompositeBootstrapper() {
            CompositeBootstrapper compositeBootstrapper = BootstrapperFactory.NewCompositeBootstrapper(LoggerSetter, Bootstrappers);
            Assert.IsNotNull(compositeBootstrapper);
            Assert.IsInstanceOf(typeof(Bootstrapper), compositeBootstrapper);
            Assert.IsInstanceOf(typeof(CompositeBootstrapperImpl), compositeBootstrapper);
            CompositeBootstrapperImpl compositeBootstrapperImpl = (CompositeBootstrapperImpl) compositeBootstrapper;
            Assert.AreEqual(Bootstrappers, compositeBootstrapperImpl.SubBootstrappers);
            Assert.IsTrue(LoggerSetterImpl.LoggerRecipients.Contains(compositeBootstrapper));
        }

        [Test]
        public void TestNewSpringRunner() {
            Runner runner = BootstrapperFactory.NewSpringRunner(LoggerSetter, SpringBootstrapper);
            Assert.IsNotNull(runner);
            Assert.IsInstanceOf(typeof(SpringRunnerImpl), runner);
            Assert.IsTrue(LoggerSetterImpl.LoggerRecipients.Contains(runner));
        }
    }
}