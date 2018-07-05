using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Vji.Mvc;
using Vji.Log4net;

namespace Vji.Mock.Mvc {
    public class MockInputImpl : PreAndPostCommandsInputDecoratorImpl, Input, LoggerRecipient {

        public Vji.Mvc.Factory MvcFactory { set; get; }
        public Vji.Mock.Mvc.Factory MockMvcFactory { set; get; }
        public ILog Logger { set; get; }
        
        public Queue<Command> MockCommands { set; get; }
        
        protected override Command NextCommand() {
            if (this.MockCommands.Count == 0) {
                return null;
            }
            return this.MockCommands.Dequeue();
        }
    }
}
