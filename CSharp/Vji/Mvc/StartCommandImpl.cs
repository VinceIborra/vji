using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public class StartCommandImpl : StartCommand {

        public ModelAndView Process(Controller controller) {
            return controller.ProcessStartCommand(this);
        }

        public override string ToString() {
            return "StartCommand";
        }
    }
}
