using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;

namespace Vji.Mvc {
    public class FactoryImpl : Factory {

        public LoggerSetter LoggerSetter { set; get; }

        public StartCommand NewStartCommand() {
            StartCommandImpl startCommand = new StartCommandImpl();
            return startCommand;
        }

        public FinishCommand NewFinishCommand() {
            FinishCommandImpl finishCommand = new FinishCommandImpl();
            return finishCommand;
        }

        public UnknownCommand NewUnknownCommand(string comment) {
            UnknownCommandImpl command = new UnknownCommandImpl();
            command.Comment = comment;
            return command;
        }
        
        public View NewSafeView(View unsafeView) {
            SafeViewImpl safeView = new SafeViewImpl();
            safeView.UnsafeView = unsafeView;
            return safeView;
        }

        public Driver NewDriver(
            Input input,
            Output output,
            Controller controller
        ) {
            DriverImpl driver = new DriverImpl();
            driver.Factory = this;
            driver.Input = input;
            driver.Output = output;
            driver.Controller = controller;
            LoggerSetter.Add(driver);
            return driver;
        }

        public ModelAndView NewModelAndView(
            IDictionary<string, object> model,
            string viewName
        ) {
            ModelAndViewImpl modelAndView = new ModelAndViewImpl();
            modelAndView.Model = model;
            modelAndView.ViewName = viewName;
            return modelAndView;
        }

        public Input NewPreAndPostCommandsInputDecorator(
            Input input,
            IList<Command> preCommands,
            IList<Command> postCommands
        ) {
            throw new Exception("Under construction.");
        }

    }
}
