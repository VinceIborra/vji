using System;
using System.Collections.Generic;
using System.Linq;

namespace Vji.Mvc {

    public class PreAndPostCommandsInputDecoratorImpl : Input {
        
//        public Queue<Command> StartCommands { set; get; }
//        
//        protected Command NextStartCommand() {
//            if (this.StartCommands.Count == 0) {
//                return null;
//            }
//            return this.StartCommands.Dequeue();
//        }
//        
//        protected abstract Command NextCommand();
//        

        public Command Next() {
            Command command;
            
            if (this.PreCommandsQueue.IsNotEmpty) {
                return this.PreCommandsQueue.Dequeue();
            }
            Command command
        }
    }
}
