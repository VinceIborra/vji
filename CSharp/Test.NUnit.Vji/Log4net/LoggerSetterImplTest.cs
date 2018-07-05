using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Mock.Log4net;
using Vji.Bootstrap;
using Vji.Std.Bootstrap;

namespace Vji.Log4net {

    [TestFixture]
    public class LoggerSetterImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private MockLog4netFactory MockLog4netFactory { set; get; }
        private LoggerRecipient MockLoggerRecipient { set; get; }

        [SetUp]
        public void TestInitialize() {
            Log4netFactory = new Log4netFactoryImpl();
            MockLog4netFactory = new MockLog4netFactoryImpl();
            MockLoggerRecipient = MockLog4netFactory.NewMockLoggerRecipient();
        }

        [Test]
        public void TestAdd() {
            BootstrapperFactory bootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter loggerSetter = Log4netFactory.NewLoggerSetter();
            LoggerSetterImpl loggerSetterImpl = (LoggerSetterImpl) loggerSetter;
            Assert.IsTrue(loggerSetterImpl.LoggerRecipients.Count == 0);
            loggerSetter.Add(MockLoggerRecipient);
            Assert.IsTrue(loggerSetterImpl.LoggerRecipients.Count == 1);
        }

        [Test]
        public void TestSetLoggers() {
            BootstrapperFactory bootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter loggerSetter = Log4netFactory.NewLoggerSetter();
            loggerSetter.Add(MockLoggerRecipient);
            loggerSetter.SetLoggers();
            Assert.IsNotNull(MockLoggerRecipient);
        }

        [Test]
        public void TestBootstrap() {
            BootstrapperFactory bootstrapperFactory = new BootstrapperFactoryImpl();
            LoggerSetter loggerSetter = Log4netFactory.NewLoggerSetter();
            loggerSetter.Add(MockLoggerRecipient);
            loggerSetter.Bootstrap();
            Assert.IsNotNull(MockLoggerRecipient);
        }
    }
}