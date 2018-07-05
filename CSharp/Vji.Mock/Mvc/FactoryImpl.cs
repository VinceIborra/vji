using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Mvc;
using Vji.Log4net;

namespace Vji.Mock.Mvc {
    public class FactoryImpl : Vji.Mock.Mvc.Factory, LoggerRecipient {

        public ILog Logger { set; get; }
        public Vji.Mvc.Factory MvcFactory { set; get; }
        public LoggerSetter LoggerSetter { set; get; }

        public Input NewMockInput() {
            MockInputImpl input = new MockInputImpl();
            input.MvcFactory = this.MvcFactory;
            input.MockMvcFactory = this;
            LoggerSetter.Add(input);
            return input;
        }

        public Output NewMockOutput(ViewResolver viewResolver) {
            MockOutputImpl output = new MockOutputImpl();
            LoggerSetter.Add(output);
            output.ViewResolver = viewResolver;
            return output;
        }

        public Controller NewMockController(Vji.Mvc.Factory mvcFactory) {
            MockControllerImpl controller = new MockControllerImpl();
            controller.Factory = mvcFactory;
            LoggerSetter.Add(controller);
            return controller;
        }

        public ViewResolver NewMockViewResolver() {
            MockViewResolverImpl viewResolver = new MockViewResolverImpl();
            viewResolver.MockMvcFactory = this;
            LoggerSetter.Add(viewResolver);
            return viewResolver;
        }

        public View NewMockView(string viewName) {
            MockViewImpl view = new MockViewImpl();
            view.Name = viewName;
            LoggerSetter.Add(view);
            return view;
        }

        public Command NewMockCommand(string message) {
            MockCommandImpl command = new MockCommandImpl();
            command.Message = message;
            return command;
        }
    }
}
