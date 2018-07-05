using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public abstract class ControllerImpl : Controller {

        public ModelAndView Process(Command command) {
            return command.Process(this);
        }

        public abstract ModelAndView ProcessStartCommand(StartCommand command);

        public abstract ModelAndView ProcessFinishCommand(FinishCommand command);
        
        public abstract ModelAndView ProcessUnknownCommand(UnknownCommand command);

    }
}
