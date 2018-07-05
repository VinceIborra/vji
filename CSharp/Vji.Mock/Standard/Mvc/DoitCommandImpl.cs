using System;
using Vji.Mvc;

namespace Vji.Mock.Standard.Mvc {

    public class DoitCommandImpl : DoitCommand {
        
        public ModelAndView Process(Controller controller) {
            throw new Exception("Under construction.");
            // return controller.ProcessStartCommand(this);
        }
        
    }
}
