using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.Log4net {

    [TestFixture]
    public class Log4netFactoryImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private LogBootstrapper LogBootstrapper { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            LogBootstrapper = BootstrapperFactory.NewLogBootstrapper();
        }

        [Test]
        public void TestNewLoggerSetter() {
            LoggerSetter loggerSetter = Log4netFactory.NewLoggerSetter();
            Assert.IsNotNull(loggerSetter);
            Assert.IsTrue(loggerSetter is LoggerSetterImpl);
            LoggerSetterImpl loggerSetterImpl = (LoggerSetterImpl) loggerSetter;
            Assert.IsNotNull(loggerSetterImpl.LoggerRecipients);
            Assert.IsTrue(loggerSetterImpl.LoggerRecipients.Count == 0);
        }

        [Test]
        public void TestNewBootstrapDependentLoggerSetter() {
            LoggerSetter loggerSetter = Log4netFactory.NewBootstrapDependentLoggerSetter(LogBootstrapper);
            Assert.IsNotNull(loggerSetter);
            Assert.IsTrue(loggerSetter is BootstrapDependentLoggerSetterImpl);
            BootstrapDependentLoggerSetterImpl loggerSetterImpl = (BootstrapDependentLoggerSetterImpl) loggerSetter;
            Assert.AreEqual(LogBootstrapper, loggerSetterImpl.LogBootstrapper);
            Assert.IsNotNull(loggerSetterImpl.LoggerRecipients);
            Assert.IsTrue(loggerSetterImpl.LoggerRecipients.Count == 0);
        }
    }
}