using System;

namespace Vji.Mvc {

    public class UnknownCommandImpl : UnknownCommand {
        public string Comment { set; get; }

        public ModelAndView Process(Controller controller) {
            return controller.ProcessUnknownCommand(this);
        }
        
    }
}
