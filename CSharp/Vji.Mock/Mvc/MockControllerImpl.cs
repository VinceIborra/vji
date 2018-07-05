using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Mvc;
using Vji.Log4net;

namespace Vji.Mock.Mvc {
    public class MockControllerImpl : ControllerImpl, Controller, LoggerRecipient {

        public ILog Logger { set; get; }
        public Vji.Mvc.Factory Factory { set; get; }
        public IList<Command> CommandsProcessed { set; get; }
        public IList<StartCommand> StartCommandsProcessed { set; get; }
        public IList<FinishCommand> FinishCommandsProcessed { set; get; }
        public IList<UnknownCommand> UnknownCommandsProcessed { set; get; }

        public MockControllerImpl() {
            CommandsProcessed = new List<Command>();
            StartCommandsProcessed = new List<StartCommand>();
            FinishCommandsProcessed = new List<FinishCommand>();
            UnknownCommandsProcessed = new List<UnknownCommand>();
        }

        public new ModelAndView Process(Command command) {
            ModelAndView modelAndView = base.Process(command);
            CommandsProcessed.Add(command);
            return modelAndView;
        }

        public override ModelAndView ProcessStartCommand(StartCommand command) {
            StartCommandsProcessed.Add(command);
            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("command", command);
            string viewName = "MockView";
            ModelAndView modelAndView = this.Factory.NewModelAndView(model, viewName);
            return modelAndView;
        }

        public override ModelAndView ProcessFinishCommand(FinishCommand command) {
            FinishCommandsProcessed.Add(command);
            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("command", command);
            string viewName = "MockView";
            ModelAndView modelAndView = this.Factory.NewModelAndView(model, viewName);
            return modelAndView;
        }

        public override ModelAndView ProcessUnknownCommand(UnknownCommand command) {
            UnknownCommandsProcessed.Add(command);
            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("command", command);
            string viewName = "MockView";
            ModelAndView modelAndView = this.Factory.NewModelAndView(model, viewName);
            return modelAndView;
        }

        public ModelAndView ProcessMockCommand(Command command) {
            IDictionary<string, object> model = new Dictionary<string, object>();
            model.Add("command", command);
            return this.Factory.NewModelAndView(model, "mockView");
        }
    }
}
