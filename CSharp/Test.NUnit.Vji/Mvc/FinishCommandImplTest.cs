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
    public class FinishCommandImplTest : NUnitStdTestCaseImpl {

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
        public void TestRun() {
            Controller mockController = MockMvcFactory.NewMockController(MvcFactory);
            MockControllerImpl mockControllerImpl = (MockControllerImpl) mockController;
            FinishCommand command = MvcFactory.NewFinishCommand();
            command.Process(mockController);
            Assert.IsTrue(mockControllerImpl.FinishCommandsProcessed.Contains(command));
        }

        [Test]
        public void TestToString() {
            FinishCommand command = MvcFactory.NewFinishCommand();
            Assert.AreEqual("FinishCommand", command.ToString());
        }

    }
}