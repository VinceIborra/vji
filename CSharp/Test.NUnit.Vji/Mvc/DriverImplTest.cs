using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Mock.Mvc;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Mvc {

    [TestFixture]
    [BootstrapLog4net]
    public class LoggerSetterClassTest : NUnitStdTestCaseImpl {

        private Vji.Mvc.Factory MvcFactory { set; get; }
        private Vji.Mock.Mvc.Factory MockMvcFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            base.Initialize();
            Vji.Mvc.FactoryImpl mvcFactoryImpl = new Vji.Mvc.FactoryImpl();
            Vji.Mock.Mvc.FactoryImpl mockMvcFactoryImpl = new Vji.Mock.Mvc.FactoryImpl();
            this.MvcFactory = mvcFactoryImpl;
            MockMvcFactory = mockMvcFactoryImpl;
            mvcFactoryImpl.LoggerSetter = LoggerSetter;
            mockMvcFactoryImpl.MvcFactory = this.MvcFactory;
            mockMvcFactoryImpl.LoggerSetter = LoggerSetter;
        }

        [TearDown]
        public void TestCleanup() {
            base.Cleanup();
        }

        [Test]
        public void TestRun() {

            Queue<Command> startCommands = new Queue<Command>();
            startCommands.Enqueue(this.MvcFactory.NewStartCommand());
            
            Queue<Command> mockCommands = new Queue<Command>();
            mockCommands.Enqueue(this.MockMvcFactory.NewMockCommand("message1"));
            mockCommands.Enqueue(this.MockMvcFactory.NewMockCommand("message2"));

            MockInputImpl mockInputImpl = (MockInputImpl) MockMvcFactory.NewMockInput();
            mockInputImpl.StartCommands = startCommands;
            mockInputImpl.MockCommands = mockCommands;
            
            ViewResolver mockViewResolver = MockMvcFactory.NewMockViewResolver();
            
            Output mockOutput = MockMvcFactory.NewMockOutput(mockViewResolver);
            MockOutputImpl mockOutputImpl = (MockOutputImpl) mockOutput;
            
            Controller mockController = MockMvcFactory.NewMockController(this.MvcFactory);
            
            Driver driver = this.MvcFactory.NewDriver(mockInputImpl, mockOutput, mockController);
            
            driver.Run();

            Assert.AreEqual(4, mockOutputImpl.Output.Count);
            Assert.AreEqual("{command => StartCommand}", mockOutputImpl.Output[0].ToString());
            Assert.AreEqual("{command => MockCommand{EnteredString => message1}}", mockOutputImpl.Output[1]);
            Assert.AreEqual("{command => MockCommand{EnteredString => message2}}", mockOutputImpl.Output[2]);
            Assert.AreEqual("{command => FinishCommand}", mockOutputImpl.Output[3]);
        }
    }
}