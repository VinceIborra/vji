using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vji.Mvc {
    public interface Controller {
        ModelAndView Process(Command command);
        ModelAndView ProcessStartCommand(StartCommand command);
        ModelAndView ProcessFinishCommand(FinishCommand command);
        ModelAndView ProcessUnknownCommand(UnknownCommand command);
    }
}
