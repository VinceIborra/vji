using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Mvc;

namespace Vji.Mock.Mvc {
    public class MockCommandImpl : MockCommand {

        public string Message { set; get; }

        public ModelAndView Process(Controller controller) {
            return ((MockControllerImpl) controller).ProcessMockCommand(this);
        }

        public override string ToString() {
            return "MockCommand{Message => " + this.Message + "}";
        }

    }
}
