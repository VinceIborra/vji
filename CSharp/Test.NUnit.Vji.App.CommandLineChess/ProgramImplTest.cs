using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using log4net;
using Vji.Log4net;
using Vji.Bootstrap;
using Vji.Mock.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.App.CommandLineChess {

    class MockRunnerClass : Runner {

        public ILog Logger { set; get; }
        public bool IsDone { set; get; }

        public void Run() {
            IsDone = true;
        }
    }

    [TestFixture]
    public class ProgramImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private MockBootstrapperFactory MockBootstrapperFactory { set; get; }
        private MainFactory MainFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        private Bootstrapper MockBootstrapper { set; get; }
        private MockRunnerClass MockRunner { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            MockBootstrapperFactory = new MockBootstrapperFactoryImpl();
            MainFactory = new MainFactoryClass();
            BootstrapperFactory bootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
            MockBootstrapper = MockBootstrapperFactory.NewMockBootstrapper();
            MockRunner = new MockRunnerClass();
            MockRunner.IsDone = false;
        }

        [Test]
        public void TestRun() {
            Program program = MainFactory.NewProgram(MockBootstrapper, MockRunner);
            program.Run();
            Assert.IsTrue(program.Bootstrapper.IsDone);
            Assert.IsTrue(program.Runner.IsDone);
        }
    }
}