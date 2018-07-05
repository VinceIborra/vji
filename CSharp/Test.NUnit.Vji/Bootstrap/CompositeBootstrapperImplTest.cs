using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Mock.Bootstrap;
using Vji.Log4net;
using Vji.Std.Bootstrap;

namespace Vji.Bootstrap {

    [TestFixture]
    public class CompositeBootstrapperImplTest {

        Log4netFactory Log4netFactory { set; get; }
        BootstrapperFactory BootstrapperFactory { set; get; }
        MockBootstrapperFactory MockBootstrapperFactory { set; get; }
        LoggerSetter LoggerSetter { set; get; }
        Bootstrapper MockBootstrapper1 { set; get; }
        Bootstrapper MockBootstrapper2 { set; get; }
        IList<Bootstrapper> MockBootstrapperList { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
            MockBootstrapperFactory = new MockBootstrapperFactoryImpl();
            MockBootstrapper1 = MockBootstrapperFactory.NewMockBootstrapper();
            MockBootstrapper2 = MockBootstrapperFactory.NewMockBootstrapper();
            MockBootstrapperList = new List<Bootstrapper>();
            MockBootstrapperList.Add(MockBootstrapper1);
            MockBootstrapperList.Add(MockBootstrapper2);
        }

        [Test]
        public void TestBootstrap() {
            CompositeBootstrapper bootstrapper = BootstrapperFactory.NewCompositeBootstrapper(LoggerSetter, MockBootstrapperList);
            foreach(Bootstrapper subBootstrapper in MockBootstrapperList) {
                Assert.IsFalse(subBootstrapper.IsDone);
            }
            Assert.IsFalse(bootstrapper.IsDone);
            bootstrapper.Bootstrap();
            foreach(Bootstrapper subBootstrapper in MockBootstrapperList) {
                Assert.IsTrue(subBootstrapper.IsDone);
            }
            Assert.IsTrue(bootstrapper.IsDone);
        }
   }
}