using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public class FinishCommandImpl : FinishCommand {

        public ModelAndView Process(Controller controller) {
            return controller.ProcessFinishCommand(this);
        }

        public override string ToString() {
            return "FinishCommand";
        }

    }
}
