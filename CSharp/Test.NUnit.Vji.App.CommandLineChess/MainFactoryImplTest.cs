using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Spring.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.App.CommandLineChess {

    [TestFixture]
    public class MainFactoryImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private MainFactory MainFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        private LogBootstrapper LogBootstrapper { set; get; }
        private AssemblyResolver AssemblyResolver { set; get; }
        private SpringBootstrapper SpringBootstrapper { set; get; }
        private IList<Bootstrapper> Bootstrappers { set; get; }
        private CompositeBootstrapper CompositeBootstrapper { set; get; }
        private Runner Runner { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            MainFactory = new MainFactoryClass();
            LogBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
            AssemblyResolver = BootstrapperFactory.NewAssemblyResolver(LoggerSetter);
            SpringBootstrapper = BootstrapperFactory.NewSpringBootstrapper(LoggerSetter);
            Bootstrappers = new List<Bootstrapper>();
            Bootstrappers.Add(LogBootstrapper);
            Bootstrappers.Add(AssemblyResolver);
            Bootstrappers.Add(SpringBootstrapper);
            CompositeBootstrapper = BootstrapperFactory.NewCompositeBootstrapper(LoggerSetter, Bootstrappers);
            Runner = BootstrapperFactory.NewSpringRunner(LoggerSetter, SpringBootstrapper);
        }

        [Test]
        public void TestNewProgram() {
            Program program = MainFactory.NewProgram(CompositeBootstrapper, Runner);
            Assert.IsNotNull(program);
            Assert.IsInstanceOf(typeof(ProgramClass), program);
            ProgramClass programImpl = (ProgramClass) program;
            Assert.AreEqual(CompositeBootstrapper, programImpl.Bootstrapper);
        }
    }
}