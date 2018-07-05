using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Log4net;

namespace Vji.Mvc {

    public class DriverImpl : Driver {

        public Factory Factory { set; get; }
        public ILog Logger { set; get; }
        public Input Input { set; get; }
        public Output Output { set; get; }
        public Controller Controller { set; get; }
        public DriverState State { set; get; }

        public void Run() {
            State = DriverState.Starting;
            while (State != DriverState.Finishing) {

                // Get the next command
                Command command = null;
                if (State == DriverState.Starting) {
                    command = this.Factory.NewStartCommand();
                    State = DriverState.Running;
                }
                else if (State == DriverState.Running) {
                    command = Input.Next();
                }

                // Process the command
                ModelAndView modelAndView = Controller.Process(command);

                // Present the model back to the user
                Output.Present(modelAndView);

                // Make sure we finish cleanly
                if (command is FinishCommand) {
                    State = DriverState.Finishing;
                }
            }
        }
    }
}