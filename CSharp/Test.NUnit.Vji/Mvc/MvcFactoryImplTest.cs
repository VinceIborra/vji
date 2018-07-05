using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vji.Bootstrap;
using Vji.Log4net;
using Vji.Mock.Mvc;
using Vji.Std.Bootstrap;

namespace Vji.Mvc {

    [TestFixture]
    public class MvcFactoryImplTest {

        private Log4netFactory Log4netFactory { set; get; }
        private BootstrapperFactory BootstrapperFactory { set; get; }
        private FactoryImpl MvcFactoryImpl { set; get; }
        private Factory MvcFactory { set; get; }
        private Vji.Mock.Mvc.FactoryImpl MockMvcFactory { set; get; }
        private LoggerSetter LoggerSetter { set; get; }
        private LoggerSetterImpl LoggerSetterImpl { set; get; }
        private Bootstrapper Bootstrapper { set; get; }

        [SetUp]
        public void TestInitialize() {

            // Factories
            Log4netFactory = new Log4netFactoryImpl();
            BootstrapperFactory = new BootstrapperFactoryImpl();
            MvcFactoryImpl = new FactoryImpl();
            MvcFactory = MvcFactoryImpl;
            MockMvcFactory = new Vji.Mock.Mvc.FactoryImpl();

            // Bootstrapping - Logging
            LogBootstrapper logBootstrapper = BootstrapperFactory.NewLogBootstrapper();
            LoggerSetter = Log4netFactory.NewLoggerSetter();
            LoggerSetterImpl = (LoggerSetterImpl) LoggerSetter;
            MvcFactoryImpl.LoggerSetter = LoggerSetter;
            MockMvcFactory.LoggerSetter = LoggerSetter;
            
            // Bootstrapping others
            IList<Bootstrapper> bootstrappers = new List<Bootstrapper>();
            bootstrappers.Add(logBootstrapper);
            bootstrappers.Add(LoggerSetter);
            Bootstrapper = BootstrapperFactory.NewCompositeBootstrapper(LoggerSetter, bootstrappers);
        }

        [Test]
        public void TestNewStartCommand() {
            StartCommand command = MvcFactory.NewStartCommand();
            Assert.IsNotNull(command);
            Assert.IsInstanceOf(typeof(StartCommandImpl), command);
        }

        [Test]
        public void TestNewFinishCommand() {
            FinishCommand command = MvcFactory.NewFinishCommand();
            Assert.IsNotNull(command);
            Assert.IsInstanceOf(typeof(FinishCommandImpl), command);
        }
        
        [Test] public void TestNewUnknownCommand() {
            UnknownCommand command = MvcFactory.NewUnknownCommand("a comment string");
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(UnknownCommandImpl)));
            Assert.That(command.Comment, Is.EqualTo("a comment string"));
        }
        
        [Test]
        public void TestNewSafeView() {
            View unsafeView = new MockViewImpl();
            View safeView = MvcFactory.NewSafeView(unsafeView);
            Assert.That(safeView, Is.Not.Null);
            Assert.That(safeView, Is.InstanceOf(typeof(SafeViewImpl)));
            SafeViewImpl safeViewImpl = safeView as SafeViewImpl;
            Assert.That(safeViewImpl.UnsafeView, Is.EqualTo(unsafeView));
        }

        [Test]
        public void TestNewDriver() {
            ViewResolver viewResolver = MockMvcFactory.NewMockViewResolver();
            Input input = MockMvcFactory.NewMockInput();
            Output output = MockMvcFactory.NewMockOutput(viewResolver);
            Controller controller = MockMvcFactory.NewMockController(MvcFactory);
            Driver driver = MvcFactory.NewDriver(input, output, controller);
            Assert.IsNotNull(driver);
            Assert.IsInstanceOf(typeof(DriverImpl), driver);
            DriverImpl driverImpl = (DriverImpl) driver;
            Assert.AreEqual(MvcFactory, driverImpl.Factory);
            Assert.AreEqual(input, driverImpl.Input);
            Assert.AreEqual(output, driverImpl.Output);
            Assert.AreEqual(controller, driverImpl.Controller);
            Assert.IsTrue(LoggerSetterImpl.LoggerRecipients.Contains(driver));
        }

        [Test]
        public void TestNewModelAndView() {
            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("modelComponent1", "modelValue1");
            string viewName = "testViewName";
            ModelAndView modelAndView = MvcFactory.NewModelAndView(model, viewName);
            Assert.IsNotNull(modelAndView);
            Assert.IsInstanceOf(typeof(ModelAndViewImpl), modelAndView);
            Assert.AreEqual(model, modelAndView.Model);
            Assert.AreEqual(viewName, modelAndView.ViewName);
        }
        
        [Test] public void TestNewPreAndPostCommandsInputDecorator() {

            IList<Command> preCommands = new List<Command>();
            preCommands.Add(this.MvcFactory.NewStartCommand());
            
            IList<Command> postCommands = new List<Command>();
            postCommands.Add(this.MvcFactory.NewFinishCommand());
            
            IList<Command> commands = new List<Command>();
            commands.Add(this.MockMvcFactory.NewMockCommand("a mock command"));
                
            Input input = this.MockMvcFactory.NewMockInput();
            
            Input decoratedInput = this.MvcFactory.NewPreAndPostCommandsInputDecorator(
                input,
                preCommands,
                postCommands
            );
            
            Assert.That(decoratedInput, Is.Not.Null);
            Assert.That(decoratedInput, Is.InstanceOf(PreAndPostCommandsInputDecoratorImpl));
            Assert.That(decoratedInput.Input, Is.EqualTo(input));
            Assert.That(decoratedInput.PreCommands, Is.EqualTo(preCommands));
            Assert.That(decoratedInput.PostCommands, Is.EqualTo(postCommands));
        }
    }
}
