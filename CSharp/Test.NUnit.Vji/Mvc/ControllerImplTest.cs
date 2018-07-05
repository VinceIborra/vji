using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Mock.Mvc;
using Vji.Std.Test;
using Vji.NUnit.Std.Test;

namespace Vji.Mvc {

    [TestFixture]
    [BootstrapLog4net]
    public class ControllerImplTest : NUnitStdTestCaseImpl {

        private Vji.Mvc.Factory MvcFactory { set; get; }
        private Vji.Mock.Mvc.Factory MockMvcFactory { set; get; }

        [SetUp]
        public void TestInitialize() {
            Vji.Mvc.FactoryImpl mvcFactoryImpl = new Vji.Mvc.FactoryImpl();
            Vji.Mock.Mvc.FactoryImpl mockMvcFactoryImpl = new Vji.Mock.Mvc.FactoryImpl();
            MvcFactory = mvcFactoryImpl;
            MockMvcFactory = mockMvcFactoryImpl;
            mvcFactoryImpl.LoggerSetter = LoggerSetter;
            mockMvcFactoryImpl.LoggerSetter = LoggerSetter;
        }

        [Test]
        public void TestProcess() {
            Controller mockController = MockMvcFactory.NewMockController(this.MvcFactory);
            MockControllerImpl mockControllerImpl = (MockControllerImpl) mockController;
            StartCommand startCommand = MvcFactory.NewStartCommand();
            FinishCommand finishCommand = MvcFactory.NewFinishCommand();
            mockController.Process(startCommand);
            mockController.Process(finishCommand);
            Assert.IsTrue(mockControllerImpl.StartCommandsProcessed.Contains(startCommand));
            Assert.IsTrue(mockControllerImpl.FinishCommandsProcessed.Contains(finishCommand));
        }

    }
}