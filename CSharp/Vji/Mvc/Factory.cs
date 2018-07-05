using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vji.Log4net;

namespace Vji.Mvc {
    public interface Factory {

        StartCommand NewStartCommand();

        FinishCommand NewFinishCommand();
        
        UnknownCommand NewUnknownCommand(string comment);
        
        View NewSafeView(View unsafeView);

        ModelAndView NewModelAndView(
            IDictionary<string, object> model,
            string viewName
        );

        Driver NewDriver(
            Input input,
            Output output,
            Controller controller
        );
        
        Input NewPreAndPostCommandsInputDecorator(
            Input input,
            IList<Command> preCommands,
            IList<Command> postCommands
        );
    }
}
